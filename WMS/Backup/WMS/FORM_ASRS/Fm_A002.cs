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
    public partial class Fm_A002 : Form
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_A002", "FORM_ASRS"), System.Reflection.Assembly.GetExecutingAssembly());
        Service.WcsCrnService service = new WMS.Service.WcsCrnService();
        List<Model.WcsCrn> Crns = new List<WMS.Model.WcsCrn>();
        Model.WcsCrn CurrentCrn = new WMS.Model.WcsCrn();

        public Fm_A002()
        {
            InitializeComponent();
        }

        private void Fm_A002_Load(object sender, EventArgs e)
        {
            vPublic.GetAsrsIDItems(cmbAsrsID);

            cmbAsrsID.StyleController = Program.STYLER;

            vPublic.RestoreViewLayoutByStream(gdv_WCS_CRN, this.Name, 1, true);
            
            SET_PRIV();

            RefreshData();
        }

        private void SET_PRIV()
        {
            var FormPriv = vPublic.GetFormPriv(this.Name);

            btnForbidden.Visible = FormPriv.Exec;
            btnManual.Visible = FormPriv.Exec;
            btnRedo.Visible = FormPriv.Exec;
            btnReset.Visible = FormPriv.Exec;
        }

        private void RefreshData()
        {
            var result = service.GetAllWcsCrnList(vPublic.AsrsDefine.AREA_NO, vPublic.AsrsDefine.WH_NO, Convert.ToInt16(cmbAsrsID.EditValue), ref Crns);
            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }


            gdc_WCS_CRN.DataSource = Crns;

            if (CurrentCrn != null)
            {
                int index = Crns.FindIndex(o => o.AREA_NO == CurrentCrn.AREA_NO && o.WH_NO == CurrentCrn.WH_NO && o.ASRS_ID == CurrentCrn.ASRS_ID && o.CRN_ID == CurrentCrn.CRN_ID);
                gdv_WCS_CRN.FocusedRowHandle = index;
            }
               
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void chkAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            tmrAutoRefresh.Enabled = chkAutoRefresh.Checked;
        }

        private void tmrAutoRefresh_Tick(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void gdv_WCS_CRN_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
        }

        private void gdv_WCS_CRN_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gdc_WCS_CRN.DataSource == null)
            {
                CurrentCrn = null;
                return;
            }

            if (gdv_WCS_CRN.RowCount <= 0)
            {
                CurrentCrn = null;
                return;
            }

            if (gdv_WCS_CRN.IsValidRowHandle(gdv_WCS_CRN.FocusedRowHandle) == false)
            {
                CurrentCrn = null;
                return;
            }

            if (gdv_WCS_CRN.FocusedRowHandle == DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
            {
                CurrentCrn = null;
                return;
            }

            string AreaNo = gdv_WCS_CRN.GetFocusedRowCellValue("AREA_NO").ToString();
            string WhNo = gdv_WCS_CRN.GetFocusedRowCellValue("WH_NO").ToString();
            int AsrsID = Convert.ToInt16(gdv_WCS_CRN.GetFocusedRowCellValue("ASRS_ID"));
            int CrnID = Convert.ToInt16(gdv_WCS_CRN.GetFocusedRowCellValue("CRN_ID"));

            CurrentCrn = Crns.Where(o => o.AREA_NO == AreaNo && o.WH_NO == WhNo && o.ASRS_ID == AsrsID && o.CRN_ID == CrnID).First();

            //gdv_WCS_CRN.BeginUpdate();
            //CurrentCrn.CHK = !CurrentCrn.CHK;
            //gdv_WCS_CRN.EndUpdate();
        }

        private void btnForbidden_Click(object sender, EventArgs e)
        {
            Fm_A002_1 objForm = new Fm_A002_1(Crns);
            objForm.StartPosition = FormStartPosition.CenterParent;
            objForm.ShowDialog();

            RefreshData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (!Crns.Any(o => o.CHK))
            {
                //請先勾選要執行異常復歸的吊車	
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0002"));
                return;
            }

            if (Crns.Where(o => o.CHK).Count() > 1)
            {
                //吊車異常復歸一次僅能針對一台吊車執行	
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0003"));
                return;
            }

            //確定要針對選取的吊車執行「異常復歸」嗎?
            if (MessageBox.Show(this, RM.GetString("ConfirmMessage1"), RM.GetString("MsgTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            var result = service.SubmitCrnReset(Crns.Where(o => o.CHK).ToList());
            vPublic.ShowAlert(result.Successed == false ? Fm_Alert.AlertType.Error : Fm_Alert.AlertType.Successful
                              , result.Message);

            if (result.Successed)
            {
                RefreshData();
            }
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (!Crns.Any(o => o.CHK))
            {
                //請先勾選要執行吊車續行的吊車	
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0007"));
                return;
            }

            if (Crns.Where(o => o.CHK).Count() > 1)
            {
                //吊車續行一次僅能針對一台吊車執行	
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0008"));
                return;
            }

            //確定要針對選取的吊車執行「{0}」嗎?
            if (MessageBox.Show(this, string.Format(RM.GetString("ConfirmMessage2"), btnRedo.Text), RM.GetString("MsgTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            var result = service.SubmitCrnRedo(Crns.Where(o => o.CHK).ToList());
            vPublic.ShowAlert(result.Successed == false ? Fm_Alert.AlertType.Error : Fm_Alert.AlertType.Successful
                              , result.Message);

            if (result.Successed)
            {
                RefreshData();
            }
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            if (Crns.Where(o => o.CHK).Count() <= 0) return;

            if (Crns.Where(o => o.CHK).Count() > 1)
            {
                //手動控制一次僅能針對一台吊車執行	
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0009"));
                return;
            }

            Fm_A002_2 objForm = new Fm_A002_2(Crns.Where(o => o.CHK).ToList());
            objForm.StartPosition = FormStartPosition.CenterParent;
            objForm.ShowDialog();

            RefreshData();
        }

        private void btnErrorLog_Click(object sender, EventArgs e)
        {
            Fm_A002_3 objForm = new Fm_A002_3();
            objForm.ShowDialog();
        }

        private void btnColumnSet_Click(object sender, EventArgs e)
        {
            List<DevExpress.XtraGrid.Columns.GridColumn> EditColumns = new List<DevExpress.XtraGrid.Columns.GridColumn>() { 
                colCHK
            };
            
            System.IO.Stream layoutStream = new System.IO.MemoryStream();
            gdv_WCS_CRN.SaveLayoutToStream(layoutStream, DevExpress.Utils.OptionsLayoutBase.FullLayout);

            FORM_PUBLIC.Fm_SetGridviewColumns EditForm = new WMS.FORM_PUBLIC.Fm_SetGridviewColumns(gdv_WCS_CRN, EditColumns, this.Name, layoutStream);
            layoutStream.Seek(0, System.IO.SeekOrigin.Begin);

            if (EditForm.ShowDialog() == DialogResult.Yes)
            {
                vPublic.RestoreViewLayoutByStream(gdv_WCS_CRN, this.Name, 1, false);
            }
        }
    }
}
