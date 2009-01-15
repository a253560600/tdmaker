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
            {
                UploadScreenshot(mi.Overall.FilePath);
            }

        }

        private void UploadScreenshot(String mediaFilePath)
        {

            Process p = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(Settings.Default.MTNPath);
            psi.WindowStyle = ProcessWindowStyle.Minimized;

            if (!Settings.Default.KeepScreenshot)
            {
                Program.ScreenshotsDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TDMaker");
            }

            if (!Directory.Exists(Program.ScreenshotsDir))
                Directory.CreateDirectory(Program.ScreenshotsDir);

            psi.Arguments = string.Format("{0} -O \"{1}\" \"{2}\"",
                Settings.Default.MTNArg,
                Program.ScreenshotsDir,
                mediaFilePath);

            p.StartInfo = psi;
            p.Start();
            p.WaitForExit();

            string screenshot = Path.Combine(Program.ScreenshotsDir, Path.GetFileNameWithoutExtension(mediaFilePath) + "_s.jpg");

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

                if (!Settings.Default.KeepScreenshot)
                {
                    // delete if option set to temporary location 
                    File.Delete(screenshot);
                }

            }

        }

        /// <summary>
        /// Create Publish based on a Template
        /// </summary>
        /// <param name="tr"></param>
        /// <returns></returns>
        public string CreatePublish(PublishOptionsPacket options, TemplateReader tr)
        {
            tr.CreateInfo();

            StringBuilder sbPublish = new StringBuilder();
            sbPublish.Append(GetMediaInfo(tr.PublishInfo, options));
            sbPublish.AppendLine();
            sbPublish.Append(GetScreenshotString(options));

            return sbPublish.ToString();
        }

        /// <summary>
        /// Create Publish based on Default (built-in) Template. 
        /// Uses ToString() method of MediaInfo2
        /// </summary>
        /// <param name="ti"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public string CreatePublish(PublishOptionsPacket options)
        {

            StringBuilder sbPublish = new StringBuilder();

            sbPublish.Append(GetMediaInfo(this.MediaInfo2.ToString(), options));
            sbPublish.AppendLine();
            sbPublish.Append(GetScreenshotString(options));

            return sbPublish.ToString();

        }

        public string GetMediaInfo(string p, PublishOptionsPacket options)
        {
            StringBuilder sbPublish = new StringBuilder();
            BbCode bb = new BbCode();

            if (options.AlignCenter)
            {
                p = bb.alignCenter(p);
            }

            if (options.PreformattedText)
            {
                sbPublish.AppendLine(bb.pre(p));
            }
            else
            {
                sbPublish.AppendLine(p);
            }

            return sbPublish.ToString();

        }

        public string GetScreenshotString(PublishOptionsPacket options)
        {
            StringBuilder sbPublish = new StringBuilder();
            BbCode bb = new BbCode();

            if (!string.IsNullOrEmpty(this.ScreenshotURLFull) && options.FullPicture)
            {
                sbPublish.AppendLine(bb.img(this.ScreenshotURLFull));
            }
            else if (!string.IsNullOrEmpty(this.ScreenshotURLForums))
            {
                sbPublish.AppendLine(this.ScreenshotURLForums);
            }

            return sbPublish.ToString();
        }

        /// <summary>
        /// Default Publish String representation of a Torrent
        /// </summary>
        /// <returns>Publish String</returns>
        public override string ToString()
        {
            return CreatePublish(this.PublishOptions);
        }

        public string ScreenshotURLForums { get; private set; }
        public string ScreenshotURLFull { get; private set; }
        public MediaInfo2 MediaInfo2 { get; private set; }
        /// <summary>
        /// String Representation of Publish tab
        /// ToString() should be called at least once
        /// </summary>
        public string PublishString { get; set; }
        /// <summary>
        /// Options for Publishing
        /// </summary>
        public PublishOptionsPacket PublishOptions { get; set; }

    }
}
