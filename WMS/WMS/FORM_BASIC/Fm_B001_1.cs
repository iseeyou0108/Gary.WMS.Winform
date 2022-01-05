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
    public partial class Fm_B001_1 : Form
    {
        // 多國語言資源檔設定
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_B001", "FORM_BASIC"), System.Reflection.Assembly.GetExecutingAssembly());


        private vPublic.EditMode editMode { get; set; }
        private Fm_B001.WMS_PROD WmsProd { get; set; }
        private List<Fm_B001.WMS_PROD> WmsProds { get; set; }
        private Fm_B001.WMS_PROD PreWmsProd { get; set; }
                    

        public Fm_B001_1()
        {
            InitializeComponent();
        }

        private void Fm_B001_1_Load(object sender, EventArgs e)
        {
            
            #region SetStyle

            txtProdNo.StyleController = Program.STYLER;
            txtSpec.StyleController = Program.STYLER;
            txtProdName.StyleController = Program.STYLER;
            txtKind.StyleController = Program.STYLER;
            txtFullQty.StyleController = Program.STYLER;
            txtRemark.StyleController = Program.STYLER;
            txtUn.StyleController = Program.STYLER;
            

            #endregion

            if (editMode == vPublic.EditMode.Update)
            {
                BindEditControl();
                PreWmsProd = new Fm_B001.WMS_PROD();
                BindModal(PreWmsProd);
                txtProdNo.Properties.ReadOnly = true;
                txtProdName.Focus();
            }
            else
            {
                layoutControlGroup_Record.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;                
                txtProdNo.Properties.ReadOnly = false;
                txtProdNo.Focus();
            }
        }

        public void SetModal(Fm_B001.WMS_PROD _WmsOrg, List<Fm_B001.WMS_PROD> _WmsOrgs)
        {
            WmsProd = _WmsOrg;
            WmsProds = new List<Fm_B001.WMS_PROD>();
            WmsProds = _WmsOrgs;
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

            if (string.IsNullOrEmpty(txtProdNo.Text))
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
            BindModal(WmsProd);

            #region 防呆檢查
            if (editMode == vPublic.EditMode.Add)
            {
                var checkResult = WmsProd.CheckAddExist();

                if (checkResult.Successed == false)
                {
                    vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString(checkResult.Message));
                    //MessageBox.Show(this, RM.GetString(checkResult.Message), RM.GetString("MsgTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            #endregion

            string ConfirmMessage = string.Empty;

            ConfirmMessage = editMode == vPublic.EditMode.Add ? RM.GetString("AddDialogSaveMsg") : string.Format(RM.GetString("EditDialogSaveMsg"), WmsProd.PROD_NO, WmsProd.PROD_NAME);

            if (MessageBox.Show(this, ConfirmMessage, RM.GetString("MsgTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            SqlConnection Conn = new SqlConnection(vPublic.ConnStr);
            try
            {
                Conn.Open();
            }
            catch (SqlException ex)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, ex.Message);
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
                        strSql = "insert into WMS_PROD (PROD_NO, PROD_NAME, SPEC, UN, FULL_QTY, VALID_FLG, KIND, SOURCE_CODE," +
                                 "                     REMARK, CREATE_DATE, CREATE_BY, UPDATE_DATE, UPDATE_BY ) " +
                                 "            values (@PROD_NO,@PROD_NAME,@SPEC,@UN,@FULL_QTY,@VALID_FLG,@KIND,@SOURCE_CODE," +
                                 "                    @REMARK,@CREATE_DATE,@CREATE_BY,@UPDATE_DATE,@UPDATE_BY) ";
                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("PROD_NO", WmsProd.PROD_NO);
                        Cmd.Parameters.AddWithValue("PROD_NAME", WmsProd.PROD_NAME);
                        Cmd.Parameters.AddWithValue("UN", WmsProd.UN);
                        Cmd.Parameters.AddWithValue("SPEC", (object)WmsProd.SPEC ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("FULL_QTY", (object)WmsProd.FULL_QTY ?? 0);
                        Cmd.Parameters.AddWithValue("VALID_FLG", (object)WmsProd.VALID_FLG ?? "N");
                        Cmd.Parameters.AddWithValue("KIND", (object)WmsProd.KIND ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("SOURCE_CODE", (object)WmsProd.SOURCE_CODE ?? "0");
                        Cmd.Parameters.AddWithValue("REMARK", (object)WmsProd.REMARK ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_DATE", (object)WmsProd.CREATE_DATE ?? DateTime.Now);
                        Cmd.Parameters.AddWithValue("CREATE_BY", (object)WmsProd.CREATE_BY ?? Program.wmsUser.UserNo);
                        Cmd.Parameters.AddWithValue("UPDATE_DATE", (object)WmsProd.UPDATE_DATE ?? DateTime.Now);
                        Cmd.Parameters.AddWithValue("UPDATE_BY", (object)WmsProd.UPDATE_BY ?? Program.wmsUser.UserNo);

                        int rtn = Cmd.ExecuteNonQuery();

                        string ErrorMessage = string.Empty;
                        //新增客戶基本檔資料-客戶代號:{0}({1})
                        bool LogResult = vPublic.Insert_WMS_USER_OPR_HIST(Cmd, string.Format(RM.GetString("AddLog"), WmsProd.PROD_NO, WmsProd.PROD_NAME), "Fm_B001", ref ErrorMessage);
                        if (!LogResult)
                            throw new Exception(ErrorMessage);
                    }
                    else
                    {
                        strSql = "update WMS_PROD set PROD_NAME = @PROD_NAME, " +
                                 "                   SPEC = @SPEC, " +
                                 "                   UN = @UN, " +
                                 "                   FULL_QTY = @FULL_QTY, " +
                                 "                   KIND = @KIND, " +
                                 "                   REMARK = @REMARK, " +
                                 "                   UPDATE_DATE = @UPDATE_DATE, " +
                                 "                   UPDATE_BY = @UPDATE_BY " +
                                 "where PROD_NO = @PROD_NO ";

                        Cmd.CommandText = strSql;
                        
                        Cmd.Parameters.AddWithValue("PROD_NAME", WmsProd.PROD_NAME);
                        Cmd.Parameters.AddWithValue("SPEC", (object)WmsProd.SPEC ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UN", WmsProd.UN);
                        Cmd.Parameters.AddWithValue("FULL_QTY", (object)WmsProd.FULL_QTY ?? 0);
                        Cmd.Parameters.AddWithValue("KIND", (object)WmsProd.KIND ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("REMARK", (object)WmsProd.REMARK ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("UPDATE_DATE", (object)WmsProd.UPDATE_DATE ?? DateTime.Now);
                        Cmd.Parameters.AddWithValue("UPDATE_BY", (object)WmsProd.UPDATE_BY ?? Program.wmsUser.UserNo);
                        Cmd.Parameters.AddWithValue("PROD_NO", WmsProd.PROD_NO);

                        int rtn = Cmd.ExecuteNonQuery();

                        //修改物料基本檔資料-物料代號:{0}, 物料名稱:{1}->{2}, 庫存單位:{3}->{4}, 規格:{5}->{6}, 滿板數量:{7}->{8}, 儲位存放類型:{9}->{10}
                        string ErrorMessage = string.Empty;
                        
                        bool LogResult = vPublic.Insert_WMS_USER_OPR_HIST(Cmd, string.Format(RM.GetString("EditLog"), WmsProd.PROD_NO,
                            PreWmsProd.PROD_NAME, WmsProd.PROD_NAME,
                            PreWmsProd.UN, WmsProd.UN,
                            PreWmsProd.SPEC, WmsProd.SPEC,
                            PreWmsProd.FULL_QTY, WmsProd.FULL_QTY,
                            PreWmsProd.KIND, WmsProd.KIND), "Fm_B001", ref ErrorMessage);
                        if (!LogResult)
                            throw new Exception(ErrorMessage);
                    }

                    trans.Commit();
                    Cmd.Dispose();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    vPublic.ShowAlert(Fm_Alert.AlertType.Error, ex.Message);
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
                WmsProd = new Fm_B001.WMS_PROD();
                BindEditControl();
            }
        }


        private void BindModal(Fm_B001.WMS_PROD _WmsProd)
        {
            _WmsProd.PROD_NO = txtProdNo.Text.Trim();
            _WmsProd.PROD_NAME = txtProdName.Text.Trim();
            _WmsProd.SPEC = txtSpec.Text.Trim();
            _WmsProd.UN = txtUn.Text.Trim();
            if (!string.IsNullOrEmpty(txtFullQty.Text.Trim()))
                _WmsProd.FULL_QTY = decimal.Parse(txtFullQty.Text.Trim());
            else
                _WmsProd.FULL_QTY = 0;

            _WmsProd.KIND = txtKind.Text.Trim();
            if (editMode == vPublic.EditMode.Add)
                _WmsProd.SOURCE_CODE = "0";
            _WmsProd.REMARK = txtRemark.Text.Trim();
            _WmsProd.UPDATE_BY = Program.wmsUser.UserNo;
            _WmsProd.UPDATE_DATE = DateTime.Now;
        }

        private void BindEditControl()
        {
            txtProdNo.Text = WmsProd.PROD_NO;
            txtSpec.Text = WmsProd.SPEC;
            txtProdName.Text = WmsProd.PROD_NAME;
            txtUn.Text = WmsProd.UN;
            txtFullQty.Text = WmsProd.FULL_QTY.ToString();
            txtKind.Text = WmsProd.KIND;
            txtRemark.Text = WmsProd.REMARK;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var NextModel = WmsProds.SkipWhile(item => item.PROD_NO != WmsProd.PROD_NO).Skip(1).DefaultIfEmpty(WmsProds[0]).FirstOrDefault();

            WmsProd = NextModel;

            BindEditControl();
            PreWmsProd = new Fm_B001.WMS_PROD();
            BindModal(PreWmsProd);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            var LastModel = WmsProds.TakeWhile(x => x.PROD_NO != WmsProd.PROD_NO).DefaultIfEmpty(WmsProds[WmsProds.Count - 1]).LastOrDefault();

            WmsProd = LastModel;

            BindEditControl();
            PreWmsProd = new Fm_B001.WMS_PROD();
            BindModal(PreWmsProd);
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
