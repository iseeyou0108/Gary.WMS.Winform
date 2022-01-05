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
    public partial class Fm_A002_2 : Form
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_A002", "FORM_ASRS"), System.Reflection.Assembly.GetExecutingAssembly());
        public List<Model.WcsCrn> Crns = new List<WMS.Model.WcsCrn>();
        List<Model.WmsBinSta> Binstas = new List<WMS.Model.WmsBinSta>();
        List<Model.WcsCrnPdStation> PDStations = new List<WMS.Model.WcsCrnPdStation>();
        Service.WcsCrnService service = new WMS.Service.WcsCrnService();
        Service.WmsBinstaService serviceWmsBinsta = new WMS.Service.WmsBinstaService();
        

        public class ComboBoxItemObject
        {
            public string DESC { get; set; }
            public object VALUE { get; set; }
        }

        public Fm_A002_2()
        {
            InitializeComponent();
        }

        public Fm_A002_2(List<Model.WcsCrn> _Crns)
        {
            InitializeComponent();
            Crns = _Crns;
        }

        private void Fm_A002_2_Load(object sender, EventArgs e)
        {
            gdc_WCS_CRN.DataSource = Crns;
            GetAllBinNos();
            var result = service.GetWcsCrnPDStationById((int)Crns.First().CRN_ID);
            if (result.Successed)
                PDStations = (List<Model.WcsCrnPdStation>)result.Data;
            
            InitialComboBox();
        }

        void GetAllBinNos()
        {
            var result = serviceWmsBinsta.GetAllWmsBinstaList(vPublic.AsrsDefine.AREA_NO, vPublic.AsrsDefine.WH_NO, (int)Crns.First().ASRS_ID, ref Binstas);
            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

            Binstas = Binstas.Where(o => o.CRN_ID == Crns.First().CRN_ID).ToList();
        }

        void InitialComboBox()
        {
            List<ComboBoxItemObject> ActionItems = new List<ComboBoxItemObject>()
            {
                new ComboBoxItemObject(){ DESC = RM.GetString("Action1"), VALUE = (object)Service.WcsCrnService.CrnManulAction.取物},
                new ComboBoxItemObject(){ DESC = RM.GetString("Action2"), VALUE = (object)Service.WcsCrnService.CrnManulAction.置物},
                new ComboBoxItemObject(){ DESC = RM.GetString("Action3"), VALUE = (object)Service.WcsCrnService.CrnManulAction.移動},
                new ComboBoxItemObject(){ DESC = RM.GetString("Action4"), VALUE = (object)Service.WcsCrnService.CrnManulAction.庫間移載}
            };

            cmbAction.Properties.DataSource = ActionItems;
            cmbAction.Properties.DropDownRows = ActionItems.Count;
            cmbAction.EditValue = Service.WcsCrnService.CrnManulAction.取物;

            List<ComboBoxItemObject> DeviceTypeItems = new List<ComboBoxItemObject>()
            {
                new ComboBoxItemObject(){ DESC = RM.GetString("DeviceType1"), VALUE = (object)Service.WcsCrnService.DeviceType.庫位},
                new ComboBoxItemObject(){ DESC = RM.GetString("DeviceType2"), VALUE = (object)Service.WcsCrnService.DeviceType.設備站}
            };

            cmbType.Properties.DataSource = DeviceTypeItems;
            cmbType.Properties.DropDownRows = DeviceTypeItems.Count;
            cmbType.EditValue = Service.WcsCrnService.DeviceType.庫位;

            SetFromToComboBox();
        }

        void SetFromToComboBox()
        {
            List<ComboBoxItemObject> FromItems = new List<ComboBoxItemObject>();
            List<ComboBoxItemObject> ToItems = new List<ComboBoxItemObject>();
            if ((Service.WcsCrnService.DeviceType)cmbType.EditValue == WMS.Service.WcsCrnService.DeviceType.庫位)
            {
                FromItems = Binstas.Select(o => new ComboBoxItemObject() { DESC = o.BIN_NO, VALUE = o.BIN_NO }).ToList();
                ToItems = Binstas.Select(o => new ComboBoxItemObject() { DESC = o.BIN_NO, VALUE = o.BIN_NO }).ToList();
            }

            if ((Service.WcsCrnService.DeviceType)cmbType.EditValue == WMS.Service.WcsCrnService.DeviceType.設備站)
            {
                FromItems = PDStations.Select(o => new ComboBoxItemObject() { DESC = o.DEV_NO, VALUE = o.BIN_NO }).ToList();
                ToItems = PDStations.Select(o => new ComboBoxItemObject() { DESC = o.DEV_NO, VALUE = o.BIN_NO }).ToList();
            }

            cmbFrom.Properties.DataSource = FromItems;
            cmbFrom.Properties.DropDownRows = FromItems.Count > 15 ? 15 : FromItems.Count;

            cmbTo.Properties.DataSource = ToItems;
            cmbTo.Properties.DropDownRows = ToItems.Count > 15 ? 15 : ToItems.Count;
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
            if (!Crns.Any(o => o.CHK))
            {
                //請先勾選要設定的吊車	
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0001"));
                return;
            }

            if (!Crns.First().INHIBIT_IN_FLG && !Crns.First().INHIBIT_OUT_FLG)
            {
                //吊車非禁用狀態，無法執行手動控制命令	
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0006"));
                return;
            }

            if (cmbFrom.Enabled)
            {
                if (cmbFrom.EditValue == null)
                {
                    //請選取來源位置	
                    vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0004"));
                    return;
                }
                if (string.IsNullOrEmpty(cmbFrom.EditValue.ToString()))
                {
                    //請選取來源位置	
                    vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0004"));
                    return;
                }
            }

            if (cmbTo.Enabled)
            {
                if (cmbTo.EditValue == null)
                {
                    //請選取目的位置	
                    vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0005"));
                    return;
                }
                if (string.IsNullOrEmpty(cmbTo.EditValue.ToString()))
                {
                    //請選取目的位置	
                    vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0005"));
                    return;
                }
            }

            //確定要針對選取的吊車執行「{0}」嗎?
            if (MessageBox.Show(this, string.Format(RM.GetString("ConfirmMessage2"), cmbAction.Text), RM.GetString("MsgTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            var result = service.SubmitCrnManualControl(Crns.Where(o => o.CHK).ToList(),
                (Service.WcsCrnService.CrnManulAction)cmbAction.EditValue,
                cmbFrom.EditValue == null ? string.Empty : cmbFrom.EditValue.ToString(),
                cmbTo.EditValue == null ? string.Empty : cmbTo.EditValue.ToString());
            vPublic.ShowAlert(result.Successed == false ? Fm_Alert.AlertType.Error : Fm_Alert.AlertType.Successful
                              , result.Message);            
        }

        private void cmbAction_EditValueChanged(object sender, EventArgs e)
        {
            cmbFrom.Enabled = (Service.WcsCrnService.CrnManulAction)cmbAction.EditValue == WMS.Service.WcsCrnService.CrnManulAction.取物 || (Service.WcsCrnService.CrnManulAction)cmbAction.EditValue == WMS.Service.WcsCrnService.CrnManulAction.庫間移載;
            cmbFrom.EditValue = cmbFrom.Enabled ? cmbFrom.EditValue : null;

            cmbTo.Enabled = (Service.WcsCrnService.CrnManulAction)cmbAction.EditValue != WMS.Service.WcsCrnService.CrnManulAction.取物;
            cmbTo.EditValue = cmbTo.Enabled ? cmbTo.EditValue : null;
        }

        private void cmbType_EditValueChanged(object sender, EventArgs e)
        {
            SetFromToComboBox();
        }

    }
}
