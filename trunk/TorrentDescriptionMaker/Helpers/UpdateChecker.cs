﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TDMaker.Properties;
using TorrentDescriptionMaker;

namespace TDMaker
{
    public class UpdateChecker
    {
        private ToolStripStatusLabel sBarTrack;
        private BackgroundWorker bwUpdate = new BackgroundWorker();

        private string[] mcUpdateDownloadDir = new string[] { "http://tdmaker.googlecode.com/files/" };
        private string[] mcUpdateCheckUrl = new string[] { "http://wmwiki.com/mcored/updates.txt" };

        private bool mIsManualCheckUpdate = false;
        private Icon mAppIcon = null;
        private Image mAppImage = null;

        public UpdateChecker(Icon appIcon, Image appImage, ToolStripStatusLabel sbar, bool manual)
        {

            this.sBarTrack = sbar;
            mIsManualCheckUpdate = manual;

            mAppIcon = appIcon;
            mAppImage = appImage;

            bwUpdate.WorkerReportsProgress = true;
            bwUpdate.WorkerSupportsCancellation = true;

            bwUpdate.DoWork += new DoWorkEventHandler(bwUpdate_DoWork);
            bwUpdate.ProgressChanged += new ProgressChangedEventHandler(bwUpdate_ProgressChanged);
            bwUpdate.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwUpdate_RunWorkerCompleted);

        }

        void bwUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            sBarTrack.Text = "Done with Checking Updates...";
        }

        void bwUpdate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            sBarTrack.Text = "Checking for updates...";
        }

        void bwUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            bwUpdate.ReportProgress(0);

            McoreSystem.AppInfo appInfo = new McoreSystem.AppInfo(Application.ProductName, Application.ProductVersion);
            appInfo.AppIcon = mAppIcon;
            appInfo.AppImage = mAppImage;

            if (Settings.Default.AutoCheckUpdates && appInfo.isUpdated(mcUpdateCheckUrl))
            {

                if (appInfo.isUpdated(mcUpdateCheckUrl))
                {
                    appInfo.CheckUpdates(mcUpdateCheckUrl, mcUpdateDownloadDir, Program.APP_NAME, McoreSystem.AppInfo.OutdatedMsgStyle.NewVersionOfAppAvailable);
                }
            }

            else if (mIsManualCheckUpdate)
            {

                appInfo.CheckUpdates(mcUpdateCheckUrl, mcUpdateDownloadDir, Program.APP_NAME, McoreSystem.AppInfo.OutdatedMsgStyle.NewVersionOfAppAvailable);
            }
        }

        public void CheckUpdates()
        {
            bwUpdate.RunWorkerAsync();
        }

    }

}
