using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;

namespace WMS.REPORT
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        Model.WmsStk stkservice = new WMS.Model.WmsStk();
        List<Model.WmsStk> Stks = new List<WMS.Model.WmsStk>();
        public XtraReport1()
        {
            InitializeComponent();
        }

        private void XtraReport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var result = stkservice.GetAllWmsStk(1, ref Stks);
            this.DataSource = Stks;
        }

    }
}
