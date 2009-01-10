using System;
using System.Collections.Generic;
using System.Diagnostics;
using TDMaker.Properties;
using System.IO;
using ZSS.ImageUploader;
using MediaInfoLib;
using System.Text;
using System.ComponentModel;
using TDMaker;

namespace TorrentDescriptionMaker
{
    class TorrentInfo
    {
        private BackgroundWorker mBwApp = null;
        
        public TorrentInfo(BackgroundWorker bwApp, MediaInfo2 mi)
        {
            // load the MediaInfo object
            MediaInfo2 = mi;

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
            int fontSizeHeading1 = (int)(Settings.Default.PreText && Settings.Default.LargerPreText == true ?
               Settings.Default.FontSizeHeading1 + Settings.Default.FontSizeIncr :
               Settings.Default.FontSizeHeading1);

            int fontSizeHeading2 = (int)(Settings.Default.PreText && Settings.Default.LargerPreText == true ?
                Settings.Default.FontSizeHeading2 + Settings.Default.FontSizeIncr :
                Settings.Default.FontSizeHeading2);

            int fontSizeBody = (int)(Settings.Default.PreText && Settings.Default.LargerPreText == true ?
                Settings.Default.FontSizeBody + Settings.Default.FontSizeIncr :
                Settings.Default.FontSizeBody);


            BbCode bb = new BbCode();

            StringBuilder sbBody = new StringBuilder();

            // Show Overall Information if more than one Media File is found
            if (MediaInfo2.MediaFiles.Count > 1)
            {
                sbBody.AppendLine(bb.size(fontSizeHeading1, bb.bold(MediaInfo2.Overall.FileName)));
                sbBody.AppendLine();

                // is a DVD so need Overall Info only
                if (MediaInfo2.IsDisc)
                {
                    sbBody.AppendLine(MediaInfo2.Overall.ToString());
                }
            }

            if (Settings.Default.WebLink && !string.IsNullOrEmpty(MediaInfo2.WebLink))
            {
                sbBody.AppendLine(string.Format("          [u]Web Link:[/u] {0}", MediaInfo2.WebLink));
            }

            // If the loaded folder is not a Disc but individual ripped files
            if (!MediaInfo2.IsDisc)
            {
                foreach (MediaFile mf in MediaInfo2.MediaFiles)
                {

                    sbBody.AppendLine(bb.size(fontSizeHeading2, bb.bolditalic(mf.FileName)));
                    sbBody.AppendLine();
                    sbBody.AppendLine(mf.ToString());

                }
            }

            if (Settings.Default.AlignCenter)
            {
                this.MediaInfoForums1 = bb.alignCenter(sbBody.ToString());
            }
            else
            {
                this.MediaInfoForums1 = sbBody.ToString();
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
        public MediaInfo2 MediaInfo2 { get; private set; }

    }
}
