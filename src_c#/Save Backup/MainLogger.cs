using System;
using System.IO;

namespace RepoSaveBackup
{
    public static class MainLogger
    {
        private static string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        private static string logFilePath;

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        static MainLogger()
        {
            Directory.CreateDirectory(logDirectory);

            string timestamp = DateTime.Now.ToString("dd-mm-yyyy HH_mm");
            logFilePath = Path.Combine(logDirectory, $"{timestamp}.txt");

            Write("R.E.P.O. Save Backup loaded");
        }

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        public static void Write(string message)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            File.AppendAllText(logFilePath, $"{time} - {message}{Environment.NewLine}");
        }

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        public static void WriteErrorAndExit(string message)
        {
            Write(message);
            System.Windows.Forms.MessageBox.Show(message, "Critical Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            Environment.Exit(1);
        }
    }
}
