using HelpersLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using UploadersLib;
using UploadersLib.HelperClasses;
using UploadersLib.ImageUploaders;
using UploadersLib.URLShorteners;

namespace TDMakerLib
{
    public class TorrentInfo
    {
        /// <summary>
        /// MediaInfo2 Object
        /// </summary>
        public MediaInfo2 Media { get; set; }

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
            this.Media = mi;
        }

        public TorrentInfo(BackgroundWorker bwApp, MediaInfo2 mi)
            : this(mi)
        {
            this.BwAppMy = bwApp;
        }

        /// <summary>
        /// Createa and upload screenshots
        /// </summary>
        public void CreateUploadScreenshots()
        {
            TakeScreenshots();
            UploadScreenshots();
        }

        public void CreateUploadScreenshots(string ssDir)
        {
            TakeScreenshots(ssDir);
            UploadScreenshots();
        }

        private bool TakeScreenshot(MediaFile mf, string ssDir)
        {
            bool success = true;
            String mediaFilePath = mf.FilePath;
            Debug.WriteLine("Taking Screenshot for " + Path.GetFileName(mediaFilePath));
            ReportProgress(ProgressType.UPDATE_STATUSBAR_DEBUG, "Taking Screenshot for " + Path.GetFileName(mediaFilePath));

            switch (Engine.conf.ThumbnailerType)
            {
                case ThumbnailerType.MovieThumbnailer:
                    mf.Thumbnailer = new MovieThumbNailer(mf, ssDir);
                    break;

                case ThumbnailerType.MPlayer:
                    mf.Thumbnailer = new MPlayerThumbnailer(mf, ssDir, Engine.conf.MPlayerOptions);
                    break;
            }

            try
            {
                mf.Thumbnailer.TakeScreenshot();
            }
            catch (Exception ex)
            {
                success = false;
                Debug.WriteLine(ex.ToString());
                ReportProgress(ProgressType.UPDATE_STATUSBAR_DEBUG, ex.Message + " for " + Path.GetFileName(mediaFilePath));
            }

            if (Engine.IsUNIX)
            {
                // Save _s.txt to MediaInfo2.Overall object
                if (string.IsNullOrEmpty(Media.Overall.Summary))
                {
                    Media.Overall.Summary = mf.Thumbnailer.MediaSummary;
                }
            }

            return success;
        }

        private void TakeScreenshots(string ssDir)
        {
            switch (this.Media.MediaTypeChoice)
            {
                case MediaType.MediaCollection:
                case MediaType.MediaIndiv:
                    foreach (MediaFile mf in this.Media.MediaFiles)
                    {
                        TakeScreenshot(mf, ssDir);
                    }
                    break;

                case MediaType.MediaDisc:
                    TakeScreenshot(this.Media.Overall, ssDir);
                    break;
            }
        }

        public void TakeScreenshots()
        {
            switch (Media.MediaTypeChoice)
            {
                case MediaType.MediaDisc:
                    TakeScreenshot(this.Media.Overall, FileSystem.GetScreenShotsDir(this.Media.Overall.FilePath));
                    break;

                default:
                    foreach (MediaFile mf in this.Media.MediaFiles)
                    {
                        TakeScreenshot(mf, FileSystem.GetScreenShotsDir(mf.FilePath));
                    }
                    break;
            }
        }

        public void UploadScreenshots()
        {
            if (Media.UploadScreenshots)
            {
                switch (Media.MediaTypeChoice)
                {
                    case MediaType.MediaDisc:
                        UploadScreenshots(Media.Overall);
                        break;

                    default:
                        foreach (MediaFile mf in this.Media.MediaFiles)
                        {
                            UploadScreenshots(mf);
                        }
                        break;
                }
            }
        }

        private void UploadScreenshots(MediaFile mf)
        {
            if (Media.UploadScreenshots)
            {
                foreach (Screenshot ss in mf.Thumbnailer.Screenshots)
                {
                    if (ss != null)
                    {
                        ReportProgress(ProgressType.UPDATE_SCREENSHOTS_LIST, ss);

                        UploadResult ur = UploadScreenshot(ss.LocalPath);

                        if (ur != null)
                        {
                            if (!string.IsNullOrEmpty(ur.URL))
                            {
                                ss.FullImageLink = ur.URL;
                                ss.LinkedThumbnail = ur.ThumbnailURL;
                            }
                        }
                    }
                }
            }
        }

