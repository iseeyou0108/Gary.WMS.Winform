using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Windows.Forms;

namespace WMS
{
    public partial class fm_Login : Form
    {
        public bool IsLogin { get; set; }
        public bool LogoutMode { get; set; }
        ResourceManager RM = new ResourceManager("WMS.Language.Resource_fm_Login", Assembly.GetExecutingAssembly());

        private class LanguageItem
        {
            public vPublic.SystemLanguage Value { get; set; }
            public string Text { get; set; }
        }

        public fm_Login()
        {
            InitializeComponent();
            IsLogin = false;
            LogoutMode = false;
        }

        public fm_Login(bool _IsLogout)
        {
            InitializeComponent();
            LogoutMode = _IsLogout;
        }

        private void fm_Login_Load(object sender, EventArgs e)
        {
            List<LanguageItem> languageItems = new List<LanguageItem>()
            {
                new LanguageItem(){ Value= vPublic.SystemLanguage.zh_TW, Text="繁體中文"},
                new LanguageItem(){ Value= vPublic.SystemLanguage.zh_CN, Text="简体中文"},
                new LanguageItem(){ Value= vPublic.SystemLanguage.en_US, Text="English"}
            };
            cbLang.Properties.DataSource = languageItems;
            //預設選項
            cbLang.EditValue = vPublic.SystemLanguage.zh_TW;

            if (LogoutMode)
            {
                txtUserNo.Text = Program.wmsUser.UserNo;
                txtUserNo.Properties.ReadOnly = true;
                txtPassword.Focus();
            }
        }

        private void txtUserNo_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            vPublic.SetConnStr("Data Source=192.168.1.65;Initial Catalog=ASRS_XINFA;User ID=sa;Password=123;");

            if (string.IsNullOrEmpty(txtUserNo.Text))
            {
                //請輸入帳號
                //MessageBox.Show(this, RM.GetString("Msg001"), "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vPublic.ShowAlert(Fm_Alert.AlertType.Information, RM.GetString("Msg001"));
                txtUserNo.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                //請輸入密碼
                //MessageBox.Show(this, RM.GetString("Msg002"), "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vPublic.ShowAlert(Fm_Alert.AlertType.Information, RM.GetString("Msg002"));
                txtPassword.Focus();
                return;
            }

            var UserResult = vPublic.GetDbData("select * from HRS_USER where USER_NO = @USER_NO", new List<vPublic.DBParameter>() { new vPublic.DBParameter() { ParameterName = "USER_NO", Value = txtUserNo.Text.Trim() } });

            if (UserResult.Successed == false)
            {
                //查詢使用者資料異常:{0}
                //MessageBox.Show(this, string.Format(RM.GetString("Msg003"), UserResult.Message), "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, RM.GetString("Msg003"));
                return;
            }

            if (UserResult.ResultDt.Rows.Count <= 0)
            {
                //查無使用者帳號，請確認帳號輸入是否正確
                //MessageBox.Show(this, RM.GetString("Msg004"), "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg004"));
                txtUserNo.Focus();
                return;
            }
            else
            {
                if (UserResult.ResultDt.Rows[0]["DISABLE_FLG"].ToString() == "1")
                {
                    //該帳號已停用
                    //MessageBox.Show(this, RM.GetString("Msg005"), "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg005"));
                    txtUserNo.Focus();
                    return;
                }

                string Password = vPublic.DeCodePasswd(UserResult.ResultDt.Rows[0]["PASSWORD"].ToString());
                if (!txtPassword.Text.Trim().Equals(Password))
                {
                    //密碼錯誤
                    //MessageBox.Show(this, RM.GetString("Msg006"), "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg006"));
                    txtPassword.Focus();
                    return;
                }

                this.DialogResult = DialogResult.OK;
                Program.wmsUser = new WMS.Model.WmsUser()
                {
                    UserNo = txtUserNo.Text.Trim(),
                    UserName = UserResult.ResultDt.Rows[0]["USER_NAME"].ToString(),
                    SuperAdmin = decimal.Parse(UserResult.ResultDt.Rows[0]["SUPER_ADMIN_FLG"].ToString()) > 0 ? true : false
                };
                Program.wmsUser.GetRolePriv();

                #region 設定多國語系

                SetLanguage((vPublic.SystemLanguage)cbLang.EditValue);
                
                #endregion
                IsLogin = true;
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        public static void SetLanguage(vPublic.SystemLanguage LagnuageID)
        {
            Program.WMS_CULTURE = new System.Globalization.CultureInfo(vPublic.GetSystemCultureName(LagnuageID));
            Program.LangID = LagnuageID;
            System.Threading.Thread.CurrentThread.CurrentUICulture = Program.WMS_CULTURE;   
        }

        private void cbLang_EditValueChanged(object sender, EventArgs e)
        {
            SetLanguage((vPublic.SystemLanguage)cbLang.EditValue);
        }

        private void txtPassword_DoubleClick(object sender, EventArgs e)
        {
            //Fm_Alert alert = new Fm_Alert();
            //alert.ShowAlert("test", Fm_Alert.AlertType.Warnning);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();
        }
    }
}
