using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Data.SqlClient;

namespace WMS.Service
{
    public class WmsListService
    {
        static System.Resources.ResourceManager RMPublic = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}Resource_Public", ""), System.Reflection.Assembly.GetExecutingAssembly());
        string QueryOutLineSql = "select a.* " +
                       "       , case when a.STATUS_CTR = 0 then @StatusCtr0 " +
                       "              when a.STATUS_CTR = 8 then @StatusCtr8 " +
                       "              when a.STATUS_CTR = 33 then @StatusCtr33 " +
                       "              when a.STATUS_CTR = 90 then @StatusCtr90 " +
                       "              when a.STATUS_CTR = 98 then @StatusCtr98 " +
                       "              when a.STATUS_CTR = 99 then @StatusCtr99 " +
                       "              else convert(varchar, a.STATUS_CTR) end STATUS_CTR_DESC " +
                       "       ,isnull(b.USER_NAME, a.CREATE_BY) as CREATE_NAME " +
                       "       ,isnull(c.USER_NAME, a.UPDATE_BY) as UPDATE_NAME " +
                       "       ,isnull(d.PROD_NAME,a.PROD_NO) as PROD_NAME " +
                       "       ,isnull(e.SNAME,a.ORG_NO) as SNAME " +
                       "       ,isnull(convert(varchar,a.PRODUCTION_DATE,111),'') PDATE " +
                       "       ,OutList.LIST_CTR, OutList.ERP_LIST_NO, OutList.ERP_LIST_TYPE " +
                       "from WMS_OUT_LINE a " +
                       "left join WMS_OUT_LIST OutList on a.LIST_NO = OutList.LIST_NO " +
                       "left join HRS_USER b on a.CREATE_BY = b.USER_NO " +
                       "left join HRS_USER c on a.UPDATE_BY = c.USER_NO " +
                       "left join WMS_PROD d on a.PROD_NO = d.PROD_NO " +
                       "left join WMS_ORG e on a.ORG_NO = e.ORG_NO " +
                       "where 1 = 1 {0} " +
                       "order by a.LIST_NO, a.LINE_ID ";

        string QueryInLineSql = "select a.* " +
               "       , case when a.STATUS_CTR = 0 then @StatusCtr0 " +
               "              when a.STATUS_CTR = 8 then @StatusCtr8 " +
               "              when a.STATUS_CTR = 33 then @StatusCtr33 " +
               "              when a.STATUS_CTR = 90 then @StatusCtr90 " +
               "              when a.STATUS_CTR = 98 then @StatusCtr98 " +
               "              when a.STATUS_CTR = 99 then @StatusCtr99 " +
               "              else convert(varchar, a.STATUS_CTR) end STATUS_CTR_DESC " +
               "       ,isnull(b.USER_NAME, a.CREATE_BY) as CREATE_NAME " +
               "       ,isnull(c.USER_NAME, a.UPDATE_BY) as UPDATE_NAME " +
               "       ,isnull(d.PROD_NAME,a.PROD_NO) as PROD_NAME " +
               "       ,isnull(e.SNAME,a.ORG_NO) as SNAME " +
               "       ,isnull(convert(varchar,a.PRODUCTION_DATE,111),'') PDATE " +
               "       ,InList.LIST_CTR, InList.ERP_LIST_NO, InList.ERP_LIST_TYPE " +
               "from WMS_IN_LINE a " +
               "left join WMS_IN_LIST InList on a.LIST_NO = InList.LIST_NO " +
               "left join HRS_USER b on a.CREATE_BY = b.USER_NO " +
               "left join HRS_USER c on a.UPDATE_BY = c.USER_NO " +
               "left join WMS_PROD d on a.PROD_NO = d.PROD_NO " +
               "left join WMS_ORG e on a.ORG_NO = e.ORG_NO " +
               "where 1 = 1 {0} " +
               "order by a.LIST_NO, a.LINE_ID ";

        /// <summary>
        /// 產生單號
        /// </summary>
        /// <param name="IOType"></param>
        /// <returns></returns>
        public string GenListNo(string IOType)
        {
            string Header = string.Empty;
            string Body = string.Empty;
            int SerNo = 0;
            Random rdm = new Random();
            Header = string.Format("L{0}", IOType);
            Body = DateTime.Now.ToString("yyyyMMddHHmmss");
            SerNo = rdm.Next(9999);

            return string.Format("{0}{1}{2:0000}", Header, Body, SerNo);
        }

