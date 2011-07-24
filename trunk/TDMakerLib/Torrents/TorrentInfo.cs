using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using UploadersLib;
using UploadersLib.HelperClasses;
using UploadersLib.ImageUploaders;

namespace TDMakerLib
{
    public class TorrentInfo
    {
        /// <summary>
        /// MediaInfo2 Object
        /// </summary>
        public MediaInfo2 MediaMy { get; set; }

        /// <summary>
        /// String Representation of Publish tab
        /// ToString() should be called at least once
        /// </summary>
        public string PublishString { get; set; }

        /// <summary>
        /// Options for Publishing
        /// </summary>
        public PublishOptionsPacket PublishOptions { get; set; }

        private BackgroundWorker BwAppMy = null;

        public TorrentInfo(MediaInfo2 mi)
        {
            this.MediaMy = mi;
        }

        public TorrentInfo(BackgroundWorker bwApp, MediaInfo2 mi)
            : this(mi)
        {
            this.BwAppMy = bwApp;
        }

        /// <summary>
        /// Createa and upload screenshots
        /// </summary>
        public void CreateScreenshots()
        {
            TakeScreenshots();
            UploadScreenshots();
        }

        public void CreateScreenshots(string ssDir)
        {
            TakeScreenshots(ssDir);
            UploadScreenshots();
        }

        private void TakeScreenshots()
        {
            foreach (MediaFile mf in this.MediaMy.MediaFiles)
            {
                TakeScreenshot(mf);
            }
        }

        private void TakeScreenshots(string ssDir)
        {
            foreach (MediaFile mf in this.MediaMy.MediaFiles)
            {
                TakeScreenshot(mf, ssDir);
            }
        }

        private void ReportProgress(ProgressType percentProgress, object userState)
        {
            if (BwAppMy != null)
            {
                BwAppMy.ReportProgress((int)percentProgress, userState);
            }
            else
            {
                switch (percentProgress)
                {
                    case ProgressType.UPDATE_STATUSBAR_DEBUG:
                        Console.WriteLine((string)userState);
                        break;
                    case ProgressType.UPDATE_SCREENSHOTS_LIST:
                        Screenshot ss = userState as Screenshot;
                        Console.WriteLine("Screenshot: " + ss.Full);
                        break;
                }
            }
        }

        private bool TakeScreenshot(MediaFile mf)
        {
            return TakeScreenshot(mf, FileSystem.GetScreenShotsDir(mf.FilePath));
        }

