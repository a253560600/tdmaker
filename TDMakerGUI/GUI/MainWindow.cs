using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TDMakerLib;
using ZSS;
using TDMakerLib.MediaInfo;
using TDMakerLib.Helpers;
using UploadersLib;

namespace TDMaker
{
    public partial class MainWindow : Form
    {
        private TrackerManager mTrackerManager = null;
        /// <summary>
        /// Global TorrentInfo for Using Quick Pre/Align Center commands
        /// </summary>
        private TorrentInfo mTorrentInfo = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void MainWindow_DragDrop(object sender, DragEventArgs e)
        {

            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop, true);
            LoadMedia(paths);

        }

        private void MakeGUIReadyForAnalysis()
        {
            lbScreenshots.Items.Clear();
            pBar.Value = 0;
        }

        private void LoadMedia(string[] ps)
        {

            lbFiles.Items.Clear();

            if (1 == ps.Length)
            {
                txtTitle.Text = Program.GetMediaName(ps[0]);
                if (cboSource.Text == "DVD")
                {
                    cboSource.Text = Program.GetDVDString(ps[0]);
                }
            }

            if (!Program.conf.WritePublish && ps.Length > 1)
            {
                if (MessageBox.Show("Writing Publish info to File is recommended when analysing multiple files or folders. \n\nWould you like to turn this feature on?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Program.conf.WritePublish = true;
                }
            }

            List<TorrentPacket> tps = new List<TorrentPacket>();

            foreach (string p in ps)
            {
                if (File.Exists(p) || Directory.Exists(p))
                {
                    // txtMediaLocation.Text = p;
                    FileSystem.AppendDebug(string.Format("Queued {0} to create a torrent", p));
                    lbFiles.Items.Add(p);
                    TorrentPacket tp = new TorrentPacket(GetTracker(), p);
                    tps.Add(tp);

                    UpdateGuiControls();
                }
            }

            if (Program.conf.AnalyzeAuto)
            {
                WorkerTask wt = new WorkerTask(bwApp, TaskType.ANALYZE_MEDIA);
                wt.FilePaths = ps;
                AnalyzeMedia(wt);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p">File or Folder</param>
        /// <returns></returns>
        private List<string> CreateFileList(string p)
        {
            List<string> fl = new List<string>();
            if (File.Exists(p))
            {
                fl.Add(p);
            }
            else if (Directory.Exists(p))
            {

            }
            return fl;
        }

        /// <summary>
        /// Gets new MediaInfo2 object from settings based on GUI Controls
        /// </summary>
        /// <param name="p">File or Folder path of the Media</param>
        /// <returns>MediaInfo2 object</returns>
        private MediaInfo2 PrepareNewMedia(string p)
        {
            MediaInfo2 mi = new MediaInfo2(p);
            mi.Extras = cboExtras.Text;
            if (cboSource.Text == "DVD")
            {
                mi.Source = Program.GetDVDString(p);
            }
            else
            {
                mi.Source = cboSource.Text;
            }
            mi.Menu = cboDiscMenu.Text;
            mi.Authoring = cboAuthoring.Text;
            mi.WebLink = txtWebLink.Text;
            mi.TorrentPacketInfo = new TorrentPacket(GetTracker(), p);

            if (Program.conf.TemplatesMode)
            {
                mi.TemplateLocation = Path.Combine(Program.conf.TemplatesDir, cboTemplate.Text);
            }

            if (Program.conf.TakeScreenshot)
            {

                // Create MTN Arg

                // Fill Screenshot object : coded parameters in alphabetical order
                StringBuilder sbMTNArgs = new StringBuilder();
                if (chkMTN_P_QuitAfterDone.Checked)
                {
                    sbMTNArgs.Append("-P ");
                }
                sbMTNArgs.Append(string.Format("-w{0} ", nudMTN_w_Width.Value));
                if (chkMTN_h_Height.Checked)
                {
                    sbMTNArgs.Append(string.Format("-h{0} ", nudMTN_h_HeightMin.Value));
                }
                sbMTNArgs.Append(string.Format("-c{0} ", nudMTN_c_Columns.Value));
                sbMTNArgs.Append(string.Format("-r{0} ", nudMTN_r_Rows.Value));
                if (chkMTN_F_FontColor.Checked)
                {
                    sbMTNArgs.Append(string.Format("-k{0} ", cboMTN_k_ColorBkgrd.Text));
                }

                if (chkMTN_i_MediaInfoTurnOff.Checked || Program.IsUNIX)
                {
                    sbMTNArgs.Append("-i ");
                }
                else if (!Program.IsUNIX)
                {
                    if (chkMTN_f_Font.Checked)
                    {
                        sbMTNArgs.Append(string.Format("-f {0} ", cboMTN_f_FontType.Text));
                    }
                    if (chkMTN_k_ColorBackground.Checked && chkMTN_F_FontSize.Checked)
                    {
                        sbMTNArgs.Append(string.Format("-F {0}:{1} ", cboMTN_F_FontColor.Text, nudMTN_F_FontSize.Value));
                    }
                }
                if (!chkMTN_tL_LocTimestamp.Checked || Program.IsUNIX)
                {
                    sbMTNArgs.Append("-t ");
                }
                else if (!Program.IsUNIX)
                {
                    if (chkMTN_L_LocInfo.Checked && chkMTN_tL_LocTimestamp.Checked)
                    {
                        sbMTNArgs.Append(string.Format("-L {0}:{1} ", cboMTN_L_LocInfo.SelectedIndex + 1, cboMTN_L_LocTimestamp.SelectedIndex + 1));
                    }
                }

                if (chkMTN_g_Gap.Checked)
                {
                    sbMTNArgs.Append(string.Format("-g {0} ", nudMTN_g_Gap.Value));
                }
                if (chkMTN_j_JPEGQuality.Checked)
                {
                    sbMTNArgs.Append(string.Format("-j {0} ", nudMTN_j_JPEGQuality.Value));
                }
                if (chkMTN_s_TimeStep.Checked)
                {
                    sbMTNArgs.Append(string.Format("-s {0} ", nudMTN_s_TimeStep.Value));
                }

                if (chkMTN_D_EdgeDetection.Checked)
                {
                    sbMTNArgs.Append(string.Format("-D {0} ", nudMTN_D_EdgeDetection.Value));
                }

                if (chkMTN_B_OmitBegin.Checked)
                {
                    sbMTNArgs.Append(string.Format("-B {0} ", nudMTN_B_OmitStart.Value));
                }

                if (chkMTN_E_OmitEnd.Checked)
                {
                    sbMTNArgs.Append(string.Format("-E {0} ", nudMTN_E_OmitEnd.Value));
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

                if (chkMTN_N_WriteInfo.Checked || Program.IsUNIX)
                {
                    sbMTNArgs.Append(string.Format("-N {0} ", txtMTN_N_InfoSuffix.Text));
                    mi.Screenshot.Settings.N_InfoSuffix = txtMTN_N_InfoSuffix.Text;
                }

                if (chkMTN_o_OutputSuffix.Checked)
                {
                    sbMTNArgs.Append(string.Format("-o {0} ", txtMTN_o_OutputSuffix.Text));
                    mi.Screenshot.Settings.o_OutputSuffix = txtMTN_o_OutputSuffix.Text;
                }
                if (chkMTN_v_Verbose.Checked)
                {
                    sbMTNArgs.Append("-v ");
                }
                if (chkMTN_T_Title.Checked)
                {
                    if (txtMTN_T_Title.Text == "%Title%")
                    {
                        txtMTN_T_Title.Text = txtTitle.Text;
                    }
                    sbMTNArgs.Append(string.Format("-T \"{0}\" ", txtMTN_T_Title.Text));
                }

                sbMTNArgs.Append(string.Format("-O \"{0}\" ", Program.GetScreenShotsDir()));

                mi.Screenshot.MTNArgs = sbMTNArgs.ToString();

                //mi.Screenshot.Settings.c_Columns = (int)nudMTN_c_Columns.Value;
                //mi.Screenshot.Settings.j_JpgQuality = (int)nudMTN_j_JPEGQuality.Value;
                //mi.Screenshot.FontStyle = string.Format("{0}:{1}", cboMTN_F_FontColor.Text, nudMTN_F_FontSize.Value);
                //mi.Screenshot.Settings.L_InfoLocation = string.Format("{0}:{1}", cboMTN_L_LocInfo.SelectedIndex, cboMTN_L_LocTimestamp.SelectedIndex);
                //mi.Screenshot.Settings.P_QuitAfterDone = chkMTN_P_QuitAfterDone.Checked;
                //mi.Screenshot.Settings.r_Rows = (int)nudMTN_r_Rows.Value;
                //mi.Screenshot.Settings.w_Width = (int)nudMTN_w_Width.Value;

                // Screenshots Mode
                if (Program.conf.UploadScreenshot)
                {
                    mi.TakeScreenshots = TakeScreenshotsType.TAKE_ONE_SCREENSHOT;

                }
            }
            return mi;
        }

        private void AnalyzeMedia(WorkerTask wt)
        {
            List<MediaInfo2> miList = new List<MediaInfo2>();

            foreach (string p in wt.FilePaths)
            {
                if (File.Exists(p) || Directory.Exists(p))
                {

                    MakeGUIReadyForAnalysis();

                    MediaInfo2 mi = this.PrepareNewMedia(p);
                    if (wt.IsSingleTask() && !string.IsNullOrEmpty(txtTitle.Text))
                    {
                        mi.SetTitle(txtTitle.Text);
                    }

                    // if it is a DVD, set the title to be name of the folder. 
                    this.Text = string.Format("{0} - {1}", Loader.gAppInfo.GetApplicationTitle(Application.ProductName, Application.ProductVersion, McoreSystem.AppInfo.VersionDepth.MajorMinorBuild), Program.GetMediaName(mi.Location));

                    txtScrFull.Text = "";
                    txtBBScrFull.Text = "";
                    txtBBScrForums.Text = "";

                    // pBar.Style = ProgressBarStyle.Marquee;

                    // lbStatus.Items.Add("Analyzing Media using MediaInfo.");

                    miList.Add(mi);

                }
            }

            if (!bwApp.IsBusy)
            {
                wt.MediaFiles = miList;
                bwApp.RunWorkerAsync(wt);
            }

            UpdateGuiControls();

        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            string mtnExe = (Program.IsUNIX ? "mtn" : "mtn.exe");

            if (!File.Exists(Program.conf.MTNPath))
            {
                Program.conf.MTNPath = Path.Combine(Application.StartupPath, mtnExe);
            }

            if (!File.Exists(Program.conf.MTNPath))
            {
                Program.conf.MTNPath = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), Program.PROGRAM_FILES_APP_NAME), mtnExe);
            }

            if (!File.Exists(Program.conf.MTNPath))
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = Application.StartupPath;
                dlg.Title = "Browse for mtn.exe";
                dlg.Filter = "Applications (*.exe)|*.exe";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Program.conf.MTNPath = dlg.FileName;
                }
            }
        }

        private void SettingsWrite()
        {
            // MTN Args
            cboMTN_L_LocInfo.SelectedIndex = Program.conf.ScreenshotSettings.L_LocInfo;
            cboMTN_L_LocTimestamp.SelectedIndex = Program.conf.ScreenshotSettings.L_LocTimestamp;

            // Source
            if (!Program.conf.Sources.Contains(cboSource.Text))
            {
                Program.conf.Sources.Add(cboSource.Text);
            }
            // Source Edits
            if (!Program.conf.AuthoringModes.Contains(cboAuthoring.Text))
            {
                Program.conf.Sources.Add(cboAuthoring.Text);
            }
            // Menus
            if (!Program.conf.DiscMenus.Contains(cboDiscMenu.Text))
            {
                Program.conf.DiscMenus.Add(cboDiscMenu.Text);
            }
            // Extras
            if (!Program.conf.Extras.Contains(cboExtras.Text))
            {
                Program.conf.Sources.Add(cboExtras.Text);
            }

            // Fonts
            if (!Program.conf.MTNFonts.Contains(cboMTN_f_FontType.Text))
            {
                Program.conf.MTNFonts.Add(cboMTN_f_FontType.Text);
            }

            Program.conf.AnnounceURLIndex = cboTrackerGroupActive.SelectedIndex;
            Program.conf.TemplateIndex = cboTemplate.SelectedIndex;

            Program.conf.TorrentFolderDefault = rbTorrentDefaultFolder.Checked;

            Program.conf.ImageUploader = (ImageDestType2)cboScreenshotDest.SelectedIndex;

            Program.conf.Write();

        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // this.WindowState = FormWindowState.Minimized;
            SettingsWrite();
            FileSystem.WriteDebugLog();
            Program.ClearScreenshots();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ConfigureDirs();
            // ConfigureGUIForUnix();
            SettingsRead();

            // Logo
            string logo1 = Path.Combine(Application.StartupPath, "logo1.png");
            if (!File.Exists(logo1))
            {
                logo1 = Path.Combine(Program.conf.SettingsDir, "logo1.png");
            }

            string logo2 = Path.Combine(Application.StartupPath, "logo.png");
            if (!File.Exists(logo2))
            {
                logo2 = Path.Combine(Program.conf.SettingsDir, "logo.png");
            }

            if (File.Exists(logo1))
            {
                gbLocation.BackgroundImage = Image.FromFile(logo1);
                gbLocation.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (File.Exists(logo2))
            {
                //this.BackgroundImage = Image.FromFile(logo);
                //this.BackgroundImageLayout = ImageLayout.Tile;
                //tpMedia.BackgroundImage = Image.FromFile(logo);
                //tpMedia.BackgroundImageLayout = ImageLayout.None;
                pbLogo.BackgroundImage = Image.FromFile(logo2);
                pbLogo.BackgroundImageLayout = ImageLayout.Stretch;
                pbLogo.BackColor = System.Drawing.SystemColors.ControlDark;
                this.BackColor = System.Drawing.SystemColors.ControlDark;
            }

            sBar.Text = string.Format("Ready.");

            this.Text = Loader.gAppInfo.GetApplicationTitle(Application.ProductName, Application.ProductVersion,
                McoreSystem.AppInfo.VersionDepth.MajorMinorBuild) +
                " - Drag and Drop a Movie file or folder...";

            UpdateGuiControls();

            if (Program.conf.UpdateCheckAuto)
            {
                CheckUpdates(false);
            }

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                // we process the args
                lbStatus.Items.Add(Environment.CommandLine);
            }

        }

        private void ConfigureDirs()
        {
            string dir = Path.Combine("Applications", Application.ProductName);

            // configure Logs folder
            Loader.LogsDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Path.Combine(dir, "Logs"));
            if (!Directory.Exists(Loader.LogsDir))
            {
                Directory.CreateDirectory(Loader.LogsDir);
            }
            FileSystem.DebugLogFilePath = String.Format(Path.Combine(Loader.LogsDir, "debug-{0}-log.txt"), DateTime.Now.ToString("yyyyMMdd"));


            // configure Screenshots folder
            if (!Directory.Exists(Program.GetScreenShotsDir()))
                Directory.CreateDirectory(Program.GetScreenShotsDir());

            // configure Settings folder
            if (string.IsNullOrEmpty(Program.conf.SettingsDir) ||
                !Directory.Exists(Program.conf.SettingsDir))
            {
                Program.conf.SettingsDir =
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Path.Combine(dir, "Settings"));

                if (!Directory.Exists(Program.conf.SettingsDir))
                    Directory.CreateDirectory(Program.conf.SettingsDir);
            }

            // configure Templates folder
            if (string.IsNullOrEmpty(Program.conf.TemplatesDir) ||
                !Directory.Exists(Program.conf.TemplatesDir))
            {
                Program.conf.TemplatesDir =
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Path.Combine(dir, "Templates"));

                if (!Directory.Exists(Program.conf.TemplatesDir))
                    Directory.CreateDirectory(Program.conf.TemplatesDir);
            }


            Program.WriteTemplates(false);

            // Read Templates to GUI
            if (Directory.Exists(Program.conf.TemplatesDir))
            {
                string[] dirs = Directory.GetDirectories(Program.conf.TemplatesDir);
                string[] templateNames = new string[dirs.Length];
                for (int i = 0; i < templateNames.Length; i++)
                {
                    templateNames[i] = Path.GetFileName(dirs[i]);
                }
                cboTemplate.Items.Clear();
                cboQuickTemplate.Items.Clear();
                cboTemplate.Items.AddRange(templateNames);
                cboQuickTemplate.Items.AddRange(templateNames);

            }
            if (cboTemplate.Items.Count > 0)
            {
                cboTemplate.SelectedIndex = Math.Max(Program.conf.TemplateIndex, 0);
                cboQuickTemplate.SelectedIndex = Math.Max(Program.conf.TemplateIndex, 0);
            }

            // Configure Torrents folder
            if (string.IsNullOrEmpty(Program.conf.TorrentsCustomDir) ||
                !Directory.Exists(Program.conf.TorrentsCustomDir))
            {
                Program.conf.TorrentsCustomDir =
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Path.Combine(dir, "Torrents"));

                if (!Directory.Exists(Program.conf.TorrentsCustomDir))
                    Directory.CreateDirectory(Program.conf.TorrentsCustomDir);
            }
            mTrackerManager = new TrackerManager();
        }

        private void SettingsRead()
        {
        	SettingsReadInput();
        	SettingsReadMedia();
            SettingsReadScreenshots();
            SettingsReadOptions();

            cboScreenshotDest.Items.Clear();
            foreach (ImageDestType2 sdt in Enum.GetValues(typeof(ImageDestType2)))
            {
                cboScreenshotDest.Items.Add(sdt.GetDescription());
            }
            cboScreenshotDest.SelectedIndex = (int)Program.conf.ImageUploader;

            if (string.IsNullOrEmpty(Program.conf.MTNPath))
                Program.conf.MTNPath = Path.Combine(Application.StartupPath, "mtn.exe");

            cboMTN_L_LocInfo.SelectedIndex = Program.conf.ScreenshotSettings.L_LocInfo;
            cboMTN_L_LocTimestamp.SelectedIndex = Program.conf.ScreenshotSettings.L_LocTimestamp;

            cboMTN_f_FontType.Items.Clear();
            foreach (string s in Program.conf.MTNFonts)
            {
                cboMTN_f_FontType.Items.Add(s);
            }

            rbTorrentDefaultFolder.Checked = Program.conf.TorrentFolderDefault;
            rbTorrentFolderCustom.Checked = !rbTorrentDefaultFolder.Checked;

            pgApp.SelectedObject = Program.conf;
            pgMtn.SelectedObject = Program.conf.ScreenshotSettings;
        }
        
        private void SettingsReadInput()
        {
            if (Program.conf.MTNArgs.Count == 0)
            {
                Program.conf.MTNArgs.AddRange(new string[] { "-P -w 0 -c 1 -r 3 -keeeeee -f arial.ttf -g8 -F 000000:12 -L4:2 -j 97", 
                                            "-P -N _s.txt -w 0 -c 1 -r 3 -keeeeee -f arial.ttf -g8 -F 000000:12 -L4:2 -j 97", 
                                            "-P -N _s.txt -w1024 -c3 -r4 -keeeeee -f arial.ttf -g8 -F 000000:12 -L4:2 -j 97", 
                                            "-w 0 -c 1 -r 3 -keeeeee -f arial.ttf -g8 -F 000000:12 -L4:2 -j 97", 
                                          });
            }
            if (Program.conf.Sources.Count == 0)
            {
                Program.conf.Sources.AddRange(new string[] { "DVD-5", "DVD-9", "HDTV", "SDTV", "Blu-ray Disc", "HD DVD", "Laser Disc", "VHS" });
            }
            if (Program.conf.Extras.Count == 0)
            {
                Program.conf.Extras.AddRange(new string[] { "Intact", "Shrunk", "Removed", "None on Source" });
            }
            if (Program.conf.AuthoringModes.Count == 0)
            {
                Program.conf.AuthoringModes.AddRange(new string[] { "Untouched", "Shrunk" });
            }
            if (Program.conf.DiscMenus.Count == 0)
            {
                Program.conf.DiscMenus.AddRange(new string[] { "Intact", "Removed", "Shrunk" });
            }
            if (Program.conf.MTNFonts.Count == 0)
            {
                Program.conf.MTNFonts.AddRange(new string[] { "arial.ttf", "tahomabd.ttf" });
            }        	
            
            cboSource.Items.Clear();
            foreach (string src in Program.conf.Sources)
            {
                cboSource.Items.Add(src);
            }

            cboAuthoring.Items.Clear();
            foreach (string ed in Program.conf.AuthoringModes)
            {
                cboAuthoring.Items.Add(ed);
            }

            cboDiscMenu.Items.Clear();
            foreach (string ex in Program.conf.DiscMenus)
            {
                cboDiscMenu.Items.Add(ex);
            }

            cboExtras.Items.Clear();
            foreach (string ex in Program.conf.Extras)
            {
                cboExtras.Items.Add(ex);
            }            
        }

        private void SettingsReadMedia()
        {
            rbDir.Checked = Program.conf.bBrowseDir;
            rbFile.Checked = !rbDir.Checked;
            gbDVD.Enabled = rbDir.Checked;
            rbTExt.Checked = chkTemplatesMode.Checked;
            rbTInt.Checked = !rbTExt.Checked;

            chkAuthoring.Checked = Program.conf.bAuthoring;
            cboAuthoring.Text = Program.conf.AuthoringMode;

            chkDiscMenu.Checked = Program.conf.bDiscMenu;
            cboDiscMenu.Text = Program.conf.DiscMenu;

            chkExtras.Checked = Program.conf.bExtras;
            cboExtras.Text = Program.conf.Extra;

            chkSource.Checked = Program.conf.bSource;
            cboSource.Text = Program.conf.Source;
            chkTitle.Checked = Program.conf.bTitle;
            chkWebLink.Checked = Program.conf.bWebLink;
        }

        private void SettingsReadScreenshots()
        {
            chkScreenshot.Checked = Program.conf.TakeScreenshot;
            chkScreenshotUpload.Checked = Program.conf.UploadScreenshot;
        }

        private void SettingsReadOptions()
        {
            chkTemplatesMode.Checked = Program.conf.TemplatesMode;
            cboTemplate.SelectedIndex = Program.conf.TemplateIndex;
            chkUploadFullScreenshot.Checked = Program.conf.UseFullPicture;


            chkAlignCenter.Checked = Program.conf.AlignCenter;
            chkPre.Checked = Program.conf.PreText;
            chkPreIncreaseFontSize.Checked = Program.conf.LargerPreText;

            nudFontSizeIncr.Value = (decimal)Program.conf.FontSizeIncr;
            nudHeading1Size.Value = (decimal)Program.conf.FontSizeHeading1;
            nudHeading2Size.Value = (decimal)Program.conf.FontSizeHeading2;
            nudHeading3Size.Value = (decimal)Program.conf.FontSizeHeading3;
            nudBodySize.Value = (decimal)Program.conf.FontSizeBody;

            SettingsReadOptionsMTN();
            SettingsReadOptionsTorrents();
        }

        private void SettingsReadOptionsMTN()
        {
            this.chkMTN_o_OutputSuffix.Checked = Program.conf.chkMTN_o_OutputSuffix;
            this.nudMTN_B_OmitStart.Value = Program.conf.ScreenshotSettings.B_OmitBegin;
            this.chkMTN_B_OmitBegin.Checked = Program.conf.chkMTN_B_OmitBegin;
            this.nudMTN_D_EdgeDetection.Value = Program.conf.ScreenshotSettings.D_EdgeDetection;
            this.chkMTN_D_EdgeDetection.Checked = Program.conf.chkMTN_D_EdgeDetection;
            this.nudMTN_E_OmitEnd.Value = Program.conf.ScreenshotSettings.E_OmitEnd;
            this.chkMTN_E_OmitEnd.Checked = Program.conf.chkMTN_E_OmitEnd;
            this.nudMTN_h_HeightMin.Value = Program.conf.ScreenshotSettings.h_MinHeight;
            this.chkMTN_h_Height.Checked = Program.conf.chkMTN_h_Height;
            this.chkMTN_v_Verbose.Checked = Program.conf.chkMTN_v_Verbose;
            this.txtMTN_o_OutputSuffix.Text = Program.conf.ScreenshotSettings.o_OutputSuffix;
            this.chkMTN_N_WriteInfo.Checked = Program.conf.chkMTN_N_WriteInfo;
            this.chkMTN_z_SeekMode.Checked = Program.conf.ScreenshotSettings.z_Seek;
            this.chkMTN_i_MediaInfoTurnOff.Checked = Program.conf.ScreenshotSettings.i_InfoOff;
            this.chkMTN_T_Title.Checked = Program.conf.chkMTN_T_Title;
            this.chkMTN_f_Font.Checked = Program.conf.chkMTN_f_Font;
            this.chkMTN_F_FontColor.Checked = Program.conf.chkMTN_F_FontColor;
            this.cboMTN_F_FontColor.Text = Program.conf.ScreenshotSettings.F_FontColor;
            this.chkMTN_F_FontSize.Checked = Program.conf.chkMTN_F_FontSize;
            this.nudMTN_F_FontSize.Value = Program.conf.ScreenshotSettings.F_FontSize;
            this.chkMTN_L_LocInfo.Checked = Program.conf.chkMTN_L_LocInfo;
            this.nudMTN_j_JPEGQuality.Value = Program.conf.ScreenshotSettings.j_JpgQuality;
            this.chkMTN_tL_LocTimestamp.Checked = Program.conf.chkMTN_L_LocTimestamp;
            this.chkMTN_k_ColorBackground.Checked = Program.conf.chkMTN_k_ColorBackground;
            this.chkMTN_g_Gap.Checked = Program.conf.chkMTN_g_Gap;
            this.cboMTN_k_ColorBkgrd.Text = Program.conf.ScreenshotSettings.k_ColorBackground;
            this.nudMTN_w_Width.Value = Program.conf.ScreenshotSettings.w_Width;
            this.nudMTN_c_Columns.Value = Program.conf.ScreenshotSettings.c_Columns;
            this.chkMTN_P_QuitAfterDone.Checked = Program.conf.ScreenshotSettings.P_QuitAfterDone;
            this.chk_w_Width.Checked = Program.conf.chkMTN_w_Width;
            this.txtMTN_N_InfoSuffix.Text = Program.conf.ScreenshotSettings.N_InfoSuffix;
            this.cboMTN_f_FontType.Text = Program.conf.ScreenshotSettings.f_Font;
            this.chkMTN_j_JPEGQuality.Checked = Program.conf.chkMTN_j_JPEGQuality;
            this.nudMTN_s_TimeStep.Value = Program.conf.ScreenshotSettings.s_TimeStep;
            this.txtImageShackRegCode.Text = Program.conf.ImageShackRegCode;
            this.chkTorrentOrganize.Checked = Program.conf.TorrentsOrganize;
            this.rbTorrentDefaultFolder.Checked = Program.conf.TorrentFolderDefault;
            this.chkCreateTorrent.Checked = Program.conf.TorrentCreateAuto;
            this.chkMTN_s_TimeStep.Checked = Program.conf.chkMTN_s_TimeStep;
            this.nudMTN_r_Rows.Value = Program.conf.ScreenshotSettings.r_Rows;        	
        }
        
        private void SettingsReadOptionsTorrents()
        {
            lbTrackerGroups.Items.Clear();
            foreach (TrackerGroup tg in Program.conf.TrackerGroups)
            {
                lbTrackerGroups.Items.Add(tg);
                lbTrackers.Items.Clear();
                foreach (Tracker myTracker in tg.Trackers)
                {
                    lbTrackers.Items.Add(myTracker);
                }
            }

            rbTorrentDefaultFolder.Checked = Program.conf.TorrentFolderDefault;
            chkWritePublish.Checked = Program.conf.WritePublish;
            chkTorrentOrganize.Checked = Program.conf.TorrentsOrganize;

            txtTorrentCustomFolder.Text = Program.conf.TorrentsCustomDir;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtBBScrFull.Text);
        }

        private string CreatePublishInitial(ref TorrentInfo ti)
        {

            PublishOptionsPacket pop = new PublishOptionsPacket();
            pop.AlignCenter = Program.conf.AlignCenter;
            pop.FullPicture = Program.conf.UploadScreenshot && Program.conf.UseFullPicture;
            pop.PreformattedText = Program.conf.PreText;
            pop.TemplatesMode = Program.conf.TemplatesMode;

            ti.PublishOptions = pop;

            return CreatePublish(ti, pop);

        }

        private object WorkerAnalyzeMedia(WorkerTask wt)
        {
            List<MediaInfo2> miList = wt.MediaFiles;
            List<TorrentInfo> tiList = new List<TorrentInfo>();

            bwApp.ReportProgress((int)ProgressType.UPDATE_PROGRESSBAR_MAX, miList.Count);

            foreach (MediaInfo2 mi in miList)
            {

                bwApp.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, "Reading " + Path.GetFileName(mi.Location) + " using MediaInfo...");
                mi.ReadMedia();

                if (mi.Overall != null)
                {
                    bwApp.ReportProgress((int)ProgressType.REPORT_MEDIAINFO_SUMMARY, mi);
                    FileSystem.WriteDebugLog();

                    // creates screenshot
                    TorrentInfo ti = new TorrentInfo(bwApp, mi);
                    ti.PublishString = CreatePublishInitial(ref ti);

                    bwApp.ReportProgress((int)ProgressType.UPDATE_SCREENSHOTS_LIST, ti.MyMedia.Screenshot);

                    if (Program.conf.WritePublish)
                    {
                        // create textFiles of MediaInfo           
                        string txtPath = Path.Combine(mi.TorrentPacketInfo.TorrentFolder, mi.Overall.FileName) + ".txt";

                        if (!Directory.Exists(mi.TorrentPacketInfo.TorrentFolder))
                        {
                            Directory.CreateDirectory(mi.TorrentPacketInfo.TorrentFolder);
                        }

                        using (StreamWriter sw = new StreamWriter(txtPath))
                        {
                            sw.WriteLine(ti.PublishString);
                        }
                    }

                    tiList.Add(ti);

                    if (Program.conf.TorrentCreateAuto)
                    {
                        new TaskManager(new WorkerTask(bwApp, Loader.CurrentTask)).WorkerCreateTorrent(mi.TorrentPacketInfo);
                    }

                }

                bwApp.ReportProgress((int)ProgressType.INCREMENT_PROGRESS_WITH_MSG, mi.Title);

            }

            return tiList;

        }



        private object WorkerCreateTorrents(List<TorrentPacket> tps)
        {
            try
            {
                foreach (TorrentPacket tp in tps)
                {
                    new TaskManager(new WorkerTask(bwApp, Loader.CurrentTask)).WorkerCreateTorrent(tp);
                }
            }
            catch (Exception ex)
            {
                bwApp.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, ex.Message);
            }

            return null;
        }

        private void bwApp_DoWork(object sender, DoWorkEventArgs e)
        {
            // start of the magic :)

            WorkerTask wt = (WorkerTask)e.Argument;
            Loader.CurrentTask = wt.Task;

            switch (wt.Task)
            {
                case TaskType.ANALYZE_MEDIA:
                    e.Result = (List<TorrentInfo>)WorkerAnalyzeMedia(wt);
                    break;
                case TaskType.CREATE_TORRENT:
                    WorkerCreateTorrents(wt.TorrentPackets);
                    break;
            }
        }

        private string CreatePublish(TorrentInfo ti, PublishOptionsPacket pop)
        {
            string pt = "";

            if (pop.TemplatesMode)
            {
                if (Directory.Exists(pop.TemplateLocation))
                {
                    pt = ti.CreatePublish(pop, new TemplateReader(pop.TemplateLocation, ti));
                }
                else if (Directory.Exists(ti.MyMedia.TemplateLocation))
                {
                    pt = ti.CreatePublish(pop, new TemplateReader(ti.MyMedia.TemplateLocation, ti));
                }
            }
            else
            {
                pt = ti.CreatePublish(pop);
            }

            return pt;
        }

        private void UpdateGuiControls()
        {
            btnCreateTorrent.Enabled = !bwApp.IsBusy && lbFiles.Items.Count > 0;
            btnAnalyze.Enabled = !bwApp.IsBusy && lbFiles.Items.Count > 0;

            btnCopy0.Enabled = !bwApp.IsBusy && !string.IsNullOrEmpty(txtScrFull.Text);
            btnCopy1.Enabled = !bwApp.IsBusy && !string.IsNullOrEmpty(txtBBScrFull.Text);
            btnCopy2.Enabled = !bwApp.IsBusy && !string.IsNullOrEmpty(txtBBScrForums.Text);

            btnPublish.Enabled = !bwApp.IsBusy && !string.IsNullOrEmpty(txtPublish.Text);

            txtTorrentCustomFolder.Enabled = rbTorrentFolderCustom.Checked;
            btnBrowseTorrentCustomFolder.Enabled = rbTorrentFolderCustom.Checked;
            chkTorrentOrganize.Enabled = rbTorrentFolderCustom.Checked;

            gbTemplatesInternal.Enabled = !chkTemplatesMode.Checked;

        }

        private void bwApp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                switch (Loader.CurrentTask)
                {
                    case TaskType.ANALYZE_MEDIA:

                        List<TorrentInfo> tiList = (List<TorrentInfo>)e.Result;
                        if (tiList.Count > 0)
                        {
                            mTorrentInfo = tiList[tiList.Count - 1];
                        }
                        if (mTorrentInfo != null)
                        {
                            txtScrFull.Text = mTorrentInfo.MyMedia.Screenshot.Full;
                            txtBBScrForums.Text = mTorrentInfo.MyMedia.Screenshot.LinkedThumbnail;
                            pbScreenshot.ImageLocation = mTorrentInfo.MyMedia.Screenshot.LocalPath;

                            if (!string.IsNullOrEmpty(txtScrFull.Text))
                                txtBBScrFull.Text = string.Format("[img]{0}[/img]", txtScrFull.Text);

                            PublishOptionsPacket pop = mTorrentInfo.PublishOptions;

                            // initialize quick publish checkboxes
                            chkQuickAlignCenter.Checked = pop.AlignCenter;
                            chkQuickFullPicture.Checked = pop.FullPicture;
                            chkQuickPre.Checked = pop.PreformattedText;
                            cboQuickTemplate.SelectedIndex = cboTemplate.SelectedIndex;

                            this.UpdatePublish(mTorrentInfo);

                        }
                        break;
                }
            }

            UpdateGuiControls();
            pBar.Style = ProgressBarStyle.Continuous;
            sBar.Text = "Ready.";

        }

        private void tmrStatus_Tick(object sender, EventArgs e)
        {
            tssPerc.Text = (bwApp.IsBusy ? string.Format("{0}%", (100.0 * (double)pBar.Value / (double)pBar.Maximum).ToString("0.0")) : "");
            btnBrowse.Enabled = !bwApp.IsBusy;
            btnAnalyze.Enabled = !bwApp.IsBusy && lbFiles.Items.Count > 0;
            lbStatus.SelectedIndex = lbStatus.Items.Count - 1;
        }

        private void btnCopy2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtBBScrForums.Text);
        }

        private void btnCopy0_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtScrFull.Text);
        }

        private void OpenFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.Title = "Browse for Media file...";
            //dlg.Filter = "Media Files|*.avi; *.divx; *.mkv; *.ogm; *.vob;";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadMedia(dlg.FileNames);
            }
        }

        private void OpenFolder()
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Browse for DVD folder...";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadMedia(new string[] { dlg.SelectedPath });
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

            if (rbFile.Checked)
            {
                OpenFile();
            }
            else
            {
                OpenFolder();
            }

        }

        private void CopyPublish()
        {
            if (!string.IsNullOrEmpty(txtPublish.Text))
            {
                Clipboard.SetText(txtPublish.Text);
            }
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            CopyPublish();
        }

        private void bwApp_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string msg = "";
            if (e.UserState.GetType() == typeof(string))
            {
                msg = e.UserState.ToString();
            }

            if (e.UserState != null)
            {
                ProgressType perc = (ProgressType)e.ProgressPercentage;

                switch (perc)
                {
                    case ProgressType.INCREMENT_PROGRESS_WITH_MSG:
                        pBar.Style = ProgressBarStyle.Continuous;
                        pBar.Increment(1);
                        sBar.Text = msg;
                        break;

                    case ProgressType.REPORT_MEDIAINFO_SUMMARY:
                        MediaInfo2 mi = (MediaInfo2)e.UserState;
                        gbDVD.Enabled = (mi.MediaType == MediaType.MEDIA_DISC);
                        txtMediaInfo.Text = mi.Overall.Summary;
                        break;

                    case ProgressType.UPDATE_PROGRESSBAR_MAX:
                        pBar.Style = ProgressBarStyle.Continuous;
                        pBar.Maximum = (int)e.UserState;
                        break;

                    case ProgressType.UPDATE_SCREENSHOTS_LIST:
                        Screenshot sp = (Screenshot)e.UserState;
                        if (sp.Full != null)
                        {
                            lbScreenshots.Items.Add(sp.Full);
                        }
                        break;
                    case ProgressType.UPDATE_STATUSBAR_DEBUG:
                        sBar.Text = msg;
                        lbStatus.Items.Add(msg);
                        FileSystem.AppendDebug(msg);
                        break;
                }

            }
        }

        private void chkScreenshotUpload_CheckedChanged(object sender, EventArgs e)
        {
            chkUploadFullScreenshot.Enabled = chkScreenshotUpload.Checked;
            Program.conf.UploadScreenshot = chkScreenshotUpload.Checked;
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            lbScreenshots.Items.Clear();
            string[] files = new string[lbFiles.Items.Count];
            for (int i = 0; i < lbFiles.Items.Count; i++)
            {
                files[i] = lbFiles.Items[i].ToString();
            }
            WorkerTask wt = new WorkerTask(bwApp, TaskType.ANALYZE_MEDIA);
            wt.FilePaths = files;
            this.AnalyzeMedia(wt);
        }

        private void txtScrFull_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtScrFull.Text))
                System.Diagnostics.Process.Start(txtScrFull.Text);
        }

        private void ShowAboutWindow()
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();

        }

        private void cmsAppAbout_Click(object sender, EventArgs e)
        {
            ShowAboutWindow();

        }

        private void FillTrackersComboBox()
        {
            try
            {
                cboTrackerGroupActive.Items.Clear();
                foreach (TrackerGroup tg in lbTrackerGroups.Items)
                {
                    cboTrackerGroupActive.Items.Add(tg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("fillTrackersComboBox() fails...");
                Console.WriteLine(ex.ToString());
            }
        }

        private TrackerGroup GetTracker()
        {
            TrackerGroup t = null;

            if (Program.conf.AnnounceURLIndex < 0)
                Program.conf.AnnounceURLIndex = 0;

            if (cboTrackerGroupActive.Items.Count > Program.conf.AnnounceURLIndex)
            {
                t = cboTrackerGroupActive.Items[Program.conf.AnnounceURLIndex] as TrackerGroup;
            }
            return t;
        }

        private void CreateTorrentButton()
        {
            if (!bwApp.IsBusy)
            {
                List<TorrentPacket> tps = new List<TorrentPacket>();
                string[] files = new string[lbFiles.Items.Count];
                for (int i = 0; i < lbFiles.Items.Count; i++)
                {
                    files[i] = lbFiles.Items[i].ToString();
                    tps.Add(new TorrentPacket(GetTracker(), files[i]));
                }

                if (files.Length > 0)
                {
                    WorkerTask wt = new WorkerTask(bwApp, TaskType.CREATE_TORRENT);
                    wt.TorrentPackets = tps;
                    bwApp.RunWorkerAsync(wt);

                    btnCreateTorrent.Enabled = false;
                }
            }

        }

        private void btnCreateTorrent_Click(object sender, EventArgs e)
        {
            CreateTorrentButton();
        }

        private void btnBrowseTorrentCustomFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtTorrentCustomFolder.Text = dlg.SelectedPath;
                Program.conf.TorrentsCustomDir = txtTorrentCustomFolder.Text;
            }
        }


        private void rbTorrentFolderCustom_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGuiControls();
            if (string.IsNullOrEmpty(txtTorrentCustomFolder.Text))
            {
                txtTorrentCustomFolder.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Torrent Uploads");
            }
        }

        private void cboAnnounceURL_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.conf.AnnounceURLIndex = cboTrackerGroupActive.SelectedIndex;
        }

        private void createPublishUser()
        {
            if (mTorrentInfo != null)
            {
                PublishOptionsPacket pop = new PublishOptionsPacket();
                pop.AlignCenter = chkQuickAlignCenter.Checked;
                pop.FullPicture = chkQuickFullPicture.Checked;
                pop.PreformattedText = chkQuickPre.Checked;

                pop.TemplatesMode = rbTExt.Checked;
                pop.TemplateLocation = Path.Combine(Program.conf.TemplatesDir, cboQuickTemplate.Text);

                txtPublish.Text = CreatePublish(mTorrentInfo, pop);
            }
        }

        private void chkQuickPre_CheckedChanged(object sender, EventArgs e)
        {
            createPublishUser();
        }

        private void chkQuickAlignCenter_CheckedChanged(object sender, EventArgs e)
        {
            createPublishUser();
        }

        private void chkQuickFullPicture_CheckedChanged(object sender, EventArgs e)
        {
            createPublishUser();
        }

        private void rbFile_CheckedChanged(object sender, EventArgs e)
        {
            gbDVD.Enabled = rbDir.Checked;
        }

        private void rbDir_CheckedChanged(object sender, EventArgs e)
        {
            gbDVD.Enabled = rbDir.Checked;
            Program.conf.bBrowseDir = rbDir.Checked;
        }

        private void txtPublish_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(1))
            {
                TextBox tb = (TextBox)sender;
                tb.SelectAll();
                e.Handled = true;
            }
        }

        private void chkTemplatesMode_CheckedChanged(object sender, EventArgs e)
        {
            gbTemplatesInternal.Enabled = !chkTemplatesMode.Checked;
            Program.conf.TemplatesMode = chkTemplatesMode.Checked;
        }

        private void btnMTNHelp_Click(object sender, EventArgs e)
        {
            Process.Start("http://moviethumbnail.sourceforge.net/usage.en.html");
        }

        private void tsmTorrentsDir_Click(object sender, EventArgs e)
        {
            FileSystem.OpenDirTorrents();
        }

        private void tsmScreenshots_Click(object sender, EventArgs e)
        {
            FileSystem.OpenDirScreenshots();
        }

        private void chkScreenshot_CheckedChanged(object sender, EventArgs e)
        {
            gbScreenshotForums.Enabled = chkScreenshot.Checked;
            gbScreenshotFull.Enabled = chkScreenshot.Checked;
            Program.conf.TakeScreenshot = chkScreenshot.Checked;
        }

        private void tsmTemplates_Click(object sender, EventArgs e)
        {
            FileSystem.OpenDirTemplates();
        }

        private void CheckUpdates(bool manual)
        {
            // McoreSystem.UpdateChecker uc = new McoreSystem.UpdateChecker("http://code.google.com/p/tdmaker/downloads/list");
            //uc.Manual = manual;
            //uc.CheckUpdates();
        }

        private void tsmUpdatesCheck_Click(object sender, EventArgs e)
        {
            CheckUpdates(true);
        }

        private void cboScreenshotDest_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.conf.ImageUploader = (ImageDestType2)cboScreenshotDest.SelectedIndex;
            tpHostingImageShack.Enabled = cboScreenshotDest.SelectedIndex == 0;
        }

        private void tsmLogsDir_Click(object sender, EventArgs e)
        {
            FileSystem.OpenDirLogs();
        }

        private void lbScreenshots_DoubleClick(object sender, EventArgs e)
        {
            Process.Start(lbScreenshots.SelectedItem.ToString());
        }

        private void lbScreenshots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbScreenshots.SelectedItem != null)
                txtScrFull.Text = lbScreenshots.SelectedItem.ToString();
        }

        private void btnTemplatesRewrite_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will rewrite old copies of TDMaker created Templates. Your own templates will not be affected. \n\nAre you sure?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Program.WriteTemplates(true);
            }
        }

        private void btnImageShackRegCode_Click(object sender, EventArgs e)
        {
            Process.Start("http://my.imageshack.us/registration/");
        }

        private void btnImageShackImages_Click(object sender, EventArgs e)
        {
            Process.Start("http://my.imageshack.us/v_images.php");
        }

        private void OpenVersionHistory()
        {
            string h = Program.GetText("VersionHistory.txt");

            if (h != string.Empty)
            {
                frmTextViewer v = new frmTextViewer(string.Format("{0} - {1}",
                    Application.ProductName, "Version History"), h);
                v.Icon = this.Icon;
                v.ShowDialog();
            }
        }


        private void tmsVersionHistory_Click(object sender, EventArgs e)
        {
            OpenVersionHistory();
        }

        private void cboQuickTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            createPublishUser();

        }

        private string GetHexColor()
        {
            string hexColor = "";
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                hexColor = string.Format("0x{0:X8}", cd.Color.ToArgb());
                hexColor = hexColor.Substring(hexColor.Length - 6, 6);
            }
            return hexColor;
        }

        private void SetComboBoxTextColor(ref ComboBox cbo)
        {
            string hexColor = "";
            ColorDialog cd = new ColorDialog();
            cd.FullOpen = true;
            cd.AnyColor = true;

            if (cd.ShowDialog() == DialogResult.OK)
            {
                hexColor = string.Format("0x{0:X8}", cd.Color.ToArgb());
                hexColor = hexColor.Substring(hexColor.Length - 6, 6);
                cbo.Text = hexColor;
                cbo.BackColor = cd.Color;
            }
        }

        private void cboMTN_k_ColorBkgrd_MouseClick(object sender, MouseEventArgs e)
        {
            this.SetComboBoxTextColor(ref cboMTN_k_ColorBkgrd);
        }

        private void cboMTN_F_FontColor_MouseClick(object sender, MouseEventArgs e)
        {
            this.SetComboBoxTextColor(ref cboMTN_F_FontColor);
        }

        private void chkMTN_i_MediaInfo_CheckedChanged(object sender, EventArgs e)
        {
            gbMTN_i_MediaInfo.Enabled = !chkMTN_i_MediaInfoTurnOff.Checked;
        }

        private void btnRefreshTrackers_Click(object sender, EventArgs e)
        {
            try
            {
                int old = cboTrackerGroupActive.SelectedIndex;
                FillTrackersComboBox();
                if (cboTrackerGroupActive.Items.Count > 0)
                {
                    if (old < 0) old = 0;
                    cboTrackerGroupActive.SelectedIndex = Math.Min(old, cboTrackerGroupActive.Items.Count - 1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void tsmSettingsDir_Click(object sender, EventArgs e)
        {
            FileSystem.OpenDirSettings();
        }

        private void UpdatePublish()
        {
            this.UpdatePublish(mTorrentInfo);
        }

        private void UpdatePublish(TorrentInfo ti)
        {
            if (ti != null)
            {
                txtPublish.Text = CreatePublishInitial(ref ti);

                if (ti.MyMedia.MediaType == MediaType.MUSIC_AUDIO_ALBUM)
                {
                    txtPublish.BackColor = System.Drawing.Color.Black;
                    txtPublish.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    txtPublish.BackColor = System.Drawing.SystemColors.Window;
                    txtPublish.ForeColor = System.Drawing.SystemColors.WindowText;
                }
            }
        }



        private void rbTInt_CheckedChanged(object sender, EventArgs e)
        {
            cboQuickTemplate.Enabled = rbTExt.Checked;
            UpdatePublish();
        }

        private void rbTExt_CheckedChanged(object sender, EventArgs e)
        {
            createPublishUser();
        }

        private void WriteMediaInfo(string info)
        {
            if (mTorrentInfo != null)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Text Files (*.txt)|*.txt";
                dlg.FileName = mTorrentInfo.MyMedia.Title;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(dlg.FileName))
                    {
                        sw.WriteLine(info);
                    }
                }
            }
        }

        private void miFileSaveInfoAs_Click(object sender, EventArgs e)
        {
            string info = "";
            if (tcMain.SelectedTab == tpMainMediaInfo)
            {
                info = txtMediaInfo.Text;
            }
            else
            {
                info = txtPublish.Text;
            }
            WriteMediaInfo(info);
        }

        private void miFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcMain.SelectedTab == tpMainMediaInfo)
            {
                miFileSaveInfoAs.Text = "&Save Media Info As...";
            }
            else
            {
                miFileSaveInfoAs.Text = "&Save Publish Info As...";
            }
        }

        private void miFileSaveTorrent_Click(object sender, EventArgs e)
        {
            CreateTorrentButton();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAboutWindow();
        }

        private void miFileOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void miFileOpenFolder_Click(object sender, EventArgs e)
        {
            OpenFolder();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyPublish();
        }

        private void miHelpCheckUpdates_Click(object sender, EventArgs e)
        {
            CheckUpdates(true);
        }

        private void miFoldersScreenshots_Click(object sender, EventArgs e)
        {
            FileSystem.OpenDirScreenshots();
        }

        private void miFoldersTorrents_Click(object sender, EventArgs e)
        {
            FileSystem.OpenDirTorrents();
        }

        private void miFoldersLogs_Click(object sender, EventArgs e)
        {
            FileSystem.OpenDirLogs();
        }

        private void miFoldersLogsDebug_Click(object sender, EventArgs e)
        {
            FileSystem.OpenFileDebug();
        }

        private void miFoldersSettings_Click(object sender, EventArgs e)
        {
            FileSystem.OpenDirSettings();
        }

        private void miFoldersTemplates_Click(object sender, EventArgs e)
        {
            FileSystem.OpenDirTemplates();
        }

        private void miHelpVersionHistory_Click(object sender, EventArgs e)
        {
            OpenVersionHistory();
        }

        private void chkMTNColumns_CheckedChanged(object sender, EventArgs e)
        {
            chkMTNColumns.CheckState = CheckState.Indeterminate;
        }

        private void chkMTNRows_CheckedChanged(object sender, EventArgs e)
        {
            chkMTNRows.CheckState = CheckState.Indeterminate;
        }

        private void chkShowMTN_CheckedChanged(object sender, EventArgs e)
        {
            Program.conf.ShowMTNWindow = chkShowMTN.Checked;
        }

        private void nudMTN_r_Rows_ValueChanged(object sender, EventArgs e)
        {
            Program.conf.ScreenshotSettings.r_Rows = (int)nudMTN_r_Rows.Value;
        }

        private void chkMTN_P_QuitAfterDone_CheckedChanged(object sender, EventArgs e)
        {
            Program.conf.ScreenshotSettings.P_QuitAfterDone = chkMTN_P_QuitAfterDone.Checked;
        }

        private void pbScreenshot_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtScrFull.Text))
            {
                Process.Start(txtScrFull.Text);
            }
        }

        private void cboMTN_k_ColorBkgrd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkUseImageShackRegCode_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkRandomizeFileNameImageShack_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkCreateTorrent_CheckedChanged(object sender, EventArgs e)
        {
            Program.conf.TorrentCreateAuto = chkCreateTorrent.Checked;
        }

        private void pgApp_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            SettingsRead();
        }

        private void cboAuthoring_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.conf.AuthoringMode = cboAuthoring.Text;
        }

        private void chkSourceEdit_CheckedChanged(object sender, EventArgs e)
        {
            Program.conf.bAuthoring = chkAuthoring.Checked;
        }

        private void cboExtras_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.conf.Extra = cboExtras.Text;
        }

        private void chkExtras_CheckedChanged(object sender, EventArgs e)
        {
            Program.conf.bExtras = chkExtras.Checked;
        }

        private void cboDiscMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.conf.DiscMenu = cboDiscMenu.Text;
        }

        private void chkDiscMenu_CheckedChanged(object sender, EventArgs e)
        {
            Program.conf.bDiscMenu = chkDiscMenu.Checked;
        }

        private void chkSource_CheckedChanged(object sender, EventArgs e)
        {
            Program.conf.bSource = chkSource.Checked;
        }

        private void cboSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.conf.Source = cboSource.Text;
        }

        private void chkTitle_CheckedChanged(object sender, EventArgs e)
        {
            Program.conf.bTitle = chkTitle.Checked;
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            // we dont save this
        }

        private void chkWebLink_CheckedChanged(object sender, EventArgs e)
        {
            Program.conf.bWebLink = chkWebLink.Checked;
        }

        private void txtWebLink_TextChanged(object sender, EventArgs e)
        {
            // we dont save this
        }

        private void cboTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.conf.TemplateIndex = cboTemplate.SelectedIndex;
        }

        private void chkUploadFullScreenshot_CheckedChanged(object sender, EventArgs e)
        {
            Program.conf.UseFullPicture = chkUploadFullScreenshot.Checked;
        }

        private void chkAlignCenter_CheckedChanged(object sender, EventArgs e)
        {
            Program.conf.AlignCenter = chkAlignCenter.Checked;
        }

        private void chkPre_CheckedChanged(object sender, EventArgs e)
        {
            Program.conf.PreText = chkPre.Checked;
        }

        private void chkPreIncreaseFontSize_CheckedChanged(object sender, EventArgs e)
        {
            Program.conf.LargerPreText = chkPreIncreaseFontSize.Checked;
        }

        private void nudFontSizeIncr_ValueChanged(object sender, EventArgs e)
        {
            Program.conf.FontSizeIncr = (int)nudFontSizeIncr.Value;
        }

        private void nudFontSizeHeading1_ValueChanged(object sender, EventArgs e)
        {
            Program.conf.FontSizeHeading1 = (int)nudHeading1Size.Value;
        }

        private void nudHeading2Size_ValueChanged(object sender, EventArgs e)
        {
            Program.conf.FontSizeHeading2 = (int)nudHeading2Size.Value;
        }

        private void nudHeading3Size_ValueChanged(object sender, EventArgs e)
        {
            Program.conf.FontSizeHeading3 = (int)nudHeading3Size.Value;
        }

        private void nudBodyText_ValueChanged(object sender, EventArgs e)
        {
            Program.conf.FontSizeBody = (int)nudBodySize.Value;
        }

        private void lbTrackers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTrackers.SelectedIndex != -1)
            {
                Tracker t = lbTrackers.SelectedItem as Tracker;
                if (t != null)
                {
                    pgTracker.SelectedObject = t;
                }
                pgTracker.Enabled = t != null;
            }
        }

        private void lbTrackerGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbTrackers.Items.Clear();
            TrackerGroup tg = lbTrackerGroups.SelectedItem as TrackerGroup;
            if (tg != null)
            {
                foreach (Tracker myTracker in tg.Trackers)
                {
                    lbTrackers.Items.Add(myTracker);
                }
                lbTrackers.SelectedIndex = 0;
            }
        }

        private void btnAddTrackerGroup_Click(object sender, EventArgs e)
        {
        	ZScreenLib.InputBox ib = new ZScreenLib.InputBox();
        	ib.Title = "Enter group name";
        	ib.InputText = "Linux ISOs";
        	if (ib.ShowDialog() == DialogResult.OK) 
        	{
        		TrackerGroup tg = new TrackerGroup(ib.InputText);
            	Tracker t = new Tracker("Ubuntu", "http://torrent.ubuntu.com:6969");
            	tg.Trackers.Add(t);

            	Program.conf.TrackerGroups.Add(tg);
            	lbTrackerGroups.Items.Add(tg);
            	lbTrackerGroups.SelectedIndex = lbTrackerGroups.Items.Count - 1;

            	btnRefreshTrackers_Click(sender, e);
        	}
        }

        private void btnRemoveTrackerGroup_Click(object sender, EventArgs e)
        {
            if (lbTrackerGroups.SelectedIndex > -1)
            {
                int sel = lbTrackerGroups.SelectedIndex;
                lbTrackerGroups.Items.RemoveAt(sel);
                Program.conf.TrackerGroups.RemoveAt(sel);
                lbTrackers.Items.Clear();
                pgTracker.Enabled = false;
            }
        }

        private void btnRemoveTracker_Click(object sender, EventArgs e)
        {
            if (lbTrackers.SelectedIndex > -1 && lbTrackerGroups.SelectedIndex > -1)
            {
                int sel = lbTrackers.SelectedIndex;
                lbTrackers.Items.RemoveAt(sel);
                Program.conf.TrackerGroups[lbTrackerGroups.SelectedIndex].Trackers.RemoveAt(sel);
            }
        }

        private void chkTorrentOrganize_CheckedChanged(object sender, EventArgs e)
        {
            Program.conf.TorrentsOrganize = chkTorrentOrganize.Checked;
        }

        private void chkWritePublish_CheckedChanged(object sender, EventArgs e)
        {
            Program.conf.WritePublish = chkWritePublish.Checked;
        }

        private void rbTorrentDefaultFolder_CheckedChanged(object sender, EventArgs e)
        {
            Program.conf.TorrentFolderDefault = rbTorrentDefaultFolder.Checked;
        }

        private void txtTorrentCustomFolder_TextChanged(object sender, EventArgs e)
        {

        }
        
        void BtnAddTrackerClick(object sender, EventArgs e)
        {
        	if (lbTrackerGroups.SelectedIndex > -1) 
        	{
        		TrackerGroup tg = lbTrackerGroups.Items[lbTrackerGroups.SelectedIndex] as TrackerGroup;
        		if (tg != null) 
        		{
        			Tracker t = new Tracker("Ubuntu", "http://torrent.ubuntu.com:6969");
            		tg.Trackers.Add(t);        			        			
            		lbTrackers.Items.Add(t);
            		lbTrackers.SelectedIndex = lbTrackers.Items.Count - 1;
        		}
        	}
        }
        
        void PgTrackerPropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (lbTrackers.SelectedIndex > -1 && lbTrackerGroups.SelectedIndex > -1)
            {
                int sel = lbTrackers.SelectedIndex;
                lbTrackers.Items[sel] = (Tracker)pgTracker.SelectedObject;                
                Program.conf.TrackerGroups[lbTrackerGroups.SelectedIndex].Trackers[lbTrackers.SelectedIndex] = (Tracker)pgTracker.SelectedObject;
            }	
        }
    }
}
