using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace TDMakerLib
{
    [Serializable]
    public class XMLSettingsScreenshot : XMLSettings
    {
        [Category("MTN / Optional"), DefaultValue(false), Description("override input file's display aspect ratio")]
        public bool a_AspectRatio { get; set; }
        [Category("MTN / Optional"), DefaultValue(0.80), Description("skip if % blank is higher; 0:skip all 1:skip really blank >1:off")]
        public double b_SkipBlank { get; set; }
        [Category("MTN / Optional"), DefaultValue(0), Description("omit this seconds from the beginning")]
        public int B_OmitBegin { get; set; }
        [Category("MTN / Core"), DefaultValue(1), Description("# of columns")]
        public int c_Columns { get; set; }
        [Category("MTN / Optional"), DefaultValue(-1), Description("cut movie and thumbnails not more than the specified seconds; <=0:off")]
        public int C_CutMovie { get; set; }
        [Category("MTN / Optional"), DefaultValue(12), Description("edge detection; 0:off >0:on; higher detects more; try -D4 -D6 or -D8")]
        public int D_EdgeDetection { get; set; }
        [Category("MTN / Optional"), DefaultValue(0), Description("omit this seconds at the end")]
        public int E_OmitEnd { get; set; }
        [Category("MTN / Optional"), DefaultValue("tahomabd.ttf"), Description("font file; use absolute path if not in usual places")]
        public string f_Font { get; set; }
        [EditorAttribute(typeof(ColorDialogEditor), typeof(UITypeEditor))]
        [Category("MTN / Optional"), DefaultValue("RRGGBB"), Description("font color; RRGGBB:size")]
        public string F_FontColor { get; set; }
        [Category("MTN / Optional"), DefaultValue(0), Description("width of output image; 0:column * movie width")]
        public int F_FontSize { get; set; }
        [Category("MTN / Optional"), DefaultValue(8), Description("gap between each shot")]
        public int g_GapBetweenShots { get; set; }
        [Category("MTN / Optional"), DefaultValue(150), Description("minimum height of each shot; will reduce # of column to fit")]
        public int h_MinHeight { get; set; }
        [Category("MTN / Optional"), DefaultValue(false), Description("info text off")]
        public bool i_InfoOff { get; set; }
        [Category("MTN / Optional"), DefaultValue(false), Description("save individual shots too")]
        public bool I_IndivScreens { get; set; }
        [Category("MTN / Optional"), DefaultValue(99), Description("jpeg quality")]
        public int j_JpgQuality { get; set; }
        [EditorAttribute(typeof(ColorDialogEditor), typeof(UITypeEditor))]
        [Category("MTN / Optional"), DefaultValue("RRGGBB"), Description("background color (in hex)")]
        public string k_ColorBackground { get; set; }
        [Category("MTN / Optional"), DefaultValue(1), Description("location of text; 1=lower left, 2=lower right, 3=upper right, 4=upper left")]
        public int L_LocInfo { get; set; }
        [Category("MTN / Optional"), DefaultValue(0), Description("width of output image; 0:column * movie width")]
        public int L_LocTimestamp { get; set; }
        [Category("MTN / Optional"), DefaultValue(false), Description("run at normal priority")]
        public bool n_Priority { get; set; }
        [Category("MTN / Optional"), DefaultValue("_s.txt"), Description("save info text to a file with suffix")]
        public string N_InfoSuffix { get; set; }
        [Category("MTN / Optional"), DefaultValue("_s.jpg"), Description("output suffix")]
        public string o_OutputSuffix { get; set; }
        [EditorAttribute(typeof(FolderNameEditor), typeof(UITypeEditor))]
        [Category("MTN / Optional"), DefaultValue(""), Description("save output files in the specified directory")]
        public string O_OutputDir { get; set; }
        [Category("MTN / Optional"), DefaultValue(false), Description("pause before exiting; default on in win32")]
        public bool p_PauseBeforeExit { get; set; }
        [Category("MTN / Optional"), DefaultValue(true), Description("dont pause before exiting; override -p")]
        public bool P_QuitAfterDone { get; set; }
        [Category("MTN / Core"), DefaultValue(3), Description("# of rows; >0:override -s")]
        public int r_Rows { get; set; }
        [Category("MTN / Optional"), DefaultValue(120), Description("time step between each shot")]
        public int s_TimeStep { get; set; }
        [Category("MTN / Optional"), DefaultValue(false), Description("pause before exiting; default on in win32")]
        public bool t_TimeStamp { get; set; }
        [Category("MTN / Optional"), DefaultValue(false), Description("add text above output image")]
        public bool T_Text { get; set; }
        [Category("MTN / Optional"), DefaultValue(false), Description("verbose mode (debug)")]
        public bool v_Verbose { get; set; }
        [Category("MTN / Optional"), DefaultValue(0), Description("width of output image; 0:column * movie width")]
        public int w_Width { get; set; }
        [Category("MTN / Optional"), DefaultValue(false), Description("dont overwrite existing files, i.e. update mode")]
        public bool W_Update { get; set; }
        [Category("MTN / Optional"), DefaultValue(false), Description("always use seek mode")]
        public bool z_Seek { get; set; }
        [Category("MTN / Optional"), DefaultValue(false), Description("always use non-seek mode -- slower but more accurate timing")]
        public bool Z_NonSeek { get; set; }


        public XMLSettingsScreenshot()
        {
            ApplyDefaultValues(this);
        }

        #region I/O Methods

        public void Write(string filePath)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                //Write XML file
                XmlSerializer serial = new XmlSerializer(typeof(XMLSettings));
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

        public static XMLSettingsScreenshot Read()
        {
            string settingsFile = Engine.mAppSettings.GetSettingsFilePath();
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

            if (File.Exists(settingsFile) && settingsFile != Engine.mAppSettings.GetSettingsFilePath())
            {
                // Update AppSettings.xml
                File.Copy(settingsFile, Engine.mAppSettings.GetSettingsFilePath());
            }

            Engine.mAppSettings.XMLSettingsFile = Engine.mAppSettings.GetSettingsFilePath();
            return Read(Engine.mAppSettings.XMLSettingsFile);
        }

        public static XMLSettingsScreenshot Read(string filePath)
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
                        XmlSerializer xs = new XmlSerializer(typeof(XMLSettings));
                        using (FileStream fs = new FileStream(filePath, FileMode.Open))
                        {
                            return xs.Deserialize(fs) as XMLSettingsScreenshot;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            return new XMLSettingsScreenshot();
        }

        #endregion
    }

}
