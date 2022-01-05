using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.Model
{
    public class WmsBinSta
    {
        public bool CHK { get; set; }
        public string AREA_NO { get; set; }
        public string WH_NO { get; set; }
        public decimal ASRS_ID { get; set; }
        public int CRN_ID { get; set; }
        public decimal BAY_NO { get; set; }
        public decimal ROW_NO { get; set; }
        public decimal LEVEL_NO { get; set; }
        public string BIN_NO { get; set; }
        public string SD { get; set; }
        public string BIN_STA { get; set; }
        public string BIN_STA_DESC { get; set; }
        public string INHIBIT_IN_FLG { get; set; }
        public string INHIBIT_OUT_FLG { get; set; }
        public WmsStk.ProdType PROD_TYPE { get; set; }
    }
}
