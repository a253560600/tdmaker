using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;

namespace TDMakerLib
{
    [Serializable]
    public class XMLSettingsScreenshot : XMLSettings
    {
        public string a_AspectRatio { get; set; }
        public int b_SkipBlank { get; set; }
        public bool bTitle { get; set; }
        public bool bSource { get; set; }
        public int B_OmitBegin { get; set; }
        [Category("MTN"), DefaultValue(1), Description("# of columns")]
        public int c_Columns { get; set; }
        public int C_CutMovie { get; set; }
        public int D_EdgeDetection { get; set; }
        public int E_OmitEnd { get; set; }
        [Category("MTN"), DefaultValue("tahomabd.ttf"), Description("font file; use absolute path if not in usual places")]
        public string f_Font { get; set; }
        public string F_FontColor { get; set; }
        [Category("MTN"), DefaultValue(8), Description("gap between each shot")]
        public int g_GapBetweenShots { get; set; }
        [Category("MTN"), DefaultValue(150), Description("minimum height of each shot; will reduce # of column to fit")]
        public int h_MinHeight { get; set; }
        public bool i_InfoOff { get; set; }
        public bool I_IndivScreens { get; set; }
        [Category("MTN"), DefaultValue(99), Description("jpeg quality")]
        public int j_JpgQuality { get; set; }
        [Category("MTN"), DefaultValue("RRGGBB"), Description("background color (in hex)")]
        public string k_ColorBackground { get; set; }
        public bool n_Priority { get; set; }
        public string N_InfoSuffix { get; set; }
        [Category("MTN"), DefaultValue("_s.jpg"), Description("output suffix")]
        public string o_OutputSuffix { get; set; }
        public string O_OutputDir { get; set; }
        [Category("MTN"), DefaultValue(false), Description("pause before exiting; default on in win32")]
        public bool p_PauseBeforeExit { get; set; }
        [Category("MTN"), DefaultValue(true), Description("dont pause before exiting; override -p")]
        public bool P_QuitAfterDone { get; set; }
        [Category("MTN"), DefaultValue(3), Description("# of rows; >0:override -s")]
        public int r_Rows { get; set; }
        [Category("MTN"), DefaultValue(120), Description("time step between each shot")]
        public int s_TimeStep { get; set; }
        public bool t_TimeStamp { get; set; }
        public bool T_Text { get; set; }
        public bool v_Verbose { get; set; }
        public int w_Width { get; set; }
        public bool W_Update { get; set; }
        public bool z_Seek { get; set; }
        public string Z_NonSeek { get; set; }
        public string L_InfoLocation { get; set; }
        public int InfoTextIndex { get; set; }
        public int InfoTimestampIndex { get; set; }
        public int F_FontSize { get; set; }
        public bool chkMTN_F_FontSize { get; set; }
        public bool chkMTN_F_FontColor { get; set; }
        public bool chk_h_MinHeight { get; set; }
        public bool chk_w_Width { get; set; }
        public string g_Gap { get; set; }
        public bool WebLink { get; set; }

        public XMLSettingsScreenshot()
        {
            ApplyDefaultValues(this);
        }


        #region I/O Methods

        public string FilePath { get; set; }

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
            Write(Program.appSettings.XMLSettingsFile);
        }

        public static XMLSettingsScreenshot Read()
        {
            string settingsFile = Program.appSettings.GetSettingsFilePath();
            if (!File.Exists(settingsFile))
            {
                if (File.Exists(Program.appSettings.XMLSettingsFile))
                {
                    // Step 2 - Attempt to read previous Application Version specific Settings file
                    settingsFile = Program.appSettings.XMLSettingsFile;
                }
                else
                {
                    // Step 3 - Attempt to read conventional Settings file
                    settingsFile = Program.XMLSettingsFile;
                }
            }

            if (File.Exists(settingsFile) && settingsFile != Program.appSettings.GetSettingsFilePath())
            {
                // Update AppSettings.xml
                File.Copy(settingsFile, Program.appSettings.GetSettingsFilePath());
            }

            Program.appSettings.XMLSettingsFile = Program.appSettings.GetSettingsFilePath();
            return Read(Program.appSettings.XMLSettingsFile);
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
