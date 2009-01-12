﻿using System;
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
            if (paths.Length == 1)
            {
                if (File.Exists(paths[0]) || Directory.Exists(paths[0]))
                {
                    loadMedia(paths[0]);
                }
            }

        }

        private void loadMedia(string p)
        {
            txtMediaLocation.Text = p;

            TorrentPacket tp = new TorrentPacket(getTracker(), p);

            if (Settings.Default.CreateTorrent)
                createTorrent(tp);

            if (Settings.Default.AnalyzeAuto)
                analyzeMedia();

            updateGuiControls();

        }

        private string getMediaName(string p)
        {

            string name = "";

            if (File.Exists(p))
            {
                string ext = Path.GetExtension(p).ToLower();
                name = (ext == ".vob" ? Path.GetDirectoryName(p) : Path.GetFileNameWithoutExtension(p));
            }
            else if (Directory.Exists(p))
            {
                name = Path.GetFileName(p);
                if (name.ToUpper().Equals("VIDEO_TS"))
                    name = Path.GetFileName(Path.GetDirectoryName(p));

            }

            return name;

        }

        private void analyzeMedia()
        {
            if (File.Exists(txtMediaLocation.Text) || Directory.Exists(txtMediaLocation.Text))
            {
                MediaInfo2 mi = new MediaInfo2(txtMediaLocation.Text);
                mi.Extras = cboExtras.Text;
                mi.Source = cboSource.Text;
                mi.Menu = cboDiscMenu.Text;
                mi.Authoring = cboAuthoring.Text;
                mi.WebLink = txtWebLink.Text;
                mi.TorrentInfo = new TorrentPacket(getTracker(), txtMediaLocation.Text);

                // Screenshots Mode
                if (Settings.Default.UploadImageShack)
                {
                    mi.TakeScreenshots = TakeScreenshotsMode.TAKE_ONE_SCREENSHOT;
                }

                // if it is a DVD, set the title to be name of the folder. 
                string p = mi.Location;

                this.Text = string.Format("{0} - {1}", Resources.AppName, this.getMediaName(p));

                txtScrFull.Text = "";
                txtBBScrFull.Text = "";
                txtBBScrForums.Text = "";

                pBar.Style = ProgressBarStyle.Marquee;

                lbStatus.Items.Add("Analyzing Media using MediaInfo.");

                if (!bwApp.IsBusy)
                    bwApp.RunWorkerAsync(mi);

                updateGuiControls();

            }
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
            this.WindowState = FormWindowState.Minimized;
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
            if (string.IsNullOrEmpty(Settings.Default.SettingsDir) || !Directory.Exists(Settings.Default.SettingsDir))
            {
                Settings.Default.SettingsDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dir + "\\Settings");

                if (!Directory.Exists(Settings.Default.SettingsDir))
                    Directory.CreateDirectory(Settings.Default.SettingsDir);
            }

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

            MediaInfo2 mi = (MediaInfo2)e.Argument;

            Program.Status = "Reading " + mi.Location;
            mi.ReadMedia();

            bwApp.ReportProgress(0, mi.Overall.Summary);

            TorrentInfo ti = new TorrentInfo(bwApp, mi);

            PublishOptionsPacket pop = new PublishOptionsPacket();
            pop.AlignCenter = Settings.Default.AlignCenter;
            pop.FullPicture = Settings.Default.UploadImageShack && Settings.Default.UseFullPicture;
            pop.PreformattedText = Settings.Default.PreText;

            ti.PublishOptions = pop;

            if (Settings.Default.WritePublish)
            {
                // create textFiles of MediaInfo           
                string txtPath = Path.Combine(mi.TorrentInfo.TorrentFolder, mi.Title) + ".txt";

                if (!Directory.Exists(mi.TorrentInfo.TorrentFolder))
                {
                    Directory.CreateDirectory(mi.TorrentInfo.TorrentFolder);
                }

                using (StreamWriter sw = new StreamWriter(txtPath))
                {
                    sw.WriteLine(ti.ToString());
                }
            }

            e.Result = ti;
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
            mTorrentInfo = (TorrentInfo)e.Result;

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
                dlg.Title = "Browse for Media file...";
                dlg.Filter = "Media Files|*.avi; *.vob; *.mkv; *.divx";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    loadMedia(dlg.FileName);
                }
            }
            else
            {
                FolderBrowserDialog dlg = new FolderBrowserDialog();
                dlg.Description = "Browse for DVD folder...";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    loadMedia(dlg.SelectedPath);
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
                    tc.Comment = this.getMediaName(p);
                    tc.Path = p;
                    tc.PublisherUrl = "http://code.google.com/p/tdmaker";
                    tc.Publisher = Application.ProductName;
                    tc.StoreMD5 = true;
                    List<string> temp = new List<string>();
                    temp.Add(tp.Tracker.AnnounceURL);
                    tc.Announces.Add(temp);

                    string torrentFileName = (File.Exists(p) ? Path.GetFileNameWithoutExtension(p) : this.getMediaName(p)) + ".torrent";
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
                int perc = e.ProgressPercentage;

                switch (perc)
                {
                    case 0:
                        lbStatus.Items.Add("Analyzed Media using MediaInfo");
                        txtMediaInfo.Text = msg;
                        break;
                    case 1:
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
            this.analyzeMedia();
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



    }
}
