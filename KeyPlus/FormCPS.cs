using System;
using System.Drawing;
using System.Windows.Forms;

namespace KeyboardHook01
{
    public partial class FormCPS : Form
    {
        private int period;
        private bool ready;
        private int clicks;
        private int elapsed;    // 0.1 seconds

        public FormCPS()
        {
            InitializeComponent();
        }

        private void FormCPS_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.logo64;
            this.Text = Language.GetText("cps_test");
            lblTitle.Text = Language.GetText("cps_test");
            lblIntruction.Text = Language.GetText("cps_instruction");
            lblClick.Text = Language.GetText("cps_click_me");
            lblClicks.Text = Language.GetText("clicks");
            lblElapse.Text = Language.GetText("elapse");
            lblCPS.Text = Language.GetText("cps");
            btnReset.Text = Language.GetText("reset");
            clicks = 0;
            ready = true;
            period = 1;
        }

        private void radio1_CheckedChanged(object sender, EventArgs e)
        {
            period = 1;
        }

        private void radio3_CheckedChanged(object sender, EventArgs e)
        {
            period = 3;
        }

        private void radio5_CheckedChanged(object sender, EventArgs e)
        {
            period = 5;
        }

        private void radio10_CheckedChanged(object sender, EventArgs e)
        {
            period = 10;
        }

        private void radio15s_CheckedChanged(object sender, EventArgs e)
        {
            period = 15;
        }

        private void radio30_CheckedChanged(object sender, EventArgs e)
        {
            period = 30;
        }

        private void radio60_CheckedChanged(object sender, EventArgs e)
        {
            period = 60;
        }

        private void radio100_CheckedChanged(object sender, EventArgs e)
        {
            period = 100;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ready = true;
            clicks = 0;
            elapsed = 0;
            lblClick.Text = Language.GetText("cps_click_me");
            lblClick.BackColor = Color.White;
            lblClick.ForeColor = Color.Black;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ++elapsed;
            lblTextElapse.Text = ((double)elapsed / 10).ToString();
            if (elapsed >= period * 10)
            {
                timer1.Enabled = false;
                ready = false;
                double cps = (double)clicks / period;
                lblTextCPS.Text = cps.ToString();
                lblClick.BackColor = Color.Gray;
                lblClick.ForeColor = Color.White;
                lblClick.Text = "CPS: " + cps + "\n";
                lblClick.Text += Language.GetText("cps_time_is_up");
            }
        }

        private void lblClick_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (clicks == 0 && ready)
                {
                    // start
                    timer1.Enabled = true;
                    lblClick.BackColor = Color.ForestGreen;
                    lblClick.ForeColor = Color.White;
                    ++clicks;
                    lblClick.Text = clicks.ToString();
                    lblTextClicks.Text = clicks.ToString();
                }
                else if (clicks > 0 && ready)
                {
                    ++clicks;
                    lblClick.Text = clicks.ToString();
                    lblTextClicks.Text = clicks.ToString();
                }
            }
        }
    }
}
