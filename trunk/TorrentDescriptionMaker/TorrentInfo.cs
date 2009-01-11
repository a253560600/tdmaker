﻿using System;
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
            {
                sGetScreenshot(mi.Overall.FilePath);
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
        public MediaInfo2 MediaInfo2 { get; private set; }
        /// <summary>
        /// String Representation of Publish tab
        /// </summary>
        public string PublishString { get; set; }
        /// <summary>
        /// Options for Publishing
        /// </summary>
        public PublishOptionsPacket PublishOptions { get; set; }

    }
}
