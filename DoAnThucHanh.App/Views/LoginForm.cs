using DoAnThucHanh.App.Models;
using System;
using System.Windows.Forms;

namespace DoAnThucHanh.App.Views
{
    public partial class LoginForm : Form
    {
        public LoginModel Model { get; set; }
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
                var updateForm = new UserUpdateForm();
                updateForm.Model.User = this.Model.User;
                updateForm.Show();
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
    }
}
