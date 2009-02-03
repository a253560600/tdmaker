using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDMaker.Properties;
using System.IO;

namespace TDMakerLib
{
    public static class Program
    {
        public const string PROGRAM_FILES_APP_NAME = "TDMaker";

        public static bool IsUNIX { get; private set; }
        public readonly static string ScreenshotsDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "MTN");
        public readonly static string ScreenshotsTempDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), PROGRAM_FILES_APP_NAME);

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
            return (Settings.Default.KeepScreenshot ? Program.ScreenshotsDir : Program.ScreenshotsTempDir);
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

    }
}
