
namespace Acorn
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBinaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonVolume = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOrganize = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCompact = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveBinary = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNewFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNewWindow = new System.Windows.Forms.ToolStripButton();
            this.dgvFilesSide0 = new System.Windows.Forms.DataGridView();
            this.dgvFilesSide1 = new System.Windows.Forms.DataGridView();
            this.splitContainerVertical = new System.Windows.Forms.SplitContainer();
            this.lbImages = new System.Windows.Forms.ListBox();
            this.splitContainerHorizontal = new System.Windows.Forms.SplitContainer();
            this.lblBootSide0 = new System.Windows.Forms.Label();
            this.lblSectorsSide0 = new System.Windows.Forms.Label();
            this.lblFilesSide0 = new System.Windows.Forms.Label();
            this.lblTitleSide0 = new System.Windows.Forms.Label();
            this.lblBootSide1 = new System.Windows.Forms.Label();
            this.lblSectorsSide1 = new System.Windows.Forms.Label();
            this.lblFilesSide1 = new System.Windows.Forms.Label();
            this.lblTitleSide1 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilesSide0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilesSide1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVertical)).BeginInit();
            this.splitContainerVertical.Panel1.SuspendLayout();
            this.splitContainerVertical.Panel2.SuspendLayout();
            this.splitContainerVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHorizontal)).BeginInit();
            this.splitContainerHorizontal.Panel1.SuspendLayout();
            this.splitContainerHorizontal.Panel2.SuspendLayout();
            this.splitContainerHorizontal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(9, 9);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(90, 24);
            this.menuStrip.TabIndex = 13;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileToolStripMenuItem,
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripMenuItem2,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.saveBinaryToolStripMenuItem,
            this.toolStripMenuItem3,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newFileToolStripMenuItem.Image")));
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.newFileToolStripMenuItem.Text = "&New";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonNewFile_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::Acorn.Properties.Resources.open;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::Acorn.Properties.Resources.close;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(183, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::Acorn.Properties.Resources.save;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = global::Acorn.Properties.Resources.save_as;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonSaveAs_Click);
            // 
            // saveBinaryToolStripMenuItem
            // 
            this.saveBinaryToolStripMenuItem.Image = global::Acorn.Properties.Resources.save_binary;
            this.saveBinaryToolStripMenuItem.Name = "saveBinaryToolStripMenuItem";
            this.saveBinaryToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveBinaryToolStripMenuItem.Text = "Save Binary";
            this.saveBinaryToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonSaveBinary_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(183, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.quitToolStripMenuItem.Text = "&Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // viewHelpToolStripMenuItem
            // 
            this.viewHelpToolStripMenuItem.Image = global::Acorn.Properties.Resources.help;
            this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
            this.viewHelpToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.viewHelpToolStripMenuItem.Text = "View Help";
            this.viewHelpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonFile,
            this.toolStripButtonVolume,
            this.toolStripButtonOrganize,
            this.toolStripButtonCompact,
            this.toolStripButtonSaveBinary,
            this.toolStripButtonSaveAs,
            this.toolStripButtonSave,
            this.toolStripSeparator1,
            this.toolStripButtonOpen,
            this.toolStripButtonNewFile,
            this.toolStripButtonNewWindow});
            this.toolStrip.Location = new System.Drawing.Point(536, 9);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip.Size = new System.Drawing.Size(239, 25);
            this.toolStrip.TabIndex = 18;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripButtonFile
            // 
            this.toolStripButtonFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFile.Image = global::Acorn.Properties.Resources.file;
            this.toolStripButtonFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFile.Name = "toolStripButtonFile";
            this.toolStripButtonFile.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFile.Text = "File";
            this.toolStripButtonFile.Click += new System.EventHandler(this.toolStripButtonFile_Click);
            // 
            // toolStripButtonVolume
            // 
            this.toolStripButtonVolume.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonVolume.Image = global::Acorn.Properties.Resources.volume;
            this.toolStripButtonVolume.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonVolume.Name = "toolStripButtonVolume";
            this.toolStripButtonVolume.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonVolume.Text = "Volume";
            this.toolStripButtonVolume.Click += new System.EventHandler(this.toolStripButtonVolume_Click);
            // 
            // toolStripButtonOrganize
            // 
            this.toolStripButtonOrganize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOrganize.Image = global::Acorn.Properties.Resources.organize;
            this.toolStripButtonOrganize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOrganize.Name = "toolStripButtonOrganize";
            this.toolStripButtonOrganize.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOrganize.Text = "Organize";
            this.toolStripButtonOrganize.Click += new System.EventHandler(this.toolStripButtonOrganize_Click);
            // 
            // toolStripButtonCompact
            // 
            this.toolStripButtonCompact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCompact.Image = global::Acorn.Properties.Resources.compact;
            this.toolStripButtonCompact.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCompact.Name = "toolStripButtonCompact";
            this.toolStripButtonCompact.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCompact.Text = "Compact";
            this.toolStripButtonCompact.Click += new System.EventHandler(this.toolStripButtonCompact_Click);
            // 
            // toolStripButtonSaveBinary
            // 
            this.toolStripButtonSaveBinary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSaveBinary.Image = global::Acorn.Properties.Resources.save_binary;
            this.toolStripButtonSaveBinary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveBinary.Name = "toolStripButtonSaveBinary";
            this.toolStripButtonSaveBinary.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSaveBinary.Text = "Save Binary";
            this.toolStripButtonSaveBinary.Click += new System.EventHandler(this.toolStripButtonSaveBinary_Click);
            // 
            // toolStripButtonSaveAs
            // 
            this.toolStripButtonSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSaveAs.Image = global::Acorn.Properties.Resources.save_as;
            this.toolStripButtonSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveAs.Name = "toolStripButtonSaveAs";
            this.toolStripButtonSaveAs.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSaveAs.Text = "Save As";
            this.toolStripButtonSaveAs.Click += new System.EventHandler(this.toolStripButtonSaveAs_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = global::Acorn.Properties.Resources.save;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.Image = global::Acorn.Properties.Resources.open;
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpen.ToolTipText = "Open File";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
            // 
            // toolStripButtonNewFile
            // 
            this.toolStripButtonNewFile.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButtonNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNewFile.Image = global::Acorn.Properties.Resources._new;
            this.toolStripButtonNewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNewFile.Name = "toolStripButtonNewFile";
            this.toolStripButtonNewFile.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNewFile.Text = "New File";
            this.toolStripButtonNewFile.Click += new System.EventHandler(this.toolStripButtonNewFile_Click);
            // 
            // toolStripButtonNewWindow
            // 
            this.toolStripButtonNewWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNewWindow.Image = global::Acorn.Properties.Resources.window;
            this.toolStripButtonNewWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNewWindow.Name = "toolStripButtonNewWindow";
            this.toolStripButtonNewWindow.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNewWindow.Text = "New Window";
            this.toolStripButtonNewWindow.Click += new System.EventHandler(this.toolStripButtonNewWindow_Click);
            // 
            // dgvFilesSide0
            // 
            this.dgvFilesSide0.AllowUserToAddRows = false;
            this.dgvFilesSide0.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvFilesSide0.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFilesSide0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFilesSide0.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFilesSide0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilesSide0.Location = new System.Drawing.Point(0, 18);
            this.dgvFilesSide0.MultiSelect = false;
            this.dgvFilesSide0.Name = "dgvFilesSide0";
            this.dgvFilesSide0.ReadOnly = true;
            this.dgvFilesSide0.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFilesSide0.Size = new System.Drawing.Size(534, 231);
            this.dgvFilesSide0.TabIndex = 19;
            this.dgvFilesSide0.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFilesSide0_CellMouseMove);
            this.dgvFilesSide0.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFilesSide0_CellMouseUp);
            this.dgvFilesSide0.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvFilesSide0_DragDrop);
            this.dgvFilesSide0.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvFilesSide0_DragEnter);
            this.dgvFilesSide0.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvFilesSide0_DragOver);
            this.dgvFilesSide0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvFilesSide0_KeyDown);
            this.dgvFilesSide0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvFilesSide0_MouseDown);
            // 
            // dgvFilesSide1
            // 
            this.dgvFilesSide1.AllowUserToAddRows = false;
            this.dgvFilesSide1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvFilesSide1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFilesSide1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFilesSide1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFilesSide1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilesSide1.Location = new System.Drawing.Point(3, 16);
            this.dgvFilesSide1.MultiSelect = false;
            this.dgvFilesSide1.Name = "dgvFilesSide1";
            this.dgvFilesSide1.ReadOnly = true;
            this.dgvFilesSide1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFilesSide1.Size = new System.Drawing.Size(531, 238);
            this.dgvFilesSide1.TabIndex = 20;
            this.dgvFilesSide1.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFilesSide1_CellMouseMove);
            this.dgvFilesSide1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvFilesSide1_DragDrop);
            this.dgvFilesSide1.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvFilesSide1_DragEnter);
            this.dgvFilesSide1.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvFilesSide1_DragOver);
            this.dgvFilesSide1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvFilesSide1_KeyDown);
            this.dgvFilesSide1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvFilesSide1_MouseDown);
            // 
            // splitContainerVertical
            // 
            this.splitContainerVertical.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerVertical.Location = new System.Drawing.Point(9, 37);
            this.splitContainerVertical.Name = "splitContainerVertical";
            // 
            // splitContainerVertical.Panel1
            // 
            this.splitContainerVertical.Panel1.Controls.Add(this.lbImages);
            // 
            // splitContainerVertical.Panel2
            // 
            this.splitContainerVertical.Panel2.Controls.Add(this.splitContainerHorizontal);
            this.splitContainerVertical.Size = new System.Drawing.Size(763, 519);
            this.splitContainerVertical.SplitterDistance = 216;
            this.splitContainerVertical.TabIndex = 21;
            // 
            // lbImages
            // 
            this.lbImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbImages.FormattingEnabled = true;
            this.lbImages.Location = new System.Drawing.Point(3, 5);
            this.lbImages.Name = "lbImages";
            this.lbImages.Size = new System.Drawing.Size(210, 498);
            this.lbImages.TabIndex = 20;
            this.lbImages.SelectedIndexChanged += new System.EventHandler(this.lbImages_SelectedIndexChanged);
            // 
            // splitContainerHorizontal
            // 
            this.splitContainerHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerHorizontal.Location = new System.Drawing.Point(3, 3);
            this.splitContainerHorizontal.Name = "splitContainerHorizontal";
            this.splitContainerHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerHorizontal.Panel1
            // 
            this.splitContainerHorizontal.Panel1.Controls.Add(this.lblBootSide0);
            this.splitContainerHorizontal.Panel1.Controls.Add(this.lblSectorsSide0);
            this.splitContainerHorizontal.Panel1.Controls.Add(this.lblFilesSide0);
            this.splitContainerHorizontal.Panel1.Controls.Add(this.lblTitleSide0);
            this.splitContainerHorizontal.Panel1.Controls.Add(this.dgvFilesSide0);
            // 
            // splitContainerHorizontal.Panel2
            // 
            this.splitContainerHorizontal.Panel2.Controls.Add(this.lblBootSide1);
            this.splitContainerHorizontal.Panel2.Controls.Add(this.lblSectorsSide1);
            this.splitContainerHorizontal.Panel2.Controls.Add(this.lblFilesSide1);
            this.splitContainerHorizontal.Panel2.Controls.Add(this.lblTitleSide1);
            this.splitContainerHorizontal.Panel2.Controls.Add(this.dgvFilesSide1);
            this.splitContainerHorizontal.Size = new System.Drawing.Size(537, 513);
            this.splitContainerHorizontal.SplitterDistance = 252;
            this.splitContainerHorizontal.TabIndex = 0;
            // 
            // lblBootSide0
            // 
            this.lblBootSide0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBootSide0.AutoSize = true;
            this.lblBootSide0.Location = new System.Drawing.Point(421, 2);
            this.lblBootSide0.Name = "lblBootSide0";
            this.lblBootSide0.Size = new System.Drawing.Size(32, 13);
            this.lblBootSide0.TabIndex = 26;
            this.lblBootSide0.Text = "Boot:";
            // 
            // lblSectorsSide0
            // 
            this.lblSectorsSide0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSectorsSide0.AutoSize = true;
            this.lblSectorsSide0.Location = new System.Drawing.Point(287, 2);
            this.lblSectorsSide0.Name = "lblSectorsSide0";
            this.lblSectorsSide0.Size = new System.Drawing.Size(46, 13);
            this.lblSectorsSide0.TabIndex = 22;
            this.lblSectorsSide0.Text = "Sectors:";
            // 
            // lblFilesSide0
            // 
            this.lblFilesSide0.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFilesSide0.AutoSize = true;
            this.lblFilesSide0.Location = new System.Drawing.Point(149, 2);
            this.lblFilesSide0.Name = "lblFilesSide0";
            this.lblFilesSide0.Size = new System.Drawing.Size(31, 13);
            this.lblFilesSide0.TabIndex = 21;
            this.lblFilesSide0.Text = "Files:";
            // 
            // lblTitleSide0
            // 
            this.lblTitleSide0.AutoSize = true;
            this.lblTitleSide0.Location = new System.Drawing.Point(3, 2);
            this.lblTitleSide0.Name = "lblTitleSide0";
            this.lblTitleSide0.Size = new System.Drawing.Size(30, 13);
            this.lblTitleSide0.TabIndex = 20;
            this.lblTitleSide0.Text = "Title:";
            // 
            // lblBootSide1
            // 
            this.lblBootSide1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBootSide1.AutoSize = true;
            this.lblBootSide1.Location = new System.Drawing.Point(421, 0);
            this.lblBootSide1.Name = "lblBootSide1";
            this.lblBootSide1.Size = new System.Drawing.Size(32, 13);
            this.lblBootSide1.TabIndex = 27;
            this.lblBootSide1.Text = "Boot:";
            // 
            // lblSectorsSide1
            // 
            this.lblSectorsSide1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSectorsSide1.AutoSize = true;
            this.lblSectorsSide1.Location = new System.Drawing.Point(287, 0);
            this.lblSectorsSide1.Name = "lblSectorsSide1";
            this.lblSectorsSide1.Size = new System.Drawing.Size(46, 13);
            this.lblSectorsSide1.TabIndex = 25;
            this.lblSectorsSide1.Text = "Sectors:";
            // 
            // lblFilesSide1
            // 
            this.lblFilesSide1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFilesSide1.AutoSize = true;
            this.lblFilesSide1.Location = new System.Drawing.Point(149, 0);
            this.lblFilesSide1.Name = "lblFilesSide1";
            this.lblFilesSide1.Size = new System.Drawing.Size(31, 13);
            this.lblFilesSide1.TabIndex = 24;
            this.lblFilesSide1.Text = "Files:";
            // 
            // lblTitleSide1
            // 
            this.lblTitleSide1.AutoSize = true;
            this.lblTitleSide1.Location = new System.Drawing.Point(3, 0);
            this.lblTitleSide1.Name = "lblTitleSide1";
            this.lblTitleSide1.Size = new System.Drawing.Size(30, 13);
            this.lblTitleSide1.TabIndex = 23;
            this.lblTitleSide1.Text = "Title:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainerVertical);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Acorn SSD/DSD Image Viewer/Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilesSide0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilesSide1)).EndInit();
            this.splitContainerVertical.Panel1.ResumeLayout(false);
            this.splitContainerVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVertical)).EndInit();
            this.splitContainerVertical.ResumeLayout(false);
            this.splitContainerHorizontal.Panel1.ResumeLayout(false);
            this.splitContainerHorizontal.Panel1.PerformLayout();
            this.splitContainerHorizontal.Panel2.ResumeLayout(false);
            this.splitContainerHorizontal.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHorizontal)).EndInit();
            this.splitContainerHorizontal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveAs;
        private System.Windows.Forms.ToolStripButton toolStripButtonCompact;
        private System.Windows.Forms.ToolStripButton toolStripButtonNewFile;
        private System.Windows.Forms.ToolStripMenuItem viewHelpToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvFilesSide0;
        private System.Windows.Forms.DataGridView dgvFilesSide1;
        private System.Windows.Forms.SplitContainer splitContainerVertical;
        private System.Windows.Forms.ListBox lbImages;
        private System.Windows.Forms.SplitContainer splitContainerHorizontal;
        private System.Windows.Forms.Label lblFilesSide0;
        private System.Windows.Forms.Label lblTitleSide0;
        private System.Windows.Forms.Label lblSectorsSide0;
        private System.Windows.Forms.Label lblSectorsSide1;
        private System.Windows.Forms.Label lblFilesSide1;
        private System.Windows.Forms.Label lblTitleSide1;
        private System.Windows.Forms.ToolStripMenuItem saveBinaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveBinary;
        private System.Windows.Forms.Label lblBootSide0;
        private System.Windows.Forms.Label lblBootSide1;
        private System.Windows.Forms.ToolStripButton toolStripButtonOrganize;
        private System.Windows.Forms.ToolStripButton toolStripButtonVolume;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonNewWindow;
        private System.Windows.Forms.ToolStripButton toolStripButtonFile;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}

