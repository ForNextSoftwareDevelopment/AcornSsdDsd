namespace Acorn
{
    partial class FormFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFile));
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbStartSector = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFileLength = new System.Windows.Forms.TextBox();
            this.lblFileLength = new System.Windows.Forms.Label();
            this.chkLocked = new System.Windows.Forms.CheckBox();
            this.tbLoadAddress = new System.Windows.Forms.TextBox();
            this.lblLoadAddress = new System.Windows.Forms.Label();
            this.tbStartAddress = new System.Windows.Forms.TextBox();
            this.lblStartAddress = new System.Windows.Forms.Label();
            this.tbFolderName = new System.Windows.Forms.TextBox();
            this.lblFolderName = new System.Windows.Forms.Label();
            this.cbIoProcMemLoad = new System.Windows.Forms.CheckBox();
            this.cbIoProcMemStart = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(137, 246);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(12, 36);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(57, 13);
            this.lblFileName.TabIndex = 1;
            this.lblFileName.Text = "File Name:";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(121, 33);
            this.tbFileName.MaxLength = 7;
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(80, 20);
            this.tbFileName.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 246);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tbStartSector
            // 
            this.tbStartSector.Location = new System.Drawing.Point(121, 183);
            this.tbStartSector.MaxLength = 7;
            this.tbStartSector.Name = "tbStartSector";
            this.tbStartSector.ReadOnly = true;
            this.tbStartSector.Size = new System.Drawing.Size(80, 20);
            this.tbStartSector.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Start Sector:";
            // 
            // tbFileLength
            // 
            this.tbFileLength.Location = new System.Drawing.Point(121, 157);
            this.tbFileLength.MaxLength = 7;
            this.tbFileLength.Name = "tbFileLength";
            this.tbFileLength.ReadOnly = true;
            this.tbFileLength.Size = new System.Drawing.Size(80, 20);
            this.tbFileLength.TabIndex = 18;
            // 
            // lblFileLength
            // 
            this.lblFileLength.AutoSize = true;
            this.lblFileLength.Location = new System.Drawing.Point(12, 160);
            this.lblFileLength.Name = "lblFileLength";
            this.lblFileLength.Size = new System.Drawing.Size(62, 13);
            this.lblFileLength.TabIndex = 17;
            this.lblFileLength.Text = "File Length:";
            // 
            // chkLocked
            // 
            this.chkLocked.AutoSize = true;
            this.chkLocked.Location = new System.Drawing.Point(121, 210);
            this.chkLocked.Name = "chkLocked";
            this.chkLocked.Size = new System.Drawing.Size(62, 17);
            this.chkLocked.TabIndex = 19;
            this.chkLocked.Text = "Locked";
            this.chkLocked.UseVisualStyleBackColor = true;
            // 
            // tbLoadAddress
            // 
            this.tbLoadAddress.Location = new System.Drawing.Point(121, 82);
            this.tbLoadAddress.MaxLength = 4;
            this.tbLoadAddress.Name = "tbLoadAddress";
            this.tbLoadAddress.Size = new System.Drawing.Size(80, 20);
            this.tbLoadAddress.TabIndex = 21;
            this.tbLoadAddress.TextChanged += new System.EventHandler(this.tbLoadAddress_TextChanged);
            // 
            // lblLoadAddress
            // 
            this.lblLoadAddress.AutoSize = true;
            this.lblLoadAddress.Location = new System.Drawing.Point(12, 85);
            this.lblLoadAddress.Name = "lblLoadAddress";
            this.lblLoadAddress.Size = new System.Drawing.Size(101, 13);
            this.lblLoadAddress.TabIndex = 20;
            this.lblLoadAddress.Text = "Load Address (hex):";
            // 
            // tbStartAddress
            // 
            this.tbStartAddress.Location = new System.Drawing.Point(121, 131);
            this.tbStartAddress.MaxLength = 4;
            this.tbStartAddress.Name = "tbStartAddress";
            this.tbStartAddress.Size = new System.Drawing.Size(80, 20);
            this.tbStartAddress.TabIndex = 23;
            this.tbStartAddress.TextChanged += new System.EventHandler(this.tbStartAddress_TextChanged);
            // 
            // lblStartAddress
            // 
            this.lblStartAddress.AutoSize = true;
            this.lblStartAddress.Location = new System.Drawing.Point(12, 134);
            this.lblStartAddress.Name = "lblStartAddress";
            this.lblStartAddress.Size = new System.Drawing.Size(99, 13);
            this.lblStartAddress.TabIndex = 22;
            this.lblStartAddress.Text = "Start Address (hex):";
            // 
            // tbFolderName
            // 
            this.tbFolderName.Location = new System.Drawing.Point(121, 7);
            this.tbFolderName.MaxLength = 1;
            this.tbFolderName.Name = "tbFolderName";
            this.tbFolderName.Size = new System.Drawing.Size(80, 20);
            this.tbFolderName.TabIndex = 25;
            // 
            // lblFolderName
            // 
            this.lblFolderName.AutoSize = true;
            this.lblFolderName.Location = new System.Drawing.Point(12, 10);
            this.lblFolderName.Name = "lblFolderName";
            this.lblFolderName.Size = new System.Drawing.Size(70, 13);
            this.lblFolderName.TabIndex = 24;
            this.lblFolderName.Text = "Folder Name:";
            // 
            // cbIoProcMemLoad
            // 
            this.cbIoProcMemLoad.AutoSize = true;
            this.cbIoProcMemLoad.Location = new System.Drawing.Point(12, 59);
            this.cbIoProcMemLoad.Name = "cbIoProcMemLoad";
            this.cbIoProcMemLoad.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbIoProcMemLoad.Size = new System.Drawing.Size(123, 17);
            this.cbIoProcMemLoad.TabIndex = 26;
            this.cbIoProcMemLoad.Text = ":I/O Proc Mem Load";
            this.cbIoProcMemLoad.UseVisualStyleBackColor = true;
            // 
            // cbIoProcMemStart
            // 
            this.cbIoProcMemStart.AutoSize = true;
            this.cbIoProcMemStart.Location = new System.Drawing.Point(12, 108);
            this.cbIoProcMemStart.Name = "cbIoProcMemStart";
            this.cbIoProcMemStart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbIoProcMemStart.Size = new System.Drawing.Size(124, 17);
            this.cbIoProcMemStart.TabIndex = 27;
            this.cbIoProcMemStart.Text = " :I/O Proc Mem Start";
            this.cbIoProcMemStart.UseVisualStyleBackColor = true;
            // 
            // FormFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 281);
            this.Controls.Add(this.cbIoProcMemStart);
            this.Controls.Add(this.cbIoProcMemLoad);
            this.Controls.Add(this.tbFolderName);
            this.Controls.Add(this.lblFolderName);
            this.Controls.Add(this.tbStartAddress);
            this.Controls.Add(this.lblStartAddress);
            this.Controls.Add(this.tbLoadAddress);
            this.Controls.Add(this.lblLoadAddress);
            this.Controls.Add(this.chkLocked);
            this.Controls.Add(this.tbFileLength);
            this.Controls.Add(this.lblFileLength);
            this.Controls.Add(this.tbStartSector);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(240, 320);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(240, 320);
            this.Name = "FormFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Info";
            this.Load += new System.EventHandler(this.FormVolume_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbStartSector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFileLength;
        private System.Windows.Forms.Label lblFileLength;
        private System.Windows.Forms.CheckBox chkLocked;
        private System.Windows.Forms.TextBox tbLoadAddress;
        private System.Windows.Forms.Label lblLoadAddress;
        private System.Windows.Forms.TextBox tbStartAddress;
        private System.Windows.Forms.Label lblStartAddress;
        private System.Windows.Forms.TextBox tbFolderName;
        private System.Windows.Forms.Label lblFolderName;
        private System.Windows.Forms.CheckBox cbIoProcMemLoad;
        private System.Windows.Forms.CheckBox cbIoProcMemStart;
    }
}