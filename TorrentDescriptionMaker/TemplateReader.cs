using System;
using System.Collections.Generic;
using System.Text;
using TorrentDescriptionMaker;
using System.IO;
using System.Text.RegularExpressions;
using TDMaker.Properties;

namespace TDMaker
{
    /// <summary>
    /// Class responsible for reading Template Directories. 
    /// A Template Directory has 5 files: 
    /// GeneralInfo.txt; VideoInfo.txt; AudioInfo.txt; Disc.txt; File.txt
    /// </summary>
    class TemplateReader
    {
        /// <summary>
        /// Location of the Template
        /// </summary>
        public string Location { get; private set; }
        public TorrentInfo TorrentInfo { get; private set; }
        public string PublishInfo { get; private set; }

        private string mAudioInfo = "";
        private string mVideoInfo = "";
        private string mGeneralInfo = "";
        private string mDiscInfo = "";
        private string mFileInfo = "";

        /// <summary>
        /// Constructure of TemplateReader
        /// </summary>
        /// <param name="loc">Directory Path of the Template</param>
        /// <param name="ti">TorrentInfo object that has MediaInfo</param>
        public TemplateReader(string loc, TorrentInfo ti)
        {
            this.Location = loc;
            this.TorrentInfo = ti;

            // Read the files in Location
            string[] files = Directory.GetFiles(loc, "*.txt", SearchOption.AllDirectories);
            foreach (string f in files)
            {
                using (StreamReader sw = new StreamReader(f))
                {
                    switch (Path.GetFileNameWithoutExtension(f))
                    {
                        case "AudioInfo":
                            mAudioInfo = sw.ReadToEnd();
                            break;
                        case "Disc":
                            mDiscInfo = sw.ReadToEnd();
                            break;
                        case "File":
                            mFileInfo = sw.ReadToEnd();
                            break;
                        case "GeneralInfo":
                            mGeneralInfo = sw.ReadToEnd();
                            break;
                        case "VideoInfo":
                            mVideoInfo = sw.ReadToEnd();
                            break;
                    }
                }
            }

        }

        public void CreateInfo()
        {
            if (TorrentInfo.MediaInfo2.IsDisc)
            {
                PublishInfo = CreateDiscInfo(TorrentInfo.MediaInfo2.Overall);
            }
            else
            {
                PublishInfo = CreateFileInfo(TorrentInfo.MediaInfo2);
            }
        }

        private string GeneralInfo(MediaFile mf)
        {

            return "";
        }

        private string VideoInfo(MediaFile mf)
        {
            return "";
        }

        private string AudioInfo(MediaFile mf)
        {

            return "";
        }

        private string CreateFileInfo(MediaInfo2 mi)
        {


            return "";
        }

        private string CreateDiscInfo(MediaFile mf)
        {
            return "";
        }

        private string GetStringFromPattern(string pattern, MediaFile mf)
        {

            int fontSizeHeading1 = (int)(Settings.Default.PreText && Settings.Default.LargerPreText == true ?
                Settings.Default.FontSizeHeading1 + Settings.Default.FontSizeIncr : Settings.Default.FontSizeHeading1);

            int fontSizeHeading2 = (int)(Settings.Default.PreText && Settings.Default.LargerPreText == true ?
                Settings.Default.FontSizeHeading2 + Settings.Default.FontSizeIncr : Settings.Default.FontSizeHeading2);

            int fontSizeHeading3 = (int)(Settings.Default.PreText && Settings.Default.LargerPreText == true ?
                Settings.Default.FontSizeHeading3 + Settings.Default.FontSizeIncr : Settings.Default.FontSizeHeading3);

            int fontSizeBody = (int)(Settings.Default.PreText && Settings.Default.LargerPreText == true ?
                Settings.Default.FontSizeBody + Settings.Default.FontSizeIncr : Settings.Default.FontSizeBody);

            pattern = Regex.Replace(pattern, "%FontSize_Body%", fontSizeBody.ToString(), RegexOptions.IgnoreCase);
            pattern = Regex.Replace(pattern, "%FontSize_Heading1%", fontSizeHeading1.ToString(), RegexOptions.IgnoreCase);
            pattern = Regex.Replace(pattern, "%FontSize_Heading2%", fontSizeHeading2.ToString(), RegexOptions.IgnoreCase);
            pattern = Regex.Replace(pattern, "%FontSize_Heading3%", fontSizeHeading3.ToString(), RegexOptions.IgnoreCase);



            return pattern;

        }

    }
}
