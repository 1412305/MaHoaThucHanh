using DoAnThucHanh.App.DTOs;
using DoAnThucHanh.App.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DoAnThucHanh.App.Views
{
    public partial class SignUpForm : Form
    {
        private SignUpModel Model { get; set; }
        private const int MinKeySize = 512;
        private const int MaxKeySize = 1024;

        #region Constructor
        public SignUpForm()
        {
            Model = new SignUpModel();
            InitializeComponent();
        }
        #endregion

        #region Load
        private void SignUpForm_Load(object sender, EventArgs e)
        {
            var keySizes = new List<TextValuePair>();
            for (int i = MinKeySize; i <= MaxKeySize; i += 64)
            {
                var keyValuePair = new TextValuePair(i.ToString(), i);
                keySizes.Add(keyValuePair);
            }

            this.keySizeCb.DisplayMember = nameof(TextValuePair.Text);
            this.keySizeCb.ValueMember = nameof(TextValuePair.Value);
            this.keySizeCb.DataSource = keySizes;
            this.keySizeCb.SelectedIndex = 0;
        }
        #endregion

        #region Control events
        private void emailTxt_TextChanged(object sender, EventArgs e)
        {
            this.Model.User.Email = this.emailTxt.Text;
        }

        private void passTxt_TextChanged(object sender, EventArgs e)
        {
            this.Model.User.Passphrase = this.passTxt.Text;
        }

        private void keySizeCb_SelectedValueChanged(object sender, EventArgs e)
        {
            this.Model.KeySize = (int?)this.keySizeCb.SelectedValue;
        }

        private void nameTxt_TextChanged(object sender, EventArgs e)
        {
            this.Model.User.Name = this.nameTxt.Text;
        }

        private void addressTxt_TextChanged(object sender, EventArgs e)
        {
            this.Model.User.Address = this.addressTxt.Text;
        }

        private void phoneTxt_TextChanged(object sender, EventArgs e)
        {
            this.Model.User.Phone = this.phoneTxt.Text;
        }

        private void birthTxt_ValueChanged(object sender, EventArgs e)
        {
            this.Model.User.Birth = this.birthTxt.Text;
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            this.Model.WarningMessage = string.Empty;
            var isSucessful = this.Model.SignUp();

            if (isSucessful)
            {
                MessageBox.Show(this.Model.InfoMessage,
                             "Sign Up",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }

            if (!string.IsNullOrWhiteSpace(this.Model.WarningMessage))
            {
                MessageBox.Show(this.Model.WarningMessage,
                              "Sign Up",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
            }
        }
        #endregion

    }
}
