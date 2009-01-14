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
            loadMedia(paths);

            //if (paths.Length == 1)
            //{
            //    if (File.Exists(paths[0]) || Directory.Exists(paths[0]))
            //    {

            //    }
            //}

        }

        private void loadMedia(string[] ps)
        {
            foreach (string p in ps)
            {
                if (File.Exists(p) || Directory.Exists(p))
                {
                    txtMediaLocation.Text = p;

                    TorrentPacket tp = new TorrentPacket(getTracker(), p);

                    if (Settings.Default.CreateTorrent)
                        createTorrent(tp);

                    updateGuiControls();
                }
            }

            if (Settings.Default.AnalyzeAuto)
                analyzeMedia(ps);
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

        private void analyzeMedia(string[] ps)
        {
            List<MediaInfo2> miList = new List<MediaInfo2>();

            foreach (string p in ps)
            {
                if (File.Exists(p) || Directory.Exists(p))
                {
                    MediaInfo2 mi = new MediaInfo2(p);
                    mi.Extras = cboExtras.Text;
                    mi.Source = cboSource.Text;
                    mi.Menu = cboDiscMenu.Text;
                    mi.Authoring = cboAuthoring.Text;
                    mi.WebLink = txtWebLink.Text;
                    mi.TorrentInfo = new TorrentPacket(getTracker(), p);
                    if (Settings.Default.TemplatesMode)
                    {
                        mi.TemplateLocation = Path.Combine(Settings.Default.TemplatesDir, cboTemplate.Text);
                    }

                    // Screenshots Mode
                    if (Settings.Default.UploadImageShack)
                    {
                        mi.TakeScreenshots = TakeScreenshotsMode.TAKE_ONE_SCREENSHOT;
                    }

                    // if it is a DVD, set the title to be name of the folder. 
                    this.Text = string.Format("{0} - {1}", Resources.AppName, Program.getMediaName(mi.Location));

                    txtScrFull.Text = "";
                    txtBBScrFull.Text = "";
                    txtBBScrForums.Text = "";

                    // pBar.Style = ProgressBarStyle.Marquee;

                    // lbStatus.Items.Add("Analyzing Media using MediaInfo.");

                    miList.Add(mi);

                }
            }

            if (!bwApp.IsBusy)
                bwApp.RunWorkerAsync(miList);

            updateGuiControls();

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

            Settings.Default.TorrentFolderDefault = rbTorrentDefaultFolder.Checked;

            Settings.Default.Save();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // this.WindowState = FormWindowState.Minimized;
            SettingsWrite();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            configureDirs();
            SettingsRead();

            Program.Status = "Ready.";

            this.Text = Resources.AppName + " - Drag and Drop a Movie file...";

            updateGuiControls();

        }

        private void configureDirs()
        {
            string dir = Path.Combine("Applications", Application.ProductName);
            if (string.IsNullOrEmpty(Settings.Default.SettingsDir) ||
                !Directory.Exists(Settings.Default.SettingsDir))
            {
                Settings.Default.SettingsDir =
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    dir + "\\Settings");

                if (!Directory.Exists(Settings.Default.SettingsDir))
                    Directory.CreateDirectory(Settings.Default.SettingsDir);
            }

            if (string.IsNullOrEmpty(Settings.Default.TemplatesDir) ||
                !Directory.Exists(Settings.Default.TemplatesDir))
            {
                Settings.Default.TemplatesDir =
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    dir + "\\Templates");

                if (!Directory.Exists(Settings.Default.TemplatesDir))
                    Directory.CreateDirectory(Settings.Default.TemplatesDir);
            }
            else if (Directory.Exists(Settings.Default.TemplatesDir))
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

            // Copy Default Template to Templates folder
            string prefix = "Templates.Default.";
            string tDefaultDir = Path.Combine(Settings.Default.TemplatesDir, "Default");
            if (!Directory.Exists(tDefaultDir))
            {
                Directory.CreateDirectory(tDefaultDir);
                string[] files = new string[] { "Disc.txt", "File.txt", "DiscAudioInfo.txt", "FileAudioInfo.txt", "GeneralInfo.txt", "VideoInfo.txt" };
                foreach (string fn in files)
                {
                    using (StreamWriter sw = new StreamWriter(Path.Combine(tDefaultDir, fn)))
                    {
                        sw.WriteLine(Program.GetText(prefix + fn));
                    }
                }
            }

            if (cboTemplate.Items.Count > 0)
                cboTemplate.SelectedIndex = Settings.Default.LastTemplateIndex;

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
                cboAnnounceURL.SelectedIndex = Settings.Default.AnnounceURLIndex;

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtBBScrFull.Text);
        }

        private void bwApp_DoWork(object sender, DoWorkEventArgs e)
        {
            // start of the magic :)

            List<MediaInfo2> miList = (List<MediaInfo2>)e.Argument;
            List<TorrentInfo> tiList = new List<TorrentInfo>();

            bwApp.ReportProgress((int)ProgressMode.UPDATE_PROGRESSBAR_MAX, miList.Count);

            foreach (MediaInfo2 mi in miList)
            {
                Program.Status = "Reading " + mi.Location;
                mi.ReadMedia();

                bwApp.ReportProgress((int)ProgressMode.REPORT_MEDIAINFO_SUMMARY, mi.Overall.Summary);

                TorrentInfo ti = new TorrentInfo(bwApp, mi);

                PublishOptionsPacket pop = new PublishOptionsPacket();
                pop.AlignCenter = Settings.Default.AlignCenter;
                pop.FullPicture = Settings.Default.UploadImageShack && Settings.Default.UseFullPicture;
                pop.PreformattedText = Settings.Default.PreText;

                ti.PublishOptions = pop;

                if (Settings.Default.TemplatesMode && Directory.Exists(mi.TemplateLocation))
                {
                    ti.PublishString = ti.CreatePublish(new TemplateReader(mi.TemplateLocation, ti));
                }
                else
                {
                    ti.PublishString = ti.ToString();
                }

                if (Settings.Default.WritePublish)
                {
                    // create textFiles of MediaInfo           
                    string txtPath = Path.Combine(mi.TorrentInfo.TorrentFolder, mi.Overall.FileName) + ".txt";

                    if (!Directory.Exists(mi.TorrentInfo.TorrentFolder))
                    {
                        Directory.CreateDirectory(mi.TorrentInfo.TorrentFolder);
                    }

                    using (StreamWriter sw = new StreamWriter(txtPath))
                    {
                        sw.WriteLine(ti.PublishString);
                    }
                }

                tiList.Add(ti);

                bwApp.ReportProgress((int)ProgressMode.INCREMENT_PROGRESS_WITH_MSG, mi.Title);

            }

            e.Result = tiList;
        }

        private void updateGuiControls()
        {
            btnCreateTorrent.Enabled = !bwApp.IsBusy && !string.IsNullOrEmpty(txtMediaLocation.Text);
            btnAnalyze.Enabled = !bwApp.IsBusy && !string.IsNullOrEmpty(txtMediaLocation.Text);

            btnCopy0.Enabled = !bwApp.IsBusy && !string.IsNullOrEmpty(txtScrFull.Text);
            btnCopy1.Enabled = !bwApp.IsBusy && !string.IsNullOrEmpty(txtBBScrFull.Text);
            btnCopy2.Enabled = !bwApp.IsBusy && !string.IsNullOrEmpty(txtBBScrForums.Text);

            btnPublish.Enabled = !bwApp.IsBusy && !string.IsNullOrEmpty(txtPublish.Text);

            txtTorrentCustomFolder.Enabled = rbTorrentFolderCustom.Checked;
            btnBrowseTorrentCustomFolder.Enabled = rbTorrentFolderCustom.Checked;
            chkTorrentOrganize.Enabled = rbTorrentFolderCustom.Checked;

        }

        private void bwApp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<TorrentInfo> tiList = (List<TorrentInfo>)e.Result;

            foreach (TorrentInfo ti in tiList)
            {
                mTorrentInfo = ti;

                if (mTorrentInfo != null)
                {

                    txtScrFull.Text = mTorrentInfo.ScreenshotURLFull;
                    txtBBScrForums.Text = mTorrentInfo.ScreenshotURLForums;

                    if (!string.IsNullOrEmpty(txtScrFull.Text))
                        txtBBScrFull.Text = string.Format("[img]{0}[/img]", txtScrFull.Text);

                    PublishOptionsPacket pop = mTorrentInfo.PublishOptions;

                    // initialize quick publish checkboxes
                    chkQuickAlignCenter.Checked = pop.AlignCenter;
                    chkQuickFullPicture.Checked = pop.FullPicture;
                    chkQuickPre.Checked = pop.PreformattedText;

                    txtPublish.Text = mTorrentInfo.PublishString;

                    // sbPublish.AppendLine("Get your Torrent Description like this using TDMaker: http://code.google.com/p/tdmaker");

                    updateGuiControls();

                }

                if (!string.IsNullOrEmpty(txtScrFull.Text))
                    lbStatus.Items.Add("Uploaded Screenshot to ImageShack.");

            }

            if (mBwTorrent == null || !mBwTorrent.IsBusy)
            {
                pBar.Style = ProgressBarStyle.Continuous;
                Program.Status = "Ready.";
            }

        }

        private void tmrStatus_Tick(object sender, EventArgs e)
        {
            sBar.Text = Program.Status;
            btnBrowse.Enabled = !bwApp.IsBusy;
            btnAnalyze.Enabled = !bwApp.IsBusy && (File.Exists(txtMediaLocation.Text) || Directory.Exists(txtMediaLocation.Text));
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
                dlg.Filter = "Media Files|*.avi; *.vob; *.mkv; *.divx";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    loadMedia(dlg.FileNames);
                }
            }
            else
            {
                FolderBrowserDialog dlg = new FolderBrowserDialog();
                dlg.Description = "Browse for DVD folder...";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    loadMedia(new string[] { dlg.SelectedPath });
                }
            }

        }

        private void createTorrent(TorrentPacket tp)
        {
            string p = tp.MediaLocation;
            if (File.Exists(p) || Directory.Exists(p))
            {
                BackgroundWorker bwTorrent = new BackgroundWorker();
                bwTorrent.DoWork += new DoWorkEventHandler(bwTorrent_DoWork);
                bwTorrent.WorkerReportsProgress = true;
                bwTorrent.ProgressChanged += new ProgressChangedEventHandler(bwTorrent_ProgressChanged);
                bwTorrent.RunWorkerAsync(tp);
            }
        }

        void bwTorrent_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string msg = e.UserState.ToString();
            switch (e.ProgressPercentage)
            {
                case 0:
                    Program.Status = msg;
                    lbStatus.Items.Add(msg);
                    pBar.Style = ProgressBarStyle.Continuous;
                    break;
                case 1:
                    Program.Status = msg;
                    lbStatus.Items.Add(msg);
                    pBar.Style = ProgressBarStyle.Marquee;
                    break;
            }
        }

        BackgroundWorker mBwTorrent = null;

        void bwTorrent_DoWork(object sender, DoWorkEventArgs e)
        {
            mBwTorrent = (BackgroundWorker)sender;
            if (e.Argument != null)
            {
                try
                {
                    TorrentPacket tp = (TorrentPacket)e.Argument;
                    string p = tp.MediaLocation;

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

                    mBwTorrent.ReportProgress(1, string.Format("Creating {0}", torrentPath));
                    tc.Create(torrentPath);
                    mBwTorrent.ReportProgress(0, string.Format("Created {0}", torrentPath));
                }
                catch (Exception ex)
                {
                    mBwTorrent.ReportProgress(0, ex.Message);
                }
            }
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtPublish.Text);
        }

        private void bwApp_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                string msg = e.UserState.ToString();
                ProgressMode perc = (ProgressMode)e.ProgressPercentage;

                switch (perc)
                {
                    case ProgressMode.INCREMENT_PROGRESS_WITH_MSG:
                        pBar.Style = ProgressBarStyle.Continuous;
                        pBar.Increment(1);
                        sBar.Text = msg;
                        break;

                    case ProgressMode.REPORT_MEDIAINFO_SUMMARY:
                        lbStatus.Items.Add("Analyzed Media using MediaInfo");
                        txtMediaInfo.Text = msg;
                        break;

                    case ProgressMode.UPDATE_PROGRESSBAR_MAX:
                        pBar.Style = ProgressBarStyle.Continuous;
                        pBar.Maximum = (int)e.UserState;
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
            this.analyzeMedia(new string[] { txtMediaLocation.Text });
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
            TorrentPacket tp = new TorrentPacket(getTracker(), txtMediaLocation.Text);
            createTorrent(tp);
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
            updateGuiControls();
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

                mTorrentInfo.PublishOptions = pop;
                txtPublish.Text = mTorrentInfo.ToString();

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



    }
}
