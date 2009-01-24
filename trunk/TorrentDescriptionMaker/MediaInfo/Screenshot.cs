using TDMaker.Properties;

namespace TDMaker.MediaInfo
{
    /// <summary>
    /// Class for Screnshot information. Belongs to MediaInfo2.cs
    /// </summary>
    public class Screenshot
    {
        /// <summary>
        /// Screenshot Settings
        /// </summary>
        internal ScreenshotSettings Settings { get; set; }

        /// <summary>
        /// URL of Full Image
        /// </summary>
        public string Full { get; set; }
        /// <summary>
        /// URL of Linked Thumbnail
        /// </summary>
        public string LinkedThumbnail { get; set; }

        public Screenshot()
        {
            this.Settings = new ScreenshotSettings();
        }

    }

}
