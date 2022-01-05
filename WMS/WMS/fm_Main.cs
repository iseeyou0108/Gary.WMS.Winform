using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using DevExpress.XtraNavBar;


namespace WMS
{
    public partial class fm_Main : DevExpress.XtraEditors.XtraForm
    {
        static System.Resources.ResourceManager RMPublic = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}Resource_Public", ""), System.Reflection.Assembly.GetExecutingAssembly());

        //系統所有選單
        List<Model.HrsMenu> hrsMenus { get; set; }
        int intDir = 1;
        List<string> AlarmMsg { get; set; }

        public fm_Main()
        {
            InitializeComponent();
        }

        private void fm_Main_Load(object sender, EventArgs e)
        {
            hrsMenus = GetHrsMenu(Program.LangID);
            SetSideBarMenu(hrsMenus);
            lblUser.Text = Program.wmsUser.UserName;

            var rectangle = ScreenRectangle();
            Size = new Size(rectangle.Width - 10, rectangle.Height - 50);
            Location = new Point(5, 5);

            AlarmMsg = new List<string>();
            AlarmMsg.Add("WMS");
            DisplayAlarmMsg();
        }


        public Rectangle ScreenRectangle()
        {
            return Screen.FromControl(this).Bounds;
        }

        //建Menu
        private void SetSideBarMenu(List<Model.HrsMenu> Menus)
        {
            navBarControl_Menu.Groups.Clear();
            #region 建第一層
            List<Model.HrsMenu> FirstLevel = Menus.Where(i => i.MENU_LEVEL == 1).ToList();

            if (FirstLevel.Count > 0)
            {
                foreach (Model.HrsMenu menu in FirstLevel)
                {
                    System.Reflection.Assembly myAssembly = this.GetType().Assembly;

                    // Gets a reference to a different assembly. (if the resources are remote)
                    // System.Reflection.Assembly myOtherAssembly = System.Reflection.Assembly.Load("ResourceAssembly");

                    // Creates the ResourceManager.
                    System.Resources.ResourceManager myManager = new
                       System.Resources.ResourceManager("WMS.Properties.Resources",
                       myAssembly);

                    Image MyImage = (Image)myManager.GetObject(string.Format("menu_{0}", menu.FORM_ID));


                    navBarControl_Menu.Groups.Add(new NavBarGroup()
                    {
                        Caption = menu.FORM_TEXT,
                        Name = string.Format("NavGroup_{0}", menu.FORM_ID),
                        Tag = menu.FORM_ID,
                        SmallImage = MyImage
                    });
                }
            }
            #endregion

            #region 建第二層

            for (int i = 0; i < navBarControl_Menu.Groups.Count; i++)
            {
                int FormID = -1;
                FormID = int.Parse(navBarControl_Menu.Groups[i].Tag.ToString());

                List<Model.HrsMenu> SecondLevel = Menus.Where(x => x.PARENT_MENU_ID == FormID && x.MENU_LEVEL == 2).ToList();

                if (SecondLevel != null)
                {
                    if (SecondLevel.Count > 0)
                    {
                        foreach (Model.HrsMenu Item in SecondLevel)
                        {
                            NavBarItem MenuItem = new NavBarItem()
                            {
                                Caption = Item.FORM_TEXT,
                                Name = string.Format("NavBarItem_{0}", Item.FORM_ID),
                                Tag = Item.FORM_NAME
                            };
                            MenuItem.LinkClicked += new NavBarLinkEventHandler(navBar_SubItemLinkClicked);
                            navBarControl_Menu.Groups[i].ItemLinks.Add(MenuItem);
                        }
                    }
                }

                //系統管理菜單
                if (FormID == 1)
                {
                    NavBarItem LogoutItem = new NavBarItem()
                    {
                        Caption = RMPublic.GetString("btnLogout"),
                        Name = string.Format("NavBarItem_{0}", "Logout"),
                        Tag = "NavBarItem_Logout"
                    };
                    LogoutItem.LinkClicked += new NavBarLinkEventHandler(navBar_LogoutLinkClicked);
                    navBarControl_Menu.Groups[i].ItemLinks.Add(LogoutItem);

                    NavBarItem ExitItem = new NavBarItem()
                    {
                        Caption = RMPublic.GetString("btnExit"),
                        Name = string.Format("NavBarItem_{0}", "Exit"),
                        Tag = "NavBarItem_Exit"
                    };
                    ExitItem.LinkClicked += new NavBarLinkEventHandler(navBar_ExitLinkClicked);
                    navBarControl_Menu.Groups[i].ItemLinks.Add(ExitItem);
                }
            }

            #endregion

            #region 檢查使用者權限 沒權限的就隱藏功能

            if (!Program.wmsUser.SuperAdmin)
            {
                for (int i = 0; i < navBarControl_Menu.Groups.Count; i++)
                {
                    for (int j = 0; j < navBarControl_Menu.Groups[i].ItemLinks.Count; j++)
                    {
                        //登入跟離開不用檢查權限
                        if (navBarControl_Menu.Groups[i].ItemLinks[j].Item.Tag.ToString() == "NavBarItem_Logout") continue;
                        if (navBarControl_Menu.Groups[i].ItemLinks[j].Item.Tag.ToString() == "NavBarItem_Exit") continue;

                        var FormAuth = hrsMenus.Where(x => x.MENU_LEVEL == 2 && x.FORM_NAME == navBarControl_Menu.Groups[i].ItemLinks[j].Item.Tag.ToString()).FirstOrDefault();

                        if (FormAuth != null)
                        {
                            var HasAuth = Program.wmsUser.RolePrivs.Any(x => x.FORM_NAME.Contains(FormAuth.FORM_NAME));
                            navBarControl_Menu.Groups[i].ItemLinks[j].Visible = HasAuth;
                        }

                    }
                }

                for (int i = 0; i < navBarControl_Menu.Groups.Count; i++)
                {
                    int TotalCount = navBarControl_Menu.Groups[i].ItemLinks.Count;
                    int HasAuthCount = 0;

                    for (int j = 0; j < navBarControl_Menu.Groups[i].ItemLinks.Count; j++)
                    {
                        if (navBarControl_Menu.Groups[i].ItemLinks[j].Item.Visible)
                            HasAuthCount += 1;
                    }

                    if (TotalCount != HasAuthCount)
                        navBarControl_Menu.Groups[i].Visible = false;
                }
            }

            #endregion
        }

