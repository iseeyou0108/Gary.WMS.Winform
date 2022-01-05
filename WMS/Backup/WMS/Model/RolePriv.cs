using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.Model
{
    public class RolePriv
    {
        public string ROLE_NO { get; set; }
        public string ROLE_NAME { get; set; }
        public string FORM_NAME { get; set; }
        public string PRIV_SELECT { get; set; }
        public string PRIV_INSERT { get; set; }
        public string PRIV_UPDATE { get; set; }
        public string PRIV_DELETE { get; set; }
        public string PRIV_EXEC { get; set; }
        public string PRIV_PRINT { get; set; }
        public string PRIV_TRANS { get; set; }
        public string PRIV_EMAIL { get; set; }
        public string PRIV_AUDIT { get; set; }
        public string PRIV_FILE { get; set; }
    }
}
