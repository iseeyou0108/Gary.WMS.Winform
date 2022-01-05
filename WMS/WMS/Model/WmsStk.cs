using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;

using System.Data.SqlClient;

namespace WMS.Model
{
    public class WmsStk
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}Resource_WMS_STK", ""), System.Reflection.Assembly.GetExecutingAssembly());

        /// <summary>
        /// Stk modify log type
        /// </summary>
        public enum ModifyLogType
        {
            新增 = 0,
            修改前 = 1,
            修改後 = 2,
            刪除 = 3,
            沒變更 = 4
        }

        /// <summary>
        /// 庫存狀態
        /// </summary>
        public enum StusCtr
        {
            可用庫存 = 0,
            待驗庫存 = 4,
            盤點待回庫 = 3,
            撿料待回庫 = 2,
            入庫預約 = 100,
            出庫預約 = 101
        }

        /// <summary>
        /// 物料類型
        /// </summary>
        public enum ProdType
        {
            成品_原物料 = 0,
            載具 = 1,
            先入品 = 2
        }

        /// <summary>
        /// 值檢結果
        /// </summary>
        public enum QCResult
        {
            [Description("未檢..")]
            未檢 = 0,
            [Description("合格..")]
            合格 = 1,
            [Description("不合格..")]
            不合格 = 2,
            [Description("良品..")]
            良品 = 3,
            [Description("劣品..")]
            劣品 = 4,
            [Description("待退..")]
            待退 = 5
        }

        public string FIFO_NO { get; set; }
        public string AREA_NO { get; set; }
        public string WH_NO { get; set; }
        public decimal ASRS_ID { get; set; }
        public decimal STUS_CTR { get; set; }
        public string STUS_CTR_DESC { get; set; }
        public string BIN_NO { get; set; }
        public string SD { get; set; }
        public string SRC_BIN_NO { get; set; }
        public ProdType PROD_TYPE { get; set; }
        public string PROD_TYPE_DESC { get; set; }
        public string PROD_NO { get; set; }
        public string PROD_NAME { get; set; }
        public string ORG_NO { get; set; }
        public string ORG_SNAME { get; set; }
        public string UN { get; set; }
        public string LOT_NO { get; set; }
        public decimal QTY { get; set; }
        public decimal RES_QTY { get; set; }
        public string LIST_NO { get; set; }
        public int LINE_ID { get; set; }
        public DateTime? STOREIN_DATE { get; set; }
        public DateTime? PRODUCTION_DATE { get; set; }
        public string PDATE { get; set; }
        public string SDATE { get; set; }
        public string REMARK { get; set; }
        public string CREATE_BY { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
        public int CRN_ID { get; set; }
        public bool CHK { get; set; }
        public QCResult QC_RESULT { get; set; }
        public string QC_RESULT_DESC { get; set; }
        public ModifyLogType ModifyType { get; set; }

        private string QueryStkSql = @"select a.*
                                              , isnull(convert(varchar,PRODUCTION_DATE,111),'') PDATE
                                              , isnull(convert(varchar,STOREIN_DATE,111),'') SDATE
                                              , b.STUS_CTR_DESC
                                              , c.SNAME as ORG_SNAME 
                                              ,case when a.PROD_TYPE = 0 then @PROD_TYPE_0
                                                   when a.PROD_TYPE = 1 then @PROD_TYPE_1
                                                   when a.PROD_TYPE = 2 then @PROD_TYPE_2
                                                   else Convert(varchar,a.PROD_TYPE) end PROD_TYPE_DESC
                                              ,case when a.QC_RESULT = 0 then @QC0
                                                   when a.QC_RESULT = 1 then @QC1
                                                   when a.QC_RESULT = 2 then @QC2
                                                   when a.QC_RESULT = 3 then @QC3
                                                   when a.QC_RESULT = 4 then @QC4
                                                   when a.QC_RESULT = 5 then @QC5
                                                   else Convert(varchar,a.QC_RESULT) end QC_RESULT_DESC, 
                                                   isnull(d.CRN_ID,0) CRN_ID, d.SD
                                       from WMS_STK a  
                                            left join WMS_STK_STUS_REF_VW b on a.STUS_CTR = b.STUS_CTR and b.LANG_ID = @LANG_ID 
                                            left join WMS_ORG c on a.ORG_NO = c.ORG_NO 
                                            left join WMS_BINSTA d on a.AREA_NO = d.AREA_NO and a.WH_NO = d.WH_NO and a.ASRS_ID = d.ASRS_ID and a.BIN_NO = d.BIN_NO
                                            where 1 = 1 {0}
                                       order by a.AREA_NO, a.WH_NO, a.ASRS_ID, a.BIN_NO ";

        private string QuerySummaryStkSql = @"select a.AREA_NO, a.WH_NO, a.ASRS_ID, sum(QTY) as QTY,
                                                     a.PROD_NO, a.PROD_NAME, a.LOT_NO, a.ORG_NO,
                                                     a.UN, a.STUS_CTR, a.PROD_TYPE, a.QC_RESULT
                                              , c.SNAME as ORG_SNAME 
                                              , isnull(convert(varchar,PRODUCTION_DATE,111),'') PDATE
                                              , b.STUS_CTR_DESC,
                                              case when a.PROD_TYPE = 0 then @PROD_TYPE_0
                                                   when a.PROD_TYPE = 1 then @PROD_TYPE_1
                                                   when a.PROD_TYPE = 2 then @PROD_TYPE_2
                                                   else Convert(varchar,a.PROD_TYPE) end PROD_TYPE_DESC 
                                              ,case when a.QC_RESULT = 0 then @QC0
                                                   when a.QC_RESULT = 1 then @QC1
                                                   when a.QC_RESULT = 2 then @QC2
                                                   when a.QC_RESULT = 3 then @QC3
                                                   when a.QC_RESULT = 4 then @QC4
                                                   when a.QC_RESULT = 5 then @QC5
                                                   else Convert(varchar,a.QC_RESULT) end QC_RESULT_DESC
                                       from WMS_STK a                                             
                                            left join WMS_STK_STUS_REF_VW b on a.STUS_CTR = b.STUS_CTR and b.LANG_ID = @LANG_ID 
                                            left join WMS_ORG c on a.ORG_NO = c.ORG_NO                                             
                                            where 1 = 1 {0}
                                       group by a.AREA_NO, a.WH_NO, a.ASRS_ID, a.PROD_NO, a.PROD_NAME, a.LOT_NO, a.ORG_NO,
                                                a.UN, a.STUS_CTR, a.PROD_TYPE, convert(varchar,PRODUCTION_DATE,111), b.STUS_CTR_DESC, c.SNAME, a.QC_RESULT
                                       order by a.AREA_NO, a.WH_NO, a.ASRS_ID ";

        public vPublic.DBExecResult GetAllWmsStk(int? ASRS_ID, ProdType _ProdType, ref List<WmsStk> Data)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true };
            
            result = GetAllWmsStk(ASRS_ID, ref Data);
            if (!result.Successed)
                return result;
            else
            {
                Data = Data.Where(o => o.PROD_TYPE == _ProdType).ToList();
                result.Data = Data;
                return result;
            }
        }

        /// <summary>
        /// 取得所有庫存
        /// </summary>
        /// <param name="ASRS_ID">倉庫代號</param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public vPublic.DBExecResult GetAllWmsStk(int? ASRS_ID, ref List<WmsStk> Data)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true };
            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>();
            string strSqlWhere = string.Empty;

            parameters.Add(new vPublic.DBParameter() { ParameterName = "LANG_ID", Value = Convert.ToInt16(Program.LangID) });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "PROD_TYPE_0", Value = RM.GetString("PROD_TYPE_0") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "PROD_TYPE_1", Value = RM.GetString("PROD_TYPE_1") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "PROD_TYPE_2", Value = RM.GetString("PROD_TYPE_2") });

            parameters.Add(new vPublic.DBParameter() { ParameterName = "QC0", Value = RM.GetString("QC0") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "QC1", Value = RM.GetString("QC1") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "QC2", Value = RM.GetString("QC2") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "QC3", Value = RM.GetString("QC3") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "QC4", Value = RM.GetString("QC4") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "QC5", Value = RM.GetString("QC5") });

            if (ASRS_ID.HasValue)
            {
                strSqlWhere += " and a.ASRS_ID = @ASRS_ID ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "ASRS_ID", Value = ASRS_ID.Value });
            }
            result = vPublic.GetDbData(string.Format(QueryStkSql, strSqlWhere), parameters);
            if (result.Successed)
                Data = GetDataList(result.ResultDt);

            return result;
        }

        /// <summary>
        /// 取得庫存彙總
        /// </summary>
        /// <param name="ASRS_ID">倉庫代號</param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public vPublic.DBExecResult GetSummaryWmsStk(int? ASRS_ID, ref List<WmsStk> Data)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true };
            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>();
            string strSqlWhere = string.Empty;

            parameters.Add(new vPublic.DBParameter() { ParameterName = "LANG_ID", Value = Convert.ToInt16(Program.LangID) });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "PROD_TYPE_0", Value = RM.GetString("PROD_TYPE_0") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "PROD_TYPE_1", Value = RM.GetString("PROD_TYPE_1") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "PROD_TYPE_2", Value = RM.GetString("PROD_TYPE_2") });

            parameters.Add(new vPublic.DBParameter() { ParameterName = "QC0", Value = RM.GetString("QC0") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "QC1", Value = RM.GetString("QC1") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "QC2", Value = RM.GetString("QC2") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "QC3", Value = RM.GetString("QC3") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "QC4", Value = RM.GetString("QC4") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "QC5", Value = RM.GetString("QC5") });

            if (ASRS_ID.HasValue)
            {
                strSqlWhere += " and a.ASRS_ID = @ASRS_ID ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "ASRS_ID", Value = ASRS_ID.Value });
            }
            result = vPublic.GetDbData(string.Format(QuerySummaryStkSql, strSqlWhere), parameters);
            if (result.Successed)
                Data = GetSummaryDataList(result.ResultDt);

            return result;
        }

        public List<WmsStk> GetSummaryDataList(DataTable dtStk)
        {
            List<WmsStk> Stks = new List<WmsStk>();

            Stks = dtStk.AsEnumerable().Select(o => new WmsStk()
            {
                AREA_NO = o.Field<string>("AREA_NO"),
                WH_NO = o.Field<string>("WH_NO"),
                ASRS_ID = o.Field<decimal>("ASRS_ID"),
                STUS_CTR = o.Field<decimal>("STUS_CTR"),
                STUS_CTR_DESC = o.Field<string>("STUS_CTR_DESC"),
                PROD_TYPE = (ProdType)Enum.ToObject(typeof(ProdType), Convert.ToInt16(o.Field<decimal>("PROD_TYPE"))),
                PROD_TYPE_DESC = o.Field<string>("PROD_TYPE_DESC"),
                QC_RESULT = (QCResult)Enum.ToObject(typeof(QCResult), Convert.ToInt16(o.Field<decimal>("QC_RESULT"))),
                QC_RESULT_DESC = o.Field<string>("QC_RESULT_DESC"),
                PROD_NO = o.Field<string>("PROD_NO"),
                PROD_NAME = o.Field<string>("PROD_NAME"),
                ORG_SNAME = o.Field<string>("ORG_SNAME"),
                UN = o.Field<string>("UN"),
                LOT_NO = o.Field<string>("LOT_NO"),
                QTY = o.Field<decimal>("QTY"),
                PDATE = o.Field<string>("PDATE"),
                ORG_NO = o.Field<string>("ORG_NO")
            }).ToList();

            return Stks;
        }

        public List<WmsStk> GetDataList(DataTable dtStk)
        {
            List<WmsStk> Stks = new List<WmsStk>();

            Stks = dtStk.AsEnumerable().Select(o => new WmsStk()
            {
                FIFO_NO = o.Field<string>("FIFO_NO"),
                AREA_NO = o.Field<string>("AREA_NO"),
                WH_NO = o.Field<string>("WH_NO"),
                ASRS_ID = o.Field<decimal>("ASRS_ID"),
                STUS_CTR = o.Field<decimal>("STUS_CTR"),
                STUS_CTR_DESC = o.Field<string>("STUS_CTR_DESC"),
                BIN_NO = o.Field<string>("BIN_NO"),
                SD = o.Field<string>("SD"),
                SRC_BIN_NO = o.Field<string>("SRC_BIN_NO"),
                PROD_TYPE = (ProdType)Enum.ToObject(typeof(ProdType), Convert.ToInt16(o.Field<decimal>("PROD_TYPE"))),
                PROD_TYPE_DESC = o.Field<string>("PROD_TYPE_DESC"),
                PROD_NO = o.Field<string>("PROD_NO"),
                PROD_NAME = o.Field<string>("PROD_NAME"),
                UN = o.Field<string>("UN"),
                LOT_NO = o.Field<string>("LOT_NO"),
                QTY = o.Field<decimal>("QTY"),
                RES_QTY = o.Field<decimal>("RES_QTY"),
                LIST_NO = o.Field<string>("LIST_NO"),
                ORG_SNAME = o.Field<string>("ORG_SNAME"),
                STOREIN_DATE = o.Field<DateTime?>("STOREIN_DATE"),
                PDATE = o.Field<string>("PDATE"),
                SDATE = o.Field<string>("SDATE"),
                ORG_NO = o.Field<string>("ORG_NO"),
                PRODUCTION_DATE = o.Field<DateTime?>("PRODUCTION_DATE"),
                REMARK = o.Field<string>("REMARK"),
                CRN_ID = Convert.ToInt16(o.Field<decimal>("CRN_ID")),
                CREATE_DATE = o.Field<DateTime?>("CREATE_DATE"),
                UPDATE_DATE = o.Field<DateTime?>("UPDATE_DATE"),
                CREATE_BY = o.Field<string>("CREATE_BY"),
                UPDATE_BY = o.Field<string>("UPDATE_BY"),
                QC_RESULT = (QCResult)Enum.ToObject(typeof(QCResult), Convert.ToInt16(o.Field<decimal>("QC_RESULT"))),
                QC_RESULT_DESC = o.Field<string>("QC_RESULT_DESC"),
                CHK = false
            }).ToList();

            return Stks;
        }

        internal static T DbNullValue<T>(object value)
        {
            if (value == null && value == DBNull.Value)
            {
                return default(T);
            }
            else if (value == null)
            {
                if (typeof(T).Name == "String")
                    return (T)Convert.ChangeType("", typeof(T));
            }
            return (T)Convert.ChangeType(value, typeof(T));
        }

        /// <summary>
        /// 產生工作檔序號
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult GenFifoNo()
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = "" };

            SqlConnection Conn = new SqlConnection(vPublic.ConnStr);
            try
            {
                Conn.Open();
            }
            catch (SqlException ex)
            {
                return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
            }

            try
            {
                var Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandTimeout = 600;
                Cmd.CommandText = "WMS_GEN_FIFO_NO_FC";
                SqlCommandBuilder.DeriveParameters(Cmd);
                Cmd.Parameters["@VALUE"].Value = "";
                Cmd.Parameters["@VALUE"].Direction = System.Data.ParameterDirection.InputOutput;

                Cmd.Parameters["@O_ERR_CODE"].Value = 0;
                Cmd.Parameters["@O_ERR_CODE"].Direction = System.Data.ParameterDirection.InputOutput;

                Cmd.Parameters["@O_ERR_DESC"].Value = "";
                Cmd.Parameters["@O_ERR_DESC"].Direction = System.Data.ParameterDirection.InputOutput;

                Cmd.ExecuteNonQuery();

                if (Cmd.Parameters["@O_ERR_CODE"].Value.ToString() != "0")
                    throw new Exception(Cmd.Parameters["@O_ERR_DESC"].Value.ToString());

                result.Data = Cmd.Parameters["@VALUE"].Value.ToString();

                Cmd.Dispose();
            }
            catch (SqlException ex)
            {
                result.Successed = false;
                result.Message = ex.Message;
                result.ErrorCode = ex.ErrorCode;
            }

            if (Conn.State == System.Data.ConnectionState.Open)
                Conn.Close();
            Conn.Dispose();

            return result;
        }

        /// <summary>
        /// 質檢結果輸入
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult QCResultInput(List<WmsStk> Lists, QCResult qcResult)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = RM.GetString("QCResultInputOK") };

            if (Lists == null)
            {
                //未選取任何待驗庫存, 請選取後重新作業
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0001") };
            }

            if (Lists.Count <= 0)
            {
                //未選取任何待驗庫存, 請選取後重新作業
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0001") };
            }

            WmsStk FirstItem = Lists.First();
            List<WmsStk> CurStks = new List<WmsStk>();
            result = GetAllWmsStk((int)FirstItem.ASRS_ID, ProdType.成品_原物料, ref CurStks);
            if (result.Successed == false)
                return result;

            //檢查有沒有不能驗的庫存
            var CheckItem = CurStks.Where(o => o.ASRS_ID == FirstItem.ASRS_ID &&
                o.WH_NO == FirstItem.WH_NO &&
                o.AREA_NO == FirstItem.AREA_NO &&
                o.PROD_TYPE == ProdType.成品_原物料 &&
                o.STUS_CTR != (decimal)StusCtr.待驗庫存 &&
                Lists.Any(x => x.FIFO_NO == o.FIFO_NO)
                );

            if (CheckItem != null)
            {
                if (CheckItem.Count() > 0)
                {
                    //倉庫:{0},庫位:{1},料號:{2}非待驗庫存, 無法執行質檢結果輸入, 請重新查詢確認 
                    return new vPublic.DBExecResult()
                    {
                        Successed = false,
                        Message = string.Format(RM.GetString("Msg0002"),
                                                CheckItem.First().ASRS_ID,
                                                CheckItem.First().BIN_NO,
                                                CheckItem.First().PROD_NO)
                    };
                }
            }

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
                        
                        strSql = "update WMS_STK set QC_RESULT = @QC_RESULT, STUS_CTR = @STUS_CTR where FIFO_NO = @FIFO_NO ";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("QC_RESULT", (int)qcResult);
                        Cmd.Parameters.AddWithValue("STUS_CTR", (int)StusCtr.可用庫存);
                        Cmd.Parameters.AddWithValue("FIFO_NO", (object)Item.FIFO_NO ?? DBNull.Value);
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

        /// <summary>
        /// 庫存刪除
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult Delete(List<WmsStk> Lists)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = RM.GetString("DeleteOK") };

            if (Lists == null)
            {
                //未選取任何庫存, 請選取後重新作業
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0003") };
            }

            if (Lists.Count <= 0)
            {
                //未選取任何庫存, 請選取後重新作業
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0003") };
            }

            WmsStk FirstItem = Lists.First();
            List<WmsStk> CurStks = new List<WmsStk>();
            result = GetAllWmsStk((int)FirstItem.ASRS_ID, ref CurStks);
            if (result.Successed == false)
                return result;

            //檢查有沒有不能驗的庫存
            var CheckItem = CurStks.Where(o => o.ASRS_ID == FirstItem.ASRS_ID &&
                o.WH_NO == FirstItem.WH_NO &&
                o.AREA_NO == FirstItem.AREA_NO &&
                (o.STUS_CTR != (decimal)StusCtr.待驗庫存 && o.STUS_CTR != (decimal)StusCtr.可用庫存) &&
                Lists.Any(x => x.FIFO_NO == o.FIFO_NO)
                );

            if (CheckItem != null)
            {
                if (CheckItem.Count() > 0)
                {
                    //倉庫:{0},庫位:{1},料號:{2}已被其他作業預約, 無法執行刪除庫存, 請重新查詢確認
                    return new vPublic.DBExecResult()
                    {
                        Successed = false,
                        Message = string.Format(RM.GetString("Msg0004"),
                                                CheckItem.First().ASRS_ID,
                                                CheckItem.First().BIN_NO,
                                                CheckItem.First().PROD_NO)
                    };
                }
            }

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

                        strSql = "delete WMS_STK where FIFO_NO = @FIFO_NO ";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();
                        Cmd.Parameters.AddWithValue("FIFO_NO", (object)Item.FIFO_NO ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();

                        strSql = @"INSERT INTO WMS_STK_MODIFY_LOG
                                   (LOG_TIME
                                   ,LOG_TYPE
                                   ,FIFO_NO
                                   ,AREA_NO
                                   ,WH_NO
                                   ,ASRS_ID
                                   ,STUS_CTR
                                   ,BIN_NO
                                   ,SRC_BIN_NO
                                   ,PROD_TYPE
                                   ,PROD_NO
                                   ,PROD_NAME
                                   ,UN
                                   ,LOT_NO
                                   ,QTY
                                   ,RES_QTY
                                   ,LIST_NO
                                   ,STOREIN_DATE
                                   ,PRODUCTION_DATE
                                   ,REMARK
                                   ,CREATE_DATE
                                   ,CREATE_BY
                                   ,UPDATE_DATE
                                   ,UPDATE_BY
                                   ,QC_RESULT
                                   ,ORG_NO)
                             VALUES
                                   (@LOG_TIME
                                   ,@LOG_TYPE
                                   ,@FIFO_NO
                                   ,@AREA_NO
                                   ,@WH_NO
                                   ,@ASRS_ID
                                   ,@STUS_CTR
                                   ,@BIN_NO
                                   ,@SRC_BIN_NO
                                   ,@PROD_TYPE
                                   ,@PROD_NO
                                   ,@PROD_NAME
                                   ,@UN
                                   ,@LOT_NO
                                   ,@QTY
                                   ,@RES_QTY
                                   ,@LIST_NO
                                   ,@STOREIN_DATE
                                   ,@PRODUCTION_DATE
                                   ,@REMARK
                                   ,@CREATE_DATE
                                   ,@CREATE_BY
                                   ,@UPDATE_DATE
                                   ,@UPDATE_BY
                                   ,@QC_RESULT
                                   ,@ORG_NO)";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();
                        Cmd.Parameters.AddWithValue("LOG_TIME", DateTime.Now);
                        Cmd.Parameters.AddWithValue("LOG_TYPE", ModifyLogType.刪除);
                        Cmd.Parameters.AddWithValue("FIFO_NO", (object)Item.FIFO_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("AREA_NO", (object)Item.AREA_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("WH_NO", (object)Item.WH_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ASRS_ID", (object)Item.ASRS_ID ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STUS_CTR", (object)Item.STUS_CTR ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("BIN_NO", (object)Item.BIN_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("SRC_BIN_NO", (object)Item.SRC_BIN_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_TYPE", (object)Item.PROD_TYPE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_NO", (object)Item.PROD_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_NAME", (object)Item.PROD_NAME ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UN", (object)Item.UN ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LOT_NO", (object)Item.LOT_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("QTY", (object)Item.QTY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("RES_QTY", (object)Item.RES_QTY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STOREIN_DATE", (object)Item.STOREIN_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PRODUCTION_DATE", (object)Item.PRODUCTION_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("REMARK", (object)Item.REMARK ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_DATE", (object)Item.CREATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_BY", (object)Item.CREATE_BY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_DATE", (object)Item.UPDATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_BY", (object)Item.UPDATE_BY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("QC_RESULT", (object)Item.QC_RESULT ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ORG_NO", (object)Item.ORG_NO ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();

                        int Itemindex = CurStks.FindIndex(p => p.FIFO_NO == Item.FIFO_NO);
                        CurStks.RemoveAt(Itemindex);

                        //庫位狀態更新
                        var CheckBinSta = CurStks.Any(o => o.AREA_NO == Item.AREA_NO && o.WH_NO == Item.WH_NO && o.ASRS_ID == Item.ASRS_ID && o.BIN_NO == Item.BIN_NO);
                        if (!CheckBinSta)
                        {
                            strSql = "update WMS_BINSTA set BIN_STA = '_' where 1 = 1 " +
                                                            " and AREA_NO = @AREA_NO " +
                                                            " and WH_NO = @WH_NO " +
                                                            " and ASRS_ID = @ASRS_ID " +
                                                            " and BIN_NO = @BIN_NO " +
                                                            "";

                            Cmd.CommandText = strSql;
                            Cmd.Parameters.Clear();
                            Cmd.Parameters.AddWithValue("AREA_NO", (object)Item.AREA_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("WH_NO", (object)Item.WH_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("ASRS_ID", (object)Item.ASRS_ID ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("BIN_NO", (object)Item.BIN_NO ?? DBNull.Value);
                            rtn = Cmd.ExecuteNonQuery();
                        }
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
            if (result.Successed)
                result.Message = RM.GetString("DeleteOK");
            return result;
        }

        /// <summary>
        /// 庫存新增
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult Add(List<WmsStk> Lists, WmsBinSta BinSta)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = RM.GetString("AddOK") };
            Service.WmsBinstaService serviceBinSta = new WMS.Service.WmsBinstaService();
            
            if (Lists == null)
            {
                //未選取任何庫存, 請選取後重新作業
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0003") };
            }

            if (Lists.Count <= 0)
            {
                //未選取任何庫存, 請選取後重新作業
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0003") };
            }

            var CurBinStaResult = serviceBinSta.GetBinDataByBinNo(BinSta.AREA_NO, BinSta.WH_NO, Convert.ToInt16(BinSta.ASRS_ID), BinSta.BIN_NO);
            if (CurBinStaResult.Successed == false)
                return result;

            var CurBinSta = ((List<WmsBinSta>)CurBinStaResult.Data).First();

            if (CurBinSta.BIN_STA != "_")
                return new vPublic.DBExecResult() { Successed = false, ErrorCode = -1, Message = string.Format(RM.GetString("Msg0005"), CurBinSta.BIN_NO) };   //庫位:{0} 非空庫位, 無法新增庫存資料

            var GroupProdType = Lists.GroupBy(o => o.PROD_TYPE);

            if(GroupProdType.Count()>1)
                return new vPublic.DBExecResult() { Successed = false, ErrorCode = -1, Message = string.Format(RM.GetString("Msg0006"), CurBinSta.BIN_NO) };   //輸入的庫存資料有不同物料類型, 不同物料類型貨物不能混放在同個庫位, 請重新輸入

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
                        var GenFifoNoResult = GenFifoNo();
                        if(GenFifoNoResult.Successed==false)
                            throw new Exception (GenFifoNoResult.Message);

                        Item.FIFO_NO = GenFifoNoResult.Data.ToString();

                        strSql = @"INSERT INTO WMS_STK
                                   (FIFO_NO
                                   ,AREA_NO
                                   ,WH_NO
                                   ,ASRS_ID
                                   ,STUS_CTR
                                   ,BIN_NO
                                   ,SRC_BIN_NO
                                   ,PROD_TYPE
                                   ,PROD_NO
                                   ,PROD_NAME
                                   ,UN
                                   ,LOT_NO
                                   ,QTY
                                   ,RES_QTY
                                   ,LIST_NO
                                   ,STOREIN_DATE
                                   ,PRODUCTION_DATE
                                   ,REMARK
                                   ,CREATE_DATE
                                   ,CREATE_BY
                                   ,UPDATE_DATE
                                   ,UPDATE_BY
                                   ,QC_RESULT
                                   ,ORG_NO)
                             VALUES
                                   (@FIFO_NO
                                   ,@AREA_NO
                                   ,@WH_NO
                                   ,@ASRS_ID
                                   ,@STUS_CTR
                                   ,@BIN_NO
                                   ,@SRC_BIN_NO
                                   ,@PROD_TYPE
                                   ,@PROD_NO
                                   ,@PROD_NAME
                                   ,@UN
                                   ,@LOT_NO
                                   ,@QTY
                                   ,@RES_QTY
                                   ,@LIST_NO
                                   ,@STOREIN_DATE
                                   ,@PRODUCTION_DATE
                                   ,@REMARK
                                   ,@CREATE_DATE
                                   ,@CREATE_BY
                                   ,@UPDATE_DATE
                                   ,@UPDATE_BY
                                   ,@QC_RESULT
                                   ,@ORG_NO)";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();
                        Cmd.Parameters.AddWithValue("FIFO_NO", GenFifoNoResult.Data.ToString());
                        Cmd.Parameters.AddWithValue("AREA_NO", (object)Item.AREA_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("WH_NO", (object)Item.WH_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ASRS_ID", (object)Item.ASRS_ID ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STUS_CTR", (object)Item.STUS_CTR ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("BIN_NO", (object)Item.BIN_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("SRC_BIN_NO", (object)Item.SRC_BIN_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_TYPE", (object)Item.PROD_TYPE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_NO", (object)Item.PROD_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_NAME", (object)Item.PROD_NAME ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UN", (object)Item.UN ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LOT_NO", (object)Item.LOT_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("QTY", (object)Item.QTY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("RES_QTY", (object)Item.RES_QTY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STOREIN_DATE", (object)Item.STOREIN_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PRODUCTION_DATE", (object)Item.PRODUCTION_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("REMARK", (object)Item.REMARK ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_DATE", (object)Item.CREATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_BY", (object)Item.CREATE_BY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_DATE", (object)Item.UPDATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_BY", (object)Item.UPDATE_BY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("QC_RESULT", (object)Item.QC_RESULT ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ORG_NO", (object)Item.ORG_NO ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();

                        strSql = @"INSERT INTO WMS_STK_MODIFY_LOG
                                   (LOG_TIME
                                   ,LOG_TYPE
                                   ,FIFO_NO
                                   ,AREA_NO
                                   ,WH_NO
                                   ,ASRS_ID
                                   ,STUS_CTR
                                   ,BIN_NO
                                   ,SRC_BIN_NO
                                   ,PROD_TYPE
                                   ,PROD_NO
                                   ,PROD_NAME
                                   ,UN
                                   ,LOT_NO
                                   ,QTY
                                   ,RES_QTY
                                   ,LIST_NO
                                   ,STOREIN_DATE
                                   ,PRODUCTION_DATE
                                   ,REMARK
                                   ,CREATE_DATE
                                   ,CREATE_BY
                                   ,UPDATE_DATE
                                   ,UPDATE_BY
                                   ,QC_RESULT
                                   ,ORG_NO)
                             VALUES
                                   (@LOG_TIME
                                   ,@LOG_TYPE
                                   ,@FIFO_NO
                                   ,@AREA_NO
                                   ,@WH_NO
                                   ,@ASRS_ID
                                   ,@STUS_CTR
                                   ,@BIN_NO
                                   ,@SRC_BIN_NO
                                   ,@PROD_TYPE
                                   ,@PROD_NO
                                   ,@PROD_NAME
                                   ,@UN
                                   ,@LOT_NO
                                   ,@QTY
                                   ,@RES_QTY
                                   ,@LIST_NO
                                   ,@STOREIN_DATE
                                   ,@PRODUCTION_DATE
                                   ,@REMARK
                                   ,@CREATE_DATE
                                   ,@CREATE_BY
                                   ,@UPDATE_DATE
                                   ,@UPDATE_BY
                                   ,@QC_RESULT
                                   ,@ORG_NO)";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();
                        Cmd.Parameters.AddWithValue("LOG_TIME", DateTime.Now);
                        Cmd.Parameters.AddWithValue("LOG_TYPE", ModifyLogType.新增);
                        Cmd.Parameters.AddWithValue("FIFO_NO", (object)Item.FIFO_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("AREA_NO", (object)Item.AREA_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("WH_NO", (object)Item.WH_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ASRS_ID", (object)Item.ASRS_ID ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STUS_CTR", (object)Item.STUS_CTR ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("BIN_NO", (object)Item.BIN_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("SRC_BIN_NO", (object)Item.SRC_BIN_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_TYPE", (object)Item.PROD_TYPE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_NO", (object)Item.PROD_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_NAME", (object)Item.PROD_NAME ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UN", (object)Item.UN ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LOT_NO", (object)Item.LOT_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("QTY", (object)Item.QTY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("RES_QTY", (object)Item.RES_QTY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STOREIN_DATE", (object)Item.STOREIN_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PRODUCTION_DATE", (object)Item.PRODUCTION_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("REMARK", (object)Item.REMARK ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_DATE", (object)Item.CREATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_BY", (object)Item.CREATE_BY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_DATE", (object)Item.UPDATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_BY", (object)Item.UPDATE_BY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("QC_RESULT", (object)Item.QC_RESULT ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ORG_NO", (object)Item.ORG_NO ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();
                    }

                    //庫位狀態更新
                    strSql = "update WMS_BINSTA set BIN_STA = '$' where 1 = 1 " +
                                                    " and AREA_NO = @AREA_NO " +
                                                    " and WH_NO = @WH_NO " +
                                                    " and ASRS_ID = @ASRS_ID " +
                                                    " and BIN_NO = @BIN_NO " +
                                                    "";

                    Cmd.CommandText = strSql;
                    Cmd.Parameters.Clear();
                    Cmd.Parameters.AddWithValue("AREA_NO", (object)BinSta.AREA_NO ?? DBNull.Value);
                    Cmd.Parameters.AddWithValue("WH_NO", (object)BinSta.WH_NO ?? DBNull.Value);
                    Cmd.Parameters.AddWithValue("ASRS_ID", (object)BinSta.ASRS_ID ?? DBNull.Value);
                    Cmd.Parameters.AddWithValue("BIN_NO", (object)BinSta.BIN_NO ?? DBNull.Value);
                    rtn = Cmd.ExecuteNonQuery();

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
            if (result.Successed)
                result.Message = RM.GetString("AddOK");
            return result;
        }

        /// <summary>
        /// 庫存修改
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult Edit(List<WmsStk> Lists, WmsBinSta BinSta)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = RM.GetString("EditOK") };
            Service.WmsBinstaService serviceBinSta = new WMS.Service.WmsBinstaService();

            if (Lists == null)
            {
                //未選取任何庫存, 請選取後重新作業
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0003") };
            }

            if (Lists.Count <= 0)
            {
                //未選取任何庫存, 請選取後重新作業
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0003") };
            }

            var CurBinStaResult = serviceBinSta.GetBinDataByBinNo(BinSta.AREA_NO, BinSta.WH_NO, Convert.ToInt16(BinSta.ASRS_ID), BinSta.BIN_NO);
            if (CurBinStaResult.Successed == false)
                return result;

            var CurBinSta = ((List<WmsBinSta>)CurBinStaResult.Data).First();

            if (CurBinSta.BIN_STA != "$")
                return new vPublic.DBExecResult() { Successed = false, ErrorCode = -1, Message = string.Format(RM.GetString("Msg0007"), CurBinSta.BIN_NO) };   //庫位:{0} 非庫存庫位, 無法修改庫存資料

            var GroupProdType = Lists.GroupBy(o => o.PROD_TYPE);

            if (GroupProdType.Count() > 1)
                return new vPublic.DBExecResult() { Successed = false, ErrorCode = -1, Message = string.Format(RM.GetString("Msg0006"), CurBinSta.BIN_NO) };   //輸入的庫存資料有不同物料類型, 不同物料類型貨物不能混放在同個庫位, 請重新輸入


            List<WmsStk> CurStks = new List<WmsStk>();
            result = GetAllWmsStk((int)BinSta.ASRS_ID, ref CurStks);
            if (result.Successed == false)
                return result;

            //檢查有沒有不能驗的庫存
            var CheckItem = CurStks.Where(o => o.ASRS_ID == BinSta.ASRS_ID &&
                o.WH_NO == BinSta.WH_NO &&
                o.AREA_NO == BinSta.AREA_NO &&
                (o.STUS_CTR != (decimal)StusCtr.待驗庫存 && o.STUS_CTR != (decimal)StusCtr.可用庫存) &&
                Lists.Any(x => x.FIFO_NO == o.FIFO_NO)
                );

            if (CheckItem != null)
            {
                if (CheckItem.Count() > 0)
                {
                    //倉庫:{0},庫位:{1},料號:{2}已被其他作業預約, 無法執行刪除庫存, 請重新查詢確認
                    return new vPublic.DBExecResult()
                    {
                        Successed = false,
                        Message = string.Format(RM.GetString("Msg0004"),
                                                CheckItem.First().ASRS_ID,
                                                CheckItem.First().BIN_NO,
                                                CheckItem.First().PROD_NO)
                    };
                }
            }

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

                    #region 寫修改前記錄
                    var BinStks = CurStks.Where(o => o.AREA_NO == BinSta.AREA_NO && o.WH_NO == BinSta.WH_NO && o.ASRS_ID == BinSta.ASRS_ID && o.BIN_NO == BinSta.BIN_NO).ToList();

                    foreach (var Item in BinStks)
                    {
                        strSql = @"INSERT INTO WMS_STK_MODIFY_LOG
                                   (LOG_TIME
                                   ,LOG_TYPE
                                   ,FIFO_NO
                                   ,AREA_NO
                                   ,WH_NO
                                   ,ASRS_ID
                                   ,STUS_CTR
                                   ,BIN_NO
                                   ,SRC_BIN_NO
                                   ,PROD_TYPE
                                   ,PROD_NO
                                   ,PROD_NAME
                                   ,UN
                                   ,LOT_NO
                                   ,QTY
                                   ,RES_QTY
                                   ,LIST_NO
                                   ,STOREIN_DATE
                                   ,PRODUCTION_DATE
                                   ,REMARK
                                   ,CREATE_DATE
                                   ,CREATE_BY
                                   ,UPDATE_DATE
                                   ,UPDATE_BY
                                   ,QC_RESULT
                                   ,ORG_NO)
                             VALUES
                                   (@LOG_TIME
                                   ,@LOG_TYPE
                                   ,@FIFO_NO
                                   ,@AREA_NO
                                   ,@WH_NO
                                   ,@ASRS_ID
                                   ,@STUS_CTR
                                   ,@BIN_NO
                                   ,@SRC_BIN_NO
                                   ,@PROD_TYPE
                                   ,@PROD_NO
                                   ,@PROD_NAME
                                   ,@UN
                                   ,@LOT_NO
                                   ,@QTY
                                   ,@RES_QTY
                                   ,@LIST_NO
                                   ,@STOREIN_DATE
                                   ,@PRODUCTION_DATE
                                   ,@REMARK
                                   ,@CREATE_DATE
                                   ,@CREATE_BY
                                   ,@UPDATE_DATE
                                   ,@UPDATE_BY
                                   ,@QC_RESULT
                                   ,@ORG_NO)";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();
                        Cmd.Parameters.AddWithValue("LOG_TIME", DateTime.Now);
                        Cmd.Parameters.AddWithValue("LOG_TYPE", ModifyLogType.修改前);
                        Cmd.Parameters.AddWithValue("FIFO_NO", (object)Item.FIFO_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("AREA_NO", (object)Item.AREA_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("WH_NO", (object)Item.WH_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ASRS_ID", (object)Item.ASRS_ID ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STUS_CTR", (object)Item.STUS_CTR ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("BIN_NO", (object)Item.BIN_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("SRC_BIN_NO", (object)Item.SRC_BIN_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_TYPE", (object)Item.PROD_TYPE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_NO", (object)Item.PROD_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_NAME", (object)Item.PROD_NAME ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UN", (object)Item.UN ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LOT_NO", (object)Item.LOT_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("QTY", (object)Item.QTY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("RES_QTY", (object)Item.RES_QTY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STOREIN_DATE", (object)Item.STOREIN_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PRODUCTION_DATE", (object)Item.PRODUCTION_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("REMARK", (object)Item.REMARK ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_DATE", (object)Item.CREATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_BY", (object)Item.CREATE_BY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_DATE", (object)Item.UPDATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_BY", (object)Item.UPDATE_BY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("QC_RESULT", (object)Item.QC_RESULT ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ORG_NO", (object)Item.ORG_NO ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();

                        //刪除庫存
                        strSql = "delete WMS_STK where FIFO_NO = @FIFO_NO ";
                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();
                        Cmd.Parameters.AddWithValue("FIFO_NO", (object)Item.FIFO_NO ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();
                    }

                    #endregion

                    foreach (var Item in Lists)
                    {
                        var GenFifoNoResult = GenFifoNo();
                        if (GenFifoNoResult.Successed == false)
                            throw new Exception(GenFifoNoResult.Message);

                        if (string.IsNullOrEmpty(Item.FIFO_NO))
                            Item.FIFO_NO = GenFifoNoResult.Data.ToString();

                        strSql = @"INSERT INTO WMS_STK
                                   (FIFO_NO
                                   ,AREA_NO
                                   ,WH_NO
                                   ,ASRS_ID
                                   ,STUS_CTR
                                   ,BIN_NO
                                   ,SRC_BIN_NO
                                   ,PROD_TYPE
                                   ,PROD_NO
                                   ,PROD_NAME
                                   ,UN
                                   ,LOT_NO
                                   ,QTY
                                   ,RES_QTY
                                   ,LIST_NO
                                   ,STOREIN_DATE
                                   ,PRODUCTION_DATE
                                   ,REMARK
                                   ,CREATE_DATE
                                   ,CREATE_BY
                                   ,UPDATE_DATE
                                   ,UPDATE_BY
                                   ,QC_RESULT
                                   ,ORG_NO)
                             VALUES
                                   (@FIFO_NO
                                   ,@AREA_NO
                                   ,@WH_NO
                                   ,@ASRS_ID
                                   ,@STUS_CTR
                                   ,@BIN_NO
                                   ,@SRC_BIN_NO
                                   ,@PROD_TYPE
                                   ,@PROD_NO
                                   ,@PROD_NAME
                                   ,@UN
                                   ,@LOT_NO
                                   ,@QTY
                                   ,@RES_QTY
                                   ,@LIST_NO
                                   ,@STOREIN_DATE
                                   ,@PRODUCTION_DATE
                                   ,@REMARK
                                   ,@CREATE_DATE
                                   ,@CREATE_BY
                                   ,@UPDATE_DATE
                                   ,@UPDATE_BY
                                   ,@QC_RESULT
                                   ,@ORG_NO)";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();
                        Cmd.Parameters.AddWithValue("FIFO_NO", (object)Item.FIFO_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("AREA_NO", (object)Item.AREA_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("WH_NO", (object)Item.WH_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ASRS_ID", (object)Item.ASRS_ID ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STUS_CTR", (object)Item.STUS_CTR ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("BIN_NO", (object)Item.BIN_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("SRC_BIN_NO", (object)Item.SRC_BIN_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_TYPE", (object)Item.PROD_TYPE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_NO", (object)Item.PROD_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_NAME", (object)Item.PROD_NAME ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UN", (object)Item.UN ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LOT_NO", (object)Item.LOT_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("QTY", (object)Item.QTY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("RES_QTY", (object)Item.RES_QTY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STOREIN_DATE", (object)Item.STOREIN_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PRODUCTION_DATE", (object)Item.PRODUCTION_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("REMARK", (object)Item.REMARK ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_DATE", (object)Item.CREATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_BY", (object)Item.CREATE_BY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_DATE", (object)Item.UPDATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_BY", (object)Item.UPDATE_BY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("QC_RESULT", (object)Item.QC_RESULT ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ORG_NO", (object)Item.ORG_NO ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();

                        strSql = @"INSERT INTO WMS_STK_MODIFY_LOG
                                   (LOG_TIME
                                   ,LOG_TYPE
                                   ,FIFO_NO
                                   ,AREA_NO
                                   ,WH_NO
                                   ,ASRS_ID
                                   ,STUS_CTR
                                   ,BIN_NO
                                   ,SRC_BIN_NO
                                   ,PROD_TYPE
                                   ,PROD_NO
                                   ,PROD_NAME
                                   ,UN
                                   ,LOT_NO
                                   ,QTY
                                   ,RES_QTY
                                   ,LIST_NO
                                   ,STOREIN_DATE
                                   ,PRODUCTION_DATE
                                   ,REMARK
                                   ,CREATE_DATE
                                   ,CREATE_BY
                                   ,UPDATE_DATE
                                   ,UPDATE_BY
                                   ,QC_RESULT
                                   ,ORG_NO)
                             VALUES
                                   (@LOG_TIME
                                   ,@LOG_TYPE
                                   ,@FIFO_NO
                                   ,@AREA_NO
                                   ,@WH_NO
                                   ,@ASRS_ID
                                   ,@STUS_CTR
                                   ,@BIN_NO
                                   ,@SRC_BIN_NO
                                   ,@PROD_TYPE
                                   ,@PROD_NO
                                   ,@PROD_NAME
                                   ,@UN
                                   ,@LOT_NO
                                   ,@QTY
                                   ,@RES_QTY
                                   ,@LIST_NO
                                   ,@STOREIN_DATE
                                   ,@PRODUCTION_DATE
                                   ,@REMARK
                                   ,@CREATE_DATE
                                   ,@CREATE_BY
                                   ,@UPDATE_DATE
                                   ,@UPDATE_BY
                                   ,@QC_RESULT
                                   ,@ORG_NO)";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();
                        Cmd.Parameters.AddWithValue("LOG_TIME", DateTime.Now);
                        Cmd.Parameters.AddWithValue("LOG_TYPE", ModifyLogType.修改後);
                        Cmd.Parameters.AddWithValue("FIFO_NO", (object)Item.FIFO_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("AREA_NO", (object)Item.AREA_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("WH_NO", (object)Item.WH_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ASRS_ID", (object)Item.ASRS_ID ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STUS_CTR", (object)Item.STUS_CTR ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("BIN_NO", (object)Item.BIN_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("SRC_BIN_NO", (object)Item.SRC_BIN_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_TYPE", (object)Item.PROD_TYPE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_NO", (object)Item.PROD_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_NAME", (object)Item.PROD_NAME ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UN", (object)Item.UN ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LOT_NO", (object)Item.LOT_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("QTY", (object)Item.QTY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("RES_QTY", (object)Item.RES_QTY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STOREIN_DATE", (object)Item.STOREIN_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PRODUCTION_DATE", (object)Item.PRODUCTION_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("REMARK", (object)Item.REMARK ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_DATE", (object)Item.CREATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_BY", (object)Item.CREATE_BY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_DATE", (object)Item.UPDATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_BY", (object)Item.UPDATE_BY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("QC_RESULT", (object)Item.QC_RESULT ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ORG_NO", (object)Item.ORG_NO ?? DBNull.Value);
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
            if (result.Successed)
                result.Message = RM.GetString("EditOK");
            return result;
        }
    }
}
