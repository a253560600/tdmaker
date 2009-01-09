using System;
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
    class TorrentInfo
    {       
        private BackgroundWorker mBwApp = null;
        MediaFile mMediaInfo2;

        public TorrentInfo(BackgroundWorker bwApp, MediaFile mi)
        {
            // load the MediaInfo object
            mMediaInfo2 = mi;

            string p = mi.Location;

            this.mBwApp = bwApp;            

            if (Settings.Default.UploadImageShack)
                sGetScreenshot(mi.FilePath);

            sGetMovieInfo();

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
                sbGeneral.AppendLine(string.Format("            [u]Source:[/u] {0}", Settings.Default.Source));
            }
            // File Name
            if (!string.IsNullOrEmpty(mMediaInfo2.FileName))
            {
                sbGeneral.AppendLine(string.Format("         [u]File Name:[/u] {0}", mMediaInfo2.FileName));
            }
            //else
            //{
            //    sbGeneral.AppendLine(string.Format("    [u]File Name:[/u] {0}.{1}",
            //        mMI.Get(0, 0, "FileName"),
            //        mMI.Get(0, 0, "FileExtension")));
            //}

            // Format
            sbGeneral.Append(string.Format("            [u]Format:[/u] {0}", mMediaInfo2.Format));
            if (!string.IsNullOrEmpty(mMediaInfo2.FormatInfo))
            {
                sbGeneral.Append(string.Format(" ({0})", mMediaInfo2.FormatInfo));
            }
            sbGeneral.Append(Environment.NewLine);

            // File Size
            sbGeneral.AppendLine(string.Format("         [u]File Size:[/u] {0}", mMediaInfo2.FileSizeString));
            // Duration
            sbGeneral.AppendLine(string.Format("          [u]Duration:[/u] {0}", mMediaInfo2.DurationString));
            // Bitrate
            sbGeneral.AppendLine(string.Format("           [u]Bitrate:[/u] {0}", mMediaInfo2.Bitrate));

            // Subtitles            
            if (!string.IsNullOrEmpty(mMediaInfo2.Subtitles))
            {
                sbGeneral.AppendLine(string.Format("         [u]Subtitles:[/u] {0}", mMediaInfo2.Subtitles));
            }

            if (Settings.Default.WebLink && !string.IsNullOrEmpty(mMediaInfo2.WebLink))
            {
                sbGeneral.AppendLine(string.Format("          [u]Web Link:[/u] {0}", mMediaInfo2.WebLink));
            }

            sbMediaInfo.Append(bb.size(fontSizeBody, sbGeneral.ToString()));

            //*********************
            //* Video
            //*********************    
            VideoInfo vi = mMediaInfo2.Video;

            sbMediaInfo.AppendLine();
            sbMediaInfo.AppendLine(bb.size(fontSizeHeading, bb.bolditalic("Video:")));
            sbMediaInfo.AppendLine();

            StringBuilder sbVideo = new StringBuilder();
            // Format            
            sbVideo.Append(string.Format("            [u]Format:[/u] {0}", this.mMediaInfo2.Video.Format));
            if (!string.IsNullOrEmpty(this.mMediaInfo2.Video.FormatVersion))
            {
                sbVideo.Append(string.Format(" {0}", this.mMediaInfo2.Video.FormatVersion));
            }
            sbVideo.Append(Environment.NewLine);

            // Codec
            if (!string.IsNullOrEmpty(vi.Codec))
                sbVideo.AppendLine(string.Format("             [u]Codec:[/u] {0}", vi.Codec));
            // Bitrate
            sbVideo.AppendLine(string.Format("           [u]Bitrate:[/u] {0}", this.mMediaInfo2.Video.Bitrate));
            // Standard            
            if (!string.IsNullOrEmpty(vi.Standard))
                sbVideo.AppendLine(string.Format("          [u]Standard:[/u] {0}", this.mMediaInfo2.Video.Standard));
            // Frame Rate
            sbVideo.AppendLine(string.Format("        [u]Frame Rate:[/u] {0}", vi.FrameRate));

            // Scan Type
            sbVideo.AppendLine(string.Format("         [u]Scan Type:[/u] {0}", vi.ScanType));
            sbVideo.AppendLine(string.Format("[u]Bits/(Pixel*Frame):[/u] {0}", vi.BitsPerPixelXFrame));

            // Resolution
            sbVideo.AppendLine(string.Format("        [u]Resolution:[/u] {0}x{1}",
                vi.Width,
                vi.Height));

            sbMediaInfo.Append(bb.size(fontSizeBody, sbVideo.ToString()));

            //*********************
            //* Audio
            //*********************          

            int audioCount = mMediaInfo2.Audio.Count;

            for (int a = 0; a < audioCount; a++)
            {
                AudioInfo ai = mMediaInfo2.Audio[a];

                sbMediaInfo.AppendLine();
                sbMediaInfo.AppendLine(string.Format(bb.size(fontSizeHeading, bb.bolditalic("Audio #{0}:")), a + 1));
                sbMediaInfo.AppendLine();

                StringBuilder sbAudio = new StringBuilder();
                // Format
                sbAudio.Append(string.Format("            [u]Format:[/u] {0}", ai.Format));
                if (!string.IsNullOrEmpty(ai.FormatVersion))
                    sbAudio.Append(string.Format(" {0}", ai.FormatVersion));
                if (!string.IsNullOrEmpty(ai.FormatProfile))
                    sbAudio.Append(string.Format(" {0}", ai.FormatProfile));
                sbAudio.Append(Environment.NewLine);

                // Codec     
                if (!string.IsNullOrEmpty(ai.Codec))
                    sbAudio.AppendLine(string.Format("             [u]Codec:[/u] {0}", ai.Codec));
                // Bitrate
                sbAudio.AppendLine(string.Format("           [u]Bitrate:[/u] {0} ({1})", ai.Bitrate, ai.BitrateMode));
                // Channels
                sbAudio.AppendLine(string.Format("          [u]Channels:[/u] {0}", ai.Channels));
                // Sampling Rate
                sbAudio.AppendLine(string.Format("     [u]Sampling Rate:[/u] {0}", ai.SamplingRate));
                // Resolution
                if (!string.IsNullOrEmpty(ai.Resolution))
                    sbAudio.AppendLine(string.Format(("        [u]Resolution:[/u] {0}"), ai.Resolution));

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

        }

        private void sGetScreenshot(String mediaFilePath)
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
                mediaFilePath);

            p.StartInfo = psi;
            p.Start();
            p.WaitForExit();

            string screenshot = Path.Combine(picPath, Path.GetFileNameWithoutExtension(mediaFilePath) + "_s.jpg");

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

    }
}
