using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace TDMakerLib
{
    public partial class MediaWizard : Form
    {
        public MediaWizardOptions Options = new MediaWizardOptions();

        public MediaWizard(List<string> FileOrDirPaths)
        {
            InitializeComponent();
            PrepareUserActionMsg(FileOrDirPaths);
            chkCreateTorrent.Checked = Engine.conf.TorrentCreateAuto;
            chkScreenshotsCreate.Checked = Engine.conf.ScreenshotsCreate;
        }

        public MediaWizard(WorkerTask wt)
        {
            InitializeComponent();
            PrepareUserActionMsg(wt.FileOrDirPaths);
            PrepareUI();
        }

        private void PrepareUI()
        {
            switch (this.Options.MediaTypeChoice)
            {
                case MediaType.MediaCollection:
                    break;
            }
        }

        private void PrepareUserActionMsg(List<string> myFilesOrDirs)
        {
            if (myFilesOrDirs.Count == 1)
            {
                lblUserActionMsg.Text = "You are about to analyze a single file...";
                this.Options.MediaTypeChoice = MediaType.MediaIndiv;
            }
            else
            {
                bool bDirFound = false;
                bool bFileFound = false;
                int dirCount = 0;
                int filesCount = 0;

                foreach (string fd in myFilesOrDirs)
                {
                    if (Directory.Exists(fd))
                    {
                        dirCount++;
                        bDirFound = true;
                    }
                    else if (File.Exists(fd))
                    {
                        filesCount++;
                        bFileFound = true;
                    }
                    if (dirCount > 1) break;
                }
                if (bDirFound)
                {
                    if (dirCount == 1)
                    {
                        lblUserActionMsg.Text = "You are about to a analyze a directory...";
                    }
                    else
                    {
                        lblUserActionMsg.Text = "You are about to analayze a collection of directories...";
                    }
                    this.Options.MediaTypeChoice = MediaType.MediaDisc;
                }
                else // no dir found
                {
                    lblUserActionMsg.Text = "You are about to a collection of files...";
                    this.Options.MediaTypeChoice = MediaType.MediaCollection;
                }
            }
        }

        private void rbFilesAsIndiv_CheckedChanged(object sender, System.EventArgs e)
        {
            this.Options.MediaTypeChoice = MediaType.MediaIndiv;
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void rbFilesAsColl_CheckedChanged(object sender, System.EventArgs e)
        {
            this.Options.MediaTypeChoice = MediaType.MediaCollection;
        }

        private void chkScreenshotsInclude_CheckedChanged(object sender, System.EventArgs e)
        {
            this.Options.ScreenshotsInclude = chkScreenshotsCreate.Checked;
        }

        private void chkCreateTorrent_CheckedChanged(object sender, System.EventArgs e)
        {
            this.Options.CreateTorrent = chkCreateTorrent.Checked;
        }
    }

    public class MediaWizardOptions
    {
        public bool ScreenshotsInclude { get; set; }
        public bool CreateTorrent { get; set; }
        public MediaType MediaTypeChoice { get; set; }
        public bool PromptShown { get; set; }
    }
}
