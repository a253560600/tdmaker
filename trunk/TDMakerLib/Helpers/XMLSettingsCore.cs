using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Specialized;
using UploadersLib;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace TDMakerLib
{
    [XmlRoot("Settings")]
    public class XMLSettingsCore : XMLSettings
    {
        public static string XMLFileName = string.Format("{0}-{1}-Settings.xml", Application.ProductName, Application.ProductVersion);

        public XMLSettingsCore()
        {
            ApplyDefaultValues(this);
        }

        // Misc
        [BrowsableAttribute(false)]
        public bool RunOnce { get; set; }
        [BrowsableAttribute(false)]
        public bool UpgradeSettings { get; set; }

        // Tab 1 - Input

        // Disc Properties
        [BrowsableAttribute(false)]
        public bool bBrowseDir { get; set; }

        [BrowsableAttribute(false)]
        public bool bAuthoring { get; set; }
        public string AuthoringMode = "Untouched";
        public StringCollection AuthoringModes = new StringCollection();

        [BrowsableAttribute(false)]
        public bool bDiscMenu { get; set; }
        public string DiscMenu = "Intact";
        public StringCollection DiscMenus = new StringCollection();

        [BrowsableAttribute(false)]
        public bool bExtras { get; set; }
        public string Extra = "Intact";
        public StringCollection Extras = new StringCollection();

        // Source Properties
        [BrowsableAttribute(false)]
        public bool bSource { get; set; }
        [BrowsableAttribute(false)]
        public string Source = "DVD-9";
        public StringCollection Sources = new StringCollection();

        [BrowsableAttribute(false)]
        public bool bTitle { get; set; }
        [BrowsableAttribute(false)]
        public bool bWebLink { get; set; }

        // Tab 2 - Media Info
        /*
         * Nothing
         */

        // Tab 3 - Publish 
        [Category("Screenshots"), DefaultValue(true), Description("Capture Screenshots using MTN")]
        public bool TakeScreenshot { get; set; }
        [Category("Screenshots"), DefaultValue(true), Description("Upload screenshot.")]
        public bool UploadScreenshot { get; set; }
        [Category("Screenshots"), DefaultValue(true), Description("Use full image URL in the torrent description.")]
        public bool UseFullPicture { get; set; }
        [Category("Screenshots"), DefaultValue(true), Description(@"Keep Screenshots in Pictures\MTN")]
        public bool KeepScreenshot { get; set; }

        // Tab 3 - Publish - Options
        [Category("Publish / Config"), DefaultValue(false), Description("Setting true will center align the description")]
        public bool AlignCenter { get; set; }
        [Category("Publish / Config"), DefaultValue(false), Description("Setting true will retain the formatting on some message boards")]
        public bool PreText { get; set; }
        [Category("Publish / Config"), DefaultValue(true), Description("Setting true will use Templates to generate the description")]
        public bool TemplatesMode { get; set; }

        // Tab 4.0 - Options - General
        [Category("Options / General"), DefaultValue(false), Description("Process media immediately after loading file or folder")]
        public bool AnalyzeAuto { get; set; }
        [Category("Options / General"), DefaultValue(true), Description("Automatically Check for Updates")]
        public bool UpdateCheckAuto { get; set; }

        // Tab 4.1 - Options - Publish Templates
        [Category("Options / Publish"), DefaultValue(false), Description("Create Torrent")]
        public bool WritePublish { get; set; }
        [Category("Options / Publish"), DefaultValue(true), Description("Font Size for Heading 2")]
        public bool LargerPreText { get; set; }
        [Category("Options / Publish / Font Sizes"), DefaultValue(5), Description("Font Size for Heading 1")]
        public int FontSizeHeading1 { get; set; }
        [Category("Options / Publish / Font Sizes"), DefaultValue(4), Description("Font Size for Heading 2")]
        public int FontSizeHeading2 { get; set; }
        [Category("Options / Publish / Font Sizes"), DefaultValue(3), Description("Font Size for Heading 3")]
        public int FontSizeHeading3 { get; set; }
        [Category("Options / Publish / Font Sizes"), DefaultValue(2), Description("Font Size for Body")]
        public int FontSizeBody { get; set; }
        [Category("Options / Publish / Font Sizes"), DefaultValue(1), Description("Font Size increment")]
        public int FontSizeIncr { get; set; }
        [Browsable(false)]
        public int TemplateIndex { get; set; }

        // Tab 4.2 - Options - MTN
        public StringCollection MTNArgs = new StringCollection();
        public StringCollection MTNFonts = new StringCollection();

        [Category("MTN"), DefaultValue(false), Description("Show MTN during file creation")]
        public bool ShowMTNWindow { get; set; }
        [EditorAttribute(typeof(ExeFileNameEditor), typeof(UITypeEditor))]
        [Category("MTN"), Description("MTN Argument")]
        public string MTNPath { get; set; }
        [Category("MTN"), DefaultValue("-P -w 0 -c 1 -r 3 -keeeeee -f arial.ttf -g8 -F 000000:12 -L4:2 -j 97"), Description("MTN Argument")]
        public string MTNArg { get; set; }
        public ImageDestType2 ImageUploader = ImageDestType2.IMAGESHACK ;
        [Category("MTN / Image Uploaders"), DefaultValue(""), Description("ImageShack registration code")]
        public string ImageShackRegCode { get; set; }
        [Category("MTN / Image Uploaders"), DefaultValue(false), Description("Randomize ImageShack file name")]
        public bool ImageShakeRandomizeFileName { get; set; }

        // Tab 4.3 - Options - Torrent Creator
        [Browsable(false)]
        public int TrackerGroupActive { get; set; }
        [Category("Torrent Creator"), DefaultValue(false), Description("Create Torrent")]
        public bool TorrentCreateAuto { get; set; }
        [Category("Torrent Creator"), DefaultValue(false), Description("Create torrents in the same folders as the media file")]
        public bool TorrentFolderDefault { get; set; }
        [Category("Torrent Creator"), DefaultValue(false), Description("Save torrent files in sub-folders organized by tracker namer")]
        public bool TorrentsOrganize { get; set; }
        public List<TrackerGroup> TrackerGroups = new List<TrackerGroup>();

        // Tab 4.4 - Options - Paths
        [Category("Options / Paths"), DefaultValue(false), Description("Use custom Templates directory")]
        public bool UseCustomTemplatesDir { get; set; }
        [Category("Options / Paths"), Description("Browse to reconfigure the Templates folder path")]
        [EditorAttribute(typeof(FolderNameEditor), typeof(UITypeEditor))]
        public string CustomTemplatesDir { get; set; }
        [Category("Options / Paths"), DefaultValue(false), Description("Use custom Torrents directory")]
        public bool UseCustomTorrentsDir { get; set; }
        [Category("Options / Paths"), Description("Browse to change where torrent files are saved")]
        [EditorAttribute(typeof(FolderNameEditor), typeof(UITypeEditor))]
        public string CustomTorrentsDir { get; set; }
        
        public string txtMTN_T_Title = string.Empty;

        #region I/O Methods

        public void Write(string filePath)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                //Write XML file
                XmlSerializer serial = new XmlSerializer(typeof(XMLSettingsCore));
                FileStream fs = new FileStream(filePath, FileMode.Create);
                serial.Serialize(fs, this);
                fs.Close();

                serial = null;
                fs = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Write()
        {
            Write(Engine.mAppSettings.XMLSettingsFile);
        }

        public static XMLSettingsCore Read()
        {
            string settingsFile = Engine.mAppSettings.GetSettingsFilePath(XMLFileName);
            if (!File.Exists(settingsFile))
            {
                if (File.Exists(Engine.mAppSettings.XMLSettingsFile))
                {
                    // Step 2 - Attempt to read previous Application Version specific Settings file
                    settingsFile = Engine.mAppSettings.XMLSettingsFile;
                }
                else
                {
                    // Step 3 - Attempt to read conventional Settings file
                    settingsFile = Engine.XMLSettingsFile;
                }
            }

            if (File.Exists(settingsFile) && settingsFile != Engine.mAppSettings.GetSettingsFilePath(XMLFileName))
            {
                // Update AppSettings.xml
                File.Copy(settingsFile, Engine.mAppSettings.GetSettingsFilePath(XMLFileName));
            }

            Engine.mAppSettings.XMLSettingsFile = Engine.mAppSettings.GetSettingsFilePath(XMLFileName);
            return Read(Engine.mAppSettings.XMLSettingsFile);
        }

        public static XMLSettingsCore Read(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                string settingsDir = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(settingsDir))
                {
                    Directory.CreateDirectory(settingsDir);
                }
                if (File.Exists(filePath))
                {
                    try
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(XMLSettingsCore), TextUploader.Types.ToArray());
                        using (FileStream fs = new FileStream(filePath, FileMode.Open))
                        {
                            return xs.Deserialize(fs) as XMLSettingsCore;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            return new XMLSettingsCore();
        }

        #endregion
    }
}
