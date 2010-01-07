using TDMakerLib;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace TDMakerLib
{
    /// <summary>
    /// Class for Screnshot information. Belongs to MediaInfo2.cs
    /// </summary>
    public class Screenshot
    {
        /// <summary>
        /// Screenshot Settings
        /// </summary>
        [Category("Screenshots"), Browsable(false), Description("MTN Profile Settings")]
        public XMLSettingsScreenshot Settings { get; set; }
        /// <summary>
        /// MTN Argument
        /// </summary>
        [Category("Screenshots"), Description("MTN profile settings")]
        public string MTNArgs { get; set; }

        /// <summary>
        /// URL of Full Image
        /// </summary>
        [Category("Screenshots"), Description("Full image URL")]
        public string Full { get; set; }
        /// <summary>
        /// URL of Linked Thumbnail
        /// </summary>
        [Category("Screenshots"), Description("Linked thumnail URL")]
        public string LinkedThumbnail { get; set; }
        /// <summary>
        /// Local file path of the Screenshot
        /// </summary>
        [Category("Screenshots"), Description("Local file path")]
        public string LocalPath { get; set; }
        
        public Screenshot()
        {
            this.Settings = new XMLSettingsScreenshot();
        }

        public override string ToString()
        {
            return Path.GetFileName(LocalPath);
        }
    }

}
