using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using UploadersLib.Helpers;

namespace TDMakerLib
{
    public static class Engine
    {
        private static string mProductName = "TDMaker"; // NOT Application.ProductName because both CLI and GUI needs common access
        private static readonly string PortableRootFolder = mProductName; // using relative paths

        public static McoreSystem.AppInfo mAppInfo = new McoreSystem.AppInfo(mProductName, Application.ProductVersion, McoreSystem.AppInfo.SoftwareCycle.Beta, false);
        public static bool Portable = Directory.Exists(Path.Combine(Application.StartupPath, PortableRootFolder));
        public static bool MultipleInstance { get; private set; }

        internal static readonly string zRoamingAppDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), mProductName);
        internal static readonly string zLocalAppDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), mProductName);

        internal static readonly string zLogsDir = Path.Combine(zLocalAppDataFolder, "Logs");
        internal static readonly string zPicturesDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), mProductName);
        internal static readonly string zSettingsDir = Path.Combine(zRoamingAppDataFolder, "Settings");
        internal static readonly string zTemplatesDir = Path.Combine(zRoamingAppDataFolder, "Templates");
        internal static readonly string zTorrentsDir = Path.Combine(zLocalAppDataFolder, "Torrents");
        public static readonly string zTempDir = Path.Combine(zLocalAppDataFolder, "Temp");

        public static AppSettings mAppSettings = AppSettings.Read();


        public static string DefaultRootAppFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), mProductName);
        public static string RootAppFolder { get; set; }

        public static string LogsDir = zLogsDir;
        public static string PicturesDir = zPicturesDir;
        public static string SettingsDir = zSettingsDir;
        public static string TemplatesDir = conf != null && Directory.Exists(conf.CustomTemplatesDir) && conf.UseCustomTemplatesDir ? conf.CustomTemplatesDir : TemplatesDir;
        public static string TorrentsDir = conf != null && Directory.Exists(conf.CustomTorrentsDir) && conf.UseCustomTorrentsDir ? conf.CustomTorrentsDir : TorrentsDir;

        public static bool IsUNIX { get; private set; }
        private static bool RunConfig = false;

        private static string[] AppDirs;

        public static XMLSettingsCore conf;
        public static XMLSettingsMtnProfiles mtnProfileMgr;

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

                return Engine.mAppSettings.XMLSettingsFile;
            }
        }

        public static void ClearScreenshots()
        {
            if (!Engine.conf.KeepScreenshots)
            {
                // delete if option set to temporary location 
                string[] files = Directory.GetFiles(Engine.zTempDir, "*.*", SearchOption.AllDirectories);
                foreach (string screenshot in files)
                {
                    try
                    {
                        File.Delete(screenshot);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
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
                string tDir = Path.Combine(Engine.TemplatesDir, name);
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
                Debug.WriteLine(ex.Message);
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
            if (mAppSettings.PreferSystemFolders)
            {
                LogsDir = zLogsDir;
                PicturesDir = zPicturesDir;
                SettingsDir = zSettingsDir;
                TemplatesDir = zTemplatesDir;
                TorrentsDir = zTorrentsDir;
            }
            else
            {
                LogsDir = Path.Combine(RootAppFolder, "Logs");
                PicturesDir = Path.Combine(RootAppFolder, "Screenshots");
                SettingsDir = Path.Combine(RootAppFolder, "Settings");
                TemplatesDir = Path.Combine(RootAppFolder, "Templates");
                TorrentsDir = Path.Combine(RootAppFolder, "Torrents");
            }

            AppDirs = new[] { LogsDir, PicturesDir, SettingsDir, TorrentsDir };

            foreach (string dp in AppDirs)
            {
                if (!string.IsNullOrEmpty(dp) && !Directory.Exists(dp))
                {
                    Directory.CreateDirectory(dp);
                }
            }

            string latestSettingsFile = Path.Combine(SettingsDir, XMLSettingsCore.XMLFileName);
            if (File.Exists(latestSettingsFile))
            {
                Engine.mAppSettings.XMLSettingsFile = latestSettingsFile;
            }
        }

        public static string GetProductName()
        {
            return mAppInfo.GetApplicationTitle(McoreSystem.AppInfo.VersionDepth.MajorMinorBuild);
        }

        public static bool TurnOn()
        {
            FileSystem.AppendDebug("Operating System: " + Environment.OSVersion.VersionString);
            FileSystem.AppendDebug("Product Version: " + mAppInfo.GetApplicationTitleFull());
            DialogResult configResult = DialogResult.OK;

            if (Directory.Exists(Path.Combine(Application.StartupPath, PortableRootFolder)))
            {
                mAppSettings.PreferSystemFolders = false;
                RootAppFolder = PortableRootFolder;
                mProductName += " Portable";
                mAppInfo.AppName = mProductName;
            }
            else
            {
                if (string.IsNullOrEmpty(Engine.mAppSettings.RootDir))
                {
                    ConfigWizard cw = new ConfigWizard(DefaultRootAppFolder);
                    configResult = cw.ShowDialog();
                    RunConfig = true;
                }
                if (!string.IsNullOrEmpty(Engine.mAppSettings.RootDir) && Directory.Exists(Engine.mAppSettings.RootDir))
                {
                    RootAppFolder = Engine.mAppSettings.RootDir;
                }
                else
                {
                    RootAppFolder = Engine.mAppSettings.PreferSystemFolders ? zLocalAppDataFolder : DefaultRootAppFolder;
                }
            }
            if (configResult == DialogResult.OK)
            {
                FileSystem.AppendDebug("Config file: " + AppSettings.AppSettingsFile);
                FileSystem.AppendDebug(string.Format("Root Folder: {0}", mAppSettings.PreferSystemFolders ? zLocalAppDataFolder : RootAppFolder));
                FileSystem.AppendDebug("Initializing Default folder paths...");
                Engine.InitializeDefaultFolderPaths(); // happens before XMLSettings is readed
            }
            mAppInfo.AppName = mProductName;
            return configResult == DialogResult.OK;
        }

        public static void TurnOff()
        {
            if (!Portable)
            {
                mAppSettings.Write();
            }
            FileSystem.WriteDebugFile();
        }

        public static void LoadSettings()
        {
            LoadSettings(string.Empty);
        }

        public static void LoadSettingsLatest()
        {
            string fp = GetLatestSettingsFile();
            XMLSettingsCore.XMLFileName = Path.GetFileName(fp);
            LoadSettings(fp);
        }

        public static string GetLatestSettingsFile()
        {
            return GetLatestSettingsFile(Path.GetDirectoryName(Engine.mAppSettings.XMLSettingsFile));
        }

        public static string GetLatestSettingsFile(string settingsDir)
        {
            string fp = string.Empty;
            if (!string.IsNullOrEmpty(settingsDir))
            {
                List<ImageFile> imgFiles = new List<ImageFile>();
                string[] files = Directory.GetFiles(settingsDir, Application.ProductName + "-*-Settings.xml");
                if (files.Length > 0)
                {
                    foreach (string f in files)
                    {
                        imgFiles.Add(new ImageFile(f));
                    }
                    imgFiles.Sort();
                    fp = imgFiles[imgFiles.Count - 1].LocalFilePath;
                }
            }
            return fp;
        }

        public static void LoadSettings(string fp)
        {
            if (string.IsNullOrEmpty(fp))
            {
                FileSystem.AppendDebug("Reading " + Engine.XMLSettingsFile);
                Engine.conf = XMLSettingsCore.Read();
            }
            else
            {
                FileSystem.AppendDebug("Reading " + fp);
                Engine.conf = XMLSettingsCore.Read(fp);
            }

            // Use Configuration Wizard Settings if applied
            if (RunConfig)
            {
                Engine.conf.ImageUploader = Engine.mAppSettings.ImageUploader;
            }
            mtnProfileMgr = XMLSettingsMtnProfiles.Read();
        }
    }
}
