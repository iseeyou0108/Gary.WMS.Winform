using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WMS
{
    public partial class Fm_B002_1 : Form
    {
        // 多國語言資源檔設定
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_B002", "FORM_BASIC"), System.Reflection.Assembly.GetExecutingAssembly());


        private vPublic.EditMode editMode { get; set; }
        private Fm_B002.WMS_ORG WmsOrg { get; set; }
        private List<Fm_B002.WMS_ORG> WmsOrgs { get; set; }
        private Fm_B002.WMS_ORG PreWmsOrg { get; set; }
                    

        public Fm_B002_1()
        {
            InitializeComponent();
        }

        private void Fm_B002_1_Load(object sender, EventArgs e)
        {
            
            #region SetStyle

            txtOrgNo.StyleController = Program.STYLER;
            txtOrgName.StyleController = Program.STYLER;
            txtSname.StyleController = Program.STYLER;
            txtCellphone.StyleController = Program.STYLER;
            txtContact.StyleController = Program.STYLER;
            txtTax.StyleController = Program.STYLER;
            txtTitle.StyleController = Program.STYLER;
            txtRemark.StyleController = Program.STYLER;
            txtPhone.StyleController = Program.STYLER;
            txtAddress.StyleController = Program.STYLER;
            txtAddress2.StyleController = Program.STYLER;

            #endregion

            if (editMode == vPublic.EditMode.Update)
            {
                BindEditControl();
                PreWmsOrg = new Fm_B002.WMS_ORG();
                BindModal(PreWmsOrg);
                txtOrgNo.Properties.ReadOnly = true;
                txtSname.Focus();
            }
            else
            {
                layoutControlGroup_Record.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;                
                txtOrgNo.Properties.ReadOnly = false;
                txtOrgNo.Focus();
            }
        }

        public void SetModal(Fm_B002.WMS_ORG _WmsOrg, List<Fm_B002.WMS_ORG> _WmsOrgs)
        {
            WmsOrg = _WmsOrg;
            WmsOrgs = new List<Fm_B002.WMS_ORG>();
            WmsOrgs = _WmsOrgs;
        }

        public void SetText(string _Text)
        {
            Text = _Text;
        }

        public void SetEditMode(vPublic.EditMode _editMode)
        {
            editMode = _editMode;
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            AutoValidate = AutoValidate.Disable;
            this.Close();
        }

        private void txtOrgNo_Validating(object sender, CancelEventArgs e)
        {
            if (this.ActiveControl.Equals(sender))
                return;

            if (string.IsNullOrEmpty(txtOrgNo.Text))
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Notnull"));
                //MessageBox.Show(this, RM.GetString("Notnull"), RM.GetString("MsgTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void txtOrgNo_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //綁定Modal
            BindModal(WmsOrg);

            #region 防呆檢查
            if (editMode == vPublic.EditMode.Add)
            {
                var checkResult = WmsOrg.CheckAddExist();

                if (checkResult.Successed == false)
                {
                    vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString(checkResult.Message));
                    //MessageBox.Show(this, RM.GetString(checkResult.Message), RM.GetString("MsgTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            #endregion

            string ConfirmMessage = string.Empty;

            ConfirmMessage = editMode == vPublic.EditMode.Add ? RM.GetString("AddDialogSaveMsg") : string.Format(RM.GetString("EditDialogSaveMsg"), WmsOrg.ORG_NO, WmsOrg.ORG_NAME);

            if (MessageBox.Show(this, ConfirmMessage, RM.GetString("MsgTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            SqlConnection Conn = new SqlConnection(vPublic.ConnStr);
            try
            {
                Conn.Open();
            }
            catch (SqlException ex)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, ex.Message);
                //MessageBox.Show(this, ex.Message, RM.GetString("MsgTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlTransaction trans = Conn.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var Cmd = Conn.CreateCommand();
                    Cmd.Transaction = trans;

                    string strSql = string.Empty;

                    if (editMode == vPublic.EditMode.Add)
                    {
                        strSql = "insert into WMS_ORG (ORG_NO, ORG_NAME, SNAME, PHONE, TAX, CONTACT, TITLE, CELLPHONE, ADDRESS, ADDRESS2, SOURCE_CODE," +
                                 "                     REMARK, CREATE_DATE, CREATE_BY, UPDATE_DATE, UPDATE_BY ) " +
                                 "            values (@ORG_NO,@ORG_NAME,@SNAME,@PHONE,@TAX,@CONTACT,@TITLE,@CELLPHONE,@ADDRESS,@ADDRESS2,@SOURCE_CODE," +
                                 "                    @REMARK,@CREATE_DATE,@CREATE_BY,@UPDATE_DATE,@UPDATE_BY) ";
                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();
                        
                        Cmd.Parameters.AddWithValue("ORG_NO", WmsOrg.ORG_NO);
                        Cmd.Parameters.AddWithValue("ORG_NAME", WmsOrg.ORG_NAME);
                        Cmd.Parameters.AddWithValue("SNAME", WmsOrg.SNAME);
                        Cmd.Parameters.AddWithValue("PHONE", (object)WmsOrg.PHONE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("TAX", (object)WmsOrg.TAX ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CONTACT", (object)WmsOrg.CONTACT ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("TITLE", (object)WmsOrg.TITLE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CELLPHONE", (object)WmsOrg.CELLPHONE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ADDRESS", (object)WmsOrg.ADDRESS ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ADDRESS2", (object)WmsOrg.ADDRESS2 ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("SOURCE_CODE", (object)WmsOrg.SOURCE_CODE ?? "0");
                        Cmd.Parameters.AddWithValue("REMARK", (object)WmsOrg.REMARK ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_DATE", (object)WmsOrg.CREATE_DATE ?? DateTime.Now);
                        Cmd.Parameters.AddWithValue("CREATE_BY", (object)WmsOrg.CREATE_BY ?? Program.wmsUser.UserNo);
                        Cmd.Parameters.AddWithValue("UPDATE_DATE", (object)WmsOrg.UPDATE_DATE ?? DateTime.Now);
                        Cmd.Parameters.AddWithValue("UPDATE_BY", (object)WmsOrg.UPDATE_BY ?? Program.wmsUser.UserNo);

                        int rtn = Cmd.ExecuteNonQuery();

                        string ErrorMessage = string.Empty;
                        //新增客戶基本檔資料-客戶代號:{0}({1})
                        bool LogResult = vPublic.Insert_WMS_USER_OPR_HIST(Cmd, string.Format(RM.GetString("AddLog"), WmsOrg.ORG_NO, WmsOrg.SNAME), "Fm_B002", ref ErrorMessage);
                        if (!LogResult)
                            throw new Exception(ErrorMessage);
                    }
                    else
                    {
                        strSql = "update WMS_ORG set ORG_NAME = @ORG_NAME, " +
                                 "                   SNAME = @SNAME, " +
                                 "                   PHONE = @PHONE, " +
                                 "                   TAX = @TAX, " +
                                 "                   CONTACT = @CONTACT, " +
                                 "                   TITLE = @TITLE, " +
                                 "                   CELLPHONE = @CELLPHONE, " +
                                 "                   ADDRESS = @ADDRESS, " +
                                 "                   ADDRESS2 = @ADDRESS2, " +
                                 "                   REMARK = @REMARK, " +
                                 "                   UPDATE_DATE = @UPDATE_DATE, " +
                                 "                   UPDATE_BY = @UPDATE_BY " +
                                 "where ORG_NO = @ORG_NO ";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.AddWithValue("ORG_NAME", WmsOrg.ORG_NAME);
                        Cmd.Parameters.AddWithValue("SNAME", WmsOrg.SNAME);
                        Cmd.Parameters.AddWithValue("PHONE", (object)WmsOrg.PHONE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("TAX", (object)WmsOrg.TAX ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CONTACT", (object)WmsOrg.CONTACT ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("TITLE", (object)WmsOrg.TITLE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CELLPHONE", (object)WmsOrg.CELLPHONE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ADDRESS", (object)WmsOrg.ADDRESS ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ADDRESS2", (object)WmsOrg.ADDRESS2 ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("REMARK", (object)WmsOrg.REMARK ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_DATE", (object)WmsOrg.UPDATE_DATE ?? DateTime.Now);
                        Cmd.Parameters.AddWithValue("UPDATE_BY", (object)WmsOrg.UPDATE_BY ?? Program.wmsUser.UserNo);
                        Cmd.Parameters.AddWithValue("ORG_NO", WmsOrg.ORG_NO);
                        int rtn = Cmd.ExecuteNonQuery();

                        //修改客戶基本檔資料-客戶代號:{0}, 客戶簡稱:{1}->{2}, 客戶名稱:{3}->{4}, 聯絡人:{5}->{6}, 職稱:{7}->{8}, 電話:{9}->{10}
                        string ErrorMessage = string.Empty;
                        //刪除客戶基本檔資料-客戶代號:{0}({1})
                        bool LogResult = vPublic.Insert_WMS_USER_OPR_HIST(Cmd, string.Format(RM.GetString("EditLog"), WmsOrg.ORG_NO,
                            PreWmsOrg.SNAME, WmsOrg.SNAME,
                            PreWmsOrg.ORG_NAME, WmsOrg.ORG_NAME,
                            PreWmsOrg.CONTACT, WmsOrg.CONTACT,
                            PreWmsOrg.TITLE, WmsOrg.TITLE,
                            PreWmsOrg.PHONE, WmsOrg.PHONE), "Fm_B002", ref ErrorMessage);
                        if (!LogResult)
                            throw new Exception(ErrorMessage);
                    }

                    trans.Commit();
                    Cmd.Dispose();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, ex.Message);
                    //MessageBox.Show(this, ex.Message, RM.GetString("MsgTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (editMode == vPublic.EditMode.Update)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                WmsOrg = new Fm_B002.WMS_ORG();
                BindEditControl();
            }
        }


        private void BindModal(Fm_B002.WMS_ORG _WmsOrg)
        {
            _WmsOrg.ORG_NO = txtOrgNo.Text.Trim();
            _WmsOrg.SNAME = txtSname.Text.Trim();
            _WmsOrg.ORG_NAME = txtOrgName.Text.Trim();
            _WmsOrg.PHONE = txtPhone.Text.Trim();
            _WmsOrg.TAX = txtTax.Text.Trim();
            _WmsOrg.CONTACT = txtContact.Text.Trim();
            _WmsOrg.TITLE = txtTitle.Text.Trim();
            _WmsOrg.CELLPHONE = txtCellphone.Text.Trim();
            _WmsOrg.ADDRESS = txtAddress.Text.Trim();
            _WmsOrg.ADDRESS2 = txtAddress2.Text.Trim();
            if (editMode == vPublic.EditMode.Add)
                _WmsOrg.SOURCE_CODE = "0";
            _WmsOrg.REMARK = txtRemark.Text.Trim();
            _WmsOrg.UPDATE_BY = Program.wmsUser.UserNo;
            _WmsOrg.UPDATE_DATE = DateTime.Now;
        }

        private void BindEditControl()
        {
            txtOrgNo.Text = WmsOrg.ORG_NO;
            txtOrgName.Text = WmsOrg.ORG_NAME;
            txtSname.Text = WmsOrg.SNAME;
            txtPhone.Text = WmsOrg.PHONE;
            txtTax.Text = WmsOrg.TAX;
            txtContact.Text = WmsOrg.CONTACT;
            txtTitle.Text = WmsOrg.TITLE;
            txtCellphone.Text = WmsOrg.CELLPHONE;
            txtAddress.Text = WmsOrg.ADDRESS;
            txtAddress2.Text = WmsOrg.ADDRESS2;
            txtRemark.Text = WmsOrg.REMARK;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var NextModel = WmsOrgs.SkipWhile(item => item.ORG_NO != WmsOrg.ORG_NO).Skip(1).DefaultIfEmpty(WmsOrgs[0]).FirstOrDefault();

            WmsOrg = NextModel;

            BindEditControl();
            PreWmsOrg = new Fm_B002.WMS_ORG();
            BindModal(PreWmsOrg);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            var LastModel = WmsOrgs.TakeWhile(x => x.ORG_NO != WmsOrg.ORG_NO).DefaultIfEmpty(WmsOrgs[WmsOrgs.Count - 1]).LastOrDefault();

            WmsOrg = LastModel;

            BindEditControl();
            PreWmsOrg = new Fm_B002.WMS_ORG();
            BindModal(PreWmsOrg);
        }


        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x10) // The upper right "X" was clicked
            {
                AutoValidate = AutoValidate.Disable; //Deactivate all validations
            }
            base.WndProc(ref m);
        }

        // To capture the "Esc" key
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                AutoValidate = AutoValidate.Disable;
                btnCancel_Click(null, null);
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

    }
}