        void navBar_ExitLinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Close();
        }

        void navBar_LogoutLinkClicked(object sender, NavBarLinkEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
                frm.Dispose();
            }

            fm_Login objForm = new fm_Login(true);
            if (objForm.ShowDialog() == DialogResult.OK)
            {
                hrsMenus = GetHrsMenu(Program.LangID);
                SetSideBarMenu(hrsMenus);
                lblUser.Text = Program.wmsUser.UserName;
            }
        }

        void navBar_SubItemLinkClicked(object sender, NavBarLinkEventArgs e)
        {
            NavBarItem btnItem = e.Link.Item;

            if (btnItem == null)
            { return; }

            #region 開啟程式子畫面

            if (btnItem.Tag == null || string.IsNullOrEmpty(btnItem.Tag.ToString()))
            { return; }

            Cursor.Current = Cursors.WaitCursor;

            // 有找到已開啟的則取代
            for (int i = 0; i < MdiChildren.Length; i++)
            {
                if (MdiChildren[i].Name != btnItem.Tag.ToString())
                { continue; }

                //顯示已開啟的頁籤
                for (int j = 0; j < xtraTabbedMdiManager1.Pages.Count; j++)
                {
                    if (xtraTabbedMdiManager1.Pages[j].MdiChild.Name == btnItem.Tag.ToString())
                    {
                        // 已有相同畫面開啟
                        xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[j];

                        return;
                    }
                }
            }

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();

            Form ui = assembly.CreateInstance("WMS." + btnItem.Tag.ToString()) as Form;

            //轉換失敗離開
            if (ui == null)
            { return; }

            // 設定FORM顯示名稱
            ui.Name = btnItem.Tag.ToString();
            ui.Text = string.Format("[{0}] - {1}", btnItem.Tag.ToString(), btnItem.Caption);

            // 設定MDI表單
            ui.MdiParent = this;
            ui.Icon = this.Icon;
            // 開啟畫面
            ui.Show();

            Cursor.Current = Cursors.Default;

            #endregion
        }

        private List<Model.HrsMenu> GetHrsMenu(vPublic.SystemLanguage Language)
        {
            int _LangID = 1;
            switch (Language)
            {
                case vPublic.SystemLanguage.zh_TW:
                    _LangID = 1;
                    break;
                case vPublic.SystemLanguage.zh_CN:
                    _LangID = 2;
                    break;
                case vPublic.SystemLanguage.en_US:
                    _LangID = 3;
                    break;
            }
            List<Model.HrsMenu> Menus = new List<Model.HrsMenu>();

            string strSql = string.Empty;
            strSql = "select * from HRS_MENU_VW where LANG_ID = @LANG_ID and VALID_FLG = 'Y' ";
            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>()
            {
                new vPublic.DBParameter() { ParameterName = "LANG_ID", Value = _LangID }
            };

            var ExecResult = vPublic.GetDbData(strSql, parameters);
            if (ExecResult.Successed)
            {
                if (ExecResult.ResultDt.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow dr in ExecResult.ResultDt.Rows)
                    {
                        Menus.Add(new Model.HrsMenu()
                        {
                            LANG_ID = _LangID,
                            FORM_ID = int.Parse(dr["FORM_ID"].ToString()),
                            FORM_NAME = dr["FORM_NAME"].ToString(),
                            FORM_TEXT = dr["FORM_TEXT"].ToString(),
                            MENU_LEVEL = int.Parse(dr["MENU_LEVEL"].ToString()),
                            PARENT_MENU_ID = int.Parse(dr["PARENT_MENU_ID"].ToString()),
                            SHORT_CUT = dr["SHORT_CUT"].ToString(),
                            VALID_FLG = dr["VALID_FLG"].ToString(),
                            ORDER_NO = int.Parse(dr["ORDER_NO"].ToString())
                        });
                    }
                }
            }

            return Menus;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var result = vPublic.GetDbData("select a.CRN_ID, b.ERR_DESC " +
                                           "from WCS_CRN a " +
                                           "left join WCS_ERR_MAPPING_REF_VW b " +
                                           "on a.ERR_CODE = b.ERR_CODE and b.DEV_TYPE = 'C' and LANG_ID = @LANG_ID " +
                                           "where CRN_ERROR > 0 " +
                                           "order by a.CRN_ID ",
                                           new List<vPublic.DBParameter>(){
                                               new vPublic.DBParameter(){ ParameterName="LANG_ID",Value=Convert.ToInt16(Program.LangID)}
                                           });
            if (result.Successed)
            {
                AlarmMsg.Clear();
                foreach (DataRow dr in result.ResultDt.Rows)
                {
                    AlarmMsg.Add(string.Format("Crn{0:00}-{1}", int.Parse(dr["CRN_ID"].ToString()), dr["ERR_DESC"].ToString()));
                }
                if(AlarmMsg.Count<=0)
                    AlarmMsg.Add("WMS");
            }

            DisplayAlarmMsg();
        }

        private void DisplayAlarmMsg()
        {
            string CurrentMsg = lblAlarmMsg.Text;
            var NextMsg = AlarmMsg.SkipWhile(item => item != CurrentMsg).Skip(1).DefaultIfEmpty(AlarmMsg[0]).FirstOrDefault();
            lblAlarmMsg.Text = NextMsg;
            Point lblLoc = new Point(pnlStatusBar.Size.Width / 2 - lblAlarmMsg.Size.Width / 2, lblAlarmMsg.Location.Y);
            lblAlarmMsg.Location = lblLoc;
        }

        private void chkShowMessage_CheckedChanged(object sender, EventArgs e)
        {
            lblAlarmMsg.Visible = chkShowMessage.Checked;
        }
    }
}