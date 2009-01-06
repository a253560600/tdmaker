using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TDMaker.Properties;

namespace TorrentDescriptionMaker
{
    public partial class frmMain : Form
    {
        private cTorrentInfo mTInfo = null;
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
            if (paths.Length == 1 && File.Exists(paths[0]))
            {
                analyzeMedia(paths[0]);
            }

        }

        private void analyzeMedia(string p)
        {
            // if it is a DVD, set the title to be name of the folder. 
            if (File.Exists(p))
            {
                string ext = Path.GetExtension(p).ToLower();
                string name = (ext == ".vob" ? Path.GetDirectoryName(p) : Path.GetFileNameWithoutExtension(p));
                this.Text = string.Format("{0} - {1}", Resources.AppName, name);
            }
            else if (Directory.Exists(p))
            {
                string name = Path.GetFileName(p);
                this.Text = string.Format("{0} - {1}", Resources.AppName, name);
            }
            
            txtScrFull.Text = "";
            txtBBScrFull.Text = "";
            txtBBScrForums.Text = "";

            pBar.Style = ProgressBarStyle.Marquee;
            bwApp.RunWorkerAsync(p);

            updateGuiControls();
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

            Settings.Default.Save();
        }

        private void frmMain_Load(object sender, EventArgs e)
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
            //cboSource.SelectedText = Settings.Default.Source;

            Program.Status = "Ready.";

            // tabControl1.TabPages.Remove(tabPage1);
            this.Text = Resources.AppName + " - Drag and Drop a Movie file...";
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtBBScrFull.Text);
        }

        private void bwApp_DoWork(object sender, DoWorkEventArgs e)
        {
            Program.Status = "Reading " + e.Argument.ToString();
            mTInfo = new cTorrentInfo(bwApp, e.Argument.ToString());
        }

        private void updateGuiControls()
        {
                btnAnalyze.Enabled = !bwApp.IsBusy && !string.IsNullOrEmpty(txtFilePath.Text);
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
                    txtFilePath.Text = dlg.FileName;
                    analyzeMedia(txtFilePath.Text);
                }
            }
            else
            {
                FolderBrowserDialog dlg = new FolderBrowserDialog();
                dlg.Description = "Browse for DVD folder...";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = dlg.SelectedPath;
                    analyzeMedia(txtFilePath.Text);
                }
            }                       

        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtPublish.Text);
        }

        private void bwApp_ProgressChanged(object sender, ProgressChangedEventArgs e)
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

        private void chkOptImageShack_CheckedChanged(object sender, EventArgs e)
        {
            chkUploadFullScreenshot.Enabled = chkOptImageShack.Checked;
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtFilePath.Text))
                this.analyzeMedia(txtFilePath.Text);
        }

        private void txtScrFull_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtScrFull.Text))
                System.Diagnostics.Process.Start(txtScrFull.Text);
        }

        private void cmsAppAbout_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Application.ProductName);
            sb.AppendLine(string.Format("Version {0}", Application.ProductVersion));
            MessageBox.Show(sb.ToString());

        }


    }
}
