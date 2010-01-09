using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDMakerLib
{
    [Serializable]
    public class XMLTorrentUpload
    {
        public string TorrentFilePath { get; set; }
        public string Type { get; set; }
        public string IMDBID { get; set; }
        public bool Scene { get; set; }
        public string Format { get; set; }
        public string Resolution { get; set; }
        public string Media { get; set; }
        public string FileType { get; set; }
        public string ReleaseDescription { get; set; }
    }
}
