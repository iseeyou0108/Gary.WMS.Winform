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
    public partial class Fm_Q004 : Form
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_Q004", "FORM_QUERY"), System.Reflection.Assembly.GetExecutingAssembly());
        public Fm_Q004()
        {
            InitializeComponent();
        }

        private void Fm_Q004_Load(object sender, EventArgs e)
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

            if (!string.IsNullOrEmpty(SearchText))
            {
                Data = Data.Where(o => (o.PROD_NO ?? string.Empty).Contains(SearchText) ||
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = string.Format("{0}_{1}", RM.GetString("ExcellFilename"), DateTime.Now.ToString("yyyyMMddHHmmss"));
            sfd.Filter = "Excel |*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gdv_WMS_STK.ExportToXlsx(sfd.FileName);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            gdc_WMS_STK.ShowPrintPreview();
            //REPORT.XtraReport1 rpt = new WMS.REPORT.XtraReport1();
            //rpt.ShowPreview();
        }

        private void btnColumnSet_Click(object sender, EventArgs e)
        {
            List<DevExpress.XtraGrid.Columns.GridColumn> EditColumns = new List<DevExpress.XtraGrid.Columns.GridColumn>();

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
    }
}
