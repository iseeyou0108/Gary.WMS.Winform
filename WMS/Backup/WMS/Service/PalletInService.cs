using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace WMS.Service
{
    public class PalletInService
    {
        static System.Resources.ResourceManager RMPublic = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}Resource_Public", ""), System.Reflection.Assembly.GetExecutingAssembly());

        string QuerySql = "select a.* " +
                           "       , case when a.STATUS = 0 then @STATUS0 " +
                           "              when a.STATUS = 1 then @STATUS1 " +
                           "              when a.STATUS = 2 then @STATUS2 " +
                           "              else convert(varchar, a.STATUS) end STATUS_DESC " +
                           "       ,isnull(b.USER_NAME, a.CREATE_BY) as CREATE_NAME " +
                           "       ,isnull(c.USER_NAME, a.UPDATE_BY) as UPDATE_NAME " +
                           "       ,isnull(d.PROD_NAME,a.PROD_NO) as PROD_NAME " +
                           "       ,isnull(e.SNAME,a.ORG_NO) as ORG_SNAME " +
                           "from CUS_BARCODE_INFO a " +
                           "left join HRS_USER b on a.CREATE_BY = b.USER_NO " +
                           "left join HRS_USER c on a.UPDATE_BY = c.USER_NO " +
                           "left join WMS_PROD d on a.PROD_NO = d.PROD_NO " +
                           "left join WMS_ORG e on a.ORG_NO = e.ORG_NO " +
                           "where 1 = 1 {0} " +
                           "order by a.PALLET_NO, a.LIST_NO, a.LINE_ID ";

        /// <summary>
        /// 產生棧板號
        /// </summary>
        /// <param name="IOType"></param>
        /// <returns></returns>
        public string GenPalletNo()
        {
            string Header = string.Empty;
            string Body = string.Empty;
            int SerNo = 0;
            Random rdm = new Random();
            Header = "BCR";
            Body = DateTime.Now.ToString("yyyyMMddHHmmss");
            SerNo = rdm.Next(9999);

            return string.Format("{0}{1}{2:0000}", Header, Body, SerNo);
        }

        /// <summary>
        /// 取得所有出庫單(單身)
        /// </summary>
        /// <param name="SDate">起始日期</param>
        /// <param name="EDate">結束日期</param>
        /// <param name="_StatusCtr">單據狀態</param>
        /// <param name="Data">返回的資料集</param>
        /// <returns></returns>
        public vPublic.DBExecResult GetAllCusBarcodeInfo(vPublic.BarcodeInStatus? _Status, ref List<Model.CusBarcodeInfo> Data)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true };
            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>();
            string strSqlWhere = string.Empty;

            parameters.Add(new vPublic.DBParameter() { ParameterName = "STATUS0", Value = RMPublic.GetString("BcrStatus0") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "STATUS1", Value = RMPublic.GetString("BcrStatus1") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "STATUS2", Value = RMPublic.GetString("BcrStatus2") });

            if (_Status.HasValue)
            {
                strSqlWhere += " and a.STATUS = @STATUS ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "STATUS", Value = Convert.ToInt16(_Status.Value) });
            }

            result = vPublic.GetDbData(string.Format(QuerySql, strSqlWhere), parameters);
            if (result.Successed)
                Data = GetListData(result.ResultDt);

            return result;
        }

        /// <summary>
        /// 取OutListData
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<Model.CusBarcodeInfo> GetListData(DataTable dt)
        {
            List<Model.CusBarcodeInfo> cusBarcodeInfos = new List<Model.CusBarcodeInfo>();

            cusBarcodeInfos = dt.AsEnumerable().Select(o => new Model.CusBarcodeInfo()
            {
                LIST_NO = o.Field<string>("LIST_NO"),
                LINE_ID = Convert.ToInt16(o.Field<decimal>("LINE_ID")),
                PALLET_NO = o.Field<string>("PALLET_NO"),
                STATUS = (vPublic.BarcodeInStatus)Enum.ToObject(typeof(vPublic.BarcodeInStatus), Convert.ToInt16(o.Field<decimal>("STATUS"))),
                STATUS_DESC = o.Field<string>("STATUS_DESC"),
                PROD_NO = o.Field<string>("PROD_NO"),
                PROD_NAME = o.Field<string>("PROD_NAME"),
                ORG_NO = o.Field<string>("ORG_NO"),
                ORG_SNAME = o.Field<string>("ORG_SNAME"),
                QTY = o.Field<decimal>("QTY"),
                LOT_NO = o.Field<string>("LOT_NO"),
                UN = o.Field<string>("UN"),
                PRODUCTION_DATE = o.Field<DateTime?>("PRODUCTION_DATE"),
                CHECK_DATE = o.Field<DateTime?>("CHECK_DATE"),
                STOREIN_DATE = o.Field<DateTime?>("STOREIN_DATE"),
                REMARK = o.Field<string>("REMARK"),
                CREATE_BY = o.Field<string>("CREATE_BY"),
                CREATE_NAME = o.Field<string>("CREATE_NAME"),
                CREATE_DATE = o.Field<DateTime?>("CREATE_DATE"),
                UPDATE_BY = o.Field<string>("UPDATE_BY"),
                UPDATE_NAME = o.Field<string>("UPDATE_NAME"),
                UPDATE_DATE = o.Field<DateTime?>("UPDATE_DATE")
            }).ToList();

            return cusBarcodeInfos;
        }

        /// <summary>
        /// 新增組盤資料
        /// </summary>
        /// <param name="Lists"></param>
        /// <returns></returns>
        public vPublic.DBExecResult CreateCusBarcodeInfo(List<Model.CusBarcodeInfo> Lists)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = RMPublic.GetString("SubmitOK") };
            Service.WmsListService ListService = new WmsListService();

            #region 防呆
            foreach (var Item in Lists)
            {
                List<Model.WmsInLine> Inlines = new List<WMS.Model.WmsInLine>();
                result = ListService.GetWmsInLineByListNoAndID(Item.LIST_NO, Item.LINE_ID, ref Inlines);
                if (result.Successed == false) return result;

                if (Inlines.Count <= 0)
                {
                    //單號:{0}, 項次:{1}, 查無入庫單據資料, 請重新查詢確認	
                    return new vPublic.DBExecResult() { Successed = false, Message = string.Format(RMPublic.GetString("PalletInMsg001"), Item.LIST_NO, Item.LINE_ID) };
                }

                var IsAvailable = Inlines.Any(o => o.STATUS_CTR == vPublic.StatusCtr.接單 || o.STATUS_CTR == vPublic.StatusCtr.收料中);
                if (!IsAvailable)
                {
                    //單號:{0}, 項次:{1}, 單據狀態非接單或收料中, 無法執行組盤作業
                    return new vPublic.DBExecResult() { Successed = false, Message = string.Format(RMPublic.GetString("PalletInMsg002"), Item.LIST_NO, Item.LINE_ID) };
                }

                IsAvailable = Inlines.Any(o => o.QTY - (o.WMS_QTY + o.TMP_QTY) > 0);
                if (!IsAvailable)
                {
                    //單號:{0}, 項次:{1}, 單據狀態非接單或收料中, 無法執行組盤作業
                    return new vPublic.DBExecResult() { Successed = false, Message = string.Format(RMPublic.GetString("PalletInMsg002"), Item.LIST_NO, Item.LINE_ID) };
                }

                IsAvailable = Inlines.Any(o => o.AVAILABLE_QTY > Item.QTY);
                if (!IsAvailable)
                {
                    //單號:{0}, 項次:{1}, 單據可組盤量不足, 無法執行組盤作業
                    return new vPublic.DBExecResult() { Successed = false, Message = string.Format(RMPublic.GetString("PalletInMsg003"), Item.LIST_NO, Item.LINE_ID) };
                }
            }
            #endregion

            return SubmitCreateCusBarcodeInfo(Lists);
        }

        /// <summary>
        /// 新增組盤資料到資料庫
        /// </summary>
        /// <returns></returns>
        private vPublic.DBExecResult SubmitCreateCusBarcodeInfo(List<Model.CusBarcodeInfo> Lists)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = RMPublic.GetString("SubmitOK") };

            SqlConnection Conn = new SqlConnection(vPublic.ConnStr);
            try
            {
                Conn.Open();
            }
            catch (SqlException ex)
            {
                return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
            }

            using (SqlTransaction trans = Conn.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var Cmd = Conn.CreateCommand();
                    Cmd.Transaction = trans;
                    int rtn = 0;
                    string strSql = string.Empty;

                    foreach (var Item in Lists)
                    {
                        strSql = "insert into CUS_BARCODE_INFO ( LIST_NO, LINE_ID, PALLET_NO, PROD_NO, ORG_NO, LOT_NO, QTY, " + "\r\n" +
                                 "                               UN, STOREIN_DATE, PRODUCTION_DATE, CHECK_DATE, REMARK, STATUS, " + "\r\n" +
                                 "                               CREATE_DATE, CREATE_BY, UPDATE_DATE, UPDATE_BY ) " + "\r\n" +
                                 "                       values(@LIST_NO,@LINE_ID,@PALLET_NO,@PROD_NO,@ORG_NO,@LOT_NO,@QTY, " + "\r\n" +
                                 "                              @UN,@STOREIN_DATE,@PRODUCTION_DATE,@CHECK_DATE,@REMARK,@STATUS, " + "\r\n" +
                                 "                              @CREATE_DATE,@CREATE_BY,@UPDATE_DATE,@UPDATE_BY) ";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LINE_ID", (object)Item.LINE_ID ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PALLET_NO", (object)Item.PALLET_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_NO", (object)Item.PROD_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ORG_NO", (object)Item.ORG_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LOT_NO", (object)Item.LOT_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("QTY", (object)Item.QTY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UN", (object)Item.UN ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STOREIN_DATE", (object)Item.STOREIN_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PRODUCTION_DATE", (object)Item.PRODUCTION_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CHECK_DATE", (object)Item.CHECK_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("REMARK", (object)Item.REMARK ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STATUS", Convert.ToInt16(Item.STATUS));
                        Cmd.Parameters.AddWithValue("CREATE_DATE", (object)Item.CREATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_BY", (object)Item.CREATE_BY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_DATE", (object)Item.UPDATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_BY", (object)Item.UPDATE_BY ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();

                        //更新單據數量
                        strSql = "update WMS_IN_LINE set TMP_QTY = TMP_QTY + @QTY, STATUS_CTR = @STATUS_CTR8 where LIST_NO = @LIST_NO and LINE_ID = @LINE_ID ";
                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("QTY", (object)Item.QTY ?? 0);
                        Cmd.Parameters.AddWithValue("STATUS_CTR8", Convert.ToInt16(vPublic.StatusCtr.收料中));
                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LINE_ID", (object)Item.LINE_ID ?? DBNull.Value);

                        rtn = Cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    result.Successed = false;
                    result.Message = ex.Message;
                    //return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
                }
                finally
                {
                    if (Conn.State == ConnectionState.Open)
                        Conn.Close();
                    Conn.Dispose();
                }
            }
            return result;
        }

        /// <summary>
        /// 刪除組盤資料
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult DeleteCusBarcodeInfo(List<Model.CusBarcodeInfo> Lists)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = RMPublic.GetString("DeleteOK") };

            SqlConnection Conn = new SqlConnection(vPublic.ConnStr);
            try
            {
                Conn.Open();
            }
            catch (SqlException ex)
            {
                return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
            }

            using (SqlTransaction trans = Conn.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var Cmd = Conn.CreateCommand();
                    Cmd.Transaction = trans;
                    int rtn = 0;
                    string strSql = string.Empty;

                    foreach (var Item in Lists)
                    {
                        strSql = "insert into CUS_BARCODE_INFO_LOG ( LIST_NO, LINE_ID, PALLET_NO, PROD_NO, ORG_NO, LOT_NO, QTY, " + "\r\n" +
                                 "                               UN, STOREIN_DATE, PRODUCTION_DATE, CHECK_DATE, REMARK, STATUS, " + "\r\n" +
                                 "                               CREATE_DATE, CREATE_BY, UPDATE_DATE, UPDATE_BY, LOG_TIME ) " + "\r\n" +
                                 "                       values(@LIST_NO,@LINE_ID,@PALLET_NO,@PROD_NO,@ORG_NO,@LOT_NO,@QTY, " + "\r\n" +
                                 "                              @UN,@STOREIN_DATE,@PRODUCTION_DATE,@CHECK_DATE,@REMARK,@STATUS, " + "\r\n" +
                                 "                              @CREATE_DATE,@CREATE_BY,@UPDATE_DATE,@UPDATE_BY,@LOG_TIME) ";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LINE_ID", (object)Item.LINE_ID ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PALLET_NO", (object)Item.PALLET_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_NO", (object)Item.PROD_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ORG_NO", (object)Item.ORG_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LOT_NO", (object)Item.LOT_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("QTY", (object)Item.QTY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UN", (object)Item.UN ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STOREIN_DATE", (object)Item.STOREIN_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PRODUCTION_DATE", (object)Item.PRODUCTION_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CHECK_DATE", (object)Item.CHECK_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("REMARK", (object)Item.REMARK ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STATUS", Convert.ToInt16(Item.STATUS));
                        Cmd.Parameters.AddWithValue("CREATE_DATE", (object)Item.CREATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_BY", (object)Item.CREATE_BY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_DATE", (object)Item.UPDATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_BY", (object)Item.UPDATE_BY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LOG_TIME", DateTime.Now);
                        rtn = Cmd.ExecuteNonQuery();

                        if (Item.STATUS == vPublic.BarcodeInStatus.未啟動)
                        {
                            //更新單據數量
                            strSql = "update WMS_IN_LINE set TMP_QTY = TMP_QTY - @QTY, "+
                                     "                       STATUS_CTR = case when TMP_QTY + WMS_QTY = 0 then @STATUS_CTR0 " +
                                     "                                    else @STATUS_CTR8 end "+
                                     "where LIST_NO = @LIST_NO and LINE_ID = @LINE_ID ";
                            Cmd.CommandText = strSql;
                            Cmd.Parameters.Clear();

                            Cmd.Parameters.AddWithValue("QTY", (object)Item.QTY ?? 0);
                            Cmd.Parameters.AddWithValue("STATUS_CTR0", Convert.ToInt16(vPublic.StatusCtr.接單));
                            Cmd.Parameters.AddWithValue("STATUS_CTR8", Convert.ToInt16(vPublic.StatusCtr.收料中));
                            Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("LINE_ID", (object)Item.LINE_ID ?? DBNull.Value);

                            rtn = Cmd.ExecuteNonQuery();
                        }

                        strSql = "delete from CUS_BARCODE_INFO where PALLET_NO = @PALLET_NO and LIST_NO = @LIST_NO and LINE_ID =@LINE_ID ";
                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("PALLET_NO", (object)Item.PALLET_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LINE_ID", (object)Item.LINE_ID ?? DBNull.Value);

                        rtn = Cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    result.Successed = false;
                    result.Message = ex.Message;
                }
                finally
                {
                    if (Conn.State == ConnectionState.Open)
                        Conn.Close();
                    Conn.Dispose();
                }
            }
            return result;
        }
    }
}
