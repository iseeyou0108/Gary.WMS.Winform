using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WMS.Service
{
    public class WcsTrkLogService
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}Resource_WMS_STK", ""), System.Reflection.Assembly.GetExecutingAssembly());

        public string  QuerySql = "select a.LOG_TIME, a.SER_NO, a.AREA_NO, a.WH_NO, a.ASRS_ID, a.BIN_NO, a.SD, a.DEV_NO, a.NEXT_DEV_NO, "+
                                  "       a.TRANS_DEV_NO, a.CUR_DEV_NO, a.IO, f.IO_DESC, a.STEP, b.STEP_DESC, a.STATUS, c.STATUS_DESC, a.OPN, d.OPN_DESC,"+
                                  "       a.USE_CRN_ID, a.EMERGE, a.WEIGHT, a.START_TIME, a.STEP_TIME, a.PALLET_NO, a.CREATE_DATE, a.CREATE_BY, "+
                                  "       e.USER_NAME as CREATE_NAME, a.SHF_NO, a.SHF_SD, a.END_TIME,  " +
                                  "       g.*,(select SNAME from WMS_ORG where g.ORG_NO = ORG_NO ) ORG_SNAME,"+
                                  "       (select PROD_NAME from WMS_PROD where g.PROD_NO = PROD_NO ) PROD_NAME " +
                                  "from WCS_TRK_LOG a "+
                                  "left join WCS_TRK_STEP_REF_VW b on a.STEP = b.STEP and b.LANG_ID = @LANG_ID "+
                                  "left join WCS_TRK_STATUS_REF_VW c on a.STATUS = c.STATUS and c.LANG_ID = @LANG_ID " +
                                  "left join WCS_TRK_OPN_REF_VW d on a.OPN = d.OPN and d.LANG_ID = @LANG_ID " +
                                  "left join HRS_USER e on a.CREATE_BY = e.USER_NO " +
                                  "left join WCS_TRK_IO_REF_VW f on a.IO = f.IO and f.LANG_ID = @LANG_ID " +
                                  "left join WCS_TRK_DET_LOG g on a.WH_NO = g.WH_NO and a.AREA_NO = g.AREA_NO and a.ASRS_ID = g.ASRS_ID and a.SER_NO = g.SER_NO and a.CREATE_DATE = g.CREATE_DATE "+
                                  "where 1 = 1 {0} " +
                                  "order by a.SER_NO ";

        /// <summary>
        /// 取得所有工作檔歷史記錄
        /// </summary>
        /// <param name="AREA_NO"></param>
        /// <param name="WH_NO"></param>
        /// <param name="ASRS_ID">倉庫代號</param>
        /// <param name="SDate">查詢-起始日期</param>
        /// <param name="EDate">查詢-結束日期</param>
        /// <param name="Data">返回的資料集</param>
        /// <returns></returns>
        public vPublic.DBExecResult GetAllWcsTrkLogList(string AREA_NO, string WH_NO, int? ASRS_ID, DateTime? SDate, DateTime? EDate, ref List<Model.WcsTrkLog> Data)
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

            if (SDate.HasValue)
            {
                strSqlWhere += " and a.CREATE_DATE >= @SDate ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "SDATE", Value = SDate.Value });
            }
            if (EDate.HasValue)
            {
                strSqlWhere += " and a.CREATE_DATE <= @EDate ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "EDate", Value = EDate.Value });
            }

            result = vPublic.GetDbData(string.Format(QuerySql, strSqlWhere), parameters);
            if (result.Successed)
                Data = GetDataList(result.ResultDt);

            return result;
        }

        /// <summary>
        /// 取得所有工作檔明細歷史記錄
        /// </summary>
        /// <param name="AREA_NO"></param>
        /// <param name="WH_NO"></param>
        /// <param name="ASRS_ID">倉庫代號</param>
        /// <param name="SDate">查詢-起始日期</param>
        /// <param name="EDate">查詢-結束日期</param>
        /// <param name="Data">返回的資料集</param>
        /// <returns></returns>
        public vPublic.DBExecResult GetFinishedWcsTrkLogDetailList(string AREA_NO, string WH_NO, int? ASRS_ID, DateTime? SDate, DateTime? EDate, ref List<Model.WcsTrkLog.WcsTrkDetLog> Data)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true };
            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>();
            string strSqlWhere = string.Empty;

            parameters.Add(new vPublic.DBParameter() { ParameterName = "LANG_ID", Value = Convert.ToInt16(Program.LangID) });

            strSqlWhere += "and (a.STEP > @STEP0 and a.STEP < @STEP99 ) ";
            parameters.Add(new vPublic.DBParameter() { ParameterName = "STEP0", Value = Convert.ToInt16(Model.WcsTrk.TrkStep.Step0) });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "STEP99", Value = Convert.ToInt16(Model.WcsTrk.TrkStep.Step99) });

            strSqlWhere += "and a.OPN in ( @OPN101,@OPN201) ";  //入庫作業；出庫作業
            parameters.Add(new vPublic.DBParameter() { ParameterName = "OPN101", Value = Convert.ToInt16(Model.WcsTrk.TrkOPN.OPN101) });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "OPN201", Value = Convert.ToInt16(Model.WcsTrk.TrkOPN.OPN201) });

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

            if (SDate.HasValue)
            {
                strSqlWhere += " and a.CREATE_DATE >= @SDate ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "SDATE", Value = SDate.Value });
            }
            if (EDate.HasValue)
            {
                strSqlWhere += " and a.CREATE_DATE <= @EDate ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "EDate", Value = EDate.Value });
            }

            result = vPublic.GetDbData(string.Format(QuerySql, strSqlWhere), parameters);
            if (result.Successed)
                Data = GetDetails(result.ResultDt, AREA_NO, WH_NO);

            if (Data.Count > 0)
            {
                if (ASRS_ID.HasValue)
                    Data = Data.Where(o => o.ASRS_ID == ASRS_ID.Value).ToList();
            }

            return result;
        }

        /// <summary>
        /// 取WcsTrkLog Data
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<Model.WcsTrkLog> GetDataList(DataTable dt)
        {
            List<Model.WcsTrkLog> Result = new List<Model.WcsTrkLog>();

            Result = dt.AsEnumerable().Select(o => new Model.WcsTrkLog()
            {
                LOG_TIME = o.Field<DateTime?>("LOG_TIME"),
                AREA_NO = o.Field<string>("AREA_NO"),
                WH_NO = o.Field<string>("WH_NO"),
                ASRS_ID = (int)o.Field<decimal>("ASRS_ID"),
                USE_CRN_ID = Convert.ToInt16(o.Field<decimal>("USE_CRN_ID")),
                BIN_NO = o.Field<string>("BIN_NO"),
                SD = o.Field<string>("SD"),
                SHF_NO = o.Field<string>("SHF_NO"),
                SHF_SD = o.Field<string>("SHF_SD"),
                CREATE_BY = o.Field<string>("CREATE_NAME"),
                CREATE_DATE = o.Field<DateTime?>("CREATE_DATE"),
                STEP_TIME = o.Field<DateTime?>("STEP_TIME"),
                END_TIME = o.Field<DateTime?>("END_TIME"),
                START_TIME = o.Field<DateTime?>("START_TIME"),
                EMERGE = (Model.WcsTrk.TrkEmerge)Enum.ToObject(typeof(Model.WcsTrk.TrkEmerge), Convert.ToInt16(o.Field<decimal>("EMERGE"))),
                STEP = (Model.WcsTrk.TrkStep)Enum.ToObject(typeof(Model.WcsTrk.TrkStep), Convert.ToInt16(o.Field<decimal>("STEP"))),
                STEP_DESC = o.Field<string>("STEP_DESC"),
                OPN = (Model.WcsTrk.TrkOPN)Enum.ToObject(typeof(Model.WcsTrk.TrkOPN), Convert.ToInt16(o.Field<decimal>("OPN"))),
                OPN_DESC = o.Field<string>("OPN_DESC"),
                STATUS = Convert.ToInt16(o.Field<decimal>("STATUS")),
                STATUS_DESC = o.Field<string>("STATUS_DESC"),
                TRANS_DEV_NO = o.Field<string>("TRANS_DEV_NO"),
                DEV_NO = o.Field<string>("DEV_NO"),
                NEXT_DEV_NO = o.Field<string>("NEXT_DEV_NO"),
                CUR_DEV_NO = o.Field<string>("CUR_DEV_NO"),
                PALLET_NO = o.Field<string>("PALLET_NO"),
                IO = o.Field<string>("IO"),
                SER_NO = Convert.ToInt16(o.Field<decimal>("SER_NO")),
                Details = GetDetails(dt, (int)o.Field<decimal>("ASRS_ID"), o.Field<string>("AREA_NO"), o.Field<string>("WH_NO"), (int)o.Field<decimal>("SER_NO"), o.Field<DateTime>("CREATE_DATE"))
            }).ToList();

            return Result;
        }

        private List<Model.WcsTrkLog.WcsTrkDetLog> GetDetails(DataTable data, int ASRS_ID, string AREA_NO, string WH_NO, int SER_NO, DateTime CREATE_DATE)
        {
            return data.AsEnumerable()
                .Where(o => o.Field<string>("AREA_NO") == AREA_NO &&
                    o.Field<string>("WH_NO") == WH_NO &&
                    (int)o.Field<decimal>("ASRS_ID") == ASRS_ID &&
                    (int)o.Field<decimal>("SER_NO") == SER_NO &&
                    o.Field<DateTime>("CREATE_DATE") == CREATE_DATE)
                .Select(o => new Model.WcsTrkLog.WcsTrkDetLog()
                {
                    STEP = (Model.WcsTrk.TrkStep)Enum.ToObject(typeof(Model.WcsTrk.TrkStep), Convert.ToInt16(o.Field<decimal>("STEP"))),
                    STEP_DESC = o.Field<string>("STEP_DESC"),
                    OPN_DESC = o.Field<string>("OPN_DESC"),
                    TRK_COUNT = (int)(o.Field<decimal?>("TRK_COUNT")??0),
                    BIN_NO = o.Field<string>("BIN_NO"),
                    PROD_NO = o.Field<string>("PROD_NO"),
                    PROD_NAME = o.Field<string>("PROD_NAME"),
                    ORG_NO = o.Field<string>("ORG_NO"),
                    ORG_SNAME = o.Field<string>("ORG_SNAME"),
                    QTY = (o.Field<decimal?>("QTY")??0),
                    OUT_QTY = (o.Field<decimal?>("OUT_QTY")??0),
                    LIST_NO = o.Field<string>("LIST_NO"),
                    LOT_NO = o.Field<string>("LOT_NO"),
                    LINE_ID = (int)(o.Field<decimal?>("LINE_ID")??0),
                    REMARK = o.Field<string>("REMARK"),
                    UN = o.Field<string>("UN"),
                    PRODUCTION_DATE = o.Field<DateTime?>("PRODUCTION_DATE"),
                    STOREIN_DATE = o.Field<DateTime?>("STOREIN_DATE"),
                    QC_RESULT_DESC = GetQcResultDesc((Model.WmsStk.QCResult)Enum.ToObject(typeof(Model.WmsStk.QCResult), Convert.ToInt16(o.Field<decimal?>("QC_RESULT"))))
                }).ToList();
        }

        private List<Model.WcsTrkLog.WcsTrkDetLog> GetDetails(DataTable data, string AREA_NO, string WH_NO)
        {
            return data.AsEnumerable()
                .Where(o => o.Field<string>("AREA_NO") == AREA_NO &&
                    o.Field<string>("WH_NO") == WH_NO)
                .Select(o => new Model.WcsTrkLog.WcsTrkDetLog()
                {
                    LOG_TIME = o.Field<DateTime>("LOG_TIME"),
                    STEP = (Model.WcsTrk.TrkStep)Enum.ToObject(typeof(Model.WcsTrk.TrkStep), Convert.ToInt16(o.Field<decimal>("STEP"))),
                    STEP_DESC = o.Field<string>("STEP_DESC"),
                    OPN_DESC = o.Field<string>("OPN_DESC"),
                    AREA_NO = o.Field<string>("AREA_NO"),
                    WH_NO = o.Field<string>("WH_NO"),
                    ASRS_ID = (int)(o.Field<decimal?>("ASRS_ID") ?? 1),
                    TRK_COUNT = (int)(o.Field<decimal?>("TRK_COUNT") ?? 0),
                    BIN_NO = o.Field<string>("BIN_NO"),
                    PROD_NO = o.Field<string>("PROD_NO"),
                    PROD_NAME = o.Field<string>("PROD_NAME"),
                    ORG_NO = o.Field<string>("ORG_NO"),
                    ORG_SNAME = o.Field<string>("ORG_SNAME"),
                    QTY = (o.Field<decimal?>("QTY") ?? 0),
                    OUT_QTY = (o.Field<decimal?>("OUT_QTY") ?? 0),
                    LIST_NO = o.Field<string>("LIST_NO"),
                    LOT_NO = o.Field<string>("LOT_NO"),
                    LINE_ID = (int)(o.Field<decimal?>("LINE_ID") ?? 0),
                    REMARK = o.Field<string>("REMARK"),
                    UN = o.Field<string>("UN"),
                    PRODUCTION_DATE = o.Field<DateTime?>("PRODUCTION_DATE"),
                    STOREIN_DATE = o.Field<DateTime?>("STOREIN_DATE"),
                    CREATE_BY = o.Field<string>("CREATE_BY"),
                    QC_RESULT_DESC = GetQcResultDesc((Model.WmsStk.QCResult)Enum.ToObject(typeof(Model.WmsStk.QCResult), Convert.ToInt16(o.Field<decimal?>("QC_RESULT"))))
                }).ToList();
        }

        public string GetQcResultDesc(Model.WmsStk.QCResult value)
        {
            string result = string.Empty;

            switch (value)
            {
                case WMS.Model.WmsStk.QCResult.未檢:
                    result = RM.GetString("QC0");
                    break;
                case WMS.Model.WmsStk.QCResult.合格:
                    result = RM.GetString("QC1");
                    break;
                case WMS.Model.WmsStk.QCResult.不合格:
                    result = RM.GetString("QC2");
                    break;
                case WMS.Model.WmsStk.QCResult.良品:
                    result = RM.GetString("QC3");
                    break;
                case WMS.Model.WmsStk.QCResult.劣品:
                    result = RM.GetString("QC4");
                    break;
                case WMS.Model.WmsStk.QCResult.待退:
                    result = RM.GetString("QC5");
                    break;
                default:
                    result = value.ToString();
                    break;
            }

            return result;
        }
    }
}
