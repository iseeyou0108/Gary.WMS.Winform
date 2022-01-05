using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS
{
    public partial class ucDevice : UserControl
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}Resource_WCS_DEVICE", ""), System.Reflection.Assembly.GetExecutingAssembly());

        public enum DeviceDirection
        {
            Up = 0,
            Down = 1,
            Left = 2,
            Right = 3,
            UpDown = 4,
            LeftRight = 5,
            None = 6
        }

        private Color ManualColor = Color.FromArgb(240, 173, 78);
        private Color AutoColor = Color.White;
        private Color ErrorColor = Color.FromArgb(217, 83, 79);
        private Color LoadingColor = Color.FromArgb(92, 184, 92);
        private Color UnLoadingColor = Color.FromArgb(224, 224, 224);

        private bool _Auto = false;
        public bool _Error = false;
        private bool _Loading = false;

        private int _SerNo = 0;
        private string _DevNo = "";
        private string _Dest = "";
        private DeviceDirection _Direction = DeviceDirection.None;
        

        /// <summary>
        /// 序號
        /// </summary>
        public int SerNo
        {
            get { return _SerNo; }
            set 
            {
                _SerNo = value;
                lblSerNo.Text = _SerNo.ToString();
            }
        }
        /// <summary>
        /// 站台編號
        /// </summary>
        public string DevNo
        {
            get { return _DevNo; }
            set
            {
                _DevNo = value;
                lblDevNo.Text = _DevNo.ToString();
            }
        }
        /// <summary>
        /// 目的站
        /// </summary>
        public string Dest
        {
            get { return _Dest; }
            set
            {
                _Dest = value;
                lblDest.Text = _Dest.ToString();
            }
        }

        /// <summary>
        /// 輸送機鍊條方向
        /// </summary>
        public DeviceDirection Direction
        {
            get { return _Direction; }
            set
            {
                _Direction = value;
                switch (_Direction)
                {
                    case DeviceDirection.Up:
                        pictureEdit_Direct.Image = WMS.Properties.Resources.ArrowTop_16;
                        pictureEdit_Direct.Visible = true;
                        break;
                    case DeviceDirection.Down:
                        pictureEdit_Direct.Image = WMS.Properties.Resources.ArrowDown_16;
                        pictureEdit_Direct.Visible = true;
                        break;
                    case DeviceDirection.Left:
                        pictureEdit_Direct.Image = WMS.Properties.Resources.ArrorLeft_16;
                        pictureEdit_Direct.Visible = true;
                        break;
                    case DeviceDirection.Right:
                        pictureEdit_Direct.Image = WMS.Properties.Resources.ArrowRight_16;
                        pictureEdit_Direct.Visible = true;
                        break;
                    case DeviceDirection.UpDown:
                        pictureEdit_Direct.Image = WMS.Properties.Resources.ArrowUpDown_16;
                        pictureEdit_Direct.Visible = true;
                        break;
                    case DeviceDirection.LeftRight:
                        pictureEdit_Direct.Image = WMS.Properties.Resources.ArrorLeftRight_16;
                        pictureEdit_Direct.Visible = true;
                        break;
                    case DeviceDirection.None:
                        pictureEdit_Direct.Image = WMS.Properties.Resources.ArrowUpDown_16;
                        pictureEdit_Direct.Visible = false;
                        break;
                }
            }
        }

        /// <summary>
        /// 切換自動
        /// </summary>
        public bool Auto 
        {
            get { return _Auto; }
            set 
            {
                _Auto = value;
                switch (_Auto)
                {
                    case true:
                        if (!_Error)
                            base.BackColor = AutoColor;
                        else
                            base.BackColor = ErrorColor;
                        break;
                    case false:
                        if (!_Error)
                            base.BackColor = ManualColor;
                        else
                            base.BackColor = ErrorColor;
                        break;
                    default:
                        if (!_Error)
                            base.BackColor = ManualColor;
                        else
                            base.BackColor = ErrorColor;
                        break;
                }
            }
        }

        /// <summary>
        /// 異常
        /// </summary>
        public bool Error
        {
            get { return _Error; }
            set
            {
                _Error = value;
                switch (_Error)
                {
                    case true:
                        base.BackColor = ErrorColor;
                        break;
                    case false:
                        if (!_Auto)
                            base.BackColor = ManualColor;
                        else
                            base.BackColor = AutoColor;
                        break;
                    default:
                        if (!_Auto)
                            base.BackColor = ManualColor;
                        else
                            base.BackColor = AutoColor;
                        break;
                }
            }
        }

        /// <summary>
        /// 有載/無載
        /// </summary>
        public bool Loading 
        {
            get { return _Loading; }
            set 
            {
                _Loading = value;
                switch (_Loading)
                {
                    case true:
                        btnLoading.BackColor = LoadingColor;
                        btnLoading.ForeColor = Color.White;
                        btnLoading.Text = RM.GetString("Loading");
                        break;
                    case false:
                        btnLoading.BackColor = UnLoadingColor;
                        btnLoading.ForeColor = Color.FromArgb(64, 64, 64);
                        btnLoading.Text = RM.GetString("UnLoading");
                        break;
                    default:
                        btnLoading.BackColor = UnLoadingColor;
                        btnLoading.ForeColor = Color.FromArgb(64, 64, 64);
                        btnLoading.Text = RM.GetString("UnLoading");
                        break;
                }
            }
        }

        public ucDevice()
        {
            InitializeComponent();
        }
    }
}
