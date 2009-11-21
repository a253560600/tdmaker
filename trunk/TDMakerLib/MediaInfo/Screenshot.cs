using TDMakerLib;

namespace TDMakerLib.MediaInfo
{
    /// <summary>
    /// Class for Screnshot information. Belongs to MediaInfo2.cs
    /// </summary>
    public class Screenshot
    {
        /// <summary>
        /// Screenshot Settings
        /// </summary>
        public XMLSettingsScreenshot Settings { get; set; }
        /// <summary>
        /// FontStyle for Screenshot Text
        /// </summary>
        public string FontStyle { get; set; }
        /// <summary>
        /// MTN Argument
        /// </summary>
        public string MTNArgs { get; set; }

        /// <summary>
        /// URL of Full Image
        /// </summary>
        public string Full { get; set; }
        /// <summary>
        /// URL of Linked Thumbnail
        /// </summary>
        public string LinkedThumbnail { get; set; }
        /// <summary>
        /// Local file path of the Screenshot
        /// </summary>
        public string LocalPath { get; set; }
        
        public Screenshot()
        {
            this.Settings = new XMLSettingsScreenshot();
        }

    }

}
