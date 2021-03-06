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
    public partial class Fm_Q005 : Form
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_Q005", "FORM_QUERY"), System.Reflection.Assembly.GetExecutingAssembly());
        public Fm_Q005()
        {
            InitializeComponent();
        }

        private void Fm_Q005_Load(object sender, EventArgs e)
        {
            vPublic.GetAsrsIDItems(cmbAsrsID);
            cmbAsrsID.StyleController = Program.STYLER;
            dateEditSdate.EditValue = DateTime.Now.AddDays(-14);
            dateEditEdate.EditValue = DateTime.Now.AddDays(-1);

            cmbAsrsID.StyleController = Program.STYLER;
            txtFilter.StyleController = Program.STYLER;
            dateEditSdate.StyleController = Program.STYLER;
            dateEditEdate.StyleController = Program.STYLER;

            vPublic.RestoreViewLayoutByStream(gdv_WCS_TRK_LOG, this.Name, 1, true);

            RefreshData();

            
        }

        private void RefreshData()
        {
            Service.WcsTrkLogService service = new WMS.Service.WcsTrkLogService();
            List<Model.WcsTrkLog> Data = new List<WMS.Model.WcsTrkLog>();
            var result = service.GetAllWcsTrkLogList(vPublic.AsrsDefine.AREA_NO,
                                                    vPublic.AsrsDefine.WH_NO,
                                                    Convert.ToInt16(cmbAsrsID.EditValue),
                                                    (DateTime?)dateEditSdate.EditValue,
                                                    (DateTime?)dateEditEdate.EditValue,
                                                    ref Data);

            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                Data = Data.Where(o => (o.CREATE_BY ?? string.Empty).Contains(txtFilter.Text) ||
                    (o.DEV_NO ?? string.Empty).Contains(txtFilter.Text) ||
                    (o.BIN_NO ?? string.Empty).Contains(txtFilter.Text) ||
                    (o.IO ?? string.Empty).Contains(txtFilter.Text) ||
                    (o.OPN_DESC ?? string.Empty).Contains(txtFilter.Text) ||
                    (o.STATUS_DESC ?? string.Empty).Contains(txtFilter.Text) ||
                    (o.STEP_DESC ?? string.Empty).Contains(txtFilter.Text) ||
                    (o.USE_CRN_ID.ToString() ?? string.Empty).Contains(txtFilter.Text)
                    ).ToList();
            }

            gdc_WCS_TRK_LOG.DataSource = Data;
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = string.Format("{0}_{1}", RM.GetString("ExcellFilename"), DateTime.Now.ToString("yyyyMMddHHmmss"));
            sfd.Filter = "Excel |*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gdv_WCS_TRK_LOG.ExportToXlsx(sfd.FileName);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            gdc_WCS_TRK_LOG.ShowPrintPreview();
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                RefreshData();
        }

        private void txtFilter_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            RefreshData();
        }

        private void btnColumnSet_Click(object sender, EventArgs e)
        {
            List<DevExpress.XtraGrid.Columns.GridColumn> EditColumns = new List<DevExpress.XtraGrid.Columns.GridColumn>();
            
            System.IO.Stream layoutStream = new System.IO.MemoryStream();
            gdv_WCS_TRK_LOG.SaveLayoutToStream(layoutStream, DevExpress.Utils.OptionsLayoutBase.FullLayout);

            FORM_PUBLIC.Fm_SetGridviewColumns EditForm = new WMS.FORM_PUBLIC.Fm_SetGridviewColumns(gdv_WCS_TRK_LOG, EditColumns, this.Name, layoutStream);
            layoutStream.Seek(0, System.IO.SeekOrigin.Begin);

            if (EditForm.ShowDialog() == DialogResult.Yes)
            {
                vPublic.RestoreViewLayoutByStream(gdv_WCS_TRK_LOG, this.Name, 1, false);
            }
        }
    }
}
