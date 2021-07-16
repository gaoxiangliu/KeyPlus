
namespace KeyboardHook01
{
    partial class FormSettings
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
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.groupNotify = new System.Windows.Forms.GroupBox();
            this.checkNotification = new System.Windows.Forms.CheckBox();
            this.checkMessageBox = new System.Windows.Forms.CheckBox();
            this.checkHideMainWindow = new System.Windows.Forms.CheckBox();
            this.checkExitAfterAlert = new System.Windows.Forms.CheckBox();
            this.btnResetSettings = new System.Windows.Forms.Button();
            this.checkStartup = new System.Windows.Forms.CheckBox();
            this.grpFile = new System.Windows.Forms.GroupBox();
            this.btnResetTotal = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.lblSaveInterval = new System.Windows.Forms.Label();
            this.btnClearFocus = new System.Windows.Forms.Button();
            this.grpGeneral.SuspendLayout();
            this.groupNotify.SuspendLayout();
            this.grpFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.groupNotify);
            this.grpGeneral.Controls.Add(this.checkHideMainWindow);
            this.grpGeneral.Controls.Add(this.checkExitAfterAlert);
            this.grpGeneral.Controls.Add(this.btnResetSettings);
            this.grpGeneral.Controls.Add(this.checkStartup);
            this.grpGeneral.Location = new System.Drawing.Point(12, 21);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(340, 161);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // groupNotify
            // 
            this.groupNotify.Controls.Add(this.checkNotification);
            this.groupNotify.Controls.Add(this.checkMessageBox);
            this.groupNotify.Location = new System.Drawing.Point(9, 78);
            this.groupNotify.Name = "groupNotify";
            this.groupNotify.Size = new System.Drawing.Size(320, 42);
            this.groupNotify.TabIndex = 4;
            this.groupNotify.TabStop = false;
            this.groupNotify.Text = "groupBox1";
            // 
            // checkNotification
            // 
            this.checkNotification.AutoSize = true;
            this.checkNotification.Location = new System.Drawing.Point(171, 20);
            this.checkNotification.Name = "checkNotification";
            this.checkNotification.Size = new System.Drawing.Size(80, 17);
            this.checkNotification.TabIndex = 1;
            this.checkNotification.Text = "checkBox1";
            this.checkNotification.UseVisualStyleBackColor = true;
            this.checkNotification.CheckedChanged += new System.EventHandler(this.checkNotification_CheckedChanged);
            // 
            // checkMessageBox
            // 
            this.checkMessageBox.AutoSize = true;
            this.checkMessageBox.Location = new System.Drawing.Point(7, 20);
            this.checkMessageBox.Name = "checkMessageBox";
            this.checkMessageBox.Size = new System.Drawing.Size(80, 17);
            this.checkMessageBox.TabIndex = 0;
            this.checkMessageBox.Text = "checkBox1";
            this.checkMessageBox.UseVisualStyleBackColor = true;
            this.checkMessageBox.CheckedChanged += new System.EventHandler(this.checkMessageBox_CheckedChanged);
            // 
            // checkHideMainWindow
            // 
            this.checkHideMainWindow.AutoSize = true;
            this.checkHideMainWindow.Location = new System.Drawing.Point(16, 54);
            this.checkHideMainWindow.Name = "checkHideMainWindow";
            this.checkHideMainWindow.Size = new System.Drawing.Size(80, 17);
            this.checkHideMainWindow.TabIndex = 3;
            this.checkHideMainWindow.Text = "checkBox1";
            this.checkHideMainWindow.UseVisualStyleBackColor = true;
            this.checkHideMainWindow.CheckedChanged += new System.EventHandler(this.checkHideMainWindow_CheckedChanged);
            // 
            // checkExitAfterAlert
            // 
            this.checkExitAfterAlert.AutoSize = true;
            this.checkExitAfterAlert.Location = new System.Drawing.Point(180, 30);
            this.checkExitAfterAlert.Name = "checkExitAfterAlert";
            this.checkExitAfterAlert.Size = new System.Drawing.Size(80, 17);
            this.checkExitAfterAlert.TabIndex = 2;
            this.checkExitAfterAlert.Text = "checkBox1";
            this.checkExitAfterAlert.UseVisualStyleBackColor = true;
            this.checkExitAfterAlert.CheckedChanged += new System.EventHandler(this.checkExitAfterAlert_CheckedChanged);
            // 
            // btnResetSettings
            // 
            this.btnResetSettings.Location = new System.Drawing.Point(9, 126);
            this.btnResetSettings.Name = "btnResetSettings";
            this.btnResetSettings.Size = new System.Drawing.Size(320, 23);
            this.btnResetSettings.TabIndex = 1;
            this.btnResetSettings.TabStop = false;
            this.btnResetSettings.Text = "button1";
            this.btnResetSettings.UseVisualStyleBackColor = true;
            this.btnResetSettings.Click += new System.EventHandler(this.btnResetSettings_Click);
            // 
            // checkStartup
            // 
            this.checkStartup.AutoSize = true;
            this.checkStartup.Location = new System.Drawing.Point(16, 30);
            this.checkStartup.Name = "checkStartup";
            this.checkStartup.Size = new System.Drawing.Size(80, 17);
            this.checkStartup.TabIndex = 0;
            this.checkStartup.TabStop = false;
            this.checkStartup.Text = "checkBox1";
            this.checkStartup.UseVisualStyleBackColor = true;
            this.checkStartup.CheckedChanged += new System.EventHandler(this.checkStartup_CheckedChanged);
            // 
            // grpFile
            // 
            this.grpFile.Controls.Add(this.btnResetTotal);
            this.grpFile.Controls.Add(this.btnSet);
            this.grpFile.Controls.Add(this.txtInterval);
            this.grpFile.Controls.Add(this.lblSaveInterval);
            this.grpFile.Location = new System.Drawing.Point(12, 188);
            this.grpFile.Name = "grpFile";
            this.grpFile.Size = new System.Drawing.Size(340, 94);
            this.grpFile.TabIndex = 0;
            this.grpFile.TabStop = false;
            this.grpFile.Text = "General";
            // 
            // btnResetTotal
            // 
            this.btnResetTotal.Location = new System.Drawing.Point(9, 58);
            this.btnResetTotal.Name = "btnResetTotal";
            this.btnResetTotal.Size = new System.Drawing.Size(325, 23);
            this.btnResetTotal.TabIndex = 3;
            this.btnResetTotal.TabStop = false;
            this.btnResetTotal.Text = "button1";
            this.btnResetTotal.UseVisualStyleBackColor = true;
            this.btnResetTotal.Click += new System.EventHandler(this.btnResetTotal_Click);
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(259, 24);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 2;
            this.btnSet.TabStop = false;
            this.btnSet.Text = "button1";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(153, 26);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(100, 20);
            this.txtInterval.TabIndex = 1;
            this.txtInterval.TabStop = false;
            // 
            // lblSaveInterval
            // 
            this.lblSaveInterval.AutoSize = true;
            this.lblSaveInterval.Location = new System.Drawing.Point(11, 29);
            this.lblSaveInterval.Name = "lblSaveInterval";
            this.lblSaveInterval.Size = new System.Drawing.Size(35, 13);
            this.lblSaveInterval.TabIndex = 0;
            this.lblSaveInterval.Text = "label1";
            // 
            // btnClearFocus
            // 
            this.btnClearFocus.Location = new System.Drawing.Point(63, 205);
            this.btnClearFocus.Name = "btnClearFocus";
            this.btnClearFocus.Size = new System.Drawing.Size(1, 1);
            this.btnClearFocus.TabIndex = 1;
            this.btnClearFocus.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 294);
            this.Controls.Add(this.btnClearFocus);
            this.Controls.Add(this.grpFile);
            this.Controls.Add(this.grpGeneral);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(377, 333);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(377, 333);
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.groupNotify.ResumeLayout(false);
            this.groupNotify.PerformLayout();
            this.grpFile.ResumeLayout(false);
            this.grpFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.GroupBox grpFile;
        private System.Windows.Forms.Button btnResetSettings;
        private System.Windows.Forms.CheckBox checkStartup;
        private System.Windows.Forms.Label lblSaveInterval;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnResetTotal;
        private System.Windows.Forms.Button btnClearFocus;
        private System.Windows.Forms.CheckBox checkExitAfterAlert;
        private System.Windows.Forms.CheckBox checkHideMainWindow;
        private System.Windows.Forms.GroupBox groupNotify;
        private System.Windows.Forms.CheckBox checkNotification;
        private System.Windows.Forms.CheckBox checkMessageBox;
    }
}