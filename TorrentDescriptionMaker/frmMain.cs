using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TorrentDescriptionMaker.Properties;

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
                this.Text = string.Format("{0} - {1}", Resources.AppName, Path.GetFileNameWithoutExtension(paths[0]));

                txtImageShackURL.Text = "";
                txtBBScrFull.Text = "";
                txtBBScrForums.Text = "";

                pBar.Style = ProgressBarStyle.Marquee;
                bwApp.RunWorkerAsync(paths[0]); 
                
            }

        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if (!File.Exists(Settings.Default.MTNPath))
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Browse for mtn.exe";
                dlg.Filter = "Applications (*.exe)|*.exe";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtMtn.Text = dlg.FileName;
                    // Settings.Default.MTNPath = txtMtn.Text;
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
            cboMtnArgs.Items.Clear();
            foreach (string arg in Settings.Default.MTNArgs)
            {
                cboMtnArgs.Items.Add(arg);
            }
            cboMtnArgs.SelectedIndex = 0;

            Program.Status = "Ready.";

            tabControl1.TabPages.Remove(tabPage1);
            this.Text = Resources.AppName + " - Drag and Drop a Movie file...";
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {            
            Clipboard.SetText(txtBBScrFull.Text);
        }

        private void bwApp_DoWork(object sender, DoWorkEventArgs e)
        {
            Program.Status = "Reading " + e.Argument.ToString();
            mTInfo = new cTorrentInfo(e.Argument.ToString());
        }

        private void bwApp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (mTInfo != null)
            {
                txtImageShackURL.Text = mTInfo.ScreenshotURLFull;
                txtBBScrForums.Text = mTInfo.ScreenshotURLForums;

                cBbCode bb = new cBbCode();
                txtBBScrFull.Text = bb.img(txtImageShackURL.Text);

                btnCopy0.Enabled = true;
                btnCopy.Enabled = true;
                btnCopy2.Enabled = true;
            }

            pBar.Style = ProgressBarStyle.Continuous;
            Program.Status = "Ready.";
        }

        private void tmrStatus_Tick(object sender, EventArgs e)
        {
            sBar.Text = Program.Status;
        }

        private void btnCopy2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtBBScrForums.Text);
        }

        private void btnCopy0_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtImageShackURL.Text);
        }
    }
}
