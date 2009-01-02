﻿using System;
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

            this.Text = string.Format("{0} - {1}", Resources.AppName, Path.GetFileNameWithoutExtension(p));

            txtImageShackURL.Text = "";
            txtBBScrFull.Text = "";
            txtBBScrForums.Text = "";

            pBar.Style = ProgressBarStyle.Marquee;
            bwApp.RunWorkerAsync(p);
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
            cboMtnArgs.SelectedIndex = 0;

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

        private void bwApp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (mTInfo != null)
            {

                txtImageShackURL.Text = mTInfo.ScreenshotURLFull;
                txtBBScrForums.Text = mTInfo.ScreenshotURLForums;

                BbCode bb = new BbCode();
                txtBBScrFull.Text = bb.img(txtImageShackURL.Text);

                btnCopy0.Enabled = true;
                btnCopy.Enabled = true;
                btnCopy2.Enabled = true;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(txtMediaInfo.Text);
                sb.AppendLine();
                if (Settings.Default.UseFullPicture)
                {
                    sb.AppendLine(txtBBScrFull.Text);
                }
                else
                {
                    sb.AppendLine(txtBBScrForums.Text);
                }
                
                txtPublish.Text = sb.ToString();

                btnPublish.Enabled = true;

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
            Clipboard.SetText(txtImageShackURL.Text);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Browse for Media file...";
            dlg.Filter = "Media Files|*.avi; *.vob; *.mkv";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtMediaFile.Text = dlg.FileName;
                analyzeMedia(txtMediaFile.Text);

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
            gbImageShack.Enabled = chkOptImageShack.Checked;
        }


    }
}