using System;
using System.IO;
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

namespace SnowLib
{
    public static class Logger
    {
        private static string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        private static string logFilePath;

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        static Logger()
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
        public static void WriteError(string message)
        {
            Write($"Error, info - {message}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(1);
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
