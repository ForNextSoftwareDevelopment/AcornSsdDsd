using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Mime;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Acorn
{
    public partial class MainForm : Form
    {
        #region Members

        // Filename of current selected image 
        private string fileName;

        // Current selected side of disk
        private int side;

        // Mouse down (clicked) position
        private Point mouseDownPos;

        #endregion

        #region Constructor

        public MainForm(string fileName = "")
        {
            InitializeComponent();

            this.fileName = fileName;
            mouseDownPos = new Point(0, 0);
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Main form loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (fileName != "")
            {
                // Read image file into byte array
                byte[] bytes = File.ReadAllBytes(fileName);

                // Create new diskimage object
                DiskImage diskImage = new DiskImage(fileName, bytes);

                // Add the new object (image) to the listbox
                lbImages.Items.Add(diskImage);
                lbImages.SelectedIndex = lbImages.Items.Count - 1;

                // Show files in this image
                ShowImageFiles((DiskImage)lbImages.SelectedItem);
            }
        }

        /// <summary>
        /// Show help form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHelp formHelp = new FormHelp();
            formHelp.ShowDialog();
        }

        /// <summary>
        /// Show about form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        /// <summary>
        /// New Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonNewWindow_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            mainForm.Location = new Point(this.Location.X + this.Size.Width + 10, this.Location.Y);
        }

        /// <summary>
        /// New image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonNewFile_Click(object sender, EventArgs e)
        {
            // Create new empty image
            DiskImage diskImage = new DiskImage(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\new.dsd", new byte[2 * 800 * 256]);
            diskImage.num_sectors_side0 = 800;
            diskImage.num_sectors_side1 = 800;
            diskImage.volume_title_side0 = "new";
            diskImage.volume_title_side1 = "new";

            // Add the new object (image) to the listbox
            lbImages.Items.Add(diskImage);
            lbImages.SelectedIndex = lbImages.Items.Count - 1;
        }

        /// <summary>
        /// Disk volume info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonVolume_Click(object sender, EventArgs e)
        {
            if (lbImages.SelectedItem != null)
            {
                DiskImage diskImage = (DiskImage)lbImages.SelectedItem;

                FormVolume formVolume = new FormVolume(diskImage);
                DialogResult result = formVolume.ShowDialog();

                if (result == DialogResult.OK)
                {
                    diskImage.volume_title_side0 = formVolume.VolumeLabelSide0;
                    diskImage.volume_title_side1 = formVolume.VolumeLabelSide1;
                    diskImage.boot_side0 = formVolume.BootOptionSide0;
                    diskImage.boot_side1 = formVolume.BootOptionSide1;

                    lblTitleSide0.Text = "Title: " + diskImage.volume_title_side0;
                    lblBootSide0.Text = "Boot: No action";
                    if (diskImage.boot_side0 == 1) lblBootSide0.Text = "Boot: *LOAD $.!BOOT";
                    if (diskImage.boot_side0 == 2) lblBootSide0.Text = "Boot: *RUN $.!BOOT";
                    if (diskImage.boot_side0 == 3) lblBootSide0.Text = "Boot: *EXEC $.!BOOT";

                    lblTitleSide1.Text = "Title: " + diskImage.volume_title_side1;
                    lblBootSide1.Text = "Boot: No action";
                    if (diskImage.boot_side1 == 1) lblBootSide1.Text = "Boot: *LOAD $.!BOOT";
                    if (diskImage.boot_side1 == 2) lblBootSide1.Text = "Boot: *RUN $.!BOOT";
                    if (diskImage.boot_side1 == 3) lblBootSide1.Text = "Boot: *EXEC $.!BOOT";

                    diskImage.SetVolumeInfo();
                }
            }
        }

        /// <summary>
        /// File info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonFile_Click(object sender, EventArgs e)
        {
            if ((side == 0) && (dgvFilesSide0.CurrentCell != null))
            {
                DiskImage diskImage = (DiskImage)lbImages.SelectedItem;
                int index = Convert.ToInt32(dgvFilesSide0.Rows[dgvFilesSide0.CurrentCell.RowIndex].Cells["index"].Value);

                FormFile formFile = new FormFile(diskImage.filesSide0[index]);
                DialogResult result = formFile.ShowDialog();
                if (result == DialogResult.OK)
                {
                    diskImage.filesSide0[index].folder_name = formFile.FolderName;
                    diskImage.filesSide0[index].file_name = formFile.FileName;
                    diskImage.filesSide0[index].load_address = formFile.LoadAddress;
                    diskImage.filesSide0[index].start_address = formFile.StartAddress;
                    diskImage.filesSide0[index].locked = formFile.Locked;

                    diskImage.SetFileInfo();

                    ShowImageFiles(diskImage);
                }
            }

            if ((side == 1) && (dgvFilesSide1.CurrentCell != null))
            {
                DiskImage diskImage = (DiskImage)lbImages.SelectedItem;
                int index = Convert.ToInt32(dgvFilesSide1.Rows[dgvFilesSide1.CurrentCell.RowIndex].Cells["index"].Value);

                FormFile formFile = new FormFile(diskImage.filesSide1[index]);
                DialogResult result = formFile.ShowDialog();
                if (result == DialogResult.OK)
                {
                    diskImage.filesSide1[index].folder_name = formFile.FolderName;
                    diskImage.filesSide1[index].file_name = formFile.FileName;
                    diskImage.filesSide1[index].load_address = formFile.LoadAddress;
                    diskImage.filesSide1[index].start_address = formFile.StartAddress;
                    diskImage.filesSide1[index].locked = formFile.Locked;

                    diskImage.SetFileInfo();

                    ShowImageFiles(diskImage);
                }
            }
        }

        /// <summary>
        /// Open image file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select Image File";
            fileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            fileDialog.FileName = "";
            fileDialog.Filter = "Acorn Disc Image|*.ssd;*.dsd|All Files|*.*";

            if (fileDialog.ShowDialog() != DialogResult.Cancel)
            {
                fileName = fileDialog.FileName;

                // Read image file into byte array
                byte[] bytes = File.ReadAllBytes(fileName);

                // Create new diskimage object
                DiskImage diskImage = new DiskImage(fileName, bytes);

                // Add the new object (image) to the listbox
                lbImages.Items.Add(diskImage);
                lbImages.SelectedIndex = lbImages.Items.Count - 1;

                // Show files in this image
                ShowImageFiles((DiskImage)lbImages.SelectedItem);
            }
        }

        /// <summary>
        /// Close image file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbImages.SelectedItem != null)
            {
                DiskImage diskImage = (DiskImage)lbImages.SelectedItem;
                lbImages.Items.Remove(diskImage);
                ShowImageFiles(null);

                if (lbImages.Items.Count > 0) lbImages.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Save image file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (lbImages.SelectedItem != null)
            {
                DiskImage diskImage = (DiskImage)lbImages.SelectedItem; 

                if (fileName == "")
                {
                    SaveFileDialog fileDialog = new SaveFileDialog();
                    fileDialog.Title = "Save File As";
                    fileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    fileDialog.FileName = "";
                    if (diskImage.num_sides == 1) fileDialog.Filter = "Acorn Disc Image|*.ssd|All Files|*.*";
                    if (diskImage.num_sides == 2) fileDialog.Filter = "Acorn Disc Image|*.dsd|All Files|*.*";

                    if (fileDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        fileName = fileDialog.FileName;

                        byte[] bytes = diskImage.bytes;

                        // Save binary file
                        File.WriteAllBytes(fileDialog.FileName, bytes);

                        MessageBox.Show("File saved as '" + fileName + "'", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } else
                {
                    byte[] bytes = diskImage.bytes;

                    // Save binary file
                    File.WriteAllBytes(fileName, bytes);

                    MessageBox.Show("File saved as '" + fileName + "'", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Save image file as
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonSaveAs_Click(object sender, EventArgs e)
        {
            if (lbImages.SelectedItem != null)
            {
                DiskImage diskImage = (DiskImage)lbImages.SelectedItem;

                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Title = "Save File As";
                fileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                fileDialog.FileName = "";
                if (diskImage.num_sides == 1) fileDialog.Filter = "Acorn Disc Image|*.ssd|All Files|*.*";
                if (diskImage.num_sides == 2) fileDialog.Filter = "Acorn Disc Image|*.dsd|All Files|*.*";

                if (fileDialog.ShowDialog() != DialogResult.Cancel)
                {
                    fileName = fileDialog.FileName;

                    byte[] bytes = diskImage.bytes;

                    // Save binary file
                    File.WriteAllBytes(fileDialog.FileName, bytes);

                    // Update name in list
                    diskImage.file_name = fileName;
                    lbImages.Items[lbImages.SelectedIndex] = diskImage;
                }

                MessageBox.Show("File saved as '" + fileName + "'", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Save binary of selected file in image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonSaveBinary_Click(object sender, EventArgs e)
        {
            if (lbImages.SelectedItem != null)
            {
                FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                folderDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderDialog.SelectedPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                folderDialog.Description = "Select the directory for saving the binary files.";

                if (folderDialog.ShowDialog() != DialogResult.Cancel)
                {
                    DiskImage diskImage = (DiskImage)lbImages.SelectedItem;
                    string[] temp1 = diskImage.file_name.Split('\\');
                    string[] temp2 = temp1[temp1.Length - 1].Split('.');
                    string imageFile = temp2[0];    

                    string folder = folderDialog.SelectedPath;
 
                    foreach (DataGridViewRow row in dgvFilesSide0.Rows)
                    {
                        string fileName = row.Cells["file"].Value.ToString().Trim();
                        int index = Convert.ToInt32(row.Cells["index"].Value);

                        byte[] data = diskImage.GetFileData(0, index);

                        if (data != null)
                        {
                            try
                            { 
                                Directory.CreateDirectory(folder + "\\" + imageFile + "\\side0");
                                File.WriteAllBytes(folder + "\\" + imageFile + "\\side0\\" + fileName + ".bin", data);

                                string info;
                                info = "Load:   " + row.Cells["load"].Value.ToString() + "\r\n";
                                info += "Start:  " + row.Cells["start"].Value.ToString() + "\r\n";
                                info += "Length: " + row.Cells["length"].Value.ToString() + "\r\n";

                                File.WriteAllText(folder + "\\" + imageFile + "\\side0\\" + fileName + ".txt", info);

                                MessageBox.Show("Files saved in '" + folder + "'", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            } catch (Exception exception)
                            {
                                MessageBox.Show("Can't save binary file: " + exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    foreach (DataGridViewRow row in dgvFilesSide1.Rows)
                    {
                        string fileName = row.Cells["file"].Value.ToString();
                        int index = Convert.ToInt32(row.Cells["index"].Value);

                        byte[] data = diskImage.GetFileData(1, index);

                        if (data != null)
                        {
                            try
                            { 
                                Directory.CreateDirectory(folder + "\\" + imageFile + "\\side1");
                                File.WriteAllBytes(folder + "\\" + imageFile + "\\side1\\" + fileName + ".bin", data);

                                string info;
                                info = "Load:   " + row.Cells["load"].Value.ToString() + "\r\n";
                                info += "Start:  " + row.Cells["start"].Value.ToString() + "\r\n";
                                info += "Length: " + row.Cells["length"].Value.ToString() + "\r\n";

                                File.WriteAllText(folder + "\\" + imageFile + "\\side1\\" + fileName + ".txt", info);

                                MessageBox.Show("Files saved in '" + folder + "'", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            } catch (Exception exception)
                            {
                                MessageBox.Show("Can't save binary file: " + exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Organize files in image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonOrganize_Click(object sender, EventArgs e)
        {
            if (lbImages.SelectedItem != null)
            {
                DiskImage diskImage = (DiskImage)lbImages.SelectedItem;

                int size = 800 * DiskImage.SECTOR_SIZE;
                if (diskImage.num_sides == 2) size = 1600 * DiskImage.SECTOR_SIZE;

                DiskImage diskImageNew = new DiskImage(diskImage.file_name, new byte[size]);
                diskImageNew.num_sides = diskImage.num_sides;

                List<string> list;

                // Side0
                list = new List<string>();
                for (int index = 0; index < diskImage.num_files_side0; index++)
                {
                    DiskImage.FILE file = diskImage.filesSide0[index];

                    // Add file data to this entry
                    diskImage.filesSide0[index].data = diskImage.GetFileData(0, index);

                    // Add to list
                    list.Add(file.file_name);
                }

                // Sort alphabetically
                list.Sort(CompareIgnoreCase);

                diskImageNew.boot_side0 = diskImage.boot_side0;
                diskImageNew.volume_title_side0 = diskImage.volume_title_side0;
                diskImageNew.num_files_side0 = 0;
                diskImageNew.num_sectors_side0 = diskImage.num_sectors_side0;

                foreach (string fileName in list)
                {
                    for (int index = 0; index < diskImage.num_files_side0; index++)
                    {
                        if ((diskImage.filesSide0[index].file_name != null) && (diskImage.filesSide0[index].file_name == fileName))
                        {
                            diskImageNew.InsertFile(diskImage.filesSide0[index], 0);

                            // Set file as done in case multiple files with the same name (but different folders) are present
                            diskImage.filesSide0[index].file_name = null;
                        }
                    }
                }

                // Side1
                if (diskImage.num_sides == 2)
                {
                    list = new List<string>();
                    for (int index = 0; index < diskImage.num_files_side1; index++)
                    {
                        DiskImage.FILE file = diskImage.filesSide1[index];

                        // Add file data to this entry
                        diskImage.filesSide1[index].data = diskImage.GetFileData(1, index);

                        // Add to list
                        list.Add(file.file_name);
                    }

                    // Sort alphabetically
                    list.Sort(CompareIgnoreCase);

                    diskImageNew.boot_side1 = diskImage.boot_side1;
                    diskImageNew.volume_title_side1 = diskImage.volume_title_side1;
                    diskImageNew.num_files_side1 = 0;
                    diskImageNew.num_sectors_side1 = diskImage.num_sectors_side1;

                    foreach (string fileName in list)
                    {
                        for (int index = 0; index < diskImage.num_files_side1; index++)
                        {
                            if ((diskImage.filesSide1[index].file_name != null) && (diskImage.filesSide1[index].file_name == fileName))
                            {
                                diskImageNew.InsertFile(diskImage.filesSide1[index], 1);

                                // Set file as done in case multiple files with the same name (but different folders) are present
                                diskImage.filesSide1[index].file_name = null;
                            }
                        }
                    }
                }

                // Replace disk image file and show files
                lbImages.Items.Remove(diskImage);
                lbImages.Items.Add(diskImageNew);
                lbImages.SelectedIndex = lbImages.Items.Count - 1;
                ShowImageFiles(diskImageNew);
            }
        }

        /// <summary>
        /// Make image compact 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonCompact_Click(object sender, EventArgs e)
        {
            if (lbImages.SelectedItem != null)
            {
                DiskImage diskImage = (DiskImage)lbImages.SelectedItem;

                // Get first unused sector on side0
                int highest_sector_side0 = 0;
                foreach (DiskImage.FILE file in diskImage.filesSide0)
                {
                    int numSectors = Convert.ToInt32(file.file_length / DiskImage.SECTOR_SIZE);
                    if (file.file_length % DiskImage.SECTOR_SIZE != 0) numSectors++;
                    if (file.file_length == 0) numSectors = 1;

                    if (file.start_sector + numSectors > highest_sector_side0) highest_sector_side0 = file.start_sector + numSectors;
                }

                // Get first unused sector on side1
                int highest_sector_side1 = 0;
                foreach (DiskImage.FILE file in diskImage.filesSide1)
                {
                    int numSectors = Convert.ToInt32(file.file_length / DiskImage.SECTOR_SIZE);
                    if (file.file_length % DiskImage.SECTOR_SIZE != 0) numSectors++;
                    if (file.file_length == 0) numSectors = 1;

                    if (file.start_sector + numSectors > highest_sector_side1) highest_sector_side1 = file.start_sector + numSectors;
                }

                int highest_sector = highest_sector_side0 >= highest_sector_side1 ? highest_sector_side0 : highest_sector_side1;

                // Go the the nearest interleave border 
                while ((highest_sector % DiskImage.INTERLEAVE_SECTORS) != 0) highest_sector++;

                // Resize data array
                if (diskImage.num_sides == 1) Array.Resize(ref diskImage.bytes,     highest_sector * DiskImage.SECTOR_SIZE);
                if (diskImage.num_sides == 2) Array.Resize(ref diskImage.bytes, 2 * highest_sector * DiskImage.SECTOR_SIZE);
            }
        }

        /// <summary>
        /// Close program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Image file selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show files in this image
            if (lbImages.SelectedItem != null)
            {
                fileName = lbImages.SelectedItem.ToString();
                ShowImageFiles((DiskImage)lbImages.SelectedItem);
            }
        }
        
        /// <summary>
        /// Delete file from image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFilesSide0_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if ((side == 0 ) && (dgvFilesSide0.CurrentCell != null))
                {
                    DiskImage diskImage = (DiskImage)lbImages.SelectedItem;
                    int index = Convert.ToInt32(dgvFilesSide0.Rows[dgvFilesSide0.CurrentCell.RowIndex].Cells["index"].Value);
                    diskImage.DeleteFile(0, index);
                    ShowImageFiles(diskImage);
                }
            }
        }

        /// <summary>
        /// Delete file from image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFilesSide1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if ((side == 1) && (dgvFilesSide1.CurrentCell != null))
                {
                    DiskImage diskImage = (DiskImage)lbImages.SelectedItem;
                    int index = Convert.ToInt32(dgvFilesSide1.Rows[dgvFilesSide1.CurrentCell.RowIndex].Cells["index"].Value);
                    diskImage.DeleteFile(1, index);
                    ShowImageFiles(diskImage);
                }
            }
        }

        /// <summary>
        /// Drag file / Show info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFilesSide0_MouseDown(object sender, MouseEventArgs e)
        {
            // Set current side to side 0
            side = 0;

            // Set initial position for drag-drop
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPos = new Point(e.X, e.Y);
            }

            // Show (edit) file info 
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvFilesSide0.HitTest(e.X, e.Y);
                if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                {
                    int index = Convert.ToInt32(dgvFilesSide0.Rows[info.RowIndex].Cells["index"].Value);

                    DiskImage diskImage = (DiskImage)lbImages.SelectedItem;

                    FormFile formFile = new FormFile(diskImage.filesSide0[index]);
                    DialogResult result = formFile.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        diskImage.filesSide0[index].folder_name = formFile.FolderName;
                        diskImage.filesSide0[index].file_name = formFile.FileName;
                        diskImage.filesSide0[index].load_address = formFile.LoadAddress;
                        diskImage.filesSide0[index].start_address = formFile.StartAddress;
                        diskImage.filesSide0[index].locked = formFile.Locked;

                        diskImage.SetFileInfo();

                        ShowImageFiles(diskImage);
                    }
                }
            }
        }

        /// <summary>
        /// Start dragging if mouse moves after click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFilesSide0_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (Math.Abs(e.X - mouseDownPos.X) >= SystemInformation.DragSize.Width ||
                    Math.Abs(e.Y - mouseDownPos.Y) >= SystemInformation.DragSize.Height)
                {
                    dgvFilesSide0.AllowDrop = false;
                    dgvFilesSide1.AllowDrop = true;

                    DataGridView.HitTestInfo info = dgvFilesSide0.HitTest(mouseDownPos.X, mouseDownPos.Y);
                    if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                    {
                        int index = Convert.ToInt32(dgvFilesSide0.Rows[info.RowIndex].Cells["index"].Value);

                        DiskImage diskImage = (DiskImage)lbImages.SelectedItem;

                        if (diskImage.num_sides == 1) dgvFilesSide1.AllowDrop = false;

                        // Get data for this file
                        byte[] data = diskImage.GetFileData(0, index);

                        // Create file object and attach data for this file
                        DiskImage.FILE file = diskImage.filesSide0[index];
                        file.data = data;

                        // Start drag-Drop
                        DataGridView dataGridView = (DataGridView)sender;
                        dataGridView.DoDragDrop(file, DragDropEffects.Copy | DragDropEffects.Move);
                    }
                }
            }
        }

        /// <summary>
        /// Drag file into datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFilesSide0_DragEnter(object sender, DragEventArgs e)
        {
            Type type = e.Data.GetType();

            if (type == typeof(DataObject))
            {
                if ((e.KeyState & 4) == 4 && (e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
                {
                    // SHIFT KeyState for move.
                    e.Effect = DragDropEffects.Move;
                } else if ((e.KeyState & 8) == 8 && (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
                {
                    // CTRL KeyState for copy.
                    e.Effect = DragDropEffects.Copy;
                } else if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
                {
                    // By default, the drop action should be copy
                    e.Effect = DragDropEffects.Copy;
                }
            } else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Check if move or copy while dragging in target area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFilesSide0_DragOver(object sender, DragEventArgs e)
        {
            if (((e.KeyState & 4) == 4) && (e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                e.Effect = DragDropEffects.Move;
            }
            else if((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            } else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Drop file in target area (other diskimage)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFilesSide0_DragDrop(object sender, DragEventArgs e)
        {
            Type type = e.Data.GetType();

            if (type == typeof(DataObject))
            {
                DiskImage.FILE fileCopy = (DiskImage.FILE)e.Data.GetData(typeof(DiskImage.FILE));

                // Get diskimage where to put this file on
                DiskImage diskImage = (DiskImage)lbImages.SelectedItem;

                // Check Folder/File names for duplicates
                bool found = false;
                foreach (DiskImage.FILE file in diskImage.filesSide0)
                {
                    if ((file.folder_name == fileCopy.folder_name) && (file.file_name == fileCopy.file_name)) found = true;
                }

                if (found)
                {
                    MessageBox.Show("Already a file with the same folder/file name present", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if the number of files already on this diskside is lower then 31
                if (diskImage.num_files_side0 >= 31)
                {
                    MessageBox.Show("Too many files on this disk side", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Insert
                diskImage.InsertFile(fileCopy, 0);

                // Update datagridview
                ShowImageFiles(diskImage);
            }
        }

        /// <summary>
        /// Drag file / Show info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFilesSide1_MouseDown(object sender, MouseEventArgs e)
        {
            // Set current side to side 1
            side = 1;

            // Set initial position for drag-drop
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPos = new Point(e.X, e.Y);
            }

            // Show (edit) file info 
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvFilesSide1.HitTest(e.X, e.Y);
                if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                {
                    int index = Convert.ToInt32(dgvFilesSide1.Rows[info.RowIndex].Cells["index"].Value);

                    DiskImage diskImage = (DiskImage)lbImages.SelectedItem;

                    FormFile formFile = new FormFile(diskImage.filesSide1[index]);
                    DialogResult result = formFile.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        diskImage.filesSide1[index].folder_name = formFile.FolderName;
                        diskImage.filesSide1[index].file_name = formFile.FileName;
                        diskImage.filesSide1[index].load_address = formFile.LoadAddress;
                        diskImage.filesSide1[index].start_address = formFile.StartAddress;
                        diskImage.filesSide1[index].locked = formFile.Locked;

                        diskImage.SetFileInfo();

                        ShowImageFiles(diskImage);
                    }
                }
            }
        }

        /// <summary>
        /// Start dragging if mouse moves after click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFilesSide1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (Math.Abs(e.X - mouseDownPos.X) >= SystemInformation.DragSize.Width ||
                    Math.Abs(e.Y - mouseDownPos.Y) >= SystemInformation.DragSize.Height)
                {
                    dgvFilesSide0.AllowDrop = true;
                    dgvFilesSide1.AllowDrop = false;

                    DataGridView.HitTestInfo info = dgvFilesSide1.HitTest(mouseDownPos.X, mouseDownPos.Y);
                    if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                    {
                        int index = Convert.ToInt32(dgvFilesSide1.Rows[info.RowIndex].Cells["index"].Value);

                        DiskImage diskImage = (DiskImage)lbImages.SelectedItem;

                        // Get data for this file
                        byte[] data = diskImage.GetFileData(1, index);

                        // Create file object and attach data for this file
                        DiskImage.FILE file = diskImage.filesSide1[index];
                        file.data = data;

                        // Start drag-Drop
                        DataGridView dataGridView = (DataGridView)sender;
                        dataGridView.DoDragDrop(file, DragDropEffects.Copy | DragDropEffects.Move);
                    }
                }
            }
        }

        /// <summary>
        /// Drag file into datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFilesSide1_DragEnter(object sender, DragEventArgs e)
        {
            Type type = e.Data.GetType();

            if (type == typeof(DataObject))
            {
                if ((e.KeyState & 4) == 4 && (e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
                {
                    // SHIFT KeyState for move.
                    e.Effect = DragDropEffects.Move;
                } else if ((e.KeyState & 8) == 8 && (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
                {
                    // CTRL KeyState for copy.
                    e.Effect = DragDropEffects.Copy;
                } else if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
                {
                    // By default, the drop action should be copy
                    e.Effect = DragDropEffects.Copy;
                }
            } else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Check if move or copy while dragging in target area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFilesSide1_DragOver(object sender, DragEventArgs e)
        {
            if (((e.KeyState & 4) == 4) && (e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                e.Effect = DragDropEffects.Move;
            } else if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            } else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Drop file in target area (other diskimage)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFilesSide1_DragDrop(object sender, DragEventArgs e)
        {
            Type type = e.Data.GetType();

            if (type == typeof(DataObject))
            {
                DiskImage.FILE fileCopy = (DiskImage.FILE)e.Data.GetData(typeof(DiskImage.FILE));

                // Get diskimage where to put this file on
                DiskImage diskImage = (DiskImage)lbImages.SelectedItem;

                // Check Folder/File names for duplicates
                bool found = false;
                foreach (DiskImage.FILE file in diskImage.filesSide1)
                {
                    if ((file.folder_name == fileCopy.folder_name) && (file.file_name == fileCopy.file_name)) found = true;
                }

                if (found)
                {
                    MessageBox.Show("Already a file with the same folder/file name present", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if the number of files already on this diskside is lower then 31
                if (diskImage.num_files_side1 >= 31)
                {
                    MessageBox.Show("Too many files on this disk side", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Insert
                diskImage.InsertFile(fileCopy, 1);

                // Update datagridview
                ShowImageFiles(diskImage);
            }
        }

        /// <summary>
        /// Mouse button released
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFilesSide0_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dgvFilesSide0.AllowDrop = false;
                dgvFilesSide1.AllowDrop = false;

                if (lbImages.SelectedItem != null)
                {
                    dgvFilesSide0.AllowDrop = true;

                    DiskImage diskImage = (DiskImage)lbImages.SelectedItem;
                    if (diskImage.num_sides == 2) dgvFilesSide1.AllowDrop = true;
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Compare 2 strings for sorting (inverse alphabetically, ignore case) 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int CompareIgnoreCase(string x, string y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're equal
                    return 0;
                } else
                {
                    // If x is null and y is not null, y is greater
                    return -1;
                }
            } else
            {
                // If x is not null...
                if (y == null)
                {
                    // ...and y is null, x is greater
                    return 1;
                } else
                {
                    // ...and y is not null, compare the two strings
                    int retval = String.Compare(x, y, true);
                    return -retval;
                }
            }
        }

        /// <summary>
        /// Show files in this image
        /// </summary>
        /// <param name="diskImage"></param>
        private void ShowImageFiles(DiskImage diskImage)
        {
            dgvFilesSide0.Rows.Clear();
            dgvFilesSide0.Columns.Clear();
            dgvFilesSide1.Rows.Clear();
            dgvFilesSide1.Columns.Clear();

            lblTitleSide0.Text = "Title: ";
            lblFilesSide0.Text = "Files: ";
            lblSectorsSide0.Text = "Sectors: ";
            lblBootSide0.Text = "Boot: No action";

            lblTitleSide1.Text = "Title: ";
            lblFilesSide1.Text = "Files: ";
            lblSectorsSide1.Text = "Sectors: ";
            lblBootSide1.Text = "Boot: No action";

            if (diskImage == null) return;

            dgvFilesSide0.AllowDrop = true;

            lblTitleSide0.Text = "Title: " + diskImage.volume_title_side0;
            lblFilesSide0.Text = "Files: " + diskImage.num_files_side0.ToString();
            lblSectorsSide0.Text = "Sectors: " + diskImage.num_sectors_side0.ToString();
            lblBootSide0.Text = "Boot: No action";
            if (diskImage.boot_side0 == 1) lblBootSide0.Text = "Boot: *LOAD $.!BOOT";
            if (diskImage.boot_side0 == 2) lblBootSide0.Text = "Boot: *RUN $.!BOOT";
            if (diskImage.boot_side0 == 3) lblBootSide0.Text = "Boot: *EXEC $.!BOOT";

            // Fill datagridview with info
            dgvFilesSide0.Columns.Add("index", "Index");
            dgvFilesSide0.Columns["index"].Visible = false;
            dgvFilesSide0.Columns.Add("file", "File");
            dgvFilesSide0.Columns.Add("folder", "Folder");
            DataGridViewCheckBoxColumn cbColumnLocked0 = new DataGridViewCheckBoxColumn();
            cbColumnLocked0.Name = "locked";
            cbColumnLocked0.HeaderText = "Locked";
            dgvFilesSide0.Columns.Add(cbColumnLocked0);
            DataGridViewCheckBoxColumn cbColumnIoProcMemLoad0 = new DataGridViewCheckBoxColumn();
            cbColumnIoProcMemLoad0.Name = "ioprocmemload";
            cbColumnIoProcMemLoad0.HeaderText = "I/O Proc Mem Load";
            dgvFilesSide0.Columns.Add(cbColumnIoProcMemLoad0);
            dgvFilesSide0.Columns.Add("load", "Load Address");
            DataGridViewCheckBoxColumn cbColumnIoProcMemStart0 = new DataGridViewCheckBoxColumn();
            cbColumnIoProcMemStart0.Name = "ioprocmemstart";
            cbColumnIoProcMemStart0.HeaderText = "I/O Proc Mem Start";
            dgvFilesSide0.Columns.Add(cbColumnIoProcMemStart0);
            dgvFilesSide0.Columns.Add("start", "Start Address");
            dgvFilesSide0.Columns.Add("length", "File Length");
            dgvFilesSide0.Columns["length"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvFilesSide0.Columns.Add("sectors", "Num Sectors");
            dgvFilesSide0.Columns["sectors"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvFilesSide0.Columns.Add("sector", "Start Sector");
            dgvFilesSide0.Columns["sector"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            for (int i = diskImage.num_files_side0 - 1; i >=0 ; i--)
            {
                int numSectors = Convert.ToInt32(diskImage.filesSide0[i].file_length / DiskImage.SECTOR_SIZE);
                if (diskImage.filesSide0[i].file_length % DiskImage.SECTOR_SIZE != 0) numSectors++;
                if (diskImage.filesSide0[i].file_length == 0) numSectors = 1;

                dgvFilesSide0.Rows.Add();
                dgvFilesSide0.Rows[dgvFilesSide0.Rows.Count - 1].Cells["index"].Value = i;
                dgvFilesSide0.Rows[dgvFilesSide0.Rows.Count - 1].Cells["file"].Value = diskImage.filesSide0[i].file_name.Trim();
                dgvFilesSide0.Rows[dgvFilesSide0.Rows.Count - 1].Cells["folder"].Value = diskImage.filesSide0[i].folder_name;
                dgvFilesSide0.Rows[dgvFilesSide0.Rows.Count - 1].Cells["locked"].Value = diskImage.filesSide0[i].locked;
                dgvFilesSide0.Rows[dgvFilesSide0.Rows.Count - 1].Cells["ioprocmemload"].Value = ((Convert.ToUInt32(diskImage.filesSide0[i].load_address) & 0x030000) == 0x030000) ? true : false; 
                dgvFilesSide0.Rows[dgvFilesSide0.Rows.Count - 1].Cells["load"].Value = "0x" + (Convert.ToUInt32(diskImage.filesSide0[i].load_address) & 0xFFFF).ToString("X4");
                dgvFilesSide0.Rows[dgvFilesSide0.Rows.Count - 1].Cells["ioprocmemstart"].Value = ((Convert.ToUInt32(diskImage.filesSide0[i].start_address) & 0x030000) == 0x030000) ? true : false;
                dgvFilesSide0.Rows[dgvFilesSide0.Rows.Count - 1].Cells["start"].Value = "0x" + (Convert.ToUInt32(diskImage.filesSide0[i].start_address) & 0xFFFF).ToString("X4");
                dgvFilesSide0.Rows[dgvFilesSide0.Rows.Count - 1].Cells["length"].Value = diskImage.filesSide0[i].file_length;
                dgvFilesSide0.Rows[dgvFilesSide0.Rows.Count - 1].Cells["sectors"].Value = numSectors;
                dgvFilesSide0.Rows[dgvFilesSide0.Rows.Count - 1].Cells["sector"].Value = diskImage.filesSide0[i].start_sector;
            }

            if (diskImage.num_sides == 2)
            {
                dgvFilesSide1.AllowDrop = true;

                lblTitleSide1.Text = "Title: " + diskImage.volume_title_side1;
                lblFilesSide1.Text = "Files: " + diskImage.num_files_side1.ToString();
                lblSectorsSide1.Text = "Sectors: " + diskImage.num_sectors_side1.ToString();
                lblBootSide1.Text = "Boot: No action";
                if (diskImage.boot_side1 == 1) lblBootSide1.Text = "Boot: *LOAD $.!BOOT";
                if (diskImage.boot_side1 == 2) lblBootSide1.Text = "Boot: *RUN $.!BOOT";
                if (diskImage.boot_side1 == 3) lblBootSide1.Text = "Boot: *EXEC $.!BOOT";

                // Fill datagridview with info
                dgvFilesSide1.Columns.Add("index", "Index");
                dgvFilesSide1.Columns["index"].Visible = false;
                dgvFilesSide1.Columns.Add("file", "File");
                dgvFilesSide1.Columns.Add("folder", "Folder");
                DataGridViewCheckBoxColumn cbColumnLocked1 = new DataGridViewCheckBoxColumn();
                cbColumnLocked1.Name = "locked";
                cbColumnLocked1.HeaderText = "Locked";
                dgvFilesSide1.Columns.Add(cbColumnLocked1);
                DataGridViewCheckBoxColumn cbColumnIoProcMemLoad1 = new DataGridViewCheckBoxColumn();
                cbColumnIoProcMemLoad1.Name = "ioprocmemload";
                cbColumnIoProcMemLoad1.HeaderText = "I/O Proc Mem Load";
                dgvFilesSide1.Columns.Add(cbColumnIoProcMemLoad1);
                dgvFilesSide1.Columns.Add("load", "Load Address");
                DataGridViewCheckBoxColumn cbColumnIoProcMemStart1 = new DataGridViewCheckBoxColumn();
                cbColumnIoProcMemStart1.Name = "ioprocmemstart";
                cbColumnIoProcMemStart1.HeaderText = "I/O Proc Mem Start";
                dgvFilesSide1.Columns.Add(cbColumnIoProcMemStart1);
                dgvFilesSide1.Columns.Add("start", "Start Address");
                dgvFilesSide1.Columns.Add("length", "File Length");
                dgvFilesSide1.Columns["length"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvFilesSide1.Columns.Add("sectors", "Num Sectors");
                dgvFilesSide1.Columns["sectors"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvFilesSide1.Columns.Add("sector", "Start Sector");
                dgvFilesSide1.Columns["sector"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                for (int i = diskImage.num_files_side1 - 1; i >= 0; i--)
                {
                    int numSectors = Convert.ToInt32(diskImage.filesSide1[i].file_length / DiskImage.SECTOR_SIZE);
                    if (diskImage.filesSide1[i].file_length % DiskImage.SECTOR_SIZE != 0) numSectors++;
                    if (diskImage.filesSide1[i].file_length == 0) numSectors = 1;

                    dgvFilesSide1.Rows.Add();
                    dgvFilesSide1.Rows[dgvFilesSide1.Rows.Count - 1].Cells["index"].Value = i;
                    dgvFilesSide1.Rows[dgvFilesSide1.Rows.Count - 1].Cells["file"].Value = diskImage.filesSide1[i].file_name.Trim();
                    dgvFilesSide1.Rows[dgvFilesSide1.Rows.Count - 1].Cells["folder"].Value = diskImage.filesSide1[i].folder_name;
                    dgvFilesSide1.Rows[dgvFilesSide1.Rows.Count - 1].Cells["locked"].Value = diskImage.filesSide1[i].locked;
                    dgvFilesSide1.Rows[dgvFilesSide1.Rows.Count - 1].Cells["ioprocmemload"].Value = ((Convert.ToUInt32(diskImage.filesSide1[i].load_address) & 0x030000) == 0x030000) ? true : false;
                    dgvFilesSide1.Rows[dgvFilesSide1.Rows.Count - 1].Cells["load"].Value = "0x" + (Convert.ToUInt32(diskImage.filesSide1[i].load_address) & 0xFFFF).ToString("X4");
                    dgvFilesSide1.Rows[dgvFilesSide1.Rows.Count - 1].Cells["ioprocmemstart"].Value = ((Convert.ToUInt32(diskImage.filesSide1[i].start_address) & 0x030000) == 0x030000) ? true : false;
                    dgvFilesSide1.Rows[dgvFilesSide1.Rows.Count - 1].Cells["start"].Value = "0x" + (Convert.ToUInt32(diskImage.filesSide1[i].start_address) & 0xFFFF).ToString("X4");
                    dgvFilesSide1.Rows[dgvFilesSide1.Rows.Count - 1].Cells["length"].Value = diskImage.filesSide1[i].file_length;
                    dgvFilesSide1.Rows[dgvFilesSide1.Rows.Count - 1].Cells["sectors"].Value = numSectors;
                    dgvFilesSide1.Rows[dgvFilesSide1.Rows.Count - 1].Cells["sector"].Value = diskImage.filesSide1[i].start_sector;
                }
            }
        }

        #endregion
    }
}
