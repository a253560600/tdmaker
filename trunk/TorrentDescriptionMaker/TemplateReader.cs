using System;
using System.Collections.Generic;
using System.Text;
using TorrentDescriptionMaker;

namespace TDMaker
{
    /// <summary>
    /// Class responsible for reading Template Directories. 
    /// A Template Directory has 5 files: 
    /// GeneralInfo.txt; VideoInfo.txt; AudioInfo.txt; Disc.txt; File.txt
    /// </summary>
     class TemplateReader
    {
        /// <summary>
        /// Location of the Template
        /// </summary>
        public string Location { get; private set; }
        public TorrentInfo TorrentInfo { get; private set; }
        public string PublishInfo { get; private set; }

        /// <summary>
        /// Constructure of TemplateReader
        /// </summary>
        /// <param name="loc">Directory Path of the Template</param>
        /// <param name="ti">TorrentInfo object that has MediaInfo</param>
        public TemplateReader(string loc, TorrentInfo ti)
        {
            this.Location = loc;
            this.TorrentInfo = ti;
        }

        public void CreateInfo()
        {
            if (TorrentInfo.MediaInfo2.IsDisc)
            {
                PublishInfo = CreateDiscInfo(TorrentInfo.MediaInfo2.Overall);
            }
            else
            {
                PublishInfo = CreateFileInfo(TorrentInfo.MediaInfo2);
            }
        }

        private string GeneralInfo(MediaFile mf)
        {
            return "";
        }

        private string VideoInfo(MediaFile mf)
        {
            return "";
        }

        private string AudioInfo(MediaFile mf)
        {
            return "";
        }

        private string CreateFileInfo(MediaInfo2 mi)
        {
            return "";
        }

        private string CreateDiscInfo(MediaFile mf)
        {
            return "";
        }

     }
}
