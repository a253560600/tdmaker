﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using TDMaker.Properties;
using System.IO;
using ZSS.ImageUploader;
using MediaInfoLib;
using System.Text;
using System.ComponentModel;

namespace TorrentDescriptionMaker
{
    class cTorrentInfo
    {
        private string mMovieFilePath = string.Empty;
        private BackgroundWorker mBwApp = null;
        private MediaInfoLib.MediaInfo mMI = new MediaInfoLib.MediaInfo();

        public cTorrentInfo(BackgroundWorker bwApp, string filePath)
        {
            this.mBwApp = bwApp;
            this.mMovieFilePath = filePath;

            mMI.Open(mMovieFilePath);
            mMI.Option("Complete");
            mBwApp.ReportProgress(0, mMI.Inform());
            
            if (Settings.Default.UploadImageShack)
                sGetScreenshot();

            sGetMovieInfo();

        }

        /// <summary>
        /// Function to populate MediaInfo class
        /// </summary>
        private void sReadMovie()
        {

        }

        /// <summary>
        /// Function to launch GSpot or MovieInfo to generate Movie Info
        /// </summary>      
        private void sGetMovieInfo()
        {
            int fontSizeHeading = (int)(Settings.Default.LargerPreText == true ? 
                Settings.Default.FontSizeHeading + Settings.Default.FontSizeIncr : 
                Settings.Default.FontSizeHeading);

            int fontSizeBody = (int)(Settings.Default.LargerPreText == true ?
                Settings.Default.FontSizeBody + Settings.Default.FontSizeIncr :
                Settings.Default.FontSizeBody);
            

            BbCode bb = new BbCode();
            
            MediaInfo myMovie = new MediaInfo();
            myMovie.Format = mMI.Get(StreamKind.General, 0, "Format");
            myMovie.FormatInfo = mMI.Get(StreamKind.General, 0, "Format/Info");
            StringBuilder sbMediaInfo = new StringBuilder();

            //*********************
            //* General
            //*********************    

            StringBuilder sbGeneral = new StringBuilder();

            sbMediaInfo.AppendLine(bb.size(fontSizeHeading, bb.bolditalic("General:")));
            sbMediaInfo.AppendLine();

            // Source 
            if (!string.IsNullOrEmpty(Settings.Default.Source))
            {
                sbGeneral.AppendLine(string.Format("       [u]Source:[/u] {0}", Settings.Default.Source));
            }            
            // File Name
            sbGeneral.AppendLine(string.Format("    [u]File Name:[/u] {0}.{1}",
                mMI.Get(0, 0, "FileName"),
                mMI.Get(0, 0, "FileExtension")));
            // Format
            sbGeneral.Append(string.Format("       [u]Format:[/u] {0}", myMovie.Format));
            if (!string.IsNullOrEmpty(myMovie.FormatInfo))
            {
                sbGeneral.Append(string.Format(" ({0})", myMovie.FormatInfo));
            }
            sbGeneral.Append(Environment.NewLine);

            // File Size
            sbGeneral.AppendLine(string.Format("    [u]File Size:[/u] {0}",
                mMI.Get(0, 0, "FileSize/String4")));
            // Duration
            sbGeneral.AppendLine(string.Format("     [u]Duration:[/u] {0}",
                mMI.Get(0, 0, "Duration/String2")));
            // Bitrate
            sbGeneral.AppendLine(string.Format("      [u]Bitrate:[/u] {0}",
                mMI.Get(StreamKind.General, 0, "OverallBitRate/String")));

            int subCount = 0;
            int.TryParse(mMI.Get(StreamKind.Text, 0, "Count"), out subCount);

            sbGeneral.Append("    [u]Subtitles:[/u] ");
            if (subCount > 0)
            {

                for (int i = 0; i < subCount; i++)
                {
                    string lang = mMI.Get(StreamKind.Text, i, "Language/String");
                    if (!string.IsNullOrEmpty(lang))
                    {
                        // System.Windows.Forms.MessageBox.Show(lang);
                        sbGeneral.Append(lang);
                        if (i < subCount - 1)
                            sbGeneral.Append(", ");
                    }
                }
            }
            else
            {
                sbGeneral.Append("None");
            }
            sbGeneral.Append(Environment.NewLine);

            sbMediaInfo.Append(bb.size(fontSizeBody, sbGeneral.ToString()));

            //*********************
            //* Video
            //*********************                        
            sbMediaInfo.AppendLine();
            sbMediaInfo.AppendLine(bb.size(fontSizeHeading, bb.bolditalic("Video:")));
            sbMediaInfo.AppendLine();

            VideoInfo vi = new VideoInfo();
            StringBuilder sbVideo = new StringBuilder();
            // Format
            vi.FormatVersion = mMI.Get(StreamKind.Video, 0, "Format_Version");
            sbVideo.Append(string.Format("       [u]Format:[/u] {0}", mMI.Get(StreamKind.Video, 0, "Format")));
            if (!string.IsNullOrEmpty(vi.FormatVersion))
            {
                sbVideo.Append(string.Format(" {0}", vi.FormatVersion));
            }
            sbVideo.Append(Environment.NewLine);

            // Codec
            this.VideoCodec = mMI.Get(StreamKind.Video, 0, "CodecID/Hint");
            if (string.IsNullOrEmpty(VideoCodec))
                this.VideoCodec = mMI.Get(StreamKind.Video, 0, "CodecID");
            if (!string.IsNullOrEmpty(VideoCodec))
                sbVideo.AppendLine(string.Format("        [u]Codec:[/u] {0}", this.VideoCodec));
            // Bitrate
            sbVideo.AppendLine(string.Format("      [u]Bitrate:[/u] {0}", mMI.Get(StreamKind.Video, 0, "BitRate/String")));
            // Standard
            vi.Standard = mMI.Get(StreamKind.Video, 0, "Standard");
            if (!string.IsNullOrEmpty(vi.Standard))
                sbVideo.AppendLine(string.Format("     [u]Standard:[/u] {0}", vi.Standard));
            // Frame Rate
            sbVideo.AppendLine(string.Format("   [u]Frame Rate:[/u] {0}", mMI.Get(StreamKind.Video, 0, "FrameRate/String")));

            // Scan Type
            sbVideo.AppendLine(string.Format("    [u]Scan Type:[/u] {0}", mMI.Get(StreamKind.Video, 0, "ScanType/String")));

            // Resolution
            sbVideo.AppendLine(string.Format("   [u]Resolution:[/u] {0}x{1}",
                mMI.Get(StreamKind.Video, 0, "Width"),
                mMI.Get(StreamKind.Video, 0, "Height")));

            int audioCount = 0;
            int.TryParse(mMI.Get(StreamKind.General, 0, "AudioCount"), out audioCount);

            sbMediaInfo.Append(bb.size(fontSizeBody, sbVideo.ToString()));


            //*********************
            //* Audio
            //*********************          
            for (int a = 0; a < audioCount; a++)
            {
                AudioInfo ai = new AudioInfo();

                sbMediaInfo.AppendLine();
                sbMediaInfo.AppendLine(string.Format(bb.size(fontSizeHeading, bb.bolditalic("Audio #{0}:")), a + 1));
                sbMediaInfo.AppendLine();

                StringBuilder sbAudio = new StringBuilder();
                // Format
                sbAudio.Append(string.Format("        [u]Format:[/u] {0}", mMI.Get(StreamKind.Audio, a, "Format")));
                ai.FormatVersion = mMI.Get(StreamKind.Audio, 0, "Format_Version");
                if (!string.IsNullOrEmpty(ai.FormatVersion))
                    sbAudio.Append(string.Format(" {0}", ai.FormatVersion));
                ai.FormatProfile = mMI.Get(StreamKind.Audio, 0, "Format_Profile");
                if (!string.IsNullOrEmpty(ai.FormatProfile))
                    sbAudio.Append(string.Format(" {0}", ai.FormatProfile));
                sbAudio.Append(Environment.NewLine);

                // Codec
                this.AudioCodec = mMI.Get(StreamKind.Audio, 0, "CodecID/Hint");
                if (string.IsNullOrEmpty(this.AudioCodec))
                    this.AudioCodec = mMI.Get(StreamKind.Audio, 0, "CodecID");
                if (!string.IsNullOrEmpty(this.AudioCodec))
                    sbAudio.AppendLine(string.Format("        [u]Codec:[/u] {0}", this.AudioCodec));
                // Bitrate
                sbAudio.AppendLine(string.Format("      [u]Bitrate:[/u] {0} ({1})",
                    mMI.Get(StreamKind.Audio, a, "BitRate/String"),
                    mMI.Get(StreamKind.Audio, a, "BitRate_Mode/String")));
                // Channels
                sbAudio.AppendLine(string.Format("     [u]Channels:[/u] {0}", mMI.Get(StreamKind.Audio, a, "Channel(s)/String")));
                // Sampling Rate
                sbAudio.AppendLine(string.Format("[u]Sampling Rate:[/u] {0}", mMI.Get(StreamKind.Audio, a, "SamplingRate/String")));
                // Resolution
                this.AudioResolution = mMI.Get(StreamKind.Audio, a, "Resolution/String");
                if (!string.IsNullOrEmpty(AudioResolution))
                    sbAudio.AppendLine(string.Format(bb.underline("   [u]Resolution:[/u] {0}"), this.AudioResolution));

                myMovie.Audio.Add(ai);

                sbMediaInfo.Append(bb.size(fontSizeBody, sbAudio.ToString()));

            }

            if (Settings.Default.AlignCenter)
            {
                this.MediaInfoForums1 = bb.alignCenter(sbMediaInfo.ToString());
            }
            else
            {
                this.MediaInfoForums1 = sbMediaInfo.ToString();
            }

            if (Settings.Default.PreText)
            {
                this.MediaInfoForums1 = bb.pre(this.MediaInfoForums1);
            }

            mMI.Close();

        }

