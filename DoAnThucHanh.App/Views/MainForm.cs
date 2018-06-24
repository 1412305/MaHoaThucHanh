using System.Windows.Forms;

namespace DoAnThucHanh.App.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void signUpItem_Click(object sender, System.EventArgs e)
        {
            var signUpForm = new SignUpForm();
            signUpForm.ShowDialog();
        }
    }
}
