using DoAnThucHanh.App.Enums;
using DoAnThucHanh.App.Models;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DoAnThucHanh.App.Views
{
    public partial class MainForm : Form
    {
        public MainFormModel Model { get; set; }
        private string currentDir;

        public MainForm()
        {
            Model = new MainFormModel();
            InitializeComponent();
            currentDir = string.Empty;
            LoadSideBar();
        }

        private void signUpItem_Click(object sender, System.EventArgs e)
        {
            var signUpForm = new SignUpForm();
            signUpForm.ShowDialog();
        }

        private void updateToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.AuthenticateFor = FormEnum.UpdateForm;
            loginForm.ShowDialog();
        }

        private void exportToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.AuthenticateFor = FormEnum.ExportKeyForm;
            loginForm.ShowDialog();
        }

        private void importToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "XML File (.xml) | *.xml;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileName = openFileDialog.FileName;
                    var isImportedSuccessful = this.Model.ImportKeyPair(fileName);
                    if (isImportedSuccessful)
                    {
                        MessageBox.Show("Imported successfully",
                                      "Import",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                        return;
                    }

                    if (!string.IsNullOrWhiteSpace(this.Model.WarningMessage))
                    {
                        MessageBox.Show(this.Model.WarningMessage,
                                      "Sign Up",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void symetricEncryptToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fileEncryptForm = new FileEncryptForm();
            fileEncryptForm.ShowDialog();
        }

        private void symetricDecryptToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.AuthenticateFor = FormEnum.DecryptFileForm;
            loginForm.ShowDialog();
        }

        private void signToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.AuthenticateFor = FormEnum.SignFileForm;
            loginForm.ShowDialog();
        }

        private void verifySignatureToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fileVerifySignatureForm = new FileVerifySignatureForm();
            fileVerifySignatureForm.ShowDialog();
        }

        private void LoadSideBar()
        {
            treeView1.BeginUpdate();

            foreach (var drive in Environment.GetLogicalDrives())
            {
                var driveNode = new TreeNode(drive.Remove(2, 1));
                driveNode.ImageKey = "disk";
                driveNode.SelectedImageKey = "disk";
                if (string.Equals(drive, "C:\\"))
                {
                    treeView1.SelectedNode = driveNode;
                }

                treeView1.Nodes.Add(driveNode);
            }

            treeView1.EndUpdate();
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AddDirectories(e.Node);

            treeView1.SelectedNode.Expand();

            AddFiles(e.Node.FullPath.ToString());
        }

        private void AddDirectories(TreeNode dirNode)
        {
            treeView1.BeginUpdate();

            try
            {
                DirectoryInfo rootDir;

                var drives = Environment.GetLogicalDrives().ToList();
                drives.ForEach(i => i.Remove(2, 1));

                if (drives.Contains(dirNode.Name))
                {
                    dirNode.ImageKey = "disk";
                    dirNode.SelectedImageKey = "disk";
                }

                if (dirNode.SelectedImageIndex < 11)
                {
                    rootDir = new DirectoryInfo(dirNode.FullPath + "\\");
                }
                else
                {
                    rootDir = new DirectoryInfo(dirNode.FullPath);
                }
                var dirs = rootDir.GetDirectories();
                currentDir = rootDir.FullName;
                dirNode.Nodes.Clear();

                foreach (var dir in dirs)
                {
                    var subNode = new TreeNode(dir.Name);
                    subNode.ImageKey = "folder";
                    subNode.SelectedImageKey = "folder";

                    dirNode.Nodes.Add(subNode);
                }

            }
            catch {; }

            treeView1.EndUpdate();
        }

        private void AddFiles(string path)
        {
            listView1.BeginUpdate();

            listView1.Items.Clear();

            var dirInfo = new DirectoryInfo(path + "\\");
            try
            {
                var files = dirInfo.GetFiles();
                foreach (var file in files)
                {
                    var lvItem = new ListViewItem(file.Name);
                    lvItem.Name = file.FullName;

                    if (!imageList1.Images.ContainsKey(file.Extension))
                    {
                        var fileIcon = Icon.ExtractAssociatedIcon(file.FullName);
                        imageList1.Images.Add(file.Extension, fileIcon);
                    }
                    lvItem.ImageKey = file.Extension;
                    lvItem.SubItems.Add("File");
                    lvItem.SubItems.Add(file.LastWriteTime.ToLongDateString());
                    listView1.Items.Add(lvItem);
                }
            }
            catch (Exception ex) {; }

            listView1.EndUpdate();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedItems = listView1.SelectedItems;
            var filePaths = new StringCollection();

            foreach (ListViewItem item in selectedItems)
            {
                filePaths.Add(item.Name);
            }

            Clipboard.SetFileDropList(filePaths);
            Clipboard.SetText("Copy");
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var filePaths = Clipboard.GetFileDropList();

            foreach (var filePath in filePaths)
            {
                var fileName = Path.GetFileName(filePath);
                var file = Path.Combine(currentDir, fileName);
                File.Create(file);
                treeView1.SelectedNode = treeView1.SelectedNode;
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var info = listView1.HitTest(e.X, e.Y);
            var item = info.Item;
            if (item != null)
            {
                try
                {
                    var path = treeView1.SelectedNode.FullPath;
                    var fileName = listView1.FocusedItem.Text;

                    Process.Start(path + "\\" + fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
