using System;
using System.Net.Http;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;
using System.Security.Principal;

// Snowy
using SnowLib;
using RepoSaveBackup;

namespace Main
{
    public partial class Main : Form
    {
        public static string SaveDirectory => Snowy.SaveDirectory;
        public static string BackupDirectory => Snowy.BackupDirectory;
        public static string versionUrl => Snowy.versionUrl;
        public static string latestReleaseUrl => Snowy.latestReleaseUrl;

        // Do this but better. SnowLib is a dll thing.
        //var SnowLib = new SnowLib.SnowLib();

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        public Main()
        {


            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            // this.MinimizeBox = false;

            InitializeComponent();


            dataGridViewRepoSaves.Columns.Add("SaveDate", "Date and Time");
            dataGridViewRepoSaves.Columns.Add("FolderName", "Folder Name");
            dataGridViewBackups.Columns.Add("SaveDate", "Date and Time");
            dataGridViewBackups.Columns.Add("FolderName", "Folder Name");

            dataGridViewRepoSaves.ReadOnly = true;
            dataGridViewRepoSaves.AllowUserToAddRows = false;
            dataGridViewRepoSaves.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadSaveList();
            ProgramLoaded();
        }


        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        private void CopyDirectory(string source, string target)
        {
            // foreach (string dirPath in Directory.GetDirectories(source, "*", SearchOption.AllDirectories))
            // {
            //     Directory.CreateDirectory(dirPath.Replace(source, target));
            // }

            // foreach (string filePath in Directory.GetFiles(source, "*.*", SearchOption.AllDirectories))
            // {
            //     string destFile = filePath.Replace(source, target);
            //     File.Copy(filePath, destFile, true);
            // }
            foreach (string dirPath in Directory.GetDirectories(source, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(source, target));
            }

            foreach (string filePath in Directory.GetFiles(source, "*.*", SearchOption.AllDirectories))
            {
                string destFile = filePath.Replace(source, target);
                Directory.CreateDirectory(Path.GetDirectoryName(destFile)); // ensure the subdir exists
                File.Copy(filePath, destFile, true);
            }


            // Reload the saves
            LoadSaveList();
        }

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        private async void ProgramLoaded()
        {
            Version localVersion = Assembly.GetExecutingAssembly().GetName().Version;
            Version remoteVersion = await GetRemoteVersion();

            if (remoteVersion == null)
            {
                Console.WriteLine("Meow! Cannot get latest github version!");
                MainLogger.Write("Cannot get latest github version.");
                //MessageBox.Show("Could not check for updates. You're on your own.", "Update Check Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (remoteVersion > localVersion)
            {
                Console.WriteLine("Meow! Version out of date!");
                MainLogger.Write("REPO Save Backup version out of date.");

                DialogResult result = MessageBox.Show(
                    $"A new version is available.\nYou're on {localVersion}, and the latest is {remoteVersion}.\n\nIt is recommended to use the latest version. But not a requirement.",
                    "Update Available",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

                if (result == DialogResult.Yes)
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = latestReleaseUrl,
                        UseShellExecute = true
                    });
                    
                    // Excuse me, we don't want to forcefully close the app! What if the user is too lazy to download the latest version??
                    //Application.Exit();
                } else {
                    // Continue with current version
                }
            } else {
                // Everything's up to date
            }

