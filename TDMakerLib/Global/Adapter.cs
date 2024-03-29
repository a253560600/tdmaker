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

#endregion License Information (GPL v2)

using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UploadersLib.HelperClasses;

namespace TDMakerLib
{
    /// <summary>
    /// Description of Adapter.
    /// </summary>
    public static class Adapter
    {
        public static string GetMtnArg(XMLSettingsScreenshot screenshotSettings)
        {
            return GetMtnArg(Program.PicturesDir, screenshotSettings);
        }

        public static string GetMtnArg(string screenshotDir, XMLSettingsScreenshot screenshotSettings)
        {
            // Fill Screenshot object : coded parameters in alphabetical order except for columns, rows and width

            StringBuilder sbMTNArgs = new StringBuilder();
            sbMTNArgs.Append(string.Format("-c {0} ", Program.mtnProfileMgr.GetMtnProfileActive().c_Columns));
            sbMTNArgs.Append(string.Format("-r {0} ", Program.mtnProfileMgr.GetMtnProfileActive().r_Rows));

            if (Program.mtnProfileMgr.GetMtnProfileActive().w_Width != XMLSettingsScreenshot.w_Width_default)
            {
                sbMTNArgs.Append(string.Format("-w {0} ", Program.mtnProfileMgr.GetMtnProfileActive().w_Width));
            }

            if (Program.mtnProfileMgr.GetMtnProfileActive().a_AspectRatio != XMLSettingsScreenshot.a_AspectRatio_default)
            {
                sbMTNArgs.Append(string.Format("-a {0} ", Program.mtnProfileMgr.GetMtnProfileActive().a_AspectRatioValue));
            }

            if (Program.mtnProfileMgr.GetMtnProfileActive().b_SkipBlank != XMLSettingsScreenshot.b_SkipBlank_default)
            {
                sbMTNArgs.Append(string.Format("-b {0} ", Program.mtnProfileMgr.GetMtnProfileActive().b_SkipBlank));
            }

            if (Program.mtnProfileMgr.GetMtnProfileActive().B_OmitBegin != XMLSettingsScreenshot.B_OmitBegin_default)
            {
                sbMTNArgs.Append(string.Format("-B {0} ", Program.mtnProfileMgr.GetMtnProfileActive().B_OmitBegin));
            }

            // c is added earlier

            if (Program.mtnProfileMgr.GetMtnProfileActive().C_CutMovie != XMLSettingsScreenshot.C_CutMovie_default)
            {
                sbMTNArgs.Append(string.Format("-C {0} ", Program.mtnProfileMgr.GetMtnProfileActive().C_CutMovie));
            }

            if (Program.mtnProfileMgr.GetMtnProfileActive().D_EdgeDetection != XMLSettingsScreenshot.D_EdgeDetection_default)
            {
                sbMTNArgs.Append(string.Format("-D {0} ", Program.mtnProfileMgr.GetMtnProfileActive().D_EdgeDetection));
            }

            if (Program.mtnProfileMgr.GetMtnProfileActive().E_OmitEnd != XMLSettingsScreenshot.E_OmitEnd_default)
            {
                sbMTNArgs.Append(string.Format("-E {0} ", Program.mtnProfileMgr.GetMtnProfileActive().E_OmitEnd));
            }

            if (Program.mtnProfileMgr.GetMtnProfileActive().i_InfoOff || Program.IsUNIX)
            {
                sbMTNArgs.Append("-i ");
            }
            else if (!Program.IsUNIX)
            {
                if (Program.mtnProfileMgr.GetMtnProfileActive().f_FontFile != XMLSettingsScreenshot.f_FontFile_default)
                {
                    sbMTNArgs.Append(string.Format("-f {0} ", Program.mtnProfileMgr.GetMtnProfileActive().f_FontFile));
                }
                if (Program.mtnProfileMgr.GetMtnProfileActive().F_FontColor != XMLSettingsScreenshot.F_FontColor_default)
                {
                    sbMTNArgs.Append(string.Format("-F {0}:{1} ", Program.mtnProfileMgr.GetMtnProfileActive().F_FontColor, Program.mtnProfileMgr.GetMtnProfileActive().F_FontSize));
                }
            }

            if (Program.mtnProfileMgr.GetMtnProfileActive().g_GapBetweenShots != XMLSettingsScreenshot.g_GapBetweenShots_default)
            {
                sbMTNArgs.Append(string.Format("-g {0} ", Program.mtnProfileMgr.GetMtnProfileActive().g_GapBetweenShots));
            }

            if (Program.mtnProfileMgr.GetMtnProfileActive().h_MinHeight != XMLSettingsScreenshot.h_MinHeight_default)
            {
                sbMTNArgs.Append(string.Format("-h {0} ", Program.mtnProfileMgr.GetMtnProfileActive().h_MinHeight));
            }

            // i is added earlier

            if (Program.mtnProfileMgr.GetMtnProfileActive().I_IndivScreens)
            {
                sbMTNArgs.Append("-I ");
            }

            if (Program.mtnProfileMgr.GetMtnProfileActive().j_JpgQuality != XMLSettingsScreenshot.g_GapBetweenShots_default)
            {
                sbMTNArgs.Append(string.Format("-j {0} ", Program.mtnProfileMgr.GetMtnProfileActive().j_JpgQuality));
            }

            if (Program.mtnProfileMgr.GetMtnProfileActive().k_ColorBackground != XMLSettingsScreenshot.k_ColorBackground_default)
            {
                sbMTNArgs.Append(string.Format("-k {0} ", Program.mtnProfileMgr.GetMtnProfileActive().k_ColorBackground));
            }

            if (Program.mtnProfileMgr.GetMtnProfileActive().t_TimeStampOff || Program.IsUNIX)
            {
                sbMTNArgs.Append("-t ");
            }
            else if (!Program.IsUNIX)
            {
                if (Program.mtnProfileMgr.GetMtnProfileActive().L_LocInfo != XMLSettingsScreenshot.L_LocInfo_default || Program.mtnProfileMgr.GetMtnProfileActive().L_LocTimestamp != XMLSettingsScreenshot.L_LocInfo_default)
                {
                    sbMTNArgs.Append(string.Format("-L {0}:{1} ", Program.mtnProfileMgr.GetMtnProfileActive().L_LocInfo, Program.mtnProfileMgr.GetMtnProfileActive().L_LocTimestamp));
                }
            }

            if (Program.mtnProfileMgr.GetMtnProfileActive().N_InfoSuffix != XMLSettingsScreenshot.N_InfoSuffix_default || Program.IsUNIX)
            {
                sbMTNArgs.Append(string.Format("-N {0} ", Program.mtnProfileMgr.GetMtnProfileActive().N_InfoSuffix));
            }

            if (Program.mtnProfileMgr.GetMtnProfileActive().o_OutputSuffix != XMLSettingsScreenshot.o_OutputSuffix_default)
            {
                sbMTNArgs.Append(string.Format("-o {0} ", Program.mtnProfileMgr.GetMtnProfileActive().o_OutputSuffix));
            }

            sbMTNArgs.Append(string.Format("-O \"{0}\" ", screenshotDir));

            if (Program.mtnProfileMgr.GetMtnProfileActive().P_QuitAfterDone)
            {
                sbMTNArgs.Append("-P ");
            }
            else if (Program.mtnProfileMgr.GetMtnProfileActive().p_PauseBeforeExit)
            {
                sbMTNArgs.Append("-p ");
            }

            // r is added earlier

            if (Program.mtnProfileMgr.GetMtnProfileActive().s_TimeStep != XMLSettingsScreenshot.s_TimeStep_default)
            {
                sbMTNArgs.Append(string.Format("-s {0} ", Program.mtnProfileMgr.GetMtnProfileActive().s_TimeStep));
            }

            // t is added earlier

            if (Program.mtnProfileMgr.GetMtnProfileActive().T_TitleTextAdd)
            {
                if (Program.mtnProfileMgr.GetMtnProfileActive().T_TitleText == "%Title%")
                {
                    sbMTNArgs.Append(string.Format("-T \"{0}\" ", Program.Settings.txtMTN_T_Title));
                }
            }

            if (Program.mtnProfileMgr.GetMtnProfileActive().v_Verbose)
            {
                sbMTNArgs.Append("-v ");
            }

            // w is added earlier

            if (Program.mtnProfileMgr.GetMtnProfileActive().z_AlwaysSeek)
            {
                sbMTNArgs.Append("-z ");
            }
            else if (Program.mtnProfileMgr.GetMtnProfileActive().Z_AlwaysNonSeek)
            {
                sbMTNArgs.Append("-Z ");
            }

            return sbMTNArgs.ToString();
        }

