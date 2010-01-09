using System.Windows.Forms;
using TDMakerLib;
using System.Collections.Generic;
using System.IO;

namespace TDMaker
{
    public partial class MediaWizard : Form
    {
        private WorkerTask MyTask = null;
        public MediaWizardOptions Options = new MediaWizardOptions();

        public MediaWizard(WorkerTask wt)
        {
            InitializeComponent();
            MyTask = wt;
            PrepareUserActionMsg();
            PrepareUI();
        }

        private void PrepareUI()
        {
            switch (this.Options.MediaTypeChoice)
            {
                case MediaType.MEDIA_FILES_COLLECTION:
                    break;
            }
        }

        private void PrepareUserActionMsg()
        {
            if (MyTask.FileOrDirPaths.Count == 1)
            {
                lblUserActionMsg.Text = "You are about to analyze a single file...";
                this.Options.MediaTypeChoice = MediaType.SINGLE_MEDIA_FILE;
            }
            else
            {
                bool bDirFound = false;
                int dirCount = 0;

                foreach (string fd in MyTask.FileOrDirPaths)
                {
                    if (Directory.Exists(fd))
                    {
                        dirCount++;
                        bDirFound = true;
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
                    this.Options.MediaTypeChoice = MediaType.MEDIA_DISC;
                }
                else // no dir found
                {
                    lblUserActionMsg.Text = "You are about to a collection of files...";
                    this.Options.MediaTypeChoice = MediaType.MEDIA_FILES_COLLECTION;
                }
            }
        }

        private void rbFilesAsIndiv_CheckedChanged(object sender, System.EventArgs e)
        {
            this.Options.MediaTypeChoice = MediaType.SINGLE_MEDIA_FILE;
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void rbFilesAsColl_CheckedChanged(object sender, System.EventArgs e)
        {
            this.Options.MediaTypeChoice = MediaType.MEDIA_FILES_COLLECTION;
        }

        private void chkScreenshotsInclude_CheckedChanged(object sender, System.EventArgs e)
        {
            this.Options.ScreenshotsInclude = chkScreenshotsInclude.Checked;
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
    }
}
