using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Globalization;
using TDMakerLib.Templates;
using System.Diagnostics;
using System.IO;

namespace TDMakerLib
{
    public class TemplateReader2
    {
        public string Location { get; private set; }
        public TorrentInfo TorrentInfo { get; private set; }
        public string PublishInfo { get; private set; }

        private string mDiscAudioInfo = "";
        private string mDiscVideoInfo = "";
        private string mFileAudioInfo = "";
        private string mFileVideoInfo = "";
        private string mGeneralInfo = "";
        private string mDiscInfo = "";
        private string mFileInfo = "";

        List<MIFieldValue> MIFieldValueList { get; set; }

        /// <summary>
        /// Constructor of TemplateReader2
        /// </summary>
        /// <param name="loc">Directory Path of the Template</param>
        /// <param name="summary">MediaInfo Summary</param>
        public TemplateReader2(string loc, TorrentInfo ti)
        {
            string summary = ti.MediaMy.Overall.Summary;

            // Read the files in Location
            string[] files = Directory.GetFiles(loc, "*.txt", SearchOption.AllDirectories);
            foreach (string f in files)
            {
                using (StreamReader sw = new StreamReader(f))
                {
                    switch (Path.GetFileNameWithoutExtension(f))
                    {
                        case "Disc":
                            mDiscInfo = sw.ReadToEnd().Trim();
                            break;
                        case "DiscAudioInfo":
                            mDiscAudioInfo = sw.ReadToEnd().Trim();
                            break;
                        case "File":
                            mFileInfo = sw.ReadToEnd().Trim();
                            break;
                        case "FileAudioInfo":
                            mFileAudioInfo = sw.ReadToEnd().Trim();
                            break;
                        case "GeneralInfo":
                            mGeneralInfo = sw.ReadToEnd().Trim();
                            break;
                        case "FileVideoInfo":
                            mFileVideoInfo = sw.ReadToEnd().Trim();
                            break;
                        case "DiscVideoInfo":
                            mDiscVideoInfo = sw.ReadToEnd().Trim();
                            break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(summary))
            {
                MIFieldValueList = new List<MIFieldValue>();
                string prefix = string.Empty;
                string[] lines = summary.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    string[] temp = line.Split(new[] { " : " }, StringSplitOptions.None);

                    if (temp.Length == 2 && !string.IsNullOrEmpty(prefix))
                    {
                        MIFieldValueList.Add(new MIFieldValue(temp[0], temp[1], prefix));
                    }
                    else if (temp.Length == 1)
                    {
                        prefix = temp[0].Trim();
                    }
                    else
                    {
                        Debug.WriteLine(string.Format("Error TemplateReader2.cs: {0}, {1}", line, prefix));
                    }
                }

                foreach (MIFieldValue mifv in MIFieldValueList)
                {
                    Debug.WriteLine(mifv.ToString());
                }
            }
        }

        public void SetFullScreenshot(bool arg)
        {
            if (arg)
            {
                this.mFileInfo = Regex.Replace(this.mFileInfo, "%ScreenshotForums%", "%ScreenshotFull%", RegexOptions.IgnoreCase);
                this.mDiscInfo = Regex.Replace(this.mDiscInfo, "%ScreenshotForums%", "%ScreenshotFull%", RegexOptions.IgnoreCase);
            }
            else
            {
                this.mFileInfo = Regex.Replace(this.mFileInfo, "%ScreenshotFull%", "%ScreenshotForums%", RegexOptions.IgnoreCase);
                this.mDiscInfo = Regex.Replace(this.mDiscInfo, "%ScreenshotFull%", "%ScreenshotForums%", RegexOptions.IgnoreCase);
            }
        }
    }
}