        public static string GetDurationString(double dura)
        {
            int mins = (int)dura / 1000 / 60;
            int secsLeft = (int)dura / 1000 - mins * 60;
            return string.Format("{0}:{1}", mins.ToString(), secsLeft.ToString("00"));
        }

        /// <summary>
        /// Remove HTML from string with Regex.
        /// </summary>
        public static string StripImg(string source)
        {
            return Regex.Replace(source, @"\[img\].*?\[/img\]", string.Empty);
        }

        public static bool MediaIsAudio(string dir)
        {
            List<string> fileColl = new List<string>();
            if (Directory.Exists(dir))
            {
                foreach (string ext in Program.Settings.SupportedFileExtAudio)
                {
                    fileColl.AddRange(Directory.GetFiles(dir, "*" + ext, SearchOption.AllDirectories));
                }
                foreach (string ext in Program.Settings.SupportedFileExtVideo)
                {
                    fileColl.AddRange(Directory.GetFiles(dir, "*" + ext, SearchOption.AllDirectories));
                }
            }
            return MediaIsAudio(fileColl);
        }

        public static bool MediaIsAudio(List<string> fileColl)
        {
            bool allAudio = true;
            List<MediaFile> tempMediaFiles = new List<MediaFile>();
            foreach (string fp in fileColl)
            {
                tempMediaFiles.Add(new MediaFile(fp, ""));
            }

            foreach (MediaFile mf in tempMediaFiles)
            {
                allAudio = mf.IsAudioFile() && allAudio;
            }
            return allAudio;
        }

