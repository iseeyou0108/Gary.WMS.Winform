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
    public partial class Fm_HrsUnit : Form
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_S001", "FORM_BASIC"), System.Reflection.Assembly.GetExecutingAssembly());
        private vPublic.EditMode editMode { get; set; }
        private string Text { get; set; }
        private string EditUnitNo { get; set; }
        private string EditUnitName { get; set; }

        public Fm_HrsUnit()
        {
            InitializeComponent();
        }

        private void Fm_HrsUnit_Load(object sender, EventArgs e)
        {
            txtUnitNo.StyleController = Program.STYLER;
            txtUnitName.StyleController = Program.STYLER;

            if (editMode == vPublic.EditMode.Add)
            {
                txtUnitNo.Focus();
            }
            else if (editMode == vPublic.EditMode.Update)
            {
                txtUnitNo.Text = EditUnitNo;
                txtUnitName.Text = EditUnitName;
                txtUnitNo.Properties.ReadOnly = true;
                txtUnitName.Focus();
            }

            this.Text = Text;

        }

        public void SetEditMode(vPublic.EditMode _editMode)
        {
            editMode = _editMode;
        }

        public void SetText(string _Text)
        {
            Text = _Text;
        }

        public void SetEditModel(string _UnitNo, string _UnitName)
        {
            EditUnitNo = _UnitNo;
            EditUnitName = _UnitName;
        }

        /// <summary>
        /// Not null驗證
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInput_Validating(object sender, CancelEventArgs e)
        {
            if (this.ActiveControl.Equals(sender))
                return;

            if (string.IsNullOrEmpty((sender as DevExpress.XtraEditors.TextEdit).Text))
            {
                MessageBox.Show(this, RM.GetString("Notnull"), RM.GetString("MsgTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult();

            if (MessageBox.Show(this, editMode == vPublic.EditMode.Add ? RM.GetString("AddMsgTitle1") : RM.GetString("EditMsgTitle1"), RM.GetString("MsgTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
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
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = editMode == vPublic.EditMode.Add ? RM.GetString("AddSaveOk1") : RM.GetString("EditSaveOk1") };

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

                    strSql = "delete HRS_UNIT where UNIT_NO = @UNIT_NO ";
                    Cmd.CommandText = strSql;
                    Cmd.Parameters.Clear();

                    Cmd.Parameters.AddWithValue("UNIT_NO", txtUnitNo.Text.Trim());

                    int rtn = Cmd.ExecuteNonQuery();



                    strSql = "insert into HRS_UNIT (UNIT_NO, UNIT_NAME) values (@UNIT_NO, @UNIT_NAME) ";
                    Cmd.CommandText = strSql;
                    Cmd.Parameters.Clear();

                    Cmd.Parameters.AddWithValue("UNIT_NO", txtUnitNo.Text.Trim());
                    Cmd.Parameters.AddWithValue("UNIT_NAME", txtUnitName.Text.Trim());

                    rtn = Cmd.ExecuteNonQuery();

                    string ErrorMessage = string.Empty;
                    //新增/修改角色權限資料-角色代號:{0}({1})
                    bool LogResult = vPublic.Insert_WMS_USER_OPR_HIST(Cmd, string.Format(editMode == vPublic.EditMode.Add ? RM.GetString("AddLog1") : RM.GetString("EditLog1"), txtUnitNo.Text, txtUnitName.Text), "Fm_S001", ref ErrorMessage);
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
