using System.Windows.Forms;
using TDMakerLib;
using System.Collections.Generic;
using System.IO;

namespace TDMaker
{
    public partial class MediaWizard : Form
    {
        WorkerTask MyTask = null;

        public MediaWizard(WorkerTask wt)
        {
            InitializeComponent();
            MyTask = wt;
        }

        private void PrepareUserActionMsg()
        {
            if (MyTask.FileOrDirPaths.Count == 1)
            {
                lblUserActionMsg.Text = "You are about to analyze a single file...";
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
                }
                else // no dir found
                {
                    lblUserActionMsg.Text = "You are about to a collection of files...";
                }
            }
        }

    }
}
