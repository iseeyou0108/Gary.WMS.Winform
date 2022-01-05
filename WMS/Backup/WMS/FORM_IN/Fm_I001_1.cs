using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS
{
    public partial class Fm_I001_1 : Form
    {
        // 多國語言資源檔設定
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_I001", "FORM_IN"), System.Reflection.Assembly.GetExecutingAssembly());

        List<Model.WmsInLine> InLines = new List<WMS.Model.WmsInLine>();
        Service.WmsListService ListService = new WMS.Service.WmsListService();

        public Fm_I001_1()
        {
            InitializeComponent();
        }

        private void Fm_I001_1_Load(object sender, EventArgs e)
        {
            vPublic.GetListCtrItems(cmbListCtr);
            vPublic.GetListStatusCtrItems(cmbStatusCtr);
            vPublic.GetWmsProdItems(repositoryItemLookUpEdit_ProdNo, "", true);
            vPublic.GetWmsOrgItems(repositoryItemLookUpEdit_OrgNo, "");

            cmbListCtr.EditValue = vPublic.ListCtr.入庫單據;
            cmbStatusCtr.EditValue = vPublic.StatusCtr.接單;

            cmbListCtr.Enabled = false;
            cmbStatusCtr.Enabled = false;

            txtErpListNo.StyleController = Program.STYLER;
            txtErpListType.StyleController = Program.STYLER;
            txtListNo.StyleController = Program.STYLER;
            cmbListCtr.StyleController = Program.STYLER;
            cmbStatusCtr.StyleController = Program.STYLER;

            InLines = new List<WMS.Model.WmsInLine>();
            gdc_WMS_IN_LINE.DataSource = InLines;
            
        }

        private void txtInput_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            InLines.Add(new Model.WmsInLine() { LINE_ID = InLines.Count + 1 });

            gdv_WMS_IN_LINE.AddNewRow();
            gdv_WMS_IN_LINE.BeginUpdate();
            gdv_WMS_IN_LINE.UpdateCurrentRow();
            gdv_WMS_IN_LINE.EndUpdate();
        }


        private void gdv_WMS_OUT_LINE_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "PROD_NO")
            {
                var Row = repositoryItemLookUpEdit_ProdNo.GetDataSourceRowByDisplayValue(gdv_WMS_IN_LINE.GetFocusedRowCellValue("PROD_NO").ToString()) as DataRowView;
                gdv_WMS_IN_LINE.SetFocusedRowCellValue("PROD_NAME", Row["PROD_NAME"].ToString());
                gdv_WMS_IN_LINE.SetFocusedRowCellValue("UN", Row["UN"].ToString());
                gdv_WMS_IN_LINE.UpdateCurrentRow();
            }

            if (e.Column.FieldName == "ORG_NO")
            {
                var Row = repositoryItemLookUpEdit_OrgNo.GetDataSourceRowByDisplayValue(gdv_WMS_IN_LINE.GetFocusedRowCellValue("ORG_NO").ToString()) as DataRowView;
                gdv_WMS_IN_LINE.SetFocusedRowCellValue("SNAME", Row["SNAME"].ToString());
                gdv_WMS_IN_LINE.UpdateCurrentRow();
            }
        }

        private void txtListNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtListNo.Text = ListService.GenListNo("I");
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
                Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region 防呆
            if (string.IsNullOrEmpty(txtListNo.Text))
            {
                txtListNo.Focus();
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Notnull"));
                return;
            }

            if (InLines.Count <= 0)
            {
                //尚未新增任何單據明細，無法儲存
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0001"));
                return;
            }

            var NullProdNos = InLines.Where(o => string.IsNullOrEmpty(o.PROD_NO)).ToList();

            if (NullProdNos != null)
            {
                if (NullProdNos.Count > 0)
                {
                    gdv_WMS_IN_LINE.FocusedRowHandle = InLines.IndexOf(NullProdNos.First());
                    gdv_WMS_IN_LINE.FocusedColumn = colPROD_NO;
                    //項次{0}, 尚未選取料號，無法儲存
                    vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, string.Format(RM.GetString("Msg0002"), NullProdNos.First().LINE_ID));
                    return;
                }
            }

            var QtyValidate = InLines.Where(o => o.QTY <= 0).ToList();

            if (QtyValidate != null)
            {
                if (QtyValidate.Count > 0)
                {
                    gdv_WMS_IN_LINE.FocusedRowHandle = InLines.IndexOf(QtyValidate.First());
                    gdv_WMS_IN_LINE.FocusedColumn = colPROD_NO;
                    //項次{0}, 數量不可<=0
                    vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, string.Format(RM.GetString("Msg0003"), QtyValidate.First().LINE_ID));
                    return;
                }
            }

            #endregion

            foreach (var Item in InLines)
            {
                Item.LIST_NO = txtListNo.Text.Trim();
                Item.ERP_LIST_NO = txtErpListNo.Text.Trim();
                Item.ERP_LIST_TYPE = txtErpListType.Text.Trim();
                Item.LIST_CTR = (vPublic.ListCtr)cmbListCtr.EditValue;
                Item.STATUS_CTR = (vPublic.StatusCtr)cmbStatusCtr.EditValue;
            }

            if (MessageBox.Show(this, RM.GetString("ConfirmAddMessage"), RM.GetString("MsgTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            var result = ListService.CreateWmsInListData(InLines);
            vPublic.ShowAlert(result.Successed == false ? Fm_Alert.AlertType.Error : Fm_Alert.AlertType.Successful
                              , result.Message);

            if (result.Successed)
            {
                InLines = new List<WMS.Model.WmsInLine>();
                gdc_WMS_IN_LINE.DataSource = InLines;
                txtErpListNo.Text = string.Empty;
                txtErpListType.Text = string.Empty;
                txtListNo.Text = string.Empty;
                //Close();
            }
        }

        private void repositoryItemButtonEdit_Delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //OutLines.RemoveAt(gdv_WMS_OUT_LINE.FocusedRowHandle);
            gdv_WMS_IN_LINE.DeleteRow(gdv_WMS_IN_LINE.FocusedRowHandle);

            foreach (var Item in InLines)
            {
                Item.LINE_ID = InLines.IndexOf(Item) + 1;
            }
        }
    }
}
