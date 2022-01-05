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
    public partial class Fm_Alert : Form
    {
        public enum AlertType
        {
            Information = 1,
            Warnning = 2,
            Error = 3,
            Successful = 4
        }

        public enum enmAction
        {
            wait,
            start,
            close
        }

        private enmAction action;
        private int x, y;
        public Fm_Alert()
        {
            InitializeComponent();
        }

        

        public void ShowAlert(string Msg, AlertType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;

            string fname;
            for (int i = 1; i < 10; i++)
            {
                fname = string.Format("alert {0}", i + 1);
                Fm_Alert frm = (Fm_Alert)Application.OpenForms[fname];
                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }

            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;
            SetBackColor(type);
            SetDisplayIcon(type);

            this.lblMsg.Text = Msg;
            this.BringToFront();
            this.Show();
            
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }
        
        /// <summary>
        /// 設定背景顏色
        /// </summary>
        /// <param name="alertType"></param>
        public void SetBackColor(AlertType alertType)
        {
            switch (alertType)
            {
                case AlertType.Information:
                    this.BackColor = Color.FromArgb(2, 117, 216);
                    break;
                case AlertType.Warnning:
                    this.BackColor = Color.FromArgb(240, 173, 78);
                    break;
                case AlertType.Error:
                    this.BackColor = Color.FromArgb(217, 83, 79);
                    break;
                case AlertType.Successful:
                    this.BackColor = Color.FromArgb(92, 184, 92);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 設定Icon
        /// </summary>
        /// <param name="alertType"></param>
        private void SetDisplayIcon(AlertType alertType)
        {
            switch (alertType)
            {
                case AlertType.Information:
                    btnIcon.Image = Properties.Resources.Information_64_W;
                    break;
                case AlertType.Warnning:
                    btnIcon.Image = Properties.Resources.Warnning_64_W;
                    break;
                case AlertType.Error:
                    btnIcon.Image = Properties.Resources.Error_64_W;
                    break;
                case AlertType.Successful:
                    btnIcon.Image = Properties.Resources.OK_64_W;
                    break;
                default:
                    break;
            }
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = enmAction.close;
        }

        private void Fm_Alert_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 5000;
                    action = enmAction.close;
                    break;
                case enmAction.start:
                    timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
