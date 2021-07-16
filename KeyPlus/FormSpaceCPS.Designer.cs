
namespace KeyboardHook01
{
    partial class FormSpaceCPS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.radio1 = new System.Windows.Forms.RadioButton();
            this.radio3 = new System.Windows.Forms.RadioButton();
            this.radio5 = new System.Windows.Forms.RadioButton();
            this.radio10 = new System.Windows.Forms.RadioButton();
            this.radio15 = new System.Windows.Forms.RadioButton();
            this.radio30 = new System.Windows.Forms.RadioButton();
            this.radio60 = new System.Windows.Forms.RadioButton();
            this.radio100 = new System.Windows.Forms.RadioButton();
            this.lblElapse = new System.Windows.Forms.Label();
            this.lblStroke = new System.Windows.Forms.Label();
            this.lblCPS = new System.Windows.Forms.Label();
            this.lblTextElapse = new System.Windows.Forms.Label();
            this.lblTextClicks = new System.Windows.Forms.Label();
            this.lblTextCPS = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblSpacebar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(147, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(70, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "label1";
            // 
            // lblInstruction
            // 
            this.lblInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.Location = new System.Drawing.Point(12, 52);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(455, 160);
            this.lblInstruction.TabIndex = 1;
            this.lblInstruction.Text = "label1";
            // 
            // radio1
            // 
            this.radio1.AutoSize = true;
            this.radio1.Checked = true;
            this.radio1.Location = new System.Drawing.Point(12, 217);
            this.radio1.Name = "radio1";
            this.radio1.Size = new System.Drawing.Size(36, 17);
            this.radio1.TabIndex = 2;
            this.radio1.TabStop = true;
            this.radio1.Text = "1s";
            this.radio1.UseVisualStyleBackColor = true;
            this.radio1.CheckedChanged += new System.EventHandler(this.radio1_CheckedChanged);
            // 
            // radio3
            // 
            this.radio3.AutoSize = true;
            this.radio3.Location = new System.Drawing.Point(66, 217);
            this.radio3.Name = "radio3";
            this.radio3.Size = new System.Drawing.Size(36, 17);
            this.radio3.TabIndex = 2;
            this.radio3.Text = "3s";
            this.radio3.UseVisualStyleBackColor = true;
            this.radio3.CheckedChanged += new System.EventHandler(this.radio3_CheckedChanged);
            // 
            // radio5
            // 
            this.radio5.AutoSize = true;
            this.radio5.Location = new System.Drawing.Point(120, 217);
            this.radio5.Name = "radio5";
            this.radio5.Size = new System.Drawing.Size(36, 17);
            this.radio5.TabIndex = 2;
            this.radio5.Text = "5s";
            this.radio5.UseVisualStyleBackColor = true;
            this.radio5.CheckedChanged += new System.EventHandler(this.radio5_CheckedChanged);
            // 
            // radio10
            // 
            this.radio10.AutoSize = true;
            this.radio10.Location = new System.Drawing.Point(174, 217);
            this.radio10.Name = "radio10";
            this.radio10.Size = new System.Drawing.Size(42, 17);
            this.radio10.TabIndex = 2;
            this.radio10.Text = "10s";
            this.radio10.UseVisualStyleBackColor = true;
            this.radio10.CheckedChanged += new System.EventHandler(this.radio10_CheckedChanged);
            // 
            // radio15
            // 
            this.radio15.AutoSize = true;
            this.radio15.Location = new System.Drawing.Point(234, 217);
            this.radio15.Name = "radio15";
            this.radio15.Size = new System.Drawing.Size(42, 17);
            this.radio15.TabIndex = 2;
            this.radio15.Text = "15s";
            this.radio15.UseVisualStyleBackColor = true;
            this.radio15.CheckedChanged += new System.EventHandler(this.radio15_CheckedChanged);
            // 
            // radio30
            // 
            this.radio30.AutoSize = true;
            this.radio30.Location = new System.Drawing.Point(294, 217);
            this.radio30.Name = "radio30";
            this.radio30.Size = new System.Drawing.Size(42, 17);
            this.radio30.TabIndex = 2;
            this.radio30.Text = "30s";
            this.radio30.UseVisualStyleBackColor = true;
            this.radio30.CheckedChanged += new System.EventHandler(this.radio30_CheckedChanged);
            // 
            // radio60
            // 
            this.radio60.AutoSize = true;
            this.radio60.Location = new System.Drawing.Point(354, 217);
            this.radio60.Name = "radio60";
            this.radio60.Size = new System.Drawing.Size(42, 17);
            this.radio60.TabIndex = 2;
            this.radio60.Text = "60s";
            this.radio60.UseVisualStyleBackColor = true;
            this.radio60.CheckedChanged += new System.EventHandler(this.radio60_CheckedChanged);
            // 
            // radio100
            // 
            this.radio100.AutoSize = true;
            this.radio100.Location = new System.Drawing.Point(414, 217);
            this.radio100.Name = "radio100";
            this.radio100.Size = new System.Drawing.Size(48, 17);
            this.radio100.TabIndex = 2;
            this.radio100.Text = "100s";
            this.radio100.UseVisualStyleBackColor = true;
            this.radio100.CheckedChanged += new System.EventHandler(this.radio100_CheckedChanged);
            // 
            // lblElapse
            // 
            this.lblElapse.AutoSize = true;
            this.lblElapse.Location = new System.Drawing.Point(9, 259);
            this.lblElapse.Name = "lblElapse";
            this.lblElapse.Size = new System.Drawing.Size(39, 13);
            this.lblElapse.TabIndex = 4;
            this.lblElapse.Text = "Elapse";
            // 
            // lblStroke
            // 
            this.lblStroke.AutoSize = true;
            this.lblStroke.Location = new System.Drawing.Point(179, 259);
            this.lblStroke.Name = "lblStroke";
            this.lblStroke.Size = new System.Drawing.Size(43, 13);
            this.lblStroke.TabIndex = 4;
            this.lblStroke.Text = "Strokes";
            // 
            // lblCPS
            // 
            this.lblCPS.AutoSize = true;
            this.lblCPS.Location = new System.Drawing.Point(355, 259);
            this.lblCPS.Name = "lblCPS";
            this.lblCPS.Size = new System.Drawing.Size(28, 13);
            this.lblCPS.TabIndex = 4;
            this.lblCPS.Text = "CPS";
            // 
            // lblTextElapse
            // 
            this.lblTextElapse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTextElapse.Location = new System.Drawing.Point(61, 256);
            this.lblTextElapse.Name = "lblTextElapse";
            this.lblTextElapse.Size = new System.Drawing.Size(80, 20);
            this.lblTextElapse.TabIndex = 5;
            this.lblTextElapse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTextClicks
            // 
            this.lblTextClicks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTextClicks.Location = new System.Drawing.Point(236, 256);
            this.lblTextClicks.Name = "lblTextClicks";
            this.lblTextClicks.Size = new System.Drawing.Size(80, 20);
            this.lblTextClicks.TabIndex = 5;
            this.lblTextClicks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTextCPS
            // 
            this.lblTextCPS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTextCPS.Location = new System.Drawing.Point(392, 256);
            this.lblTextCPS.Name = "lblTextCPS";
            this.lblTextCPS.Size = new System.Drawing.Size(80, 20);
            this.lblTextCPS.TabIndex = 5;
            this.lblTextCPS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblSpacebar
            // 
            this.lblSpacebar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSpacebar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpacebar.Location = new System.Drawing.Point(12, 297);
            this.lblSpacebar.Name = "lblSpacebar";
            this.lblSpacebar.Size = new System.Drawing.Size(460, 148);
            this.lblSpacebar.TabIndex = 6;
            this.lblSpacebar.Text = "label1";
            this.lblSpacebar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSpacebar.Click += new System.EventHandler(this.lblSpacebar_Click);
            // 
            // FormSpaceCPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 454);
            this.Controls.Add(this.lblSpacebar);
            this.Controls.Add(this.lblTextCPS);
            this.Controls.Add(this.lblTextClicks);
            this.Controls.Add(this.lblTextElapse);
            this.Controls.Add(this.lblCPS);
            this.Controls.Add(this.lblStroke);
            this.Controls.Add(this.lblElapse);
            this.Controls.Add(this.radio100);
            this.Controls.Add(this.radio60);
            this.Controls.Add(this.radio30);
            this.Controls.Add(this.radio15);
            this.Controls.Add(this.radio10);
            this.Controls.Add(this.radio5);
            this.Controls.Add(this.radio3);
            this.Controls.Add(this.radio1);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 493);
            this.MinimumSize = new System.Drawing.Size(500, 493);
            this.Name = "FormSpaceCPS";
            this.Text = "FormSpaceCPS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSpaceCPS_FormClosing);
            this.Load += new System.EventHandler(this.FormSpaceCPS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.RadioButton radio1;
        private System.Windows.Forms.RadioButton radio3;
        private System.Windows.Forms.RadioButton radio5;
        private System.Windows.Forms.RadioButton radio10;
        private System.Windows.Forms.RadioButton radio15;
        private System.Windows.Forms.RadioButton radio30;
        private System.Windows.Forms.RadioButton radio60;
        private System.Windows.Forms.RadioButton radio100;
        private System.Windows.Forms.Label lblElapse;
        private System.Windows.Forms.Label lblStroke;
        private System.Windows.Forms.Label lblCPS;
        private System.Windows.Forms.Label lblTextElapse;
        private System.Windows.Forms.Label lblTextClicks;
        private System.Windows.Forms.Label lblTextCPS;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblSpacebar;
    }
}