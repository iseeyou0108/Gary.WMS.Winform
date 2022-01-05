using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace WMS.Service
{
    public class WmsBinstaService
    {
        static System.Resources.ResourceManager RMPublic = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}Resource_Public", ""), System.Reflection.Assembly.GetExecutingAssembly());

        string QuerySql = "select a.* " +
                          "       ,isnull(b.BIN_STA_DESC, a.BIN_STA) as BIN_STA_DESC " +
                          "       ,isnull( (select top 1 PROD_TYPE from WMS_STK where AREA_NO = a.AREA_NO and WH_NO = a.WH_NO and ASRS_ID = a.ASRS_ID and BIN_NO = a.BIN_NO) , 0) PROD_TYPE "+
                          "from WMS_BINSTA a " +
                          "left join WMS_BIN_STA_REF_VW b on a.BIN_STA = b.BIN_STA and b.LANG_ID = @LANG_ID " +
                          "where 1 = 1 {0} " +
                          "order by a.AREA_NO, a.WH_NO, a.ASRS_ID, a.BIN_NO ";

        /// <summary>
        /// 取得所有庫位
        /// </summary>
        /// <param name="AREA_NO"></param>
        /// <param name="WH_NO"></param>
        /// <param name="ASRS_ID"></param>
        /// <param name="Data">返回的資料結果</param>
        /// <returns></returns>
        public vPublic.DBExecResult GetAllWmsBinstaList(string AREA_NO, string WH_NO, int? ASRS_ID, ref List<Model.WmsBinSta> Data)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true };
            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>();
            string strSqlWhere = string.Empty;
            

            parameters.Add(new vPublic.DBParameter() { ParameterName = "LANG_ID", Value = Convert.ToInt16(Program.LangID) });

            if (!string.IsNullOrEmpty(AREA_NO))
            {
                strSqlWhere += " and a.AREA_NO = @AREA_NO ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "AREA_NO", Value = AREA_NO });
            }
            if (!string.IsNullOrEmpty(WH_NO))
            {
                strSqlWhere += " and a.WH_NO = @WH_NO ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "WH_NO", Value = WH_NO });
            }
            if (ASRS_ID.HasValue)
            {
                strSqlWhere += " and a.ASRS_ID = @ASRS_ID ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "ASRS_ID", Value = ASRS_ID.Value });
            }

            result = vPublic.GetDbData(string.Format(QuerySql, strSqlWhere), parameters);
            if (result.Successed)
                Data = GetDataList(result.ResultDt);

            return result;
        }

        /// <summary>
        /// 取得所有庫位
        /// </summary>
        /// <param name="AREA_NO"></param>
        /// <param name="WH_NO"></param>
        /// <param name="ASRS_ID"></param>
        /// <param name="Data">返回的資料結果</param>
        /// <returns></returns>
        public vPublic.DBExecResult GetBinDataByBinNo(string AREA_NO, string WH_NO, int? ASRS_ID, string BIN_NO)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true };
            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>();
            string strSqlWhere = string.Empty;


            parameters.Add(new vPublic.DBParameter() { ParameterName = "LANG_ID", Value = Convert.ToInt16(Program.LangID) });

            if (!string.IsNullOrEmpty(AREA_NO))
            {
                strSqlWhere += " and a.AREA_NO = @AREA_NO ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "AREA_NO", Value = AREA_NO });
            }
            if (!string.IsNullOrEmpty(WH_NO))
            {
                strSqlWhere += " and a.WH_NO = @WH_NO ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "WH_NO", Value = WH_NO });
            }
            if (ASRS_ID.HasValue)
            {
                strSqlWhere += " and a.ASRS_ID = @ASRS_ID ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "ASRS_ID", Value = ASRS_ID.Value });
            }

            if (!string.IsNullOrEmpty(BIN_NO))
            {
                strSqlWhere += " and a.BIN_NO = @BIN_NO ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "BIN_NO", Value = BIN_NO });
            }

            result = vPublic.GetDbData(string.Format(QuerySql, strSqlWhere), parameters);
            if (result.Successed)
            {
                result.Data = GetDataList(result.ResultDt);
            }

            return result;
        }

        /// <summary>
        /// 取OutListData
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<Model.WmsBinSta> GetDataList(DataTable dt)
        {
            List<Model.WmsBinSta> BinstaLists = new List<Model.WmsBinSta>();

            BinstaLists = dt.AsEnumerable().Select(o => new Model.WmsBinSta()
            {
                AREA_NO = o.Field<string>("AREA_NO"),
                WH_NO = o.Field<string>("WH_NO"),
                ASRS_ID = o.Field<decimal>("ASRS_ID"),
                ROW_NO = o.Field<decimal>("ROW_NO"),
                BAY_NO = o.Field<decimal>("BAY_NO"),
                LEVEL_NO = o.Field<decimal>("LEVEL_NO"),
                CRN_ID = Convert.ToInt16(o.Field<decimal>("CRN_ID")),
                BIN_NO = o.Field<string>("BIN_NO"),
                SD = o.Field<string>("SD"),
                BIN_STA = o.Field<string>("BIN_STA"),
                BIN_STA_DESC = o.Field<string>("BIN_STA_DESC"),
                INHIBIT_IN_FLG = o.Field<string>("INHIBIT_IN_FLG"),
                INHIBIT_OUT_FLG = o.Field<string>("INHIBIT_OUT_FLG"),
                PROD_TYPE = (WMS.Model.WmsStk.ProdType)Enum.ToObject(typeof(WMS.Model.WmsStk.ProdType), (int)o.Field<decimal>("PROD_TYPE")),
                CHK = false
            }).ToList();

            return BinstaLists;
        }

        /// <summary>
        /// 提交庫位禁用/解禁用設定
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult SubmitDisableSettings(List<Fm_Q002.BinStaCell> Lists, bool Forbidden)
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
                        strSql = "update WMS_BINSTA set INHIBIT_IN_FLG = @INHIBIT_IN_FLG, INHIBIT_OUT_FLG = @INHIBIT_OUT_FLG "+
                                 "where AREA_NO = @AREA_NO "+
                                 "and WH_NO = @WH_NO "+
                                 "and ASRS_ID = @ASRS_ID " +
                                 "and BIN_NO = @BIN_NO " +
                                 " ";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("INHIBIT_IN_FLG", Forbidden ? "Y" : "N");
                        Cmd.Parameters.AddWithValue("INHIBIT_OUT_FLG", Forbidden ? "Y" : "N");
                        Cmd.Parameters.AddWithValue("AREA_NO", (object)Item.AREA_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("WH_NO", (object)Item.WH_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ASRS_ID", (object)Item.ASRS_ID ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("BIN_NO", (object)Item.BIN_NO ?? DBNull.Value);
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
    }
}

