using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace WMS.Service
{
    public class WcsCrnService
    {
        static System.Resources.ResourceManager RMPublic = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}Resource_Public", ""), System.Reflection.Assembly.GetExecutingAssembly());

        /// <summary>
        /// 手動控制類型
        /// </summary>
        public enum CrnManulAction
        {
            取物 = 1,
            置物 = 2,
            移動 = 3,
            庫間移載 = 4
        }

        /// <summary>
        /// 設備類型
        /// </summary>
        public enum DeviceType
        {
            設備站 = 1,
            庫位 = 2
        }

        public string QuerySql = "select a.*,  " +
                          "       isnull(b.ERR_DESC, a.ERR_CODE) ERR_CODE_DESC, " +
                          "       isnull(c.USER_NAME, a.UPDATE_BY) UPDATE_NAME " +
                          "from WCS_CRN a " +
                          "left join WCS_ERR_MAPPING_REF_VW b on a.ERR_CODE = b.ERR_CODE and b.LANG_ID = @LANG_ID and b.DEV_TYPE = 'C' " +
                          "left join HRS_USER c on a.UPDATE_BY = c.USER_NO " +
                          "where 1 = 1 {0} " +
                          "order by a.AREA_NO, a.WH_NO, a.ASRS_ID, a.CRN_ID ";

        public string QueryErrorLogSql = "select a.*, isnull(b.ERR_DESC, a.ERR_CODE) ERR_DESC "+
                                         "from WCS_CRN_ERR_LOG a "+
                                         "left join WCS_ERR_MAPPING_REF_VW b on b.LANG_ID = @LANG_ID and b.DEV_TYPE = 'C' and a.ERR_CODE = b.ERR_CODE " +
                                         "where 1 = 1 {0} "+
                                         "order by a.CRN_ID, a.CREATE_DATE ";

       
        public vPublic.DBExecResult GetAllWcsCrnList(string AREA_NO, string WH_NO, int? ASRS_ID, ref List<Model.WcsCrn> Data)
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
        /// 查詢吊車異常記錄
        /// </summary>
        /// <param name="CRN_ID"></param>
        /// <param name="Sdate"></param>
        /// <param name="Edate"></param>
        /// <returns></returns>
        public vPublic.DBExecResult GetAllCrnErrorLogList(int? CRN_ID, DateTime? Sdate, DateTime? Edate)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true };
            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>();
            string strSqlWhere = string.Empty;


            parameters.Add(new vPublic.DBParameter() { ParameterName = "LANG_ID", Value = Convert.ToInt16(Program.LangID) });

            
            if (CRN_ID.HasValue)
            {
                if (CRN_ID > 0)
                {
                    strSqlWhere += " and a.CRN_ID = @CRN_ID ";
                    parameters.Add(new vPublic.DBParameter() { ParameterName = "CRN_ID", Value = CRN_ID.Value });
                }
            }

            if (Sdate.HasValue)
            {
                strSqlWhere += " and a.CREATE_DATE >= @Sdate ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "Sdate", Value = Sdate.Value });
            }

            if (Edate.HasValue)
            {
                strSqlWhere += " and a.CREATE_DATE <= @Edate ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "Edate", Value = Edate.Value });
            }

            result = vPublic.GetDbData(string.Format(QueryErrorLogSql, strSqlWhere), parameters);
            if (result.Successed)
            {
                result.Data = result.ResultDt.AsEnumerable().Select(o => new Model.WcsCrnErrorLog()
                    {
                        CRN_ID = o.Field<decimal>("CRN_ID"),
                        FROM_BIN = o.Field<string>("FROM_BIN"),
                        FROM_SD = o.Field<string>("FROM_SD"),
                        TO_BIN = o.Field<string>("TO_BIN"),
                        TO_SD = o.Field<string>("TO_SD"),
                        ERR_CODE = o.Field<decimal>("ERR_CODE"),
                        IO = o.Field<string>("IO"),
                        STEP = o.Field<decimal>("STEP"),
                        LOADING = o.Field<decimal>("LOADING") > 0,
                        SER_NO = o.Field<decimal>("SER_NO"),
                        CREATE_DATE = o.Field<DateTime?>("CREATE_DATE"),
                        ERR_DESC = o.Field<string>("ERR_DESC")
                    }).ToList();
            }
            return result;
        }

        /// <summary>
        /// 取得吊車pd站
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult GetWcsCrnPDStation()
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true };
            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>();
            string strSql = string.Empty;

            strSql = "select * from WCS_CRN_PD_STATION order by CRN_ID ";

            result = vPublic.GetDbData(strSql, parameters);
            if (result.Successed)
            {
                List<Model.WcsCrnPdStation> PDStations = new List<WMS.Model.WcsCrnPdStation>();
                foreach (DataRow dr in result.ResultDt.Rows)
                {
                    PDStations.Add(new Model.WcsCrnPdStation()
                    {
                        CRN_ID = Convert.ToInt16(dr["CRN_ID"].ToString()),
                        DEV_NO = dr["DEV_NO"].ToString(),
                        BIN_NO = dr["BIN_NO"].ToString(),
                        IO = dr["IO"].ToString()
                    });
                }
                result.Data = PDStations;
            }

            return result;
        }

        /// <summary>
        /// 取得吊車pd站 by CRN_ID
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult GetWcsCrnPDStationById(int CrnID)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true };

            result = GetWcsCrnPDStation();

            if (result.Successed == false)
                return result;

            result.Data = ((List<Model.WcsCrnPdStation>)result.Data).Where(o => o.CRN_ID == CrnID).ToList();
            
            return result;
        }

        /// <summary>
        /// 取WcsCrn Data
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<Model.WcsCrn> GetDataList(DataTable dt)
        {
            List<Model.WcsCrn> Result = new List<Model.WcsCrn>();

            Result = dt.AsEnumerable().Select(o => new Model.WcsCrn()
            {
                AREA_NO = o.Field<string>("AREA_NO"),
                WH_NO = o.Field<string>("WH_NO"),
                ASRS_ID = o.Field<decimal>("ASRS_ID"),
                CRN_ID = o.Field<decimal>("CRN_ID"),
                CONNECT_MODE = o.Field<decimal>("CONNECT_MODE") > 0,
                CONNECT_MODE_DESC = o.Field<decimal>("CONNECT_MODE") > 0 ? RMPublic.GetString("Connected") : RMPublic.GetString("Disconnect"),
                INHIBIT_IN_FLG = o.Field<string>("INHIBIT_IN_FLG") == "Y",
                INHIBIT_OUT_FLG = o.Field<string>("INHIBIT_OUT_FLG") == "Y",
                IO = o.Field<string>("IO"),
                SER_NO = Convert.ToInt16(o.Field<decimal>("SER_NO")),
                FROM_BIN = o.Field<string>("FROM_BIN"),
                FROM_SD = o.Field<string>("FROM_SD"),
                TO_BIN = o.Field<string>("TO_BIN"),
                TO_SD = o.Field<string>("TO_SD"),
                START_TIME = o.Field<DateTime?>("START_TIME"),
                ERR_CODE = o.Field<decimal>("ERR_CODE"),
                ERR_CODE_DESC = o.Field<string>("ERR_CODE_DESC"),
                LOADING = o.Field<decimal>("LOADING") > 0,
                CRN_LOCATION = o.Field<string>("CRN_LOCATION"),
                CRN_SER_NO = o.Field<decimal>("CRN_SER_NO"),
                CRN_ERROR = o.Field<decimal>("CRN_ERROR"),
                CRN_AUTO = o.Field<decimal>("CRN_AUTO") > 0,
                CRN_INITIAL = o.Field<decimal>("CRN_INITIAL") > 0,
                CRN_CMD_COMP = o.Field<decimal>("CRN_CMD_COMP") > 0,
                CRN_NORMAL = o.Field<decimal>("CRN_NORMAL") > 0,
                CRN_CMD_EXIST = o.Field<decimal>("CRN_CMD_EXIST") > 0,
                CRN_READY = o.Field<decimal>("CRN_READY") > 0,
                INSIDE_INHIBIT_FLG = o.Field<string>("INSIDE_INHIBIT_FLG"),
                INSIDE_WORKER = o.Field<string>("INSIDE_WORKER"),
                INSIDE_PASSWORD = o.Field<string>("INSIDE_PASSWORD"),
                INSIDE_REMARK = o.Field<string>("INSIDE_REMARK"),
                CHK = false
            }).ToList();

            return Result;
        }

        /// <summary>
        /// 設定吊車禁入/禁出
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult SubmitCrnDisableSettings(List<Model.WcsCrn> Lists, Boolean DisableIn, Boolean DisableOut)
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
                        //更新單據數量
                        strSql = "update WCS_CRN set INHIBIT_IN_FLG = @INHIBIT_IN_FLG, INHIBIT_OUT_FLG = @INHIBIT_OUT_FLG "+
                                 "where AREA_NO = @AREA_NO and WH_NO = @WH_NO and ASRS_ID = @ASRS_ID and CRN_ID = @CRN_ID ";
                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("INHIBIT_IN_FLG", DisableIn ? "Y" : "N");
                        Cmd.Parameters.AddWithValue("INHIBIT_OUT_FLG", DisableOut ? "Y" : "N");
                        Cmd.Parameters.AddWithValue("AREA_NO", (object)Item.AREA_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("WH_NO", (object)Item.WH_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ASRS_ID", (object)Item.ASRS_ID ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CRN_ID", (object)Item.CRN_ID ?? DBNull.Value);

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
        /// 吊車異常復歸
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult SubmitCrnReset(List<Model.WcsCrn> Lists)
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
                        strSql = "insert into WCS_UI_COMMAND_ONLINE ( AREA_NO, WH_NO, ASRS_ID, CMD_ID, VAL, PARAM1, PARAM2, PARAM3, PARAM4, PARAM5 )"+
                                 "                            values(@AREA_NO,@WH_NO,@ASRS_ID,@CMD_ID,@VAL,@PARAM1,@PARAM2,@PARAM3,@PARAM4,@PARAM5)";
                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("AREA_NO", Item.AREA_NO);
                        Cmd.Parameters.AddWithValue("WH_NO", Item.WH_NO);
                        Cmd.Parameters.AddWithValue("ASRS_ID", Item.ASRS_ID);
                        Cmd.Parameters.AddWithValue("CMD_ID", 1);
                        Cmd.Parameters.AddWithValue("VAL", 1);
                        Cmd.Parameters.AddWithValue("PARAM1", Item.CRN_ID);
                        Cmd.Parameters.AddWithValue("PARAM2", DBNull.Value);
                        Cmd.Parameters.AddWithValue("PARAM3", DBNull.Value);
                        Cmd.Parameters.AddWithValue("PARAM4", DBNull.Value);
                        Cmd.Parameters.AddWithValue("PARAM5", DBNull.Value);

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
        /// 吊車續行
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult SubmitCrnRedo(List<Model.WcsCrn> Lists)
        {
            Model.WcsTrk TrkService = new WMS.Model.WcsTrk();
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = RMPublic.GetString("SubmitOK") };

            var TrkDataResult = vPublic.GetDbData("select * from WCS_TRK order by SER_NO ", new List<vPublic.DBParameter>());
            if (TrkDataResult.Successed == false)
                return TrkDataResult;

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
                        decimal SerNo = 0;
                        DateTime? CreateDate = null;
                        //檢查是否有屬於該台吊車的工作檔可以續行
                        var TrkItem = TrkDataResult.ResultDt
                            .AsEnumerable()
                            .Where(o => o.Field<string>("AREA_NO") == Item.AREA_NO &&
                                      o.Field<string>("WH_NO") == Item.WH_NO &&
                                      o.Field<decimal>("ASRS_ID") == Item.ASRS_ID &&
                                      o.Field<decimal>("SER_NO") == Item.SER_NO);

                        if (TrkItem == null || TrkItem.Count() <= 0)
                        {
                            var CheckCrnTrkItem = TrkDataResult.ResultDt
                            .AsEnumerable()
                            .Where(o => o.Field<decimal>("USE_CRN_ID") == Item.CRN_ID &&
                                      o.Field<string>("AREA_NO") == Item.AREA_NO &&
                                      o.Field<string>("WH_NO") == Item.WH_NO &&
                                      o.Field<decimal>("ASRS_ID") == Item.ASRS_ID &&
                                      (o.Field<decimal>("STEP") == (decimal)Model.WcsTrk.TrkStep.Step80 ||
                                      o.Field<decimal>("STEP") == (decimal)Model.WcsTrk.TrkStep.Step81 ||
                                      o.Field<decimal>("STEP") == (decimal)Model.WcsTrk.TrkStep.Step82 ||
                                      o.Field<decimal>("STEP") == (decimal)Model.WcsTrk.TrkStep.Step78)
                                      );

                            //查無異常工作檔「{0}」資料，無法執行吊車續行
                            if (CheckCrnTrkItem == null || CheckCrnTrkItem.Count() <= 0)
                                throw new Exception(string.Format(RMPublic.GetString("NoErrorTrk"), Item.SER_NO));
                            SerNo = CheckCrnTrkItem.First().Field<decimal>("SER_NO");
                            CreateDate = CheckCrnTrkItem.First().Field<DateTime?>("CREATE_DATE");
                        }
                        else
                        {
                            //針對屬於吊車序號的工作檔去續行
                            SerNo = TrkItem.First().Field<decimal>("SER_NO");
                            CreateDate = TrkItem.First().Field<DateTime?>("CREATE_DATE");
                        }

                        strSql = "update WCS_TRK set "+
                                 " STEP = @STEP83 "+
                                 " where SER_NO = @SER_NO "+
                                 " and CREATE_DATE = @CREATE_DATE "+
                                 " and STEP  in (78, 80, 81, 82)";
                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("STEP83", Model.WcsTrk.TrkStep.Step83); //吊車續行STEP = 83
                        Cmd.Parameters.AddWithValue("SER_NO", SerNo);
                        Cmd.Parameters.AddWithValue("CREATE_DATE", CreateDate);

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
        /// 吊車手動控制派令
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult SubmitCrnManualControl(List<Model.WcsCrn> Lists, CrnManulAction ManulActiom, string From, string To)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = RMPublic.GetString("SubmitOK") };
            Model.WcsTrk TrkService = new WMS.Model.WcsTrk();
            Model.WcsTrk Trk = new WMS.Model.WcsTrk();
            Service.WmsBinstaService serviceBinSta = new WmsBinstaService();

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
                        Trk = new WMS.Model.WcsTrk();

                        Trk.AREA_NO = Item.AREA_NO;
                        Trk.WH_NO = Item.WH_NO;
                        Trk.ASRS_ID = (int)Item.ASRS_ID;
                        Trk.USE_CRN_ID = (int)Item.CRN_ID;

                        #region 取序號、作業時間
                        int SerNo = 0;
                        var SerNoResult = TrkService.GenSerNo(ref SerNo);
                        if (SerNoResult.Successed == false)
                        {
                            result = SerNoResult;
                            break;
                        }

                        Trk.SER_NO = SerNo;

                        var CreateDateResult = vPublic.GetDbData("select getdate() ", new List<vPublic.DBParameter>());
                        if (CreateDateResult.Successed == false)
                        {
                            result = CreateDateResult;
                            break;
                        }

                        Trk.CREATE_DATE = Convert.ToDateTime(CreateDateResult.ResultDt.Rows[0][0].ToString());

                        #endregion

                        #region OPN
                        Trk.IO = ManulActiom == CrnManulAction.庫間移載 ? "C" : "M";
                        if (ManulActiom == CrnManulAction.移動)
                            Trk.OPN = WMS.Model.WcsTrk.TrkOPN.OPN2;
                        if (ManulActiom == CrnManulAction.取物)
                            Trk.OPN = WMS.Model.WcsTrk.TrkOPN.OPN3;
                        if (ManulActiom == CrnManulAction.置物)
                            Trk.OPN = WMS.Model.WcsTrk.TrkOPN.OPN4;
                        if (ManulActiom == CrnManulAction.庫間移載)
                            Trk.OPN = WMS.Model.WcsTrk.TrkOPN.OPN5;
                        #endregion

                        #region 來源位置
                        Trk.BIN_NO = From;
                        if (!string.IsNullOrEmpty(Trk.BIN_NO))
                        {
                            result = serviceBinSta.GetBinDataByBinNo(Trk.AREA_NO, Trk.WH_NO, Trk.ASRS_ID, Trk.BIN_NO);
                            if (result.Successed == false)
                                throw new Exception(result.Message);
                            if (((List<Model.WmsBinSta>)result.Data).Count <= 0)
                                Trk.SD = "S";
                            else
                                Trk.SD = ((List<Model.WmsBinSta>)result.Data).First().SD;
                        }
                        else
                        {
                            Trk.SD = "";
                        }
                        #endregion

                        #region 目的位置
                        Trk.SHF_NO = To;
                        if (!string.IsNullOrEmpty(Trk.SHF_NO))
                        {
                            result = serviceBinSta.GetBinDataByBinNo(Trk.AREA_NO, Trk.WH_NO, Trk.ASRS_ID, Trk.SHF_NO);
                            if (result.Successed == false)
                                throw new Exception(result.Message);
                            if (((List<Model.WmsBinSta>)result.Data).Count <= 0)
                                Trk.SHF_SD = "S";
                            else
                                Trk.SHF_SD = ((List<Model.WmsBinSta>)result.Data).First().SD;
                        }
                        else
                        {
                            Trk.SHF_SD = "";
                        }
                        #endregion

                        Trk.STEP = WMS.Model.WcsTrk.TrkStep.Step0;
                        Trk.STATUS = 0;
                        Trk.EMERGE = WMS.Model.WcsTrk.TrkEmerge.Normal;
                        Trk.CREATE_BY = Program.wmsUser.UserNo;
                            
                        strSql = "insert into WCS_TRK ( SER_NO, AREA_NO, WH_NO, ASRS_ID, BIN_NO, SD, SHF_NO, SHF_SD, DEV_NO, CUR_DEV_NO, " + "\r\n" +
                                 "                      NEXT_DEV_NO, TRANS_DEV_NO, IO, STEP, STATUS, OPN, USE_CRN_ID, EMERGE, WEIGHT, SIZE_CHK, " + "\r\n" +
                                 "                      BIN_TYPE, KIND, START_TIME, END_TIME, PALLET_NO, CREATE_DATE, CREATE_BY ) " + "\r\n" +
                                 "              values(@SER_NO,@AREA_NO,@WH_NO,@ASRS_ID,@BIN_NO,@SD,@SHF_NO,@SHF_SD,@DEV_NO,@CUR_DEV_NO, " + "\r\n" +
                                 "                     @NEXT_DEV_NO,@TRANS_DEV_NO,@IO,@STEP,@STATUS,@OPN,@USE_CRN_ID,@EMERGE,@WEIGHT,@SIZE_CHK, " + "\r\n" +
                                 "                     @BIN_TYPE,@KIND,@START_TIME,@END_TIME,@PALLET_NO,@CREATE_DATE,@CREATE_BY) ";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("SER_NO", (object)Trk.SER_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("AREA_NO", (object)Trk.AREA_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("WH_NO", (object)Trk.WH_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ASRS_ID", (object)Trk.ASRS_ID ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("BIN_NO", (object)Trk.BIN_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("SD", (object)Trk.SD ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("SHF_NO", (object)Trk.SHF_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("SHF_SD", (object)Trk.SHF_SD ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("DEV_NO", (object)Trk.DEV_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CUR_DEV_NO", (object)Trk.CUR_DEV_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("NEXT_DEV_NO", (object)Trk.NEXT_DEV_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("TRANS_DEV_NO", (object)Trk.TRANS_DEV_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("IO", (object)Trk.IO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STEP", Convert.ToInt16(Trk.STEP));
                        Cmd.Parameters.AddWithValue("STATUS", (object)Trk.STATUS ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("OPN", Convert.ToInt16(Trk.OPN));
                        Cmd.Parameters.AddWithValue("USE_CRN_ID", (object)Trk.USE_CRN_ID ?? 0);
                        Cmd.Parameters.AddWithValue("EMERGE", Convert.ToInt16(Trk.EMERGE));
                        Cmd.Parameters.AddWithValue("WEIGHT", (object)Trk.WEIGHT ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("SIZE_CHK", (object)Trk.SIZE_CHK ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("BIN_TYPE", (object)Trk.BIN_TYPE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("KIND", (object)Trk.KIND ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("START_TIME", (object)Trk.START_TIME ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("END_TIME", (object)Trk.END_TIME ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PALLET_NO", (object)Trk.PALLET_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_DATE", (object)Trk.CREATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_BY", (object)Trk.CREATE_BY ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();

                        //庫間移載
                        if (Trk.OPN == WMS.Model.WcsTrk.TrkOPN.OPN5)
                        {
                            strSql = "update WMS_BINSTA set BIN_STA = @BIN_STA_O "+
                                     "where AREA_NO = @AREA_NO "+
                                     "and WH_NO = @WH_NO and ASRS_ID = @ASRS_ID and BIN_NO = @BIN_NO ";
                            Cmd.CommandText = strSql;
                            Cmd.Parameters.Clear();

                            Cmd.Parameters.AddWithValue("BIN_STA_O", Model.WcsTrk.IO_O);
                            Cmd.Parameters.AddWithValue("AREA_NO", (object)Trk.AREA_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("WH_NO", (object)Trk.WH_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("ASRS_ID", (object)Trk.ASRS_ID ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("BIN_NO", (object)Trk.BIN_NO ?? DBNull.Value);
                            rtn = Cmd.ExecuteNonQuery();

                            strSql = "update WMS_BINSTA set BIN_STA = @BIN_STA_I " +
                                     "where AREA_NO = @AREA_NO " +
                                     "and WH_NO = @WH_NO and ASRS_ID = @ASRS_ID and BIN_NO = @BIN_NO ";
                            Cmd.CommandText = strSql;
                            Cmd.Parameters.Clear();

                            Cmd.Parameters.AddWithValue("BIN_STA_I", Model.WcsTrk.IO_I);
                            Cmd.Parameters.AddWithValue("AREA_NO", (object)Trk.AREA_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("WH_NO", (object)Trk.WH_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("ASRS_ID", (object)Trk.ASRS_ID ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("BIN_NO", (object)Trk.SHF_NO ?? DBNull.Value);
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
                    //return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
                }
                finally
                {
                    if (Conn.State == ConnectionState.Open)
                        Conn.Close();
                    Conn.Dispose();
                }
            }
            if (result.Successed)
                result.Message = RMPublic.GetString("SubmitOK");
            return result;
        }
    }
}
