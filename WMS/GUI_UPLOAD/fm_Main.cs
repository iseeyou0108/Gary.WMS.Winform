using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Data.SqlClient;

namespace GUI_UPLOAD
{
    public partial class fm_Main : Form
    {
        string ConnStr = "Data Source=192.168.1.65;Initial Catalog=ASRS_XINFA;User ID=sa;Password=123;";

        public fm_Main()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            //資料夾路徑
            string path = string.Empty;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                path = folderBrowserDialog1.SelectedPath;
            else
                return;
            

            //TreeView根節點
            //TreeNode node = treeView1.Nodes.Add(path);
            treeView1.Nodes.Clear();
            //呼叫遞迴
            DirectoryToTree(path, treeView1.Nodes);

            treeView1.ExpandAll();

            lblMsg.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        private void DirectoryToTree(string path, TreeNodeCollection nodes)
        {
            foreach (string item in Directory.GetDirectories(path))
            {
                TreeNode node = nodes.Add(Path.GetFileName(item));
                DirectoryToTree(item, node.Nodes);
            }
            string[] strFiles = Directory.GetFiles(path);
            foreach (string str in strFiles)
            {
                TreeNode fileNode = new TreeNode()
                {
                    Text = Path.GetFileName(str),
                    Tag = str
                };

                nodes.Add(fileNode);
            }
        }

        // Return a list of the TreeNodes that are checked.
        private void FindCheckedNodes(
            List<TreeNode> checked_nodes, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                // Add this node.
                if (!node.Checked) checked_nodes.Add(node);

                // Check the node's descendants.
                FindCheckedNodes(checked_nodes, node.Nodes);
            }
        }

        // Return a list of the checked TreeView nodes.
        private List<TreeNode> CheckedNodes(TreeView trv)
        {
            List<TreeNode> checked_nodes = new List<TreeNode>();
            FindCheckedNodes(checked_nodes, treeView1.Nodes);
            return checked_nodes;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            List<TreeNode> checked_nodes = CheckedNodes(treeView1);

            foreach (var Item in checked_nodes)
            {
                if (Item.Tag != null)
                {

                    string sFilePath = Item.Parent != null ? "\\"+Item.Parent.Text : "";
                    string sFileVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(Item.Tag.ToString()).FileVersion;
                    var fileBody = File.ReadAllBytes(Item.Tag.ToString());
                    FileInfo f = new FileInfo(Item.Tag.ToString());
                    var fileSize = f.Length;
                    string sFileName = Path.GetFileName(Item.Tag.ToString());

                    SqlConnection Conn = new SqlConnection(ConnStr);

                    try
                    {
                        Conn.Open();
                        int rtn = 0;
                        var Cmd = Conn.CreateCommand();
                        Cmd.CommandText = "delete from SYS_UPDATE where FILE_NAME = @FILE_NAME ";
                        Cmd.Parameters.Clear();
                        Cmd.Parameters.AddWithValue("FILE_NAME", sFileName);
                        rtn = Cmd.ExecuteNonQuery();

                        Cmd.CommandText = "insert into SYS_UPDATE ( FILE_PATH, FILE_NAME, FILE_BODY, FILE_VERSION, FILE_EXECUTE, FILE_SIZE, UPDATE_DATE, UPDATE_BY) "+
                                          "                 values(@FILE_PATH,@FILE_NAME,@FILE_BODY,@FILE_VERSION,@FILE_EXECUTE,@FILE_SIZE,@UPDATE_DATE,@UPDATE_BY) ";
                        Cmd.Parameters.Clear();
                        Cmd.Parameters.AddWithValue("FILE_PATH", sFilePath);
                        Cmd.Parameters.AddWithValue("FILE_NAME", sFileName);
                        Cmd.Parameters.AddWithValue("FILE_BODY", fileBody);
                        Cmd.Parameters.AddWithValue("FILE_VERSION", sFileVersion);
                        Cmd.Parameters.AddWithValue("FILE_EXECUTE", sFileName == "WMS.exe" ? 1 : 0);
                        Cmd.Parameters.AddWithValue("FILE_SIZE", fileSize);
                        Cmd.Parameters.AddWithValue("UPDATE_DATE", DateTime.Now);
                        Cmd.Parameters.AddWithValue("UPDATE_BY", "GUI_UPLOAD.exe");
                        rtn = Cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }

            lblMsg.Text = string.Format("{0} - 上傳完成....", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
