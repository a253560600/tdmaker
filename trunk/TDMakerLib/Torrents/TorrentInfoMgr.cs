using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDMakerLib
{
    public class TorrentInfoMgr
    {
        public List<TorrentInfo> TorrentInfos { get; set; }

        /// <summary>
        /// Options for Publishing
        /// </summary>
        public PublishOptionsPacket PublishOptions { get; set; }

        public TorrentInfoMgr()
        {
            this.TorrentInfos = new List<TorrentInfo>();
        }

        public TorrentInfoMgr(List<TorrentInfo> listTorentInfo)
        {
            this.TorrentInfos = listTorentInfo;
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
            foreach (TorrentInfo ti in this.TorrentInfos)
            {
                string info = ti.MyMedia.ToString();
                sbPublish.Append(GetMediaInfo(info, options));
                sbPublish.AppendLine();
                sbPublish.Append(GetScreenshotString(ti, options));
            }
            return sbPublish.ToString();
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

        public string GetScreenshotString(TorrentInfo ti, PublishOptionsPacket options)
        {
            StringBuilder sbPublish = new StringBuilder();
            BbCode bb = new BbCode();

            if (!string.IsNullOrEmpty(ti.MyMedia.Screenshot.Full) && options.FullPicture)
            {
                sbPublish.AppendLine(bb.Img(ti.MyMedia.Screenshot.Full));
            }
            else if (!string.IsNullOrEmpty(ti.MyMedia.Screenshot.LinkedThumbnail))
            {
                sbPublish.AppendLine(ti.MyMedia.Screenshot.LinkedThumbnail);
            }

            return sbPublish.ToString();
        }
    }
}
