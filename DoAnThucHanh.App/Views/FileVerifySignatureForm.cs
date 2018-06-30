using DoAnThucHanh.App.Models;
using System;
using System.Windows.Forms;

namespace DoAnThucHanh.App.Views
{
    public partial class FileVerifySignatureForm : Form
    {
        public FileVerifySignatureModel Model { get; set; }

        public FileVerifySignatureForm()
        {
            Model = new FileVerifySignatureModel();
            InitializeComponent();
        }

        private void browseVerifyButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.Model.FileVerifyName = dialog.FileName;
                    this.fileVerifyTxt.Text = dialog.FileName;
                }
            }
        }

        private void fileSignatureButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.Model.FileSignatureName = dialog.FileName;
                    this.fileSignatureTxt.Text = dialog.FileName;
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void verifyButton_Click(object sender, EventArgs e)
        {
            this.Model.WarningMessage = string.Empty;
            var isSucessful = this.Model.VerifySignature();

            if (isSucessful)
            {
                MessageBox.Show(this.Model.InfoMessage,
                             "Signature Verify",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
            }

            if (!string.IsNullOrWhiteSpace(this.Model.WarningMessage))
            {
                MessageBox.Show(this.Model.WarningMessage,
                              "Signature Verify",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
            }
        }
    }
}
