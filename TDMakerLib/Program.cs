using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TDMakerLib
{
    public static class Program
    {
        public const string PROGRAM_FILES_APP_NAME = "TDMaker";
        private static string mProductName = Application.ProductName;
        public static McoreSystem.AppInfo mAppInfo = new McoreSystem.AppInfo(mProductName, Application.ProductVersion, McoreSystem.AppInfo.SoftwareCycle.Beta, false);
        public static bool Portable { get; private set; }
        public static bool MultipleInstance { get; private set; }

        internal static readonly string LocalAppDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Application.ProductName);
        public static AppSettings appSettings = AppSettings.Read();

        private static readonly string PortableRootFolder = Application.ProductName; // using relative paths
        public static string DefaultRootAppFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), Application.ProductName);
        public static string RootAppFolder { get; set; }

        public static string SettingsDir { get; set; }
        public static string LogsDir { get; set; }
        public static bool IsUNIX { get; private set; }

        public readonly static string ScreenshotsDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "MTN");
        public readonly static string ScreenshotsTempDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), PROGRAM_FILES_APP_NAME);

        private static string[] AppDirs;
        public static readonly string XMLFileName = "Settings.xml";
        public static string DefaultXMLFilePath { get; private set; }

        public static XMLSettings conf;
        private static bool RunConfig = false;

        public static bool DetectUnix()
        {
            string os = System.Environment.OSVersion.ToString();
            bool b = os.Contains("Unix");
            IsUNIX = b;

            return IsUNIX;
        }

        public static string XMLSettingsFile
        {
            get
            {
                if (!Directory.Exists(SettingsDir))
                {
                    Directory.CreateDirectory(SettingsDir);
                }

                return DefaultXMLFilePath;                                  // v2.x               
            }
        }

        public static string GetMediaName(string p)
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

        public static string GetScreenShotsDir()
        {
            return (Program.conf.KeepScreenshot ? Program.ScreenshotsDir : Program.ScreenshotsTempDir);
        }

        public static bool MediaIsDisc(string p)
        {
            bool disc = Directory.Exists(p);

            if (disc)
            {
                string[] ifo = Directory.GetFiles(p, "VTS_01_0.IFO", SearchOption.AllDirectories);
                string[] vob = Directory.GetFiles(p, "*.VOB", SearchOption.AllDirectories);
                disc = ifo.Length > 0 && vob.Length > 0;
            }

            return disc;
        }

        /// <summary>
        /// Function to determine DVD-5 or DVD-9
        /// </summary>
        /// <returns>DVD-5 or DVD-9</returns>
        public static string GetDVDString(string p)
        {
            string ss = "DVD";
            double size = 0.0;      // size in Bytes
            if (MediaIsDisc(p))
            {
                string[] files = Directory.GetFiles(p, "*.*", SearchOption.AllDirectories);
                foreach (string f in files)
                {
                    FileInfo fi = new FileInfo(f);
                    size += fi.Length;
                }
                if (size > 0.0)
                {
                    ss = (size > 4.7 * 1000.0 * 1000.0 * 1000.0 ? "DVD-9" : "DVD-5");
                }
            }
            return ss;
        }

        public static void ClearScreenshots()
        {
            if (!Program.conf.KeepScreenshot)
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


        /// <summary>
        /// Get DuratingString in HH:mm:ss
        /// </summary>
        /// <param name="dura">Duration in Milliseconds</param>
        /// <returns>DuratingString in HH:mm:ss</returns>
        public static string GetDurationString(double dura)
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

        public static void WriteTemplates(bool rewrite)
        {
            string[] tNames = new string[] { "Default", "MTN", "Minimal" };
            foreach (string name in tNames)
            {
                // Copy Default Templates to Templates folder
                string dPrefix = string.Format("Templates.{0}.", name);
                string tDir = Path.Combine(Program.conf.TemplatesDir, name);
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
                            sw.WriteLine(GetText(dPrefix + fn));
                        }
                    }
                }

            }

        }


        public static string GetText(string name)
        {
            string text = "";

            try
            {
                System.Reflection.Assembly oAsm = System.Reflection.Assembly.GetExecutingAssembly();
                Stream oStrm = oAsm.GetManifestResourceStream(oAsm.GetName().Name + "." + name);
                StreamReader oRdr = new StreamReader(oStrm);
                text = oRdr.ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return text;
        }

        public static string GetFileSizeString(double size)
        {
            return string.Format("{0} MiB", (size / 1024.0 / 1024.0).ToString("0.00"));
        }

        /// <summary>
        /// Function to update Default Folder Paths based on Root folder
        /// </summary>
        public static void InitializeDefaultFolderPaths()
        {
            LogsDir = Path.Combine(RootAppFolder, "Logs");
            SettingsDir = Path.Combine(RootAppFolder, "Settings");

            AppDirs = new[] { LogsDir, SettingsDir };

            foreach (string dp in AppDirs)
            {
                if (!string.IsNullOrEmpty(dp) && !Directory.Exists(dp))
                {
                    Directory.CreateDirectory(dp);
                }
            }

            DefaultXMLFilePath = Path.Combine(SettingsDir, XMLSettings.XMLFileName);
            string DefaultXMLFilePathOld = Path.Combine(SettingsDir, XMLFileName);
            if (!File.Exists(DefaultXMLFilePath) && File.Exists(DefaultXMLFilePathOld))
            {
                DefaultXMLFilePath = DefaultXMLFilePathOld;
            }
        }

        public static void Load()
        {
            FileSystem.AppendDebug("Operating System: " + Environment.OSVersion.VersionString);
            FileSystem.AppendDebug("Product Version: " + mAppInfo.GetApplicationTitleFull());

            if (Directory.Exists(Path.Combine(Application.StartupPath, PortableRootFolder)))
            {
                Portable = true;
                RootAppFolder = PortableRootFolder;
                mProductName += " Portable";
                mAppInfo.AppName = mProductName;
            }
            else
            {
                if (string.IsNullOrEmpty(Program.appSettings.RootDir))
                {
                    ConfigWizard cw = new ConfigWizard(DefaultRootAppFolder);
                    cw.ShowDialog();
                    Program.appSettings.RootDir = cw.RootFolder;
                    Program.appSettings.ImageUploader = cw.ImageDestinationType;
                    RunConfig = true;
                }
                RootAppFolder = Program.appSettings.RootDir;
            }

            Program.InitializeDefaultFolderPaths(); // happens before XMLSettings is readed
            conf = XMLSettings.Read();
        }

        public static void Unload()
        {
            conf.Save();
            appSettings.Write();
        }
    }
}
