
    //-----------------------------------------------------------------------------
    // Purpose: 
    //-----------------------------------------------------------------------------
    public class SaveManager
    {
        private string SaveDirectory => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"..\LocalLow\semiwork\Repo\saves");
        private string BackupDirectory => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "R.E.P.O Saves (Backup)");

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        public void EnsureBackupFolderExists()
        {
            if (!Directory.Exists(BackupDirectory))
            {
                Directory.CreateDirectory(BackupDirectory);
            }
        }

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        public List<SaveEntry> GetSaveList()
        {
            List<SaveEntry> saves = new List<SaveEntry>();

            if (!Directory.Exists(SaveDirectory))
            {
                return saves;
            }

            foreach (string path in Directory.GetDirectories(SaveDirectory))
            {
                string folderName = Path.GetFileName(path);
                string timestamp = folderName.Replace("REPO_SAVE_", "");
                string formatted = "Invalid Format";

                if (DateTime.TryParseExact(timestamp, "yyyy_MM_dd_HH_mm_ss",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                {
                    formatted = dt.ToString("f");
                }

                saves.Add(new SaveEntry
                {
                    DateTimeFormatted = formatted,
                    FolderName = folderName
                });
            }

            return saves;
        }

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        public void BackupSaves()
        {
            CopyDirectory(SaveDirectory, BackupDirectory);
        }

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        public void RestoreSaves()
        {
            CopyDirectory(BackupDirectory, SaveDirectory);
        }

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        public void OpenSaveFolder()
        {
            Process.Start("explorer.exe", SaveDirectory);
        }

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        public void OpenBackupFolder()
        {
            Process.Start("explorer.exe", BackupDirectory);
        }

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        private void CopyDirectory(string sourceDir, string targetDir)
        {
            foreach (string dirPath in Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourceDir, targetDir));
            }

            foreach (string newPath in Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourceDir, targetDir), true);
            }
        }
    }
