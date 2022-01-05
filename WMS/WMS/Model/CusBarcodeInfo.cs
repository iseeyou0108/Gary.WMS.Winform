using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.Model
{
    public class CusBarcodeInfo
    {
        public string LIST_NO { get; set; }
        public int LINE_ID { get; set; }
        public string PALLET_NO { get; set; }
        public string PROD_NO { get; set; }
        public string PROD_NAME { get; set; }
        public string ORG_NO { get; set; }
        public string ORG_SNAME { get; set; }
        public string LOT_NO { get; set; }
        public decimal QTY { get; set; }
        public string UN { get; set; }
        public DateTime? STOREIN_DATE { get; set; }
        public DateTime? PRODUCTION_DATE { get; set; }
        public DateTime? CHECK_DATE { get; set; }
        public string REMARK { get; set; }
        public vPublic.BarcodeInStatus STATUS { get; set; }
        public string STATUS_DESC { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string CREATE_BY { get; set; }
        public string CREATE_NAME { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public string UPDATE_NAME { get; set; }
    }
}

