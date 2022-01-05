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
    public partial class Fm_I003 : Form
    {
        // 多國語言資源檔設定
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_I003", "FORM_IN"), System.Reflection.Assembly.GetExecutingAssembly());
        Service.WmsListService ListService = new WMS.Service.WmsListService();
        List<Model.WmsInLine> InLines = new List<WMS.Model.WmsInLine>();
        public class ComboBoxObject
        {
            public string DESC { get; set; }
            public object VALUE { get; set; }
        }

        public Fm_I003()
        {
            InitializeComponent();
        }

        private void Fm_I003_Load(object sender, EventArgs e)
        {
            vPublic.GetStoreInDevNoItems(cmbDevNo);
            vPublic.GetEmergeItems(cmbEmerge);
            vPublic.RestoreViewLayoutByStream(gdv_WMS_IN_LINE, this.Name, 1, true);
            InitialCreateTypeComboBox();
            SET_PRIV();
        }

        private void SET_PRIV()
        {
            var FormPriv = vPublic.GetFormPriv(this.Name);

            btnExec.Visible = FormPriv.Exec;
        }

        private void InitialCreateTypeComboBox()
        {
            List<ComboBoxObject> Items = new List<ComboBoxObject>()
            {
                new ComboBoxObject(){DESC=RM.GetString("CreateType1"), VALUE = Model.WcsTrk.StoreInCreateType.單板入庫},
                new ComboBoxObject(){DESC=RM.GetString("CreateType2"), VALUE = Model.WcsTrk.StoreInCreateType.批次入庫}
            };

            cmbCreateType.Properties.DataSource = Items;
            cmbCreateType.EditValue = Model.WcsTrk.StoreInCreateType.單板入庫;
            cmbCreateType.Properties.DropDownRows = 2;
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            Fm_I003_1 objForm = new Fm_I003_1();
            if (objForm.ShowDialog() == DialogResult.Yes)
            {
                var SelectedResult = objForm.SelectedList.Where(t1 => !InLines.Any(t2 => t2.LIST_NO == t1.LIST_NO && t2.LINE_ID == t1.LINE_ID));
                gdv_WMS_IN_LINE.BeginUpdate();
                InLines.AddRange(SelectedResult);
                InLines = InLines.OrderBy(o => o.LIST_NO).ThenBy(o => o.LINE_ID).ToList();
                gdv_WMS_IN_LINE.EndUpdate();
                gdc_WMS_IN_LINE.DataSource = InLines;
            }
        }

        private void btnColumnSet_Click(object sender, EventArgs e)
        {
            List<DevExpress.XtraGrid.Columns.GridColumn> EditColumns = new List<DevExpress.XtraGrid.Columns.GridColumn>() { 
                colDelete2
            };

            System.IO.Stream layoutStream = new System.IO.MemoryStream();
            gdv_WMS_IN_LINE.SaveLayoutToStream(layoutStream, DevExpress.Utils.OptionsLayoutBase.FullLayout);

            FORM_PUBLIC.Fm_SetGridviewColumns EditForm = new WMS.FORM_PUBLIC.Fm_SetGridviewColumns(gdv_WMS_IN_LINE, EditColumns, this.Name, layoutStream);
            layoutStream.Seek(0, System.IO.SeekOrigin.Begin);

            if (EditForm.ShowDialog() == DialogResult.Yes)
            {
                vPublic.RestoreViewLayoutByStream(gdv_WMS_IN_LINE, this.Name, 1, false);
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            gdv_WMS_IN_LINE.BeginUpdate();
            InLines = new List<WMS.Model.WmsInLine>();
            gdv_WMS_IN_LINE.EndUpdate();
            gdc_WMS_IN_LINE.DataSource = InLines;
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            Model.WcsTrk TrkService = new WMS.Model.WcsTrk();

            var result = TrkService.CreateWmsListIn(vPublic.AsrsDefine.ASRS_ID, InLines, cmbDevNo.Text, (WMS.Model.WcsTrk.StoreInCreateType)cmbCreateType.EditValue, (WMS.Model.WcsTrk.TrkEmerge)cmbEmerge.EditValue);
            vPublic.ShowAlert(result.Successed == false ? Fm_Alert.AlertType.Error : Fm_Alert.AlertType.Successful
                              , result.Message);

            if (result.Successed)
            {
                gdv_WMS_IN_LINE.BeginUpdate();
                InLines = new List<WMS.Model.WmsInLine>();
                gdv_WMS_IN_LINE.EndUpdate();
                gdc_WMS_IN_LINE.DataSource = InLines;
            }
            else
            {
                gdv_WMS_IN_LINE.BeginUpdate();

                gdv_WMS_IN_LINE.EndUpdate();
                gdc_WMS_IN_LINE.DataSource = InLines;
            }
        }

        
    }
}
