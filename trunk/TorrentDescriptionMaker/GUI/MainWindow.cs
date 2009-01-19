using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TDMaker.Properties;
using TDMaker;
using System.Diagnostics;

namespace TorrentDescriptionMaker
{
    public partial class frmMain : Form
    {
        private TrackerManager mTrackerManager = null;
        /// <summary>
        /// Global TorrentInfo for Using Quick Pre/Align Center commands
        /// </summary>
        private TorrentInfo mTorrentInfo = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_DragEnter(object sender, DragEventArgs e)
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

        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {

            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop, true);
            LoadMedia(paths);

        }

        private void LoadMedia(string[] ps)
        {
            if (!Settings.Default.WritePublish && ps.Length > 1)
            {
                if (MessageBox.Show("Writing Publish info to File is recommended when analysing multiple files or folders. \n\nWould you like to turn this feature on?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Settings.Default.WritePublish = true;
                }
            }

            List<TorrentPacket> tps = new List<TorrentPacket>();

            lbFiles.Items.Clear();
            lbScreenshots.Items.Clear();

            foreach (string p in ps)
            {
                if (File.Exists(p) || Directory.Exists(p))
                {
                    // txtMediaLocation.Text = p;
                    Program.AppendDebug(string.Format("Queued {0} to create a torrent", p));
                    lbFiles.Items.Add(p);
                    TorrentPacket tp = new TorrentPacket(getTracker(), p);
                    tps.Add(tp);

                    UpdateGuiControls();
                }
            }

            if (Settings.Default.AnalyzeAuto)
            {
                WorkerTask wt = new WorkerTask(TaskType.ANALYZE_MEDIA);
                wt.FilePaths = ps;
                analyzeMedia(wt);
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

        private void analyzeMedia(WorkerTask wt)
        {
            List<MediaInfo2> miList = new List<MediaInfo2>();

            foreach (string p in wt.FilePaths)
            {
                if (File.Exists(p) || Directory.Exists(p))
                {
                    MediaInfo2 mi = new MediaInfo2(p);
                    mi.Extras = cboExtras.Text;
                    mi.Source = cboSource.Text;
                    mi.Menu = cboDiscMenu.Text;
                    mi.Authoring = cboAuthoring.Text;
                    mi.WebLink = txtWebLink.Text;
                    mi.TorrentPacketInfo = new TorrentPacket(getTracker(), p);
                    if (Settings.Default.TemplatesMode)
                    {
                        mi.TemplateLocation = Path.Combine(Settings.Default.TemplatesDir, cboTemplate.Text);
                    }

                    // Screenshots Mode
                    if (Settings.Default.UploadScreenshot)
                    {
                        mi.TakeScreenshots = TakeScreenshotsType.TAKE_ONE_SCREENSHOT;
                    }

                    // if it is a DVD, set the title to be name of the folder. 
                    this.Text = string.Format("{0} - {1}", Program.gAppInfo.GetApplicationTitle(Application.ProductName, Application.ProductVersion, McoreSystem.AppInfo.VersionDepth.MajorMinorBuild), Program.getMediaName(mi.Location));

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

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if (!File.Exists(Settings.Default.MTNPath))
            {
                Settings.Default.MTNPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), @"TDMaker\mtn.exe");

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

        private void SettingsWrite()
        {
            // MTN Args
            if (!Settings.Default.MTNArgs.Contains(cboMtnArgs.Text))
            {
                Settings.Default.MTNArgs.Add(cboMtnArgs.Text);
            }
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

            // tm2.Write(dgvTrackers);
            trackersWrite();
            Settings.Default.AnnounceURLIndex = cboAnnounceURL.SelectedIndex;
            Settings.Default.TemplateIndex = cboTemplate.SelectedIndex;

            Settings.Default.TorrentFolderDefault = rbTorrentDefaultFolder.Checked;

            Settings.Default.ScreenshotDestIndex = cboScreenshotDest.SelectedIndex;

            Settings.Default.Save();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // this.WindowState = FormWindowState.Minimized;
            SettingsWrite();
            Program.WriteDebugLog();

            if (!Settings.Default.KeepScreenshot)
            {
                // delete if option set to temporary location 
                string[] files = Directory.GetFiles(Program.ScreenshotsTempDir, "*.*", SearchOption.AllDirectories);
                foreach (string screenshot in files)
                {
                    try
                    {
                        File.Delete(screenshot);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            configureDirs();
            SettingsRead();

            Program.Status = string.Format("Ready.");

            this.Text = Program.gAppInfo.GetApplicationTitle(Application.ProductName, Application.ProductVersion,
                McoreSystem.AppInfo.VersionDepth.MajorMinorBuild) +
                " - Drag and Drop a Movie file or folder...";

            UpdateGuiControls();

            if (Settings.Default.UpdateCheckAuto)
            {
                UpdateChecker uc = new UpdateChecker(this.Icon, Resources.GenuineAdv, sBar, false);
                uc.CheckUpdates();
            }

        }

        private void configureDirs()
        {
            string dir = Path.Combine("Applications", Application.ProductName);

            // configure Logs folder
            Program.LogsDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    dir + "\\Logs");
            if (!Directory.Exists(Program.LogsDir))
            {
                Directory.CreateDirectory(Program.LogsDir);
            }
            Program.DebugLogFilePath = String.Format(Path.Combine(Program.LogsDir, "debug-{0}-log.txt"), DateTime.Now.ToString("yyyyMMdd"));


            // configure Screenshots folder
            if (!Directory.Exists(Program.ScreenshotsDir))
                Directory.CreateDirectory(Program.ScreenshotsDir);

            // configure Settings folder
            if (string.IsNullOrEmpty(Settings.Default.SettingsDir) ||
                !Directory.Exists(Settings.Default.SettingsDir))
            {
                Settings.Default.SettingsDir =
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    dir + "\\Settings");

                if (!Directory.Exists(Settings.Default.SettingsDir))
                    Directory.CreateDirectory(Settings.Default.SettingsDir);
            }

            // configure Templates folder
            if (string.IsNullOrEmpty(Settings.Default.TemplatesDir) ||
                !Directory.Exists(Settings.Default.TemplatesDir))
            {
                Settings.Default.TemplatesDir =
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    dir + "\\Templates");

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
                cboTemplate.Items.AddRange(templateNames);
            }
            if (cboTemplate.Items.Count > 0)
                cboTemplate.SelectedIndex = Math.Max(Settings.Default.TemplateIndex, 0);

            // Configure Torrents folder
            if (string.IsNullOrEmpty(Settings.Default.TorrentsCustomDir) ||
                !Directory.Exists(Settings.Default.TorrentsCustomDir))
            {
                Settings.Default.TorrentsCustomDir =
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    dir + "\\Torrents");

                if (!Directory.Exists(Settings.Default.TorrentsCustomDir))
                    Directory.CreateDirectory(Settings.Default.TorrentsCustomDir);
            }
            mTrackerManager = new TrackerManager();

        }

        private void SettingsRead()
        {

            rbFile.Checked = !Settings.Default.BrowseDir;

            cboScreenshotDest.SelectedIndex = Settings.Default.ScreenshotDestIndex;

            if (string.IsNullOrEmpty(Settings.Default.MTNPath))
                Settings.Default.MTNPath = Path.Combine(Application.StartupPath, "mtn.exe");

            cboMtnArgs.Items.Clear();
            foreach (string arg in Settings.Default.MTNArgs)
            {
                cboMtnArgs.Items.Add(arg);
            }
            // cboMtnArgs.Text = Settings.Default.MTNArg;

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


            rbTorrentDefaultFolder.Checked = Settings.Default.TorrentFolderDefault;
            rbTorrentFolderCustom.Checked = !rbTorrentDefaultFolder.Checked;

            // Trackers
            trackersRead();

        }

        private void trackersWrite()
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

        private void trackersRead()
        {

            mTrackerManager.Read();

            for (int i = 0; i < mTrackerManager.Trackers.Count; i++)
            {
                dgvTrackers.Rows.Add();
                dgvTrackers.Rows[i].Cells[0].Value = mTrackerManager.Trackers[i].Name;
                dgvTrackers.Rows[i].Cells[1].Value = mTrackerManager.Trackers[i].AnnounceURL;
            }

            fillTrackersComboBox();
            if (cboAnnounceURL.Items.Count > 0)
                cboAnnounceURL.SelectedIndex = Math.Max(Settings.Default.AnnounceURLIndex, 0);

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtBBScrFull.Text);
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
                    bwApp.ReportProgress((int)ProgressType.REPORT_MEDIAINFO_SUMMARY, mi.Overall.Summary);
                    Program.WriteDebugLog();

                    // creates screenshot
                    TorrentInfo ti = new TorrentInfo(bwApp, mi);

                    PublishOptionsPacket pop = new PublishOptionsPacket();
                    pop.AlignCenter = Settings.Default.AlignCenter;
                    pop.FullPicture = Settings.Default.UploadScreenshot && Settings.Default.UseFullPicture;
                    pop.PreformattedText = Settings.Default.PreText;

                    ti.PublishOptions = pop;
                    ti.PublishString = CreatePublish(ti, pop);

                    bwApp.ReportProgress((int)ProgressType.UPDATE_SCREENSHOTS_LIST, ti.MediaInfo2.Screenshot);

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
                tc.Comment = Program.getMediaName(p);
                tc.Path = p;
                tc.PublisherUrl = "http://code.google.com/p/tdmaker";
                tc.Publisher = Application.ProductName;
                tc.StoreMD5 = true;
                List<string> temp = new List<string>();
                temp.Add(tp.Tracker.AnnounceURL);
                tc.Announces.Add(temp);

                string torrentFileName = (File.Exists(p) ? Path.GetFileName(p) : Program.getMediaName(p)) + ".torrent";
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

            if (Settings.Default.TemplatesMode && Directory.Exists(ti.MediaInfo2.TemplateLocation))
            {
                pt = ti.CreatePublish(pop, new TemplateReader(ti.MediaInfo2.TemplateLocation, ti));
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
                            txtScrFull.Text = mTorrentInfo.MediaInfo2.Screenshot.Full;
                            txtBBScrForums.Text = mTorrentInfo.MediaInfo2.Screenshot.LinkedThumbnail;

                            if (!string.IsNullOrEmpty(txtScrFull.Text))
                                txtBBScrFull.Text = string.Format("[img]{0}[/img]", txtScrFull.Text);

                            PublishOptionsPacket pop = mTorrentInfo.PublishOptions;

                            // initialize quick publish checkboxes
                            chkQuickAlignCenter.Checked = pop.AlignCenter;
                            chkQuickFullPicture.Checked = pop.FullPicture;
                            chkQuickPre.Checked = pop.PreformattedText;

                            txtPublish.Text = mTorrentInfo.PublishString;

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

        private void btnBrowse_Click(object sender, EventArgs e)
        {

            if (rbFile.Checked)
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
            else
            {
                FolderBrowserDialog dlg = new FolderBrowserDialog();
                dlg.Description = "Browse for DVD folder...";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadMedia(new string[] { dlg.SelectedPath });
                }
            }

        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtPublish.Text);
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
                        txtMediaInfo.Text = msg;
                        break;

                    case ProgressType.UPDATE_PROGRESSBAR_MAX:
                        pBar.Style = ProgressBarStyle.Continuous;
                        pBar.Maximum = (int)e.UserState;
                        break;

                    case ProgressType.UPDATE_SCREENSHOTS_LIST:
                        ScreenshotsPacket sp = (ScreenshotsPacket)e.UserState;
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
            this.analyzeMedia(wt);
        }

        private void txtScrFull_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtScrFull.Text))
                System.Diagnostics.Process.Start(txtScrFull.Text);
        }

