using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.Model
{
    public class WcsCrnErrorLog
    {
        public decimal CRN_ID { get; set; }
        public string FROM_BIN { get; set; }
        public string FROM_SD { get; set; }
        public string TO_BIN { get; set; }
        public string TO_SD { get; set; }
        public decimal SER_NO { get; set; }
        public decimal ERR_CODE { get; set; }
        public string ERR_DESC { get; set; }
        public string IO { get; set; }
        public decimal STEP { get; set; }
        public bool LOADING { get; set; }
        public DateTime? CREATE_DATE { get; set; }
    }
}
