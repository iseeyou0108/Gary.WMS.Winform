using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.Model
{
    public class HrsMenu
    {
        public int LANG_ID { get; set; }
        public int FORM_ID { get; set; }
        public string FORM_NAME { get; set; }
        public string FORM_TEXT { get; set; }
        public int MENU_LEVEL { get; set; }
        public int PARENT_MENU_ID { get; set; }
        public string SHORT_CUT { get; set; }
        public string VALID_FLG { get; set; }
        public int ORDER_NO { get; set; }

        public HrsMenu()
        {
            LANG_ID = 1;
        }


    }
}
