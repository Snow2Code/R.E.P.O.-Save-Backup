using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Management;
using System.Runtime.InteropServices;

using static SnowLib.Logger;

namespace SnowLib
{
    //-----------------------------------------------------------------------------
    // Purpose: 
    //-----------------------------------------------------------------------------
    public class SaveEntry
    {
        public string DateTimeFormatted { get; set; }
        public string FolderName { get; set; }
    }
    

    //-----------------------------------------------------------------------------
    // Purpose: 
    //-----------------------------------------------------------------------------
    public class Snowy
    {
        public static string SaveDirectory => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"..\LocalLow\semiwork\Repo\saves");
        public static string BackupDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "R.E.P.O Saves (Backup)");

        public static string versionUrl = "https://raw.githubusercontent.com/Snow2Code/R.E.P.O.-Save-Backup/refs/heads/main/version.txt";
        public static string latestReleaseUrl = "https://github.com/Snow2Code/R.E.P.O.-Save-Backup/releases/latest";

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        public static void Output(string message)
        {
            Debug.WriteLine(message);
        }

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        public static void OutputCommandLine(string message)
        {
            Console.WriteLine(message);
        }

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        public static void EnsureBackupDirectory()
        {
            try
            {
                if (!Directory.Exists(BackupDirectory))
                {
                    Logger.Write("Creating backup directory.");
                    
                    Directory.CreateDirectory(BackupDirectory);
                }
            } catch (Exception ex) {
                Logger.Write($"Failed to create backup directory: {ex.Message}");
            }
        }

        //-----------------------------------------------------------------------------
        // Purpose: Open a directory
        //-----------------------------------------------------------------------------
        public static void OpenDirectory(string what)
        {
            if (what == "repo saves")
            {
                Process.Start("explorer.exe", SaveDirectory);
            } else if (what == "backup saves") {
                Process.Start("explorer.exe", BackupDirectory);
            }
        }
    }
}
