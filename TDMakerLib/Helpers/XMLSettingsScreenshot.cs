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
    	public const bool a_AspectRatio_default = false;
    	public const double b_SkipBlank_default = 0.80; 
    	public const int B_OmitBegin_default = 0; 
    	public const int c_Columns_default = 3;
    	public const int C_CutMovie_default = -1; 
    	public const int D_EdgeDetection_default = 12; 
    	public const int E_OmitEnd_default = 0; 
    	public const string f_FontFile_default = "tahomabd.ttf";
    	public const string F_FontColor_default = "RRGGBB"; 
    	public const int g_GapBetweenShots_default = 0; 
    	public const int h_MinHeight_default = 150; 
    	public const bool i_InfoOff_default = false;
    	public const bool I_IndivScreens_default = false;
    	public const int j_JpgQuality_default = 90; 
    	public const string k_ColorBackground_default = "RRGGBB"; 
    	public const int L_LocInfo_default = 4; 
    	public const bool n_Priority_default = false;
    	public const string N_InfoSuffix_default = "";
    	public const string o_OutputSuffix_default = "_s.jpg";
    	public const string O_OutputDir_default = "";
    	public const bool p_PauseBeforeExit_default = false;
    	public const bool P_QuitAfterDone_default = false;
    	public const int r_Rows_default = 0; 
    	public const int s_TimeStep_default = 120; 
    	public const bool t_TimeStampOff_default = false;
    	public const bool T_Text_default = false;
    	public const bool v_Verbose_default = false;
    	public const int w_Width_default = 1024;
    	public const bool W_Update_default = false;
    	public const bool z_Seek_default = false;
    	public const bool Z_NonSeek_default = false;
    	
        [Category("MTN / Optional"), DefaultValue(a_AspectRatio_default), Description("override input file's display aspect ratio")]
        public bool a_AspectRatio { get; set; }
        [Category("MTN / Optional"), DefaultValue(b_SkipBlank_default), Description("skip if % blank is higher; 0:skip all 1:skip really blank >1:off")]
        public double b_SkipBlank { get; set; }
        [Category("MTN / Optional"), DefaultValue(B_OmitBegin_default), Description("omit this number of seconds from the beginning")]
        public int B_OmitBegin { get; set; }
        [Category("MTN / Core"), DefaultValue(1), Description("# of columns")]
        public int c_Columns { get; set; }
        [Category("MTN / Optional"), DefaultValue(C_CutMovie_default), Description("cut movie and thumbnails not more than the specified seconds; <=0:off")]
        public int C_CutMovie { get; set; }
        [Category("MTN / Optional"), DefaultValue(D_EdgeDetection_default), Description("edge detection; 0:off >0:on; higher detects more; try -D4 -D6 or -D8")]
        public int D_EdgeDetection { get; set; }
        [Category("MTN / Optional"), DefaultValue(E_OmitEnd_default), Description("omit this seconds at the end")]
        public int E_OmitEnd { get; set; }
        [Category("MTN / Optional"), DefaultValue(f_FontFile_default), Description("font file; use absolute path if not in usual places")]
        public string f_FontFile { get; set; }
        [EditorAttribute(typeof(ColorDialogEditor), typeof(UITypeEditor))]
        [Category("MTN / Optional"), DefaultValue(F_FontColor_default), Description("font color in hex; e.g. RRGGBB")]
        public string F_FontColor { get; set; }
        [Category("MTN / Optional"), DefaultValue(8), Description("font size")]
        public int F_FontSize { get; set; }
        [Category("MTN / Optional"), DefaultValue(g_GapBetweenShots_default), Description("gap between each shot")]
        public int g_GapBetweenShots { get; set; }
        [Category("MTN / Optional"), DefaultValue(h_MinHeight_default), Description("minimum height of each shot; will reduce # of column to fit")]
        public int h_MinHeight { get; set; }
        [Category("MTN / Optional"), DefaultValue(i_InfoOff_default), Description("info text off")]
        public bool i_InfoOff { get; set; }
        [Category("MTN / Optional"), DefaultValue(I_IndivScreens_default), Description("save individual shots too")]
        public bool I_IndivScreens { get; set; }
        [Category("MTN / Optional"), DefaultValue(99), Description("jpeg quality")]
        public int j_JpgQuality { get; set; }
        [EditorAttribute(typeof(ColorDialogEditor), typeof(UITypeEditor))]
        [Category("MTN / Optional"), DefaultValue(k_ColorBackground_default), Description("background color (in hex)")]
        public string k_ColorBackground { get; set; }
        [Category("MTN / Optional"), DefaultValue(L_LocInfo_default), Description("location of text; 1=lower left, 2=lower right, 3=upper right, 4=upper left")]
        public int L_LocInfo { get; set; }
        [Category("MTN / Optional"), DefaultValue(4), Description("location of timestamp text; 1=lower left, 2=lower right, 3=upper right, 4=upper left")]
        public int L_LocTimestamp { get; set; }
        [Category("MTN / Optional"), DefaultValue(n_Priority_default), Description("run at normal priority")]
        public bool n_Priority { get; set; }
        [Category("MTN / Optional"), DefaultValue("_s.txt"), Description("save info text to a file with suffix")]
        public string N_InfoSuffix { get; set; }
        [Category("MTN / Optional"), DefaultValue(o_OutputSuffix_default), Description("output suffix")]
        public string o_OutputSuffix { get; set; }
        [EditorAttribute(typeof(FolderNameEditor), typeof(UITypeEditor))]
        [Category("MTN / Optional"), DefaultValue(O_OutputDir_default), Description("save output files in the specified directory")]
        public string O_OutputDir { get; set; }
        [Category("MTN / Optional"), DefaultValue(p_PauseBeforeExit_default), Description("pause before exiting; default on in win32")]
        public bool p_PauseBeforeExit { get; set; }
        [Category("MTN / Optional"), DefaultValue(true), Description("dont pause before exiting; override -p")]
        public bool P_QuitAfterDone { get; set; }
        [Category("MTN / Core"), DefaultValue(3), Description("# of rows; >0:override -s")]
        public int r_Rows { get; set; }
        [Category("MTN / Optional"), DefaultValue(s_TimeStep_default), Description("time step between each shot")]
        public int s_TimeStep { get; set; }
        [Category("MTN / Optional"), DefaultValue(t_TimeStampOff_default), Description("time stamp off")]
        public bool t_TimeStampOff { get; set; }
        [Category("MTN / Optional"), DefaultValue(T_Text_default), Description("add text above output image")]
        public bool T_Text { get; set; }
        [Category("MTN / Optional"), DefaultValue(v_Verbose_default), Description("verbose mode (debug)")]
        public bool v_Verbose { get; set; }
        [Category("MTN / Optional"), DefaultValue(0), Description("width of output image; 0:column * movie width")]
        public int w_Width { get; set; }
        [Category("MTN / Optional"), DefaultValue(W_Update_default), Description("dont overwrite existing files, i.e. update mode")]
        public bool W_Update { get; set; }
        [Category("MTN / Optional"), DefaultValue(z_Seek_default), Description("always use seek mode")]
        public bool z_AlwaysSeek { get; set; }
        [Category("MTN / Optional"), DefaultValue(Z_NonSeek_default), Description("always use non-seek mode -- slower but more accurate timing")]
        public bool Z_AlwaysNonSeek { get; set; }

        public string T_Title = string.Empty;    
        
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
