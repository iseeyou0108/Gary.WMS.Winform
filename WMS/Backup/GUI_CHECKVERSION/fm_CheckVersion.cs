using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.IO;

using System.Threading;

namespace GUI_CHECKVERSION
{
    public partial class fm_CheckVersion : Form
    {
        string AutoStarupProcess = "";
        int ProcessValue = 0;
        int TotalJobs = 0;
        Thread trDownloadProcess;

        private delegate void myUICallBack_ControlText(object value, Control ctl);
        private delegate void myUICallBack_ProgressMaximum(int value, ProgressBar ctl);
        public delegate void CloseDelagate();

        public fm_CheckVersion()
        {
            InitializeComponent();
        }

        private void fm_CheckVersion_Load(object sender, EventArgs e)
        {

            trDownloadProcess = new Thread(DownloadProcess);
            trDownloadProcess.IsBackground = true;
            trDownloadProcess.Start();
        }

        private void ChangeProgressBarMaximum(int value, ProgressBar ctl)
        {
            if (this.InvokeRequired)
            {
                myUICallBack_ProgressMaximum myUpdate = new myUICallBack_ProgressMaximum(ChangeProgressBarMaximum);
                this.Invoke(myUpdate, value, ctl);
            }
            else
            {
                ctl.Maximum = value;
            }
        }

        private void ChangeControlText(object value, Control ctl)
        {
            if (this.InvokeRequired)
            {
                myUICallBack_ControlText myUpdate = new myUICallBack_ControlText(ChangeControlText);
                this.Invoke(myUpdate, value, ctl);
            }
            else
            {
                if (ctl is ProgressBar)
                    ((ProgressBar)ctl).Value = Convert.ToInt16(value);
            }
        }

        private void DownloadProcess()
        {
            string ConnStr = "Data Source=192.168.1.65;Initial Catalog=ASRS_XINFA;User ID=sa;Password=123;";

            SqlConnection Conn = new SqlConnection(ConnStr);
            try
            {
                Conn.Open();

                var Cmd = Conn.CreateCommand();
                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                Cmd.CommandText = "select * from SYS_UPDATE ";
                DataTable dt = new DataTable();
                dap.Fill(dt);
                TotalJobs = dt.Rows.Count;

                ChangeProgressBarMaximum(TotalJobs, progressBar1);

                foreach (DataRow dr in dt.Rows)
                {
                    string sFileName = Application.StartupPath + dr["FILE_PATH"].ToString() + "\\" + dr["FILE_NAME"].ToString();

                    if (Convert.ToDecimal(dr["FILE_EXECUTE"]) > 0)
                        AutoStarupProcess = sFileName;

                    //local資料夾內沒有該檔案，直接下載...
                    if (!File.Exists(sFileName))
                    {
                        goto S1;
                    }

                    string LocalVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(sFileName).FileVersion;
                    var localVersion = new Version(LocalVersion);
                    var serverVersion = new Version(dr["FILE_VERSION"].ToString());
                    var result = serverVersion.CompareTo(localVersion);

                    /*
                     * 更新程式
                     */
                    string fileExtension = Path.GetExtension(sFileName);

                    //判斷Process是否有執行
                    if (fileExtension == ".exe")
                    {
                        string p = dr["FILE_NAME"].ToString();
                        System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName(Path.GetFileNameWithoutExtension(sFileName));
                        if (processes.Length > 0)
                        {
                            foreach (var process in processes)
                            {
                                process.Kill();
                            }
                        }
                    }

                    //版本號沒有差異，不用更新
                    if (result == 0)
                    {
                        ProcessValue += 1;
                        ChangeControlText(ProcessValue, progressBar1);
                        System.Threading.Thread.Sleep(100);
                        continue;
                    }

                S1:
                    //檢查上層目錄是否存在
                    string FileFolder = Application.StartupPath + dr["FILE_PATH"].ToString();
                    if (!Directory.Exists(FileFolder))
                        Directory.CreateDirectory(FileFolder);
                    FileStream fs = new FileStream(sFileName, FileMode.Create, FileAccess.Write);
                    BinaryWriter sw = new BinaryWriter(fs, Encoding.Default);
                    sw.Write((Byte[])dr["FILE_BODY"]);

                    sw.Close();
                    fs.Close();

                    ProcessValue += 1;
                    ChangeControlText(ProcessValue, progressBar1);
                    System.Threading.Thread.Sleep(100);
                }

                Conn.Close();
                Cmd.Dispose();
                dap.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (Conn.State == ConnectionState.Open)
                Conn.Close();

            Conn.Dispose();

            if (!string.IsNullOrEmpty(AutoStarupProcess))
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = AutoStarupProcess;
                proc.Start();
            }

            this.Invoke((MethodInvoker)delegate
            {
                // close the form on the forms thread
                this.Close();
            });

            
        }

        private void fm_CheckVersion_Activated(object sender, EventArgs e)
        {
            
        }

        private void fm_CheckVersion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (trDownloadProcess.IsAlive)
                trDownloadProcess.Abort();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
