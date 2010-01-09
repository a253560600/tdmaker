﻿#region License Information (GPL v2)
/*
    TDMaker - A program that allows you to upload screenshots in one keystroke.
    Copyright (C) 2008-2009  Brandon Zimmerman

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
    
    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using System.Text;
using UploadersLib.Helpers;

namespace TDMakerLib
{
    /// <summary>
    /// Description of Adapter.
    /// </summary>
    public static class Adapter
    {
        public static ProxySettings CheckProxySettings()
        {
            FileSystem.AppendDebug("Proxy Enabled: " + Engine.conf.ProxyEnabled.ToString());
            return new ProxySettings { ProxyEnabled = Engine.conf.ProxyEnabled, ProxyActive = Engine.conf.ProxySettings };
        }

        public static string GetMtnArg(XMLSettingsScreenshot screenshotSettings)
        {
            // Fill Screenshot object : coded parameters in alphabetical order except for columns, rows and width

            StringBuilder sbMTNArgs = new StringBuilder();
            sbMTNArgs.Append(string.Format("-c {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().c_Columns));
            sbMTNArgs.Append(string.Format("-r {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().r_Rows));

            if (Engine.mtnProfileMgr.GetMtnProfileActive().w_Width != XMLSettingsScreenshot.w_Width_default)
            {
                sbMTNArgs.Append(string.Format("-w {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().w_Width));
            }

            if (Engine.mtnProfileMgr.GetMtnProfileActive().a_AspectRatio != XMLSettingsScreenshot.a_AspectRatio_default)
            {
                sbMTNArgs.Append(string.Format("-a {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().a_AspectRatioValue));
            }

            if (Engine.mtnProfileMgr.GetMtnProfileActive().b_SkipBlank != XMLSettingsScreenshot.b_SkipBlank_default)
            {
                sbMTNArgs.Append(string.Format("-b {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().b_SkipBlank));
            }

            if (Engine.mtnProfileMgr.GetMtnProfileActive().B_OmitBegin != XMLSettingsScreenshot.B_OmitBegin_default)
            {
                sbMTNArgs.Append(string.Format("-B {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().B_OmitBegin));
            }

            // c is added earlier

            if (Engine.mtnProfileMgr.GetMtnProfileActive().C_CutMovie != XMLSettingsScreenshot.C_CutMovie_default)
            {
                sbMTNArgs.Append(string.Format("-C {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().C_CutMovie));
            }

            if (Engine.mtnProfileMgr.GetMtnProfileActive().D_EdgeDetection != XMLSettingsScreenshot.D_EdgeDetection_default)
            {
                sbMTNArgs.Append(string.Format("-D {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().D_EdgeDetection));
            }

            if (Engine.mtnProfileMgr.GetMtnProfileActive().E_OmitEnd != XMLSettingsScreenshot.E_OmitEnd_default)
            {
                sbMTNArgs.Append(string.Format("-E {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().E_OmitEnd));
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

            if (Engine.mtnProfileMgr.GetMtnProfileActive().g_GapBetweenShots != XMLSettingsScreenshot.g_GapBetweenShots_default)
            {
                sbMTNArgs.Append(string.Format("-g {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().g_GapBetweenShots));
            }

            if (Engine.mtnProfileMgr.GetMtnProfileActive().h_MinHeight != XMLSettingsScreenshot.h_MinHeight_default)
            {
                sbMTNArgs.Append(string.Format("-h {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().h_MinHeight));
            }

            // i is added earlier

            if (Engine.mtnProfileMgr.GetMtnProfileActive().I_IndivScreens)
            {
                sbMTNArgs.Append("-I ");
            }

            if (Engine.mtnProfileMgr.GetMtnProfileActive().j_JpgQuality != XMLSettingsScreenshot.g_GapBetweenShots_default)
            {
                sbMTNArgs.Append(string.Format("-j {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().j_JpgQuality));
            }

            if (Engine.mtnProfileMgr.GetMtnProfileActive().k_ColorBackground != XMLSettingsScreenshot.k_ColorBackground_default)
            {
                sbMTNArgs.Append(string.Format("-k {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().k_ColorBackground));
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

            if (Engine.mtnProfileMgr.GetMtnProfileActive().N_InfoSuffix != XMLSettingsScreenshot.N_InfoSuffix_default || Engine.IsUNIX)
            {
                sbMTNArgs.Append(string.Format("-N {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().N_InfoSuffix));
            }

            if (Engine.mtnProfileMgr.GetMtnProfileActive().o_OutputSuffix != XMLSettingsScreenshot.o_OutputSuffix_default)
            {
                sbMTNArgs.Append(string.Format("-o {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().o_OutputSuffix));
            }

            sbMTNArgs.Append(string.Format("-O \"{0}\" ", Engine.GetScreenShotsDir()));

            if (Engine.mtnProfileMgr.GetMtnProfileActive().P_QuitAfterDone)
            {
                sbMTNArgs.Append("-P ");
            }
            else if (Engine.mtnProfileMgr.GetMtnProfileActive().p_PauseBeforeExit)
            {
                sbMTNArgs.Append("-p ");
            }

            // r is added earlier

            if (Engine.mtnProfileMgr.GetMtnProfileActive().s_TimeStep != XMLSettingsScreenshot.s_TimeStep_default)
            {
                sbMTNArgs.Append(string.Format("-s {0} ", Engine.mtnProfileMgr.GetMtnProfileActive().s_TimeStep));
            }

            // t is added earlier

            if (Engine.mtnProfileMgr.GetMtnProfileActive().T_TitleTextAdd)
            {
                if (Engine.mtnProfileMgr.GetMtnProfileActive().T_TitleText == "%Title%")
                {
                    sbMTNArgs.Append(string.Format("-T \"{0}\" ", Engine.conf.txtMTN_T_Title));
                }
            }

            if (Engine.mtnProfileMgr.GetMtnProfileActive().v_Verbose)
            {
                sbMTNArgs.Append("-v ");
            }

            // w is added earlier

            if (Engine.mtnProfileMgr.GetMtnProfileActive().z_AlwaysSeek)
            {
                sbMTNArgs.Append("-z ");
            }
            else if (Engine.mtnProfileMgr.GetMtnProfileActive().Z_AlwaysNonSeek)
            {
                sbMTNArgs.Append("-Z ");
            }

            return sbMTNArgs.ToString();
        }

        public static string GetDurationString(double dura)
        {
            int mins = (int)dura/1000 / 60;
            int secsLeft = (int)dura/1000 - mins * 60;
            return string.Format("{0}:{1}", mins.ToString(), secsLeft.ToString("00"));
        }
    }
}