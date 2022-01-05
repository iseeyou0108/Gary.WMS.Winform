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
    public partial class Fm_Q010 : Form
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_Q010", "FORM_QUERY"), System.Reflection.Assembly.GetExecutingAssembly());

        public class QcResultItem 
        {
            public Model.WmsStk.QCResult QC_RESULT { get; set; }
            public string QC_RESULT_DESC { get; set; }
        }

        public Fm_Q010()
        {
            InitializeComponent();
        }

        private void Fm_Q010_Load(object sender, EventArgs e)
        {
            vPublic.GetAsrsIDItems(cmbAsrsID);
            vPublic.GetWmsProdItems(cmbProdNo, "");
            SET_PRIV();

            txtFilter.StyleController = Program.STYLER;
            cmbProdNo.StyleController = Program.STYLER;
            cmbAsrsID.StyleController = Program.STYLER;

            vPublic.RestoreViewLayoutByStream(gdv_WMS_STK, this.Name, 1,true);

            RefreshData("");
        }

        private void SET_PRIV()
        {
            var FormPriv = vPublic.GetFormPriv(this.Name);
            btn_Insert.Visible = FormPriv.Add;
            colDelete.Visible = FormPriv.Delete;
            colEdit.Visible = FormPriv.Edit;
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            RefreshData(txtFilter.Text);
        }

        private void RefreshData(string SearchText)
        {
            Model.WmsStk StkLib = new WMS.Model.WmsStk();
            List<Model.WmsStk> Data = new List<WMS.Model.WmsStk>();

            var result = StkLib.GetAllWmsStk(Convert.ToInt16(cmbAsrsID.EditValue), ref Data);
            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

            Data = Data.Where(o => o.STUS_CTR == (decimal)Model.WmsStk.StusCtr.待驗庫存
                                || o.STUS_CTR == (decimal)Model.WmsStk.StusCtr.可用庫存)
                                .ToList();

            if (!string.IsNullOrEmpty(SearchText))
            {
                Data = Data.Where(o => (o.PROD_NO ?? string.Empty).Contains(SearchText) ||
                    (o.BIN_NO ?? string.Empty).Contains(SearchText) ||
                    (o.PROD_TYPE_DESC ?? string.Empty).Contains(SearchText) ||
                    (o.PROD_NAME ?? string.Empty).Contains(SearchText) ||
                    (o.LOT_NO ?? string.Empty).Contains(SearchText) ||
                    (o.UN ?? string.Empty).Contains(SearchText) ||
                    (o.STUS_CTR_DESC ?? string.Empty).Contains(SearchText) ||
                    (o.ORG_SNAME ?? string.Empty).Contains(SearchText) ||
                    (o.ORG_NO ?? string.Empty).Contains(SearchText)
                    ).ToList();   
            }

            if (cmbProdNo.EditValue != null)
            {
                Data = Data.Where(o => (o.PROD_NO ?? string.Empty) == cmbProdNo.EditValue.ToString()).ToList();
            }

            gdc_WMS_STK.DataSource = Data;
        }

        private void txtFilter_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            RefreshData(txtFilter.Text);
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
                RefreshData(txtFilter.Text);
        }

        private void btnColumnSet_Click(object sender, EventArgs e)
        {
            List<DevExpress.XtraGrid.Columns.GridColumn> EditColumns = new List<DevExpress.XtraGrid.Columns.GridColumn>() { 
                colDelete,
                colEdit
            };

            System.IO.Stream layoutStream = new System.IO.MemoryStream();
            gdv_WMS_STK.SaveLayoutToStream(layoutStream, DevExpress.Utils.OptionsLayoutBase.FullLayout);

            FORM_PUBLIC.Fm_SetGridviewColumns EditForm = new WMS.FORM_PUBLIC.Fm_SetGridviewColumns(gdv_WMS_STK, EditColumns, this.Name, layoutStream);
            layoutStream.Seek(0, System.IO.SeekOrigin.Begin);

            if (EditForm.ShowDialog() == DialogResult.Yes)
            {
                vPublic.RestoreViewLayoutByStream(gdv_WMS_STK, this.Name, 1, false);
            }
        }

        private void cmbProdNo_KeyUp(object sender, KeyEventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit edit = sender as DevExpress.XtraEditors.LookUpEdit;
            if (e.KeyCode == Keys.Delete)
            {
                edit.ClosePopup();
                edit.EditValue = null;
            }
            e.Handled = true;  
        }

        private void gdv_WMS_STK_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (gdv_WMS_STK.IsValidRowHandle(e.RowHandle) == false) return;
            if (e.RowHandle < 0) return;
            if (e.RowHandle == DevExpress.XtraGrid.GridControl.AutoFilterRowHandle) return;
            
            if (e.Column.FieldName == "STUS_CTR_DESC")
            {
                var StusCtr = int.Parse(gdv_WMS_STK.GetRowCellValue(e.RowHandle, "STUS_CTR").ToString());
                if (StusCtr == Convert.ToInt16(Model.WmsStk.StusCtr.待驗庫存))
                {
                    //e.Graphics.DrawImageUnscaled(Properties.Resources.Important_16, e.Bounds.X + 1, e.Bounds.Y);
                    e.Appearance.BackColor = Color.FromArgb(217, 83, 79);
                    e.Appearance.ForeColor = Color.WhiteSmoke;
                }
            }
        }

        private void repositoryItemButtonEdit_Delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            List<Model.WmsStk> Stks = (List<Model.WmsStk>)gdc_WMS_STK.DataSource;
            Model.WmsStk StkService = new WMS.Model.WmsStk();

            var Item = Stks.Where(o => o.FIFO_NO == gdv_WMS_STK.GetFocusedRowCellValue("FIFO_NO").ToString()).First();

            string ConfirmMessage = string.Empty;
            //確定要刪除選取的庫存資料?{0}儲位代號:{1}, 料號:{2}({3})
            ConfirmMessage = string.Format(RM.GetString("DeleteConfirmMessage"), Environment.NewLine, Item.BIN_NO, Item.PROD_NO, Item.PROD_NAME);

            if (MessageBox.Show(this, ConfirmMessage, RM.GetString("MsgTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;


            var result = StkService.Delete(Stks.Where(o => o.FIFO_NO == Item.FIFO_NO).ToList());
            vPublic.ShowAlert(result.Successed == false ? Fm_Alert.AlertType.Error : Fm_Alert.AlertType.Successful
                              , result.Message);
            if (result.Successed)
                btn_Select_Click(null, null);
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            Fm_Q010_1 objForm = new Fm_Q010_1(vPublic.EditMode.Add, new List<WMS.Model.WmsStk>());
            objForm.StartPosition = FormStartPosition.CenterParent;
            if (objForm.ShowDialog() == DialogResult.OK)
                RefreshData(txtFilter.Text);
        }

        private void repositoryItemButtonEdit_Edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var EditStks = (List<Model.WmsStk>)gdc_WMS_STK.DataSource;
            var CurItem = EditStks.Where(o => o.FIFO_NO == gdv_WMS_STK.GetFocusedRowCellValue("FIFO_NO").ToString()).First();

            //取得選取的庫位的庫存
            EditStks = EditStks.Where(o => o.AREA_NO == CurItem.AREA_NO &&
                                            o.WH_NO == CurItem.WH_NO &&
                                            o.ASRS_ID == CurItem.ASRS_ID &&
                                            o.BIN_NO == CurItem.BIN_NO).ToList();
            Fm_Q010_1 objForm = new Fm_Q010_1(vPublic.EditMode.Update, EditStks);
            objForm.StartPosition = FormStartPosition.CenterParent;
            objForm.ShowDialog();

            RefreshData(txtFilter.Text);
        }
    }
}
