using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace WMS
{
    static class Program
    {
        public static DevExpress.XtraEditors.StyleController STYLER = new DevExpress.XtraEditors.StyleController();
        public static Model.WmsUser wmsUser { get; set; }

        /// <summary>
        /// 多國語言物件
        /// </summary> 
        //public static CultureInfo WMS_CULTURE = new CultureInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.Name);
        //public static CultureInfo GUI_CULTURE = new CultureInfo("zh-TW");  // 預設(繁體: 簡體:zh-CN 英文:en-US)
        public static CultureInfo WMS_CULTURE = new CultureInfo("zh-TW");
        public static vPublic.SystemLanguage LangID { get; set; }

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 取得或設定資源管理員目前用以在執行階段查詢特定文化特性資源所用的文化特性
            System.Threading.Thread.CurrentThread.CurrentUICulture = WMS_CULTURE;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            fm_Login login = new fm_Login();
            login.ShowDialog();

            if (login.IsLogin)
            {
                STYLER.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
                STYLER.AppearanceReadOnly.BackColor = System.Drawing.SystemColors.Control; //Control.DefaultBackColor;
                Application.Run(new fm_Main());
            }
        }
    }
}
