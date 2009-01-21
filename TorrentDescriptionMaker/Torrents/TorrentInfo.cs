using System;
using System.Collections.Generic;
using System.Diagnostics;
using TDMaker.Properties;
using System.IO;
using MediaInfoLib;
using System.Text;
using System.ComponentModel;
using TDMaker;
using ZSS.ImageUploader;
using System.Threading;

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

            if (Settings.Default.TakeScreenshot)
            {
                if (mi.Overall != null && TakeScreenshot(mi.Overall.FilePath) &&
                    Settings.Default.UploadScreenshot)
                {
                    UploadScreenshot(mi.Overall.FilePath);
                }
            }

        }

        private bool TakeScreenshot(String mediaFilePath)
        {
            bool succes = true;
            Console.WriteLine("Taking Screenshot for " + Path.GetFileName(mediaFilePath));
            mBwApp.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, "Taking Screenshot for " + Path.GetFileName(mediaFilePath));

            try
            {
                Console.WriteLine("Creating a MTN process...");
                
                string assemblyMTN = Settings.Default.MTNPath;
                string args = string.Format("{0} -O \"{1}\" \"{2}\"", Settings.Default.MTNArg.Trim(), Program.GetScreenShotsDir(), mediaFilePath);

                if (Program.IsUNIX)
                {
                    assemblyMTN = Settings.Default.MTNPath.Replace(".exe", "");
                    args = args.Replace("-f arial.ttf", "-i -t");
                }

                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo(assemblyMTN);

                if (Program.IsUNIX)
                {
                    psi.UseShellExecute = false;
                }

                Console.WriteLine("MTN Path: " + assemblyMTN);
                Console.WriteLine("MTN Args: " + args);

                Environment.CurrentDirectory = Path.GetDirectoryName(assemblyMTN);
                               
                psi.WindowStyle = (Settings.Default.ShowMTNWindow ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden);

                psi.Arguments = args;

                p.StartInfo = psi;
                p.Start();
                p.WaitForExit(1000 * 30);
            }
            catch (Exception ex)
            {
                succes = false;
                Console.WriteLine(ex.ToString());
                mBwApp.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, ex.Message + " for " + Path.GetFileName(mediaFilePath));                
            }

            return succes;

        }

        private List<ImageFile> UploadImageShack(string screenshot, bool linq)
        {
            List<ZSS.ImageUploader.ImageFile> lstScreenshots = new List<ImageFile>();
            int retry = 0;
            ImageShackUploader su = new ImageShackUploader();

            if (linq)
            {
                su.DeveloperKey = "16BCFGWY58707bec94f7b0a773d0aa8bbf301900";
                if (Settings.Default.UseImageShackRegCode && !string.IsNullOrEmpty(Settings.Default.ImageShackRegCode))
                {
                    su.RegistrationCode = Settings.Default.ImageShackRegCode;
                }
                su.Public = false;
                su.RandomizeFileName = Settings.Default.ImageShakeRandomizeFileName;
            }                        

            while (retry <= 3 && lstScreenshots == null ||
               (++retry <= 3 && lstScreenshots != null && lstScreenshots.Count < 1))
            {
                if (retry > 1)
                    Thread.Sleep(1000);
                mBwApp.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, string.Format("Uploading {0} to ImageShack... Attempt {1}", Path.GetFileName(screenshot), retry));
                if (linq)
                {
                    lstScreenshots = su.UploadImage(screenshot);
                }
                else
                {
                    lstScreenshots = su.UploadImageLegacy(screenshot);
                }
            }
            return lstScreenshots;

        }

        private List<ImageFile> UploadTinyPic(string screenshot)
        {
            List<ZSS.ImageUploader.ImageFile> lstScreenshots = new List<ImageFile>();
            int retry = 0;
            TinyPicUploader tpu = new TinyPicUploader("e2aabb8d555322fa", "00a68ed73ddd54da52dc2d5803fa35ee");
            while (retry <= 3 && lstScreenshots == null ||
               (++retry <= 3 && lstScreenshots != null && lstScreenshots.Count < 1))
            {
                if (retry > 1)
                    Thread.Sleep(2000);
                mBwApp.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, string.Format("Uploading {0} to TinyPic... Attempt {1}", Path.GetFileName(screenshot), retry));
                lstScreenshots = tpu.UploadImage(screenshot);
            }
            return lstScreenshots;
        }

        private void UploadScreenshot(String mediaFilePath)
        {

            string screenshot = Path.Combine(Program.GetScreenShotsDir(), Path.GetFileNameWithoutExtension(mediaFilePath) + "_s.jpg");

            if (File.Exists(screenshot))
            {
                List<ZSS.ImageUploader.ImageFile> lstScreenshots = new List<ImageFile>();

                switch ((ScreenshotDestType)Settings.Default.ScreenshotDestIndex)
                {
                    case ScreenshotDestType.IMAGESHACK:
                        lstScreenshots = UploadImageShack(screenshot, true);
                        break;
                    case ScreenshotDestType.TINYPIC:
                        lstScreenshots = UploadTinyPic(screenshot);
                        break;
                    case ScreenshotDestType.IMAGESHACK_LEGACY_METHOD:
                        lstScreenshots = UploadImageShack(screenshot, false);
                        break;
                }

                if (lstScreenshots != null && lstScreenshots.Count > 0)
                {
                    ScreenshotsPacket sp = new ScreenshotsPacket();

                    foreach (ImageFile imf in lstScreenshots)
                    {
                        if (imf.Type == ImageFile.ImageType.FULLIMAGE)
                        {
                            sp.Full = imf.URI;
                        }
                        else if (imf.Type == ImageFile.ImageType.THUMBNAIL_FORUMS1)
                        {
                            sp.LinkedThumbnail = imf.URI;
                        }
                    }

                    mBwApp.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, string.Format("Uploaded {0}.", Path.GetFileName(screenshot)));
                    MediaInfo2.Screenshot = sp;
                }
                else
                {                    
                    mBwApp.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, string.Format("Failed uploading {0}. Try again later.", Path.GetFileName(screenshot)));
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
            tr.SetFullScreenshot(options.FullPicture);
            tr.CreateInfo();

            StringBuilder sbPublish = new StringBuilder();
            sbPublish.Append(GetMediaInfo(tr.PublishInfo, options));

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
                p = bb.AlignCenter(p);
            }

            if (options.PreformattedText)
            {
                sbPublish.AppendLine(bb.Pre(p));
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

            if (!string.IsNullOrEmpty(MediaInfo2.Screenshot.Full) && options.FullPicture)
            {
                sbPublish.AppendLine(bb.Img(MediaInfo2.Screenshot.Full));
            }
            else if (!string.IsNullOrEmpty(MediaInfo2.Screenshot.LinkedThumbnail))
            {
                sbPublish.AppendLine(MediaInfo2.Screenshot.LinkedThumbnail);
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

        public MediaInfo2 MediaInfo2 { get; set; }
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
