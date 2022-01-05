using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace WMS.Service
{
    public class WmsCycdService
    {
        static System.Resources.ResourceManager RMPublic = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}Resource_Public", ""), System.Reflection.Assembly.GetExecutingAssembly());

        private string QuerySql = "select a.* "+
                                  ",isnull(b.PROD_NAME,a.PROD_NO) PROD_NAME"+
                                  ",isnull(c.USER_NAME,a.CREATE_BY) CREATE_NAME "+
                                  ",isnull(d.SNAME,a.ORG_NO) ORG_SNAME " +
                                  ", case when a.REPLY_FLG = 0 then @REPLY_FLG0 when a.REPLY_FLG = 1 then @REPLY_FLG1 end REPLY_FLG_DESC " +
                                  ", case when a.CYCD_FLAG = 0 then @CYCD_FLAG0 when a.CYCD_FLAG = 1 then @CYCD_FLAG1 end CYCD_FLAG_DESC " +
                                  ",case when a.QC_RESULT = 0 then @QC0 "+
                                  "      when a.QC_RESULT = 1 then @QC1 "+
                                  "      when a.QC_RESULT = 2 then @QC2 "+
                                  "      when a.QC_RESULT = 3 then @QC3 "+
                                  "      when a.QC_RESULT = 4 then @QC4 "+
                                  "      when a.QC_RESULT = 5 then @QC5 "+
                                  "      else Convert(varchar,a.QC_RESULT) end QC_RESULT_DESC " +
                                  "from WMS_CYCD a "+
                                  "left join (select PROD_NO, PROD_NAME from WMS_PROD) b on a.PROD_NO = b.PROD_NO "+
                                  "left join (select USER_NO, USER_NAME from HRS_USER) c on a.CREATE_BY = c.USER_NO " +
                                  "left join (select ORG_NO, SNAME from WMS_ORG) d on a.ORG_NO = d.ORG_NO " +
                                  "where 1 = 1 {0} "+
                                  "order by a.CHECK_NO, a.FIFO_NO, a.CYCD_FLAG ";

        /// <summary>
        /// 查詢盤差資料
        /// </summary>
        /// <param name="Sdate">盤點日期(起始)</param>
        /// <param name="Edate">盤點日期(結束)</param>
        /// <param name="ProdNo">料號</param>
        /// <returns></returns>
        public vPublic.DBExecResult GetData(DateTime? Sdate, DateTime? Edate, string ProdNo)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = "" };

            string strSqlWhere = string.Empty;
            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>();

            parameters.Add(new vPublic.DBParameter() { ParameterName = "REPLY_FLG0", Value = RMPublic.GetString("REPLY_FLG0") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "REPLY_FLG1", Value = RMPublic.GetString("REPLY_FLG1") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "CYCD_FLAG0", Value = RMPublic.GetString("CYCD_FLAG0") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "CYCD_FLAG1", Value = RMPublic.GetString("CYCD_FLAG1") });

            parameters.Add(new vPublic.DBParameter() { ParameterName = "QC0", Value = RMPublic.GetString("QC0") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "QC1", Value = RMPublic.GetString("QC1") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "QC2", Value = RMPublic.GetString("QC2") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "QC3", Value = RMPublic.GetString("QC3") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "QC4", Value = RMPublic.GetString("QC4") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "QC5", Value = RMPublic.GetString("QC5") });

            if (Sdate.HasValue)
            {
                strSqlWhere += " and a.CHECK_DATE >= @Sdate ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "Sdate", Value = Sdate.Value });
            }

            if (Edate.HasValue)
            {
                strSqlWhere += " and a.CHECK_DATE <= @Edate ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "Edate", Value = Edate.Value });
            }

            if (!string.IsNullOrEmpty(ProdNo))
            {
                strSqlWhere += " and a.PROD_NO = @ProdNo ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "ProdNo", Value = ProdNo });
            }

            result = vPublic.GetDbData(string.Format(QuerySql, strSqlWhere), parameters);
            if (result.Successed == false)
                return result;

            result.Data = (List<Model.WmsCycd>)result.ResultDt.AsEnumerable()
                .Select(o => new Model.WmsCycd()
                {
                    CHECK_NO = o.Field<string>("CHECK_NO"),
                    REPLY_FLG = (Model.WmsCycd.ReplyFlag)Enum.ToObject(typeof(Model.WmsCycd.ReplyFlag), Convert.ToInt16(o.Field<decimal>("REPLY_FLG"))),
                    FIFO_NO = o.Field<string>("FIFO_NO"),
                    AREA_NO = o.Field<string>("AREA_NO"),
                    WH_NO = o.Field<string>("WH_NO"),
                    ASRS_ID = o.Field<decimal>("ASRS_ID"),
                    BIN_NO = o.Field<string>("BIN_NO"),
                    SD = o.Field<string>("SD"),
                    CYCD_FLAG = (Model.WmsCycd.CycdFlag)Enum.ToObject(typeof(Model.WmsCycd.CycdFlag), Convert.ToInt16(o.Field<decimal>("CYCD_FLAG"))),
                    LIST_NO = o.Field<string>("LIST_NO"),
                    LINE_ID = o.Field<decimal?>("LINE_ID"),
                    PALLET_NO = o.Field<string>("PALLET_NO"),
                    PROD_NO = o.Field<string>("PROD_NO"),
                    LOT_NO = o.Field<string>("LOT_NO"),
                    ORG_NO = o.Field<string>("ORG_NO"),
                    QTY = o.Field<decimal>("QTY"),
                    UN = o.Field<string>("UN"),
                    STOREIN_DATE = o.Field<DateTime?>("STOREIN_DATE"),
                    PRODUCTION_DATE = o.Field<DateTime?>("PRODUCTION_DATE"),
                    PROD_NAME = o.Field<string>("PROD_NAME"),
                    QC_RESULT = (Model.WmsStk.QCResult)Enum.ToObject(typeof(Model.WmsStk.QCResult), Convert.ToInt16(o.Field<decimal>("QC_RESULT"))),
                    QC_RESULT_DESC = o.Field<string>("QC_RESULT_DESC"),
                    ORG_SNAME = o.Field<string>("ORG_SNAME"),
                    CHECK_DATE = o.Field<DateTime?>("CHECK_DATE"),
                    REMARK = o.Field<string>("REMARK"),
                    CREATE_BY = o.Field<string>("CREATE_BY"),
                    CREATE_DATE = o.Field<DateTime?>("CREATE_DATE"),
                    CREATE_NAME = o.Field<string>("CREATE_NAME"),
                    CHK = false,
                    REPLY_FLG_DESC = o.Field<string>("REPLY_FLG_DESC"),
                    CYCD_FLAG_DESC = o.Field<string>("CYCD_FLAG_DESC"),
                }).ToList();

            return result;
        }

        /// <summary>
        /// 新增盤點差異資料
        /// </summary>
        /// <param name="Datas"></param>
        /// <returns></returns>
        public vPublic.DBExecResult Add(List<Model.WmsCycd> Datas)
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

                    foreach (var Item in Datas)
                    {
                        strSql = @"insert into WMS_CYCD ( CHECK_NO, REPLY_FLG, FIFO_NO, AREA_NO, WH_NO, ASRS_ID, BIN_NO, SD, 
                                                          CYCD_FLAG, LIST_NO, LINE_ID, PALLET_NO, PROD_NO, LOT_NO, ORG_NO,
                                                          QTY, UN, STOREIN_DATE, PRODUCTION_DATE, QC_RESULT, CHECK_DATE, REMARK,
                                                          CREATE_DATE, CREATE_BY )
                                                 values (@CHECK_NO,@REPLY_FLG,@FIFO_NO,@AREA_NO,@WH_NO,@ASRS_ID,@BIN_NO,@SD, 
                                                         @CYCD_FLAG,@LIST_NO,@LINE_ID,@PALLET_NO,@PROD_NO,@LOT_NO,@ORG_NO,
                                                         @QTY,@UN,@STOREIN_DATE,@PRODUCTION_DATE,@QC_RESULT,@CHECK_DATE,@REMARK,
                                                         @CREATE_DATE,@CREATE_BY )";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("CHECK_NO", (object)Item.CHECK_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("REPLY_FLG", (int)Item.REPLY_FLG);
                        Cmd.Parameters.AddWithValue("FIFO_NO", (object)Item.FIFO_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("AREA_NO", (object)Item.AREA_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("WH_NO", (object)Item.WH_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ASRS_ID", (object)Item.ASRS_ID ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("BIN_NO", (object)Item.BIN_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("SD", (object)Item.SD ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CYCD_FLAG", (int)Item.CYCD_FLAG);
                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LINE_ID", (object)Item.LINE_ID ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PALLET_NO", (object)Item.PALLET_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_NO", (object)Item.PROD_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LOT_NO", (object)Item.LOT_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ORG_NO", (object)Item.ORG_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("QTY", (object)Item.QTY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UN", (object)Item.UN ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STOREIN_DATE", (object)Item.STOREIN_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PRODUCTION_DATE", (object)Item.PRODUCTION_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("QC_RESULT", (object)Item.QC_RESULT ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CHECK_DATE", (object)Item.CHECK_DATE ?? DateTime.Now);
                        Cmd.Parameters.AddWithValue("REMARK", (object)Item.REMARK ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_DATE", (object)Item.CREATE_DATE ?? DateTime.Now);
                        Cmd.Parameters.AddWithValue("CREATE_BY", (object)Item.CREATE_BY ?? Program.wmsUser.UserNo);
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
        /// 儲存盤點調整
        /// </summary>
        /// <param name="Datas"></param>
        /// <returns></returns>
        public vPublic.DBExecResult Save(List<Model.WmsStk> Stks, List<Model.WmsStk> OriStks)
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

                    string CheckNo = DateTime.Now.ToString("yyyyMMddHHmmss");
                    DateTime CheckDate = DateTime.Now;
                    Model.WmsStk serviceStk = new WMS.Model.WmsStk();

                    OriStks = OriStks.Where(o => o.STUS_CTR == (decimal)Model.WmsStk.StusCtr.盤點待回庫 
                        && o.WH_NO == vPublic.AsrsDefine.WH_NO_C
                        && o.UPDATE_DATE == OriStks.First().UPDATE_DATE
                        && o.UPDATE_BY == OriStks.First().UPDATE_BY
                        )
                        .ToList();

                    if (OriStks.Count <= 0)
                        throw new Exception(RMPublic.GetString("CycdMsg001"));  //庫存已被異動，請重新查詢確認

                    if (Stks.Count > 0)
                    {
                        //有盤點待回庫資料
                        foreach (var Item in Stks)
                        {
                            #region 寫盤點差異記錄(修改前)
                            var PreStk = OriStks.Where(o => o.FIFO_NO == Item.FIFO_NO).FirstOrDefault();
                            if (PreStk != null)
                            {
                                
                                strSql = @"insert into WMS_CYCD ( CHECK_NO, REPLY_FLG, FIFO_NO, AREA_NO, WH_NO, ASRS_ID, BIN_NO, SD, 
                                                          CYCD_FLAG, LIST_NO, LINE_ID, PALLET_NO, PROD_NO, LOT_NO, ORG_NO,
                                                          QTY, UN, STOREIN_DATE, PRODUCTION_DATE, QC_RESULT, CHECK_DATE, REMARK,
                                                          CREATE_DATE, CREATE_BY )
                                                 values (@CHECK_NO,@REPLY_FLG,@FIFO_NO,@AREA_NO,@WH_NO,@ASRS_ID,@BIN_NO,@SD, 
                                                         @CYCD_FLAG,@LIST_NO,@LINE_ID,@PALLET_NO,@PROD_NO,@LOT_NO,@ORG_NO,
                                                         @QTY,@UN,@STOREIN_DATE,@PRODUCTION_DATE,@QC_RESULT,@CHECK_DATE,@REMARK,
                                                         @CREATE_DATE,@CREATE_BY )";

                                Cmd.CommandText = strSql;
                                Cmd.Parameters.Clear();

                                Cmd.Parameters.AddWithValue("CHECK_NO", CheckNo);
                                Cmd.Parameters.AddWithValue("REPLY_FLG", Model.WmsCycd.ReplyFlag.未回報);
                                Cmd.Parameters.AddWithValue("FIFO_NO", (object)PreStk.FIFO_NO ?? DBNull.Value);
                                Cmd.Parameters.AddWithValue("AREA_NO", (object)PreStk.AREA_NO ?? DBNull.Value);
                                Cmd.Parameters.AddWithValue("WH_NO", (object)PreStk.WH_NO ?? DBNull.Value);
                                Cmd.Parameters.AddWithValue("ASRS_ID", (object)PreStk.ASRS_ID ?? DBNull.Value);
                                Cmd.Parameters.AddWithValue("BIN_NO", (object)PreStk.BIN_NO ?? DBNull.Value);
                                Cmd.Parameters.AddWithValue("SD", (object)PreStk.SD ?? DBNull.Value);
                                Cmd.Parameters.AddWithValue("CYCD_FLAG", Model.WmsCycd.CycdFlag.修改前);
                                Cmd.Parameters.AddWithValue("LIST_NO", (object)PreStk.LIST_NO ?? DBNull.Value);
                                Cmd.Parameters.AddWithValue("LINE_ID", (object)PreStk.LINE_ID ?? DBNull.Value);
                                Cmd.Parameters.AddWithValue("PALLET_NO", "");
                                Cmd.Parameters.AddWithValue("PROD_NO", (object)PreStk.PROD_NO ?? DBNull.Value);
                                Cmd.Parameters.AddWithValue("LOT_NO", (object)PreStk.LOT_NO ?? DBNull.Value);
                                Cmd.Parameters.AddWithValue("ORG_NO", (object)PreStk.ORG_NO ?? DBNull.Value);
                                Cmd.Parameters.AddWithValue("QTY", (object)PreStk.QTY ?? DBNull.Value);
                                Cmd.Parameters.AddWithValue("UN", (object)PreStk.UN ?? DBNull.Value);
                                Cmd.Parameters.AddWithValue("STOREIN_DATE", (object)PreStk.STOREIN_DATE ?? DBNull.Value);
                                Cmd.Parameters.AddWithValue("PRODUCTION_DATE", (object)PreStk.PRODUCTION_DATE ?? DBNull.Value);
                                Cmd.Parameters.AddWithValue("QC_RESULT", (object)PreStk.QC_RESULT ?? DBNull.Value);
                                Cmd.Parameters.AddWithValue("CHECK_DATE", CheckDate);
                                Cmd.Parameters.AddWithValue("REMARK", (object)PreStk.REMARK ?? DBNull.Value);
                                Cmd.Parameters.AddWithValue("CREATE_DATE", (object)PreStk.CREATE_DATE ?? DateTime.Now);
                                Cmd.Parameters.AddWithValue("CREATE_BY", (object)PreStk.CREATE_BY ?? Program.wmsUser.UserNo);
                                rtn = Cmd.ExecuteNonQuery();
                            }
                            #endregion

                            #region 寫盤點差異記錄(修改後)

                            strSql = @"insert into WMS_CYCD ( CHECK_NO, REPLY_FLG, FIFO_NO, AREA_NO, WH_NO, ASRS_ID, BIN_NO, SD, 
                                                          CYCD_FLAG, LIST_NO, LINE_ID, PALLET_NO, PROD_NO, LOT_NO, ORG_NO,
                                                          QTY, UN, STOREIN_DATE, PRODUCTION_DATE, QC_RESULT, CHECK_DATE, REMARK,
                                                          CREATE_DATE, CREATE_BY )
                                                 values (@CHECK_NO,@REPLY_FLG,@FIFO_NO,@AREA_NO,@WH_NO,@ASRS_ID,@BIN_NO,@SD, 
                                                         @CYCD_FLAG,@LIST_NO,@LINE_ID,@PALLET_NO,@PROD_NO,@LOT_NO,@ORG_NO,
                                                         @QTY,@UN,@STOREIN_DATE,@PRODUCTION_DATE,@QC_RESULT,@CHECK_DATE,@REMARK,
                                                         @CREATE_DATE,@CREATE_BY )";

                            Cmd.CommandText = strSql;
                            Cmd.Parameters.Clear();

                            Cmd.Parameters.AddWithValue("CHECK_NO", CheckNo);
                            Cmd.Parameters.AddWithValue("REPLY_FLG", Model.WmsCycd.ReplyFlag.未回報);
                            Cmd.Parameters.AddWithValue("FIFO_NO", (object)Item.FIFO_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("AREA_NO", (object)Item.AREA_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("WH_NO", (object)Item.WH_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("ASRS_ID", (object)Item.ASRS_ID ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("BIN_NO", (object)Item.BIN_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("SD", (object)Item.SD ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("CYCD_FLAG", Model.WmsCycd.CycdFlag.修改後);
                            Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("LINE_ID", (object)Item.LINE_ID ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("PALLET_NO", "");
                            Cmd.Parameters.AddWithValue("PROD_NO", (object)Item.PROD_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("LOT_NO", (object)Item.LOT_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("ORG_NO", (object)Item.ORG_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("QTY", (object)Item.QTY ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("UN", (object)Item.UN ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("STOREIN_DATE", (object)Item.STOREIN_DATE ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("PRODUCTION_DATE", (object)Item.PRODUCTION_DATE ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("QC_RESULT", (object)Item.QC_RESULT ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("CHECK_DATE", CheckDate);
                            Cmd.Parameters.AddWithValue("REMARK", (object)Item.REMARK ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("CREATE_DATE", (object)Item.CREATE_DATE ?? DateTime.Now);
                            Cmd.Parameters.AddWithValue("CREATE_BY", (object)Item.CREATE_BY ?? Program.wmsUser.UserNo);
                            rtn = Cmd.ExecuteNonQuery();

                            #endregion

                            #region 寫庫存
                            if (string.IsNullOrEmpty(Item.FIFO_NO))
                            {
                                result = serviceStk.GenFifoNo();
                                if (result.Successed == false)
                                    throw new Exception(result.Message);
                                Item.FIFO_NO = result.Data.ToString();

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
                                Cmd.Parameters.AddWithValue("LOG_TYPE", Model.WmsStk.ModifyLogType.新增);
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

                            strSql = "delete WMS_STK where FIFO_NO = @FIFO_NO ";
                            Cmd.CommandText = strSql;
                            Cmd.Parameters.Clear();

                            Cmd.Parameters.AddWithValue("FIFO_NO", Item.FIFO_NO);
                            rtn = Cmd.ExecuteNonQuery();

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
                            Cmd.Parameters.AddWithValue("FIFO_NO", Item.FIFO_NO);
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

                            #endregion
                        }
                    }
                    else
                    {
                        /*
                         * 沒有盤點待回庫資料
                         * 代表所有盤點待回庫庫存不回倉庫(直接寫盤點差異記錄表(修改前))
                         */
                        foreach (var Item in OriStks)
                        {
                            #region 寫盤點差異記錄(修改前)
                            
                            strSql = @"insert into WMS_CYCD ( CHECK_NO, REPLY_FLG, FIFO_NO, AREA_NO, WH_NO, ASRS_ID, BIN_NO, SD, 
                                                      CYCD_FLAG, LIST_NO, LINE_ID, PALLET_NO, PROD_NO, LOT_NO, ORG_NO,
                                                      QTY, UN, STOREIN_DATE, PRODUCTION_DATE, QC_RESULT, CHECK_DATE, REMARK,
                                                      CREATE_DATE, CREATE_BY )
                                             values (@CHECK_NO,@REPLY_FLG,@FIFO_NO,@AREA_NO,@WH_NO,@ASRS_ID,@BIN_NO,@SD, 
                                                     @CYCD_FLAG,@LIST_NO,@LINE_ID,@PALLET_NO,@PROD_NO,@LOT_NO,@ORG_NO,
                                                     @QTY,@UN,@STOREIN_DATE,@PRODUCTION_DATE,@QC_RESULT,@CHECK_DATE,@REMARK,
                                                     @CREATE_DATE,@CREATE_BY )";

                            Cmd.CommandText = strSql;
                            Cmd.Parameters.Clear();

                            Cmd.Parameters.AddWithValue("CHECK_NO", CheckNo);
                            Cmd.Parameters.AddWithValue("REPLY_FLG", Model.WmsCycd.ReplyFlag.未回報);
                            Cmd.Parameters.AddWithValue("FIFO_NO", (object)Item.FIFO_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("AREA_NO", (object)Item.AREA_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("WH_NO", (object)Item.WH_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("ASRS_ID", (object)Item.ASRS_ID ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("BIN_NO", (object)Item.BIN_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("SD", (object)Item.SD ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("CYCD_FLAG", Model.WmsCycd.CycdFlag.修改前);
                            Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("LINE_ID", (object)Item.LINE_ID ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("PALLET_NO", "");
                            Cmd.Parameters.AddWithValue("PROD_NO", (object)Item.PROD_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("LOT_NO", (object)Item.LOT_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("ORG_NO", (object)Item.ORG_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("QTY", (object)Item.QTY ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("UN", (object)Item.UN ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("STOREIN_DATE", (object)Item.STOREIN_DATE ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("PRODUCTION_DATE", (object)Item.PRODUCTION_DATE ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("QC_RESULT", (object)Item.QC_RESULT ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("CHECK_DATE", CheckDate);
                            Cmd.Parameters.AddWithValue("REMARK", (object)Item.REMARK ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("CREATE_DATE", (object)Item.CREATE_DATE ?? DateTime.Now);
                            Cmd.Parameters.AddWithValue("CREATE_BY", (object)Item.CREATE_BY ?? Program.wmsUser.UserNo);
                            rtn = Cmd.ExecuteNonQuery();
                            
                            #endregion

                            #region 寫庫存維護記錄

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
                            Cmd.Parameters.AddWithValue("LOG_TYPE", Model.WmsStk.ModifyLogType.刪除);
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

                            #endregion

                            //刪除庫存資料
                            strSql = "delete WMS_STK where FIFO_NO = @FIFO_NO ";
                            Cmd.CommandText = strSql;
                            Cmd.Parameters.Clear();

                            Cmd.Parameters.AddWithValue("FIFO_NO", Item.FIFO_NO);
                            rtn = Cmd.ExecuteNonQuery();

                        }
                    }

                    //檢查是否有被刪除掉的庫存資料
                    var CheckResult = OriStks.Where(o => !Stks.Any(x => x.FIFO_NO == o.FIFO_NO)).ToList();

                    foreach (var Item in CheckResult)
                    {
                        #region 寫盤點差異記錄(修改前)

                        strSql = @"insert into WMS_CYCD ( CHECK_NO, REPLY_FLG, FIFO_NO, AREA_NO, WH_NO, ASRS_ID, BIN_NO, SD, 
                                                      CYCD_FLAG, LIST_NO, LINE_ID, PALLET_NO, PROD_NO, LOT_NO, ORG_NO,
                                                      QTY, UN, STOREIN_DATE, PRODUCTION_DATE, QC_RESULT, CHECK_DATE, REMARK,
                                                      CREATE_DATE, CREATE_BY )
                                             values (@CHECK_NO,@REPLY_FLG,@FIFO_NO,@AREA_NO,@WH_NO,@ASRS_ID,@BIN_NO,@SD, 
                                                     @CYCD_FLAG,@LIST_NO,@LINE_ID,@PALLET_NO,@PROD_NO,@LOT_NO,@ORG_NO,
                                                     @QTY,@UN,@STOREIN_DATE,@PRODUCTION_DATE,@QC_RESULT,@CHECK_DATE,@REMARK,
                                                     @CREATE_DATE,@CREATE_BY )";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("CHECK_NO", CheckNo);
                        Cmd.Parameters.AddWithValue("REPLY_FLG", Model.WmsCycd.ReplyFlag.未回報);
                        Cmd.Parameters.AddWithValue("FIFO_NO", (object)Item.FIFO_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("AREA_NO", (object)Item.AREA_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("WH_NO", (object)Item.WH_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ASRS_ID", (object)Item.ASRS_ID ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("BIN_NO", (object)Item.BIN_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("SD", (object)Item.SD ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CYCD_FLAG", Model.WmsCycd.CycdFlag.修改前);
                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LINE_ID", (object)Item.LINE_ID ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PALLET_NO", "");
                        Cmd.Parameters.AddWithValue("PROD_NO", (object)Item.PROD_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LOT_NO", (object)Item.LOT_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ORG_NO", (object)Item.ORG_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("QTY", (object)Item.QTY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UN", (object)Item.UN ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STOREIN_DATE", (object)Item.STOREIN_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PRODUCTION_DATE", (object)Item.PRODUCTION_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("QC_RESULT", (object)Item.QC_RESULT ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CHECK_DATE", CheckDate);
                        Cmd.Parameters.AddWithValue("REMARK", (object)Item.REMARK ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_DATE", (object)Item.CREATE_DATE ?? DateTime.Now);
                        Cmd.Parameters.AddWithValue("CREATE_BY", (object)Item.CREATE_BY ?? Program.wmsUser.UserNo);
                        rtn = Cmd.ExecuteNonQuery();

                        #endregion

                        #region 寫庫存維護記錄

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
                        Cmd.Parameters.AddWithValue("LOG_TYPE", Model.WmsStk.ModifyLogType.刪除);
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

                        #endregion

                        //刪除庫存資料
                        strSql = "delete WMS_STK where FIFO_NO = @FIFO_NO ";
                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("FIFO_NO", Item.FIFO_NO);
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