        /// <summary>
        /// 取得所有出庫單(單頭)
        /// </summary>
        /// <param name="SDate">起始日期</param>
        /// <param name="EDate">結束日期</param>
        /// <param name="_StatusCtr">單據狀態</param>
        /// <param name="Data">返回的資料集</param>
        /// <returns></returns>
        public vPublic.DBExecResult GetAllWmsOutList(DateTime? SDate, DateTime? EDate, vPublic.StatusCtr? _StatusCtr, ref List<Model.WmsOutList> Data)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true };
            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>();
            string strSqlWhere = string.Empty;
            string QuerySql = string.Empty;

            QuerySql = "select a.* "+
                       "       , case when a.STATUS_CTR = 0 then @StatusCtr0 " +
                       "              when a.STATUS_CTR = 8 then @StatusCtr8 " +
                       "              when a.STATUS_CTR = 33 then @StatusCtr33 " +
                       "              when a.STATUS_CTR = 90 then @StatusCtr90 " +
                       "              when a.STATUS_CTR = 98 then @StatusCtr98 " +
                       "              when a.STATUS_CTR = 99 then @StatusCtr99 " +
                       "              else convert(varchar, a.STATUS_CTR) end STATUS_CTR_DESC " +
                       "       , case when a.LIST_CTR = 1 then @ListCtr1 " +
                       "              when a.LIST_CTR = 2 then @ListCtr2 " +
                       "              else convert(varchar, a.LIST_CTR) end LIST_CTR_DESC " +
                       "       ,isnull(b.USER_NAME, a.CREATE_BY) as CREATE_NAME " +
                       "       ,isnull(c.USER_NAME, a.UPDATE_BY) as UPDATE_NAME " +
                       "from WMS_OUT_LIST a "+
                       "left join HRS_USER b on a.CREATE_BY = b.USER_NO "+
                       "left join HRS_USER c on a.UPDATE_BY = c.USER_NO " +
                       "where 1 = 1 "+
                       "order by a.LIST_NO ";

            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr0", Value = RMPublic.GetString("StatusCtr0") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr8", Value = RMPublic.GetString("StatusCtr8") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr33", Value = RMPublic.GetString("StatusCtr33") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr90", Value = RMPublic.GetString("StatusCtr90") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr98", Value = RMPublic.GetString("StatusCtr98") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr99", Value = RMPublic.GetString("StatusCtr99") });

            parameters.Add(new vPublic.DBParameter() { ParameterName = "ListCtr1", Value = RMPublic.GetString("ListCtr1") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "ListCtr2", Value = RMPublic.GetString("ListCtr2") });

            if (SDate.HasValue)
            {
                strSqlWhere += " and a.LIST_DATE >= @SDATE ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "SDATE", Value = SDate.Value.ToString("yyyy/MM/dd 00:00:00") });
            }

            if (EDate.HasValue)
            {
                strSqlWhere += " and a.LIST_DATE <= @EDATE ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "EDATE", Value = EDate.Value.ToString("yyyy/MM/dd 23:59:59") });
            }

            if (_StatusCtr.HasValue)
            {
                strSqlWhere += " and a.STATUS_CTR = @STATUS_CTR ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "STATUS_CTR", Value = _StatusCtr.Value });
            }

            result = vPublic.GetDbData(string.Format(QuerySql, strSqlWhere), parameters);
            if (result.Successed)
                Data = GetOutListData(result.ResultDt);

            return result;
        }

        /// <summary>
        /// 取得所有出庫單(單身)
        /// </summary>
        /// <param name="SDate">起始日期</param>
        /// <param name="EDate">結束日期</param>
        /// <param name="_StatusCtr">單據狀態</param>
        /// <param name="Data">返回的資料集</param>
        /// <returns></returns>
        public vPublic.DBExecResult GetAllWmsOutLine(DateTime? SDate, DateTime? EDate, vPublic.StatusCtr? _StatusCtr, ref List<Model.WmsOutLine> Data)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true };
            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>();
            string strSqlWhere = string.Empty;
            string QuerySql = string.Empty;

            QuerySql = QueryOutLineSql;

            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr0", Value = RMPublic.GetString("StatusCtr0") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr8", Value = RMPublic.GetString("StatusCtr8") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr33", Value = RMPublic.GetString("StatusCtr33") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr90", Value = RMPublic.GetString("StatusCtr90") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr98", Value = RMPublic.GetString("StatusCtr98") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr99", Value = RMPublic.GetString("StatusCtr99") });

            if (SDate.HasValue)
            {
                strSqlWhere += " and a.CREATE_DATE >= @SDATE ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "SDATE", Value = SDate.Value.ToString("yyyy/MM/dd 00:00:00") });
            }

            if (EDate.HasValue)
            {
                strSqlWhere += " and a.CREATE_DATE <= @EDATE ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "EDATE", Value = EDate.Value.ToString("yyyy/MM/dd 23:59:59") });
            }

            if (_StatusCtr.HasValue)
            {
                strSqlWhere += " and a.STATUS_CTR = @STATUS_CTR ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "STATUS_CTR", Value = _StatusCtr.Value });
            }

            result = vPublic.GetDbData(string.Format(QuerySql, strSqlWhere), parameters);
            if (result.Successed)
                Data = GetOutLineData(result.ResultDt);

            return result;
        }

        /// <summary>
        /// 取得所有入庫單(單身)
        /// </summary>
        /// <param name="SDate">起始日期</param>
        /// <param name="EDate">結束日期</param>
        /// <param name="_StatusCtr">單據狀態</param>
        /// <param name="Data">返回的資料集</param>
        /// <returns></returns>
        public vPublic.DBExecResult GetAllWmsInLine(DateTime? SDate, DateTime? EDate, vPublic.StatusCtr? _StatusCtr, ref List<Model.WmsInLine> Data)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true };
            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>();
            string strSqlWhere = string.Empty;
            string QuerySql = string.Empty;

            QuerySql = QueryInLineSql;

            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr0", Value = RMPublic.GetString("StatusCtr0") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr8", Value = RMPublic.GetString("StatusCtr8") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr33", Value = RMPublic.GetString("StatusCtr33") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr90", Value = RMPublic.GetString("StatusCtr90") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr98", Value = RMPublic.GetString("StatusCtr98") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr99", Value = RMPublic.GetString("StatusCtr99") });

            if (SDate.HasValue)
            {
                strSqlWhere += " and a.CREATE_DATE >= @SDATE ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "SDATE", Value = SDate.Value.ToString("yyyy/MM/dd 00:00:00") });
            }

            if (EDate.HasValue)
            {
                strSqlWhere += " and a.CREATE_DATE <= @EDATE ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "EDATE", Value = EDate.Value.ToString("yyyy/MM/dd 23:59:59") });
            }

            if (_StatusCtr.HasValue)
            {
                strSqlWhere += " and a.STATUS_CTR = @STATUS_CTR ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "STATUS_CTR", Value = _StatusCtr.Value });
            }

            result = vPublic.GetDbData(string.Format(QuerySql, strSqlWhere), parameters);
            if (result.Successed)
                Data = GetInLineData(result.ResultDt);

            return result;
        }

        /// <summary>
        /// 取得可以出庫的單身資料
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public vPublic.DBExecResult GetAvailableWmsOutLine(ref List<Model.WmsOutLine> Data)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true };
            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>();
            string strSqlWhere = string.Empty;
            string QuerySql = string.Empty;

            QuerySql = QueryOutLineSql;

            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr0", Value = RMPublic.GetString("StatusCtr0") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr8", Value = RMPublic.GetString("StatusCtr8") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr33", Value = RMPublic.GetString("StatusCtr33") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr90", Value = RMPublic.GetString("StatusCtr90") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr98", Value = RMPublic.GetString("StatusCtr98") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr99", Value = RMPublic.GetString("StatusCtr99") });
            
            strSqlWhere += " and a.STATUS_CTR in (@STATUS_CTR0, @STATUS_CTR33) ";
            parameters.Add(new vPublic.DBParameter() { ParameterName = "STATUS_CTR0", Value = vPublic.StatusCtr.接單 });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "STATUS_CTR33", Value = vPublic.StatusCtr.出庫中 });

            //不超領
            strSqlWhere += " and a.QTY - (a.WMS_QTY + a.TMP_QTY) > 0 ";

            result = vPublic.GetDbData(string.Format(QuerySql, strSqlWhere), parameters);
            if (result.Successed)
                Data = GetOutLineData(result.ResultDt);

            return result;
        }

        /// <summary>
        /// 取得可以入庫的單身資料
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public vPublic.DBExecResult GetAvailableWmsInLine(ref List<Model.WmsInLine> Data)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true };
            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>();
            string strSqlWhere = string.Empty;
            string QuerySql = string.Empty;

            QuerySql = QueryInLineSql;

            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr0", Value = RMPublic.GetString("StatusCtr0") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr8", Value = RMPublic.GetString("StatusCtr8") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr33", Value = RMPublic.GetString("StatusCtr33") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr90", Value = RMPublic.GetString("StatusCtr90") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr98", Value = RMPublic.GetString("StatusCtr98") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr99", Value = RMPublic.GetString("StatusCtr99") });

            strSqlWhere += " and a.STATUS_CTR in (@STATUS_CTR0, @STATUS_CTR8) ";
            parameters.Add(new vPublic.DBParameter() { ParameterName = "STATUS_CTR0", Value = vPublic.StatusCtr.接單 });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "STATUS_CTR8", Value = vPublic.StatusCtr.收料中 });

            //不超入
            strSqlWhere += " and a.QTY - (a.WMS_QTY + a.TMP_QTY) > 0 ";

            result = vPublic.GetDbData(string.Format(QuerySql, strSqlWhere), parameters);
            if (result.Successed)
                Data = GetInLineData(result.ResultDt);

            return result;
        }

        /// <summary>
        /// 取得出庫單身資料 by 單號+項次
        /// </summary>
        /// <param name="LIST_NO"></param>
        /// <param name="LINE_ID"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public vPublic.DBExecResult GetWmsOutLineByListNoAndID(string LIST_NO, int? LINE_ID, ref List<Model.WmsOutLine> Data)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true };
            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>();
            string strSqlWhere = string.Empty;
            string QuerySql = string.Empty;

            QuerySql = QueryOutLineSql;

            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr0", Value = RMPublic.GetString("StatusCtr0") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr8", Value = RMPublic.GetString("StatusCtr8") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr33", Value = RMPublic.GetString("StatusCtr33") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr90", Value = RMPublic.GetString("StatusCtr90") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr98", Value = RMPublic.GetString("StatusCtr98") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr99", Value = RMPublic.GetString("StatusCtr99") });

            if (!string.IsNullOrEmpty(LIST_NO))
            {
                strSqlWhere += " and a.LIST_NO = @LIST_NO ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "LIST_NO", Value = LIST_NO });
            }

            if (LINE_ID.HasValue)
            {
                strSqlWhere += " and a.LINE_ID = @LINE_ID ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "LINE_ID", Value = LINE_ID.Value });
            }


            result = vPublic.GetDbData(string.Format(QuerySql, strSqlWhere), parameters);
            if (result.Successed)
                Data = GetOutLineData(result.ResultDt);

            return result;
        }

        /// <summary>
        /// 取得入庫單身資料 by 單號+項次
        /// </summary>
        /// <param name="LIST_NO"></param>
        /// <param name="LINE_ID"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public vPublic.DBExecResult GetWmsInLineByListNoAndID(string LIST_NO, int? LINE_ID, ref List<Model.WmsInLine> Data)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true };
            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>();
            string strSqlWhere = string.Empty;
            string QuerySql = string.Empty;

            QuerySql = QueryInLineSql;

            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr0", Value = RMPublic.GetString("StatusCtr0") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr8", Value = RMPublic.GetString("StatusCtr8") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr33", Value = RMPublic.GetString("StatusCtr33") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr90", Value = RMPublic.GetString("StatusCtr90") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr98", Value = RMPublic.GetString("StatusCtr98") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr99", Value = RMPublic.GetString("StatusCtr99") });

            if (!string.IsNullOrEmpty(LIST_NO))
            {
                strSqlWhere += " and a.LIST_NO = @LIST_NO ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "LIST_NO", Value = LIST_NO });
            }

            if (LINE_ID.HasValue)
            {
                strSqlWhere += " and a.LINE_ID = @LINE_ID ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "LINE_ID", Value = LINE_ID.Value });
            }


            result = vPublic.GetDbData(string.Format(QuerySql, strSqlWhere), parameters);
            if (result.Successed)
                Data = GetInLineData(result.ResultDt);

            return result;
        }

        /// <summary>
        /// 取得出庫單(單身) BY單號
        /// </summary>
        /// <param name="LIST_NO">單號</param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public vPublic.DBExecResult GetWmsOutLineByListNo(string LIST_NO, ref List<Model.WmsOutLine> Data)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true };
            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>();
            string strSqlWhere = string.Empty;
            string QuerySql = string.Empty;

            QuerySql = "select a.* " +
                       "       , case when a.STATUS_CTR = 0 then @StatusCtr0 " +
                       "              when a.STATUS_CTR = 8 then @StatusCtr8 " +
                       "              when a.STATUS_CTR = 33 then @StatusCtr33 " +
                       "              when a.STATUS_CTR = 90 then @StatusCtr90 " +
                       "              when a.STATUS_CTR = 98 then @StatusCtr98 " +
                       "              when a.STATUS_CTR = 99 then @StatusCtr99 " +
                       "              else convert(varchar, a.STATUS_CTR) end STATUS_CTR_DESC " +
                       "       ,isnull(b.USER_NAME, a.CREATE_BY) as CREATE_NAME " +
                       "       ,isnull(c.USER_NAME, a.UPDATE_BY) as UPDATE_NAME " +
                       "       ,isnull(d.PROD_NAME,a.PROD_NO) as PROD_NAME " +
                       "       ,isnull(e.SNAME,a.ORG_NO) as SNAME " +
                       "       ,isnull(convert(varchar,a.PRODUCTION_DATE,111),'') PDATE " +
                       "       ,OutList.LIST_CTR, OutList.ERP_LIST_NO, OutList.ERP_LIST_TYPE " +
                       "from WMS_OUT_LINE a " +
                       "left join WMS_OUT_LIST OutList on a.LIST_NO = OutList.LIST_NO " +
                       "left join HRS_USER b on a.CREATE_BY = b.USER_NO " +
                       "left join HRS_USER c on a.UPDATE_BY = c.USER_NO " +
                       "left join WMS_PROD d on a.PROD_NO = d.PROD_NO " +
                       "left join WMS_ORG e on a.ORG_NO = e.ORG_NO " +
                       "where 1 = 1 {0} " +
                       "order by a.LIST_NO, a.LINE_ID ";

            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr0", Value = RMPublic.GetString("StatusCtr0") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr8", Value = RMPublic.GetString("StatusCtr8") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr33", Value = RMPublic.GetString("StatusCtr33") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr90", Value = RMPublic.GetString("StatusCtr90") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr98", Value = RMPublic.GetString("StatusCtr98") });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "StatusCtr99", Value = RMPublic.GetString("StatusCtr99") });

            if(!string.IsNullOrEmpty(LIST_NO))
            {
                strSqlWhere += " and a.LIST_NO = @LIST_NO ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "LIST_NO", Value = LIST_NO });
            }

            result = vPublic.GetDbData(string.Format(QuerySql, strSqlWhere), parameters);
            if (result.Successed)
                Data = GetOutLineData(result.ResultDt);

            return result;
        }

        /// <summary>
        /// 取OutListData
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<Model.WmsOutList> GetOutListData(DataTable dt)
        {
            List<Model.WmsOutList> OutLists = new List<Model.WmsOutList>();

            OutLists = dt.AsEnumerable().Select(o => new Model.WmsOutList()
            {
                LIST_NO = o.Field<string>("LIST_NO"),
                LIST_DATE = o.Field<DateTime>("LIST_DATE"),
                STATUS_CTR = (vPublic.StatusCtr)Enum.ToObject(typeof(vPublic.StatusCtr), Convert.ToInt16(o.Field<decimal>("STATUS_CTR"))),
                STATUS_CTR_DESC = o.Field<string>("STATUS_CTR_DESC"),
                LIST_CTR = (vPublic.ListCtr)Enum.ToObject(typeof(vPublic.ListCtr), Convert.ToInt16(o.Field<decimal>("LIST_CTR"))),
                LIST_CTR_DESC = o.Field<string>("LIST_CTR_DESC"),
                ERP_LIST_NO = o.Field<string>("ERP_LIST_NO"),
                ERP_LIST_TYPE = o.Field<string>("ERP_LIST_TYPE"),
                REMARK = o.Field<string>("REMARK"),
                CREATE_BY = o.Field<string>("CREATE_BY"),
                CREATE_NAME = o.Field<string>("CREATE_NAME"),
                CREATE_DATE = o.Field<DateTime>("CREATE_DATE"),
                UPDATE_BY = o.Field<string>("UPDATE_BY"),
                UPDATE_NAME = o.Field<string>("UPDATE_NAME"),
                UPDATE_DATE = o.Field<DateTime>("UPDATE_DATE")
            }).ToList();

            return OutLists;
        }

        /// <summary>
        /// 取OutLineData
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<Model.WmsOutLine> GetOutLineData(DataTable dt)
        {
            List<Model.WmsOutLine> OutLines = new List<Model.WmsOutLine>();

            OutLines = dt.AsEnumerable().Select(o => new Model.WmsOutLine()
            {
                LIST_NO = o.Field<string>("LIST_NO"),
                LINE_ID = Convert.ToInt16(o.Field<decimal>("LINE_ID")),
                ERP_LIST_TYPE = o.Field<string>("ERP_LIST_TYPE"),
                ERP_LIST_NO = o.Field<string>("ERP_LIST_NO"),
                ERP_LINE_ID = o.Field<string>("ERP_LINE_ID"),
                LIST_CTR = (vPublic.ListCtr)Enum.ToObject(typeof(vPublic.ListCtr), Convert.ToInt16(o.Field<decimal>("LIST_CTR"))),
                STATUS_CTR = (vPublic.StatusCtr)Enum.ToObject(typeof(vPublic.StatusCtr), Convert.ToInt16(o.Field<decimal>("STATUS_CTR"))),
                STATUS_CTR_DESC = o.Field<string>("STATUS_CTR_DESC"),
                ORG_NO = o.Field<string>("ORG_NO"),
                SNAME = o.Field<string>("SNAME"),
                QTY = o.Field<decimal>("QTY"),
                WMS_QTY = o.Field<decimal>("WMS_QTY"),
                TMP_QTY = o.Field<decimal>("TMP_QTY"),
                PROD_NO = o.Field<string>("PROD_NO"),
                PROD_NAME = o.Field<string>("PROD_NAME"),
                UN = o.Field<string>("UN"),
                LOT_NO = o.Field<string>("LOT_NO"),
                PRODUCTION_DATE = o.Field<DateTime?>("PRODUCTION_DATE"),
                PDATE = o.Field<string>("PDATE"),
                REMARK = o.Field<string>("REMARK"),
                CREATE_BY = o.Field<string>("CREATE_BY"),
                CREATE_NAME = o.Field<string>("CREATE_NAME"),
                CREATE_DATE = o.Field<DateTime>("CREATE_DATE"),
                UPDATE_BY = o.Field<string>("UPDATE_BY"),
                UPDATE_NAME = o.Field<string>("UPDATE_NAME"),
                UPDATE_DATE = o.Field<DateTime>("UPDATE_DATE"),
                CHK = false,
                OUT_QTY = o.Field<decimal>("QTY") - (o.Field<decimal>("TMP_QTY") + o.Field<decimal>("WMS_QTY")),
                STK_QTY = GetStkQty(o.Field<string>("PROD_NO"), o.Field<string>("LOT_NO"), o.Field<DateTime?>("PRODUCTION_DATE"), o.Field<string>("ORG_NO"))
            }).ToList();

            return OutLines;
        }

        /// <summary>
        /// 取InLineData
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<Model.WmsInLine> GetInLineData(DataTable dt)
        {
            List<Model.WmsInLine> InLines = new List<Model.WmsInLine>();

            InLines = dt.AsEnumerable().Select(o => new Model.WmsInLine()
            {
                LIST_NO = o.Field<string>("LIST_NO"),
                LINE_ID = Convert.ToInt16(o.Field<decimal>("LINE_ID")),
                ERP_LIST_TYPE = o.Field<string>("ERP_LIST_TYPE"),
                ERP_LIST_NO = o.Field<string>("ERP_LIST_NO"),
                ERP_LINE_ID = o.Field<string>("ERP_LINE_ID"),
                LIST_CTR = (vPublic.ListCtr)Enum.ToObject(typeof(vPublic.ListCtr), Convert.ToInt16(o.Field<decimal>("LIST_CTR"))),
                STATUS_CTR = (vPublic.StatusCtr)Enum.ToObject(typeof(vPublic.StatusCtr), Convert.ToInt16(o.Field<decimal>("STATUS_CTR"))),
                STATUS_CTR_DESC = o.Field<string>("STATUS_CTR_DESC"),
                ORG_NO = o.Field<string>("ORG_NO"),
                SNAME = o.Field<string>("SNAME"),
                QTY = o.Field<decimal>("QTY"),
                WMS_QTY = o.Field<decimal>("WMS_QTY"),
                TMP_QTY = o.Field<decimal>("TMP_QTY"),
                PROD_NO = o.Field<string>("PROD_NO"),
                PROD_NAME = o.Field<string>("PROD_NAME"),
                UN = o.Field<string>("UN"),
                LOT_NO = o.Field<string>("LOT_NO"),
                PRODUCTION_DATE = o.Field<DateTime?>("PRODUCTION_DATE"),
                PDATE = o.Field<string>("PDATE"),
                REMARK = o.Field<string>("REMARK"),
                CREATE_BY = o.Field<string>("CREATE_BY"),
                CREATE_NAME = o.Field<string>("CREATE_NAME"),
                CREATE_DATE = o.Field<DateTime>("CREATE_DATE"),
                UPDATE_BY = o.Field<string>("UPDATE_BY"),
                UPDATE_NAME = o.Field<string>("UPDATE_NAME"),
                UPDATE_DATE = o.Field<DateTime>("UPDATE_DATE"),
                CHK = false,
                IN_QTY = o.Field<decimal>("QTY") - (o.Field<decimal>("TMP_QTY") + o.Field<decimal>("WMS_QTY")),
                AVAILABLE_QTY = o.Field<decimal>("QTY") - (o.Field<decimal>("TMP_QTY") + o.Field<decimal>("WMS_QTY"))
                
            }).ToList();

            return InLines;
        }

        /// <summary>
        /// 新增出庫單據資料
        /// </summary>
        /// <param name="InputData"></param>
        /// <returns></returns>
        public vPublic.DBExecResult CreateWmsOutListData(List<Model.WmsOutLine> InputData)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true };

            var WMS_OUT_LIST = InputData.GroupBy(o => new
            {
                o.LIST_NO,
                o.LIST_CTR,
                o.ERP_LIST_NO,
                o.ERP_LIST_TYPE
            })
            .Select(p => new Model.WmsOutList()
            {
                LIST_NO = p.Key.LIST_NO,
                ERP_LIST_TYPE = p.Key.ERP_LIST_TYPE,
                LIST_CTR = p.Key.LIST_CTR,
                ERP_LIST_NO = p.Key.ERP_LIST_NO,
                STATUS_CTR = vPublic.StatusCtr.接單,
                LIST_DATE = DateTime.Now,
                CREATE_BY = Program.wmsUser.UserNo,
                UPDATE_BY = Program.wmsUser.UserNo,
                CREATE_DATE = DateTime.Now,
                UPDATE_DATE = DateTime.Now
            }).First();

            foreach (var Item in InputData)
            {
                Item.CREATE_BY = WMS_OUT_LIST.CREATE_BY;
                Item.UPDATE_BY = WMS_OUT_LIST.UPDATE_BY;
                Item.CREATE_DATE = WMS_OUT_LIST.CREATE_DATE;
                Item.UPDATE_DATE = WMS_OUT_LIST.UPDATE_DATE;
            }

            WMS_OUT_LIST.Details = InputData;
            List<Model.WmsOutList> Lists = new List<WMS.Model.WmsOutList>();
            Lists.Add(WMS_OUT_LIST);

            return SubmitCreateWmsOutList(Lists);
        }

        /// <summary>
        /// 新增入庫單據資料
        /// </summary>
        /// <param name="InputData"></param>
        /// <returns></returns>
        public vPublic.DBExecResult CreateWmsInListData(List<Model.WmsInLine> InputData)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true };

            var WMS_IN_LIST = InputData.GroupBy(o => new
            {
                o.LIST_NO,
                o.LIST_CTR,
                o.ERP_LIST_NO,
                o.ERP_LIST_TYPE
            })
            .Select(p => new Model.WmsInList()
            {
                LIST_NO = p.Key.LIST_NO,
                ERP_LIST_TYPE = p.Key.ERP_LIST_TYPE,
                LIST_CTR = p.Key.LIST_CTR,
                ERP_LIST_NO = p.Key.ERP_LIST_NO,
                STATUS_CTR = vPublic.StatusCtr.接單,
                LIST_DATE = DateTime.Now,
                CREATE_BY = Program.wmsUser.UserNo,
                UPDATE_BY = Program.wmsUser.UserNo,
                CREATE_DATE = DateTime.Now,
                UPDATE_DATE = DateTime.Now
            }).First();

            foreach (var Item in InputData)
            {
                Item.CREATE_BY = WMS_IN_LIST.CREATE_BY;
                Item.UPDATE_BY = WMS_IN_LIST.UPDATE_BY;
                Item.CREATE_DATE = WMS_IN_LIST.CREATE_DATE;
                Item.UPDATE_DATE = WMS_IN_LIST.UPDATE_DATE;
            }

            WMS_IN_LIST.Details = InputData;
            List<Model.WmsInList> Lists = new List<WMS.Model.WmsInList>();
            Lists.Add(WMS_IN_LIST);

            return SubmitCreateWmsInList(Lists);
        }

        /// <summary>
        /// 產生出庫單據資料
        /// </summary>
        /// <returns></returns>
        private vPublic.DBExecResult SubmitCreateWmsOutList(List<Model.WmsOutList> Lists)
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
                        strSql = "insert into WMS_OUT_LIST ( LIST_NO, LIST_DATE, STATUS_CTR, LIST_CTR, ERP_LIST_NO, ERP_LIST_TYPE, REMARK, " + "\r\n" +
                                 "                           CREATE_DATE, CREATE_BY, UPDATE_DATE, UPDATE_BY ) " + "\r\n" +
                                 "                   values(@LIST_NO,@LIST_DATE,@STATUS_CTR,@LIST_CTR,@ERP_LIST_NO,@ERP_LIST_TYPE,@REMARK, " + "\r\n" +
                                 "                          @CREATE_DATE,@CREATE_BY,@UPDATE_DATE,@UPDATE_BY) ";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LIST_DATE", (object)Item.LIST_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STATUS_CTR", Convert.ToInt16(Item.STATUS_CTR));
                        Cmd.Parameters.AddWithValue("LIST_CTR", Convert.ToInt16(Item.LIST_CTR));
                        Cmd.Parameters.AddWithValue("ERP_LIST_NO", (object)Item.ERP_LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ERP_LIST_TYPE", (object)Item.ERP_LIST_TYPE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("REMARK", (object)Item.REMARK ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_DATE", (object)Item.CREATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_BY", (object)Item.CREATE_BY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_DATE", (object)Item.UPDATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_BY", (object)Item.UPDATE_BY ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();

                        foreach (var Detail in Item.Details)
                        {
                            strSql = "insert into WMS_OUT_LINE ( LIST_NO, LINE_ID, ERP_LINE_ID, STATUS_CTR, PROD_NO, LOT_NO, ORG_NO, QTY, WMS_QTY, TMP_QTY, " + "\r\n" +
                                     "                           MES_QTY, UN, PRODUCTION_DATE, REMARK, CREATE_DATE, CREATE_BY, UPDATE_DATE, UPDATE_BY ) " + "\r\n" +
                                     "                  values (@LIST_NO,@LINE_ID,@ERP_LINE_ID,@STATUS_CTR,@PROD_NO,@LOT_NO,@ORG_NO,@QTY,@WMS_QTY,@TMP_QTY, " + "\r\n" +
                                     "                          @MES_QTY,@UN,@PRODUCTION_DATE,@REMARK,@CREATE_DATE,@CREATE_BY,@UPDATE_DATE,@UPDATE_BY) ";

                            Cmd.CommandText = strSql;
                            Cmd.Parameters.Clear();

                            Cmd.Parameters.AddWithValue("LIST_NO", (object)Detail.LIST_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("LINE_ID", (object)Detail.LINE_ID ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("ERP_LINE_ID", (object)Detail.ERP_LINE_ID ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("STATUS_CTR", Convert.ToInt16(Detail.STATUS_CTR));
                            Cmd.Parameters.AddWithValue("PROD_NO", (object)Detail.PROD_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("LOT_NO", (object)Detail.LOT_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("ORG_NO", (object)Detail.ORG_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("QTY", (object)Detail.QTY ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("WMS_QTY", 0);
                            Cmd.Parameters.AddWithValue("TMP_QTY", 0);
                            Cmd.Parameters.AddWithValue("MES_QTY", 0);
                            Cmd.Parameters.AddWithValue("UN", (object)Detail.UN ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("PRODUCTION_DATE", (object)Detail.PRODUCTION_DATE ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("REMARK", (object)Detail.REMARK ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("CREATE_DATE", (object)Item.CREATE_DATE ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("CREATE_BY", (object)Item.CREATE_BY ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("UPDATE_DATE", (object)Item.UPDATE_DATE ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("UPDATE_BY", (object)Item.UPDATE_BY ?? DBNull.Value);
                            rtn = Cmd.ExecuteNonQuery();

                        }
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
                }
            }
            return result;
        }

        /// <summary>
        /// 產生入庫單據資料
        /// </summary>
        /// <returns></returns>
        private vPublic.DBExecResult SubmitCreateWmsInList(List<Model.WmsInList> Lists)
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
                        strSql = "insert into WMS_IN_LIST ( LIST_NO, LIST_DATE, STATUS_CTR, LIST_CTR, ERP_LIST_NO, ERP_LIST_TYPE, REMARK, " + "\r\n" +
                                 "                           CREATE_DATE, CREATE_BY, UPDATE_DATE, UPDATE_BY ) " + "\r\n" +
                                 "                   values(@LIST_NO,@LIST_DATE,@STATUS_CTR,@LIST_CTR,@ERP_LIST_NO,@ERP_LIST_TYPE,@REMARK, " + "\r\n" +
                                 "                          @CREATE_DATE,@CREATE_BY,@UPDATE_DATE,@UPDATE_BY) ";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LIST_DATE", (object)Item.LIST_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STATUS_CTR", Convert.ToInt16(Item.STATUS_CTR));
                        Cmd.Parameters.AddWithValue("LIST_CTR", Convert.ToInt16(Item.LIST_CTR));
                        Cmd.Parameters.AddWithValue("ERP_LIST_NO", (object)Item.ERP_LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ERP_LIST_TYPE", (object)Item.ERP_LIST_TYPE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("REMARK", (object)Item.REMARK ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_DATE", (object)Item.CREATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_BY", (object)Item.CREATE_BY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_DATE", (object)Item.UPDATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_BY", (object)Item.UPDATE_BY ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();

                        foreach (var Detail in Item.Details)
                        {
                            strSql = "insert into WMS_IN_LINE ( LIST_NO, LINE_ID, ERP_LINE_ID, STATUS_CTR, PROD_NO, LOT_NO, ORG_NO, QTY, WMS_QTY, TMP_QTY, " + "\r\n" +
                                     "                           MES_QTY, UN, PRODUCTION_DATE, REMARK, CREATE_DATE, CREATE_BY, UPDATE_DATE, UPDATE_BY ) " + "\r\n" +
                                     "                  values (@LIST_NO,@LINE_ID,@ERP_LINE_ID,@STATUS_CTR,@PROD_NO,@LOT_NO,@ORG_NO,@QTY,@WMS_QTY,@TMP_QTY, " + "\r\n" +
                                     "                          @MES_QTY,@UN,@PRODUCTION_DATE,@REMARK,@CREATE_DATE,@CREATE_BY,@UPDATE_DATE,@UPDATE_BY) ";

                            Cmd.CommandText = strSql;
                            Cmd.Parameters.Clear();

                            Cmd.Parameters.AddWithValue("LIST_NO", (object)Detail.LIST_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("LINE_ID", (object)Detail.LINE_ID ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("ERP_LINE_ID", (object)Detail.ERP_LINE_ID ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("STATUS_CTR", Convert.ToInt16(Detail.STATUS_CTR));
                            Cmd.Parameters.AddWithValue("PROD_NO", (object)Detail.PROD_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("LOT_NO", (object)Detail.LOT_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("ORG_NO", (object)Detail.ORG_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("QTY", (object)Detail.QTY ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("WMS_QTY", 0);
                            Cmd.Parameters.AddWithValue("TMP_QTY", 0);
                            Cmd.Parameters.AddWithValue("MES_QTY", 0);
                            Cmd.Parameters.AddWithValue("UN", (object)Detail.UN ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("PRODUCTION_DATE", (object)Detail.PRODUCTION_DATE ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("REMARK", (object)Detail.REMARK ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("CREATE_DATE", (object)Item.CREATE_DATE ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("CREATE_BY", (object)Item.CREATE_BY ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("UPDATE_DATE", (object)Item.UPDATE_DATE ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("UPDATE_BY", (object)Item.UPDATE_BY ?? DBNull.Value);
                            rtn = Cmd.ExecuteNonQuery();

                        }
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
                }
            }
            return result;
        }

        /// <summary>
        /// 刪除出庫單據資料
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult DeleteWmsOutList(List<Model.WmsOutLine> Lists)
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
                        strSql = "delete WMS_OUT_LINE where LIST_NO = @LIST_NO and LINE_ID = @LINE_ID ";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LINE_ID", (object)Item.LINE_ID ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();

                        strSql = "delete WMS_OUT_LIST where not exists (select b.LIST_NO from WMS_OUT_LINE b where WMS_OUT_LIST.LIST_NO = b.LIST_NO ) ";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        rtn = Cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
                }
            }
            return result;
        }

        /// <summary>
        /// 刪除入庫單據資料
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult DeleteWmsInList(List<Model.WmsInLine> Lists)
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
                        strSql = "delete WMS_IN_LINE where LIST_NO = @LIST_NO and LINE_ID = @LINE_ID ";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LINE_ID", (object)Item.LINE_ID ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();

                        strSql = "delete WMS_IN_LIST where not exists (select b.LIST_NO from WMS_IN_LINE b where WMS_IN_LIST.LIST_NO = b.LIST_NO ) ";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        rtn = Cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
                }
            }
            return result;
        }

        /// <summary>
        /// 編輯出庫單據資料
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult EditWmsOutList(List<Model.WmsOutLine> Lists)
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
                        strSql = "delete WMS_OUT_LINE where LIST_NO = @LIST_NO and LINE_ID = @LINE_ID ";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LINE_ID", (object)Item.LINE_ID ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();

                        strSql = "insert into WMS_OUT_LINE ( LIST_NO, LINE_ID, ERP_LINE_ID, STATUS_CTR, PROD_NO, LOT_NO, ORG_NO, QTY, WMS_QTY, TMP_QTY, " + "\r\n" +
                                 "                           MES_QTY, UN, PRODUCTION_DATE, REMARK, CREATE_DATE, CREATE_BY, UPDATE_DATE, UPDATE_BY ) " + "\r\n" +
                                 "                  values (@LIST_NO,@LINE_ID,@ERP_LINE_ID,@STATUS_CTR,@PROD_NO,@LOT_NO,@ORG_NO,@QTY,@WMS_QTY,@TMP_QTY, " + "\r\n" +
                                 "                          @MES_QTY,@UN,@PRODUCTION_DATE,@REMARK,@CREATE_DATE,@CREATE_BY,@UPDATE_DATE,@UPDATE_BY) ";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LINE_ID", (object)Item.LINE_ID ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ERP_LINE_ID", (object)Item.ERP_LINE_ID ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STATUS_CTR", Convert.ToInt16(Item.STATUS_CTR));
                        Cmd.Parameters.AddWithValue("PROD_NO", (object)Item.PROD_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LOT_NO", (object)Item.LOT_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ORG_NO", (object)Item.ORG_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("QTY", (object)Item.QTY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("WMS_QTY", 0);
                        Cmd.Parameters.AddWithValue("TMP_QTY", 0);
                        Cmd.Parameters.AddWithValue("MES_QTY", 0);
                        Cmd.Parameters.AddWithValue("UN", (object)Item.UN ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PRODUCTION_DATE", (object)Item.PRODUCTION_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("REMARK", (object)Item.REMARK ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_DATE", (object)Item.CREATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_BY", (object)Item.CREATE_BY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_DATE", (object)Item.UPDATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_BY", (object)Item.UPDATE_BY ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
                }
            }
            return result;
        }

        /// <summary>
        /// 編輯入庫單據資料
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult EditWmsInList(List<Model.WmsInLine> Lists)
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
                        strSql = "delete WMS_IN_LINE where LIST_NO = @LIST_NO and LINE_ID = @LINE_ID ";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LINE_ID", (object)Item.LINE_ID ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();

                        strSql = "insert into WMS_IN_LINE ( LIST_NO, LINE_ID, ERP_LINE_ID, STATUS_CTR, PROD_NO, LOT_NO, ORG_NO, QTY, WMS_QTY, TMP_QTY, " + "\r\n" +
                                 "                           MES_QTY, UN, PRODUCTION_DATE, REMARK, CREATE_DATE, CREATE_BY, UPDATE_DATE, UPDATE_BY ) " + "\r\n" +
                                 "                  values (@LIST_NO,@LINE_ID,@ERP_LINE_ID,@STATUS_CTR,@PROD_NO,@LOT_NO,@ORG_NO,@QTY,@WMS_QTY,@TMP_QTY, " + "\r\n" +
                                 "                          @MES_QTY,@UN,@PRODUCTION_DATE,@REMARK,@CREATE_DATE,@CREATE_BY,@UPDATE_DATE,@UPDATE_BY) ";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LINE_ID", (object)Item.LINE_ID ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ERP_LINE_ID", (object)Item.ERP_LINE_ID ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STATUS_CTR", Convert.ToInt16(Item.STATUS_CTR));
                        Cmd.Parameters.AddWithValue("PROD_NO", (object)Item.PROD_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LOT_NO", (object)Item.LOT_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ORG_NO", (object)Item.ORG_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("QTY", (object)Item.QTY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("WMS_QTY", 0);
                        Cmd.Parameters.AddWithValue("TMP_QTY", 0);
                        Cmd.Parameters.AddWithValue("MES_QTY", 0);
                        Cmd.Parameters.AddWithValue("UN", (object)Item.UN ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PRODUCTION_DATE", (object)Item.PRODUCTION_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("REMARK", (object)Item.REMARK ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_DATE", (object)Item.CREATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_BY", (object)Item.CREATE_BY ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_DATE", (object)Item.UPDATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_BY", (object)Item.UPDATE_BY ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
                }
            }
            return result;
        }

        /// <summary>
        /// 強制結單出庫單據資料
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult CompleteWmsOutList(List<Model.WmsOutLine> Lists)
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
                        strSql = "update WMS_OUT_LINE set STATUS_CTR = @STATUS_CTR where LIST_NO = @LIST_NO and LINE_ID = @LINE_ID ";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("STATUS_CTR", Convert.ToInt16(vPublic.StatusCtr.手動觸發強制結單));
                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LINE_ID", (object)Item.LINE_ID ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();

                        
                    }

                    strSql = "update WMS_OUT_LIST set STATUS_CTR = @STATUS_CTR " +
                             "where not exists " +
                             "  (select b.LIST_NO from WMS_OUT_LINE b " +
                             "   where WMS_OUT_LIST.LIST_NO = b.LIST_NO " +
                             "   and b.STATUS_CTR in (@STATUS_CTR0, @STATUS_CTR8, @STATUS_CTR33)) ";

                    Cmd.CommandText = strSql;
                    Cmd.Parameters.Clear();
                    Cmd.Parameters.AddWithValue("STATUS_CTR", Convert.ToInt16(vPublic.StatusCtr.手動觸發強制結單));
                    Cmd.Parameters.AddWithValue("STATUS_CTR0", Convert.ToInt16(vPublic.StatusCtr.接單));
                    Cmd.Parameters.AddWithValue("STATUS_CTR8", Convert.ToInt16(vPublic.StatusCtr.收料中));
                    Cmd.Parameters.AddWithValue("STATUS_CTR33", Convert.ToInt16(vPublic.StatusCtr.出庫中));
                    rtn = Cmd.ExecuteNonQuery();

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
                }
            }
            return result;
        }

        /// <summary>
        /// 強制結單入庫單據資料
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult CompleteWmsInList(List<Model.WmsInLine> Lists)
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
                        strSql = "update WMS_IN_LINE set STATUS_CTR = @STATUS_CTR where LIST_NO = @LIST_NO and LINE_ID = @LINE_ID ";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("STATUS_CTR", Convert.ToInt16(vPublic.StatusCtr.手動觸發強制結單));
                        Cmd.Parameters.AddWithValue("LIST_NO", (object)Item.LIST_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LINE_ID", (object)Item.LINE_ID ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();


                    }

                    strSql = "update WMS_IN_LIST set STATUS_CTR = @STATUS_CTR " +
                             "where not exists " +
                             "  (select b.LIST_NO from WMS_IN_LINE b " +
                             "   where WMS_IN_LIST.LIST_NO = b.LIST_NO " +
                             "   and b.STATUS_CTR in (@STATUS_CTR0, @STATUS_CTR8, @STATUS_CTR33)) ";

                    Cmd.CommandText = strSql;
                    Cmd.Parameters.Clear();
                    Cmd.Parameters.AddWithValue("STATUS_CTR", Convert.ToInt16(vPublic.StatusCtr.手動觸發強制結單));
                    Cmd.Parameters.AddWithValue("STATUS_CTR0", Convert.ToInt16(vPublic.StatusCtr.接單));
                    Cmd.Parameters.AddWithValue("STATUS_CTR8", Convert.ToInt16(vPublic.StatusCtr.收料中));
                    Cmd.Parameters.AddWithValue("STATUS_CTR33", Convert.ToInt16(vPublic.StatusCtr.出庫中));
                    rtn = Cmd.ExecuteNonQuery();

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
                }
            }
            return result;
        }

        /// <summary>
        /// 檢視可用庫存數量
        /// </summary>
        /// <param name="ProdNo">料號</param>
        /// <param name="LotNo">批號</param>
        /// <param name="PDate">生產日期</param>
        /// <param name="OrgNo">客戶代號</param>
        /// <returns></returns>
        public decimal GetStkQty(string ProdNo, string LotNo, DateTime? PDate, string OrgNo)
        {
            string strSql = string.Empty;
            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>();
            strSql = "select isnull(sum(QTY),0) as QTY from WMS_STK where PROD_NO = @PROD_NO and STUS_CTR = @STUS_CTR and PROD_TYPE = @PROD_TYPE "+
                     "and WH_NO = @WH_NO and ASRS_ID = @ASRS_ID and AREA_NO = @AREA_NO ";

            parameters.Add(new vPublic.DBParameter() { ParameterName = "PROD_NO", Value = ProdNo });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "STUS_CTR", Value = Convert.ToDecimal(Model.WmsStk.StusCtr.可用庫存) });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "PROD_TYPE", Value = Convert.ToDecimal(Model.WmsStk.ProdType.成品_原物料) });

            parameters.Add(new vPublic.DBParameter() { ParameterName = "WH_NO", Value = vPublic.AsrsDefine.WH_NO });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "ASRS_ID", Value = vPublic.AsrsDefine.ASRS_ID });
            parameters.Add(new vPublic.DBParameter() { ParameterName = "AREA_NO", Value = vPublic.AsrsDefine.AREA_NO });

            
            strSql += " and isnull(LOT_NO,' ') = isnull(@LOT_NO,' ') ";
            parameters.Add(new vPublic.DBParameter() { ParameterName = "LOT_NO", Value = LotNo });
            

            //if (!string.IsNullOrEmpty(OrgNo))
            //{
            //    strSql += " and ORG_NO = @ORG_NO ";
            //    parameters.Add(new vPublic.DBParameter() { ParameterName = "ORG_NO", Value = OrgNo });
            //}

            if (PDate.HasValue)
            {
                strSql += " and Convert(varchar,PRODUCTION_DATE,111) = @PRODUCTION_DATE ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "PRODUCTION_DATE", Value = PDate.Value.ToString("yyyy/MM/dd") });
            }
            
            var result = vPublic.GetDbData(strSql, parameters);
            if (result.Successed)
            {
                result.Data = Convert.ToDecimal(result.ResultDt.Rows[0]["QTY"]);
            }
            else
                result.Data = null;

            return result.Successed ? (decimal)result.Data : -1;
        }
    }
}

