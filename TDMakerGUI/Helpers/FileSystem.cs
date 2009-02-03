using System.Diagnostics;
using System.IO;
using TDMaker.Properties;
using TorrentDescriptionMaker;

namespace TDMaker
{
    public static class FileSystem
    {
        public static void OpenDirTorrents()
        {
            if (Directory.Exists(Settings.Default.TorrentsCustomDir))
            {
                Process.Start(Settings.Default.TorrentsCustomDir);
            }
        }

        public static void OpenDirScreenshots()
        {
            if (Directory.Exists(TDMakerLib.Program.GetScreenShotsDir()))
            {
                Process.Start(TDMakerLib.Program.GetScreenShotsDir());
            }
        }

        public static void OpenDirTemplates()
        {
            if (Directory.Exists(Settings.Default.TemplatesDir))
            {
                Process.Start(Settings.Default.TemplatesDir);
            }
        }

        internal static void OpenDirLogs()
        {
            if (Directory.Exists(Program.LogsDir))
            {
                Process.Start(Program.LogsDir);
            }
        }

        internal static void OpenDirSettings()
        {
            if (Directory.Exists(Settings.Default.SettingsDir))
            {
                Process.Start(Settings.Default.SettingsDir);
            }
        }

        internal static void OpenFileDebug()
        {
            if (File.Exists(Program.DebugLogFilePath))
            {
                Process.Start(Program.DebugLogFilePath);
            }
        }

    }
}
