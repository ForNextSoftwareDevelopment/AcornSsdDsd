namespace Acorn
{
    partial class FormVolume
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVolume));
            this.btnSave = new System.Windows.Forms.Button();
            this.lblVolumeLabelSide0 = new System.Windows.Forms.Label();
            this.lblVolumeLabelSide1 = new System.Windows.Forms.Label();
            this.tbVolumeLabelSide0 = new System.Windows.Forms.TextBox();
            this.tbVolumeLabelSide1 = new System.Windows.Forms.TextBox();
            this.cbBootOptionSide0 = new System.Windows.Forms.ComboBox();
            this.lblBootOptionSide0 = new System.Windows.Forms.Label();
            this.lblBootOptionSide1 = new System.Windows.Forms.Label();
            this.cbBootOptionSide1 = new System.Windows.Forms.ComboBox();
            this.lblFreeSide0 = new System.Windows.Forms.Label();
            this.lblFreeSide1 = new System.Windows.Forms.Label();
            this.chartSide0 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSide1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartSide0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSide1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(897, 726);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblVolumeLabelSide0
            // 
            this.lblVolumeLabelSide0.AutoSize = true;
            this.lblVolumeLabelSide0.Location = new System.Drawing.Point(3, 3);
            this.lblVolumeLabelSide0.Name = "lblVolumeLabelSide0";
            this.lblVolumeLabelSide0.Size = new System.Drawing.Size(104, 13);
            this.lblVolumeLabelSide0.TabIndex = 1;
            this.lblVolumeLabelSide0.Text = "Volume Label Side0:";
            // 
            // lblVolumeLabelSide1
            // 
            this.lblVolumeLabelSide1.AutoSize = true;
            this.lblVolumeLabelSide1.Location = new System.Drawing.Point(3, 3);
            this.lblVolumeLabelSide1.Name = "lblVolumeLabelSide1";
            this.lblVolumeLabelSide1.Size = new System.Drawing.Size(104, 13);
            this.lblVolumeLabelSide1.TabIndex = 2;
            this.lblVolumeLabelSide1.Text = "Volume Label Side1:";
            // 
            // tbVolumeLabelSide0
            // 
            this.tbVolumeLabelSide0.Location = new System.Drawing.Point(6, 19);
            this.tbVolumeLabelSide0.MaxLength = 12;
            this.tbVolumeLabelSide0.Name = "tbVolumeLabelSide0";
            this.tbVolumeLabelSide0.Size = new System.Drawing.Size(101, 20);
            this.tbVolumeLabelSide0.TabIndex = 3;
            // 
            // tbVolumeLabelSide1
            // 
            this.tbVolumeLabelSide1.Location = new System.Drawing.Point(6, 19);
            this.tbVolumeLabelSide1.MaxLength = 12;
            this.tbVolumeLabelSide1.Name = "tbVolumeLabelSide1";
            this.tbVolumeLabelSide1.Size = new System.Drawing.Size(101, 20);
            this.tbVolumeLabelSide1.TabIndex = 4;
            // 
            // cbBootOptionSide0
            // 
            this.cbBootOptionSide0.FormattingEnabled = true;
            this.cbBootOptionSide0.Items.AddRange(new object[] {
            "No action",
            "*LOAD $.!BOOT",
            "*RUN $.!BOOT",
            "*EXEC $.!BOOT"});
            this.cbBootOptionSide0.Location = new System.Drawing.Point(6, 74);
            this.cbBootOptionSide0.Name = "cbBootOptionSide0";
            this.cbBootOptionSide0.Size = new System.Drawing.Size(121, 21);
            this.cbBootOptionSide0.TabIndex = 5;
            // 
            // lblBootOptionSide0
            // 
            this.lblBootOptionSide0.AutoSize = true;
            this.lblBootOptionSide0.Location = new System.Drawing.Point(3, 58);
            this.lblBootOptionSide0.Name = "lblBootOptionSide0";
            this.lblBootOptionSide0.Size = new System.Drawing.Size(96, 13);
            this.lblBootOptionSide0.TabIndex = 6;
            this.lblBootOptionSide0.Text = "Boot Option Side0:";
            // 
            // lblBootOptionSide1
            // 
            this.lblBootOptionSide1.AutoSize = true;
            this.lblBootOptionSide1.Location = new System.Drawing.Point(3, 58);
            this.lblBootOptionSide1.Name = "lblBootOptionSide1";
            this.lblBootOptionSide1.Size = new System.Drawing.Size(96, 13);
            this.lblBootOptionSide1.TabIndex = 8;
            this.lblBootOptionSide1.Text = "Boot Option Side1:";
            // 
            // cbBootOptionSide1
            // 
            this.cbBootOptionSide1.FormattingEnabled = true;
            this.cbBootOptionSide1.Items.AddRange(new object[] {
            "No action",
            "*LOAD $.!BOOT",
            "*RUN $.!BOOT",
            "*EXEC $.!BOOT"});
            this.cbBootOptionSide1.Location = new System.Drawing.Point(6, 74);
            this.cbBootOptionSide1.Name = "cbBootOptionSide1";
            this.cbBootOptionSide1.Size = new System.Drawing.Size(121, 21);
            this.cbBootOptionSide1.TabIndex = 7;
            // 
            // lblFreeSide0
            // 
            this.lblFreeSide0.AutoSize = true;
            this.lblFreeSide0.Location = new System.Drawing.Point(3, 117);
            this.lblFreeSide0.Name = "lblFreeSide0";
            this.lblFreeSide0.Size = new System.Drawing.Size(116, 13);
            this.lblFreeSide0.TabIndex = 9;
            this.lblFreeSide0.Text = "800 sectors of 800 free";
            // 
            // lblFreeSide1
            // 
            this.lblFreeSide1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFreeSide1.AutoSize = true;
            this.lblFreeSide1.Location = new System.Drawing.Point(3, 117);
            this.lblFreeSide1.Name = "lblFreeSide1";
            this.lblFreeSide1.Size = new System.Drawing.Size(116, 13);
            this.lblFreeSide1.TabIndex = 10;
            this.lblFreeSide1.Text = "800 sectors of 800 free";
            // 
            // chartSide0
            // 
            this.chartSide0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartSide0.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSide0.Legends.Add(legend1);
            this.chartSide0.Location = new System.Drawing.Point(6, 133);
            this.chartSide0.Name = "chartSide0";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartSide0.Series.Add(series1);
            this.chartSide0.Size = new System.Drawing.Size(461, 572);
            this.chartSide0.TabIndex = 11;
            this.chartSide0.Text = "chartSide0";
            // 
            // chartSide1
            // 
            this.chartSide1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chartSide1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartSide1.Legends.Add(legend2);
            this.chartSide1.Location = new System.Drawing.Point(5, 133);
            this.chartSide1.Name = "chartSide1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartSide1.Series.Add(series2);
            this.chartSide1.Size = new System.Drawing.Size(477, 572);
            this.chartSide1.TabIndex = 12;
            this.chartSide1.Text = "chartSide1";
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(12, 12);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tbVolumeLabelSide0);
            this.splitContainer.Panel1.Controls.Add(this.lblVolumeLabelSide0);
            this.splitContainer.Panel1.Controls.Add(this.chartSide0);
            this.splitContainer.Panel1.Controls.Add(this.cbBootOptionSide0);
            this.splitContainer.Panel1.Controls.Add(this.lblBootOptionSide0);
            this.splitContainer.Panel1.Controls.Add(this.lblFreeSide0);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.lblVolumeLabelSide1);
            this.splitContainer.Panel2.Controls.Add(this.chartSide1);
            this.splitContainer.Panel2.Controls.Add(this.tbVolumeLabelSide1);
            this.splitContainer.Panel2.Controls.Add(this.lblFreeSide1);
            this.splitContainer.Panel2.Controls.Add(this.cbBootOptionSide1);
            this.splitContainer.Panel2.Controls.Add(this.lblBootOptionSide1);
            this.splitContainer.Size = new System.Drawing.Size(960, 708);
            this.splitContainer.SplitterDistance = 471;
            this.splitContainer.TabIndex = 13;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 726);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormVolume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "FormVolume";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Volume Info";
            this.Load += new System.EventHandler(this.FormVolume_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartSide0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSide1)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblVolumeLabelSide0;
        private System.Windows.Forms.Label lblVolumeLabelSide1;
        private System.Windows.Forms.TextBox tbVolumeLabelSide0;
        private System.Windows.Forms.TextBox tbVolumeLabelSide1;
        private System.Windows.Forms.ComboBox cbBootOptionSide0;
        private System.Windows.Forms.Label lblBootOptionSide0;
        private System.Windows.Forms.Label lblBootOptionSide1;
        private System.Windows.Forms.ComboBox cbBootOptionSide1;
        private System.Windows.Forms.Label lblFreeSide0;
        private System.Windows.Forms.Label lblFreeSide1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSide0;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSide1;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button btnCancel;
    }
}