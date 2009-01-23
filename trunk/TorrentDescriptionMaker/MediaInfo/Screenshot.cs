using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDMaker.MediaInfo
{
    /// <summary>
    /// Class for Screnshot information. Belongs to MediaInfo2.cs
    /// </summary>
    public class Screenshot
    {
        public string FontPath { get; set; }
        public string InputFilePath { get; set; }
        public string OutputFilePath { get; set; }

        /// <summary>
        /// URL of Full Image
        /// </summary>
        public string Full { get; set; }
        /// <summary>
        /// URL of Linked Thumbnail
        /// </summary>
        public string LinkedThumbnail { get; set; }

    }

}
