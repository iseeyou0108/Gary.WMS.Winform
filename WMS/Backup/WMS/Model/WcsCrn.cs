using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.Model
{
    public class WcsCrn
    {
        public bool CHK { get; set; }
        public string AREA_NO { get; set; }
        public string WH_NO { get; set; }
        public decimal ASRS_ID { get; set; }
        public string CRN_NO { get; set; }
        public decimal CRN_ID { get; set; }
        public bool CONNECT_MODE { get; set; }
        public string CONNECT_MODE_DESC { get; set; }
        public bool INHIBIT_IN_FLG { get; set; }
        public bool INHIBIT_OUT_FLG { get; set; }
        public decimal SER_NO { get; set; }
        public string IO { get; set; }
        public string FROM_BIN { get; set; }
        public string FROM_SD { get; set; }
        public string TO_BIN { get; set; }
        public string TO_SD { get; set; }
        public DateTime? START_TIME { get; set; }
        public decimal ERR_CODE { get; set; }
        public string ERR_CODE_DESC { get; set; }
        public decimal STEP { get; set; }
        public bool LOADING { get; set; }
        public decimal SYS_LOCK { get; set; }
        public decimal CRN_TYPE { get; set; }
        public decimal CRN_RUNNING { get; set; }
        public decimal CRN_LOADING { get; set; }
        public string CRN_LOCATION { get; set; }
        public decimal CRN_SER_NO { get; set; }
        public decimal CRN_ERROR { get; set; }
        public bool CRN_AUTO { get; set; }
        public bool CRN_INITIAL { get; set; }
        public bool CRN_CMD_COMP { get; set; }
        public bool CRN_NORMAL { get; set; }
        public bool CRN_CMD_EXIST { get; set; }
        public bool CRN_READY { get; set; }
        public string INSIDE_INHIBIT_FLG { get; set; }
        public string INSIDE_WORKER { get; set; }
        public string INSIDE_PASSWORD { get; set; }
        public string INSIDE_REMARK { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public string UPDATE_NAME { get; set; }
    }
}
