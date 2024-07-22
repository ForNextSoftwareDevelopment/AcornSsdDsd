using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace Acorn
{
    public class DiskImage
    {
        #region Define

        public const int SECTOR_SIZE = 256;
        public const int START_SECTOR_0 = 0;
        public const int START_SECTOR_1 = 256;
        public const int INTERLEAVE_SECTORS = 10;
        public const int INTERLEAVE = INTERLEAVE_SECTORS * SECTOR_SIZE;

        public struct FILE
        {
            public FILE(string file_name = "", char folder_name = ' ', bool locked = false, int load_address = 0, int start_address = 0, int file_length = 0, int start_sector = 0, byte[] data = null)
            {
                this.file_name = file_name;
                this.folder_name = folder_name;
                this.locked = locked;
                this.load_address = load_address;
                this.start_address = start_address;
                this.file_length = file_length;
                this.start_sector = start_sector;
                this.data = data;
            }

            public string file_name;
            public char folder_name;
            public bool locked;
            public int load_address;
            public int start_address;
            public int file_length;
            public int start_sector;

            // Used for drag-drop
            public byte[] data;

            public override string ToString() => $"({folder_name}, {file_name})";
        }

        #endregion

        #region Members

        public string file_name;
        public int num_sides;
        public string volume_title_side0;
        public string volume_title_side1;
        public int num_files_side0;
        public int num_files_side1;
        public int boot_side0;
        public int boot_side1;
        public int num_sectors_side0;
        public int num_sectors_side1;

        public byte[] bytes;

        public FILE[] filesSide0;
        public FILE[] filesSide1;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="file_name"></param>
        /// <param name="bytes"></param>
        public DiskImage(string file_name, byte[] bytes)
        {
            this.file_name = file_name;
            this.bytes = bytes;

            num_sides = 1;
            if (file_name.ToLower().EndsWith(".ssd")) num_sides = 1; else
            if (file_name.ToLower().EndsWith(".dsd")) num_sides = 2; else
            {
                MessageBox.Show("No ssd or dsd extension so assuming single sided disk.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            volume_title_side0 = "";
            volume_title_side1 = "";
            num_files_side0 = 0;
            num_files_side1 = 0;
            boot_side0 = 0;
            boot_side1 = 0;
            num_sectors_side0 = 0;
            num_sectors_side1 = 0;

            filesSide0 = new FILE[31];
            filesSide1 = new FILE[31];

            // Get info for each side (fill members)
            GetVolumeInfo();

            // Get info for files on each side
            GetFileInfo();

            // Check image file
            bool result = CheckImage();
            if (!result)
            {
                MessageBox.Show("This disk image seems corrupt, use with caution !", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Override ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return file_name;
        }

        /// <summary>
        /// Get general info for disc 
        /// </summary>
        private void GetVolumeInfo()
        {
            try
            {
                // Copy disk title (side0)
                for (int i = 0; i < 8; i++)
                {
                    volume_title_side0 += Convert.ToChar(bytes[START_SECTOR_0 + i]);
                }

                for (int i = 0; i < 4; i++)
                {
                    volume_title_side0 += Convert.ToChar(bytes[START_SECTOR_1 + i]);
                }

                // Get number of files (side0)
                num_files_side0 = bytes[START_SECTOR_1 + 5] >> 3;

                // Get boot option (side0)
                boot_side0 = (bytes[START_SECTOR_1 + 6] & 0b00110000) >> 4;

                // Get number of sectors (side0)
                num_sectors_side0 = (bytes[START_SECTOR_1 + 6] & 0b00000011) << 8;
                num_sectors_side0 += bytes[START_SECTOR_1 + 7];

                if (num_sides == 2)
                {
                    // Copy disk title (side1)
                    for (int i = 0; i < 8; i++)
                    {
                        volume_title_side1 += Convert.ToChar(bytes[INTERLEAVE + START_SECTOR_0 + i]);
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        volume_title_side1 += Convert.ToChar(bytes[INTERLEAVE + START_SECTOR_1 + i]);
                    }

                    // Get number of files  (side1)
                    num_files_side1 = bytes[INTERLEAVE + START_SECTOR_1 + 5] >> 3;

                    // Get boot option (side1)
                    boot_side1 = (bytes[INTERLEAVE + START_SECTOR_1 + 6] & 0b00110000) >> 4;

                    // Get number of sectors (side1)
                    num_sectors_side1 = (bytes[INTERLEAVE + START_SECTOR_1 + 6] & 0b00000011) << 8;
                    num_sectors_side1 += bytes[INTERLEAVE + START_SECTOR_1 + 7];
                }
            } catch (Exception exception)
            {
                MessageBox.Show("Can't get volume info: " + exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Get file info 
        /// </summary>
        /// <returns></returns>
        private void GetFileInfo()
        {
            try
            { 
                // Get file/folder names side 0
                for (int i = 0; i < num_files_side0; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        filesSide0[i].file_name += Convert.ToChar(bytes[START_SECTOR_0 + 8 + (i * 8) + j]);
                    }

                    // Get folder name for this file
                    filesSide0[i].folder_name = Convert.ToChar(bytes[START_SECTOR_0 + 8 + (i * 8) + 7] & 0b01111111);

                    // Get locked status 
                    filesSide0[i].locked = (bytes[START_SECTOR_0 + 8 + (i * 8) + 7] & 0b10000000) == 0b10000000 ? true : false;

                    // Get load addresses
                    int load_address = bytes[START_SECTOR_1 + i * 8 + 8];
                    load_address += 0x100 * bytes[START_SECTOR_1 + i * 8 + 9];
                    load_address += 0x10000 * ((bytes[START_SECTOR_1 + i * 8 + 14] & 0b00001100) >> 2);
                    filesSide0[i].load_address = load_address;

                    // Get start addresses
                    int start_address = bytes[START_SECTOR_1 + i * 8 + 10];
                    start_address += 0x100 * bytes[START_SECTOR_1 + i * 8 + 11];
                    start_address += 0x10000 * ((bytes[START_SECTOR_1 + i * 8 + 14] & 0b11000000) >> 6);
                    filesSide0[i].start_address = start_address;

                    // Get file length
                    int file_length = bytes[START_SECTOR_1 + i * 8 + 12];
                    file_length += 0x100 * bytes[START_SECTOR_1 + i * 8 + 13];
                    file_length += 0x10000 * ((bytes[START_SECTOR_1 + i * 8 + 14] & 0b00110000) >> 4);
                    filesSide0[i].file_length = file_length;

                    // Get start sector
                    int start_sector = bytes[START_SECTOR_1 + i * 8 + 15];
                    start_sector += 0x100 * (bytes[START_SECTOR_1 + i * 8 + 14] & 0b00000011);
                    filesSide0[i].start_sector = start_sector;
                }

                // Get file/folder names side 1
                if (num_sides == 2)
                {
                    for (int i = 0; i < num_files_side1; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            filesSide1[i].file_name += Convert.ToChar(bytes[INTERLEAVE + START_SECTOR_0 + 8 + (i * 8) + j]);
                        }

                        // Get folder name for this file
                        filesSide1[i].folder_name = Convert.ToChar(bytes[INTERLEAVE + START_SECTOR_0 + 8 + (i * 8) + 7] & 0b01111111);

                        // Get locked status 
                        filesSide1[i].locked = (bytes[INTERLEAVE + START_SECTOR_0 + 8 + (i * 8) + 7] & 0b10000000) == 0b10000000 ? true : false;

                        // Get load addresses
                        int load_address = bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 8];
                        load_address += 0x100 * bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 9];
                        load_address += 0x10000 * ((bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 14] & 0b00001100) >> 2);
                        filesSide1[i].load_address = load_address;

                        // Get start addresses
                        int start_address = bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 10];
                        start_address += 0x100 * bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 11];
                        start_address += 0x10000 * ((bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 14] & 0b11000000) >> 6);
                        filesSide1[i].start_address = start_address;

                        // Get file length
                        int file_length = bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 12];
                        file_length += 0x100 * bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 13];
                        file_length += 0x10000 * ((bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 14] & 0b00110000) >> 4);
                        filesSide1[i].file_length = file_length;

                        // Get start sector
                        int start_sector = bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 15];
                        start_sector += 0x100 * (bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 14] & 0b00000011);
                        filesSide1[i].start_sector = start_sector;
                    }
                }
            } catch (Exception exception)
            {
                MessageBox.Show("Can't get file info: " + exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Set general info for disc 
        /// </summary>
        public void SetVolumeInfo()
        {
            try 
            { 
                // Copy disk title (side0)
                for (int i = 0; i < 8; i++)
                {
                    bytes[START_SECTOR_0 + i] = Convert.ToByte(' ');
                    if (volume_title_side0.Length > i) bytes[START_SECTOR_0 + i] = Convert.ToByte(volume_title_side0[i]);
                }

                for (int i = 0; i < 4; i++)
                {
                    bytes[START_SECTOR_1 + i] = Convert.ToByte(' ');
                    if (volume_title_side0.Length > 8 + i) bytes[START_SECTOR_1 + i] = Convert.ToByte(volume_title_side0[8 + i]);
                }

                // Set number of files (side0)
                bytes[START_SECTOR_1 + 5] = Convert.ToByte(num_files_side0 << 3);

                // Set boot option (side0)
                bytes[START_SECTOR_1 + 6] = Convert.ToByte((bytes[START_SECTOR_1 + 6] & 0b11001111) | (boot_side0 << 4));

                // Set number of sectors (side0)
                bytes[START_SECTOR_1 + 6] = Convert.ToByte((bytes[START_SECTOR_1 + 6] & 0b11111100) | (num_sectors_side0 >> 8));
                bytes[START_SECTOR_1 + 7] = Convert.ToByte(num_sectors_side0 & 0xFF);

                if (num_sides == 2)
                {
                    // Copy disk title (side1)
                    for (int i = 0; i < 8; i++)
                    {
                        bytes[INTERLEAVE + START_SECTOR_0 + i] = Convert.ToByte(' ');
                        if (volume_title_side1.Length > i) bytes[INTERLEAVE + START_SECTOR_0 + i] = Convert.ToByte(volume_title_side1[i]);
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        bytes[INTERLEAVE + START_SECTOR_1 + i] = Convert.ToByte(' ');
                        if (volume_title_side1.Length > 8 + i) bytes[INTERLEAVE + START_SECTOR_1 + i] = Convert.ToByte(volume_title_side1[8 + i]);
                    }

                    // Get number of files (side1)
                    bytes[INTERLEAVE + START_SECTOR_1 + 5] = Convert.ToByte(num_files_side1 << 3);

                    // Get boot option (side1)
                    bytes[INTERLEAVE + START_SECTOR_1 + 6] = Convert.ToByte((bytes[INTERLEAVE + START_SECTOR_1 + 6] & 0b11001111) | (boot_side1 << 4));

                    // Get number of sectors (side1)
                    bytes[INTERLEAVE + START_SECTOR_1 + 6] = Convert.ToByte((bytes[INTERLEAVE + START_SECTOR_1 + 6] & 0b11111100) | (num_sectors_side1 >> 8));
                    bytes[INTERLEAVE + START_SECTOR_1 + 7] = Convert.ToByte(num_sectors_side1 & 0xFF);
                }
            } catch (Exception exception)
            {
                MessageBox.Show("Can't set volume info: " + exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Set file info 
        /// </summary>
        /// <returns></returns>
        public void SetFileInfo()
        {
            try 
            {
                // Get file/folder names side 0
                for (int i = 0; i < num_files_side0; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        bytes[START_SECTOR_0 + 8 + (i * 8) + j] = Convert.ToByte(' ');
                        if (filesSide0[i].file_name.Length > j) bytes[START_SECTOR_0 + 8 + (i * 8) + j] = Convert.ToByte(filesSide0[i].file_name[j]);
                    }

                    // Set folder name for this file
                    bytes[START_SECTOR_0 + 8 + (i * 8) + 7] = Convert.ToByte(filesSide0[i].folder_name);

                    // Set locked status 
                    if (filesSide0[i].locked) bytes[START_SECTOR_0 + 8 + (i * 8) + 7] = Convert.ToByte(bytes[START_SECTOR_0 + 8 + (i * 8) + 7] | 0b10000000);
                    if (!filesSide0[i].locked) bytes[START_SECTOR_0 + 8 + (i * 8) + 7] = Convert.ToByte(bytes[START_SECTOR_0 + 8 + (i * 8) + 7] & 0b01111111);

                    // Set load addresses
                    bytes[START_SECTOR_1 + i * 8 + 8] = Convert.ToByte(filesSide0[i].load_address & 0xFF);
                    bytes[START_SECTOR_1 + i * 8 + 9] = Convert.ToByte((filesSide0[i].load_address >> 8) & 0xFF);
                    bytes[START_SECTOR_1 + i * 8 + 14] = Convert.ToByte((bytes[START_SECTOR_1 + i * 8 + 14] & 0b11110011) + ((filesSide0[i].load_address & 0xFF0000) >> 14));

                    // Set start addresses
                    bytes[START_SECTOR_1 + i * 8 + 10] = Convert.ToByte(filesSide0[i].start_address & 0xFF);
                    bytes[START_SECTOR_1 + i * 8 + 11] = Convert.ToByte((filesSide0[i].start_address >> 8) & 0xFF);
                    bytes[START_SECTOR_1 + i * 8 + 14] = Convert.ToByte((bytes[START_SECTOR_1 + i * 8 + 14] & 0b00111111) + ((filesSide0[i].start_address & 0xFF0000) >> 10));

                    // Set file length
                    bytes[START_SECTOR_1 + i * 8 + 12] = Convert.ToByte(filesSide0[i].file_length & 0xFF);
                    bytes[START_SECTOR_1 + i * 8 + 13] = Convert.ToByte((filesSide0[i].file_length >> 8) & 0xFF);
                    bytes[START_SECTOR_1 + i * 8 + 14] = Convert.ToByte((bytes[START_SECTOR_1 + i * 8 + 14] & 0b11001111) + ((filesSide0[i].file_length & 0xFF0000) >> 12));

                    // Set start sector
                    bytes[START_SECTOR_1 + i * 8 + 15] = Convert.ToByte(filesSide0[i].start_sector & 0xFF);
                    bytes[START_SECTOR_1 + i * 8 + 14] = Convert.ToByte((bytes[START_SECTOR_1 + i * 8 + 14] & 0b11111100) + ((filesSide0[i].start_sector & 0x0F00) >> 8));
                }

                // Get file/folder names side 1
                if (num_sides == 2)
                {
                    for (int i = 0; i < num_files_side1; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            bytes[INTERLEAVE + START_SECTOR_0 + 8 + (i * 8) + j] = Convert.ToByte(' ');
                            if (filesSide1[i].file_name.Length > j) bytes[INTERLEAVE + START_SECTOR_0 + 8 + (i * 8) + j] = Convert.ToByte(filesSide1[i].file_name[j]);
                        }

                        // Set folder name for this file
                        bytes[INTERLEAVE + START_SECTOR_0 + 8 + (i * 8) + 7] = Convert.ToByte(filesSide1[i].folder_name);

                        // Set locked status 
                        if (filesSide1[i].locked) bytes[INTERLEAVE + START_SECTOR_0 + 8 + (i * 8) + 7] = Convert.ToByte(bytes[INTERLEAVE + START_SECTOR_0 + 8 + (i * 8) + 7] | 0b10000000);
                        if (!filesSide1[i].locked) bytes[INTERLEAVE + START_SECTOR_0 + 8 + (i * 8) + 7] = Convert.ToByte(bytes[INTERLEAVE + START_SECTOR_0 + 8 + (i * 8) + 7] & 0b01111111);

                        // Set load addresses
                        bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 8] = Convert.ToByte(filesSide1[i].load_address & 0xFF);
                        bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 9] = Convert.ToByte((filesSide1[i].load_address >> 8) & 0xFF);
                        bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 14] = Convert.ToByte((bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 14] & 0b11110011) + ((filesSide1[i].load_address & 0xFF0000) >> 14));
                    
                        // Set start addresses
                        bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 10] = Convert.ToByte(filesSide1[i].start_address & 0xFF);
                        bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 11] = Convert.ToByte((filesSide1[i].start_address >> 8) & 0xFF);
                        bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 14] = Convert.ToByte((bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 14] & 0b00111111) + ((filesSide1[i].start_address & 0xFF0000) >> 10));

                        // Set file length
                        bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 12] = Convert.ToByte(filesSide1[i].file_length & 0xFF);
                        bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 13] = Convert.ToByte((filesSide1[i].file_length >> 8) & 0xFF);
                        bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 14] = Convert.ToByte((bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 14] & 0b11001111) + ((filesSide1[i].file_length & 0xFF0000) >> 12));

                        // Set start sector
                        bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 15] = Convert.ToByte(filesSide1[i].start_sector & 0xFF);
                        bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 14] = Convert.ToByte((bytes[INTERLEAVE + START_SECTOR_1 + i * 8 + 14] & 0b11111100) + ((filesSide1[i].start_sector & 0x0F00) >> 8));
                    }
                }
            } catch (Exception exception)
            {
                MessageBox.Show("Can't set file info: " + exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Get binary data from a file
        /// </summary>
        /// <param name="side"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public byte[] GetFileData(int side, int index)
        {
            try
            { 
                byte[] data = new byte[0];

                DiskImage.FILE file = new FILE();

                if (side == 0)
                {
                    file = filesSide0[index];
                    data = new byte[file.file_length];
                }

                if (side == 1)
                {
                    file = filesSide1[index];
                    data = new byte[file.file_length];
                }

                // Copy bytes if not interleaved 
                if ((side == 0) && (num_sides == 1))
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        data[i] = bytes[file.start_sector * SECTOR_SIZE + i];
                    }
                }

                // Copy side0 if interleaved 
                if ((side == 0) && (num_sides == 2))
                {
                    int num_bytes_copied = 0;
                    int sector = file.start_sector;
                    int bytes_index = ((sector / INTERLEAVE_SECTORS) * INTERLEAVE_SECTORS + sector) * SECTOR_SIZE;
                    int data_index = 0;

                    while (num_bytes_copied < data.Length)
                    {
                        // Copy data until interleave border
                        do
                        {
                            for (int i = 0; (i < SECTOR_SIZE) && (num_bytes_copied < data.Length); i++)
                            {
                                data[data_index++] = bytes[bytes_index++];
                                num_bytes_copied++;
                            }

                            sector++;
                        } while ((sector % INTERLEAVE_SECTORS != 0) && (num_bytes_copied < data.Length));

                        // Skip next INTERLEAVE_SECTORS blocks
                        if (num_bytes_copied < data.Length)
                        {
                            bytes_index += INTERLEAVE_SECTORS * SECTOR_SIZE;
                        }
                    }
                }

                // Copy side1 if interleaved 
                if ((side == 1) && (num_sides == 2))
                {
                    int num_bytes_copied = 0;
                    int sector = file.start_sector;
                    int bytes_index = ((sector / INTERLEAVE_SECTORS) * INTERLEAVE_SECTORS + sector + INTERLEAVE_SECTORS) * SECTOR_SIZE;
                    int data_index = 0;

                    while (num_bytes_copied < data.Length)
                    {
                        // Copy data until interleave border
                        do
                        {
                            for (int i = 0; (i < SECTOR_SIZE) && (num_bytes_copied < data.Length); i++)
                            {
                                data[data_index++] = bytes[bytes_index++];
                                num_bytes_copied++;
                            }

                            sector++;
                        } while ((sector % INTERLEAVE_SECTORS != 0) && (num_bytes_copied < data.Length));

                        // Skip next INTERLEAVE_SECTORS blocks
                        if (num_bytes_copied < data.Length)
                        {
                            bytes_index += INTERLEAVE_SECTORS * SECTOR_SIZE;
                        }
                    }
                }

                return (data);
            } catch (Exception exception)
            {
                MessageBox.Show("Can't get volume info: " + exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Delete file from image
        /// </summary>
        /// <param name="side"></param>
        /// <param name="index"></param>
        public void DeleteFile(int side, int index)
        {
            try
            { 
                FILE file;

                // Delete from side0
                if (side == 0)
                {
                    file = filesSide0[index];
                    FILE[] files = new FILE[31];

                    int j = 0;
                    for (int i = 0; i < num_files_side0; i++)
                    {
                        if (i != index)
                        {
                            files[j] = filesSide0[i];
                            j++;
                        }
                    }

                    num_files_side0--;
                    filesSide0 = files;
                }

                // Delete from side1
                if (side == 1)
                {
                    file = filesSide0[index];
                    FILE[] files = new FILE[31];

                    int j = 0;
                    for (int i = 0; i < num_files_side1; i++)
                    {
                        if (i != index)
                        {
                            files[j] = filesSide1[i];
                            j++;
                        }
                    }

                    num_files_side1--;
                    filesSide1 = files;
                }

                // Insert volume information into the data (START_SECTOR_0)
                SetVolumeInfo();

                // Insert file information into the data (START_SECTOR_0 & START_SECTOR_1)
                SetFileInfo();
            } catch (Exception exception)
            {
                MessageBox.Show("Can't delete file: " + exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Insert file into image
        /// </summary>
        /// <param name="file"></param>
        /// <param name="side"></param>
        public void InsertFile(FILE file, int side)
        {
            try
            { 
                bool found = false;

                int numSectorsNeeded = Convert.ToInt32(file.file_length / SECTOR_SIZE);
                if (file.file_length % SECTOR_SIZE != 0) numSectorsNeeded++;
                if (file.file_length == 0) numSectorsNeeded = 1;

                DataTable dtFiles = new DataTable();
                dtFiles.Columns.Add("naam", typeof(string));
                dtFiles.Columns.Add("start", typeof(int));
                dtFiles.Columns.Add("end", typeof(int));

                if (side == 0)
                {
                    // Create a list of the files according to startsector
                    for (int sector = 0; sector < num_sectors_side0; sector++)
                    {
                        for (int i = 0; i < num_files_side0; i++)
                        {
                            if (filesSide0[i].start_sector == sector)
                            {
                                int numSectors = Convert.ToInt32(filesSide0[i].file_length / SECTOR_SIZE);
                                if (filesSide0[i].file_length % SECTOR_SIZE != 0) numSectors++;
                                if (filesSide0[i].file_length == 0) numSectors = 1;

                                DataRow row = dtFiles.NewRow();
                                row["naam"] = filesSide0[i].file_name;
                                row["start"] = filesSide0[i].start_sector;
                                row["end"] = filesSide0[i].start_sector + numSectors;

                                dtFiles.Rows.Add(row);
                            }
                        }
                    }

                    if (dtFiles.Rows.Count > 0)
                    {
                        // Check if there is enough room on side0 at start of disk
                        if (Convert.ToInt32(dtFiles.Rows[0]["start"]) - 2 >= numSectorsNeeded)
                        {
                            file.start_sector = 2;
                            filesSide0[num_files_side0] = file;
                            CopyData(file.data, file.start_sector, side);

                            num_files_side0++;

                            found = true;
                        }

                        // Check if there is enough room on side0
                        for (int i = 1; (i < dtFiles.Rows.Count - 1) && !found; i++)
                        {
                            if ((Convert.ToInt32(dtFiles.Rows[i + 1]["start"]) - Convert.ToInt32(dtFiles.Rows[i]["end"])) >= numSectorsNeeded)
                            {
                                file.start_sector = Convert.ToInt32(dtFiles.Rows[i]["end"]);
                                filesSide0[num_files_side0] = file;
                                CopyData(file.data, file.start_sector, side);

                                num_files_side0++;

                                found = true;
                            }
                        }

                        if (!found && (num_sectors_side0 - Convert.ToInt32(dtFiles.Rows[dtFiles.Rows.Count - 1]["end"])) > numSectorsNeeded)
                        {
                            file.start_sector = Convert.ToInt32(dtFiles.Rows[dtFiles.Rows.Count - 1]["end"]);
                            filesSide0[num_files_side0] = file;
                            CopyData(file.data, file.start_sector, side);

                            num_files_side0++;

                            found = true;
                        }
                    } else
                    {
                        file.start_sector = 2;
                        filesSide0[num_files_side0] = file;
                        CopyData(file.data, file.start_sector, side);

                        num_files_side0++;

                        found = true;
                    }

                    // Check total free room
                    int totalSectorsSide0 = 0;
                    for (int i = 0; i < num_files_side0; i++)
                    {
                        int numSectors = Convert.ToInt32(filesSide0[i].file_length / DiskImage.SECTOR_SIZE);
                        if (filesSide0[i].file_length % DiskImage.SECTOR_SIZE != 0) numSectors++;
                        totalSectorsSide0 += numSectors;
                    }
                    int freeSide0 = num_sectors_side0 - totalSectorsSide0;

                    if (found)
                    {
                        // Insert volume information into the data (START_SECTOR_0)
                        SetVolumeInfo();

                        // Insert file information into the data (START_SECTOR_0 & START_SECTOR_1)
                        SetFileInfo();
                    } else
                    {
                        string message = "Not enough space on disk.\r\n";
                        if (freeSide0 >= numSectorsNeeded) message += "Try 'Organize' to remove gaps in between files.\r\n";
                        MessageBox.Show(message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                if (side == 1)
                {
                    // Create a list of the files according to startsector
                    for (int sector = 0; sector < num_sectors_side1; sector++)
                    {
                        for (int i = 0; i < num_files_side1; i++)
                        {
                            if (filesSide1[i].start_sector == sector)
                            {
                                int numSectors = Convert.ToInt32(filesSide1[i].file_length / SECTOR_SIZE);
                                if (filesSide1[i].file_length % SECTOR_SIZE != 0) numSectors++;
                                if (filesSide1[i].file_length == 0) numSectors = 1;

                                DataRow row = dtFiles.NewRow();
                                row["naam"] = filesSide1[i].file_name;
                                row["start"] = filesSide1[i].start_sector;
                                row["end"] = filesSide1[i].start_sector + numSectors;

                                dtFiles.Rows.Add(row);
                            }
                        }
                    }

                    if (dtFiles.Rows.Count > 0)
                    {
                        // Check if there is enough room on side0 at start of disk
                        if (Convert.ToInt32(dtFiles.Rows[0]["start"]) - 2 >= numSectorsNeeded)
                        {
                            file.start_sector = 2;
                            filesSide1[num_files_side1] = file;
                            CopyData(file.data, file.start_sector, side);

                            num_files_side1++;

                            found = true;
                        }

                        // Check if there is enough room on side0
                        for (int i = 1; (i < dtFiles.Rows.Count - 1) && !found; i++)
                        {
                            if ((Convert.ToInt32(dtFiles.Rows[i + 1]["start"]) - Convert.ToInt32(dtFiles.Rows[i]["end"])) >= numSectorsNeeded)
                            {
                                file.start_sector = Convert.ToInt32(dtFiles.Rows[i]["end"]);
                                filesSide1[num_files_side1] = file;
                                CopyData(file.data, file.start_sector, side);

                                num_files_side1++;

                                found = true;
                            }
                        }

                        if (!found && (num_sectors_side1 - Convert.ToInt32(dtFiles.Rows[dtFiles.Rows.Count - 1]["end"])) > numSectorsNeeded)
                        {
                            file.start_sector = Convert.ToInt32(dtFiles.Rows[dtFiles.Rows.Count - 1]["end"]);
                            filesSide1[num_files_side1] = file;
                            CopyData(file.data, file.start_sector, side);

                            num_files_side1++;

                            found = true;
                        }
                    } else
                    {
                        // Just add to start
                        file.start_sector = 2;
                        filesSide1[num_files_side1] = file;
                        CopyData(file.data, file.start_sector, side);

                        num_files_side1++;

                        found = true;
                    }

                    // Check total free room
                    int totalSectorsSide1 = 0;
                    for (int i = 0; i < num_files_side1; i++)
                    {
                        int numSectors = Convert.ToInt32(filesSide1[i].file_length / DiskImage.SECTOR_SIZE);
                        if (filesSide1[i].file_length % DiskImage.SECTOR_SIZE != 0) numSectors++;
                        totalSectorsSide1 += numSectors;
                    }
                    int freeSide1 = num_sectors_side1 - totalSectorsSide1;
                
                    if (found)
                    {
                        // Insert volume information into the data (START_SECTOR_0)
                        SetVolumeInfo();

                        // Insert file information into the data (START_SECTOR_0 & START_SECTOR_1)
                        SetFileInfo();
                    } else
                    {
                        string message = "Not enough space on disk.\r\n";
                        if (freeSide1 >= numSectorsNeeded) message += "Try 'Organize' to remove gaps in between files.\r\n";
                        MessageBox.Show(message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            } catch (Exception exception)
            {
                MessageBox.Show("Can't insert file: " + exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Copy data to disk starting at a specific sector 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="sector"></param>
        /// <param name="side"></param>
        private void CopyData(byte[] data, int sector, int side)
        {
            try
            { 
                int num_bytes_copied = 0;
                int data_index = 0;
                int bytes_index = 0;
                if (side == 0) bytes_index = ((sector / INTERLEAVE_SECTORS) * INTERLEAVE_SECTORS + sector                     ) * SECTOR_SIZE;
                if (side == 1) bytes_index = ((sector / INTERLEAVE_SECTORS) * INTERLEAVE_SECTORS + sector + INTERLEAVE_SECTORS) * SECTOR_SIZE;

                // Check if bytes data is full disk size or compacted
                if (num_sides == 1)
                {
                    if (bytes.Length < num_sectors_side0 * SECTOR_SIZE)
                    {
                        // Resize to full length
                        Array.Resize(ref bytes, num_sectors_side0 * SECTOR_SIZE);
                    }
                }

                if (num_sides == 2)
                {
                    if (bytes.Length < (num_sectors_side0 + num_sectors_side1) * SECTOR_SIZE)
                    {
                        // Resize to full length
                        Array.Resize(ref bytes, (num_sectors_side0 + num_sectors_side1) * SECTOR_SIZE);
                    }
                }

                while (num_bytes_copied < data.Length)
                {
                    // Copy data until interleave border
                    do
                    {
                        for (int i = 0; (i < SECTOR_SIZE) && (num_bytes_copied < data.Length); i++)
                        {
                            bytes[bytes_index++] = data[data_index++];
                            num_bytes_copied++;
                        }

                        sector++;
                    } while ((sector % INTERLEAVE_SECTORS != 0) && (num_bytes_copied < data.Length));

                    // Skip next INTERLEAVE_SECTORS blocks
                    if (num_bytes_copied < data.Length)
                    {
                        bytes_index += INTERLEAVE_SECTORS * SECTOR_SIZE;
                        sector += INTERLEAVE_SECTORS;
                    }
                }
            } catch (Exception exception)
            {
                MessageBox.Show("Can't copy data: " + exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Do some checks to see if the image file is not corrupt
        /// </summary>
        /// <returns></returns>
        private bool CheckImage()
        {
            // Check volume name
            if (Encoding.UTF8.GetByteCount(volume_title_side0) != volume_title_side0.Length)
            {
                return (false);
            }

            if (Encoding.UTF8.GetByteCount(volume_title_side1) != volume_title_side1.Length)
            {
                return (false);
            }

            // Check file names
            for (int i = 0; i < num_files_side0; i++)
            {
                if (Encoding.UTF8.GetByteCount(filesSide0[i].file_name) != filesSide0[i].file_name.Length)
                {
                    return (false);
                }
            }

            for (int i = 0; i < num_files_side1; i++)
            {
                if (Encoding.UTF8.GetByteCount(filesSide1[i].file_name) != filesSide1[i].file_name.Length)
                {
                    return (false);
                }
            }

            // Check start sector
            for (int i = 0; i < num_files_side0; i++)
            {
                if ((filesSide0[i].start_sector < 0) || (filesSide0[i].start_sector > 800))
                {
                    return (false);
                }
            }

            for (int i = 0; i < num_files_side1; i++)
            {
                if ((filesSide1[i].start_sector < 0) || (filesSide1[i].start_sector > 800))
                {
                    return (false);
                }
            }

            // Check load/start adresses
            for (int i = 0; i < num_files_side0; i++)
            {
                if ((filesSide0[i].start_address < 0) || (filesSide0[i].start_address > 0x03FFFF))
                {
                    return (false);
                }

                if ((filesSide0[i].load_address < 0) || (filesSide0[i].load_address > 0x03FFFF))
                {
                    return (false);
                }
            }

            for (int i = 0; i < num_files_side1; i++)
            {
                if ((filesSide1[i].start_address < 0) || (filesSide1[i].start_address > 0x03FFFF))
                {
                    return (false);
                }

                if ((filesSide1[i].load_address < 0) || (filesSide1[i].load_address > 0x03FFFF))
                {
                    return (false);
                }
            }

            // Check file length
            for (int i = 0; i < num_files_side0; i++)
            {
                if ((filesSide0[i].file_length < 0) || (filesSide0[i].file_length > 0x03FFFF))
                {
                    return (false);
                }
            }

            for (int i = 0; i < num_files_side1; i++)
            {
                if ((filesSide1[i].file_length < 0) || (filesSide1[i].file_length > 0x03FFFF))
                {
                    return (false);
                }
            }

            return (true);
        }

        #endregion
    }
}
