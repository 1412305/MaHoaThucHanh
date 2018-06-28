using DoAnThucHanh.App.DTOs;
using DoAnThucHanh.App.Enums;
using DoAnThucHanh.App.Models;
using System;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace DoAnThucHanh.App.Views
{
    public partial class FileEncryptForm : Form
    {
        public FileEncryptModel Model { get; set; }

        public FileEncryptForm()
        {
            Model = new FileEncryptModel();
            InitializeComponent();
        }

        private void FileEncryptForm_Load(object sender, EventArgs e)
        {
            this.algoCb.DisplayMember = nameof(TextValuePair.Text);
            this.algoCb.ValueMember = nameof(TextValuePair.Value);
            this.algoCb.DataSource = this.Model.Algorithms;
            this.algoCb.SelectedIndex = 0;

            this.paddingCb.DisplayMember = nameof(TextValuePair.Text);
            this.paddingCb.ValueMember = nameof(TextValuePair.Value);
            this.paddingCb.DataSource = this.Model.PaddingModes;
            this.paddingCb.SelectedIndex = 0;

            this.modeCb.DisplayMember = nameof(TextValuePair.Text);
            this.modeCb.ValueMember = nameof(TextValuePair.Value);
            this.modeCb.DataSource = this.Model.CipherModes;
            this.modeCb.SelectedIndex = 0;

            this.emailCb.DisplayMember = nameof(TextValuePair.Text);
            this.emailCb.ValueMember = nameof(TextValuePair.Value);
            this.emailCb.DataSource = this.Model.Emails;
            this.emailCb.SelectedIndex = 0;
        }

        private void browseEncryptButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.Model.FileEncryptName = dialog.FileName;
                    this.fileEncryptTxt.Text = dialog.FileName;
                }
            }
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.Model.FileSaveName = dialog.FileName;
                    this.saveFileTxt.Text = dialog.FileName;
                }
            }
        }

        private void emailCb_SelectedValueChanged(object sender, EventArgs e)
        {
            this.Model.Email = (string)this.emailCb.SelectedValue;
        }

        private void algoCb_SelectedValueChanged(object sender, EventArgs e)
        {
            this.Model.EncryptInfo.Algorithm = (Algorithm?)this.algoCb.SelectedValue;
        }

        private void paddingCb_SelectedValueChanged(object sender, EventArgs e)
        {
            this.Model.EncryptInfo.PaddingMode = (PaddingMode?)this.paddingCb.SelectedValue;
        }

        private void modeCb_SelectedValueChanged(object sender, EventArgs e)
        {
            this.Model.EncryptInfo.CipherMode = (CipherMode?)this.modeCb.SelectedValue;
        }

        private void compressCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.Model.EncryptInfo.IsCompressed = this.compressCheckBox.Checked;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            this.Model.EncryptFile();
        }
    }
}
