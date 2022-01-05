using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.Model
{
    public class WmsStkOrder
    {
        public string FIFO_NO { get; set; }
        public string AREA_NO { get; set; }
        public string WH_NO { get; set; }
        public decimal ASRS_ID { get; set; }
        public WmsStk.StusCtr STUS_CTR { get; set; }
        public string STUS_CTR_DESC { get; set; }
        public string BIN_NO { get; set; }
        public string SD { get; set; }
        public string SRC_BIN_NO { get; set; }
        public WmsStk.ProdType PROD_TYPE { get; set; }
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
        public WmsStk.QCResult QC_RESULT { get; set; }
        public string QC_RESULT_DESC { get; set; }
    }
}
