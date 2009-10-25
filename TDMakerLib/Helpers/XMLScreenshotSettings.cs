using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TDMakerLib
{
    [Serializable]
    public class XMLScreenshotSettings
    {
        public string a_AspectRatio { get; set; }
        public decimal b_SkipBlank { get; set; }
        public bool bTitle { get; set; }
        public bool bSource { get; set; }
        public decimal B_OmitBegin { get; set; }
        public decimal c_Columns { get; set; }
        public decimal C_CutMovie { get; set; }
        public decimal D_EdgeDetection { get; set; }
        public decimal E_OmitEnd { get; set; }
        public string f_Font { get; set; }
        public string F_FontColor { get; set; }
        public decimal g_GapBetweenShots { get; set; }
        public decimal h_MinHeight { get; set; }
        public bool i_InfoOff { get; set; }
        public bool I_IndivScreens { get; set; }
        public decimal j_JpgQuality = 50;
        public string k_ColorBackground { get; set; }
        public bool n_Priority { get; set; }
        public string N_InfoSuffix { get; set; }
        public string o_OutputSuffix { get; set; }
        public string O_OutputDir { get; set; }
        public bool p_PauseBeforeExit { get; set; }
        public bool P_QuitAfterDone { get; set; }
        public decimal r_Rows { get; set; }
        public decimal s_TimeStep { get; set; }
        public bool t_TimeStamp { get; set; }
        public bool T_Text { get; set; }
        public bool v_Verbose { get; set; }
        public decimal w_Width { get; set; }
        public bool W_Update { get; set; }
        public bool z_Seek { get; set; }
        public string Z_NonSeek { get; set; }
        public string L_InfoLocation { get; set; }
        public int InfoTextIndex { get; set; }
        public int InfoTimestampIndex { get; set; }
        public decimal F_FontSize { get; set; }
        public bool chkMTN_F_FontSize { get; set; }
        public bool chkMTN_F_FontColor { get; set; }
        public bool chk_h_MinHeight { get; set; }
        public bool chk_w_Width { get; set; }
        public string chkMTN_g_Gap { get; set; }
        public bool chkMTN_k_ColorBackground { get; set; }
        public bool chkMTN_s_TimeStep { get; set; }
        public bool chkMTN_j_JPEGQuality { get; set; }
        public bool chkMTN_B_OmitBegin { get; set; }
        public bool chkMTN_E_OmitEnd { get; set; }
        public bool chkMTN_D_EdgeDetection { get; set; }
        public bool chkMTN_h_Height { get; set; }
        public bool chkMTN_T_Title { get; set; }
        public bool chkMTN_L_LocInfo { get; set; }
        public bool chkMTN_N_WriteInfo { get; set; }
        public bool chkMTN_o_OutputSuffix { get; set; }
        public bool chkMTN_tL_LocTimestamp { get; set; }
        public bool chkMTN_f_Font { get; set; }
        public bool chkMTN_v_Verbose { get; set; }
        public bool WebLink { get; set; }

        public XMLScreenshotSettings()
        {
            ApplyDefaultValues(this);
        }

        static public void ApplyDefaultValues(object self)
        {
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(self))
            {
                DefaultValueAttribute attr = prop.Attributes[typeof(DefaultValueAttribute)] as DefaultValueAttribute;
                if (attr == null) continue;
                prop.SetValue(self, attr.Value);
            }
        }

    }

}
