using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TDMaker;
using TDMaker.Helpers;
using TDMaker.MediaInfo;
using TDMaker.Properties;
using ZSS;
using TDMakerLib;

namespace TorrentDescriptionMaker
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

            if (!Settings.Default.WritePublish && ps.Length > 1)
            {
                if (MessageBox.Show("Writing Publish info to File is recommended when analysing multiple files or folders. \n\nWould you like to turn this feature on?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Settings.Default.WritePublish = true;
                }
            }

            List<TorrentPacket> tps = new List<TorrentPacket>();

            foreach (string p in ps)
            {
                if (File.Exists(p) || Directory.Exists(p))
                {
                    Program.AppendDebug(string.Format("Queued {0} to create a torrent", p));
                    lbFiles.Items.Add(p);
                    TorrentPacket tp = new TorrentPacket(GetTracker(), p);
                    tps.Add(tp);

                    UpdateGuiControls();
                }
            }

            if (Settings.Default.AnalyzeAuto)
            {
                WorkerTask wt = new WorkerTask(TaskType.ANALYZE_MEDIA);
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

            if (Settings.Default.TemplatesMode)
            {
                mi.TemplateLocation = Path.Combine(Settings.Default.TemplatesDir, cboTemplate.Text);
            }

            if (Settings.Default.TakeScreenshot)
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
                if (Settings.Default.UploadScreenshot)
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
                    this.Text = string.Format("{0} - {1}", Program.gAppInfo.GetApplicationTitle(Application.ProductName, Application.ProductVersion, McoreSystem.AppInfo.VersionDepth.MajorMinorBuild), Program.GetMediaName(mi.Location));

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

        private void ConfigureMTN()
        {
            string mtnExe = (Program.IsUNIX ? "mtn" : "mtn.exe");

            if (!File.Exists(Settings.Default.MTNPath))
            {
                Settings.Default.MTNPath = Path.Combine(Application.StartupPath, mtnExe);
            }

            if (!File.Exists(Settings.Default.MTNPath))
            {
                Settings.Default.MTNPath = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), TDMakerLib.Program.PROGRAM_FILES_APP_NAME), mtnExe);
            }

            if (!File.Exists(Settings.Default.MTNPath))
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = Application.StartupPath;
                dlg.Title = "Browse for mtn.exe";
                dlg.Filter = "Applications (*.exe)|*.exe";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtMtn.Text = dlg.FileName;
                    Settings.Default.MTNPath = dlg.FileName;
                }
            }
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            this.ConfigureMTN();
        }

        private void SettingsWrite()
        {
            // MTN Args
            cboMTN_L_LocInfo.SelectedIndex = ScreenshotSettings.Default.InfoTextIndex;
            cboMTN_L_LocTimestamp.SelectedIndex = ScreenshotSettings.Default.InfoTimestampIndex;

            // Source
            if (!Settings.Default.Sources.Contains(cboSource.Text))
            {
                Settings.Default.Sources.Add(cboSource.Text);
            }
            // Source Edits
            if (!Settings.Default.SourceEdits.Contains(cboAuthoring.Text))
            {
                Settings.Default.Sources.Add(cboAuthoring.Text);
            }
            // Menus
            if (!Settings.Default.DiscMenus.Contains(cboDiscMenu.Text))
            {
                Settings.Default.DiscMenus.Add(cboDiscMenu.Text);
            }
            // Extras
            if (!Settings.Default.Extras.Contains(cboExtras.Text))
            {
                Settings.Default.Sources.Add(cboExtras.Text);
            }

            // Fonts
            if (!Settings.Default.MTNFonts.Contains(cboMTN_f_FontType.Text))
            {
                Settings.Default.MTNFonts.Add(cboMTN_f_FontType.Text);
            }

            // tm2.Write(dgvTrackers);
            TrackersWrite();
            Settings.Default.AnnounceURLIndex = cboAnnounceURL.SelectedIndex;
            Settings.Default.TemplateIndex = cboTemplate.SelectedIndex;

            Settings.Default.TorrentFolderDefault = rbTorrentDefaultFolder.Checked;

            Settings.Default.ScreenshotDestIndex = cboScreenshotDest.SelectedIndex;

            Program.Save();

        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // this.WindowState = FormWindowState.Minimized;
            SettingsWrite();
            Program.WriteDebugLog();
            Program.ClearScreenshots();
        }

        private void ConfigureLogo()
        {
            // Logo
            string logo1 = Path.Combine(Application.StartupPath, "logo1.png");
            if (!File.Exists(logo1))
            {
                logo1 = Path.Combine(Settings.Default.SettingsDir, "logo1.png");
            }

            string logo2 = Path.Combine(Application.StartupPath, "logo.png");
            if (!File.Exists(logo2))
            {
                logo2 = Path.Combine(Settings.Default.SettingsDir, "logo.png");
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

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

            ConfigureDirs();
            // ConfigureGUIForUnix();
            SettingsRead();
            ConfigureLogo();

            sBar.Text = string.Format("Ready.");

            this.Text = Program.gAppInfo.GetApplicationTitle(Application.ProductName, Application.ProductVersion,
                McoreSystem.AppInfo.VersionDepth.MajorMinorBuild) +
                " - Drag and Drop a Movie file or folder...";

            UpdateGuiControls();

            if (Settings.Default.UpdateCheckAuto)
            {
                UpdateChecker uc = new UpdateChecker(this.Icon, Resources.GenuineAdv, sBar, false);
                uc.CheckUpdates();
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
            Program.LogsDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Path.Combine(dir, "Logs"));
            if (!Directory.Exists(Program.LogsDir))
            {
                Directory.CreateDirectory(Program.LogsDir);
            }
            Program.DebugLogFilePath = String.Format(Path.Combine(Program.LogsDir, "debug-{0}-log.txt"), DateTime.Now.ToString("yyyyMMdd"));


            // configure Screenshots folder
            if (!Directory.Exists(Program.GetScreenShotsDir()))
                Directory.CreateDirectory(Program.GetScreenShotsDir());

            // configure Settings folder
            if (string.IsNullOrEmpty(Settings.Default.SettingsDir) ||
                !Directory.Exists(Settings.Default.SettingsDir))
            {
                Settings.Default.SettingsDir =
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Path.Combine(dir, "Settings"));

                if (!Directory.Exists(Settings.Default.SettingsDir))
                    Directory.CreateDirectory(Settings.Default.SettingsDir);
            }

            // configure Templates folder
            if (string.IsNullOrEmpty(Settings.Default.TemplatesDir) ||
                !Directory.Exists(Settings.Default.TemplatesDir))
            {
                Settings.Default.TemplatesDir =
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Path.Combine(dir, "Templates"));

                if (!Directory.Exists(Settings.Default.TemplatesDir))
                    Directory.CreateDirectory(Settings.Default.TemplatesDir);
            }


            Program.WriteTemplates(false);

            // Read Templates to GUI
            if (Directory.Exists(Settings.Default.TemplatesDir))
            {
                string[] dirs = Directory.GetDirectories(Settings.Default.TemplatesDir);
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
                cboTemplate.SelectedIndex = Math.Max(Settings.Default.TemplateIndex, 0);
                cboQuickTemplate.SelectedIndex = Math.Max(Settings.Default.TemplateIndex, 0);
            }

            // Configure Torrents folder
            if (string.IsNullOrEmpty(Settings.Default.TorrentsCustomDir) ||
                !Directory.Exists(Settings.Default.TorrentsCustomDir))
            {
                Settings.Default.TorrentsCustomDir =
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Path.Combine(dir, "Torrents"));

                if (!Directory.Exists(Settings.Default.TorrentsCustomDir))
                    Directory.CreateDirectory(Settings.Default.TorrentsCustomDir);
            }
            mTrackerManager = new TrackerManager();

        }

        private void SettingsRead()
        {

            rbFile.Checked = !Settings.Default.BrowseDir;
            rbTExt.Checked = chkTemplatesMode.Checked;
            rbTInt.Checked = !rbTExt.Checked;

            cboScreenshotDest.Items.Clear();
            foreach (ScreenshotDestType sdt in Enum.GetValues(typeof(ScreenshotDestType)))
            {
                cboScreenshotDest.Items.Add(sdt.ToDescriptionString());
            }
            cboScreenshotDest.SelectedIndex = Settings.Default.ScreenshotDestIndex;

            if (string.IsNullOrEmpty(Settings.Default.MTNPath))
                Settings.Default.MTNPath = Path.Combine(Application.StartupPath, "mtn.exe");

            cboMTN_L_LocInfo.SelectedIndex = ScreenshotSettings.Default.InfoTextIndex;
            cboMTN_L_LocTimestamp.SelectedIndex = ScreenshotSettings.Default.InfoTimestampIndex;

            cboSource.Items.Clear();
            foreach (string src in Settings.Default.Sources)
            {
                cboSource.Items.Add(src);
            }

            cboAuthoring.Items.Clear();
            foreach (string ed in Settings.Default.SourceEdits)
            {
                cboAuthoring.Items.Add(ed);
            }

            cboDiscMenu.Items.Clear();
            foreach (string ex in Settings.Default.DiscMenus)
            {
                cboDiscMenu.Items.Add(ex);
            }

            cboExtras.Items.Clear();
            foreach (string ex in Settings.Default.Extras)
            {
                cboExtras.Items.Add(ex);
            }

            cboMTN_f_FontType.Items.Clear();
            foreach (string s in Settings.Default.MTNFonts)
            {
                cboMTN_f_FontType.Items.Add(s);
            }

            rbTorrentDefaultFolder.Checked = Settings.Default.TorrentFolderDefault;
            rbTorrentFolderCustom.Checked = !rbTorrentDefaultFolder.Checked;

            // Trackers
            TrackersRead();

        }

        private void TrackersWrite()
        {
            mTrackerManager.Trackers.Clear();

            for (int i = 0; i < dgvTrackers.Rows.Count; i++)
            {
                object name = dgvTrackers.Rows[i].Cells[0].Value;
                object url = dgvTrackers.Rows[i].Cells[1].Value;
                if (name != null && url != null)
                    mTrackerManager.Trackers.Add(new Tracker(name.ToString(), url.ToString()));

            }

            mTrackerManager.Write();

        }

        private void TrackersRead()
        {
            Console.WriteLine("Reading trackers.xml");
            mTrackerManager.Read();
            Console.WriteLine(string.Format("Read {0} trackers", mTrackerManager.Trackers.Count.ToString()));
            try
            {

                for (int i = 0; i < mTrackerManager.Trackers.Count; i++)
                {
                    dgvTrackers.Rows.Add();
                    Console.WriteLine(string.Format("Adding {0}", mTrackerManager.Trackers[i].Name));
                    dgvTrackers.Rows[i].Cells[0].Value = mTrackerManager.Trackers[i].Name;
                    dgvTrackers.Rows[i].Cells[1].Value = mTrackerManager.Trackers[i].AnnounceURL;
                }

                FillTrackersComboBox();
                if (cboAnnounceURL.Items.Count > 0)
                    cboAnnounceURL.SelectedIndex = Math.Max(Settings.Default.AnnounceURLIndex, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtBBScrFull.Text);
        }

        private string CreatePublishInitial(ref TorrentInfo ti)
        {

            PublishOptionsPacket pop = new PublishOptionsPacket();
            pop.AlignCenter = Settings.Default.AlignCenter;
            pop.FullPicture = Settings.Default.UploadScreenshot && Settings.Default.UseFullPicture;
            pop.PreformattedText = Settings.Default.PreText;
            pop.TemplatesMode = Settings.Default.TemplatesMode;

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
                    Program.WriteDebugLog();

                    // creates screenshot
                    TorrentInfo ti = new TorrentInfo(bwApp, mi);
                    ti.PublishString = CreatePublishInitial(ref ti);

                    bwApp.ReportProgress((int)ProgressType.UPDATE_SCREENSHOTS_LIST, ti.MyMedia.Screenshot);

                    if (Settings.Default.WritePublish)
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

                    if (Settings.Default.CreateTorrent)
                    {
                        WorkerCreateTorrent(mi.TorrentPacketInfo);
                    }

                }

                bwApp.ReportProgress((int)ProgressType.INCREMENT_PROGRESS_WITH_MSG, mi.Title);

            }

            return tiList;

        }

        private bool WorkerCreateTorrent(TorrentPacket tp)
        {
            bool success = true;

            string p = tp.MediaLocation;
            if (File.Exists(p) || Directory.Exists(p))
            {
                MonoTorrent.Common.TorrentCreator tc = new MonoTorrent.Common.TorrentCreator();
                tc.Private = true;
                tc.Comment = Program.GetMediaName(p);
                tc.Path = p;
                tc.PublisherUrl = "http://code.google.com/p/tdmaker";
                tc.Publisher = Application.ProductName;
                tc.StoreMD5 = true;
                List<string> temp = new List<string>();
                temp.Add(tp.Tracker.AnnounceURL);
                tc.Announces.Add(temp);

                string torrentFileName = (File.Exists(p) ? Path.GetFileName(p) : Program.GetMediaName(p)) + ".torrent";
                string torrentPath = Path.Combine(tp.TorrentFolder, torrentFileName);

                if (!Directory.Exists(tp.TorrentFolder))
                    Directory.CreateDirectory(Path.GetDirectoryName(torrentPath));

                bwApp.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, string.Format("Creating {0}", torrentPath));
                tc.Create(torrentPath);
                bwApp.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, string.Format("Created {0}", torrentPath));
            }

            return success;
        }

        private object WorkerCreateTorrents(List<TorrentPacket> tps)
        {
            try
            {
                foreach (TorrentPacket tp in tps)
                {
                    WorkerCreateTorrent(tp);
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
            Program.CurrentTask = wt.Task;

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
                switch (Program.CurrentTask)
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
                        Program.AppendDebug(msg);
                        break;
                }

            }
        }

        private void chkOptImageShack_CheckedChanged(object sender, EventArgs e)
        {
            chkUploadFullScreenshot.Enabled = chkOptImageShack.Checked;
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            lbScreenshots.Items.Clear();
            string[] files = new string[lbFiles.Items.Count];
            for (int i = 0; i < lbFiles.Items.Count; i++)
            {
                files[i] = lbFiles.Items[i].ToString();
            }
            WorkerTask wt = new WorkerTask(TaskType.ANALYZE_MEDIA);
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
            TDMaker.GUI.AboutBox ab = new TDMaker.GUI.AboutBox();
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
                cboAnnounceURL.Items.Clear();
                for (int i = 0; i < dgvTrackers.Rows.Count; i++)
                {
                    object val = dgvTrackers.Rows[i].Cells[1].Value;
                    if (val != null)
                        cboAnnounceURL.Items.Add(dgvTrackers.Rows[i].Cells[1].Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("fillTrackersComboBox() fails...");
                Console.WriteLine(ex.ToString());
            }

        }

        private Tracker GetTracker()
        {
            Tracker t = new Tracker("Unknown Tracker", "");

            if (Settings.Default.AnnounceURLIndex < 0)
                Settings.Default.AnnounceURLIndex = 0;

            if (dgvTrackers.Rows.Count > Settings.Default.AnnounceURLIndex)
            {

                object obj1 = dgvTrackers.Rows[Settings.Default.AnnounceURLIndex].Cells[0].Value;
                object obj2 = dgvTrackers.Rows[Settings.Default.AnnounceURLIndex].Cells[1].Value;

                if (obj1 != null && obj2 != null)
                {
                    t.Name = obj1.ToString();
                    t.AnnounceURL = obj2.ToString();
                }

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
                    WorkerTask wt = new WorkerTask(TaskType.CREATE_TORRENT);
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
            }
        }


        private void rbTorrentFolderCustom_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGuiControls();
        }

        private void cboAnnounceURL_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.AnnounceURLIndex = cboAnnounceURL.SelectedIndex;
        }

        private void dgvTrackers_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (null == e.FormattedValue || string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                MessageBox.Show(string.Format("{0} cannot be null.", dgvTrackers.Columns[e.ColumnIndex].HeaderText));
            }
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
                pop.TemplateLocation = Path.Combine(Settings.Default.TemplatesDir, cboQuickTemplate.Text);

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

        }

        private void rbDir_CheckedChanged(object sender, EventArgs e)
        {
            gbDVD.Enabled = rbDir.Checked;
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
        }

        private void tsmTemplates_Click(object sender, EventArgs e)
        {
            FileSystem.OpenDirTemplates();
        }

        private void CheckUpdates()
        {
            UpdateChecker uc = new UpdateChecker(this.Icon, Resources.GenuineAdv, sBar, true);
            uc.CheckUpdates();
        }

        private void tsmUpdatesCheck_Click(object sender, EventArgs e)
        {
            CheckUpdates();
        }

        private void cboScreenshotDest_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.ScreenshotDestIndex = cboScreenshotDest.SelectedIndex;
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
                int old = cboAnnounceURL.SelectedIndex;
                FillTrackersComboBox();
                if (cboAnnounceURL.Items.Count > 0)
                {
                    if (old < 0) old = 0;
                    cboAnnounceURL.SelectedIndex = Math.Min(old, cboAnnounceURL.Items.Count - 1);
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
            CheckUpdates();
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

    }
}