        private void cmsAppAbout_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Version {0}", Application.ProductVersion));
            sb.AppendLine();
            sb.AppendLine(string.Format("Running from {0}", Application.ExecutablePath));
            sb.AppendLine();
            sb.AppendLine("Copyright © McoreD 2009");
            MessageBox.Show(sb.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dgvTrackers_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            int old = cboAnnounceURL.SelectedIndex;
            fillTrackersComboBox();

            if (cboAnnounceURL.Items.Count > 0 && old < 0)
            {
                old = 0;
            }
            if (cboAnnounceURL.Items.Count > old)
            {
                cboAnnounceURL.SelectedIndex = old;
            }
        }

        private void fillTrackersComboBox()
        {

            cboAnnounceURL.Items.Clear();
            for (int i = 0; i < dgvTrackers.Rows.Count; i++)
            {
                object val = dgvTrackers.Rows[i].Cells[1].Value;
                if (val != null)
                    cboAnnounceURL.Items.Add(dgvTrackers.Rows[i].Cells[1].Value);
            }

        }

        private Tracker getTracker()
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

        private void btnCreateTorrent_Click(object sender, EventArgs e)
        {
            if (!bwApp.IsBusy)
            {
                List<TorrentPacket> tps = new List<TorrentPacket>();
                string[] files = new string[lbFiles.Items.Count];
                for (int i = 0; i < lbFiles.Items.Count; i++)
                {
                    files[i] = lbFiles.Items[i].ToString();
                    tps.Add(new TorrentPacket(getTracker(), files[i]));
                }

                WorkerTask wt = new WorkerTask(TaskType.CREATE_TORRENT);
                wt.TorrentPackets = tps;
                bwApp.RunWorkerAsync(wt);

                btnCreateTorrent.Enabled = false;
            }
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

        private void createQuickPublish()
        {
            if (mTorrentInfo != null)
            {
                PublishOptionsPacket pop = new PublishOptionsPacket();
                pop.AlignCenter = chkQuickAlignCenter.Checked;
                pop.FullPicture = chkQuickFullPicture.Checked;
                pop.PreformattedText = chkQuickPre.Checked;

                txtPublish.Text = CreatePublish(mTorrentInfo, pop);
            }
        }

        private void chkQuickPre_CheckedChanged(object sender, EventArgs e)
        {
            createQuickPublish();
        }

        private void chkQuickAlignCenter_CheckedChanged(object sender, EventArgs e)
        {
            createQuickPublish();
        }

        private void chkQuickFullPicture_CheckedChanged(object sender, EventArgs e)
        {
            createQuickPublish();
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
            if (Directory.Exists(Settings.Default.TorrentsCustomDir))
            {
                Process.Start(Settings.Default.TorrentsCustomDir);
            }
        }

        private void tsmScreenshots_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Program.ScreenshotsDir))
            {
                Process.Start(Program.ScreenshotsDir);
            }
        }

        private void chkScreenshot_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tsmTemplates_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Settings.Default.TemplatesDir))
            {
                Process.Start(Settings.Default.TemplatesDir);
            }
        }

        private void tsmUpdatesCheck_Click(object sender, EventArgs e)
        {
            UpdateChecker uc = new UpdateChecker(this.Icon, Resources.GenuineAdv, sBar, true);
            uc.CheckUpdates();
        }

        private void cboScreenshotDest_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.ScreenshotDestIndex = cboScreenshotDest.SelectedIndex;
            tpHostingImageShack.Enabled = cboScreenshotDest.SelectedIndex == 0;
        }

        private void tsmLogsDir_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Program.LogsDir))
            {
                Process.Start(Program.LogsDir);
            }
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


    }
}
