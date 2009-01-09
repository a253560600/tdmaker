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
        private TorrentInfo mTInfo = null;
        private MediaInfo2 mMI = null;
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
            if (Settings.Default.CreateTorrent)
                createTorrent(p);
            updateGuiControls();

            if (Settings.Default.AnalyzeAuto)
                analyzeMedia();
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
                mMI = new MediaInfo2(txtMediaLocation.Text);
                mMI.Source = cboSource.Text;
                mMI.WebLink = txtWebLink.Text;

                // if it is a DVD, set the title to be name of the folder. 
                string p = mMI.Location;

                this.Text = string.Format("{0} - {1}", Resources.AppName, this.getMediaName(p));

                txtScrFull.Text = "";
                txtBBScrFull.Text = "";
                txtBBScrForums.Text = "";

                pBar.Style = ProgressBarStyle.Marquee;

                if (!bwApp.IsBusy)
                    bwApp.RunWorkerAsync();

                updateGuiControls();

            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
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

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Settings.Default.MTNArgs.Contains(cboMtnArgs.Text))
            {
                Settings.Default.MTNArgs.Add(cboMtnArgs.Text);
            }
            if (!Settings.Default.Sources.Contains(cboSource.Text))
            {
                Settings.Default.Sources.Add(cboSource.Text);
            }

            // tm2.Write(dgvTrackers);
            writeTrackers1();
            Settings.Default.AnnounceURLIndex = cboAnnounceURL.SelectedIndex;

            Settings.Default.Save();
        }

        List<Tracker> trackers = new List<Tracker>();
        TrackerManager tm = new TrackerManager();
        TrackerManager2 tm2 = new TrackerManager2();

        private void frmMain_Load(object sender, EventArgs e)
        {

            SettingsGet();

            Program.Status = "Ready.";

            this.Text = Resources.AppName + " - Drag and Drop a Movie file...";

        }

        private void SettingsGet()
        {

            if (string.IsNullOrEmpty(Settings.Default.MTNPath))
                Settings.Default.MTNPath = Path.Combine(Application.StartupPath, "mtn.exe");

            cboMtnArgs.Items.Clear();
            foreach (string arg in Settings.Default.MTNArgs)
            {
                cboMtnArgs.Items.Add(arg);
            }
            cboMtnArgs.Text = Settings.Default.MTNArg;

            cboSource.Items.Clear();
            foreach (string src in Settings.Default.Sources)
            {
                cboSource.Items.Add(src);
            }

            // Trackers

            readTrackers1();


            //DataSet ds = tm2.Read();
            //if (ds != null)
            //{
            //    dgvTrackers.DataSource = ds.Tables[0];
            //    if (dgvTrackers.Columns.Count > 0)
            //    {
            //        dgvTrackers.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //        dgvTrackers.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //    }
            //    cboAnnounceURL.DataSource = dgvTrackers.DataSource;
            //    cboAnnounceURL.DisplayMember = "Name";
            //    cboAnnounceURL.ValueMember = "AnnounceURL";
            //}
        }

        private void writeTrackers1()
        {
            trackers.Clear();
            for (int i = 0; i < dgvTrackers.Rows.Count; i++)
            {
                object name = dgvTrackers.Rows[i].Cells[0].Value;
                object url = dgvTrackers.Rows[i].Cells[1].Value;
                if (name != null && url != null)
                    trackers.Add(new Tracker(name.ToString(), url.ToString()));

            }

            tm.Write(trackers);

        }

        private void readTrackers1()
        {

            trackers = tm.Read();

            for (int i = 0; i < trackers.Count; i++)
            {
                dgvTrackers.Rows.Add();
                dgvTrackers.Rows[i].Cells[0].Value = trackers[i].Name;
                dgvTrackers.Rows[i].Cells[1].Value = trackers[i].AnnounceURL;
            }

            fillTrackersComboBox();
            cboAnnounceURL.SelectedIndex = Settings.Default.AnnounceURLIndex;

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtBBScrFull.Text);
        }

        private void bwApp_DoWork(object sender, DoWorkEventArgs e)
        {
            // start of the magic :)

            Program.Status = "Reading " + mMI.Location;
            mMI.ReadMedia();
            bwApp.ReportProgress(0, mMI.Summary);
            mTInfo = new TorrentInfo(bwApp, mMI);
        }

        private void updateGuiControls()
        {
            btnAnalyze.Enabled = !bwApp.IsBusy && !string.IsNullOrEmpty(txtMediaLocation.Text);
            btnCopy0.Enabled = !bwApp.IsBusy && !string.IsNullOrEmpty(txtScrFull.Text);
            btnCopy1.Enabled = !bwApp.IsBusy && !string.IsNullOrEmpty(txtBBScrFull.Text);
            btnCopy2.Enabled = !bwApp.IsBusy && !string.IsNullOrEmpty(txtBBScrForums.Text);
            btnPublish.Enabled = !bwApp.IsBusy && !string.IsNullOrEmpty(txtPublish.Text);
        }

        private void bwApp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (mTInfo != null)
            {

                txtScrFull.Text = mTInfo.ScreenshotURLFull;
                txtBBScrForums.Text = mTInfo.ScreenshotURLForums;

                BbCode bb = new BbCode();
                if (!string.IsNullOrEmpty(txtScrFull.Text))
                    txtBBScrFull.Text = bb.img(txtScrFull.Text);

                StringBuilder sbPublish = new StringBuilder();
                sbPublish.AppendLine(mTInfo.MediaInfoForums1);

                sbPublish.AppendLine();
                if (!string.IsNullOrEmpty(txtBBScrFull.Text) && Settings.Default.UseFullPicture)
                {
                    sbPublish.AppendLine(txtBBScrFull.Text);
                }
                else if (!string.IsNullOrEmpty(txtBBScrForums.Text))
                {
                    sbPublish.AppendLine(txtBBScrForums.Text);
                }

                // sbPublish.AppendLine("Get your Torrent Description like this using TDMaker: http://code.google.com/p/tdmaker");

                txtPublish.Text = sbPublish.ToString();

                updateGuiControls();

            }

            pBar.Style = ProgressBarStyle.Continuous;
            Program.Status = "Ready.";
        }

        private void tmrStatus_Tick(object sender, EventArgs e)
        {
            sBar.Text = Program.Status;
            btnBrowse.Enabled = !bwApp.IsBusy;
            // btnBrowse.Text = (File.Exists(txtMediaFile.Text) ? "&Analyze" : "&Browse...");
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

        private void createTorrent(string p)
        {
            if (File.Exists(p) || Directory.Exists(p))
            {
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                bw.WorkerReportsProgress = true;
                bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
                bw.RunWorkerAsync(p);
            }
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string msg = e.UserState.ToString();
            switch (e.ProgressPercentage)
            {
                case 0:
                    Program.Status = msg;
                    break;
                case 1:
                    break;
            }
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;
            if (e.Argument != null)
            {
                try
                {
                    string p = e.Argument.ToString();

                    MonoTorrent.Common.TorrentCreator tc = new MonoTorrent.Common.TorrentCreator();
                    tc.Private = true;
                    tc.Comment = this.getMediaName(p);
                    tc.Path = p;
                    tc.PublisherUrl = "http://code.google.com/p/tdmaker";
                    tc.Publisher = Application.ProductName;
                    tc.StoreMD5 = true;
                    List<string> temp = new List<string>();
                    temp.Add(Settings.Default.AnnounceURL);
                    tc.Announces.Add(temp);

                    string torrentPath = "";
                    if (!Settings.Default.TorrentFolderDefault && Directory.Exists(Settings.Default.TorrentCustomFolder))
                    {
                        torrentPath = torrentPath = Path.Combine(Settings.Default.TorrentCustomFolder, Path.GetFileNameWithoutExtension(p) + ".torrent");
                    }
                    else
                    {
                        torrentPath = Path.Combine(Path.GetDirectoryName(p), Path.GetFileNameWithoutExtension(p) + ".torrent");
                    }
                    
                    tc.Create(torrentPath);

                    bw.ReportProgress(0, string.Format("{0} created.", torrentPath));
                }
                catch (Exception ex)
                {
                    bw.ReportProgress(0, ex.Message);
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

        private void dgvTrackers_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTrackers_Leave(object sender, EventArgs e)
        {

        }

        private void dgvTrackers_MouseLeave(object sender, EventArgs e)
        {

        }

        private void dgvTrackers_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {

        }

        private void dgvTrackers_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            int old = cboAnnounceURL.SelectedIndex;
            fillTrackersComboBox();
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

        private void btnCreateTorrent_Click(object sender, EventArgs e)
        {
            createTorrent(txtMediaLocation.Text);
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
            txtTorrentCustomFolder.Enabled = rbTorrentFolderCustom.Checked;
            btnBrowseTorrentCustomFolder.Enabled = rbTorrentFolderCustom.Checked;
        }


    }
}