        private UploadResult UploadScreenshot(string ssPath)
        {
            ImageUploader imageUploader = null;
            UploadResult ur = null;

            if (File.Exists(ssPath))
            {
                if (!string.IsNullOrEmpty(Engine.conf.PtpImgCode))
                {
                    imageUploader = new PtpImageUploader(Crypt.Decrypt(Engine.conf.PtpImgCode));
                }
                else
                {
                    switch ((ImageDestination)Engine.conf.ImageUploaderType)
                    {
                        case ImageDestination.TinyPic:
                            imageUploader = new TinyPicUploader(ZKeys.TinyPicID, ZKeys.TinyPicKey, Engine.UploadersConfig.TinyPicAccountType,
                                Engine.UploadersConfig.TinyPicRegistrationCode);
                            break;

                        case ImageDestination.Imgur:
                            imageUploader = new Imgur(Engine.UploadersConfig.ImgurAccountType, ZKeys.ImgurAnonymousKey, Engine.UploadersConfig.ImgurOAuthInfo);
                            break;

                        case ImageDestination.Flickr:
                            imageUploader = new FlickrUploader(ApiKeys.FlickrKey, ApiKeys.FlickrSecret, Engine.UploadersConfig.FlickrAuthInfo, Engine.UploadersConfig.FlickrSettings);
                            break;

                        case ImageDestination.Photobucket:
                            imageUploader = new Photobucket(Engine.UploadersConfig.PhotobucketOAuthInfo, Engine.UploadersConfig.PhotobucketAccountInfo);
                            break;

                        case ImageDestination.Immio:
                            imageUploader = new ImmioUploader();
                            break;

                        case ImageDestination.Picasa:
                            imageUploader = new Picasa(Engine.UploadersConfig.PicasaOAuthInfo);
                            break;

                        case ImageDestination.UploadScreenshot:
                            imageUploader = new UploadScreenshot(ApiKeys.UploadScreenshotKey);
                            break;

                        case ImageDestination.Twitpic:
                            int indexTwitpic = Engine.UploadersConfig.TwitterSelectedAccount;

                            if (Engine.UploadersConfig.TwitterOAuthInfoList != null && Engine.UploadersConfig.TwitterOAuthInfoList.IsValidIndex(indexTwitpic))
                            {
                                imageUploader = new TwitPicUploader(ApiKeys.TwitPicKey, Engine.UploadersConfig.TwitterOAuthInfoList[indexTwitpic])
                                {
                                    TwitPicThumbnailMode = Engine.UploadersConfig.TwitPicThumbnailMode,
                                    ShowFull = Engine.UploadersConfig.TwitPicShowFull
                                };
                            }
                            break;

                        case ImageDestination.Twitsnaps:
                            int indexTwitsnaps = Engine.UploadersConfig.TwitterSelectedAccount;

                            if (Engine.UploadersConfig.TwitterOAuthInfoList.IsValidIndex(indexTwitsnaps))
                            {
                                imageUploader = new TwitSnapsUploader(ApiKeys.TwitsnapsKey, Engine.UploadersConfig.TwitterOAuthInfoList[indexTwitsnaps]);
                            }
                            break;

                        case ImageDestination.yFrog:
                            YfrogOptions yFrogOptions = new YfrogOptions(ApiKeys.ImageShackKey);
                            yFrogOptions.Username = Engine.UploadersConfig.YFrogUsername;
                            yFrogOptions.Password = Engine.UploadersConfig.YFrogPassword;
                            yFrogOptions.Source = Application.ProductName;
                            imageUploader = new YfrogUploader(yFrogOptions);
                            break;

                        case ImageDestination.FileUploader:
                            ur = new UploadResult() { LocalFilePath = ssPath };
                            break;

                        default:
                            imageUploader = new ImageShackUploader(ZKeys.ImageShackKey, Engine.UploadersConfig.ImageShackAccountType,
                                      Engine.UploadersConfig.ImageShackRegistrationCode)
                            {
                                IsPublic = Engine.UploadersConfig.ImageShackShowImagesInPublic
                            };
                            break;
                    }
                }

                if (imageUploader != null)
                {
                    if (Engine.conf.ProxyEnabled)
                    {
                        ProxySettings proxy = new ProxySettings();
                        proxy.ProxyConfig = EProxyConfigType.ManualProxy;
                        proxy.ProxyActive = Engine.conf.ProxySettings;
                        Uploader.ProxySettings = proxy;
                    }
                    else
                    {
                        Uploader.ProxySettings = new ProxySettings();
                    }

                    ReportProgress(ProgressType.UPDATE_STATUSBAR_DEBUG, string.Format("Uploading {0}.", Path.GetFileName(ssPath)));
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

            switch (Media.MediaTypeChoice)
            {
                case MediaType.MediaDisc:
                    sbMediaInfo.AppendLine(Media.Overall.Summary.Trim());
                    sbMediaInfo.AppendLine();
                    break;

                default:
                    foreach (MediaFile mf in Media.MediaFiles)
                    {
                        sbMediaInfo.AppendLine(BbCode.Bold(mf.FileName));
                        sbMediaInfo.AppendLine();
                        sbMediaInfo.AppendLine(mf.Summary.Trim());
                        sbMediaInfo.AppendLine();
                    }

                    break;
            }

            sbPublish.AppendLine(GetMediaInfo(sbMediaInfo.ToString(), pop));

            if (Media.UploadScreenshots)
            {
                switch (Media.MediaTypeChoice)
                {
                    case MediaType.MediaDisc:
                        sbPublish.AppendLine(Media.Overall.GetScreenshotString(pop));
                        break;

                    default:
                        foreach (MediaFile mf in Media.MediaFiles)
                        {
                            sbPublish.AppendLine(mf.GetScreenshotString(pop));
                        }
                        break;
                }
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
            string info = Media.MediaTypeChoice == MediaType.MusicAudioAlbum ? Media.ToStringAudio() : Media.ToStringMedia(pop);
            sbPublish.Append(GetMediaInfo(info, pop));

            return sbPublish.ToString().Trim();
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
                        Console.WriteLine("Screenshot: " + ss.FullImageLink);
                        break;
                }
            }
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
            return Path.GetFileName(this.Media.Location);
        }
    }
}