            // Silly pre-release version change I guess.
            if (localVersion > remoteVersion)
            {
                MessageBox.Show(
                    $"You goober {Environment.UserName}. You updated the applcations version but not the github. Better do that when you are releaseing this version",
                    "You goober!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }

            
            // V1.0.1.2  -  Add popup/messagebox on start if user wants to up back their saves.
            DialogResult backupsaveResult = MessageBox.Show(
                $"Backup saves now?",
                "Backup Saves",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );

            if (backupsaveResult == DialogResult.Yes)
            {
                try
                {
                    //Backup to save, not save to backup. grrrr
                    CopyDirectory(BackupDirectory, SaveDirectory);
                    
                    MessageBox.Show("Backup created");
                } catch (Exception ex) {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        private async Task<Version> GetRemoteVersion()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string versionString = await client.GetStringAsync(versionUrl);
                    return new Version(versionString.Trim());
                } catch {
                    return null;
                }
            }
        }
        
        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        private void LoadSaveList()
        {
            dataGridViewRepoSaves.Rows.Clear();
            dataGridViewBackups.Rows.Clear();

            MainLogger.Write("Loading saves");

            if (!Directory.Exists(SaveDirectory))
                return;

            var dirs_repo = Directory.GetDirectories(SaveDirectory).Select(Path.GetFileName).OrderByDescending(name => name);
            var dirs_backup = Directory.GetDirectories(BackupDirectory).Select(Path.GetFileName).OrderByDescending(name => name);

            // R.E.P.O. Saves Grid View
            foreach (var dirName in dirs_repo)
            {
                // Try to extract the date/time
                string dateTimeFormatted = "Invalid Format";

                if (dirName.StartsWith("REPO_SAVE_"))
                {
                    string timestampPart = dirName.Substring("REPO_SAVE_".Length);

                    if (DateTime.TryParseExact(timestampPart, "yyyy_MM_dd_HH_mm_ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime parsedTime))
                    {
                        // Nice readable format like "May 19, 2025 11:03:06 PM"
                        dateTimeFormatted = parsedTime.ToString("f");
                    }
                }

                dataGridViewRepoSaves.Rows.Add(dateTimeFormatted, dirName);
            }

            // Backup Saves
            foreach (var dirName in dirs_backup)
            {
                // Try to extract the date/time
                string dateTimeFormatted = "Invalid Format";

                if (dirName.StartsWith("REPO_SAVE_"))
                {
                    string timestampPart = dirName.Substring("REPO_SAVE_".Length);

                    if (DateTime.TryParseExact(timestampPart, "yyyy_MM_dd_HH_mm_ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime parsedTime))
                    {
                        // Nice readable format like "May 19, 2025 11:03:06 PM"
                        dateTimeFormatted = parsedTime.ToString("f");
                    }
                }

                dataGridViewBackups.Rows.Add(dateTimeFormatted, dirName);
            }
        }


        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        private void buttonBackup_Click(object sender, EventArgs e)
        {
            var confirm1 = MessageBox.Show("Are you SURE you want to restore the backup?\nThis cannot be undone.", "Restore Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm1 != DialogResult.Yes) return;

            var confirm2 = MessageBox.Show("Seriously, this will overwrite all existing saves.\nNo way to undo it. Proceed?", "Final Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm2 != DialogResult.Yes) return;


            // Restore: Copy from backup to save folder
            try
            {
                CopyDirectory(BackupDirectory, SaveDirectory);
                MessageBox.Show("Restore complete. Thank Snowy later.");
                MainLogger.Write("Restore Backup Saves (override repo saves) successful.");
                LoadSaveList(); // Refresh
            } catch (Exception ex) {
                MainLogger.Write("Restore Backup Saves (override repo saves) failed, error message: " + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        private void buttonOpenSaves_Click(object sender, EventArgs e)
        {
            Snowy.OpenDirectory("repo saves");
        }

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        private void buttonOpenBackup_Click(object sender, EventArgs e)
        {
            Snowy.OpenDirectory("backup saves");
        }

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        private void buttonBackupNow_Click(object sender, EventArgs e)
        {
            try
            {
                CopyDirectory(SaveDirectory, BackupDirectory);
                MessageBox.Show("Backup created");
            } catch (Exception ex) {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        private void buttonBackupSelected_Click(object sender, EventArgs e)
        {
            if (dataGridViewRepoSaves.SelectedRows.Count == 0)
            {
                MessageBox.Show("No save selected to backup.");
                return;
            }

            var folderName = dataGridViewRepoSaves.SelectedRows[0].Cells["FolderName"].Value.ToString();

            var sourcePath = Path.Combine(SaveDirectory, folderName);
            var targetPath = Path.Combine(BackupDirectory, folderName);

            try
            {
                CopyDirectory(sourcePath, targetPath);
                MessageBox.Show("Selected save backed up.");
            } catch (Exception ex) {
                MessageBox.Show("Error: " + ex.Message);
            }

            LoadSaveList(); // Refresh
        }

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        private void buttonRestoreSelected_Click(object sender, EventArgs e)
        {
            if (dataGridViewBackups.SelectedRows.Count == 0)
            {
                MessageBox.Show("No backup selected to restore.");
                return;
            }

            var folderName = dataGridViewBackups.SelectedRows[0].Cells["FolderName"].Value.ToString();

            var sourcePath = Path.Combine(BackupDirectory, folderName);
            var targetPath = Path.Combine(SaveDirectory, folderName);

            var confirm1 = MessageBox.Show($"Are you sure you want to restore backup:\n{folderName}?\nIt will overwrite any save with the same name.", "Restore Selected Save", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm1 != DialogResult.Yes) return;

            try
            {
                CopyDirectory(sourcePath, targetPath);
                MessageBox.Show("Selected save restored.");
            } catch (Exception ex) {
                MessageBox.Show("Error: " + ex.Message);
            }

            LoadSaveList(); // Refresh
        }

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        private void repoSaves_Label_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", SaveDirectory);
        }

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        private void backupSaves_Label_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", BackupDirectory);
        }
    }
}
