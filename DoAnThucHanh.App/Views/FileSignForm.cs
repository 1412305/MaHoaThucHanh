using DoAnThucHanh.App.Models;
using System.Windows.Forms;

namespace DoAnThucHanh.App.Views
{
    public partial class FileSignForm : Form
    {
        public FileSignModel Model { get; set; }

        public FileSignForm()
        {
            Model = new FileSignModel();
            InitializeComponent();
        }

        private void browseSignButton_Click(object sender, System.EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.Model.FileSignName = dialog.FileName;
                    this.fileSignTxt.Text = dialog.FileName;
                }
            }
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void signButton_Click(object sender, System.EventArgs e)
        {
            this.Model.WarningMessage = string.Empty;
            var isSucessful = this.Model.SignFile();

            if (isSucessful)
            {
                MessageBox.Show("Signed successfully",
                             "File Sign",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            if (!string.IsNullOrWhiteSpace(this.Model.WarningMessage))
            {
                MessageBox.Show(this.Model.WarningMessage,
                              "File Sign",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
            }
        }
    }
}
