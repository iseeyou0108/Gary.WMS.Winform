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
    public partial class Fm_HrsUser : Form
    {
        public class HrsUnit
        {
            public string UNIT_NO { get; set; }
            public string UNIT_NAME { get; set; }
        }
        public class HrsRole
        {
            public string ROLE_NO { get; set; }
            public string ROLE_NAME { get; set; }
        }

        public List<HrsUnit> HrsUnits { get; set; }
        public List<HrsRole> HrsRoles { get; set; }

        public List<HrsRole> LeftItmes { get; set; }
        public List<HrsRole> RightItmes { get; set; }

        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_S001", "FORM_BASIC"), System.Reflection.Assembly.GetExecutingAssembly());
        private vPublic.EditMode editMode { get; set; }
        private Fm_S001.HrsUser EditModel { get; set; }
        private string Text { get; set; }

        public Fm_HrsUser()
        {
            InitializeComponent();
        }

        private void Fm_HrsUser_Load(object sender, EventArgs e)
        {
            txtUserNo.StyleController = Program.STYLER;
            txtUserName.StyleController = Program.STYLER;
            txtPassword.StyleController = Program.STYLER;
            cmbUnit.StyleController = Program.STYLER;

            cmbUnit.Properties.DataSource = HrsUnits;
            BindListBox();

            if (editMode == vPublic.EditMode.Add)
            {
                txtUserNo.Focus();
            }
            else if (editMode == vPublic.EditMode.Update)
            {
                txtUserNo.Properties.ReadOnly = true;
                txtUserNo.Text = EditModel.USER_NO;
                txtUserName.Text = EditModel.USER_NAME;
                txtPassword.Text = vPublic.DeCodePasswd(EditModel.PASSWORD);
                chkSuperAdminFlg.Checked = EditModel.SUPER_ADMIN_FLG;
                cmbUnit.EditValue = EditModel.UNIT_NO;
                txtUserName.Focus();
            }
        }

        public void SetEditMode(vPublic.EditMode _editMode)
        {
            editMode = _editMode;
        }

        public void SetEditModel(Fm_S001.HrsUser _hrsUser)
        {
            EditModel = _hrsUser;
        }

        public void BindHrsUnit(List<Fm_S001.HrsUnit> UnitList)
        {
            HrsUnits = new List<HrsUnit>();
            var GroupItem = from t in UnitList
                            group t by new { t1 = t.UNIT_NO, t2 = t.UNIT_NAME } into m
                            select new
                            {
                                UNIT_NO = m.Key.t1,
                                UNIT_NAME = m.Key.t2
                            };

            HrsUnits = GroupItem.Select(o => new HrsUnit() { UNIT_NO = o.UNIT_NO, UNIT_NAME = o.UNIT_NAME }).ToList();
        }

        public void BindListBox()
        {
            var AllRoles = from x in Fm_S001.RolePriv.GetRolePriv()
                           group x by new { x1 = x.PRIV_ROLE_NO, x2 = x.ROLE_NAME } into m
                           select new
                           {
                               ROLE_NO = m.Key.x1,
                               ROLE_NAME = string.Format("{0}-{1}",m.Key.x2,m.Key.x1)
                           };

            var LoginUserRoles = from x in Program.wmsUser.RolePrivs
                                 group x by new { x1 = x.ROLE_NO, x2 = x.ROLE_NAME } into m
                                 select new
                                 {
                                     ROLE_NO = m.Key.x1,
                                     ROLE_NAME = string.Format("{0}-{1}", m.Key.x2, m.Key.x1)
                                 };
            

            if (editMode == vPublic.EditMode.Update)
            {
                RightItmes = LoginUserRoles.Select(o => new HrsRole() { ROLE_NO = o.ROLE_NO, ROLE_NAME = o.ROLE_NAME }).ToList();
                LeftItmes = AllRoles.Select(o => new HrsRole() { ROLE_NO = o.ROLE_NO, ROLE_NAME = o.ROLE_NAME }).Where(o => !RightItmes.Any(o2 => o2.ROLE_NO == o.ROLE_NO)).ToList();
            }
            else
            {
                RightItmes = new List<HrsRole>();
                LeftItmes = AllRoles.Select(o => new HrsRole() { ROLE_NO = o.ROLE_NO, ROLE_NAME = o.ROLE_NAME }).ToList();
                
            }

            listBoxRight.DataSource = RightItmes;
            listBoxLeft.DataSource = LeftItmes; 
        } 

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            AutoValidate = AutoValidate.Disable;
            this.Close();
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

        private void btnArrowRight_Click(object sender, EventArgs e)
        {
            if (listBoxLeft.SelectedIndex >= 0)
            {
                listBoxRight.Items.BeginUpdate();
                RightItmes.Add(LeftItmes[listBoxLeft.SelectedIndex]);
                listBoxRight.Items.EndUpdate();
                listBoxLeft.Items.BeginUpdate();
                LeftItmes.Remove(LeftItmes[listBoxLeft.SelectedIndex]);
                listBoxLeft.Items.EndUpdate();
            }
        }

        private void btnArrowLeft_Click(object sender, EventArgs e)
        {
            if (listBoxRight.SelectedIndex >= 0)
            {
                
                listBoxLeft.Items.BeginUpdate();
                LeftItmes.Add(RightItmes[listBoxRight.SelectedIndex]);
                listBoxLeft.Items.EndUpdate();

                listBoxRight.Items.BeginUpdate();
                RightItmes.Remove(RightItmes[listBoxRight.SelectedIndex]);
                listBoxRight.Items.EndUpdate();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult();

            if (MessageBox.Show(this, editMode == vPublic.EditMode.Add ? RM.GetString("AddMsgTitle") : RM.GetString("EditMsgTitle"), RM.GetString("MsgTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            result = SubmitResult();

            if (result.Successed)
            {
                Program.wmsUser.GetRolePriv();
                this.DialogResult = DialogResult.OK;
                MessageBox.Show(this, result.Message, RM.GetString("MsgTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                
            }
            else
            {
                
                MessageBox.Show(this, result.Message, RM.GetString("MsgTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// 儲存
        /// </summary>
        /// <returns></returns>
        private vPublic.DBExecResult SubmitResult()
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = editMode == vPublic.EditMode.Add ? RM.GetString("AddSaveOk") : RM.GetString("EditSaveOk") };

            SqlConnection Conn = new SqlConnection(vPublic.ConnStr);
            try
            {
                Conn.Open();
            }
            catch (SqlException ex)
            {
                return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
            }

            using (SqlTransaction trans = Conn.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var Cmd = Conn.CreateCommand();
                    Cmd.Transaction = trans;

                    string strSql = string.Empty;

                    strSql = "delete HRS_USER where USER_NO = @USER_NO ";
                    Cmd.CommandText = strSql;
                    Cmd.Parameters.Clear();

                    Cmd.Parameters.AddWithValue("USER_NO", txtUserNo.Text.Trim());

                    int rtn = Cmd.ExecuteNonQuery();



                    DateTime dtCreateDate = DateTime.Now;
                    strSql = "insert into HRS_USER ( USER_NO, USER_NAME, PASSWORD, UNIT_NO, DISABLE_FLG, SUPER_ADMIN_FLG, CREATE_DATE, CREATE_BY, UPDATE_DATE, UPDATE_BY) "+
                             "              values (@USER_NO,@USER_NAME,@PASSWORD,@UNIT_NO,@DISABLE_FLG,@SUPER_ADMIN_FLG,@CREATE_DATE,@CREATE_BY,@UPDATE_DATE,@UPDATE_BY) ";
                    Cmd.CommandText = strSql;
                    Cmd.Parameters.Clear();

                    Cmd.Parameters.AddWithValue("USER_NO", txtUserNo.Text.Trim());
                    Cmd.Parameters.AddWithValue("USER_NAME", txtUserName.Text.Trim());
                    Cmd.Parameters.AddWithValue("PASSWORD", vPublic.EnCodePasswd(txtPassword.Text.Trim()));
                    Cmd.Parameters.AddWithValue("UNIT_NO", cmbUnit.EditValue.ToString());
                    Cmd.Parameters.AddWithValue("DISABLE_FLG", 0);
                    Cmd.Parameters.AddWithValue("SUPER_ADMIN_FLG", chkSuperAdminFlg.Checked == true ? 1 : 0);
                    Cmd.Parameters.AddWithValue("CREATE_DATE", dtCreateDate);
                    Cmd.Parameters.AddWithValue("CREATE_BY", Program.wmsUser.UserNo);
                    Cmd.Parameters.AddWithValue("UPDATE_DATE", dtCreateDate);
                    Cmd.Parameters.AddWithValue("UPDATE_BY", Program.wmsUser.UserNo);

                    rtn = Cmd.ExecuteNonQuery();

                    strSql = "delete HRS_USER_ROLE where USER_NO = @USER_NO ";
                    Cmd.CommandText = strSql;
                    Cmd.Parameters.Clear();

                    Cmd.Parameters.AddWithValue("USER_NO", txtUserNo.Text.Trim());

                    rtn = Cmd.ExecuteNonQuery();

                    foreach (var Item in RightItmes)
                    {
                        strSql = "insert into HRS_USER_ROLE (USER_NO,ROLE_NO) values (@USER_NO,@ROLE_NO) ";
                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("USER_NO", txtUserNo.Text.Trim());
                        Cmd.Parameters.AddWithValue("ROLE_NO", Item.ROLE_NO);

                        rtn = Cmd.ExecuteNonQuery();
                    }

                    string ErrorMessage = string.Empty;
                    //新增/修改角色權限資料-角色代號:{0}({1})
                    bool LogResult = vPublic.Insert_WMS_USER_OPR_HIST(Cmd, string.Format(editMode == vPublic.EditMode.Add ? RM.GetString("AddLog") : RM.GetString("EditLog"), txtUserNo.Text, txtUserName.Text), "Fm_S001", ref ErrorMessage);
                    if (!LogResult)
                        throw new Exception(ErrorMessage);

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
                }
            }
            return result;
        }

      
    }
}