        public static bool MediaIsDisc(string p)
        {
            bool dir = Directory.Exists(p);

            if (dir)
            {
                string[] ifo = Directory.GetFiles(p, "VTS_01_0.IFO", SearchOption.AllDirectories);
                string[] vob = Directory.GetFiles(p, "*.VOB", SearchOption.AllDirectories);
                dir = ifo.Length > 0 && vob.Length > 0;
            }
            else if (File.Exists(p))
            {
                dir = Path.GetExtension(p).ToLower() == "iso";
            }

            return dir;
        }

        public static MediaWizardOptions GetMediaType(List<string> FileOrDirPaths)
        {
            return GetMediaType(FileOrDirPaths, false);
        }

        public static MediaWizardOptions GetMediaType(List<string> FileOrDirPaths, bool silent)
        {
            MediaWizardOptions mwo = new MediaWizardOptions() { MediaTypeChoice = MediaType.MediaIndiv };

            bool showWizard = false;

            if (FileOrDirPaths.Count == 1 && File.Exists(FileOrDirPaths[0]))
            {
                mwo.MediaTypeChoice = MediaType.MediaIndiv;
            }
            else
            {
                bool bDirFound = false;
                int dirCount = 0;

                foreach (string fd in FileOrDirPaths)
                {
                    if (Directory.Exists(fd))
                    {
                        dirCount++;
                        bDirFound = true;
                    }
                    if (dirCount > 1) break;
                }
                if (bDirFound)
                {
                    if (dirCount == 1)
                    {
                        string dir = FileOrDirPaths[0];
                        if (MediaIsDisc(dir))
                        {
                            mwo.MediaTypeChoice = MediaType.MediaDisc;
                        }
                        else if (MediaIsAudio(dir))
                        {
                            mwo.MediaTypeChoice = MediaType.MusicAudioAlbum;
                        }
                        else if (!silent)
                        {
                            showWizard = true;
                        }
                    }
                }
                else if (!silent) // no dir found
                {
                    showWizard = true;
                }
            }

            if (showWizard)
            {
                MediaWizard mw = new MediaWizard(FileOrDirPaths);
                mwo.DialogResultMy = mw.ShowDialog();
                if (mwo.DialogResultMy == DialogResult.OK)
                {
                    mwo = mw.Options;
                }
                mwo.PromptShown = true;
            }

            FileSystem.AppendDebug("Determined media type as: " + mwo.MediaTypeChoice.ToString());
            return mwo;
        }

        /// <summary>
        /// Function to determine DVD-5 or DVD-9
        /// </summary>
        /// <returns>DVD-5 or DVD-9</returns>
        public static string GetDVDString(string p)
        {
            string ss = "DVD";
            double size = 0.0;      // size in Bytes
            if (MediaIsDisc(p))
            {
                string[] files = Directory.GetFiles(p, "*.*", SearchOption.AllDirectories);
                foreach (string f in files)
                {
                    FileInfo fi = new FileInfo(f);
                    size += fi.Length;
                }
                if (size > 0.0)
                {
                    ss = (size > 4.7 * 1000.0 * 1000.0 * 1000.0 ? "DVD-9" : "DVD-5");
                }
            }
            return ss;
        }

        #region Publish

        public static string CreatePublish(TorrentInfo ti, PublishOptionsPacket pop)
        {
            string pt = "";

            switch (pop.PublishInfoTypeChoice)
            {
                case PublishInfoType.ExternalTemplate:
                    if (Directory.Exists(pop.TemplateLocation))
                    {
                        pt = ti.CreatePublish(pop, new TemplateReader2(pop.TemplateLocation, ti));
                    }
                    else if (Directory.Exists(ti.Media.TemplateLocation))
                    {
                        pt = ti.CreatePublish(pop, new TemplateReader2(ti.Media.TemplateLocation, ti));
                    }
                    else
                    {
                        pt = ti.CreatePublishInternal(pop);
                    }
                    break;

                case PublishInfoType.InternalTemplate:
                    pt = ti.CreatePublishInternal(pop);
                    break;

                case PublishInfoType.MediaInfo:
                    pt = ti.CreatePublishMediaInfo(pop);
                    break;
            }

            ti.Media.ReleaseDescription = Adapter.StripImg(pt).Trim(); ;

            return pt;
        }

        #endregion Publish
    }
}