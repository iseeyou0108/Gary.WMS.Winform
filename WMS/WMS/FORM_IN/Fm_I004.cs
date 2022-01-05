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
    public partial class Fm_I004 : Form
    {
        public Fm_I004()
        {
            InitializeComponent();
        }

        private void Fm_I004_Load(object sender, EventArgs e)
        {
            txtProdNo.Text = vPublic.SystemProdNo.EmptyPallet;
            spinEdit_Qty.StyleController = Program.STYLER;
            spinEdit_TrkCount.StyleController = Program.STYLER;
            cmbDevNo.StyleController = Program.STYLER;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Model.WcsTrk Trk = new WMS.Model.WcsTrk();
            var result = Trk.CreateEmptyPalletIn(vPublic.AsrsDefine.ASRS_ID, cmbDevNo.Text, null, spinEdit_TrkCount.Value, spinEdit_Qty.Value);
            vPublic.ShowAlert(result.Successed == true ? Fm_Alert.AlertType.Successful : Fm_Alert.AlertType.Error, result.Message);
        }
    }
}
