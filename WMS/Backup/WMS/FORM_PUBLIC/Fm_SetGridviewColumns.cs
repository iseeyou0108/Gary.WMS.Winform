using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WMS.FORM_PUBLIC
{
    public partial class Fm_SetGridviewColumns : Form
    {
        DevExpress.XtraGrid.Views.Grid.GridView SetGridView { get; set; }
        List<DevExpress.XtraGrid.Columns.GridColumn> EditColumns { get; set; }
        string FormName { get; set; }
        System.IO.Stream layoutStream { get; set; }

        public Fm_SetGridviewColumns()
        {
            InitializeComponent();
        }

        public Fm_SetGridviewColumns(DevExpress.XtraGrid.Views.Grid.GridView _SetGridView,
                                     List<DevExpress.XtraGrid.Columns.GridColumn> _EditColumns,
                                     string _FormName,
                                     System.IO.Stream _layoutStream)
        {
            InitializeComponent();

            SetGridView = _SetGridView;
            EditColumns = _EditColumns;
            FormName = _FormName;
            layoutStream = _layoutStream;
        }

        private void Fm_SetGridviewColumns_Load(object sender, EventArgs e)
        {
            
            InitialEditForm();
            InitialDB();
        }



        private void InitialDB()
        {

            SqlConnection Conn = new SqlConnection(vPublic.ConnStr);
            try
            {
                Conn.Open();
            }
            catch (SqlException ex)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, ex.Message);
                //MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var Cmd = Conn.CreateCommand();

                Cmd.CommandText = @"IF OBJECT_ID ('dbo.SYS_COLUMNS_SET', 'U') IS NULL 
                                    begin
                                       CREATE TABLE SYS_COLUMNS_SET  
                                        (  
                                         FORM_NAME 	 	varchar(100) not null,
                                         VIEW_TYPE      int default 0,
                                         LANG_ID        int default 1,
                                         USER_NO		varchar(100) not null,
                                         VIEW_FILE		VARBINARY(MAX)
                                        ); 
                                    end ";
                Cmd.ExecuteNonQuery();

                if (Conn.State == ConnectionState.Open)
                    Conn.Close();

                Conn.Dispose();
                Cmd.Dispose();
            }
            catch (SqlException ex)
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();

                Conn.Dispose();
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, ex.Message);
                //MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>() 
            { 
                new vPublic.DBParameter(){ ParameterName = "LANG_ID", Value = Convert.ToInt16(Program.LangID) },
                new vPublic.DBParameter(){ ParameterName = "VIEW_TYPE", Value = 0 },
                new vPublic.DBParameter(){ ParameterName = "USER_NO", Value = Program.wmsUser.UserNo },
                new vPublic.DBParameter(){ ParameterName = "FORM_NAME", Value = FormName }
            };

            var QueryResult = vPublic.GetDbData("select * from SYS_COLUMNS_SET where LANG_ID = @LANG_ID and VIEW_TYPE = @VIEW_TYPE and USER_NO = @USER_NO and FORM_NAME = @FORM_NAME ", parameters);

            if (QueryResult.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, QueryResult.Message);
                return;
            }

            if (QueryResult.ResultDt.Rows.Count <= 0)
            {
                //Insert View to database
                
                try
                {
                    Conn = new SqlConnection(vPublic.ConnStr);
                    Conn.Open();
                }
                catch (SqlException ex)
                {
                    vPublic.ShowAlert(Fm_Alert.AlertType.Error, ex.Message);
                    return;
                }

                try
                {
                    System.IO.Stream ViewStream = new System.IO.MemoryStream();
                    gridView1.SaveLayoutToStream(ViewStream, DevExpress.Utils.OptionsLayoutBase.FullLayout);
                    ViewStream.Seek(0, System.IO.SeekOrigin.Begin);

                    var Cmd = Conn.CreateCommand();

                    Cmd.CommandText = @"insert into SYS_COLUMNS_SET (FORM_NAME, VIEW_TYPE, LANG_ID, USER_NO, VIEW_FILE) values (@FORM_NAME,@VIEW_TYPE,@LANG_ID,@USER_NO,@VIEW_FILE) ";
                    Cmd.Parameters.AddWithValue("FORM_NAME", FormName);
                    Cmd.Parameters.AddWithValue("VIEW_TYPE", 0);
                    Cmd.Parameters.AddWithValue("LANG_ID", (int)Program.LangID);
                    Cmd.Parameters.AddWithValue("USER_NO", Program.wmsUser.UserNo);
                    Cmd.Parameters.AddWithValue("VIEW_FILE", new System.Data.SqlTypes.SqlBytes(ViewStream));
                    ViewStream.Seek(0, System.IO.SeekOrigin.Begin);
                    Cmd.ExecuteNonQuery();

                    if (Conn.State == ConnectionState.Open)
                        Conn.Close();

                    Conn.Dispose();
                    Cmd.Dispose();
                }
                catch (SqlException ex)
                {
                    if (Conn.State == ConnectionState.Open)
                        Conn.Close();

                    Conn.Dispose();
                    vPublic.ShowAlert(Fm_Alert.AlertType.Error, ex.Message);
                    return;
                }

                
            }
        }

        private void InitialEditForm()
        {
            gridView1.RestoreLayoutFromStream(layoutStream, DevExpress.Utils.OptionsLayoutBase.FullLayout);
            layoutStream.Seek(0, System.IO.SeekOrigin.Begin);
            foreach (DevExpress.XtraGrid.Columns.GridColumn Item in gridView1.Columns)
            {
                if (EditColumns != null)
                {
                    if (EditColumns.Count > 0)
                    {
                        if (EditColumns.Any(o => o.Name == Item.Name))
                        {
                            continue;
                        }
                        
                    }
                }

                DevExpress.XtraEditors.CheckEdit chk = new DevExpress.XtraEditors.CheckEdit();
                chk.Text = Item.Caption;
                chk.Tag = Item;
                chk.Checked = Item.Visible;
                chk.CheckedChanged += new EventHandler(chk_CheckedChanged);

                chk.Dock = DockStyle.Top;
                
                xtraScrollableControl1.Controls.Add(chk);
                chk.BringToFront();
                //pnlChkList.Controls.Add(chk);
            }
            
            //if (EditColumns != null)
            //{
            //    if (EditColumns.Count > 0)
            //    {
            //        foreach (DevExpress.XtraGrid.Columns.GridColumn Item in gridView1.Columns)
            //        {

            //            if (EditColumns.Any(o => o.Name == Item.Name))
            //            {
            //                Item.Visible = false;
            //            }
            //        }
            //    }
            //}
        }

        void chk_CheckedChanged(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Columns.GridColumn Col = (DevExpress.XtraGrid.Columns.GridColumn)((DevExpress.XtraEditors.CheckEdit)sender).Tag;

            foreach (DevExpress.XtraGrid.Columns.GridColumn Item in gridView1.Columns)
            {
                if (Item.Name == Col.Name)
                    Item.Visible = ((DevExpress.XtraEditors.CheckEdit)sender).Checked;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection(vPublic.ConnStr);
            System.IO.Stream ViewStream = new System.IO.MemoryStream();
            gridView1.SaveLayoutToStream(ViewStream, DevExpress.Utils.OptionsLayoutBase.FullLayout);
            ViewStream.Seek(0, System.IO.SeekOrigin.Begin);
            if (ViewStream != null)
            {
                try
                {
                    Conn = new SqlConnection(vPublic.ConnStr);
                    Conn.Open();
                }
                catch (SqlException ex)
                {
                    vPublic.ShowAlert(Fm_Alert.AlertType.Error, ex.Message);
                    return;
                }

                try
                {
                    var Cmd = Conn.CreateCommand();

                    Cmd.CommandText = "delete SYS_COLUMNS_SET where FORM_NAME = @FORM_NAME and LANG_ID = @LANG_ID and USER_NO = @USER_NO and VIEW_TYPE = @VIEW_TYPE ";
                    Cmd.Parameters.AddWithValue("FORM_NAME", FormName);
                    Cmd.Parameters.AddWithValue("LANG_ID", (int)Program.LangID);
                    Cmd.Parameters.AddWithValue("USER_NO", Program.wmsUser.UserNo);
                    Cmd.Parameters.AddWithValue("VIEW_TYPE", 1);
                    Cmd.ExecuteNonQuery();

                    Cmd.CommandText = @"insert into SYS_COLUMNS_SET (FORM_NAME, VIEW_TYPE, LANG_ID, USER_NO, VIEW_FILE) values (@FORM_NAME,@VIEW_TYPE,@LANG_ID,@USER_NO,@VIEW_FILE) ";
                    Cmd.Parameters.Clear();
                    Cmd.Parameters.AddWithValue("FORM_NAME", FormName);
                    Cmd.Parameters.AddWithValue("VIEW_TYPE", 1);
                    Cmd.Parameters.AddWithValue("LANG_ID", (int)Program.LangID);
                    Cmd.Parameters.AddWithValue("USER_NO", Program.wmsUser.UserNo);
                    Cmd.Parameters.AddWithValue("VIEW_FILE", new System.Data.SqlTypes.SqlBytes(ViewStream));
                    Cmd.ExecuteNonQuery();

                    if (Conn.State == ConnectionState.Open)
                        Conn.Close();

                    Conn.Dispose();
                    Cmd.Dispose();
                }
                catch (SqlException ex)
                {
                    if (Conn.State == ConnectionState.Open)
                        Conn.Close();

                    Conn.Dispose();
                    vPublic.ShowAlert(Fm_Alert.AlertType.Error, ex.Message);
                    //MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            this.DialogResult = DialogResult.Yes;
            Close();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (xtraScrollableControl1.Controls.Count > 0)
            {
                foreach (Control Ctrl in xtraScrollableControl1.Controls)
                {
                    if (Ctrl is DevExpress.XtraEditors.CheckEdit)
                    {
                        ((DevExpress.XtraEditors.CheckEdit)Ctrl).Checked = chkAll.Checked;
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            vPublic.RestoreViewLayoutByStream(gridView1, FormName, 0, false);

            foreach (DevExpress.XtraGrid.Columns.GridColumn Item in gridView1.Columns)
            {
                foreach (Control Ctrl in xtraScrollableControl1.Controls)
                {
                    DevExpress.XtraGrid.Columns.GridColumn Col = (DevExpress.XtraGrid.Columns.GridColumn)((DevExpress.XtraEditors.CheckEdit)Ctrl).Tag;

                    if (Col.Name == Item.Name)
                    {
                        ((DevExpress.XtraEditors.CheckEdit)Ctrl).Checked = Item.Visible;
                    }
                }
            }
        }


    }
}
