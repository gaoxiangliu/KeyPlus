
namespace KeyboardHook01
{
    partial class FormWPM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWPM));
            this.textInput = new System.Windows.Forms.TextBox();
            this.lblWords = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblTime = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblWrongWords = new System.Windows.Forms.Label();
            this.lblCorrectWords = new System.Windows.Forms.Label();
            this.lblBackspace = new System.Windows.Forms.Label();
            this.lblTextBackspace = new System.Windows.Forms.Label();
            this.lblTextAccuracy = new System.Windows.Forms.Label();
            this.lblAccuracy = new System.Windows.Forms.Label();
            this.lblWrongKeystrokes = new System.Windows.Forms.Label();
            this.lblTextWrongWords = new System.Windows.Forms.Label();
            this.lblTextWrongKeystrokes = new System.Windows.Forms.Label();
            this.lblTextCorrectWords = new System.Windows.Forms.Label();
            this.lblTextCorrectKeystrokes = new System.Windows.Forms.Label();
            this.lblCorrectKeystrokes = new System.Windows.Forms.Label();
            this.lblTextTotalKeystrokes = new System.Windows.Forms.Label();
            this.lblTotalKeystrokes = new System.Windows.Forms.Label();
            this.lblWPM = new System.Windows.Forms.Label();
            this.groupTestWords = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.comboBoxTestWords = new System.Windows.Forms.ComboBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupTestWords.SuspendLayout();
            this.SuspendLayout();
            // 
            // textInput
            // 
            this.textInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInput.Location = new System.Drawing.Point(197, 105);
            this.textInput.Name = "textInput";
            this.textInput.Size = new System.Drawing.Size(421, 35);
            this.textInput.TabIndex = 0;
            this.textInput.TextChanged += new System.EventHandler(this.textInput_TextChanged);
            this.textInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textInput_KeyDown);
            this.textInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textInput_KeyUp);
            // 
            // lblWords
            // 
            this.lblWords.BackColor = System.Drawing.Color.White;
            this.lblWords.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWords.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWords.Location = new System.Drawing.Point(12, 9);
            this.lblWords.Name = "lblWords";
            this.lblWords.Size = new System.Drawing.Size(1044, 83);
            this.lblWords.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(711, 105);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(135, 35);
            this.btnReset.TabIndex = 2;
            this.btnReset.TabStop = false;
            this.btnReset.Text = "button1";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblInstruction
            // 
            this.lblInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.Location = new System.Drawing.Point(12, 246);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(323, 171);
            this.lblInstruction.TabIndex = 3;
            this.lblInstruction.Text = resources.GetString("lblInstruction.Text");
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // lblTime
            // 
            this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(624, 105);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(81, 35);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "label1";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblWrongWords);
            this.groupBox1.Controls.Add(this.lblCorrectWords);
            this.groupBox1.Controls.Add(this.lblBackspace);
            this.groupBox1.Controls.Add(this.lblTextBackspace);
            this.groupBox1.Controls.Add(this.lblTextAccuracy);
            this.groupBox1.Controls.Add(this.lblAccuracy);
            this.groupBox1.Controls.Add(this.lblWrongKeystrokes);
            this.groupBox1.Controls.Add(this.lblTextWrongWords);
            this.groupBox1.Controls.Add(this.lblTextWrongKeystrokes);
            this.groupBox1.Controls.Add(this.lblTextCorrectWords);
            this.groupBox1.Controls.Add(this.lblTextCorrectKeystrokes);
            this.groupBox1.Controls.Add(this.lblCorrectKeystrokes);
            this.groupBox1.Controls.Add(this.lblTextTotalKeystrokes);
            this.groupBox1.Controls.Add(this.lblTotalKeystrokes);
            this.groupBox1.Controls.Add(this.lblWPM);
            this.groupBox1.Location = new System.Drawing.Point(395, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(661, 239);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // lblWrongWords
            // 
            this.lblWrongWords.AutoSize = true;
            this.lblWrongWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWrongWords.Location = new System.Drawing.Point(395, 191);
            this.lblWrongWords.Name = "lblWrongWords";
            this.lblWrongWords.Size = new System.Drawing.Size(70, 25);
            this.lblWrongWords.TabIndex = 1;
            this.lblWrongWords.Text = "label1";
            // 
            // lblCorrectWords
            // 
            this.lblCorrectWords.AutoSize = true;
            this.lblCorrectWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorrectWords.Location = new System.Drawing.Point(395, 146);
            this.lblCorrectWords.Name = "lblCorrectWords";
            this.lblCorrectWords.Size = new System.Drawing.Size(70, 25);
            this.lblCorrectWords.TabIndex = 1;
            this.lblCorrectWords.Text = "label1";
            // 
            // lblBackspace
            // 
            this.lblBackspace.AutoSize = true;
            this.lblBackspace.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackspace.Location = new System.Drawing.Point(395, 99);
            this.lblBackspace.Name = "lblBackspace";
            this.lblBackspace.Size = new System.Drawing.Size(70, 25);
            this.lblBackspace.TabIndex = 1;
            this.lblBackspace.Text = "label1";
            // 
            // lblTextBackspace
            // 
            this.lblTextBackspace.AutoSize = true;
            this.lblTextBackspace.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextBackspace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTextBackspace.Location = new System.Drawing.Point(563, 99);
            this.lblTextBackspace.Name = "lblTextBackspace";
            this.lblTextBackspace.Size = new System.Drawing.Size(70, 25);
            this.lblTextBackspace.TabIndex = 1;
            this.lblTextBackspace.Text = "label1";
            // 
            // lblTextAccuracy
            // 
            this.lblTextAccuracy.AutoSize = true;
            this.lblTextAccuracy.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextAccuracy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTextAccuracy.Location = new System.Drawing.Point(563, 55);
            this.lblTextAccuracy.Name = "lblTextAccuracy";
            this.lblTextAccuracy.Size = new System.Drawing.Size(70, 25);
            this.lblTextAccuracy.TabIndex = 1;
            this.lblTextAccuracy.Text = "label1";
            // 
            // lblAccuracy
            // 
            this.lblAccuracy.AutoSize = true;
            this.lblAccuracy.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccuracy.Location = new System.Drawing.Point(395, 55);
            this.lblAccuracy.Name = "lblAccuracy";
            this.lblAccuracy.Size = new System.Drawing.Size(70, 25);
            this.lblAccuracy.TabIndex = 1;
            this.lblAccuracy.Text = "label1";
            // 
            // lblWrongKeystrokes
            // 
            this.lblWrongKeystrokes.AutoSize = true;
            this.lblWrongKeystrokes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWrongKeystrokes.Location = new System.Drawing.Point(14, 191);
            this.lblWrongKeystrokes.Name = "lblWrongKeystrokes";
            this.lblWrongKeystrokes.Size = new System.Drawing.Size(70, 25);
            this.lblWrongKeystrokes.TabIndex = 1;
            this.lblWrongKeystrokes.Text = "label1";
            // 
            // lblTextWrongWords
            // 
            this.lblTextWrongWords.AutoSize = true;
            this.lblTextWrongWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextWrongWords.ForeColor = System.Drawing.Color.Red;
            this.lblTextWrongWords.Location = new System.Drawing.Point(563, 191);
            this.lblTextWrongWords.Name = "lblTextWrongWords";
            this.lblTextWrongWords.Size = new System.Drawing.Size(70, 25);
            this.lblTextWrongWords.TabIndex = 1;
            this.lblTextWrongWords.Text = "label1";
            // 
            // lblTextWrongKeystrokes
            // 
            this.lblTextWrongKeystrokes.AutoSize = true;
            this.lblTextWrongKeystrokes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextWrongKeystrokes.ForeColor = System.Drawing.Color.Red;
            this.lblTextWrongKeystrokes.Location = new System.Drawing.Point(231, 191);
            this.lblTextWrongKeystrokes.Name = "lblTextWrongKeystrokes";
            this.lblTextWrongKeystrokes.Size = new System.Drawing.Size(70, 25);
            this.lblTextWrongKeystrokes.TabIndex = 1;
            this.lblTextWrongKeystrokes.Text = "label1";
            // 
            // lblTextCorrectWords
            // 
            this.lblTextCorrectWords.AutoSize = true;
            this.lblTextCorrectWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextCorrectWords.ForeColor = System.Drawing.Color.Green;
            this.lblTextCorrectWords.Location = new System.Drawing.Point(563, 146);
            this.lblTextCorrectWords.Name = "lblTextCorrectWords";
            this.lblTextCorrectWords.Size = new System.Drawing.Size(70, 25);
            this.lblTextCorrectWords.TabIndex = 1;
            this.lblTextCorrectWords.Text = "label1";
            // 
            // lblTextCorrectKeystrokes
            // 
            this.lblTextCorrectKeystrokes.AutoSize = true;
            this.lblTextCorrectKeystrokes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextCorrectKeystrokes.ForeColor = System.Drawing.Color.Green;
            this.lblTextCorrectKeystrokes.Location = new System.Drawing.Point(231, 146);
            this.lblTextCorrectKeystrokes.Name = "lblTextCorrectKeystrokes";
            this.lblTextCorrectKeystrokes.Size = new System.Drawing.Size(70, 25);
            this.lblTextCorrectKeystrokes.TabIndex = 1;
            this.lblTextCorrectKeystrokes.Text = "label1";
            // 
            // lblCorrectKeystrokes
            // 
            this.lblCorrectKeystrokes.AutoSize = true;
            this.lblCorrectKeystrokes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorrectKeystrokes.Location = new System.Drawing.Point(14, 146);
            this.lblCorrectKeystrokes.Name = "lblCorrectKeystrokes";
            this.lblCorrectKeystrokes.Size = new System.Drawing.Size(70, 25);
            this.lblCorrectKeystrokes.TabIndex = 1;
            this.lblCorrectKeystrokes.Text = "label1";
            // 
            // lblTextTotalKeystrokes
            // 
            this.lblTextTotalKeystrokes.AutoSize = true;
            this.lblTextTotalKeystrokes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextTotalKeystrokes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTextTotalKeystrokes.Location = new System.Drawing.Point(231, 99);
            this.lblTextTotalKeystrokes.Name = "lblTextTotalKeystrokes";
            this.lblTextTotalKeystrokes.Size = new System.Drawing.Size(70, 25);
            this.lblTextTotalKeystrokes.TabIndex = 1;
            this.lblTextTotalKeystrokes.Text = "label1";
            // 
            // lblTotalKeystrokes
            // 
            this.lblTotalKeystrokes.AutoSize = true;
            this.lblTotalKeystrokes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalKeystrokes.Location = new System.Drawing.Point(14, 99);
            this.lblTotalKeystrokes.Name = "lblTotalKeystrokes";
            this.lblTotalKeystrokes.Size = new System.Drawing.Size(70, 25);
            this.lblTotalKeystrokes.TabIndex = 1;
            this.lblTotalKeystrokes.Text = "label1";
            // 
            // lblWPM
            // 
            this.lblWPM.AutoSize = true;
            this.lblWPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWPM.ForeColor = System.Drawing.Color.Green;
            this.lblWPM.Location = new System.Drawing.Point(6, 16);
            this.lblWPM.Name = "lblWPM";
            this.lblWPM.Size = new System.Drawing.Size(313, 73);
            this.lblWPM.TabIndex = 0;
            this.lblWPM.Text = "105 WPM";
            // 
            // groupTestWords
            // 
            this.groupTestWords.Controls.Add(this.btnBrowse);
            this.groupTestWords.Controls.Add(this.comboBoxTestWords);
            this.groupTestWords.Location = new System.Drawing.Point(16, 178);
            this.groupTestWords.Name = "groupTestWords";
            this.groupTestWords.Size = new System.Drawing.Size(319, 49);
            this.groupTestWords.TabIndex = 6;
            this.groupTestWords.TabStop = false;
            this.groupTestWords.Text = "groupBox2";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Location = new System.Drawing.Point(238, 18);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "button1";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // comboBoxTestWords
            // 
            this.comboBoxTestWords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTestWords.FormattingEnabled = true;
            this.comboBoxTestWords.Location = new System.Drawing.Point(7, 20);
            this.comboBoxTestWords.Name = "comboBoxTestWords";
            this.comboBoxTestWords.Size = new System.Drawing.Size(225, 21);
            this.comboBoxTestWords.TabIndex = 0;
            this.comboBoxTestWords.SelectedIndexChanged += new System.EventHandler(this.comboBoxTestWords_SelectedIndexChanged);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(254, 147);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(28, 13);
            this.lblPath.TabIndex = 7;
            this.lblPath.Text = "path";
            this.lblPath.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormWPM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 429);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.groupTestWords);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblWords);
            this.Controls.Add(this.textInput);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1084, 468);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1084, 468);
            this.Name = "FormWPM";
            this.Text = " ";
            this.Load += new System.EventHandler(this.FormWPM_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormWPM_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupTestWords.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textInput;
        private System.Windows.Forms.Label lblWords;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblWPM;
        private System.Windows.Forms.Label lblTotalKeystrokes;
        private System.Windows.Forms.Label lblWrongWords;
        private System.Windows.Forms.Label lblCorrectWords;
        private System.Windows.Forms.Label lblBackspace;
        private System.Windows.Forms.Label lblAccuracy;
        private System.Windows.Forms.Label lblWrongKeystrokes;
        private System.Windows.Forms.Label lblCorrectKeystrokes;
        private System.Windows.Forms.Label lblTextWrongKeystrokes;
        private System.Windows.Forms.Label lblTextCorrectKeystrokes;
        private System.Windows.Forms.Label lblTextTotalKeystrokes;
        private System.Windows.Forms.Label lblTextBackspace;
        private System.Windows.Forms.Label lblTextAccuracy;
        private System.Windows.Forms.Label lblTextWrongWords;
        private System.Windows.Forms.Label lblTextCorrectWords;
        private System.Windows.Forms.GroupBox groupTestWords;
        private System.Windows.Forms.ComboBox comboBoxTestWords;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}