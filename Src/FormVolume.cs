using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Acorn
{
    public partial class FormVolume : Form
    {
        #region Members

        private DiskImage diskImage;

        public string VolumeLabelSide0;
        public string VolumeLabelSide1;

        public int BootOptionSide0;
        public int BootOptionSide1;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="diskImage"></param>
        public FormVolume(DiskImage diskImage)
        {
            InitializeComponent();

            this.diskImage = diskImage;

            chartSide0.Series.Clear();
            chartSide0.ChartAreas[0].AxisX.Interval = 1;
            chartSide0.ChartAreas[0].Area3DStyle.Enable3D = true;
            chartSide0.ChartAreas[0].Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartSide0.ChartAreas[0].Area3DStyle.IsClustered = true;
            chartSide0.ChartAreas[0].Area3DStyle.Inclination = 50;
            chartSide0.Titles.Add("DiskUse Side0");

            if (diskImage.num_sides == 2)
            {
                chartSide1.Series.Clear();
                chartSide1.ChartAreas[0].AxisX.Interval = 1;
                chartSide1.ChartAreas[0].Area3DStyle.Enable3D = true;
                chartSide1.ChartAreas[0].Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
                chartSide1.ChartAreas[0].Area3DStyle.IsClustered = true;
                chartSide1.ChartAreas[0].Area3DStyle.Inclination = 50;
                chartSide1.Titles.Add("DiskUse Side1");
            } else
            {
                lblBootOptionSide1.Visible = false;
                lblVolumeLabelSide1.Visible = false;
                lblFreeSide1.Visible = false;
                tbVolumeLabelSide1.Visible = false;
                cbBootOptionSide1.Visible = false;
                chartSide1.Visible = false;
            }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Form loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormVolume_Load(object sender, EventArgs e)
        {
            tbVolumeLabelSide0.Text = diskImage.volume_title_side0;
            cbBootOptionSide0.SelectedIndex = diskImage.boot_side0;

            Series seriesSide0 = this.chartSide0.Series.Add("Side0");
            seriesSide0.ChartType = SeriesChartType.Pie;
            seriesSide0.CustomProperties = "PieLabelStyle=Outside";
            seriesSide0.Enabled = true;

            int totalSectorsSide0 = 0;
            for (int i=0; i<diskImage.num_files_side0; i++)
            {
                int numSectors = Convert.ToInt32(diskImage.filesSide0[i].file_length / DiskImage.SECTOR_SIZE);
                if (diskImage.filesSide0[i].file_length % DiskImage.SECTOR_SIZE != 0) numSectors++;

                seriesSide0.Points.AddXY(diskImage.filesSide0[i].file_name, numSectors);
                totalSectorsSide0 += numSectors;
            }

            int freeSide0 = diskImage.num_sectors_side0 - totalSectorsSide0 - 2;
            if (freeSide0 > 0) seriesSide0.Points.AddXY("FREE", freeSide0);
            lblFreeSide0.Text = freeSide0 + " sectors of " + diskImage.num_sectors_side0 + " free (" + freeSide0 * 256 + " bytes)";

            if (diskImage.num_sides == 2)
            {
                tbVolumeLabelSide1.Text = diskImage.volume_title_side1;
                cbBootOptionSide1.SelectedIndex = diskImage.boot_side1;

                Series seriesSide1 = this.chartSide1.Series.Add("Side1");
                seriesSide1.ChartType = SeriesChartType.Pie;
                seriesSide1.CustomProperties = "PieLabelStyle=Outside";
                seriesSide1.Enabled = true;

                int totalSectorsSide1 = 0;
                for (int i = 0; i < diskImage.num_files_side1; i++)
                {
                    int numSectors = Convert.ToInt32(diskImage.filesSide1[i].file_length / DiskImage.SECTOR_SIZE);
                    if (diskImage.filesSide1[i].file_length % DiskImage.SECTOR_SIZE != 0) numSectors++;

                    seriesSide1.Points.AddXY(diskImage.filesSide1[i].file_name, numSectors);
                    totalSectorsSide1 += numSectors;
                }

                int freeSide1 = diskImage.num_sectors_side1 - totalSectorsSide1 - 2;
                if (freeSide1 > 0) seriesSide1.Points.AddXY("FREE", freeSide1);
                lblFreeSide1.Text = freeSide1 + " sectors of " + diskImage.num_sectors_side1 + " free (" + freeSide1 * 256 + " bytes)";
            }
        }

        /// <summary>
        /// Update variables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            VolumeLabelSide0 = tbVolumeLabelSide0.Text.Trim();
            VolumeLabelSide1 = tbVolumeLabelSide1.Text.Trim();

            if (diskImage.num_sides == 2)
            {
                BootOptionSide0 = cbBootOptionSide0.SelectedIndex;
                BootOptionSide1 = cbBootOptionSide1.SelectedIndex;
            }
        }

        #endregion
    }
}
