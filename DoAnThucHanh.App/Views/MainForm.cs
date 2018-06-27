using DoAnThucHanh.App.Enums;
using DoAnThucHanh.App.Models;
using System.Windows.Forms;

namespace DoAnThucHanh.App.Views
{
    public partial class MainForm : Form
    {
        public MainFormModel Model { get; set; }

        public MainForm()
        {
            Model = new MainFormModel();
            InitializeComponent();
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

    }
}
