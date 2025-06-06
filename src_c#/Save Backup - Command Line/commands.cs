using System;

// Snowy
using SnowLib;

static class Commands
{
    public static bool ClearedOutput { get; set; } = false;

    public static void ShowHelp()
    {
        if (ClearedOutput == true)
        {
            Snowy.OutputCommandLine("Snow2Code R.E.P.O Save Backup -- Command Line\n");
            ClearedOutput = false;
        }

        Snowy.OutputCommandLine("Usage:");
        Snowy.OutputCommandLine("help               - Show this help");
        Snowy.OutputCommandLine("clear | cls        - Clear console");
        Snowy.OutputCommandLine("list_saves         - List all repo or backup saves");
        Snowy.OutputCommandLine("backup             - Backup entire save directory");
        Snowy.OutputCommandLine("restore            - Restore entire backup directory");
        Snowy.OutputCommandLine("backup_selected X  - Backup specific save folder named X");
        Snowy.OutputCommandLine("restore_selected X - Restore specific backup folder named X");
        Snowy.OutputCommandLine("open_save_dir      - Open directories | Usage repo or backup");
        Snowy.OutputCommandLine("exit | quit        - Exit program\n");
    }

    public static void OpenSaveDir(string input)
    {
        string[] openParts = input.Split(' ');
        if (openParts.Length > 1 && openParts[1] != null)
        {
            switch (input.Split(' ')[1])
            {
                case "repo":
                    Snowy.OutputCommandLine("Opening R.E.P.O saves directory");
                    Snowy.OpenDirectory("repo saves");
                    break;
                case "backup":
                    Snowy.OutputCommandLine("Opening backup saves directory");
                    Snowy.OpenDirectory("backup saves");
                    break;
                default:
                    Snowy.OutputCommandLine("Unknown argument for open. Arguments for open is 'repo' and 'backup'");
                    break;
            }
        } else {
            Snowy.OutputCommandLine("Need help for open_save_dir? The usage is 'open_save_dir repo' or 'open_save_dir backup'. Those are the only arguments");
        }
    }

    public static void Clear()
    {
        Console.Clear();
        ClearedOutput = true;
    }

    public static void ListSaves(string directory)
    {
        if (directory == "repo" || directory == "")
        {
            if (!Directory.Exists(directory))
            {
                Snowy.OutputCommandLine($"Directory not found: {directory}");
                return;
            }

            var dirs = Directory.GetDirectories(directory).Select(Path.GetFileName).OrderByDescending(n => n);

            if (!dirs.Any())
            {
                Snowy.OutputCommandLine("No saves found.");
                return;
            }

            Snowy.OutputCommandLine($"Listing repo saves:");

            foreach (var dirName in dirs)
            {
                string dateTimeFormatted = "Invalid Format";

                if (dirName.StartsWith("REPO_SAVE_"))
                {
                    string timestampPart = dirName.Substring("REPO_SAVE_".Length);

                    if (DateTime.TryParseExact(timestampPart, "yyyy_MM_dd_HH_mm_ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime parsedTime))
                    {
                        dateTimeFormatted = parsedTime.ToString("f");
                    }
                }

                Snowy.OutputCommandLine($"{dirName}  ({dateTimeFormatted})");
            }
        } else if (directory == "backup") {
            if (!Directory.Exists(directory))
            {
                Snowy.OutputCommandLine($"Directory not found: {directory}");
                return;
            }

            var dirs = Directory.GetDirectories(directory).Select(Path.GetFileName).OrderByDescending(n => n);

            if (!dirs.Any())
            {
                Snowy.OutputCommandLine("No saves found.");
                return;
            }

            Snowy.OutputCommandLine($"Listing backup saves:");

            foreach (var dirName in dirs)
            {
                string dateTimeFormatted = "Invalid Format";

                if (dirName.StartsWith("REPO_SAVE_"))
                {
                    string timestampPart = dirName.Substring("REPO_SAVE_".Length);

                    if (DateTime.TryParseExact(timestampPart, "yyyy_MM_dd_HH_mm_ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime parsedTime))
                    {
                        dateTimeFormatted = parsedTime.ToString("f");
                    }
                }

                Snowy.OutputCommandLine($"{dirName}  ({dateTimeFormatted})");
            }
        }
    }
}
