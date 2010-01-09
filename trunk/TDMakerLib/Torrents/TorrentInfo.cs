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

        private BackgroundWorker mBwApp = null;

        public TorrentInfo(BackgroundWorker bwApp, MediaInfo2 mi)
        {
            // load the MediaInfo object
            MyMedia = mi;

            string p = mi.Location;

            this.mBwApp = bwApp;

            if (mi.UploadScreenshots)
            {
                TakeScreenshots();
                UploadScreenshots();
            }
        }

        private void TakeScreenshots()
        {
            foreach (MediaFile mf in this.MyMedia.MediaFiles)
            {
                TakeScreenshot(mf);
            }
        }

        private bool TakeScreenshot(MediaFile mf)
        {
            bool success = true;
            String mediaFilePath = mf.FilePath;
            Debug.WriteLine("Taking Screenshot for " + Path.GetFileName(mediaFilePath));
            mBwApp.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, "Taking Screenshot for " + Path.GetFileName(mediaFilePath));

            try
            {
                Debug.WriteLine("Creating a MTN process...");
                string assemblyMTN = (Engine.IsUNIX ? Engine.conf.MTNPath.Replace(".exe", "") : Engine.conf.MTNPath);
                if (string.IsNullOrEmpty(Path.GetDirectoryName(assemblyMTN)))
                {
                    assemblyMTN = Path.Combine(System.Windows.Forms.Application.StartupPath, assemblyMTN);
                    Engine.conf.MTNPath = assemblyMTN;
                }

                mf.Screenshot.MTNArgs = Adapter.GetMtnArg(Path.GetDirectoryName(mf.FilePath), Engine.mtnProfileMgr.GetMtnProfileActive());
                string args = string.Format("{0} \"{1}\"", mf.Screenshot.MTNArgs, mediaFilePath);

                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo(assemblyMTN);

                if (Engine.IsUNIX)
                {
                    psi.UseShellExecute = false;
                }

                Debug.WriteLine("MTN Path: " + assemblyMTN);
                Debug.WriteLine("MTN Args: " + args);

                psi.WindowStyle = (Engine.conf.ShowMTNWindow ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden);
                Debug.WriteLine("MTN Window: " + psi.WindowStyle.ToString());
                psi.Arguments = args;

                p.StartInfo = psi;
                p.Start();
                p.WaitForExit(1000 * 30);

                if (Engine.IsUNIX)
                {
                    // Save _s.txt to MediaInfo2.Overall object
                    if (string.IsNullOrEmpty(MyMedia.Overall.Summary))
                    {
                        string info = Path.Combine(Engine.GetScreenShotsDir(mediaFilePath), Path.GetFileNameWithoutExtension(mediaFilePath) + Engine.mtnProfileMgr.GetMtnProfileActive().N_InfoSuffix);

                        using (StreamReader sr = new StreamReader(info))
                        {
                            MyMedia.Overall.Summary = sr.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                success = false;
                Debug.WriteLine(ex.ToString());
                mBwApp.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, ex.Message + " for " + Path.GetFileName(mediaFilePath));
            }

            return success;
        }

        private void UploadScreenshots()
        {
            foreach (MediaFile mf in this.MyMedia.MediaFiles)
            {
                ImageFileManager imf = UploadScreenshot(mf.FilePath);
                if (imf != null)
                {
                    mf.Screenshot.LocalPath = imf.LocalFilePath;
                    if (imf.ImageFileList != null && imf.ImageFileList.Count > 0)
                    {
                        mf.Screenshot.Full = imf.GetFullImageUrl();
                        mf.Screenshot.LinkedThumbnail = imf.GetLinkedThumbnailForumUrl();
                    }
                    mBwApp.ReportProgress((int)ProgressType.UPDATE_SCREENSHOTS_LIST, mf.Screenshot);
                }
            }
        }

        private ImageFileManager UploadScreenshot(string mediaFilePath)
        {
            string ssPath = Path.Combine(Engine.GetScreenShotsDir(mediaFilePath), Path.GetFileNameWithoutExtension(mediaFilePath) + Engine.mtnProfileMgr.GetMtnProfileActive().o_OutputSuffix);
            ImageUploader imageUploader = null;
            ImageFileManager imf = null;

            if (File.Exists(ssPath))
            {
                switch ((ImageDestType2)Engine.conf.ImageUploader)
                {
                    case ImageDestType2.IMAGESHACK:
                        imageUploader = new ImageShackUploader("16BCFGWY58707bec94f7b0a773d0aa8bbf301900", Engine.conf.ImageShackRegCode, UploadMode.ANONYMOUS);
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
                    case ImageDestType2.FILE:
                        imf = new ImageFileManager() { LocalFilePath = ssPath };
                        break;
                    default:
                        imageUploader = new UploadersLib.ImageUploaders.Imgur();
                        break;
                }

                if (imageUploader != null)
                {
                    int retry = 0;

                    if (Engine.conf.ProxyEnabled)
                    {
                        ProxySettings proxy = new ProxySettings();
                        proxy.ProxyEnabled = true;
                        proxy.ProxyActive = Engine.conf.ProxySettings;
                        Uploader.ProxySettings = proxy;
                    }

                    while (retry <= 3 && imf == null || (retry <= 3 && imf != null && imf.ImageFileList.Count < 1))
                    {
                        retry++;
                        if (retry > 1)
                            Thread.Sleep(2000);
                        mBwApp.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, string.Format("Uploading {0} to {1}... Attempt {2}", Path.GetFileName(ssPath), imageUploader.Name, retry));
                        imf = imageUploader.UploadImage(ssPath);
                    }
                }

                if (imf != null)
                {
                    if (imf.ImageFileList.Count > 0)
                    {
                        imf.LocalFilePath = ssPath;
                        mBwApp.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, string.Format("Uploaded {0}.", Path.GetFileName(ssPath)));
                    }
                }
                else
                {
                    mBwApp.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, string.Format("Failed uploading {0}. Try again later.", Path.GetFileName(ssPath)));
                }
            }
            return imf;
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

        public string CreatePublishMediaInfo(PublishOptionsPacket options)
        {
            StringBuilder sbPublish = new StringBuilder();
            StringBuilder sbMediaInfo = new StringBuilder();
            foreach (MediaFile mf in MyMedia.MediaFiles)
            {
                sbMediaInfo.AppendLine(BbCode.Bold(mf.FileName));
                sbMediaInfo.AppendLine();
                sbMediaInfo.AppendLine(mf.Summary);
            }
            sbPublish.AppendLine(GetMediaInfo(sbMediaInfo.ToString(), options));
            foreach (MediaFile mf in MyMedia.MediaFiles)
            {
                sbPublish.AppendLine(mf.GetScreenshotString());
            }
            return sbPublish.ToString();
        }

        /// <summary>
        /// Create Publish based on Default (built-in) Template. 
        /// Uses ToString() method of MediaInfo2
        /// </summary>
        /// <param name="ti"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public string CreatePublishInternal(PublishOptionsPacket options)
        {
            foreach (MediaFile mf in this.MyMedia.MediaFiles)
            {
                mf.PublishOptions = options;
            }

            StringBuilder sbPublish = new StringBuilder();
            string info = MyMedia.MediaTypeChoice == MediaType.MUSIC_AUDIO_ALBUM ? MyMedia.ToStringAudio() : MyMedia.ToStringMedia();
            sbPublish.Append(GetMediaInfo(info, options));

            return sbPublish.ToString().Trim();
        }

        public string GetMediaInfo(string p, PublishOptionsPacket options)
        {
            StringBuilder sbPublish = new StringBuilder();

            if (options.AlignCenter)
            {
                p = BbCode.AlignCenter(p);
            }

            if (options.PreformattedText)
            {
                sbPublish.AppendLine(BbCode.Pre(p));
            }
            else
            {
                sbPublish.AppendLine(p);
            }

            return sbPublish.ToString();

        }

        /// <summary>
        /// Default Publish String representation of a Torrent
        /// </summary>
        /// <returns>Publish String</returns>
        public string ToStringPublish()
        {
            return CreatePublishInternal(this.PublishOptions);
        }

        public override string ToString()
        {
            return Path.GetFileName(this.MyMedia.Location);
        }

    }
}
