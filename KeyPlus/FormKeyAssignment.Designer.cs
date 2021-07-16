
namespace KeyboardHook01
{
    partial class FormKeyAssignment
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
            this.listView = new System.Windows.Forms.ListView();
            this.lblIndex = new System.Windows.Forms.Label();
            this.lblHotKey = new System.Windows.Forms.Label();
            this.lblAssignment = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblTextIndex = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtHotKey = new System.Windows.Forms.TextBox();
            this.comboBoxAssignment = new System.Windows.Forms.ComboBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.AllowColumnReorder = true;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(13, 13);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(667, 290);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Location = new System.Drawing.Point(6, 28);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(35, 13);
            this.lblIndex.TabIndex = 1;
            this.lblIndex.Text = "label1";
            // 
            // lblHotKey
            // 
            this.lblHotKey.AutoSize = true;
            this.lblHotKey.Location = new System.Drawing.Point(176, 28);
            this.lblHotKey.Name = "lblHotKey";
            this.lblHotKey.Size = new System.Drawing.Size(35, 13);
            this.lblHotKey.TabIndex = 2;
            this.lblHotKey.Text = "label1";
            // 
            // lblAssignment
            // 
            this.lblAssignment.AutoSize = true;
            this.lblAssignment.Location = new System.Drawing.Point(408, 27);
            this.lblAssignment.Name = "lblAssignment";
            this.lblAssignment.Size = new System.Drawing.Size(35, 13);
            this.lblAssignment.TabIndex = 3;
            this.lblAssignment.Text = "label1";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(6, 66);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(35, 13);
            this.lblPath.TabIndex = 4;
            this.lblPath.Text = "label1";
            // 
            // lblTextIndex
            // 
            this.lblTextIndex.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTextIndex.Location = new System.Drawing.Point(47, 24);
            this.lblTextIndex.Name = "lblTextIndex";
            this.lblTextIndex.Size = new System.Drawing.Size(100, 20);
            this.lblTextIndex.TabIndex = 5;
            this.lblTextIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(94, 309);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "button1";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(175, 309);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "button1";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(13, 309);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "button1";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.btnSave);
            this.groupBox.Controls.Add(this.btnBrowse);
            this.groupBox.Controls.Add(this.txtHotKey);
            this.groupBox.Controls.Add(this.comboBoxAssignment);
            this.groupBox.Controls.Add(this.txtPath);
            this.groupBox.Controls.Add(this.lblPath);
            this.groupBox.Controls.Add(this.lblAssignment);
            this.groupBox.Controls.Add(this.lblTextIndex);
            this.groupBox.Controls.Add(this.lblHotKey);
            this.groupBox.Controls.Add(this.lblIndex);
            this.groupBox.Location = new System.Drawing.Point(13, 338);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(673, 100);
            this.groupBox.TabIndex = 10;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "groupBox1";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(604, 22);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 62);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "button1";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(523, 61);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 14;
            this.btnBrowse.Text = "button1";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtHotKey
            // 
            this.txtHotKey.BackColor = System.Drawing.Color.White;
            this.txtHotKey.Location = new System.Drawing.Point(230, 25);
            this.txtHotKey.Name = "txtHotKey";
            this.txtHotKey.ReadOnly = true;
            this.txtHotKey.Size = new System.Drawing.Size(156, 20);
            this.txtHotKey.TabIndex = 11;
            this.txtHotKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotKey_KeyDown);
            // 
            // comboBoxAssignment
            // 
            this.comboBoxAssignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAssignment.FormattingEnabled = true;
            this.comboBoxAssignment.Location = new System.Drawing.Point(475, 24);
            this.comboBoxAssignment.Name = "comboBoxAssignment";
            this.comboBoxAssignment.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAssignment.TabIndex = 12;
            this.comboBoxAssignment.SelectedIndexChanged += new System.EventHandler(this.comboBoxAssignment_SelectedIndexChanged);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(47, 63);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(461, 20);
            this.txtPath.TabIndex = 13;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormKeyAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 450);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.listView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(714, 999999);
            this.MinimumSize = new System.Drawing.Size(714, 250);
            this.Name = "FormKeyAssignment";
            this.Text = "FormKeyAssignment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormKeyAssignment_FormClosing);
            this.Load += new System.EventHandler(this.FormKeyAssignment_Load);
            this.Resize += new System.EventHandler(this.FormKeyAssignment_Resize);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.Label lblHotKey;
        private System.Windows.Forms.Label lblAssignment;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblTextIndex;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox txtHotKey;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ComboBox comboBoxAssignment;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}