/*
 * Created by SharpDevelop.
 * User: e80655
 * Date: 2010-01-05
 * Time: 8:12 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text;

namespace TDMakerLib
{
	/// <summary>
	/// Description of Adapter.
	/// </summary>
	public static class Adapter
	{
		public static string GetMtnArg(XMLSettingsScreenshot screenshotSettings)
        {
        	// Create MTN Arg

                // Fill Screenshot object : coded parameters in alphabetical order
                StringBuilder sbMTNArgs = new StringBuilder();
                if (Engine.mtnProfileMgr.GetMtnProfileActive().P_QuitAfterDone)
                {
                    sbMTNArgs.Append("-P ");
                }
                if (Engine.mtnProfileMgr.GetMtnProfileActive().w_Width != XMLSettingsScreenshot.w_Width_default) {
                	sbMTNArgs.Append(string.Format("-w{0} ", Engine.mtnProfileMgr.GetMtnProfileActive().w_Width));                	
                }
                if (Engine.mtnProfileMgr.GetMtnProfileActive().h_MinHeight != XMLSettingsScreenshot.h_MinHeight_default)
                {
                    sbMTNArgs.Append(string.Format("-h{0} ", Engine.mtnProfileMgr.GetMtnProfileActive().h_MinHeight));
                }
                
                sbMTNArgs.Append(string.Format("-c{0} ", Engine.mtnProfileMgr.GetMtnProfileActive().c_Columns));
                sbMTNArgs.Append(string.Format("-r{0} ", Engine.mtnProfileMgr.GetMtnProfileActive().r_Rows));
                if (Engine.mtnProfileMgr.GetMtnProfileActive().k_ColorBackground != XMLSettingsScreenshot.k_ColorBackground_default)
                {
                    sbMTNArgs.Append(string.Format("-k{0} ", Engine.mtnProfileMgr.GetMtnProfileActive().k_ColorBackground));
                }

                if (Engine.mtnProfileMgr.GetMtnProfileActive().i_InfoOff || Engine.IsUNIX)
                {
                    sbMTNArgs.Append("-i ");
                }
                else if (!Engine.IsUNIX)
                {
                    if (Engine.mtnProfileMgr.GetMtnProfileActive().f_FontFile != XMLSettingsScreenshot.f_FontFile_default)
                    {
                        sbMTNArgs.Append(string.Format("-f {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().f_FontFile));
                    }
                    if (Engine.mtnProfileMgr.GetMtnProfileActive().F_FontColor != XMLSettingsScreenshot.F_FontColor_default)
                    {
                        sbMTNArgs.Append(string.Format("-F {0}:{1} ", Engine.mtnProfileMgr.GetMtnProfileActive().F_FontColor, Engine.mtnProfileMgr.GetMtnProfileActive().F_FontSize));
                    }
                }
                if (!Engine.mtnProfileMgr.GetMtnProfileActive().t_TimeStampOff || Engine.IsUNIX)
                {
                    sbMTNArgs.Append("-t ");
                }
                else if (!Engine.IsUNIX)
                {
                    if (Engine.mtnProfileMgr.GetMtnProfileActive().L_LocInfo != XMLSettingsScreenshot.L_LocInfo_default)
                    {
                        sbMTNArgs.Append(string.Format("-L {0}:{1} ", Engine.mtnProfileMgr.GetMtnProfileActive().L_LocInfo, Engine.mtnProfileMgr.GetMtnProfileActive().L_LocTimestamp));
                    }
                }

                if (Engine.mtnProfileMgr.GetMtnProfileActive().g_GapBetweenShots != XMLSettingsScreenshot.g_GapBetweenShots_default)
                {
                    sbMTNArgs.Append(string.Format("-g {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().g_GapBetweenShots));
                }
                
                if (Engine.mtnProfileMgr.GetMtnProfileActive().j_JpgQuality != XMLSettingsScreenshot.g_GapBetweenShots_default)
                {
                    sbMTNArgs.Append(string.Format("-j {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().j_JpgQuality));
                }
                
                if (Engine.mtnProfileMgr.GetMtnProfileActive().s_TimeStep != XMLSettingsScreenshot.s_TimeStep_default)
                {
                    sbMTNArgs.Append(string.Format("-s {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().s_TimeStep));
                }
                
                if (Engine.mtnProfileMgr.GetMtnProfileActive().D_EdgeDetection != XMLSettingsScreenshot.D_EdgeDetection_default)
                {
                    sbMTNArgs.Append(string.Format("-D {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().D_EdgeDetection));
                }

                if (Engine.mtnProfileMgr.GetMtnProfileActive().B_OmitBegin != XMLSettingsScreenshot.B_OmitBegin_default)
                {
                    sbMTNArgs.Append(string.Format("-B {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().B_OmitBegin));
                }

                if (Engine.mtnProfileMgr.GetMtnProfileActive().E_OmitEnd != XMLSettingsScreenshot.E_OmitEnd_default)
                {
                    sbMTNArgs.Append(string.Format("-E {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().E_OmitEnd));
                }

                // Not supported in MTN 2.45
                //if (chkMTN_z_SeekMode.Checked)
                //{
                //    sbMTNArgs.Append("-z ");
                //}
                //else
                //{
                //    sbMTNArgs.Append("-Z ");
                //}

                if (Engine.mtnProfileMgr.GetMtnProfileActive().N_InfoSuffix != XMLSettingsScreenshot.N_InfoSuffix_default || Engine.IsUNIX)
                {
                    sbMTNArgs.Append(string.Format("-N {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().N_InfoSuffix));                    
                }

                if (Engine.mtnProfileMgr.GetMtnProfileActive().o_OutputSuffix != XMLSettingsScreenshot.o_OutputSuffix_default)
                {
                    sbMTNArgs.Append(string.Format("-o {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().o_OutputSuffix));
                }
                
                if (Engine.mtnProfileMgr.GetMtnProfileActive().v_Verbose)
                {
                    sbMTNArgs.Append("-v ");
                }
                
                if (Engine.mtnProfileMgr.GetMtnProfileActive().T_TitleTextAdd)
                {
                    if (Engine.mtnProfileMgr.GetMtnProfileActive().T_TitleText == "%Title%")
                    {
	                    sbMTNArgs.Append(string.Format("-T \"{0}\" ", Engine.conf.txtMTN_T_Title));                        
                    }
                }
                sbMTNArgs.Append(string.Format("-O \"{0}\" ", Engine.GetScreenShotsDir()));
        	return sbMTNArgs.ToString();
        }	
	}
}
