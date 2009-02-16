﻿using System;
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
using TDMaker.Helpers;
using ZSS.ImageUploader.Helpers;

namespace TorrentDescriptionMaker
{
    class TorrentInfo
    {
        private BackgroundWorker mBwApp = null;

        public TorrentInfo(BackgroundWorker bwApp, MediaInfo2 mi)
        {
            // load the MediaInfo object
            MyMedia = mi;

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

                string assemblyMTN = (Program.IsUNIX ? Settings.Default.MTNPath.Replace(".exe", "") : Settings.Default.MTNPath);

                string args = string.Format("{0} \"{1}\"", MyMedia.Screenshot.MTNArgs.Trim(), mediaFilePath);

                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo(assemblyMTN);

                if (Program.IsUNIX)
                {
                    psi.UseShellExecute = false;
                }

                Console.WriteLine("MTN Path: " + assemblyMTN);
                Console.WriteLine("MTN Args: " + args);

                psi.WindowStyle = (Settings.Default.ShowMTNWindow ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden);
                Console.WriteLine("MTN Window: " + psi.WindowStyle.ToString());
                psi.Arguments = args;

                p.StartInfo = psi;
                p.Start();
                p.WaitForExit(1000 * 30);

                if (Program.IsUNIX)
                {
                    // Save _s.txt to MediaInfo2.Overall object
                    if (string.IsNullOrEmpty(MyMedia.Overall.Summary))
                    {
                        string info = Path.Combine(Program.GetScreenShotsDir(), Path.GetFileNameWithoutExtension(mediaFilePath) + MyMedia.Screenshot.Settings.N_InfoSuffix);

                        using (StreamReader sr = new StreamReader(info))
                        {
                            MyMedia.Overall.Summary = sr.ReadToEnd();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                succes = false;
                Console.WriteLine(ex.ToString());
                mBwApp.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, ex.Message + " for " + Path.GetFileName(mediaFilePath));
            }

            return succes;

        }

       private void UploadScreenshot(String mediaFilePath)
        {
            string screenshot = Path.Combine(Program.GetScreenShotsDir(), Path.GetFileNameWithoutExtension(mediaFilePath) + MyMedia.Screenshot.Settings.o_OutputSuffix);
            HTTPUploader imageUploader = null;

            if (File.Exists(screenshot))
            {
                ImageFileManager imf = null;

                switch ((ScreenshotDestType)Settings.Default.ScreenshotDestIndex)
                {
                    case ScreenshotDestType.IMAGESHACK:
                        imageUploader = new ImageShackUploader("16BCFGWY58707bec94f7b0a773d0aa8bbf301900", Settings.Default.ImageShackRegCode, UploadMode.API);
                        ((ImageShackUploader)imageUploader).RandomizeFileName = Settings.Default.ImageShakeRandomizeFileName;
                        break;
                    case ScreenshotDestType.TINYPIC:
                        imageUploader = new TinyPicUploader("e2aabb8d555322fa", "00a68ed73ddd54da52dc2d5803fa35ee");
                        break;
                    case ScreenshotDestType.IMAGESHACK_LEGACY_METHOD:
                        imageUploader = new ImageShackUploader();
                        break;
                    case ScreenshotDestType.XSTO:
                        imageUploader = new XsToUploader();
                        break;
                }

                if (imageUploader != null)
                {
                    int retry = 0;
                    while (retry <= 3 && imf == null || (retry <= 3 && imf != null && imf.FileCount < 1))
                    {
                        retry++;
                        if (retry > 1)
                            Thread.Sleep(2000);
                        mBwApp.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, string.Format("Uploading {0} to {1}... Attempt {2}", Path.GetFileName(screenshot), imageUploader.Name, retry));
                        imf = imageUploader.UploadImage(screenshot);                      
                    }
                }

                if (imf != null && imf.FileCount > 0)
                {
                    MyMedia.Screenshot.Full = imf.GetFullImageUrl();
                    MyMedia.Screenshot.LinkedThumbnail = imf.GetLinkedThumbnailUrl();

                    mBwApp.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, string.Format("Uploaded {0}.", Path.GetFileName(screenshot)));

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
            string info = this.MyMedia.ToString();

            sbPublish.Append(GetMediaInfo(info, options));
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

            if (!string.IsNullOrEmpty(MyMedia.Screenshot.Full) && options.FullPicture)
            {
                sbPublish.AppendLine(bb.Img(MyMedia.Screenshot.Full));
            }
            else if (!string.IsNullOrEmpty(MyMedia.Screenshot.LinkedThumbnail))
            {
                sbPublish.AppendLine(MyMedia.Screenshot.LinkedThumbnail);
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

        /// <summary>
        /// MediaInfo2 Object
        /// </summary>
        public MediaInfo2 MyMedia { get; set; }
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
