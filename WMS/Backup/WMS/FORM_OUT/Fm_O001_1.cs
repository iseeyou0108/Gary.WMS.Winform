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
    public partial class Fm_O001_1 : Form
    {
        // 多國語言資源檔設定
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_O001", "FORM_OUT"), System.Reflection.Assembly.GetExecutingAssembly());

        List<Model.WmsOutLine> OutLines = new List<WMS.Model.WmsOutLine>();
        Service.WmsListService ListService = new WMS.Service.WmsListService();

        public Fm_O001_1()
        {
            InitializeComponent();
        }

        private void Fm_O001_1_Load(object sender, EventArgs e)
        {
            vPublic.GetListCtrItems(cmbListCtr);
            vPublic.GetListStatusCtrItems(cmbStatusCtr);
            vPublic.GetWmsProdItems(repositoryItemLookUpEdit_ProdNo, "", true);
            vPublic.GetWmsOrgItems(repositoryItemLookUpEdit_OrgNo, "");

            cmbListCtr.EditValue = vPublic.ListCtr.出庫單據;
            cmbStatusCtr.EditValue = vPublic.StatusCtr.接單;

            cmbListCtr.Enabled = false;
            cmbStatusCtr.Enabled = false;

            txtErpListNo.StyleController = Program.STYLER;
            txtErpListType.StyleController = Program.STYLER;
            txtListNo.StyleController = Program.STYLER;
            cmbListCtr.StyleController = Program.STYLER;
            cmbStatusCtr.StyleController = Program.STYLER;

            OutLines = new List<WMS.Model.WmsOutLine>();
            gdc_WMS_OUT_LINE.DataSource = OutLines;
            
        }

        private void txtInput_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            OutLines.Add(new Model.WmsOutLine() { LINE_ID = OutLines.Count + 1 });

            gdv_WMS_OUT_LINE.AddNewRow();
            gdv_WMS_OUT_LINE.BeginUpdate();
            gdv_WMS_OUT_LINE.UpdateCurrentRow();
            gdv_WMS_OUT_LINE.EndUpdate();
        }


        private void gdv_WMS_OUT_LINE_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "PROD_NO")
            {
                var Row = repositoryItemLookUpEdit_ProdNo.GetDataSourceRowByDisplayValue(gdv_WMS_OUT_LINE.GetFocusedRowCellValue("PROD_NO").ToString()) as DataRowView;
                gdv_WMS_OUT_LINE.SetFocusedRowCellValue("PROD_NAME", Row["PROD_NAME"].ToString());
                gdv_WMS_OUT_LINE.SetFocusedRowCellValue("UN", Row["UN"].ToString());
                gdv_WMS_OUT_LINE.UpdateCurrentRow();
            }

            if (e.Column.FieldName == "ORG_NO")
            {
                var Row = repositoryItemLookUpEdit_OrgNo.GetDataSourceRowByDisplayValue(gdv_WMS_OUT_LINE.GetFocusedRowCellValue("ORG_NO").ToString()) as DataRowView;
                gdv_WMS_OUT_LINE.SetFocusedRowCellValue("SNAME", Row["SNAME"].ToString());
                gdv_WMS_OUT_LINE.UpdateCurrentRow();
            }
        }

        private void txtListNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            
            txtListNo.Text = ListService.GenListNo("O");
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

            if (OutLines.Count <= 0)
            {
                //尚未新增任何單據明細，無法儲存
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0001"));
                return;
            }

            var NullProdNos = OutLines.Where(o => string.IsNullOrEmpty(o.PROD_NO)).ToList();

            if (NullProdNos != null)
            {
                if (NullProdNos.Count > 0)
                {
                    gdv_WMS_OUT_LINE.FocusedRowHandle = OutLines.IndexOf(NullProdNos.First());
                    gdv_WMS_OUT_LINE.FocusedColumn = colPROD_NO;
                    //項次{0}, 尚未選取料號，無法儲存
                    vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, string.Format(RM.GetString("Msg0002"), NullProdNos.First().LINE_ID));
                    return;
                }
            }

            var QtyValidate = OutLines.Where(o => o.QTY <= 0).ToList();

            if (QtyValidate != null)
            {
                if (QtyValidate.Count > 0)
                {
                    gdv_WMS_OUT_LINE.FocusedRowHandle = OutLines.IndexOf(QtyValidate.First());
                    gdv_WMS_OUT_LINE.FocusedColumn = colPROD_NO;
                    //項次{0}, 數量不可<=0
                    vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, string.Format(RM.GetString("Msg0003"), QtyValidate.First().LINE_ID));
                    return;
                }
            }

            #endregion

            foreach (var Item in OutLines)
            {
                Item.LIST_NO = txtListNo.Text.Trim();
                Item.ERP_LIST_NO = txtErpListNo.Text.Trim();
                Item.ERP_LIST_TYPE = txtErpListType.Text.Trim();
                Item.LIST_CTR = (vPublic.ListCtr)cmbListCtr.EditValue;
                Item.STATUS_CTR = (vPublic.StatusCtr)cmbStatusCtr.EditValue;
            }

            if (MessageBox.Show(this, RM.GetString("ConfirmAddMessage"), RM.GetString("MsgTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            var result = ListService.CreateWmsOutListData(OutLines);
            vPublic.ShowAlert(result.Successed == false ? Fm_Alert.AlertType.Error : Fm_Alert.AlertType.Successful
                              , result.Message);

            if (result.Successed)
            {
                OutLines = new List<WMS.Model.WmsOutLine>();
                gdc_WMS_OUT_LINE.DataSource = OutLines;
                txtErpListNo.Text = string.Empty;
                txtErpListType.Text = string.Empty;
                txtListNo.Text = string.Empty;
                //Close();
            }
        }

        private void repositoryItemButtonEdit_Delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //OutLines.RemoveAt(gdv_WMS_OUT_LINE.FocusedRowHandle);
            gdv_WMS_OUT_LINE.DeleteRow(gdv_WMS_OUT_LINE.FocusedRowHandle);

            foreach (var Item in OutLines)
            {
                Item.LINE_ID = OutLines.IndexOf(Item) + 1;
            }
        }
    }
}
