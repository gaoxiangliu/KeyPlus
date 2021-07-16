using Microsoft.Win32;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KeyboardHook01
{
    partial class Form1 : Form
    {
        private void SaveManually()
        {
            Storage.WriteConfigurationToFile();
            Storage.WriteToTotalStatisticsFile();
            notifyIcon1.Visible = true;
            if ((Configure.saveNotify & 2) == 2)
                notifyIcon1.ShowBalloonTip(1000, Language.GetText("info"), Language.GetText("save_successfully"), ToolTipIcon.Info);
            if ((Configure.saveNotify & 1) == 1)
                MessageBox.Show(Language.GetText("save_successfully"), Language.GetText("info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void UpdateTimerInterval()
        {
            try
            {
                timer1.Interval = Configure.totalKeystrkesSaveInterval * 1000;
            }
            catch
            {
                timer1.Interval = 600000;
            }
            timer1.Enabled = true;
        }

        public void RunOnStartUpBasedOnSettings()
        {
            if (Configure.runOnStartUp == 0)
            {
                try
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    key.DeleteValue("KeyPlus");
                }
                catch { }
            }
            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                key.SetValue("KeyPlus", "\"" + Application.ExecutablePath + "\" -background");
            }
        }

        public void setWindowCenterPosition()
        {
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            this.StartPosition = FormStartPosition.Manual;
            this.Left = (resolution.Width - this.Width) / 2;
            this.Top = (resolution.Height - this.Height) / 2;
        }

        public void setWindowLeftUpperPosition()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Left = 0;
            this.Top = 0;
        }

        public void showMainWindow()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            btnRemoveFocus.Focus();
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            if (this.Left < (0 - this.Width + 300))
                this.Left = 0;
            if (this.Top < 0)
                this.Top = 0;
            if (this.Left >= resolution.Width - 200)
                this.Left = resolution.Width - this.Width;
            if (this.Top >= resolution.Height - 40)
                this.Top = resolution.Height - this.Height;
        }
    }
}
