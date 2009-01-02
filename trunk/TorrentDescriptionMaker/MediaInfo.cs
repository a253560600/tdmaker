using System;
using System.Collections.Generic;
using System.Text;

namespace TorrentDescriptionMaker
{
    /// <summary>
    /// Class that holds all Media Info: Genernal, Audio 1 to n, Video
    /// </summary>
    public class MediaInfo
    {
        public MediaInfo()
        {
            this.Audio = new List<AudioInfo>();
            this.Video = new VideoInfo();
        }

        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string Format { get; set; }
        public string FormatInfo { get; set; }

        public List<AudioInfo> Audio { get; set; }
        public VideoInfo Video { get; set; }

    }

    public class AudioInfo
    {
        public string FormatProfile { get; set; }
        public string FormatVersion { get; set; }
    }

    public class VideoInfo
    {
        public string Standard { get; set; }
        public string FormatVersion { get; set; }

    }

}
