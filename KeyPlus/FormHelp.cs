using System;
using System.Windows.Forms;

namespace KeyboardHook01
{
    public partial class FormHelp : Form
    {
        /// <summary>
        /// language code the last time open this help window
        /// -1 is not a valid code, and it is the initial code
        /// if the current language code is different, refresh the documentation
        /// if the are the same, do nothing (avoid annoying text position reset)
        /// </summary>
        private int lastLanguageCode = -1;

        public FormHelp()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.logo64;
            LoadLanguage();
        }

        private void LoadLanguage()
        {
            this.Text = Language.GetText("view_help");
            if (Configure.language == 1)
            {
                webBrowser1.DocumentText = Properties.Resources.help_cn;
            }
            else
            {
                webBrowser1.DocumentText = Properties.Resources.help;
            }
            lastLanguageCode = Configure.language;
        }

        private void FormHelp_Load(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void FormHelp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        

        private void FormHelp_Activated(object sender, EventArgs e)
        {
            if ((lastLanguageCode != -1 && lastLanguageCode != Configure.language) || lastLanguageCode == -1)
                LoadLanguage();
        }
    }
}
