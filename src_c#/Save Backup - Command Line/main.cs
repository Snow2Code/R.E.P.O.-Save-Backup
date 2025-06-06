//========= Copyright Valve Corporation, All rights reserved. ============//
//
// Purpose: vcd_sound_check.cpp : Defines the entry point for the console application.
//
//===========================================================================//

using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// Snowy
using SnowLib;
using static System.Net.Mime.MediaTypeNames;

class REPOSaveCommandLine
{
    static bool alreadyRan = false;
    static string input = "";
    static string input_split = "";

    public static string SaveDirectory => Snowy.SaveDirectory;
    public static string BackupDirectory => Snowy.BackupDirectory;
    public static string versionUrl => Snowy.versionUrl;
    public static string latestReleaseUrl => Snowy.latestReleaseUrl;

    //-----------------------------------------------------------------------------
    // Purpose: 
    //-----------------------------------------------------------------------------
    static async Task Main(string[] args)
    {
        CheckSnowLib();
        Output("Snow2Code R.E.P.O Save Backup -- Command Line\n");
        //await CheckVersion();

        while (true)
        {
            if (alreadyRan == false)
            {
                alreadyRan = true;
                Commands.ShowHelp();
            }

            Console.Write("> ");
            input = Console.ReadLine();
            input_split = input.Split(' ')[0];

            switch (input_split)
            {
                case "clear" or "cls":
                    Commands.Clear();
                    break;
                case "help":
                    Commands.ShowHelp();
                    break;
                case "list_saves":
                    Console.Write(input.Split(' '));
                    Commands.ListSaves(SaveDirectory);
                    break;
                case "open_save_dir":
                    Commands.OpenSaveDir(input);
                    break;
                default:
                    /* Reason for this check
                     * 
                     * The windows terminal doesn't output anything
                     * if the user input is nothing or a space
                     * 
                    */
                    if (input == "" || Regex.Replace(input, @"\s+", "") == "")
                    {
                        // Nothing
                    } else {
                        //StringBuilder sb = new StringBuilder();

                        //foreach (char c in input)
                        //{
                        //    if (c <= 127) // ASCII range
                        //    {
                        //        sb.Append("");
                        //    }
                        //}

                        //input = sb.ToString();


                        if (input == "")
                        {
                        } else {
                            Output($"'{input}' is not recognized as an internal or external command.\nUse help if needed");
                        }
                        //"Unknown input.\nNeed help? use help to see how to use this."
                    }
                    break;
            }
        }
    }


    //-----------------------------------------------------------------------------
    // Purpose: 
    //-----------------------------------------------------------------------------
    static void Output(string message)
    {
        Console.WriteLine(message);
    }

    //-----------------------------------------------------------------------------
    // Purpose: 
    //-----------------------------------------------------------------------------
    static void CheckSnowLib()
    {
        string dllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SnowLib.dll");
        
        if (!File.Exists(dllPath))
        {
            Logger.WriteError("Cannot find SnowLib.dll.");
        }
        Logger.Write("SnowLib.dll found, continuing.");
    }
}
