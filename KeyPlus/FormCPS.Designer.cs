
namespace KeyboardHook01
{
    partial class FormCPS
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
            this.lblIntruction = new System.Windows.Forms.Label();
            this.radio1 = new System.Windows.Forms.RadioButton();
            this.radio3 = new System.Windows.Forms.RadioButton();
            this.radio5 = new System.Windows.Forms.RadioButton();
            this.radio10 = new System.Windows.Forms.RadioButton();
            this.radio15s = new System.Windows.Forms.RadioButton();
            this.radio30 = new System.Windows.Forms.RadioButton();
            this.radio60 = new System.Windows.Forms.RadioButton();
            this.radio100 = new System.Windows.Forms.RadioButton();
            this.lblClick = new System.Windows.Forms.Label();
            this.lblElapse = new System.Windows.Forms.Label();
            this.lblClicks = new System.Windows.Forms.Label();
            this.lblCPS = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblTextElapse = new System.Windows.Forms.Label();
            this.lblTextClicks = new System.Windows.Forms.Label();
            this.lblTextCPS = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(194, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(79, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "label1";
            // 
            // lblIntruction
            // 
            this.lblIntruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntruction.Location = new System.Drawing.Point(13, 44);
            this.lblIntruction.Name = "lblIntruction";
            this.lblIntruction.Size = new System.Drawing.Size(459, 154);
            this.lblIntruction.TabIndex = 1;
            this.lblIntruction.Text = "label1";
            // 
            // radio1
            // 
            this.radio1.AutoSize = true;
            this.radio1.Checked = true;
            this.radio1.Location = new System.Drawing.Point(9, 204);
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
            this.radio3.Location = new System.Drawing.Point(64, 204);
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
            this.radio5.Location = new System.Drawing.Point(119, 204);
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
            this.radio10.Location = new System.Drawing.Point(174, 204);
            this.radio10.Name = "radio10";
            this.radio10.Size = new System.Drawing.Size(42, 17);
            this.radio10.TabIndex = 2;
            this.radio10.Text = "10s";
            this.radio10.UseVisualStyleBackColor = true;
            this.radio10.CheckedChanged += new System.EventHandler(this.radio10_CheckedChanged);
            // 
            // radio15s
            // 
            this.radio15s.AutoSize = true;
            this.radio15s.Location = new System.Drawing.Point(235, 204);
            this.radio15s.Name = "radio15s";
            this.radio15s.Size = new System.Drawing.Size(42, 17);
            this.radio15s.TabIndex = 2;
            this.radio15s.Text = "15s";
            this.radio15s.UseVisualStyleBackColor = true;
            this.radio15s.CheckedChanged += new System.EventHandler(this.radio15s_CheckedChanged);
            // 
            // radio30
            // 
            this.radio30.AutoSize = true;
            this.radio30.Location = new System.Drawing.Point(296, 204);
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
            this.radio60.Location = new System.Drawing.Point(357, 204);
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
            this.radio100.Location = new System.Drawing.Point(418, 204);
            this.radio100.Name = "radio100";
            this.radio100.Size = new System.Drawing.Size(48, 17);
            this.radio100.TabIndex = 2;
            this.radio100.Text = "100s";
            this.radio100.UseVisualStyleBackColor = true;
            this.radio100.CheckedChanged += new System.EventHandler(this.radio100_CheckedChanged);
            // 
            // lblClick
            // 
            this.lblClick.BackColor = System.Drawing.Color.White;
            this.lblClick.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblClick.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClick.Location = new System.Drawing.Point(9, 277);
            this.lblClick.Name = "lblClick";
            this.lblClick.Size = new System.Drawing.Size(463, 212);
            this.lblClick.TabIndex = 3;
            this.lblClick.Text = "label1";
            this.lblClick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClick.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblClick_MouseDown);
            // 
            // lblElapse
            // 
            this.lblElapse.AutoSize = true;
            this.lblElapse.Location = new System.Drawing.Point(9, 249);
            this.lblElapse.Name = "lblElapse";
            this.lblElapse.Size = new System.Drawing.Size(39, 13);
            this.lblElapse.TabIndex = 4;
            this.lblElapse.Text = "Elapse";
            // 
            // lblClicks
            // 
            this.lblClicks.AutoSize = true;
            this.lblClicks.Location = new System.Drawing.Point(140, 249);
            this.lblClicks.Name = "lblClicks";
            this.lblClicks.Size = new System.Drawing.Size(35, 13);
            this.lblClicks.TabIndex = 5;
            this.lblClicks.Text = "label1";
            // 
            // lblCPS
            // 
            this.lblCPS.AutoSize = true;
            this.lblCPS.Location = new System.Drawing.Point(267, 249);
            this.lblCPS.Name = "lblCPS";
            this.lblCPS.Size = new System.Drawing.Size(35, 13);
            this.lblCPS.TabIndex = 6;
            this.lblCPS.Text = "label1";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(394, 244);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "button1";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblTextElapse
            // 
            this.lblTextElapse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTextElapse.Location = new System.Drawing.Point(60, 244);
            this.lblTextElapse.Name = "lblTextElapse";
            this.lblTextElapse.Size = new System.Drawing.Size(68, 23);
            this.lblTextElapse.TabIndex = 8;
            // 
            // lblTextClicks
            // 
            this.lblTextClicks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTextClicks.Location = new System.Drawing.Point(187, 244);
            this.lblTextClicks.Name = "lblTextClicks";
            this.lblTextClicks.Size = new System.Drawing.Size(68, 23);
            this.lblTextClicks.TabIndex = 8;
            // 
            // lblTextCPS
            // 
            this.lblTextCPS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTextCPS.Location = new System.Drawing.Point(314, 244);
            this.lblTextCPS.Name = "lblTextCPS";
            this.lblTextCPS.Size = new System.Drawing.Size(68, 23);
            this.lblTextCPS.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormCPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 501);
            this.Controls.Add(this.lblTextCPS);
            this.Controls.Add(this.lblTextClicks);
            this.Controls.Add(this.lblTextElapse);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblCPS);
            this.Controls.Add(this.lblClicks);
            this.Controls.Add(this.lblElapse);
            this.Controls.Add(this.lblClick);
            this.Controls.Add(this.radio100);
            this.Controls.Add(this.radio60);
            this.Controls.Add(this.radio30);
            this.Controls.Add(this.radio15s);
            this.Controls.Add(this.radio10);
            this.Controls.Add(this.radio5);
            this.Controls.Add(this.radio3);
            this.Controls.Add(this.radio1);
            this.Controls.Add(this.lblIntruction);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 540);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 540);
            this.Name = "FormCPS";
            this.Text = "FormCPS";
            this.Load += new System.EventHandler(this.FormCPS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblIntruction;
        private System.Windows.Forms.RadioButton radio1;
        private System.Windows.Forms.RadioButton radio3;
        private System.Windows.Forms.RadioButton radio5;
        private System.Windows.Forms.RadioButton radio10;
        private System.Windows.Forms.RadioButton radio15s;
        private System.Windows.Forms.RadioButton radio30;
        private System.Windows.Forms.RadioButton radio60;
        private System.Windows.Forms.RadioButton radio100;
        private System.Windows.Forms.Label lblClick;
        private System.Windows.Forms.Label lblElapse;
        private System.Windows.Forms.Label lblClicks;
        private System.Windows.Forms.Label lblCPS;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblTextElapse;
        private System.Windows.Forms.Label lblTextClicks;
        private System.Windows.Forms.Label lblTextCPS;
        private System.Windows.Forms.Timer timer1;
    }
}