        private void sGetScreenshot()
        {

            Process p = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(Settings.Default.MTNPath);
            psi.WindowStyle = ProcessWindowStyle.Minimized;

            string picPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "MTN");
            if (!Settings.Default.KeepScreenshot)
            {
                picPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TDMaker");
            }
            
            if (!Directory.Exists(picPath))
                Directory.CreateDirectory(picPath);

            psi.Arguments = string.Format("{0} -O \"{1}\" \"{2}\"",
                Settings.Default.MTNArg,
                picPath,
                this.mMovieFilePath);

            p.StartInfo = psi;
            p.Start();
            p.WaitForExit();

            string screenshot = Path.Combine(picPath, Path.GetFileNameWithoutExtension(mMovieFilePath) + "_s.jpg");

            if (File.Exists(screenshot))
            {
                ImageShackUploader su = new ImageShackUploader();

                int retry = 1;
                List<ZSS.ImageUploader.ImageFile> lstScreenshots = new List<ImageFile>();
                while (retry <= 3 && lstScreenshots == null ||
                   (retry <= 3 && lstScreenshots != null && lstScreenshots.Count < 1))
                {
                    Program.Status = string.Format("Uploading screenshot to ImageShack... Attempt {0}", retry);
                    lstScreenshots = su.UploadImage(screenshot);
                }

                if (lstScreenshots != null && lstScreenshots.Count > 0)
                {
                    foreach (ImageFile imf in lstScreenshots)
                    {
                        if (imf.Type == ImageFile.ImageType.FULLIMAGE)
                        {
                            this.ScreenshotURLFull = imf.URI;
                        }
                        else if (imf.Type == ImageFile.ImageType.THUMBNAIL_FORUMS1)
                        {
                            this.ScreenshotURLForums = imf.URI;
                        }
                    }
                }
                else
                {
                    Program.Status = "Failed uploading screenshot to ImageShack. Try again later.";
                }

                // delete if option set to temporary location 
                File.Delete(screenshot);
            }

        }

        public string ScreenshotURLForums { get; private set; }
        public string ScreenshotURLFull { get; private set; }
        public string MediaInfoForums1 { get; private set; }

        public string AudioCodec { get; private set; }
        public string AudioFormat { get; private set; }
        public string AudioResolution { get; private set; }
        public string VideoCodec { get; private set; }
        public string VideoFormat { get; private set; }

    }
}
