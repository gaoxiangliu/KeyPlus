using System;
using System.Drawing;
using System.Windows.Forms;

namespace KeyboardHook01
{
    public partial class FormSpaceCPS : Form
    {
        private int period;
        private int elapse;
        private bool ready;
        private int clicks;

        public FormSpaceCPS()
        {
            InitializeComponent();
        }

        private void FormSpaceCPS_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.logo64;
            this.Text = Language.GetText("spacebar_test");
            lblTitle.Text = Language.GetText("spacebar_test");
            lblInstruction.Text = Language.GetText("spacebar_intruction");
            lblStroke.Text = Language.GetText("strokes");
            lblElapse.Text = Language.GetText("elapse");
            lblCPS.Text = Language.GetText("cps");
            lblSpacebar.Text = Language.GetText("spacebar_click_me");
            lblSpacebar.BackColor = Color.White;
            period = 1;
            elapse = 0;
            clicks = 0;
            ready = false;
        }

        public bool isReady()
        {
            return this.ready;
        }

        public void SpacePressedDown()
        {
            if (ready && clicks == 0)
            {
                ++clicks;
                lblSpacebar.BackColor = Color.ForestGreen;
                lblSpacebar.ForeColor = Color.White;
                timer1.Enabled = true;
                lblSpacebar.Text = clicks.ToString();
                lblTextClicks.Text = clicks.ToString();
            }
            else if (ready && clicks > 0)
            {
                ++clicks;
                lblSpacebar.Text = clicks.ToString();
                lblTextClicks.Text = clicks.ToString();
            }
        }

        private void lblSpacebar_Click(object sender, EventArgs e)
        {
            if (!ready)
            {
                ready = true;
                clicks = 0;
                elapse = 0;
                lblTextClicks.Text = "";
                lblTextCPS.Text = "";
                lblTextElapse.Text = "";
                radio1.Enabled = false;
                radio3.Enabled = false;
                radio5.Enabled = false;
                radio10.Enabled = false;
                radio15.Enabled = false;
                radio30.Enabled = false;
                radio60.Enabled = false;
                radio100.Enabled = false;
                lblSpacebar.Text = Language.GetText("spacebar_ready");
                lblSpacebar.BackColor = Color.White;
                lblSpacebar.ForeColor = Color.Black;
            }
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            ++elapse;
            lblTextElapse.Text = ((double)elapse / 10).ToString();
            if (elapse >= period * 10)
            {
                ready = false;
                timer1.Enabled = false;
                lblSpacebar.BackColor = Color.Gray;
                double cps = (double)clicks / period;
                lblTextCPS.Text = cps.ToString();
                lblSpacebar.Text = "CPS: " + cps + "\n";
                lblSpacebar.Text += Language.GetText("spacebar_time_is_up");
                lblSpacebar.ForeColor = Color.White;
                radio1.Enabled = true;
                radio3.Enabled = true;
                radio5.Enabled = true;
                radio10.Enabled = true;
                radio15.Enabled = true;
                radio30.Enabled = true;
                radio60.Enabled = true;
                radio100.Enabled = true;
            }
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

        private void radio15_CheckedChanged(object sender, EventArgs e)
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

        private void FormSpaceCPS_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
    }
}
