using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.Model
{
    public class WmsOutList
    {
        public string LIST_NO { get; set; }
        public DateTime? LIST_DATE { get; set; }
        public vPublic.StatusCtr STATUS_CTR { get; set; }
        public string STATUS_CTR_DESC { get; set; }
        public vPublic.ListCtr LIST_CTR { get; set; }
        public string LIST_CTR_DESC { get; set; }
        public string ERP_LIST_NO { get; set; }
        public string ERP_LIST_TYPE { get; set; }
        public string REMARK { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string CREATE_BY { get; set; }
        public string CREATE_NAME { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public string UPDATE_NAME { get; set; }
        public List<WmsOutLine> Details { get; set; }

        public WmsOutList()
        {
            STATUS_CTR = vPublic.StatusCtr.接單;
            LIST_CTR = vPublic.ListCtr.出庫單據;
            CREATE_DATE = DateTime.Now;
            UPDATE_DATE = DateTime.Now;
            CREATE_BY = Program.wmsUser.UserNo;
            UPDATE_BY = Program.wmsUser.UserNo;
        }
    }
}
