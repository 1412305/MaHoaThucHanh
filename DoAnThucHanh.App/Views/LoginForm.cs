using DoAnThucHanh.App.Enums;
using DoAnThucHanh.App.Models;
using System;
using System.IO;
using System.Windows.Forms;

namespace DoAnThucHanh.App.Views
{
    public partial class LoginForm : Form
    {
        public LoginModel Model { get; set; }
        public FormEnum AuthenticateFor { get; set; }

        public LoginForm()
        {
            Model = new LoginModel();
            InitializeComponent();
        }

        private void emailTxt_TextChanged(object sender, EventArgs e)
        {
            this.Model.Email = this.emailTxt.Text;
        }

        private void passTxt_TextChanged(object sender, EventArgs e)
        {
            this.Model.Passphrase = this.passTxt.Text;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.Model.WarningMessage = string.Empty;
            var isValid = this.Model.IsUserValid();

            if (isValid)
            {
                switch (AuthenticateFor)
                {
                    case FormEnum.UpdateForm:
                        var updateForm = new UserUpdateForm();
                        updateForm.Model.User = this.Model.User;
                        updateForm.Show();
                        break;
                    case FormEnum.ExportKeyForm:
                        this.ExportKeyPair();
                        break;
                    case FormEnum.DecryptFileForm:
                        var decryptFileForm = new FileDecryptForm();
                        decryptFileForm.Model.User = this.Model.User;
                        decryptFileForm.Show();
                        break;
                    case FormEnum.SignFileForm:
                        var signFileForm = new FileSignForm();
                        signFileForm.Model.User = this.Model.User;
                        signFileForm.Show();
                        break;
                }

                this.Close();
            }

            if (!string.IsNullOrWhiteSpace(this.Model.WarningMessage))
            {
                MessageBox.Show(this.Model.WarningMessage,
                              "Sign Up",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
            }
        }

        private void ExportKeyPair()
        {
            var fileName = string.Empty;
            using (var openFileDialog = new SaveFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = Path.ChangeExtension(openFileDialog.FileName, "xml");
                    this.Model.ExportKeyPair(fileName);
                    MessageBox.Show("Exported successfully",
                            "Export",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                }
            }
        }
    }
}
