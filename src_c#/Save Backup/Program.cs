using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RepoSaveBackup;

// Snowy
using SnowLib;

namespace Main
{
    internal static class Program
    {
        /*
        Directorys.

        Repo saves - C:\Users\Snowy\AppData\locallow\semiwork\Repo\saves
        Backup saves - C:\Users\Snowy\Documents\R.E.P.O Saves (Backup)

        */

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CheckSnowLib();

            Snowy.EnsureBackupDirectory();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        //-----------------------------------------------------------------------------
        // Purpose: 
        //-----------------------------------------------------------------------------
        static void CheckSnowLib()
        {
            string dllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SnowLib.dll");

            if (!File.Exists(dllPath))
            {
                Logger.WriteErrorAndExit("Cannot find SnowLib.dll, closing.");
            }

            Logger.Write("SnowLib.dll found, continuing.");
        }
    }
}
