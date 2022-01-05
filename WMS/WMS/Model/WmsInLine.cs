using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.Model
{
    public class WmsInLine
    {
        public string LIST_NO { get; set; }
        public int LINE_ID { get; set; }
        public string ERP_LINE_ID { get; set; }
        public vPublic.StatusCtr STATUS_CTR { get; set; }
        public string STATUS_CTR_DESC { get; set; }
        public string PROD_NO { get; set; }
        public string PROD_NAME { get; set; }
        public string LOT_NO { get; set; }
        public string ORG_NO { get; set; }
        public string SNAME { get; set; }
        public decimal QTY { get; set; }
        public decimal WMS_QTY { get; set; }
        public decimal TMP_QTY { get; set; }
        public decimal MES_QTY { get; set; }
        public string UN { get; set; }
        public DateTime? PRODUCTION_DATE { get; set; }
        public string PDATE { get; set; }
        public string REMARK { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string CREATE_BY { get; set; }
        public string CREATE_NAME { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public string UPDATE_NAME { get; set; }
        public vPublic.ListCtr LIST_CTR { get; set; }
        public string ERP_LIST_NO { get; set; }
        public string ERP_LIST_TYPE { get; set; }
        public bool CHK { get; set; }
        public decimal IN_QTY { get; set; }
        public decimal AVAILABLE_QTY { get; set; }
        public decimal STK_QTY { get; set; }
    }
}
