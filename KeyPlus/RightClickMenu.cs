using System;
using System.Windows.Forms;

namespace KeyboardHook01
{
    partial class Form1 : Form
    {
        private ToolStripMenuItem rightMenuDisplay;
        private ToolStripMenuItem rightMenuCenterWindow;
        private ToolStripMenuItem rightMenuLeftUpperWindow;
        private ToolStripMenuItem rightMenuSave;
        private ToolStripMenuItem rightMenuExit;

        private void CreateRightClickMenu()
        {
            notifyIcon1.Icon = Properties.Resources.logo64;
            notifyIcon1.Text = Language.GetText("program_title");

            rightMenuDisplay = new ToolStripMenuItem(Language.GetText("display_main"));
            rightMenuCenterWindow = new ToolStripMenuItem(Language.GetText("center_window"));
            rightMenuLeftUpperWindow = new ToolStripMenuItem(Language.GetText("left_upper_window"));
            rightMenuSave = new ToolStripMenuItem(Language.GetText("save"));
            rightMenuExit = new ToolStripMenuItem(Language.GetText("exit"));
            rightMenuDisplay.Click += new EventHandler(RightClickMenuHandler);
            rightMenuCenterWindow.Click += new EventHandler(RightClickMenuHandler);
            rightMenuLeftUpperWindow.Click += new EventHandler(RightClickMenuHandler);
            rightMenuSave.Click += new EventHandler(RightClickMenuHandler);
            rightMenuExit.Click += new EventHandler(RightClickMenuHandler);

            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add(rightMenuDisplay);
            contextMenuStrip1.Items.Add(rightMenuCenterWindow);
            contextMenuStrip1.Items.Add(rightMenuLeftUpperWindow);
            contextMenuStrip1.Items.Add("-");
            contextMenuStrip1.Items.Add(rightMenuSave);
            contextMenuStrip1.Items.Add("-");
            contextMenuStrip1.Items.Add(rightMenuExit);
        }

        private void RightClickMenuHandler(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            if (item == rightMenuDisplay)
            {
                showMainWindow();
            }
            else if (item == rightMenuCenterWindow)
            {
                setWindowCenterPosition();
            }
            else if (item == rightMenuLeftUpperWindow)
            {
                setWindowLeftUpperPosition();
            }
            else if (item == rightMenuSave)
            {
                SaveManually();
            }
            else if (item == rightMenuExit)
            {
                if (Configure.exitAfterAlert == 0)
                {
                    Application.Exit();
                }
                else
                {
                    var result = MessageBox.Show(Language.GetText("exit_alert"), Language.GetText("warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                }
            }
        }
    }
}
