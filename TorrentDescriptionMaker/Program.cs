﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using TDMaker;
using TDMaker.Properties;
using System.Text;
using System.Configuration;

namespace TorrentDescriptionMaker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

        /// <summary>
        /// Application Version
        /// </summary>
        public static McoreSystem.AppInfo gAppInfo = new McoreSystem.AppInfo(Application.ProductName, Application.ProductVersion, McoreSystem.AppInfo.SoftwareCycle.FINAL);

        public const string APP_NAME = "TDMaker";
        public static TaskType CurrentTask { get; set; }
        private readonly static string ScreenshotsDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "MTN");
        private readonly static string ScreenshotsTempDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), APP_NAME);
        public static string LogsDir { get; set; }
        public static string DebugLogFilePath { get; set; }
        private static StringBuilder mSbDebug = new StringBuilder();

        public static string GetScreenShotsDir()
        {
            return (Settings.Default.KeepScreenshot ? Program.ScreenshotsDir : Program.ScreenshotsTempDir);
        }

        public static void ClearScreenshots()
        {
            if (!Settings.Default.KeepScreenshot)
            {
                // delete if option set to temporary location 
                string[] files = Directory.GetFiles(Program.ScreenshotsTempDir, "*.*", SearchOption.AllDirectories);
                foreach (string screenshot in files)
                {
                    try
                    {
                        File.Delete(screenshot);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }
        }

        public static void WriteTemplates(bool rewrite)
        {
            string[] tNames = new string[] { "Default", "MTN", "Minimal" };
            foreach (string name in tNames)
            {
                // Copy Default Templates to Templates folder
                string dPrefix = string.Format("Templates.{0}.", name);
                string tDir = Path.Combine(Settings.Default.TemplatesDir, name);
                if (!Directory.Exists(tDir))
                {
                    Directory.CreateDirectory(tDir);
                }
                string[] tFiles = new string[] { "Disc.txt", "File.txt", "DiscAudioInfo.txt", "FileAudioInfo.txt", "GeneralInfo.txt", "FileVideoInfo.txt", "DiscVideoInfo.txt" };

                foreach (string fn in tFiles)
                {
                    string dFile = Path.Combine(tDir, fn);
                    bool write = !File.Exists(dFile) || (File.Exists(dFile) && rewrite);
                    if (write)
                    {
                        using (StreamWriter sw = new StreamWriter(dFile))
                        {
                            sw.WriteLine(Program.GetText(dPrefix + fn));
                        }
                    }
                }

            }

        }

        public static string GetConfigFilePath()
        {

            System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            return config.FilePath;

        }

        public static string getFileSizeString(double size)
        {

            return string.Format("{0} MiB", (size / 1024.0 / 1024.0).ToString("0.00"));

        }

        /// <summary>
        /// Get DuratingString in HH:mm:ss
        /// </summary>
        /// <param name="dura">Duration in Milliseconds</param>
        /// <returns>DuratingString in HH:mm:ss</returns>
        public static string getDurationString(double dura)
        {

            double duraSec = dura / 1000.0;

            long hours = (long)duraSec / 3600;
            long secLeft = (long)duraSec - hours * 3600;
            long mins = secLeft / 60;
            long sec = secLeft - mins * 60;

            string duraString = string.Format("{0}:{1}:{2}",
                hours.ToString("00"),
                mins.ToString("00"),
                sec.ToString("00"));

            return duraString;

        }

        public static string getMediaName(string p)
        {

            string name = "";

            if (File.Exists(p))
            {
                string ext = Path.GetExtension(p).ToLower();
                if (ext == ".vob" && Path.GetFileName(Path.GetDirectoryName(p)) == "VIDEO_TS")
                {
                    name = Path.GetFileName(Path.GetDirectoryName(Path.GetDirectoryName(p)));
                }
                else
                {
                    name = Path.GetFileNameWithoutExtension(p);
                }
            }
            else if (Directory.Exists(p))
            {
                name = Path.GetFileName(p);
                if (name.ToUpper().Equals("VIDEO_TS"))
                    name = Path.GetFileName(Path.GetDirectoryName(p));
            }

            return name;

        }

        public static string GetText(string name)
        {
            string text = "";

            try
            {
                System.Reflection.Assembly oAsm = System.Reflection.Assembly.GetExecutingAssembly();
                Stream oStrm = oAsm.GetManifestResourceStream(oAsm.GetName().Name + "." + name);

                for (int i = 0; i < oAsm.GetManifestResourceNames().Length; i++)
                {
                    Console.WriteLine(oAsm.GetManifestResourceNames()[i].ToString());
                }
                StreamReader oRdr = new StreamReader(oStrm);
                text = oRdr.ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return text;
        }

        public static void WriteDebugLog()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(DebugLogFilePath, true))
                {
                    sw.WriteLine(mSbDebug.ToString());
                }
                mSbDebug = new System.Text.StringBuilder();
                // clear
                GC.Collect();
            }
            catch (Exception ex)
            {
                // msAppendWarnings(ex.Message);
            }
        }


        public static void AppendDebug(string msg)
        {

            if (mSbDebug.Length < mSbDebug.MaxCapacity)
            {
                mSbDebug.AppendLine(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + " " + msg);
            }

            if (mSbDebug.Length > 100000)
            {
                WriteDebugLog();
            }

        }

    }

    public enum TakeScreenshotsType
    {
        NONE,
        TAKE_ALL_SCREENSHOTS,
        TAKE_ONE_SCREENSHOT
    }

    public enum ProgressType
    {
        INCREMENT_PROGRESS_WITH_MSG,
        REPORT_MEDIAINFO_SUMMARY,
        UPDATE_PROGRESSBAR_MAX,
        UPDATE_SCREENSHOTS_LIST,
        UPDATE_STATUSBAR_DEBUG
    }

    public enum TaskType
    {
        ANALYZE_MEDIA,
        CREATE_TORRENT
    }

    public enum ScreenshotDestType
    {
        IMAGESHACK,
        TINYPIC,
        IMAGESHACK_LEGACY_METHOD
    }

    public class TorrentPacket
    {

        public TDMaker.Tracker Tracker { get; private set; }
        public string MediaLocation { get; private set; }
        public string TorrentFolder { get; private set; }

        public TorrentPacket(Tracker tracker, string mediaLoc)
        {
            this.Tracker = tracker;
            this.MediaLocation = mediaLoc;
            this.TorrentFolder = getTorrentFolderPath();
        }

        string getTorrentFolderPath()
        {
            string dir = "";

            if (!Settings.Default.TorrentFolderDefault &&
                Directory.Exists(Settings.Default.TorrentsCustomDir))
            {

                if (Settings.Default.TorrentsOrganize)
                {
                    dir = Path.Combine(Settings.Default.TorrentsCustomDir, Tracker.Name);
                }
                else
                {
                    dir = Settings.Default.TorrentsCustomDir;
                }
            }
            else
            {
                dir = Path.GetDirectoryName(MediaLocation);
            }

            return dir;

        }

    }



    public struct ScreenshotsPacket
    {
        public string Full { get; set; }
        public string LinkedThumbnail { get; set; }
    }

    /// <summary>
    /// Options regard Publish
    /// </summary>
    public struct PublishOptionsPacket
    {
        public bool AlignCenter { get; set; }
        public bool PreformattedText { get; set; }
        public bool FullPicture { get; set; }
        public bool TemplatesMode { get; set; }
        public string TemplateLocation { get; set; }        
    }


}
