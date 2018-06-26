using DoAnThucHanh.App.Models;
using System.Windows.Forms;

namespace DoAnThucHanh.App.Views
{
    public partial class UserUpdateForm : Form
    {
        public UserUpdateModel Model { get; set; }

        public UserUpdateForm()
        {
            Model = new UserUpdateModel();
            InitializeComponent();
        }

        private void UserUpdateForm_Load(object sender, System.EventArgs e)
        {
            this.emailTxt.Text = this.Model.User.Email;
            this.passTxt.Text = this.Model.User.Passphrase;
            this.nameTxt.Text = this.Model.User.Name;
            this.birthTxt.Text = this.Model.User.Birth;
            this.addressTxt.Text = this.Model.User.Address;
            this.phoneTxt.Text = this.Model.User.Phone;
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void passTxt_TextChanged(object sender, System.EventArgs e)
        {
            this.Model.User.Passphrase = this.passTxt.Text;
        }

        private void nameTxt_TextChanged(object sender, System.EventArgs e)
        {
            this.Model.User.Name = this.nameTxt.Text;
        }

        private void birthTxt_ValueChanged(object sender, System.EventArgs e)
        {
            this.Model.User.Birth = this.birthTxt.Text;
        }

        private void addressTxt_TextChanged(object sender, System.EventArgs e)
        {
            this.Model.User.Address = this.addressTxt.Text;
        }

        private void phoneTxt_TextChanged(object sender, System.EventArgs e)
        {
            this.Model.User.Phone = this.phoneTxt.Text;
        }

        private void updateButton_Click(object sender, System.EventArgs e)
        {
            this.Model.WarningMessage = string.Empty;
            var isSucessful = this.Model.UpdateUserInfo();

            if (isSucessful)
            {
                MessageBox.Show(this.Model.InfoMessage,
                             "Update",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            if (!string.IsNullOrWhiteSpace(this.Model.WarningMessage))
            {
                MessageBox.Show(this.Model.WarningMessage,
                              "Update",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
            }
        }
    }
}
