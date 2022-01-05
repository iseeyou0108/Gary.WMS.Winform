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
    public partial class Fm_A003 : Form
    {
        Timer tmrRefresh = new Timer();
        List<ucDevice> AsrsDevices = new List<ucDevice>();

        public Fm_A003()
        {
            InitializeComponent();
        }

        private void Fm_A003_Load(object sender, EventArgs e)
        {

            //註冊Device
            foreach (Control ctrl in xtraScrollableControl1.Controls)
            {
                if (ctrl is ucDevice)
                    AsrsDevices.Add((ucDevice)ctrl);
            }

            tmrRefresh.Interval = 1000;
            tmrRefresh.Tick += new EventHandler(tmrRefresh_Tick);
            tmrRefresh.Enabled = true;


        }

        void tmrRefresh_Tick(object sender, EventArgs e)
        {
            var result = vPublic.GetDbData("select DEV_NO, SER_NO, AUTO, AUTO_START, LOAD, LOAD_F, LOAD_B, ERR, DEST from WCS_DEVICE where ASRS_ID = @ASRS_ID order by DEV_NO "
                , new List<vPublic.DBParameter>() { new vPublic.DBParameter() { ParameterName = "ASRS_ID", Value = vPublic.AsrsDefine.ASRS_ID } });

            if (result.Successed)
            {
                foreach (DataRow Item in result.ResultDt.Rows)
                {
                    string DevNo = Item["DEV_NO"].ToString();
                    var Device = AsrsDevices.Where(o => o.DevNo == DevNo).FirstOrDefault();
                    if (Device != null)
                    {
                        if (!string.IsNullOrEmpty(Item["SER_NO"].ToString()))
                            Device.SerNo = int.Parse(Item["SER_NO"].ToString());
                        else
                            Device.SerNo = 0;

                        if (!string.IsNullOrEmpty(Item["AUTO_START"].ToString()))
                            Device.Auto = int.Parse(Item["AUTO_START"].ToString()) == 0 ? false : true;
                        else
                            Device.Auto = false;

                        if (!string.IsNullOrEmpty(Item["ERR"].ToString()))
                            Device.Error = int.Parse(Item["ERR"].ToString()) == 0 ? false : true;
                        else
                            Device.Error = false;

                        if (!string.IsNullOrEmpty(Item["LOAD"].ToString()))
                            Device.Loading = int.Parse(Item["LOAD"].ToString()) == 0 ? false : true;
                        else
                            Device.Loading = false;

                        Device.Dest = Item["DEST"].ToString();
                    }
                }
            }
        }


        private void btnScale1F_Click(object sender, EventArgs e)
        {
            double Scale = 1;
            if ((sender as Button) == btnPlus1F)
                Scale = 1.1;
            else if ((sender as Button) == btnMinus1F)
                Scale = 0.9;
            xtraScrollableControl1.Scale(new SizeF(ToSingle(Scale), ToSingle(Scale)));
            ResizeFont(xtraScrollableControl1.Controls, (float)Scale);
        }

        public static float ToSingle(double value)
        {
            return (float)value;
        }

        private void ResizeFont(Control.ControlCollection coll, float scaleFactor)
        {
            foreach (Control c in coll)
            {
                if (c.HasChildren)
                {
                    ResizeFont(c.Controls, scaleFactor);
                }
                else
                {
                    //if (c.GetType().ToString() == "System.Windows.Form.Label")
                    if (true)
                    {
                        // scale font
                        c.Font = new Font(c.Font.FontFamily.Name, c.Font.Size * scaleFactor);
                    }
                }
            }
        }

        private void xtraScrollableControl1_Resize(object sender, EventArgs e)
        {
            button5.Size = new Size(xtraScrollableControl1.Size.Width, button5.Size.Height);
        }
    }
}
