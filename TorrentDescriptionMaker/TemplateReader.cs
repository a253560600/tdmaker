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

        private string mDiscAudioInfo = "";
        private string mFileAudioInfo = "";
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
                        case "Disc":
                            mDiscInfo = sw.ReadToEnd();
                            break;
                        case "DiscAudioInfo":
                            mDiscAudioInfo = sw.ReadToEnd();
                            break;
                        case "File":
                            mFileInfo = sw.ReadToEnd();
                            break;
                        case "FileAudioInfo":
                            mFileAudioInfo = sw.ReadToEnd();
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

            string pattern = "";

            if (TorrentInfo.MediaInfo2.IsDisc)
            {
                pattern = CreateDiscInfo(TorrentInfo.MediaInfo2);
            }
            else
            {
                pattern = CreateFileInfo(TorrentInfo.MediaInfo2);
            }

            pattern = GetSourceInfo(pattern, TorrentInfo.MediaInfo2);

            PublishInfo = pattern;
        }

        private string GetGeneralInfo(MediaFile mf)
        {
            string pattern = mGeneralInfo;
    
            pattern = Regex.Replace(pattern, "%Format%", mf.Format);            
            pattern = Regex.Replace(pattern, "%Bitrate%", mf.Bitrate);
            pattern = Regex.Replace(pattern, "%FileSize%", mf.FileSizeString);
            pattern = Regex.Replace(pattern, "%Subtitles%", mf.Subtitles);
            pattern = Regex.Replace(pattern, "%Duration%", mf.DurationString);

            return pattern;
        }

        private string GetVideoInfo(MediaFile mf)
        {
            string pattern = mVideoInfo;

            pattern = Regex.Replace(pattern, "%Video_Format%", mf.Video.Format);
            pattern = Regex.Replace(pattern, "%Video_Bitrate%", mf.Video.Bitrate);
            pattern = Regex.Replace(pattern, "%Video_Standard%", mf.Video.Standard);
            pattern = Regex.Replace(pattern, "%Video_FrameRate%", mf.Video.FrameRate);
            pattern = Regex.Replace(pattern, "%Video_ScanType%", mf.Video.ScanType);
            pattern = Regex.Replace(pattern, "%Video_BitsPerPixelFrame%", mf.Video.BitsPerPixelXFrame);
            pattern = Regex.Replace(pattern, "%Video_Width%", mf.Video.Width);
            pattern = Regex.Replace(pattern, "%Video_Height%", mf.Video.Height);

            return pattern;
        }

        private string GetAudioInfo(string pattern, MediaFile mf)
        {
            StringBuilder sbAudio = new StringBuilder();


            for (int i = 0; i < mf.Audio.Count; i++)
            {
                string info = pattern;
                AudioInfo ai = mf.Audio[i];
                info = Regex.Replace(info, "%AudioID%", (i + 1).ToString(), RegexOptions.IgnoreCase);
                info = GetStringFromAudio(info, ai);
                sbAudio.AppendLine(info);
            }

            return sbAudio.ToString();
        }

        private string GetStringFromAudio(string pattern, AudioInfo ai)
        {
            pattern = Regex.Replace(pattern, "%Audio_%Format%", ai.Format, RegexOptions.IgnoreCase);
            pattern = Regex.Replace(pattern, "%Audio_Bitrate%", ai.Bitrate, RegexOptions.IgnoreCase);
            pattern = Regex.Replace(pattern, "%Audio_Channels%", ai.Channels, RegexOptions.IgnoreCase);
            pattern = Regex.Replace(pattern, "%Audio_SamplingRate%", ai.SamplingRate, RegexOptions.IgnoreCase);
            pattern = Regex.Replace(pattern, "%Audio_Resolution%", ai.Resolution, RegexOptions.IgnoreCase);

            return pattern;

        }

        private string CreateFileInfo(MediaInfo2 mi)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < mi.MediaFiles.Count; i++)
            {
                MediaFile mf = mi.MediaFiles[i];

                string pattern = mFileInfo;

                string gi = GetGeneralInfo(mf);
                string vi = GetVideoInfo(mf); // this is our %Video_Info%
                string ai = GetAudioInfo(mFileAudioInfo, mf); // this is our %Audio_Info%

                pattern = Regex.Replace(pattern, "%General_Info%", gi, RegexOptions.IgnoreCase);
                pattern = Regex.Replace(pattern, "%Video_Info%", vi, RegexOptions.IgnoreCase);
                pattern = Regex.Replace(pattern, "%Audio_Info%", ai, RegexOptions.IgnoreCase);

                pattern = Regex.Replace(pattern, "%FileName%", mf.FileName);

                pattern = GetStyles(pattern); // apply any formatting

                sb.AppendLine(pattern);
            }

            return sb.ToString();
        }

        private string GetSourceInfo(string pattern, MediaInfo2 mi)
        {
            pattern = Regex.Replace(pattern, "%Title%", mi.Title);
            pattern = Regex.Replace(pattern, "%Source%", mi.Source);
            pattern = Regex.Replace(pattern, "%Disc_Menu%", mi.Menu);
            pattern = Regex.Replace(pattern, "%Disc_Extras%", mi.Extras);
            pattern = Regex.Replace(pattern, "%Disc_Authoring%", mi.Authoring);
            pattern = Regex.Replace(pattern, "%WebLink%", mi.WebLink);
            
            return pattern;
        }

        private string CreateDiscInfo(MediaInfo2 mi)
        {
            string pattern = mDiscInfo;

            string gi = GetGeneralInfo(mi.Overall);
            string vi = GetVideoInfo(mi.Overall);
            string ai = GetAudioInfo(mDiscAudioInfo, mi.Overall);

            pattern = Regex.Replace(pattern, "%General_Info%", gi, RegexOptions.IgnoreCase);
            pattern = Regex.Replace(pattern, "%Video_Info%", vi, RegexOptions.IgnoreCase);
            pattern = Regex.Replace(pattern, "%Audio_Info%", ai, RegexOptions.IgnoreCase);

            pattern = GetStyles(pattern); // apply any formatting

            return pattern; 
        }

        private string GetStyles(string pattern)
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
