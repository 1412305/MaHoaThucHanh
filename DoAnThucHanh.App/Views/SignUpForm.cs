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
        private const int MaxKeySize = 1014;

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
            for (int i = MinKeySize; i <= MaxKeySize + 1; i += 64)
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

        private void signUpButton_Click(object sender, EventArgs e)
        {
            var isSucessful = this.Model.SignUp();

            if (isSucessful)
            {
                MessageBox.Show(this.Model.InfoMessage,
                             "Sign Up",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this.Model.WarningMessage,
                              "Sign Up",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
            }

            this.DialogResult = DialogResult.Cancel;
        }
        #endregion
    }
}
