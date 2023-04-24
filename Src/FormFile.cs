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
    public partial class FormFile : Form
    {
        #region Members

        private DiskImage.FILE file;

        public char FolderName;
        public string FileName;
        public int LoadAddress;
        public int StartAddress;
        public bool Locked;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="diskImage"></param>
        public FormFile(DiskImage.FILE file)
        {
            InitializeComponent();

            this.file = file;
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
            tbFolderName.Text = file.folder_name.ToString();
            tbFileName.Text = file.file_name;
            cbIoProcMemLoad.Checked = (file.load_address & 0x030000) == 0x030000 ? true : false;
            tbLoadAddress.Text = (file.load_address & 0xFFFF).ToString("X4");
            cbIoProcMemStart.Checked = (file.start_address & 0x030000) == 0x030000 ? true : false;
            tbStartAddress.Text = (file.start_address & 0xFFFF).ToString("X4");
            tbFileLength.Text = file.file_length.ToString();
            tbStartSector.Text = file.start_sector.ToString();
            chkLocked.Checked = file.locked;
        }

        /// <summary>
        /// Update variables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            FolderName = tbFolderName.Text != "" ? tbFolderName.Text[0]: '$';
            FileName = tbFileName.Text.Trim();
            LoadAddress = Convert.ToInt32(tbLoadAddress.Text, 16);
            if (cbIoProcMemLoad.Checked) LoadAddress += 0x030000;
            StartAddress = Convert.ToInt32(tbStartAddress.Text, 16);
            if (cbIoProcMemStart.Checked) StartAddress += 0x030000;
            Locked = chkLocked.Checked;
        }

        /// <summary>
        /// Load address changing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbLoadAddress_TextChanged(object sender, EventArgs e)
        {
            string hexdigits = "1234567890ABCDEFabcdef";
            bool noHex = false;
            foreach (char c in tbLoadAddress.Text)
            {
                if (hexdigits.IndexOf(c) < 0)
                {
                    MessageBox.Show("Only hexadecimal values", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    noHex = true;
                }
            }

            if (noHex) tbLoadAddress.Text = "0000";
        }

        /// <summary>
        /// Start address changing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbStartAddress_TextChanged(object sender, EventArgs e)
        {
            string hexdigits = "1234567890ABCDEFabcdef";
            bool noHex = false;
            foreach (char c in tbStartAddress.Text)
            {
                if (hexdigits.IndexOf(c) < 0)
                {
                    MessageBox.Show("Only hexadecimal values", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    noHex = true;
                }
            }

            if (noHex) tbStartAddress.Text = "0000";
        }

        #endregion
    }
}
