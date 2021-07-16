using System;
using System.Reflection;
using System.Windows.Forms;

namespace KeyboardHook01
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.logo64;
            LoadLanaguage();
            pictureBox1.Image = Properties.Resources.keyplus_pic;
        }

        private void LoadLanaguage()
        {
            this.Text = Language.GetText("about");
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lblAuthor.Text = "by Gaoxiang Liu";
            lblDate.Text = "June 2021";
            lblTitle.Text = "Key Plus";
            lblVersion.Text = "v" + version;
        }

        private void FormAbout_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
    }
}
