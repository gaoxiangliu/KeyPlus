using System;
using System.Windows.Forms;

namespace KeyboardHook01
{
    public partial class FormSettings : Form
    {
        private Form1 form1 = null;

        public FormSettings(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.logo64;
            LoadLangae();
            LoadInitialValue();
        }

        public void LoadLangae()
        {
            this.Text = Language.GetText("settings");
            grpFile.Text = Language.GetText("statistics_file");
            grpGeneral.Text = Language.GetText("general");
            checkStartup.Text = Language.GetText("run_startup");
            btnResetSettings.Text = Language.GetText("reset_settings");
            lblSaveInterval.Text = Language.GetText("save_interval");
            btnSet.Text = Language.GetText("set");
            btnResetTotal.Text = Language.GetText("reset_total_keystrokes");
            checkExitAfterAlert.Text = Language.GetText("exit_after_alert");
            checkMessageBox.Text = Language.GetText("message_box");
            checkNotification.Text = Language.GetText("windows_notification");
            checkHideMainWindow.Text = Language.GetText("hide_main_window");
            groupNotify.Text = Language.GetText("notify_when_saving");
        }

        public void LoadInitialValue()
        {
            if (Configure.runOnStartUp == 1)
            {
                checkStartup.Checked = true;
            }
            else if (Configure.runOnStartUp == 0)
            {
                checkStartup.Checked = false;
            }

            if (Configure.exitAfterAlert == 1)
            {
                checkExitAfterAlert.Checked = true;
            }
            else if (Configure.exitAfterAlert == 0)
            {
                checkExitAfterAlert.Checked = false;
            }

            if (Configure.hideFormAfterRunning == 0)
            {
                checkHideMainWindow.Checked = false;
            }
            else if (Configure.hideFormAfterRunning == 1)
            {
                checkHideMainWindow.Checked = true;
            }

            if ((Configure.saveNotify & 1) == 1)
            {
                checkMessageBox.Checked = true;
            }
            if ((Configure.saveNotify & 2) == 2)
            {
                checkNotification.Checked = true;
            }

            txtInterval.Text = Configure.totalKeystrkesSaveInterval.ToString();
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            btnClearFocus.Focus();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            int interval;
            try
            {
                interval = Convert.ToInt32(txtInterval.Text);
                if (interval < Configure.lowerInterval)
                {
                    txtInterval.Text = Configure.lowerInterval.ToString();
                    MessageBox.Show(Language.GetText("integer_lower_alert") + Configure.lowerInterval, Language.GetText("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (interval > Configure.upperInterval)
                {
                    txtInterval.Text = Configure.upperInterval.ToString();
                    MessageBox.Show(Language.GetText("integer_upper_alert") + Configure.upperInterval, Language.GetText("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // okay
                    Configure.totalKeystrkesSaveInterval = interval;
                    Storage.WriteConfigurationToFile();
                    if (form1 != null)
                        form1.UpdateTimerInterval();
                    MessageBox.Show(Language.GetText("success"), Language.GetText("info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                txtInterval.Text = Configure.totalKeystrkesSaveInterval.ToString();
                MessageBox.Show(Language.GetText("integer_invalid_alert"), Language.GetText("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnClearFocus.Focus();
        }

        private void btnResetTotal_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(Language.GetText("real_reset_total"), Language.GetText("warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                var result1 = MessageBox.Show(Language.GetText("double_confirm"), Language.GetText("warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result1 == DialogResult.Yes)
                {
                    Keyboard.ResetCount();
                    form1.InitializeUIComponents();
                    Storage.WriteToTotalStatisticsFile();
                }
            }
            btnClearFocus.Focus();
        }

        private void btnResetSettings_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(Language.GetText("reset_configuration_alert"), Language.GetText("warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                var result1 = MessageBox.Show(Language.GetText("double_confirm"), Language.GetText("warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result1 == DialogResult.Yes)
                {
                    Configure.InitilizeConfiguration();
                    form1.InitializeUIComponents();
                    Storage.WriteConfigurationToFile();
                    this.Close();
                }
            }
            btnClearFocus.Focus();
        }

        private void checkStartup_CheckedChanged(object sender, EventArgs e)
        {
            if (checkStartup.Checked == true)
            {
                Configure.runOnStartUp = 1;
                form1.RunOnStartUpBasedOnSettings();
            }
            else
            {
                var resutlt = MessageBox.Show(Language.GetText("run_on_startup_alert"), Language.GetText("warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resutlt == DialogResult.Yes)
                {
                    Configure.runOnStartUp = 0;
                    form1.RunOnStartUpBasedOnSettings();
                }
                else
                {
                    checkStartup.Checked = true;
                }
            }
        }

        private void checkExitAfterAlert_CheckedChanged(object sender, EventArgs e)
        {
            if (checkExitAfterAlert.Checked == true)
            {
                Configure.exitAfterAlert = 1;
            }
            else
            {
                Configure.exitAfterAlert = 0;
            }
            Storage.WriteConfigurationToFile();
        }

        private void checkHideMainWindow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHideMainWindow.Checked == true)
            {
                Configure.hideFormAfterRunning = 1;
            }
            else
            {
                Configure.hideFormAfterRunning = 0;
            }
            Storage.WriteConfigurationToFile();
        }

        private void checkMessageBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMessageBox.Checked == true)
            {
                Configure.saveNotify |= 1;
            }
            else
            {
                Configure.saveNotify ^= 1;
            }
            Storage.WriteConfigurationToFile();
        }

        private void checkNotification_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNotification.Checked == true)
            {
                Configure.saveNotify |= 2;
            }
            else
            {
                Configure.saveNotify ^= 2;
            }
        }
    }
}