        private bool TakeScreenshot(MediaFile mf, string ssDir)
        {
            bool success = true;
            String mediaFilePath = mf.FilePath;
            Debug.WriteLine("Taking Screenshot for " + Path.GetFileName(mediaFilePath));

            ReportProgress(ProgressType.UPDATE_STATUSBAR_DEBUG, "Taking Screenshot for " + Path.GetFileName(mediaFilePath));

            try
            {
                Debug.WriteLine("Creating a MTN process...");
                string assemblyMTN = (Engine.IsUNIX ? Engine.conf.MTNPath.Replace(".exe", "") : Engine.conf.MTNPath);
                if (string.IsNullOrEmpty(Path.GetDirectoryName(assemblyMTN)))
                {
                    assemblyMTN = Path.Combine(System.Windows.Forms.Application.StartupPath, assemblyMTN);
                    Engine.conf.MTNPath = assemblyMTN;
                }

                mf.Screenshot.MTNArgs = Adapter.GetMtnArg(ssDir, Engine.mtnProfileMgr.GetMtnProfileActive());
                string args = string.Format("{0} \"{1}\"", mf.Screenshot.MTNArgs, mediaFilePath);

                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo(assemblyMTN);

                if (Engine.IsUNIX)
                {
                    psi.UseShellExecute = false;
                }

                Debug.WriteLine("MTN Path: " + assemblyMTN);
                Debug.WriteLine("MTN Args: " + args);

                psi.WindowStyle = (Engine.conf.ShowMTNWindow ? ProcessWindowStyle.Normal : ProcessWindowStyle.Minimized);
                Debug.WriteLine("MTN Window: " + psi.WindowStyle.ToString());
                psi.Arguments = args;

                p.StartInfo = psi;
                p.Start();
                p.WaitForExit(1000 * 30);

                if (Engine.IsUNIX)
                {
                    // Save _s.txt to MediaInfo2.Overall object
                    if (string.IsNullOrEmpty(MediaMy.Overall.Summary))
                    {
                        string info = Path.Combine(FileSystem.GetScreenShotsDir(mediaFilePath), Path.GetFileNameWithoutExtension(mediaFilePath) + Engine.mtnProfileMgr.GetMtnProfileActive().N_InfoSuffix);

                        using (StreamReader sr = new StreamReader(info))
                        {
                            MediaMy.Overall.Summary = sr.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                success = false;
                Debug.WriteLine(ex.ToString());
                ReportProgress(ProgressType.UPDATE_STATUSBAR_DEBUG, ex.Message + " for " + Path.GetFileName(mediaFilePath));
            }

            return success;
        }

        private void UploadScreenshots()
        {
            foreach (MediaFile mf in this.MediaMy.MediaFiles)
            {
                UploadResult ur = UploadScreenshot(mf.FilePath);
                if (ur != null && mf.Screenshot != null)
                {
                    mf.Screenshot.LocalPath = ur.LocalFilePath;
                    if (!string.IsNullOrEmpty(ur.URL))
                    {
                        mf.Screenshot.Full = ur.GetFullImageUrl();
                        mf.Screenshot.LinkedThumbnail = ur.ThumbnailURL;
                    }
                    ReportProgress(ProgressType.UPDATE_SCREENSHOTS_LIST, mf.Screenshot);
                }
            }
        }

        private UploadResult UploadScreenshot(string mediaFilePath)
        {
            string ssPath = Path.Combine(FileSystem.GetScreenShotsDir(mediaFilePath), Path.GetFileNameWithoutExtension(mediaFilePath) + Engine.mtnProfileMgr.GetMtnProfileActive().o_OutputSuffix);
            ImageUploader imageUploader = null;
            UploadResult ur = null;

            if (File.Exists(ssPath))
            {
                switch ((ImageUploaderType)Engine.conf.ImageUploader)
                {
                    case ImageUploaderType.TINYPIC:
                        imageUploader = new TinyPicUploader(ZKeys.TinyPicID, ZKeys.TinyPicKey, Engine.MyUploadersConfig.TinyPicAccountType,
                            Engine.MyUploadersConfig.TinyPicRegistrationCode);
                        break;
                    case ImageUploaderType.IMGUR:
                        imageUploader = new Imgur(Engine.MyUploadersConfig.ImgurAccountType, ZKeys.ImgurAnonymousKey, Engine.MyUploadersConfig.ImgurOAuthInfo);
                        break;
                    case ImageUploaderType.FileUploader:
                        ur = new UploadResult() { LocalFilePath = ssPath };
                        break;
                    default:
                        imageUploader = new ImageShackUploader(ZKeys.ImageShackKey, Engine.MyUploadersConfig.ImageShackAccountType,
                                  Engine.MyUploadersConfig.ImageShackRegistrationCode)
                        {
                            IsPublic = Engine.MyUploadersConfig.ImageShackShowImagesInPublic
                        };
                        break;
                }

                if (imageUploader != null)
                {
                    if (Engine.conf.ProxyEnabled)
                    {
                        ProxySettings proxy = new ProxySettings();
                        proxy.ProxyActive = Engine.conf.ProxySettings;
                        Uploader.ProxySettings = proxy;
                    }

                    ur = imageUploader.Upload(ssPath);
                }

                if (ur != null)
                {
                    if (!string.IsNullOrEmpty(ur.URL))
                    {
                        ur.LocalFilePath = ssPath;
                        ReportProgress(ProgressType.UPDATE_STATUSBAR_DEBUG, string.Format("Uploaded {0}.", Path.GetFileName(ssPath)));
                    }
                }
                else
                {
                    ReportProgress(ProgressType.UPDATE_STATUSBAR_DEBUG, string.Format("Failed uploading {0}. Try again later.", Path.GetFileName(ssPath)));
                }
            }
            return ur;
        }

        /// <summary>
        /// Create Publish based on a Template
        /// </summary>
        /// <param name="tr"></param>
        /// <returns></returns>
        public string CreatePublish(PublishOptionsPacket options, TemplateReader2 tr)
        {
            tr.SetFullScreenshot(options.FullPicture);
            tr.CreateInfo();

            StringBuilder sbPublish = new StringBuilder();
            sbPublish.Append(GetMediaInfo(tr.PublishInfo, options));

            return sbPublish.ToString();
        }

        public string CreatePublishMediaInfo(PublishOptionsPacket pop)
        {
            StringBuilder sbPublish = new StringBuilder();
            StringBuilder sbMediaInfo = new StringBuilder();
            foreach (MediaFile mf in MediaMy.MediaFiles)
            {
                sbMediaInfo.AppendLine(BbCode.Bold(mf.FileName));
                sbMediaInfo.AppendLine();
                sbMediaInfo.AppendLine(mf.Summary.Trim());
                sbMediaInfo.AppendLine();
            }
            sbPublish.AppendLine(GetMediaInfo(sbMediaInfo.ToString(), pop));
            foreach (MediaFile mf in MediaMy.MediaFiles)
            {
                sbPublish.AppendLine(mf.GetScreenshotString(pop));
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
        public string CreatePublishInternal(PublishOptionsPacket pop)
        {
            StringBuilder sbPublish = new StringBuilder();
            string info = MediaMy.MediaTypeChoice == MediaType.MusicAudioAlbum ? MediaMy.ToStringAudio() : MediaMy.ToStringMedia(pop);
            sbPublish.Append(GetMediaInfo(info, pop));

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
            return Path.GetFileName(this.MediaMy.Location);
        }
    }
}