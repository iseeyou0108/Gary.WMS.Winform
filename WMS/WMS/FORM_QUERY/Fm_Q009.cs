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
    public partial class Fm_Q009 : Form
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_Q009", "FORM_QUERY"), System.Reflection.Assembly.GetExecutingAssembly());

        public class QcResultItem 
        {
            public Model.WmsStk.QCResult QC_RESULT { get; set; }
            public string QC_RESULT_DESC { get; set; }
        }

        public Fm_Q009()
        {
            InitializeComponent();
        }

        private void Fm_Q009_Load(object sender, EventArgs e)
        {
            vPublic.GetAsrsIDItems(cmbAsrsID);
            vPublic.GetWmsProdItems(cmbProdNo, "");
            InitialQcResultCmb();
            SET_PRIV();

            txtFilter.StyleController = Program.STYLER;
            cmbProdNo.StyleController = Program.STYLER;
            cmbAsrsID.StyleController = Program.STYLER;

            vPublic.RestoreViewLayoutByStream(gdv_WMS_STK, this.Name, 1,true);

            RefreshData("");
        }

        private void InitialQcResultCmb()
        {
            List<QcResultItem> Items = new List<QcResultItem>()
             {
                 new QcResultItem()
                 {
                    QC_RESULT= WMS.Model.WmsStk.QCResult.合格,
                    QC_RESULT_DESC=RM.GetString("QCResult1")
                 },
                 new QcResultItem()
                 {
                    QC_RESULT= WMS.Model.WmsStk.QCResult.不合格,
                    QC_RESULT_DESC=RM.GetString("QCResult2")
                 },
                 new QcResultItem()
                 {
                    QC_RESULT= WMS.Model.WmsStk.QCResult.劣品,
                    QC_RESULT_DESC=RM.GetString("QCResult3")
                 },
                 new QcResultItem()
                 {
                    QC_RESULT= WMS.Model.WmsStk.QCResult.良品,
                    QC_RESULT_DESC=RM.GetString("QCResult4")
                 },
                 new QcResultItem()
                 {
                    QC_RESULT= WMS.Model.WmsStk.QCResult.待退,
                    QC_RESULT_DESC=RM.GetString("QCResult5")
                 }
             };

            cmbQCResult.Properties.DataSource = Items;
            cmbQCResult.Properties.DropDownRows = Items.Count;
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

            var result = StkLib.GetAllWmsStk(Convert.ToInt16(cmbAsrsID.EditValue), WMS.Model.WmsStk.ProdType.成品_原物料, ref Data);
            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

            Data = Data.Where(o => o.STUS_CTR == (decimal)Model.WmsStk.StusCtr.待驗庫存).ToList();

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

        private void btnExec_Click(object sender, EventArgs e)
        {

            if (gdc_WMS_STK.DataSource == null) return;
            if (gdv_WMS_STK.RowCount <= 0) return;

            var StkList = ((List<Model.WmsStk>)gdc_WMS_STK.DataSource).Where(o => o.CHK == true).ToList();

            if (StkList == null)
            {
                //請先勾選要執行質檢結果輸入的庫存
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, RM.GetString("Msg0001"));
                return;
            }

            if (StkList.Count <= 0)
            {
                //請先勾選要執行質檢結果輸入的庫存
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, RM.GetString("Msg0001"));
                return;
            }

            if (cmbQCResult.EditValue == null)
            {
                //請選取質檢結果
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, RM.GetString("Msg0002"));
                return;
            }

            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = "" };
            Model.WmsStk StkService = new WMS.Model.WmsStk();


            result = StkService.QCResultInput(StkList, (WMS.Model.WmsStk.QCResult)cmbQCResult.EditValue);

            if (result.Successed)
            {
                cmbQCResult.EditValue = null;
                RefreshData("");
            }
            else
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }
        }
    }
}
