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
    public partial class Fm_I002 : Form
    {
        // 多國語言資源檔設定
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_I002", "FORM_IN"), System.Reflection.Assembly.GetExecutingAssembly());
        List<Model.CusBarcodeInfo> cusBarcodeInfos = new List<WMS.Model.CusBarcodeInfo>();
        Service.PalletInService Service = new WMS.Service.PalletInService();

        public Fm_I002()
        {
            InitializeComponent();
        }

        private void Fm_I002_Load(object sender, EventArgs e)
        {
            txtFilter.StyleController = Program.STYLER;

            SET_PRIV();

            vPublic.RestoreViewLayoutByStream(gdv_CUS_BARCODE_INFO, this.Name, 1, true);

            RefreshData();
        }

        private void SET_PRIV()
        {
            var FormPriv = vPublic.GetFormPriv(this.Name);

            btn_Insert.Visible = FormPriv.Add;
            colDelete2.Visible = FormPriv.Delete;
        }

        private void btnColumnSet_Click(object sender, EventArgs e)
        {
            List<DevExpress.XtraGrid.Columns.GridColumn> EditColumns = new List<DevExpress.XtraGrid.Columns.GridColumn>()
            {
                colDelete2
            };
            
            System.IO.Stream layoutStream = new System.IO.MemoryStream();
            gdv_CUS_BARCODE_INFO.SaveLayoutToStream(layoutStream, DevExpress.Utils.OptionsLayoutBase.FullLayout);

            FORM_PUBLIC.Fm_SetGridviewColumns EditForm = new WMS.FORM_PUBLIC.Fm_SetGridviewColumns(gdv_CUS_BARCODE_INFO, EditColumns, this.Name, layoutStream);
            layoutStream.Seek(0, System.IO.SeekOrigin.Begin);

            if (EditForm.ShowDialog() == DialogResult.Yes)
            {
                vPublic.RestoreViewLayoutByStream(gdv_CUS_BARCODE_INFO, this.Name, 1, false);
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        void RefreshData()
        {
            var result = Service.GetAllCusBarcodeInfo(null, ref cusBarcodeInfos);
            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                cusBarcodeInfos = cusBarcodeInfos
                    .Where(o => (o.LIST_NO ?? string.Empty).Contains(txtFilter.Text)
                        || (o.PROD_NO ?? string.Empty).Contains(txtFilter.Text)
                        || (o.PROD_NAME ?? string.Empty).Contains(txtFilter.Text)
                        || (o.ORG_NO ?? string.Empty).Contains(txtFilter.Text)
                        || (o.ORG_SNAME ?? string.Empty).Contains(txtFilter.Text)
                        || (o.PALLET_NO ?? string.Empty).Contains(txtFilter.Text)
                        || (o.REMARK ?? string.Empty).Contains(txtFilter.Text)
                        || (o.STATUS_DESC ?? string.Empty).Contains(txtFilter.Text)
                        || (o.LOT_NO ?? string.Empty).Contains(txtFilter.Text)
                        || (o.UN ?? string.Empty).Contains(txtFilter.Text)
                    ).ToList();
            }

            gdc_CUS_BARCODE_INFO.DataSource = cusBarcodeInfos;
            gdv_CUS_BARCODE_INFO.ExpandAllGroups();
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

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            Fm_I002_1 objForm = new Fm_I002_1();
            if (objForm.ShowDialog() == DialogResult.Yes)
            {
                RefreshData();
            }
        }

        private void repositoryItemButtonEdit_Delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string PalletNo = string.Empty;
            string ListNo = string.Empty;
            int LineID = 0;

            PalletNo = gdv_CUS_BARCODE_INFO.GetFocusedRowCellValue("PALLET_NO").ToString();
            ListNo = gdv_CUS_BARCODE_INFO.GetFocusedRowCellValue("LIST_NO").ToString();
            LineID = Convert.ToInt16(gdv_CUS_BARCODE_INFO.GetFocusedRowCellValue("LINE_ID"));

            var DeleteItems = cusBarcodeInfos.Where(o => o.PALLET_NO == PalletNo && o.LINE_ID == LineID && o.LIST_NO == ListNo).ToList();
            if (DeleteItems != null)
            {
                var result = Service.DeleteCusBarcodeInfo(DeleteItems);
                vPublic.ShowAlert(result.Successed == false ? Fm_Alert.AlertType.Error : Fm_Alert.AlertType.Successful
                              , result.Message);
                if (result.Successed)
                    btn_Select_Click(null, null);
            }
            else
                return;
        }

    }
}
