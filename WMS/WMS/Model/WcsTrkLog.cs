using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.Model
{
    public class WcsTrkLog
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}Resource_WCS_TRK", ""), System.Reflection.Assembly.GetExecutingAssembly());

        public DateTime? LOG_TIME { get; set; }
        public int SER_NO { get; set; }
        public string AREA_NO { get; set; }
        public string WH_NO { get; set; }
        public int ASRS_ID { get; set; }
        public string BIN_NO { get; set; }
        public string SD { get; set; }
        public string SHF_NO { get; set; }
        public string SHF_SD { get; set; }
        public string DEV_NO { get; set; }
        public string CUR_DEV_NO { get; set; }
        public string NEXT_DEV_NO { get; set; }
        public string TRANS_DEV_NO { get; set; }
        public string IO { get; set; }
        public WcsTrk.TrkStep STEP { get; set; }
        public string STEP_DESC { get; set; }
        public int STATUS { get; set; }
        public string STATUS_DESC { get; set; }
        public WcsTrk.TrkOPN OPN { get; set; }
        public string OPN_DESC { get; set; }
        public int USE_CRN_ID { get; set; }
        public WcsTrk.TrkEmerge EMERGE { get; set; }
        public decimal WEIGHT { get; set; }
        public int SIZE_CHK { get; set; }
        public string BIN_TYPE { get; set; }
        public string KIND { get; set; }
        public DateTime? START_TIME { get; set; }
        public DateTime? STEP_TIME { get; set; }
        public DateTime? END_TIME { get; set; }
        public string PALLET_NO { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string CREATE_BY { get; set; }
        public List<WcsTrkDetLog> Details { get; set; }

        public class WcsTrkDetLog
        {
            public DateTime? LOG_TIME { get; set; }
            public WcsTrk.TrkStep STEP { get; set; }
            public string STEP_DESC { get; set; }
            public string OPN_DESC { get; set; }
            public int SER_NO { get; set; }
            public string AREA_NO { get; set; }
            public string WH_NO { get; set; }
            public int ASRS_ID { get; set; }
            public int? TRK_COUNT { get; set; }
            public string BIN_NO { get; set; }
            public string LIST_NO { get; set; }
            public int? LINE_ID { get; set; }
            public string PALLET_NO { get; set; }
            public string PROD_NO { get; set; }
            public string PROD_NAME { get; set; }
            public string LOT_NO { get; set; }
            public decimal? QTY { get; set; }
            public decimal? OUT_QTY { get; set; }
            public string UN { get; set; }
            public DateTime? STOREIN_DATE { get; set; }
            public DateTime? PRODUCTION_DATE { get; set; }
            public string REMARK { get; set; }
            public DateTime? CREATE_DATE { get; set; }
            public string CREATE_BY { get; set; }
            public string FIFO_NO { get; set; }
            public string ORG_NO { get; set; }
            public string ORG_SNAME { get; set; }
            public string SRC_BIN_NO { get; set; }
            public string QC_RESULT_DESC { get; set; }
        }
    }
}
