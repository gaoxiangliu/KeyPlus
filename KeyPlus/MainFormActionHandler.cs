using System;
using System.Windows.Forms;

namespace KeyboardHook01
{
    partial class Form1 : Form
    {
        private void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveFocus.Focus();
            Configure.colorKeystroke = comboBoxColor.SelectedIndex;
            ShowKeystrokesGraphByCurrentMode();
            ChangeColorToneUI();
        }

        private void radioDelayed_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDelayed.Checked)
            {
                btnRemoveFocus.Focus();
                Configure.refreshMode = 0;
                Storage.WriteConfigurationToFile();
            }
        }

        private void radioRealTime_CheckedChanged(object sender, EventArgs e)
        {
            if (radioRealTime.Checked)
            {
                btnRemoveFocus.Focus();
                Configure.refreshMode = 1;
                ShowKeystrokesGraphByCurrentMode();
                Storage.WriteConfigurationToFile();
            }
        }

        private void radioTotal_CheckedChanged(object sender, EventArgs e)
        {
            if (radioTotal.Checked)
            {
                btnRemoveFocus.Focus();
                Configure.mode = 0;
                ChangeModeUI();
                ShowKeystrokesGraphByCurrentMode();
                Storage.WriteConfigurationToFile();
            }
        }

        private void radioThisTime_CheckedChanged(object sender, EventArgs e)
        {
            if (radioThisTime.Checked)
            {
                btnRemoveFocus.Focus();
                Configure.mode = 1;
                ChangeModeUI();
                ShowKeystrokesGraphByCurrentMode();
                Storage.WriteConfigurationToFile();
            }
        }

        private void radioKeyboardTest_CheckedChanged(object sender, EventArgs e)
        {
            if (radioKeyboardTest.Checked)
            {
                btnRemoveFocus.Focus();
                Configure.mode = 2;
                ChangeModeUI();
                ClearKeyboardColor();
                Storage.WriteConfigurationToFile();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnRemoveFocus.Focus();
            if (Configure.mode == 2)
            {
                ClearKeyboardColor();
                lblKeyInput.Text = "";
            }
            else if (Configure.mode == 1 &&
                MessageBox.Show(Language.GetText("confirm_reset_current"), Language.GetText("warning"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                System.Windows.Forms.DialogResult.Yes)
            {
                Keyboard.ResetCountCurrent();
                ClearKeyboardColor();
            }
            else if (Configure.mode == 0)
            {
                MessageBox.Show(Language.GetText("alert_reset_total"), Language.GetText("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkKeepTrace_CheckedChanged(object sender, EventArgs e)
        {
            btnRemoveFocus.Focus();
            if (checkKeepTrace.Checked)
                Configure.keepTrace = 1;
            else
            {
                Configure.keepTrace = 0;
                ClearKeyboardColor();
            }
            Storage.WriteConfigurationToFile();
        }

        private void btnStatisticsList_Click(object sender, EventArgs e)
        {
            btnRemoveFocus.Focus();
            if (formStatisticsList == null)
                formStatisticsList = new FormStatisticsList();
            if (!FormStatisticsList.open)
                formStatisticsList.RefreshStatisticsList();
            formStatisticsList.Show();
            FormStatisticsList.open = true;
            formStatisticsList.Focus();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Left)
            {
                showMainWindow();
            }
        }
    }
}
