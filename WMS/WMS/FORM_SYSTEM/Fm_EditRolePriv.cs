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
    public partial class Fm_EditRolePriv : Form
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_S001", "FORM_BASIC"), System.Reflection.Assembly.GetExecutingAssembly());

        List<Fm_S001.RolePriv> EditRolePrivList { get; set; }
        private vPublic.EditMode editMode { get; set; }
        private string Text { get; set; }

        public Fm_EditRolePriv()
        {
            InitializeComponent();
        }

        public Fm_EditRolePriv(List<Fm_S001.RolePriv> _EditRolePrivList)
        {
            InitializeComponent();

            EditRolePrivList = _EditRolePrivList;

            
        }


        public void SetEditMode(vPublic.EditMode _editMode)
        {
            editMode = _editMode;
        }

        public void SetText(string _Text)
        {
            Text = _Text;
        }

        public static List<Fm_S001.RolePriv> GetRolePriv()
        {
            List<Fm_S001.RolePriv> result = new List<Fm_S001.RolePriv>();

            string strSql = "select a.*, '' as ROLE_NO, '' as ROLE_NAME, "+
                            "       'N' as PRIV_SELECT, " +
                            "       'N' as PRIV_INSERT, " +
                            "       'N' as PRIV_UPDATE, " +
                            "       'N' as PRIV_DELETE, " +
                            "       'N' as PRIV_EXEC " +
                            "from HRS_MENU_VW a where 1 = 1 and a.LANG_ID = @LANG_ID and a.FORM_NAME <> '' order by a.FORM_NAME ";
            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>() { 
                        new vPublic.DBParameter(){ ParameterName = "LANG_ID", Value = Convert.ToInt16(Program.LangID) }
                    };

            var ExecResult = vPublic.GetDbData(strSql, parameters);

            if (ExecResult.Successed)
            {
                if (ExecResult.ResultDt.Rows.Count > 0)
                {
                    foreach (DataRow Detail in ExecResult.ResultDt.Rows)
                    {
                        result.Add(new Fm_S001.RolePriv()
                        {
                            ROLE_NO = string.Format("{0}-{1}", Detail.Field<string>("ROLE_NO"), Detail.Field<string>("FORM_NAME")),
                            FORM_NAME = Detail.Field<string>("FORM_NAME"),
                            FORM_TEXT = Detail.Field<string>("FORM_TEXT"),
                            PRIV_ROLE_NO = Detail.Field<string>("ROLE_NO"),
                            ROLE_NAME = Detail.Field<string>("ROLE_NAME"),
                            PRIV_SELECT = Detail.Field<string>("PRIV_SELECT") == "Y" ? true : false,
                            PRIV_INSERT = Detail.Field<string>("PRIV_INSERT") == "Y" ? true : false,
                            PRIV_UPDATE = Detail.Field<string>("PRIV_UPDATE") == "Y" ? true : false,
                            PRIV_DELETE = Detail.Field<string>("PRIV_DELETE") == "Y" ? true : false,
                            PRIV_EXEC = Detail.Field<string>("PRIV_EXEC") == "Y" ? true : false,
                            HAVE_PRIV = false,
                            CHK_ALL = false
                        });
                    }
                }
            }

            return result;
        }

        private void Fm_EditRolePriv_Load(object sender, EventArgs e)
        {
            txtRoleNo.StyleController = Program.STYLER;
            txtRoleName.StyleController = Program.STYLER;

            if (editMode == vPublic.EditMode.Update)
            {
                var AllPriv = GetRolePriv();
                AllPriv.ForEach(o =>
                {
                    o.ROLE_NO = EditRolePrivList.First().PRIV_ROLE_NO;
                    o.ROLE_NAME = EditRolePrivList.First().ROLE_NAME;

                    o.HAVE_PRIV = EditRolePrivList.Any(x => x.FORM_NAME == o.FORM_NAME) ? EditRolePrivList.Where(x => x.FORM_NAME == o.FORM_NAME).First().HAVE_PRIV : false;
                    o.PRIV_DELETE = EditRolePrivList.Any(x => x.FORM_NAME == o.FORM_NAME) ? EditRolePrivList.Where(x => x.FORM_NAME == o.FORM_NAME).First().PRIV_DELETE : false;
                    o.PRIV_EXEC = EditRolePrivList.Any(x => x.FORM_NAME == o.FORM_NAME) ? EditRolePrivList.Where(x => x.FORM_NAME == o.FORM_NAME).First().PRIV_EXEC : false;
                    o.PRIV_INSERT = EditRolePrivList.Any(x => x.FORM_NAME == o.FORM_NAME) ? EditRolePrivList.Where(x => x.FORM_NAME == o.FORM_NAME).First().PRIV_INSERT : false;
                    o.PRIV_SELECT = EditRolePrivList.Any(x => x.FORM_NAME == o.FORM_NAME) ? EditRolePrivList.Where(x => x.FORM_NAME == o.FORM_NAME).First().PRIV_SELECT : false;
                    o.PRIV_UPDATE = EditRolePrivList.Any(x => x.FORM_NAME == o.FORM_NAME) ? EditRolePrivList.Where(x => x.FORM_NAME == o.FORM_NAME).First().PRIV_UPDATE : false;
                });

                EditRolePrivList = AllPriv;

                txtRoleNo.Text = EditRolePrivList.First().ROLE_NO;
                txtRoleName.Text = EditRolePrivList.First().ROLE_NAME;
                txtRoleNo.Properties.ReadOnly = true;
                txtRoleName.Focus();
            }
            else
            {
                EditRolePrivList = GetRolePriv();
                txtRoleNo.Focus();
            }

            this.Text = Text;
            gdc_RolePriv.DataSource = EditRolePrivList;
            gdv_RolePriv.BestFitColumns();
        }

        private void repositoryItemCheckEdit_CHK_ALL_CheckedChanged(object sender, EventArgs e)
        {
            string FormName = gdv_RolePriv.GetFocusedRowCellValue("FORM_NAME").ToString();

            int index = EditRolePrivList.FindIndex(item => item.FORM_NAME == FormName);

            var Item = EditRolePrivList.Where(o => o.FORM_NAME == FormName).FirstOrDefault();

            if (Item != null)
            {
                Item.PRIV_SELECT = Convert.ToBoolean(gdv_RolePriv.GetFocusedRowCellValue("CHK_ALL"));
                Item.PRIV_INSERT = Convert.ToBoolean(gdv_RolePriv.GetFocusedRowCellValue("CHK_ALL"));
                Item.PRIV_UPDATE = Convert.ToBoolean(gdv_RolePriv.GetFocusedRowCellValue("CHK_ALL"));
                Item.PRIV_DELETE = Convert.ToBoolean(gdv_RolePriv.GetFocusedRowCellValue("CHK_ALL"));
                Item.PRIV_EXEC = Convert.ToBoolean(gdv_RolePriv.GetFocusedRowCellValue("CHK_ALL"));

                EditRolePrivList[index] = Item;
            }
        }

        private void repositoryItemCheckEdit_CHK_ALL_CheckStateChanged(object sender, EventArgs e)
        {
            string FormName = gdv_RolePriv.GetFocusedRowCellValue("FORM_NAME").ToString();

            int index = EditRolePrivList.FindIndex(item => item.FORM_NAME == FormName);

            var Item = EditRolePrivList.Where(o => o.FORM_NAME == FormName).FirstOrDefault();

            if (Item != null)
            {
                Item.PRIV_SELECT = Convert.ToBoolean(gdv_RolePriv.GetFocusedRowCellValue("CHK_ALL"));
                Item.PRIV_INSERT = Convert.ToBoolean(gdv_RolePriv.GetFocusedRowCellValue("CHK_ALL"));
                Item.PRIV_UPDATE = Convert.ToBoolean(gdv_RolePriv.GetFocusedRowCellValue("CHK_ALL"));
                Item.PRIV_DELETE = Convert.ToBoolean(gdv_RolePriv.GetFocusedRowCellValue("CHK_ALL"));
                Item.PRIV_EXEC = Convert.ToBoolean(gdv_RolePriv.GetFocusedRowCellValue("CHK_ALL"));

                EditRolePrivList[index] = Item;
            }
        }

        private void repositoryItemButtonEdit_All_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string FormName = gdv_RolePriv.GetFocusedRowCellValue("FORM_NAME").ToString();

            int index = EditRolePrivList.FindIndex(item => item.FORM_NAME == FormName);

            var Item = EditRolePrivList.Where(o => o.FORM_NAME == FormName).FirstOrDefault();

            if (Item != null)
            {
                Item.PRIV_SELECT = true;
                Item.PRIV_INSERT = true;
                Item.PRIV_UPDATE = true;
                Item.PRIV_DELETE = true;
                Item.PRIV_EXEC = true;
                Item.HAVE_PRIV = true;

                EditRolePrivList[index] = Item;

                gdv_RolePriv.UpdateCurrentRow();
            }
        }

        private void repositoryItemButtonEdit_Cancel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string FormName = gdv_RolePriv.GetFocusedRowCellValue("FORM_NAME").ToString();

            int index = EditRolePrivList.FindIndex(item => item.FORM_NAME == FormName);

            var Item = EditRolePrivList.Where(o => o.FORM_NAME == FormName).FirstOrDefault();

            if (Item != null)
            {
                Item.PRIV_SELECT = false;
                Item.PRIV_INSERT = false;
                Item.PRIV_UPDATE = false;
                Item.PRIV_DELETE = false;
                Item.PRIV_EXEC = false;
                Item.HAVE_PRIV = false;

                EditRolePrivList[index] = Item;

                gdv_RolePriv.UpdateCurrentRow();
            }
        }

        /// <summary>
        /// 儲存按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult();

            if (MessageBox.Show(this, editMode == vPublic.EditMode.Add ? RM.GetString("AddMsgTitle2") : RM.GetString("EditMsgTitle2"), RM.GetString("MsgTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            result = SubmitResult();

            if (result.Successed)
            {
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
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = editMode == vPublic.EditMode.Add ? RM.GetString("AddSaveOk2") : RM.GetString("EditSaveOk2") };

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

                    strSql = "delete HRS_ROLE where ROLE_NO = @ROLE_NO ";
                    Cmd.CommandText = strSql;
                    Cmd.Parameters.Clear();

                    Cmd.Parameters.AddWithValue("ROLE_NO", txtRoleNo.Text.Trim());

                    int rtn = Cmd.ExecuteNonQuery();

                    strSql = "delete HRS_ROLE_PRIV where ROLE_NO = @ROLE_NO ";

                    Cmd.CommandText = strSql;
                    Cmd.Parameters.Clear();

                    Cmd.Parameters.AddWithValue("ROLE_NO", txtRoleNo.Text.Trim());

                    rtn = Cmd.ExecuteNonQuery();

                    strSql = "insert into HRS_ROLE (ROLE_NO, ROLE_NAME) values (@ROLE_NO, @ROLE_NAME) ";
                    Cmd.CommandText = strSql;
                    Cmd.Parameters.Clear();

                    Cmd.Parameters.AddWithValue("ROLE_NO", txtRoleNo.Text.Trim());
                    Cmd.Parameters.AddWithValue("ROLE_NAME", txtRoleName.Text.Trim());

                    rtn = Cmd.ExecuteNonQuery();

                    foreach (var Item in EditRolePrivList)
                    {
                        if (Item.HAVE_PRIV == false) continue;

                        strSql = "insert into HRS_ROLE_PRIV ( ROLE_NO, FORM_NAME, PRIV_SELECT, PRIV_INSERT, PRIV_UPDATE, PRIV_DELETE, PRIV_EXEC ) values "+
                                 "                          (@ROLE_NO,@FORM_NAME,@PRIV_SELECT,@PRIV_INSERT,@PRIV_UPDATE,@PRIV_DELETE,@PRIV_EXEC) ";
                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("ROLE_NO", txtRoleNo.Text.Trim());
                        Cmd.Parameters.AddWithValue("FORM_NAME", Item.FORM_NAME);
                        Cmd.Parameters.AddWithValue("PRIV_SELECT", Item.PRIV_SELECT == true ? "Y" : "N");
                        Cmd.Parameters.AddWithValue("PRIV_INSERT", Item.PRIV_INSERT == true ? "Y" : "N");
                        Cmd.Parameters.AddWithValue("PRIV_UPDATE", Item.PRIV_UPDATE == true ? "Y" : "N");
                        Cmd.Parameters.AddWithValue("PRIV_DELETE", Item.PRIV_DELETE == true ? "Y" : "N");
                        Cmd.Parameters.AddWithValue("PRIV_EXEC", Item.PRIV_EXEC == true ? "Y" : "N");

                        rtn = Cmd.ExecuteNonQuery();

                    }

                    string ErrorMessage = string.Empty;
                    //新增/修改角色權限資料-角色代號:{0}({1})
                    bool LogResult = vPublic.Insert_WMS_USER_OPR_HIST(Cmd, string.Format(editMode == vPublic.EditMode.Add ? RM.GetString("AddLog2") : RM.GetString("EditLog2"), txtRoleNo.Text, txtRoleName.Text), "Fm_S001", ref ErrorMessage);
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

        private void txtRoleNo_Validating(object sender, CancelEventArgs e)
        {
            if (this.ActiveControl.Equals(sender))
                return;

            if (string.IsNullOrEmpty((sender as DevExpress.XtraEditors.TextEdit).Text))
            {
                MessageBox.Show(this, RM.GetString("Notnull"), RM.GetString("MsgTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
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
    }
}
