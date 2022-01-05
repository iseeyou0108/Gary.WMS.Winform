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
    public partial class Fm_O002 : Form
    {
        // 多國語言資源檔設定
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_O002", "FORM_OUT"), System.Reflection.Assembly.GetExecutingAssembly());
        Service.WmsListService ListService = new WMS.Service.WmsListService();
        List<Model.WmsOutLine> OutLines = new List<WMS.Model.WmsOutLine>();

        public Fm_O002()
        {
            InitializeComponent();
        }

        private void Fm_O002_Load(object sender, EventArgs e)
        {
            vPublic.GetStoreOutDevNoItems(cmbDevNo);
            vPublic.GetShippingStraegyItems(cmbStategy);
            vPublic.GetEmergeItems(cmbEmerge);
            vPublic.RestoreViewLayoutByStream(gdv_WMS_OUT_LINE, this.Name, 1, true);

            SET_PRIV();
            
            gdc_WMS_OUT_LINE.DataSource = OutLines;
        }

        private void SET_PRIV()
        {
            var FormPriv = vPublic.GetFormPriv(this.Name);

            btnExec.Visible = FormPriv.Exec;
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            Fm_O002_1 objForm = new Fm_O002_1();
            if (objForm.ShowDialog() == DialogResult.Yes)
            {
                var SelectedResult = objForm.SelectedList.Where(t1 => !OutLines.Any(t2 => t2.LIST_NO == t1.LIST_NO && t2.LINE_ID == t1.LINE_ID));
                gdv_WMS_OUT_LINE.BeginUpdate();
                OutLines.AddRange(SelectedResult);
                OutLines = OutLines.OrderBy(o => o.LIST_NO).ThenBy(o => o.LINE_ID).ToList();
                gdv_WMS_OUT_LINE.EndUpdate();
                gdc_WMS_OUT_LINE.DataSource = OutLines;
            }
        }

        private void repositoryItemButtonEdit_Delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gdv_WMS_OUT_LINE.BeginUpdate();

            string ListNo = gdv_WMS_OUT_LINE.GetFocusedRowCellValue("LIST_NO").ToString();
            int LineID = Convert.ToInt16(gdv_WMS_OUT_LINE.GetFocusedRowCellValue("LINE_ID"));

            var itemToRemove = OutLines.Single(r => r.LIST_NO == ListNo && r.LINE_ID == LineID);

            OutLines.Remove(itemToRemove);
            gdv_WMS_OUT_LINE.EndUpdate();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            gdv_WMS_OUT_LINE.BeginUpdate();
            OutLines = new List<WMS.Model.WmsOutLine>();
            gdv_WMS_OUT_LINE.EndUpdate();
            gdc_WMS_OUT_LINE.DataSource = OutLines;
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            Model.WcsTrk TrkService = new WMS.Model.WcsTrk();

            var result = TrkService.CreateWmsListOut(OutLines, cmbDevNo.Text, (WMS.Model.WcsTrk.StoreOutStrategy)cmbStategy.EditValue, (WMS.Model.WcsTrk.TrkEmerge)cmbEmerge.EditValue);
            vPublic.ShowAlert(result.Successed == false ? Fm_Alert.AlertType.Error : Fm_Alert.AlertType.Successful
                              , result.Message);

            if (result.Successed)
            {
                gdv_WMS_OUT_LINE.BeginUpdate();
                OutLines = new List<WMS.Model.WmsOutLine>();
                gdv_WMS_OUT_LINE.EndUpdate();
                gdc_WMS_OUT_LINE.DataSource = OutLines;
            }
            else
            {
                gdv_WMS_OUT_LINE.BeginUpdate();
                
                gdv_WMS_OUT_LINE.EndUpdate();
                gdc_WMS_OUT_LINE.DataSource = OutLines;
            }
        }

        private void btnColumnSet_Click(object sender, EventArgs e)
        {
            List<DevExpress.XtraGrid.Columns.GridColumn> EditColumns = new List<DevExpress.XtraGrid.Columns.GridColumn>() { 
                colDelete2
            };

            System.IO.Stream layoutStream = new System.IO.MemoryStream();
            gdv_WMS_OUT_LINE.SaveLayoutToStream(layoutStream, DevExpress.Utils.OptionsLayoutBase.FullLayout);

            FORM_PUBLIC.Fm_SetGridviewColumns EditForm = new WMS.FORM_PUBLIC.Fm_SetGridviewColumns(gdv_WMS_OUT_LINE, EditColumns, this.Name, layoutStream);
            layoutStream.Seek(0, System.IO.SeekOrigin.Begin);

            if (EditForm.ShowDialog() == DialogResult.Yes)
            {
                vPublic.RestoreViewLayoutByStream(gdv_WMS_OUT_LINE, this.Name, 1, false);
            }
        }
    }
}
