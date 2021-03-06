﻿using DoAnThucHanh.App.Models;
using System;
using System.Windows.Forms;

namespace DoAnThucHanh.App.Views
{
    public partial class FileDecryptForm : Form
    {
        public FileDecryptModel Model { get; set; }

        public FileDecryptForm()
        {
            Model = new FileDecryptModel();
            InitializeComponent();
        }

        private void browseDecryptButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.Model.FileDecryptName = dialog.FileName;
                    this.fileDecryptTxt.Text = dialog.FileName;
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            this.Model.WarningMessage = string.Empty;
            var isSucessful = this.Model.DecryptFile();

            if (isSucessful)
            {
                MessageBox.Show("Decrypted successfully",
                             "File Decrypt",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            if (!string.IsNullOrWhiteSpace(this.Model.WarningMessage))
            {
                MessageBox.Show(this.Model.WarningMessage,
                              "File Decrypt",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
            }
        }
    }
}
