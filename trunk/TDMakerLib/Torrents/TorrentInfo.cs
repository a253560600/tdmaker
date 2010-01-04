using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using TDMakerLib;
using TDMakerLib.Helpers;
using UploadersLib;
using UploadersLib.Helpers;
using UploadersLib.ImageUploaders;

namespace TDMakerLib
{
    public class TorrentInfo
    {
        private BackgroundWorker mBwApp = null;

        public TorrentInfo(BackgroundWorker bwApp, MediaInfo2 mi)
        {
            // load the MediaInfo object
            MyMedia = mi;

            string p = mi.Location;

            this.mBwApp = bwApp;

            if (Program.conf.TakeScreenshot)
            {
                if (mi.Overall != null && TakeScreenshot(mi.Overall.FilePath) &&
                    Program.conf.UploadScreenshot)
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
                string assemblyMTN = (Program.IsUNIX ? Program.conf.MTNPath.Replace(".exe", "") : Program.conf.MTNPath);
                if (string.IsNullOrEmpty(Path.GetDirectoryName(assemblyMTN)))
                {
                    assemblyMTN = Path.Combine(System.Windows.Forms.Application.StartupPath, assemblyMTN);
                    Program.conf.MTNPath = assemblyMTN;
                }

                string args = string.Format("{0} \"{1}\"", MyMedia.Screenshot.MTNArgs.Trim(), mediaFilePath);

                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo(assemblyMTN);

                if (Program.IsUNIX)
                {
                    psi.UseShellExecute = false;
                }

                Console.WriteLine("MTN Path: " + assemblyMTN);
                Console.WriteLine("MTN Args: " + args);

                psi.WindowStyle = (Program.conf.ShowMTNWindow ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden);
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
            string ssPath = Path.Combine(Program.GetScreenShotsDir(), Path.GetFileNameWithoutExtension(mediaFilePath) + MyMedia.Screenshot.Settings.o_OutputSuffix);
            ImageUploader imageUploader = null;

            if (File.Exists(ssPath))
            {
                ImageFileManager imf = null;

                switch ((ImageDestType2)Program.conf.ImageUploader)
                {
                    case ImageDestType2.IMAGESHACK:
                        imageUploader = new ImageShackUploader("16BCFGWY58707bec94f7b0a773d0aa8bbf301900", Program.conf.ImageShackRegCode, UploadMode.ANONYMOUS);
                        // ((ImageShackUploader)imageUploader).RandomizeFileName = Program.conf.ImageShakeRandomizeFileName;
                        break;
                    case ImageDestType2.TINYPIC:
                        imageUploader = new TinyPicUploader("e2aabb8d555322fa", "00a68ed73ddd54da52dc2d5803fa35ee", UploadMode.ANONYMOUS);
                        break;
                    case ImageDestType2.IMAGEBIN:
                        imageUploader = new ImageBin();
                        break;
                    case ImageDestType2.IMGUR:
                        imageUploader = new Imgur();
                        break;
                    default:
                        imageUploader = new UploadersLib.ImageUploaders.Imgur();
                        break;
                }

                if (imageUploader != null)
                {
                    int retry = 0;
                    while (retry <= 3 && imf == null || (retry <= 3 && imf != null && imf.ImageFileList.Count < 1))
                    {
                        retry++;
                        if (retry > 1)
                            Thread.Sleep(2000);
                        mBwApp.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, string.Format("Uploading {0} to {1}... Attempt {2}", Path.GetFileName(ssPath), imageUploader.Name, retry));
                        imf = imageUploader.UploadImage(ssPath);
                    }
                }

                if (imf != null && imf.ImageFileList.Count > 0)
                {
                    MyMedia.Screenshot.LocalPath = ssPath;
                    MyMedia.Screenshot.Full = imf.GetFullImageUrl();
                    MyMedia.Screenshot.LinkedThumbnail = imf.GetLinkedThumbnailForumUrl();

                    mBwApp.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, string.Format("Uploaded {0}.", Path.GetFileName(ssPath)));

                }
                else
                {
                    mBwApp.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, string.Format("Failed uploading {0}. Try again later.", Path.GetFileName(ssPath)));
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
