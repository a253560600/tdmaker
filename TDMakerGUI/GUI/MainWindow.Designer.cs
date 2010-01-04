using TDMakerLib;

namespace TDMaker
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.gbScreenshotFull = new System.Windows.Forms.GroupBox();
            this.lbScreenshots = new System.Windows.Forms.ListBox();
            this.txtScrFull = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCopy0 = new System.Windows.Forms.Button();
            this.pbScreenshot = new System.Windows.Forms.PictureBox();
            this.gbScreenshotForums = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCopy2 = new System.Windows.Forms.Button();
            this.txtBBScrForums = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCopy1 = new System.Windows.Forms.Button();
            this.txtBBScrFull = new System.Windows.Forms.TextBox();
            this.bwApp = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sbarIcon = new System.Windows.Forms.ToolStripStatusLabel();
            this.sBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssPerc = new System.Windows.Forms.ToolStripStatusLabel();
            this.pBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpMedia = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.lbStatus = new System.Windows.Forms.ListBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.chkTitle = new System.Windows.Forms.CheckBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.chkWebLink = new System.Windows.Forms.CheckBox();
            this.chkSource = new System.Windows.Forms.CheckBox();
            this.txtWebLink = new System.Windows.Forms.TextBox();
            this.cboSource = new System.Windows.Forms.ComboBox();
            this.gbDVD = new System.Windows.Forms.GroupBox();
            this.cboDiscMenu = new System.Windows.Forms.ComboBox();
            this.chkDiscMenu = new System.Windows.Forms.CheckBox();
            this.cboExtras = new System.Windows.Forms.ComboBox();
            this.chkExtras = new System.Windows.Forms.CheckBox();
            this.cboAuthoring = new System.Windows.Forms.ComboBox();
            this.chkAuthoring = new System.Windows.Forms.CheckBox();
            this.gbLocation = new System.Windows.Forms.GroupBox();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.rbDir = new System.Windows.Forms.RadioButton();
            this.rbFile = new System.Windows.Forms.RadioButton();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tpMainMediaInfo = new System.Windows.Forms.TabPage();
            this.txtMediaInfo = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tlpScreenshots = new System.Windows.Forms.TableLayoutPanel();
            this.tlpScreenshots2 = new System.Windows.Forms.TableLayoutPanel();
            this.flpScreenshots1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkScreenshot = new System.Windows.Forms.CheckBox();
            this.chkScreenshotUpload = new System.Windows.Forms.CheckBox();
            this.cboScreenshotDest = new System.Windows.Forms.ComboBox();
            this.tpMainPublish = new System.Windows.Forms.TabPage();
            this.tlpPublish = new System.Windows.Forms.TableLayoutPanel();
            this.gbQuickPublish = new System.Windows.Forms.GroupBox();
            this.rbTExt = new System.Windows.Forms.RadioButton();
            this.rbTInt = new System.Windows.Forms.RadioButton();
            this.cboQuickTemplate = new System.Windows.Forms.ComboBox();
            this.chkQuickFullPicture = new System.Windows.Forms.CheckBox();
            this.chkQuickAlignCenter = new System.Windows.Forms.CheckBox();
            this.chkQuickPre = new System.Windows.Forms.CheckBox();
            this.txtPublish = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tcOptions = new System.Windows.Forms.TabControl();
            this.tpPublish = new System.Windows.Forms.TabPage();
            this.btnTemplatesRewrite = new System.Windows.Forms.Button();
            this.cboTemplate = new System.Windows.Forms.ComboBox();
            this.gbTemplatesInternal = new System.Windows.Forms.GroupBox();
            this.nudFontSizeIncr = new System.Windows.Forms.NumericUpDown();
            this.chkPre = new System.Windows.Forms.CheckBox();
            this.chkPreIncreaseFontSize = new System.Windows.Forms.CheckBox();
            this.chkAlignCenter = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.nudHeading1Size = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.nudHeading2Size = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudHeading3Size = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudBodySize = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chkUploadFullScreenshot = new System.Windows.Forms.CheckBox();
            this.chkTemplatesMode = new System.Windows.Forms.CheckBox();
            this.tpScreenshots = new System.Windows.Forms.TabPage();
            this.tcMtn = new System.Windows.Forms.TabControl();
            this.tpUsage1 = new System.Windows.Forms.TabPage();
            this.pMTNUsage = new System.Windows.Forms.Panel();
            this.nudMTN_B_OmitStart = new System.Windows.Forms.NumericUpDown();
            this.chkMTN_B_OmitBegin = new System.Windows.Forms.CheckBox();
            this.nudMTN_D_EdgeDetection = new System.Windows.Forms.NumericUpDown();
            this.chkMTN_D_EdgeDetection = new System.Windows.Forms.CheckBox();
            this.nudMTN_E_OmitEnd = new System.Windows.Forms.NumericUpDown();
            this.chkMTN_E_OmitEnd = new System.Windows.Forms.CheckBox();
            this.nudMTN_h_HeightMin = new System.Windows.Forms.NumericUpDown();
            this.chkMTN_h_Height = new System.Windows.Forms.CheckBox();
            this.chkMTN_v_Verbose = new System.Windows.Forms.CheckBox();
            this.txtMTN_o_OutputSuffix = new System.Windows.Forms.TextBox();
            this.chkMTN_o_OutputSuffix = new System.Windows.Forms.CheckBox();
            this.txtMTN_N_InfoSuffix = new System.Windows.Forms.TextBox();
            this.chkMTN_N_WriteInfo = new System.Windows.Forms.CheckBox();
            this.chkMTN_z_SeekMode = new System.Windows.Forms.CheckBox();
            this.chkMTN_i_MediaInfoTurnOff = new System.Windows.Forms.CheckBox();
            this.gbMTN_i_MediaInfo = new System.Windows.Forms.GroupBox();
            this.chkMTN_T_Title = new System.Windows.Forms.CheckBox();
            this.cboMTN_f_FontType = new System.Windows.Forms.ComboBox();
            this.txtMTN_T_Title = new System.Windows.Forms.TextBox();
            this.chkMTN_f_Font = new System.Windows.Forms.CheckBox();
            this.chkMTN_F_FontColor = new System.Windows.Forms.CheckBox();
            this.cboMTN_F_FontColor = new System.Windows.Forms.ComboBox();
            this.chkMTN_F_FontSize = new System.Windows.Forms.CheckBox();
            this.nudMTN_F_FontSize = new System.Windows.Forms.NumericUpDown();
            this.chkMTN_L_LocInfo = new System.Windows.Forms.CheckBox();
            this.cboMTN_L_LocInfo = new System.Windows.Forms.ComboBox();
            this.nudMTN_j_JPEGQuality = new System.Windows.Forms.NumericUpDown();
            this.chkMTN_j_JPEGQuality = new System.Windows.Forms.CheckBox();
            this.cboMTN_L_LocTimestamp = new System.Windows.Forms.ComboBox();
            this.chkMTN_tL_LocTimestamp = new System.Windows.Forms.CheckBox();
            this.chkMTN_k_ColorBackground = new System.Windows.Forms.CheckBox();
            this.nudMTN_g_Gap = new System.Windows.Forms.NumericUpDown();
            this.chkMTN_g_Gap = new System.Windows.Forms.CheckBox();
            this.cboMTN_k_ColorBkgrd = new System.Windows.Forms.ComboBox();
            this.nudMTN_w_Width = new System.Windows.Forms.NumericUpDown();
            this.chkMTN_w_Width = new System.Windows.Forms.CheckBox();
            this.chkMTN_P_QuitAfterDone = new System.Windows.Forms.CheckBox();
            this.nudMTN_s_TimeStep = new System.Windows.Forms.NumericUpDown();
            this.chkMTN_s_TimeStep = new System.Windows.Forms.CheckBox();
            this.nudMTN_r_Rows = new System.Windows.Forms.NumericUpDown();
            this.chkShowMTN = new System.Windows.Forms.CheckBox();
            this.chkMTNRows = new System.Windows.Forms.CheckBox();
            this.nudMTN_c_Columns = new System.Windows.Forms.NumericUpDown();
            this.chkMTNColumns = new System.Windows.Forms.CheckBox();
            this.tpUsage2 = new System.Windows.Forms.TabPage();
            this.pgMtn = new System.Windows.Forms.PropertyGrid();
            this.tpHostingImageShack = new System.Windows.Forms.TabPage();
            this.btnImageShackImages = new System.Windows.Forms.Button();
            this.btnImageShackRegCode = new System.Windows.Forms.Button();
            this.chkUseImageShackRegCode = new System.Windows.Forms.CheckBox();
            this.txtImageShackRegCode = new System.Windows.Forms.TextBox();
            this.chkRandomizeFileNameImageShack = new System.Windows.Forms.CheckBox();
            this.tpTorrents = new System.Windows.Forms.TabPage();
            this.btnRefreshTrackers = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.chkWritePublish = new System.Windows.Forms.CheckBox();
            this.chkTorrentOrganize = new System.Windows.Forms.CheckBox();
            this.btnBrowseTorrentCustomFolder = new System.Windows.Forms.Button();
            this.txtTorrentCustomFolder = new System.Windows.Forms.TextBox();
            this.rbTorrentFolderCustom = new System.Windows.Forms.RadioButton();
            this.rbTorrentDefaultFolder = new System.Windows.Forms.RadioButton();
            this.gbTrackerMgr = new System.Windows.Forms.GroupBox();
            this.tlpTrackers = new System.Windows.Forms.TableLayoutPanel();
            this.flpTrackers = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddTracker = new System.Windows.Forms.Button();
            this.btnRemoveTracker = new System.Windows.Forms.Button();
            this.pgTracker = new System.Windows.Forms.PropertyGrid();
            this.flpTrackerGroups = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddTrackerGroup = new System.Windows.Forms.Button();
            this.btnRemoveTrackerGroup = new System.Windows.Forms.Button();
            this.gbTrackerGroups = new System.Windows.Forms.GroupBox();
            this.lbTrackerGroups = new System.Windows.Forms.ListBox();
            this.gbTrackers = new System.Windows.Forms.GroupBox();
            this.lbTrackers = new System.Windows.Forms.ListBox();
            this.cboTrackerGroupActive = new System.Windows.Forms.ComboBox();
            this.chkCreateTorrent = new System.Windows.Forms.CheckBox();
            this.tpAdvanced = new System.Windows.Forms.TabPage();
            this.pgApp = new System.Windows.Forms.PropertyGrid();
            this.tmrStatus = new System.Windows.Forms.Timer(this.components);
            this.btnPublish = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.cmsApp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.foldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmScreenshots = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTorrentsDir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmLogsDir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSettingsDir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTemplates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmUpdatesCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsVersionHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsAppAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreateTorrent = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.ttApp = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.miFileSaveTorrent = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileSaveInfoAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.miFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.foldersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.miFoldersScreenshots = new System.Windows.Forms.ToolStripMenuItem();
            this.miFoldersTorrents = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.miFoldersLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.miFoldersLogsDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.miFoldersSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.miFoldersTemplates = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelpCheckUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelpVersionHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbScreenshotFull.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbScreenshot)).BeginInit();
            this.gbScreenshotForums.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tpMedia.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.gbDVD.SuspendLayout();
            this.gbLocation.SuspendLayout();
            this.tpMainMediaInfo.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tlpScreenshots.SuspendLayout();
            this.tlpScreenshots2.SuspendLayout();
            this.flpScreenshots1.SuspendLayout();
            this.tpMainPublish.SuspendLayout();
            this.tlpPublish.SuspendLayout();
            this.gbQuickPublish.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tcOptions.SuspendLayout();
            this.tpPublish.SuspendLayout();
            this.gbTemplatesInternal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSizeIncr)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeading1Size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeading2Size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeading3Size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBodySize)).BeginInit();
            this.tpScreenshots.SuspendLayout();
            this.tcMtn.SuspendLayout();
            this.tpUsage1.SuspendLayout();
            this.pMTNUsage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_B_OmitStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_D_EdgeDetection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_E_OmitEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_h_HeightMin)).BeginInit();
            this.gbMTN_i_MediaInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_F_FontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_j_JPEGQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_g_Gap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_w_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_s_TimeStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_r_Rows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_c_Columns)).BeginInit();
            this.tpUsage2.SuspendLayout();
            this.tpHostingImageShack.SuspendLayout();
            this.tpTorrents.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.gbTrackerMgr.SuspendLayout();
            this.tlpTrackers.SuspendLayout();
            this.flpTrackers.SuspendLayout();
            this.flpTrackerGroups.SuspendLayout();
            this.gbTrackerGroups.SuspendLayout();
            this.gbTrackers.SuspendLayout();
            this.tpAdvanced.SuspendLayout();
            this.cmsApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbScreenshotFull
            // 
            this.gbScreenshotFull.Controls.Add(this.lbScreenshots);
            this.gbScreenshotFull.Controls.Add(this.txtScrFull);
            this.gbScreenshotFull.Controls.Add(this.label4);
            this.gbScreenshotFull.Controls.Add(this.btnCopy0);
            this.gbScreenshotFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbScreenshotFull.Location = new System.Drawing.Point(3, 35);
            this.gbScreenshotFull.Name = "gbScreenshotFull";
            this.gbScreenshotFull.Size = new System.Drawing.Size(710, 194);
            this.gbScreenshotFull.TabIndex = 1;
            this.gbScreenshotFull.TabStop = false;
            this.gbScreenshotFull.Text = "URL for IRC/IM";
            // 
            // lbScreenshots
            // 
            this.lbScreenshots.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbScreenshots.FormattingEnabled = true;
            this.lbScreenshots.Location = new System.Drawing.Point(114, 65);
            this.lbScreenshots.Name = "lbScreenshots";
            this.lbScreenshots.Size = new System.Drawing.Size(446, 82);
            this.lbScreenshots.TabIndex = 8;
            this.lbScreenshots.SelectedIndexChanged += new System.EventHandler(this.lbScreenshots_SelectedIndexChanged);
            this.lbScreenshots.DoubleClick += new System.EventHandler(this.lbScreenshots_DoubleClick);
            // 
            // txtScrFull
            // 
            this.txtScrFull.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScrFull.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtScrFull.Location = new System.Drawing.Point(114, 32);
            this.txtScrFull.Name = "txtScrFull";
            this.txtScrFull.Size = new System.Drawing.Size(446, 20);
            this.txtScrFull.TabIndex = 7;
            this.txtScrFull.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.txtScrFull_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Full Image:";
            // 
            // btnCopy0
            // 
            this.btnCopy0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy0.AutoSize = true;
            this.btnCopy0.Enabled = false;
            this.btnCopy0.Location = new System.Drawing.Point(566, 31);
            this.btnCopy0.Name = "btnCopy0";
            this.btnCopy0.Size = new System.Drawing.Size(106, 23);
            this.btnCopy0.TabIndex = 3;
            this.btnCopy0.Text = "&Copy to Clipboard";
            this.btnCopy0.UseVisualStyleBackColor = true;
            this.btnCopy0.Click += new System.EventHandler(this.btnCopy0_Click);
            // 
            // pbScreenshot
            // 
            this.pbScreenshot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbScreenshot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbScreenshot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbScreenshot.Location = new System.Drawing.Point(725, 3);
            this.pbScreenshot.Name = "pbScreenshot";
            this.pbScreenshot.Size = new System.Drawing.Size(122, 433);
            this.pbScreenshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbScreenshot.TabIndex = 12;
            this.pbScreenshot.TabStop = false;
            this.pbScreenshot.Click += new System.EventHandler(this.pbScreenshot_Click);
            // 
            // gbScreenshotForums
            // 
            this.gbScreenshotForums.Controls.Add(this.label2);
            this.gbScreenshotForums.Controls.Add(this.btnCopy2);
            this.gbScreenshotForums.Controls.Add(this.txtBBScrForums);
            this.gbScreenshotForums.Controls.Add(this.label5);
            this.gbScreenshotForums.Controls.Add(this.btnCopy1);
            this.gbScreenshotForums.Controls.Add(this.txtBBScrFull);
            this.gbScreenshotForums.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbScreenshotForums.Location = new System.Drawing.Point(3, 235);
            this.gbScreenshotForums.Name = "gbScreenshotForums";
            this.gbScreenshotForums.Size = new System.Drawing.Size(710, 195);
            this.gbScreenshotForums.TabIndex = 2;
            this.gbScreenshotForums.TabStop = false;
            this.gbScreenshotForums.Text = "URL for Forums";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Thumbnail:";
            // 
            // btnCopy2
            // 
            this.btnCopy2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy2.AutoSize = true;
            this.btnCopy2.Enabled = false;
            this.btnCopy2.Location = new System.Drawing.Point(566, 78);
            this.btnCopy2.Name = "btnCopy2";
            this.btnCopy2.Size = new System.Drawing.Size(106, 23);
            this.btnCopy2.TabIndex = 7;
            this.btnCopy2.Text = "&Copy to Clipboard";
            this.btnCopy2.UseVisualStyleBackColor = true;
            this.btnCopy2.Click += new System.EventHandler(this.btnCopy2_Click);
            // 
            // txtBBScrForums
            // 
            this.txtBBScrForums.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBBScrForums.Location = new System.Drawing.Point(114, 80);
            this.txtBBScrForums.Name = "txtBBScrForums";
            this.txtBBScrForums.ReadOnly = true;
            this.txtBBScrForums.Size = new System.Drawing.Size(446, 20);
            this.txtBBScrForums.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Full Image:";
            // 
            // btnCopy1
            // 
            this.btnCopy1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy1.AutoSize = true;
            this.btnCopy1.Enabled = false;
            this.btnCopy1.Location = new System.Drawing.Point(566, 40);
            this.btnCopy1.Name = "btnCopy1";
            this.btnCopy1.Size = new System.Drawing.Size(106, 23);
            this.btnCopy1.TabIndex = 2;
            this.btnCopy1.Text = "&Copy to Clipboard";
            this.btnCopy1.UseVisualStyleBackColor = true;
            this.btnCopy1.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // txtBBScrFull
            // 
            this.txtBBScrFull.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBBScrFull.Location = new System.Drawing.Point(114, 42);
            this.txtBBScrFull.Name = "txtBBScrFull";
            this.txtBBScrFull.ReadOnly = true;
            this.txtBBScrFull.Size = new System.Drawing.Size(446, 20);
            this.txtBBScrFull.TabIndex = 1;
            // 
            // bwApp
            // 
            this.bwApp.WorkerReportsProgress = true;
            this.bwApp.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwApp_DoWork);
            this.bwApp.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwApp_RunWorkerCompleted);
            this.bwApp.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwApp_ProgressChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbarIcon,
            this.sBar,
            this.tssPerc,
            this.pBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(892, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sbarIcon
            // 
            this.sbarIcon.Image = ((System.Drawing.Image)(resources.GetObject("sbarIcon.Image")));
            this.sbarIcon.Name = "sbarIcon";
            this.sbarIcon.Size = new System.Drawing.Size(16, 17);
            // 
            // sBar
            // 
            this.sBar.Name = "sBar";
            this.sBar.Size = new System.Drawing.Size(759, 17);
            this.sBar.Spring = true;
            this.sBar.Text = "Ready";
            this.sBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssPerc
            // 
            this.tssPerc.Name = "tssPerc";
            this.tssPerc.Size = new System.Drawing.Size(0, 17);
            // 
            // pBar
            // 
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(100, 16);
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.tpMedia);
            this.tcMain.Controls.Add(this.tpMainMediaInfo);
            this.tcMain.Controls.Add(this.tabPage2);
            this.tcMain.Controls.Add(this.tpMainPublish);
            this.tcMain.Controls.Add(this.tabPage4);
            this.tcMain.Location = new System.Drawing.Point(12, 32);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(864, 471);
            this.tcMain.TabIndex = 4;
            this.tcMain.SelectedIndexChanged += new System.EventHandler(this.tcMain_SelectedIndexChanged);
            // 
            // tpMedia
            // 
            this.tpMedia.Controls.Add(this.groupBox10);
            this.tpMedia.Controls.Add(this.groupBox9);
            this.tpMedia.Controls.Add(this.gbDVD);
            this.tpMedia.Controls.Add(this.gbLocation);
            this.tpMedia.Location = new System.Drawing.Point(4, 22);
            this.tpMedia.Name = "tpMedia";
            this.tpMedia.Size = new System.Drawing.Size(856, 445);
            this.tpMedia.TabIndex = 4;
            this.tpMedia.Text = "Input";
            this.tpMedia.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.lbStatus);
            this.groupBox10.Location = new System.Drawing.Point(12, 322);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(828, 116);
            this.groupBox10.TabIndex = 13;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Progress";
            // 
            // lbStatus
            // 
            this.lbStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStatus.FormattingEnabled = true;
            this.lbStatus.Location = new System.Drawing.Point(3, 16);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.ScrollAlwaysVisible = true;
            this.lbStatus.Size = new System.Drawing.Size(822, 95);
            this.lbStatus.TabIndex = 11;
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.chkTitle);
            this.groupBox9.Controls.Add(this.txtTitle);
            this.groupBox9.Controls.Add(this.chkWebLink);
            this.groupBox9.Controls.Add(this.chkSource);
            this.groupBox9.Controls.Add(this.txtWebLink);
            this.groupBox9.Controls.Add(this.cboSource);
            this.groupBox9.Location = new System.Drawing.Point(297, 178);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(543, 133);
            this.groupBox9.TabIndex = 12;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Source Properties";
            // 
            // chkTitle
            // 
            this.chkTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkTitle.AutoSize = true;
            this.chkTitle.Checked = true;
            this.chkTitle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTitle.Location = new System.Drawing.Point(22, 60);
            this.chkTitle.Name = "chkTitle";
            this.chkTitle.Size = new System.Drawing.Size(49, 17);
            this.chkTitle.TabIndex = 14;
            this.chkTitle.Text = "&Title:";
            this.chkTitle.UseVisualStyleBackColor = true;
            this.chkTitle.CheckedChanged += new System.EventHandler(this.chkTitle_CheckedChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(117, 59);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(402, 20);
            this.txtTitle.TabIndex = 15;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // chkWebLink
            // 
            this.chkWebLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkWebLink.AutoSize = true;
            this.chkWebLink.Location = new System.Drawing.Point(22, 90);
            this.chkWebLink.Name = "chkWebLink";
            this.chkWebLink.Size = new System.Drawing.Size(75, 17);
            this.chkWebLink.TabIndex = 9;
            this.chkWebLink.Text = "&Web Link:";
            this.chkWebLink.UseVisualStyleBackColor = true;
            this.chkWebLink.CheckedChanged += new System.EventHandler(this.chkWebLink_CheckedChanged);
            // 
            // chkSource
            // 
            this.chkSource.AutoSize = true;
            this.chkSource.Checked = true;
            this.chkSource.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSource.Location = new System.Drawing.Point(22, 31);
            this.chkSource.Name = "chkSource";
            this.chkSource.Size = new System.Drawing.Size(60, 17);
            this.chkSource.TabIndex = 13;
            this.chkSource.Text = "&Source";
            this.chkSource.UseVisualStyleBackColor = true;
            this.chkSource.CheckedChanged += new System.EventHandler(this.chkSource_CheckedChanged);
            // 
            // txtWebLink
            // 
            this.txtWebLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWebLink.Location = new System.Drawing.Point(117, 89);
            this.txtWebLink.Name = "txtWebLink";
            this.txtWebLink.Size = new System.Drawing.Size(402, 20);
            this.txtWebLink.TabIndex = 10;
            this.txtWebLink.TextChanged += new System.EventHandler(this.txtWebLink_TextChanged);
            // 
            // cboSource
            // 
            this.cboSource.FormattingEnabled = true;
            this.cboSource.Location = new System.Drawing.Point(117, 29);
            this.cboSource.Name = "cboSource";
            this.cboSource.Size = new System.Drawing.Size(121, 21);
            this.cboSource.TabIndex = 0;
            this.cboSource.SelectedIndexChanged += new System.EventHandler(this.cboSource_SelectedIndexChanged);
            // 
            // gbDVD
            // 
            this.gbDVD.Controls.Add(this.cboDiscMenu);
            this.gbDVD.Controls.Add(this.chkDiscMenu);
            this.gbDVD.Controls.Add(this.cboExtras);
            this.gbDVD.Controls.Add(this.chkExtras);
            this.gbDVD.Controls.Add(this.cboAuthoring);
            this.gbDVD.Controls.Add(this.chkAuthoring);
            this.gbDVD.Location = new System.Drawing.Point(12, 178);
            this.gbDVD.Name = "gbDVD";
            this.gbDVD.Size = new System.Drawing.Size(269, 133);
            this.gbDVD.TabIndex = 11;
            this.gbDVD.TabStop = false;
            this.gbDVD.Text = "DVD Properties";
            // 
            // cboDiscMenu
            // 
            this.cboDiscMenu.FormattingEnabled = true;
            this.cboDiscMenu.Location = new System.Drawing.Point(121, 58);
            this.cboDiscMenu.Name = "cboDiscMenu";
            this.cboDiscMenu.Size = new System.Drawing.Size(121, 21);
            this.cboDiscMenu.TabIndex = 18;
            this.cboDiscMenu.SelectedIndexChanged += new System.EventHandler(this.cboDiscMenu_SelectedIndexChanged);
            // 
            // chkDiscMenu
            // 
            this.chkDiscMenu.AutoSize = true;
            this.chkDiscMenu.Checked = true;
            this.chkDiscMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDiscMenu.Location = new System.Drawing.Point(26, 60);
            this.chkDiscMenu.Name = "chkDiscMenu";
            this.chkDiscMenu.Size = new System.Drawing.Size(56, 17);
            this.chkDiscMenu.TabIndex = 17;
            this.chkDiscMenu.Text = "Menu:";
            this.chkDiscMenu.UseVisualStyleBackColor = true;
            this.chkDiscMenu.CheckedChanged += new System.EventHandler(this.chkDiscMenu_CheckedChanged);
            // 
            // cboExtras
            // 
            this.cboExtras.FormattingEnabled = true;
            this.cboExtras.Location = new System.Drawing.Point(121, 86);
            this.cboExtras.Name = "cboExtras";
            this.cboExtras.Size = new System.Drawing.Size(121, 21);
            this.cboExtras.TabIndex = 16;
            this.cboExtras.SelectedIndexChanged += new System.EventHandler(this.cboExtras_SelectedIndexChanged);
            // 
            // chkExtras
            // 
            this.chkExtras.AutoSize = true;
            this.chkExtras.Checked = true;
            this.chkExtras.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExtras.Location = new System.Drawing.Point(26, 88);
            this.chkExtras.Name = "chkExtras";
            this.chkExtras.Size = new System.Drawing.Size(58, 17);
            this.chkExtras.TabIndex = 15;
            this.chkExtras.Text = "E&xtras:";
            this.chkExtras.UseVisualStyleBackColor = true;
            this.chkExtras.CheckedChanged += new System.EventHandler(this.chkExtras_CheckedChanged);
            // 
            // cboAuthoring
            // 
            this.cboAuthoring.FormattingEnabled = true;
            this.cboAuthoring.Location = new System.Drawing.Point(121, 29);
            this.cboAuthoring.Name = "cboAuthoring";
            this.cboAuthoring.Size = new System.Drawing.Size(121, 21);
            this.cboAuthoring.TabIndex = 14;
            this.cboAuthoring.SelectedIndexChanged += new System.EventHandler(this.cboAuthoring_SelectedIndexChanged);
            // 
            // chkAuthoring
            // 
            this.chkAuthoring.AutoSize = true;
            this.chkAuthoring.Checked = true;
            this.chkAuthoring.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAuthoring.Location = new System.Drawing.Point(26, 32);
            this.chkAuthoring.Name = "chkAuthoring";
            this.chkAuthoring.Size = new System.Drawing.Size(74, 17);
            this.chkAuthoring.TabIndex = 13;
            this.chkAuthoring.Text = "Authoring:";
            this.chkAuthoring.UseVisualStyleBackColor = true;
            this.chkAuthoring.CheckedChanged += new System.EventHandler(this.chkSourceEdit_CheckedChanged);
            // 
            // gbLocation
            // 
            this.gbLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLocation.Controls.Add(this.lbFiles);
            this.gbLocation.Controls.Add(this.rbDir);
            this.gbLocation.Controls.Add(this.rbFile);
            this.gbLocation.Controls.Add(this.btnBrowse);
            this.gbLocation.Location = new System.Drawing.Point(12, 8);
            this.gbLocation.Name = "gbLocation";
            this.gbLocation.Size = new System.Drawing.Size(828, 163);
            this.gbLocation.TabIndex = 7;
            this.gbLocation.TabStop = false;
            this.gbLocation.Text = "Location";
            // 
            // lbFiles
            // 
            this.lbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.HorizontalScrollbar = true;
            this.lbFiles.Location = new System.Drawing.Point(26, 57);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(786, 82);
            this.lbFiles.TabIndex = 13;
            // 
            // rbDir
            // 
            this.rbDir.AutoSize = true;
            this.rbDir.Location = new System.Drawing.Point(232, 27);
            this.rbDir.Name = "rbDir";
            this.rbDir.Size = new System.Drawing.Size(80, 17);
            this.rbDir.TabIndex = 9;
            this.rbDir.TabStop = true;
            this.rbDir.Text = "&DVD Folder";
            this.rbDir.UseVisualStyleBackColor = true;
            this.rbDir.CheckedChanged += new System.EventHandler(this.rbDir_CheckedChanged);
            // 
            // rbFile
            // 
            this.rbFile.AutoSize = true;
            this.rbFile.Checked = true;
            this.rbFile.Location = new System.Drawing.Point(26, 27);
            this.rbFile.Name = "rbFile";
            this.rbFile.Size = new System.Drawing.Size(71, 17);
            this.rbFile.TabIndex = 8;
            this.rbFile.TabStop = true;
            this.rbFile.Text = "&Video File";
            this.rbFile.UseVisualStyleBackColor = true;
            this.rbFile.CheckedChanged += new System.EventHandler(this.rbFile_CheckedChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.AutoSize = true;
            this.btnBrowse.Location = new System.Drawing.Point(740, 24);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(72, 23);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "&Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tpMainMediaInfo
            // 
            this.tpMainMediaInfo.Controls.Add(this.txtMediaInfo);
            this.tpMainMediaInfo.Location = new System.Drawing.Point(4, 22);
            this.tpMainMediaInfo.Name = "tpMainMediaInfo";
            this.tpMainMediaInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpMainMediaInfo.Size = new System.Drawing.Size(856, 445);
            this.tpMainMediaInfo.TabIndex = 0;
            this.tpMainMediaInfo.Text = "Media Info";
            this.tpMainMediaInfo.UseVisualStyleBackColor = true;
            // 
            // txtMediaInfo
            // 
            this.txtMediaInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMediaInfo.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMediaInfo.Location = new System.Drawing.Point(3, 3);
            this.txtMediaInfo.Multiline = true;
            this.txtMediaInfo.Name = "txtMediaInfo";
            this.txtMediaInfo.ReadOnly = true;
            this.txtMediaInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMediaInfo.Size = new System.Drawing.Size(850, 439);
            this.txtMediaInfo.TabIndex = 0;
            this.txtMediaInfo.WordWrap = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tlpScreenshots);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(856, 445);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Screenshots";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tlpScreenshots
            // 
            this.tlpScreenshots.ColumnCount = 2;
            this.tlpScreenshots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tlpScreenshots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpScreenshots.Controls.Add(this.tlpScreenshots2, 0, 0);
            this.tlpScreenshots.Controls.Add(this.pbScreenshot, 1, 0);
            this.tlpScreenshots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpScreenshots.Location = new System.Drawing.Point(3, 3);
            this.tlpScreenshots.Name = "tlpScreenshots";
            this.tlpScreenshots.RowCount = 1;
            this.tlpScreenshots.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpScreenshots.Size = new System.Drawing.Size(850, 439);
            this.tlpScreenshots.TabIndex = 12;
            // 
            // tlpScreenshots2
            // 
            this.tlpScreenshots2.ColumnCount = 1;
            this.tlpScreenshots2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpScreenshots2.Controls.Add(this.flpScreenshots1, 0, 0);
            this.tlpScreenshots2.Controls.Add(this.gbScreenshotForums, 0, 2);
            this.tlpScreenshots2.Controls.Add(this.gbScreenshotFull, 0, 1);
            this.tlpScreenshots2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpScreenshots2.Location = new System.Drawing.Point(3, 3);
            this.tlpScreenshots2.Name = "tlpScreenshots2";
            this.tlpScreenshots2.RowCount = 3;
            this.tlpScreenshots2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpScreenshots2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpScreenshots2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpScreenshots2.Size = new System.Drawing.Size(716, 433);
            this.tlpScreenshots2.TabIndex = 0;
            // 
            // flpScreenshots1
            // 
            this.flpScreenshots1.Controls.Add(this.chkScreenshot);
            this.flpScreenshots1.Controls.Add(this.chkScreenshotUpload);
            this.flpScreenshots1.Controls.Add(this.cboScreenshotDest);
            this.flpScreenshots1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpScreenshots1.Location = new System.Drawing.Point(3, 3);
            this.flpScreenshots1.Name = "flpScreenshots1";
            this.flpScreenshots1.Size = new System.Drawing.Size(710, 26);
            this.flpScreenshots1.TabIndex = 0;
            // 
            // chkScreenshot
            // 
            this.chkScreenshot.AutoSize = true;
            this.chkScreenshot.Checked = true;
            this.chkScreenshot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScreenshot.Location = new System.Drawing.Point(3, 3);
            this.chkScreenshot.Name = "chkScreenshot";
            this.chkScreenshot.Size = new System.Drawing.Size(114, 17);
            this.chkScreenshot.TabIndex = 11;
            this.chkScreenshot.Text = "&Create Screenshot";
            this.chkScreenshot.UseVisualStyleBackColor = true;
            this.chkScreenshot.CheckedChanged += new System.EventHandler(this.chkScreenshot_CheckedChanged);
            // 
            // chkScreenshotUpload
            // 
            this.chkScreenshotUpload.AutoSize = true;
            this.chkScreenshotUpload.Checked = true;
            this.chkScreenshotUpload.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScreenshotUpload.Location = new System.Drawing.Point(123, 3);
            this.chkScreenshotUpload.Name = "chkScreenshotUpload";
            this.chkScreenshotUpload.Size = new System.Drawing.Size(129, 17);
            this.chkScreenshotUpload.TabIndex = 0;
            this.chkScreenshotUpload.Text = "Upload Screenshot to";
            this.chkScreenshotUpload.UseVisualStyleBackColor = true;
            this.chkScreenshotUpload.CheckedChanged += new System.EventHandler(this.chkScreenshotUpload_CheckedChanged);
            // 
            // cboScreenshotDest
            // 
            this.cboScreenshotDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboScreenshotDest.FormattingEnabled = true;
            this.cboScreenshotDest.Location = new System.Drawing.Point(258, 3);
            this.cboScreenshotDest.Name = "cboScreenshotDest";
            this.cboScreenshotDest.Size = new System.Drawing.Size(196, 21);
            this.cboScreenshotDest.TabIndex = 2;
            this.cboScreenshotDest.SelectedIndexChanged += new System.EventHandler(this.cboScreenshotDest_SelectedIndexChanged);
            // 
            // tpMainPublish
            // 
            this.tpMainPublish.Controls.Add(this.tlpPublish);
            this.tpMainPublish.Location = new System.Drawing.Point(4, 22);
            this.tpMainPublish.Name = "tpMainPublish";
            this.tpMainPublish.Padding = new System.Windows.Forms.Padding(3);
            this.tpMainPublish.Size = new System.Drawing.Size(856, 445);
            this.tpMainPublish.TabIndex = 2;
            this.tpMainPublish.Text = "Publish";
            this.tpMainPublish.UseVisualStyleBackColor = true;
            // 
            // tlpPublish
            // 
            this.tlpPublish.ColumnCount = 2;
            this.tlpPublish.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpPublish.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPublish.Controls.Add(this.gbQuickPublish, 1, 0);
            this.tlpPublish.Controls.Add(this.txtPublish, 0, 0);
            this.tlpPublish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPublish.Location = new System.Drawing.Point(3, 3);
            this.tlpPublish.Name = "tlpPublish";
            this.tlpPublish.RowCount = 1;
            this.tlpPublish.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPublish.Size = new System.Drawing.Size(850, 439);
            this.tlpPublish.TabIndex = 2;
            // 
            // gbQuickPublish
            // 
            this.gbQuickPublish.Controls.Add(this.rbTExt);
            this.gbQuickPublish.Controls.Add(this.rbTInt);
            this.gbQuickPublish.Controls.Add(this.cboQuickTemplate);
            this.gbQuickPublish.Controls.Add(this.chkQuickFullPicture);
            this.gbQuickPublish.Controls.Add(this.chkQuickAlignCenter);
            this.gbQuickPublish.Controls.Add(this.chkQuickPre);
            this.gbQuickPublish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbQuickPublish.Location = new System.Drawing.Point(683, 3);
            this.gbQuickPublish.Name = "gbQuickPublish";
            this.gbQuickPublish.Size = new System.Drawing.Size(164, 433);
            this.gbQuickPublish.TabIndex = 1;
            this.gbQuickPublish.TabStop = false;
            this.gbQuickPublish.Text = "Options";
            // 
            // rbTExt
            // 
            this.rbTExt.AutoSize = true;
            this.rbTExt.Location = new System.Drawing.Point(15, 127);
            this.rbTExt.Name = "rbTExt";
            this.rbTExt.Size = new System.Drawing.Size(110, 17);
            this.rbTExt.TabIndex = 6;
            this.rbTExt.TabStop = true;
            this.rbTExt.Text = "E&xternal Template";
            this.rbTExt.UseVisualStyleBackColor = true;
            this.rbTExt.CheckedChanged += new System.EventHandler(this.rbTExt_CheckedChanged);
            // 
            // rbTInt
            // 
            this.rbTInt.AutoSize = true;
            this.rbTInt.Location = new System.Drawing.Point(15, 104);
            this.rbTInt.Name = "rbTInt";
            this.rbTInt.Size = new System.Drawing.Size(107, 17);
            this.rbTInt.TabIndex = 5;
            this.rbTInt.TabStop = true;
            this.rbTInt.Text = "&Internal Template";
            this.rbTInt.UseVisualStyleBackColor = true;
            this.rbTInt.CheckedChanged += new System.EventHandler(this.rbTInt_CheckedChanged);
            // 
            // cboQuickTemplate
            // 
            this.cboQuickTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuickTemplate.FormattingEnabled = true;
            this.cboQuickTemplate.Location = new System.Drawing.Point(15, 150);
            this.cboQuickTemplate.Name = "cboQuickTemplate";
            this.cboQuickTemplate.Size = new System.Drawing.Size(121, 21);
            this.cboQuickTemplate.TabIndex = 3;
            this.cboQuickTemplate.SelectedIndexChanged += new System.EventHandler(this.cboQuickTemplate_SelectedIndexChanged);
            // 
            // chkQuickFullPicture
            // 
            this.chkQuickFullPicture.AutoSize = true;
            this.chkQuickFullPicture.Location = new System.Drawing.Point(15, 71);
            this.chkQuickFullPicture.Name = "chkQuickFullPicture";
            this.chkQuickFullPicture.Size = new System.Drawing.Size(78, 17);
            this.chkQuickFullPicture.TabIndex = 2;
            this.chkQuickFullPicture.Text = "Full &Picture";
            this.chkQuickFullPicture.UseVisualStyleBackColor = true;
            this.chkQuickFullPicture.CheckedChanged += new System.EventHandler(this.chkQuickFullPicture_CheckedChanged);
            // 
            // chkQuickAlignCenter
            // 
            this.chkQuickAlignCenter.AutoSize = true;
            this.chkQuickAlignCenter.Location = new System.Drawing.Point(15, 48);
            this.chkQuickAlignCenter.Name = "chkQuickAlignCenter";
            this.chkQuickAlignCenter.Size = new System.Drawing.Size(83, 17);
            this.chkQuickAlignCenter.TabIndex = 1;
            this.chkQuickAlignCenter.Text = "Align &Center";
            this.chkQuickAlignCenter.UseVisualStyleBackColor = true;
            this.chkQuickAlignCenter.CheckedChanged += new System.EventHandler(this.chkQuickAlignCenter_CheckedChanged);
            // 
            // chkQuickPre
            // 
            this.chkQuickPre.AutoSize = true;
            this.chkQuickPre.Location = new System.Drawing.Point(15, 25);
            this.chkQuickPre.Name = "chkQuickPre";
            this.chkQuickPre.Size = new System.Drawing.Size(110, 17);
            this.chkQuickPre.TabIndex = 0;
            this.chkQuickPre.Text = "&Preformatted Text";
            this.chkQuickPre.UseVisualStyleBackColor = true;
            this.chkQuickPre.CheckedChanged += new System.EventHandler(this.chkQuickPre_CheckedChanged);
            // 
            // txtPublish
            // 
            this.txtPublish.AcceptsReturn = true;
            this.txtPublish.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPublish.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPublish.Location = new System.Drawing.Point(3, 3);
            this.txtPublish.Multiline = true;
            this.txtPublish.Name = "txtPublish";
            this.txtPublish.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPublish.Size = new System.Drawing.Size(674, 433);
            this.txtPublish.TabIndex = 0;
            this.txtPublish.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPublish_KeyPress);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tcOptions);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(856, 445);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Options";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tcOptions
            // 
            this.tcOptions.Controls.Add(this.tpPublish);
            this.tcOptions.Controls.Add(this.tpScreenshots);
            this.tcOptions.Controls.Add(this.tpTorrents);
            this.tcOptions.Controls.Add(this.tpAdvanced);
            this.tcOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcOptions.Location = new System.Drawing.Point(0, 0);
            this.tcOptions.Name = "tcOptions";
            this.tcOptions.SelectedIndex = 0;
            this.tcOptions.Size = new System.Drawing.Size(856, 445);
            this.tcOptions.TabIndex = 11;
            // 
            // tpPublish
            // 
            this.tpPublish.Controls.Add(this.btnTemplatesRewrite);
            this.tpPublish.Controls.Add(this.cboTemplate);
            this.tpPublish.Controls.Add(this.gbTemplatesInternal);
            this.tpPublish.Controls.Add(this.groupBox6);
            this.tpPublish.Controls.Add(this.chkUploadFullScreenshot);
            this.tpPublish.Controls.Add(this.chkTemplatesMode);
            this.tpPublish.Location = new System.Drawing.Point(4, 22);
            this.tpPublish.Name = "tpPublish";
            this.tpPublish.Padding = new System.Windows.Forms.Padding(3);
            this.tpPublish.Size = new System.Drawing.Size(848, 419);
            this.tpPublish.TabIndex = 2;
            this.tpPublish.Text = "Publish Templates";
            this.tpPublish.UseVisualStyleBackColor = true;
            // 
            // btnTemplatesRewrite
            // 
            this.btnTemplatesRewrite.AutoSize = true;
            this.btnTemplatesRewrite.Location = new System.Drawing.Point(16, 233);
            this.btnTemplatesRewrite.Name = "btnTemplatesRewrite";
            this.btnTemplatesRewrite.Size = new System.Drawing.Size(151, 23);
            this.btnTemplatesRewrite.TabIndex = 13;
            this.btnTemplatesRewrite.Text = "&Rewrite Default Templates...";
            this.btnTemplatesRewrite.UseVisualStyleBackColor = true;
            this.btnTemplatesRewrite.Click += new System.EventHandler(this.btnTemplatesRewrite_Click);
            // 
            // cboTemplate
            // 
            this.cboTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTemplate.FormattingEnabled = true;
            this.cboTemplate.Location = new System.Drawing.Point(252, 14);
            this.cboTemplate.Name = "cboTemplate";
            this.cboTemplate.Size = new System.Drawing.Size(195, 21);
            this.cboTemplate.TabIndex = 9;
            this.cboTemplate.SelectedIndexChanged += new System.EventHandler(this.cboTemplate_SelectedIndexChanged);
            // 
            // gbTemplatesInternal
            // 
            this.gbTemplatesInternal.Controls.Add(this.nudFontSizeIncr);
            this.gbTemplatesInternal.Controls.Add(this.chkPre);
            this.gbTemplatesInternal.Controls.Add(this.chkPreIncreaseFontSize);
            this.gbTemplatesInternal.Controls.Add(this.chkAlignCenter);
            this.gbTemplatesInternal.Location = new System.Drawing.Point(16, 72);
            this.gbTemplatesInternal.Name = "gbTemplatesInternal";
            this.gbTemplatesInternal.Size = new System.Drawing.Size(431, 148);
            this.gbTemplatesInternal.TabIndex = 3;
            this.gbTemplatesInternal.TabStop = false;
            this.gbTemplatesInternal.Text = "Internal Template Settings";
            // 
            // nudFontSizeIncr
            // 
            this.nudFontSizeIncr.Location = new System.Drawing.Point(319, 55);
            this.nudFontSizeIncr.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFontSizeIncr.Name = "nudFontSizeIncr";
            this.nudFontSizeIncr.Size = new System.Drawing.Size(55, 20);
            this.nudFontSizeIncr.TabIndex = 9;
            this.nudFontSizeIncr.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFontSizeIncr.ValueChanged += new System.EventHandler(this.nudFontSizeIncr_ValueChanged);
            // 
            // chkPre
            // 
            this.chkPre.AutoSize = true;
            this.chkPre.Location = new System.Drawing.Point(17, 56);
            this.chkPre.Name = "chkPre";
            this.chkPre.Size = new System.Drawing.Size(132, 17);
            this.chkPre.TabIndex = 1;
            this.chkPre.Text = "Use Preformatted Text";
            this.chkPre.UseVisualStyleBackColor = true;
            this.chkPre.CheckedChanged += new System.EventHandler(this.chkPre_CheckedChanged);
            // 
            // chkPreIncreaseFontSize
            // 
            this.chkPreIncreaseFontSize.AutoSize = true;
            this.chkPreIncreaseFontSize.Checked = true;
            this.chkPreIncreaseFontSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreIncreaseFontSize.Location = new System.Drawing.Point(165, 56);
            this.chkPreIncreaseFontSize.Name = "chkPreIncreaseFontSize";
            this.chkPreIncreaseFontSize.Size = new System.Drawing.Size(148, 17);
            this.chkPreIncreaseFontSize.TabIndex = 8;
            this.chkPreIncreaseFontSize.Text = "and increase Font Size by";
            this.chkPreIncreaseFontSize.UseVisualStyleBackColor = true;
            this.chkPreIncreaseFontSize.CheckedChanged += new System.EventHandler(this.chkPreIncreaseFontSize_CheckedChanged);
            // 
            // chkAlignCenter
            // 
            this.chkAlignCenter.AutoSize = true;
            this.chkAlignCenter.Location = new System.Drawing.Point(17, 33);
            this.chkAlignCenter.Name = "chkAlignCenter";
            this.chkAlignCenter.Size = new System.Drawing.Size(83, 17);
            this.chkAlignCenter.TabIndex = 0;
            this.chkAlignCenter.Text = "Align &Center";
            this.chkAlignCenter.UseVisualStyleBackColor = true;
            this.chkAlignCenter.CheckedChanged += new System.EventHandler(this.chkAlignCenter_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.nudHeading1Size);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.nudHeading2Size);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.nudHeading3Size);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.nudBodySize);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Location = new System.Drawing.Point(455, 72);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(190, 148);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Font Size";
            // 
            // nudHeading1Size
            // 
            this.nudHeading1Size.Location = new System.Drawing.Point(106, 30);
            this.nudHeading1Size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeading1Size.Name = "nudHeading1Size";
            this.nudHeading1Size.Size = new System.Drawing.Size(55, 20);
            this.nudHeading1Size.TabIndex = 10;
            this.nudHeading1Size.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeading1Size.ValueChanged += new System.EventHandler(this.nudFontSizeHeading1_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Heading 1";
            // 
            // nudHeading2Size
            // 
            this.nudHeading2Size.Location = new System.Drawing.Point(106, 53);
            this.nudHeading2Size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeading2Size.Name = "nudHeading2Size";
            this.nudHeading2Size.Size = new System.Drawing.Size(55, 20);
            this.nudHeading2Size.TabIndex = 8;
            this.nudHeading2Size.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeading2Size.ValueChanged += new System.EventHandler(this.nudHeading2Size_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Heading 2";
            // 
            // nudHeading3Size
            // 
            this.nudHeading3Size.Location = new System.Drawing.Point(106, 79);
            this.nudHeading3Size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeading3Size.Name = "nudHeading3Size";
            this.nudHeading3Size.Size = new System.Drawing.Size(55, 20);
            this.nudHeading3Size.TabIndex = 4;
            this.nudHeading3Size.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeading3Size.ValueChanged += new System.EventHandler(this.nudHeading3Size_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(69, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Body";
            // 
            // nudBodySize
            // 
            this.nudBodySize.Location = new System.Drawing.Point(106, 105);
            this.nudBodySize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBodySize.Name = "nudBodySize";
            this.nudBodySize.Size = new System.Drawing.Size(55, 20);
            this.nudBodySize.TabIndex = 5;
            this.nudBodySize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBodySize.ValueChanged += new System.EventHandler(this.nudBodyText_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Heading 3";
            // 
            // chkUploadFullScreenshot
            // 
            this.chkUploadFullScreenshot.AutoSize = true;
            this.chkUploadFullScreenshot.Checked = true;
            this.chkUploadFullScreenshot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUploadFullScreenshot.Location = new System.Drawing.Point(16, 41);
            this.chkUploadFullScreenshot.Name = "chkUploadFullScreenshot";
            this.chkUploadFullScreenshot.Size = new System.Drawing.Size(200, 17);
            this.chkUploadFullScreenshot.TabIndex = 1;
            this.chkUploadFullScreenshot.Text = "Use &Full Image instead of Thumbnail ";
            this.chkUploadFullScreenshot.UseVisualStyleBackColor = true;
            this.chkUploadFullScreenshot.CheckedChanged += new System.EventHandler(this.chkUploadFullScreenshot_CheckedChanged);
            // 
            // chkTemplatesMode
            // 
            this.chkTemplatesMode.AutoSize = true;
            this.chkTemplatesMode.Location = new System.Drawing.Point(16, 16);
            this.chkTemplatesMode.Name = "chkTemplatesMode";
            this.chkTemplatesMode.Size = new System.Drawing.Size(230, 17);
            this.chkTemplatesMode.TabIndex = 0;
            this.chkTemplatesMode.Text = "Create description using External &Template:";
            this.chkTemplatesMode.UseVisualStyleBackColor = true;
            this.chkTemplatesMode.CheckedChanged += new System.EventHandler(this.chkTemplatesMode_CheckedChanged);
            // 
            // tpScreenshots
            // 
            this.tpScreenshots.Controls.Add(this.tcMtn);
            this.tpScreenshots.Location = new System.Drawing.Point(4, 22);
            this.tpScreenshots.Name = "tpScreenshots";
            this.tpScreenshots.Padding = new System.Windows.Forms.Padding(3);
            this.tpScreenshots.Size = new System.Drawing.Size(848, 419);
            this.tpScreenshots.TabIndex = 0;
            this.tpScreenshots.Text = "Movie Thumbnailer";
            this.tpScreenshots.UseVisualStyleBackColor = true;
            // 
            // tcMtn
            // 
            this.tcMtn.Controls.Add(this.tpUsage1);
            this.tcMtn.Controls.Add(this.tpUsage2);
            this.tcMtn.Controls.Add(this.tpHostingImageShack);
            this.tcMtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMtn.Location = new System.Drawing.Point(3, 3);
            this.tcMtn.Name = "tcMtn";
            this.tcMtn.SelectedIndex = 0;
            this.tcMtn.Size = new System.Drawing.Size(842, 413);
            this.tcMtn.TabIndex = 5;
            // 
            // tpUsage1
            // 
            this.tpUsage1.Controls.Add(this.pMTNUsage);
            this.tpUsage1.Location = new System.Drawing.Point(4, 22);
            this.tpUsage1.Name = "tpUsage1";
            this.tpUsage1.Padding = new System.Windows.Forms.Padding(3);
            this.tpUsage1.Size = new System.Drawing.Size(834, 387);
            this.tpUsage1.TabIndex = 1;
            this.tpUsage1.Text = "Usage (Simple)";
            this.tpUsage1.UseVisualStyleBackColor = true;
            // 
            // pMTNUsage
            // 
            this.pMTNUsage.AutoScroll = true;
            this.pMTNUsage.Controls.Add(this.nudMTN_B_OmitStart);
            this.pMTNUsage.Controls.Add(this.chkMTN_B_OmitBegin);
            this.pMTNUsage.Controls.Add(this.nudMTN_D_EdgeDetection);
            this.pMTNUsage.Controls.Add(this.chkMTN_D_EdgeDetection);
            this.pMTNUsage.Controls.Add(this.nudMTN_E_OmitEnd);
            this.pMTNUsage.Controls.Add(this.chkMTN_E_OmitEnd);
            this.pMTNUsage.Controls.Add(this.nudMTN_h_HeightMin);
            this.pMTNUsage.Controls.Add(this.chkMTN_h_Height);
            this.pMTNUsage.Controls.Add(this.chkMTN_v_Verbose);
            this.pMTNUsage.Controls.Add(this.txtMTN_o_OutputSuffix);
            this.pMTNUsage.Controls.Add(this.chkMTN_o_OutputSuffix);
            this.pMTNUsage.Controls.Add(this.txtMTN_N_InfoSuffix);
            this.pMTNUsage.Controls.Add(this.chkMTN_N_WriteInfo);
            this.pMTNUsage.Controls.Add(this.chkMTN_z_SeekMode);
            this.pMTNUsage.Controls.Add(this.chkMTN_i_MediaInfoTurnOff);
            this.pMTNUsage.Controls.Add(this.gbMTN_i_MediaInfo);
            this.pMTNUsage.Controls.Add(this.nudMTN_j_JPEGQuality);
            this.pMTNUsage.Controls.Add(this.chkMTN_j_JPEGQuality);
            this.pMTNUsage.Controls.Add(this.cboMTN_L_LocTimestamp);
            this.pMTNUsage.Controls.Add(this.chkMTN_tL_LocTimestamp);
            this.pMTNUsage.Controls.Add(this.chkMTN_k_ColorBackground);
            this.pMTNUsage.Controls.Add(this.nudMTN_g_Gap);
            this.pMTNUsage.Controls.Add(this.chkMTN_g_Gap);
            this.pMTNUsage.Controls.Add(this.cboMTN_k_ColorBkgrd);
            this.pMTNUsage.Controls.Add(this.nudMTN_w_Width);
            this.pMTNUsage.Controls.Add(this.chkMTN_w_Width);
            this.pMTNUsage.Controls.Add(this.chkMTN_P_QuitAfterDone);
            this.pMTNUsage.Controls.Add(this.nudMTN_s_TimeStep);
            this.pMTNUsage.Controls.Add(this.chkMTN_s_TimeStep);
            this.pMTNUsage.Controls.Add(this.nudMTN_r_Rows);
            this.pMTNUsage.Controls.Add(this.chkShowMTN);
            this.pMTNUsage.Controls.Add(this.chkMTNRows);
            this.pMTNUsage.Controls.Add(this.nudMTN_c_Columns);
            this.pMTNUsage.Controls.Add(this.chkMTNColumns);
            this.pMTNUsage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMTNUsage.Location = new System.Drawing.Point(3, 3);
            this.pMTNUsage.Name = "pMTNUsage";
            this.pMTNUsage.Size = new System.Drawing.Size(828, 381);
            this.pMTNUsage.TabIndex = 14;
            // 
            // nudMTN_B_OmitStart
            // 
            this.nudMTN_B_OmitStart.DecimalPlaces = 1;
            this.nudMTN_B_OmitStart.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMTN_B_OmitStart.Location = new System.Drawing.Point(172, 213);
            this.nudMTN_B_OmitStart.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMTN_B_OmitStart.Name = "nudMTN_B_OmitStart";
            this.nudMTN_B_OmitStart.Size = new System.Drawing.Size(120, 20);
            this.nudMTN_B_OmitStart.TabIndex = 52;
            this.ttApp.SetToolTip(this.nudMTN_B_OmitStart, "Keep 0 for Exact Dimensions");
            this.nudMTN_B_OmitStart.ValueChanged += new System.EventHandler(this.nudMTN_B_OmitStart_ValueChanged);
            // 
            // chkMTN_B_OmitBegin
            // 
            this.chkMTN_B_OmitBegin.AutoSize = true;
            this.chkMTN_B_OmitBegin.Location = new System.Drawing.Point(22, 215);
            this.chkMTN_B_OmitBegin.Name = "chkMTN_B_OmitBegin";
            this.chkMTN_B_OmitBegin.Size = new System.Drawing.Size(121, 17);
            this.chkMTN_B_OmitBegin.TabIndex = 51;
            this.chkMTN_B_OmitBegin.Text = "&Omit Start (seconds)";
            this.chkMTN_B_OmitBegin.UseVisualStyleBackColor = true;
            // 
            // nudMTN_D_EdgeDetection
            // 
            this.nudMTN_D_EdgeDetection.Location = new System.Drawing.Point(172, 263);
            this.nudMTN_D_EdgeDetection.Name = "nudMTN_D_EdgeDetection";
            this.nudMTN_D_EdgeDetection.Size = new System.Drawing.Size(120, 20);
            this.nudMTN_D_EdgeDetection.TabIndex = 50;
            this.nudMTN_D_EdgeDetection.ValueChanged += new System.EventHandler(this.nudMTN_D_EdgeDetection_ValueChanged);
            // 
            // chkMTN_D_EdgeDetection
            // 
            this.chkMTN_D_EdgeDetection.AutoSize = true;
            this.chkMTN_D_EdgeDetection.Checked = true;
            this.chkMTN_D_EdgeDetection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMTN_D_EdgeDetection.Location = new System.Drawing.Point(22, 265);
            this.chkMTN_D_EdgeDetection.Name = "chkMTN_D_EdgeDetection";
            this.chkMTN_D_EdgeDetection.Size = new System.Drawing.Size(100, 17);
            this.chkMTN_D_EdgeDetection.TabIndex = 49;
            this.chkMTN_D_EdgeDetection.Text = "Edge Detection";
            this.chkMTN_D_EdgeDetection.UseVisualStyleBackColor = true;
            // 
            // nudMTN_E_OmitEnd
            // 
            this.nudMTN_E_OmitEnd.DecimalPlaces = 1;
            this.nudMTN_E_OmitEnd.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMTN_E_OmitEnd.Location = new System.Drawing.Point(172, 238);
            this.nudMTN_E_OmitEnd.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMTN_E_OmitEnd.Name = "nudMTN_E_OmitEnd";
            this.nudMTN_E_OmitEnd.Size = new System.Drawing.Size(120, 20);
            this.nudMTN_E_OmitEnd.TabIndex = 48;
            this.ttApp.SetToolTip(this.nudMTN_E_OmitEnd, "Keep 0 for Exact Dimensions");
            this.nudMTN_E_OmitEnd.ValueChanged += new System.EventHandler(this.nudMTN_E_OmitEnd_ValueChanged);
            // 
            // chkMTN_E_OmitEnd
            // 
            this.chkMTN_E_OmitEnd.AutoSize = true;
            this.chkMTN_E_OmitEnd.Location = new System.Drawing.Point(22, 240);
            this.chkMTN_E_OmitEnd.Name = "chkMTN_E_OmitEnd";
            this.chkMTN_E_OmitEnd.Size = new System.Drawing.Size(118, 17);
            this.chkMTN_E_OmitEnd.TabIndex = 47;
            this.chkMTN_E_OmitEnd.Text = "&Omit End (seconds)";
            this.chkMTN_E_OmitEnd.UseVisualStyleBackColor = true;
            // 
            // nudMTN_h_HeightMin
            // 
            this.nudMTN_h_HeightMin.Location = new System.Drawing.Point(172, 62);
            this.nudMTN_h_HeightMin.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.nudMTN_h_HeightMin.Name = "nudMTN_h_HeightMin";
            this.nudMTN_h_HeightMin.Size = new System.Drawing.Size(120, 20);
            this.nudMTN_h_HeightMin.TabIndex = 46;
            this.nudMTN_h_HeightMin.ValueChanged += new System.EventHandler(this.nudMTN_h_HeightMin_ValueChanged);
            // 
            // chkMTN_h_Height
            // 
            this.chkMTN_h_Height.AutoSize = true;
            this.chkMTN_h_Height.Location = new System.Drawing.Point(22, 65);
            this.chkMTN_h_Height.Name = "chkMTN_h_Height";
            this.chkMTN_h_Height.Size = new System.Drawing.Size(107, 17);
            this.chkMTN_h_Height.TabIndex = 45;
            this.chkMTN_h_Height.Text = "Height (Minimum)";
            this.chkMTN_h_Height.UseVisualStyleBackColor = true;
            // 
            // chkMTN_v_Verbose
            // 
            this.chkMTN_v_Verbose.AutoSize = true;
            this.chkMTN_v_Verbose.Location = new System.Drawing.Point(22, 301);
            this.chkMTN_v_Verbose.Name = "chkMTN_v_Verbose";
            this.chkMTN_v_Verbose.Size = new System.Drawing.Size(95, 17);
            this.chkMTN_v_Verbose.TabIndex = 44;
            this.chkMTN_v_Verbose.Text = "&Verbose Mode";
            this.chkMTN_v_Verbose.UseVisualStyleBackColor = true;
            // 
            // txtMTN_o_OutputSuffix
            // 
            this.txtMTN_o_OutputSuffix.Location = new System.Drawing.Point(444, 194);
            this.txtMTN_o_OutputSuffix.Name = "txtMTN_o_OutputSuffix";
            this.txtMTN_o_OutputSuffix.Size = new System.Drawing.Size(232, 20);
            this.txtMTN_o_OutputSuffix.TabIndex = 43;
            this.txtMTN_o_OutputSuffix.TextChanged += new System.EventHandler(this.txtMTN_o_OutputSuffix_TextChanged);
            // 
            // chkMTN_o_OutputSuffix
            // 
            this.chkMTN_o_OutputSuffix.AutoSize = true;
            this.chkMTN_o_OutputSuffix.Checked = true;
            this.chkMTN_o_OutputSuffix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMTN_o_OutputSuffix.Location = new System.Drawing.Point(350, 196);
            this.chkMTN_o_OutputSuffix.Name = "chkMTN_o_OutputSuffix";
            this.chkMTN_o_OutputSuffix.Size = new System.Drawing.Size(87, 17);
            this.chkMTN_o_OutputSuffix.TabIndex = 42;
            this.chkMTN_o_OutputSuffix.Text = "Output Suffix";
            this.chkMTN_o_OutputSuffix.UseVisualStyleBackColor = true;
            this.chkMTN_o_OutputSuffix.CheckedChanged += new System.EventHandler(this.chkMTN_o_OutputSuffix_CheckedChanged);
            // 
            // txtMTN_N_InfoSuffix
            // 
            this.txtMTN_N_InfoSuffix.Location = new System.Drawing.Point(444, 167);
            this.txtMTN_N_InfoSuffix.Name = "txtMTN_N_InfoSuffix";
            this.txtMTN_N_InfoSuffix.Size = new System.Drawing.Size(232, 20);
            this.txtMTN_N_InfoSuffix.TabIndex = 41;
            this.txtMTN_N_InfoSuffix.TextChanged += new System.EventHandler(this.txtMTN_N_InfoSuffix_TextChanged);
            // 
            // chkMTN_N_WriteInfo
            // 
            this.chkMTN_N_WriteInfo.AutoSize = true;
            this.chkMTN_N_WriteInfo.Location = new System.Drawing.Point(350, 170);
            this.chkMTN_N_WriteInfo.Name = "chkMTN_N_WriteInfo";
            this.chkMTN_N_WriteInfo.Size = new System.Drawing.Size(73, 17);
            this.chkMTN_N_WriteInfo.TabIndex = 40;
            this.chkMTN_N_WriteInfo.Text = "&Info Suffix";
            this.chkMTN_N_WriteInfo.UseVisualStyleBackColor = true;
            this.chkMTN_N_WriteInfo.CheckedChanged += new System.EventHandler(this.chkMTN_N_WriteInfo_CheckedChanged);
            // 
            // chkMTN_z_SeekMode
            // 
            this.chkMTN_z_SeekMode.AutoSize = true;
            this.chkMTN_z_SeekMode.Checked = true;
            this.chkMTN_z_SeekMode.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkMTN_z_SeekMode.Location = new System.Drawing.Point(720, 344);
            this.chkMTN_z_SeekMode.Name = "chkMTN_z_SeekMode";
            this.chkMTN_z_SeekMode.Size = new System.Drawing.Size(81, 17);
            this.chkMTN_z_SeekMode.TabIndex = 10;
            this.chkMTN_z_SeekMode.Text = "&Seek Mode";
            this.chkMTN_z_SeekMode.ThreeState = true;
            this.chkMTN_z_SeekMode.UseVisualStyleBackColor = true;
            this.chkMTN_z_SeekMode.Visible = false;
            // 
            // chkMTN_i_MediaInfoTurnOff
            // 
            this.chkMTN_i_MediaInfoTurnOff.AutoSize = true;
            this.chkMTN_i_MediaInfoTurnOff.Location = new System.Drawing.Point(350, 18);
            this.chkMTN_i_MediaInfoTurnOff.Name = "chkMTN_i_MediaInfoTurnOff";
            this.chkMTN_i_MediaInfoTurnOff.Size = new System.Drawing.Size(116, 17);
            this.chkMTN_i_MediaInfoTurnOff.TabIndex = 37;
            this.chkMTN_i_MediaInfoTurnOff.Text = "Turn off Media Info";
            this.chkMTN_i_MediaInfoTurnOff.UseVisualStyleBackColor = false;
            this.chkMTN_i_MediaInfoTurnOff.CheckedChanged += new System.EventHandler(this.chkMTN_i_MediaInfo_CheckedChanged);
            // 
            // gbMTN_i_MediaInfo
            // 
            this.gbMTN_i_MediaInfo.Controls.Add(this.chkMTN_T_Title);
            this.gbMTN_i_MediaInfo.Controls.Add(this.cboMTN_f_FontType);
            this.gbMTN_i_MediaInfo.Controls.Add(this.txtMTN_T_Title);
            this.gbMTN_i_MediaInfo.Controls.Add(this.chkMTN_f_Font);
            this.gbMTN_i_MediaInfo.Controls.Add(this.chkMTN_F_FontColor);
            this.gbMTN_i_MediaInfo.Controls.Add(this.cboMTN_F_FontColor);
            this.gbMTN_i_MediaInfo.Controls.Add(this.chkMTN_F_FontSize);
            this.gbMTN_i_MediaInfo.Controls.Add(this.nudMTN_F_FontSize);
            this.gbMTN_i_MediaInfo.Controls.Add(this.chkMTN_L_LocInfo);
            this.gbMTN_i_MediaInfo.Controls.Add(this.cboMTN_L_LocInfo);
            this.gbMTN_i_MediaInfo.Location = new System.Drawing.Point(338, 41);
            this.gbMTN_i_MediaInfo.Name = "gbMTN_i_MediaInfo";
            this.gbMTN_i_MediaInfo.Size = new System.Drawing.Size(364, 122);
            this.gbMTN_i_MediaInfo.TabIndex = 39;
            this.gbMTN_i_MediaInfo.TabStop = false;
            this.gbMTN_i_MediaInfo.Text = "Media Info";
            // 
            // chkMTN_T_Title
            // 
            this.chkMTN_T_Title.AutoSize = true;
            this.chkMTN_T_Title.Location = new System.Drawing.Point(12, 18);
            this.chkMTN_T_Title.Name = "chkMTN_T_Title";
            this.chkMTN_T_Title.Size = new System.Drawing.Size(46, 17);
            this.chkMTN_T_Title.TabIndex = 46;
            this.chkMTN_T_Title.Text = "&Title";
            this.chkMTN_T_Title.UseVisualStyleBackColor = true;
            this.chkMTN_T_Title.CheckedChanged += new System.EventHandler(this.chkMTN_T_Title_CheckedChanged);
            // 
            // cboMTN_f_FontType
            // 
            this.cboMTN_f_FontType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMTN_f_FontType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.cboMTN_f_FontType.FormattingEnabled = true;
            this.cboMTN_f_FontType.Location = new System.Drawing.Point(106, 41);
            this.cboMTN_f_FontType.Name = "cboMTN_f_FontType";
            this.cboMTN_f_FontType.Size = new System.Drawing.Size(232, 21);
            this.cboMTN_f_FontType.TabIndex = 12;
            this.ttApp.SetToolTip(this.cboMTN_f_FontType, "tahomabd.ttf : font file; use absolute path if not in usual places");
            this.cboMTN_f_FontType.SelectedIndexChanged += new System.EventHandler(this.cboMTN_f_FontType_SelectedIndexChanged);
            // 
            // txtMTN_T_Title
            // 
            this.txtMTN_T_Title.Location = new System.Drawing.Point(106, 16);
            this.txtMTN_T_Title.Name = "txtMTN_T_Title";
            this.txtMTN_T_Title.Size = new System.Drawing.Size(232, 20);
            this.txtMTN_T_Title.TabIndex = 45;
            this.txtMTN_T_Title.Text = "%Title%";
            this.txtMTN_T_Title.TextChanged += new System.EventHandler(this.txtMTN_T_Title_TextChanged);
            // 
            // chkMTN_f_Font
            // 
            this.chkMTN_f_Font.AutoSize = true;
            this.chkMTN_f_Font.Checked = true;
            this.chkMTN_f_Font.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMTN_f_Font.Location = new System.Drawing.Point(12, 43);
            this.chkMTN_f_Font.Name = "chkMTN_f_Font";
            this.chkMTN_f_Font.Size = new System.Drawing.Size(78, 17);
            this.chkMTN_f_Font.TabIndex = 13;
            this.chkMTN_f_Font.Text = "&Font Name";
            this.chkMTN_f_Font.UseVisualStyleBackColor = true;
            this.chkMTN_f_Font.CheckedChanged += new System.EventHandler(this.chkMTN_f_Font_CheckedChanged);
            // 
            // chkMTN_F_FontColor
            // 
            this.chkMTN_F_FontColor.AutoSize = true;
            this.chkMTN_F_FontColor.Checked = true;
            this.chkMTN_F_FontColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMTN_F_FontColor.Location = new System.Drawing.Point(12, 69);
            this.chkMTN_F_FontColor.Name = "chkMTN_F_FontColor";
            this.chkMTN_F_FontColor.Size = new System.Drawing.Size(74, 17);
            this.chkMTN_F_FontColor.TabIndex = 24;
            this.chkMTN_F_FontColor.Text = "&Font Color";
            this.ttApp.SetToolTip(this.chkMTN_F_FontColor, "-F RRGGBB:size");
            this.chkMTN_F_FontColor.UseVisualStyleBackColor = true;
            this.chkMTN_F_FontColor.CheckedChanged += new System.EventHandler(this.chkMTN_F_FontColor_CheckedChanged);
            // 
            // cboMTN_F_FontColor
            // 
            this.cboMTN_F_FontColor.FormattingEnabled = true;
            this.cboMTN_F_FontColor.Location = new System.Drawing.Point(106, 67);
            this.cboMTN_F_FontColor.MaxLength = 6;
            this.cboMTN_F_FontColor.Name = "cboMTN_F_FontColor";
            this.cboMTN_F_FontColor.Size = new System.Drawing.Size(120, 21);
            this.cboMTN_F_FontColor.TabIndex = 27;
            this.cboMTN_F_FontColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cboMTN_F_FontColor_MouseClick);
            this.cboMTN_F_FontColor.SelectedIndexChanged += new System.EventHandler(this.cboMTN_F_FontColor_SelectedIndexChanged);
            // 
            // chkMTN_F_FontSize
            // 
            this.chkMTN_F_FontSize.AutoSize = true;
            this.chkMTN_F_FontSize.Checked = true;
            this.chkMTN_F_FontSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMTN_F_FontSize.Location = new System.Drawing.Point(234, 69);
            this.chkMTN_F_FontSize.Name = "chkMTN_F_FontSize";
            this.chkMTN_F_FontSize.Size = new System.Drawing.Size(46, 17);
            this.chkMTN_F_FontSize.TabIndex = 33;
            this.chkMTN_F_FontSize.Text = "Size";
            this.ttApp.SetToolTip(this.chkMTN_F_FontSize, "-F RRGGBB:size");
            this.chkMTN_F_FontSize.UseVisualStyleBackColor = true;
            this.chkMTN_F_FontSize.CheckedChanged += new System.EventHandler(this.chkMTN_F_FontSize_CheckedChanged);
            // 
            // nudMTN_F_FontSize
            // 
            this.nudMTN_F_FontSize.Location = new System.Drawing.Point(286, 68);
            this.nudMTN_F_FontSize.Name = "nudMTN_F_FontSize";
            this.nudMTN_F_FontSize.Size = new System.Drawing.Size(52, 20);
            this.nudMTN_F_FontSize.TabIndex = 34;
            this.nudMTN_F_FontSize.ValueChanged += new System.EventHandler(this.nudMTN_F_FontSize_ValueChanged);
            // 
            // chkMTN_L_LocInfo
            // 
            this.chkMTN_L_LocInfo.AutoSize = true;
            this.chkMTN_L_LocInfo.Checked = true;
            this.chkMTN_L_LocInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMTN_L_LocInfo.Location = new System.Drawing.Point(12, 94);
            this.chkMTN_L_LocInfo.Name = "chkMTN_L_LocInfo";
            this.chkMTN_L_LocInfo.Size = new System.Drawing.Size(67, 17);
            this.chkMTN_L_LocInfo.TabIndex = 29;
            this.chkMTN_L_LocInfo.Text = "Location";
            this.chkMTN_L_LocInfo.UseVisualStyleBackColor = true;
            this.chkMTN_L_LocInfo.CheckedChanged += new System.EventHandler(this.chkMTN_L_LocInfo_CheckedChanged);
            // 
            // cboMTN_L_LocInfo
            // 
            this.cboMTN_L_LocInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMTN_L_LocInfo.FormattingEnabled = true;
            this.cboMTN_L_LocInfo.Items.AddRange(new object[] {
            "Lower Left",
            "Lower Right",
            "Upper Right",
            "Upper Left"});
            this.cboMTN_L_LocInfo.Location = new System.Drawing.Point(106, 92);
            this.cboMTN_L_LocInfo.MaxLength = 6;
            this.cboMTN_L_LocInfo.Name = "cboMTN_L_LocInfo";
            this.cboMTN_L_LocInfo.Size = new System.Drawing.Size(232, 21);
            this.cboMTN_L_LocInfo.TabIndex = 30;
            this.cboMTN_L_LocInfo.SelectedIndexChanged += new System.EventHandler(this.cboMTN_L_LocInfo_SelectedIndexChanged);
            // 
            // nudMTN_j_JPEGQuality
            // 
            this.nudMTN_j_JPEGQuality.Location = new System.Drawing.Point(172, 188);
            this.nudMTN_j_JPEGQuality.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudMTN_j_JPEGQuality.Name = "nudMTN_j_JPEGQuality";
            this.nudMTN_j_JPEGQuality.Size = new System.Drawing.Size(120, 20);
            this.nudMTN_j_JPEGQuality.TabIndex = 36;
            this.nudMTN_j_JPEGQuality.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudMTN_j_JPEGQuality.ValueChanged += new System.EventHandler(this.nudMTN_j_JPEGQuality_ValueChanged);
            // 
            // chkMTN_j_JPEGQuality
            // 
            this.chkMTN_j_JPEGQuality.AutoSize = true;
            this.chkMTN_j_JPEGQuality.Checked = true;
            this.chkMTN_j_JPEGQuality.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMTN_j_JPEGQuality.Location = new System.Drawing.Point(22, 190);
            this.chkMTN_j_JPEGQuality.Name = "chkMTN_j_JPEGQuality";
            this.chkMTN_j_JPEGQuality.Size = new System.Drawing.Size(105, 17);
            this.chkMTN_j_JPEGQuality.TabIndex = 35;
            this.chkMTN_j_JPEGQuality.Text = "JPEG Quality (%)";
            this.chkMTN_j_JPEGQuality.UseVisualStyleBackColor = true;
            // 
            // cboMTN_L_LocTimestamp
            // 
            this.cboMTN_L_LocTimestamp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMTN_L_LocTimestamp.FormattingEnabled = true;
            this.cboMTN_L_LocTimestamp.Items.AddRange(new object[] {
            "Lower Left",
            "Lower Right",
            "Upper Right",
            "Upper Left"});
            this.cboMTN_L_LocTimestamp.Location = new System.Drawing.Point(556, 16);
            this.cboMTN_L_LocTimestamp.MaxLength = 6;
            this.cboMTN_L_LocTimestamp.Name = "cboMTN_L_LocTimestamp";
            this.cboMTN_L_LocTimestamp.Size = new System.Drawing.Size(120, 21);
            this.cboMTN_L_LocTimestamp.TabIndex = 32;
            this.cboMTN_L_LocTimestamp.SelectedIndexChanged += new System.EventHandler(this.cboMTN_L_LocTimestamp_SelectedIndexChanged);
            // 
            // chkMTN_tL_LocTimestamp
            // 
            this.chkMTN_tL_LocTimestamp.AutoSize = true;
            this.chkMTN_tL_LocTimestamp.Checked = true;
            this.chkMTN_tL_LocTimestamp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMTN_tL_LocTimestamp.Location = new System.Drawing.Point(472, 18);
            this.chkMTN_tL_LocTimestamp.Name = "chkMTN_tL_LocTimestamp";
            this.chkMTN_tL_LocTimestamp.Size = new System.Drawing.Size(77, 17);
            this.chkMTN_tL_LocTimestamp.TabIndex = 31;
            this.chkMTN_tL_LocTimestamp.Text = "Timestamp";
            this.chkMTN_tL_LocTimestamp.UseVisualStyleBackColor = true;
            this.chkMTN_tL_LocTimestamp.CheckedChanged += new System.EventHandler(this.chkMTN_tL_LocTimestamp_CheckedChanged);
            // 
            // chkMTN_k_ColorBackground
            // 
            this.chkMTN_k_ColorBackground.AutoSize = true;
            this.chkMTN_k_ColorBackground.Checked = true;
            this.chkMTN_k_ColorBackground.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMTN_k_ColorBackground.Location = new System.Drawing.Point(22, 140);
            this.chkMTN_k_ColorBackground.Name = "chkMTN_k_ColorBackground";
            this.chkMTN_k_ColorBackground.Size = new System.Drawing.Size(111, 17);
            this.chkMTN_k_ColorBackground.TabIndex = 28;
            this.chkMTN_k_ColorBackground.Text = "&Background Color";
            this.ttApp.SetToolTip(this.chkMTN_k_ColorBackground, "  -k RRGGBB : background color (in hex)");
            this.chkMTN_k_ColorBackground.UseVisualStyleBackColor = true;
            // 
            // nudMTN_g_Gap
            // 
            this.nudMTN_g_Gap.Location = new System.Drawing.Point(172, 112);
            this.nudMTN_g_Gap.Name = "nudMTN_g_Gap";
            this.nudMTN_g_Gap.Size = new System.Drawing.Size(120, 20);
            this.nudMTN_g_Gap.TabIndex = 26;
            this.nudMTN_g_Gap.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudMTN_g_Gap.ValueChanged += new System.EventHandler(this.nudMTN_g_Gap_ValueChanged);
            // 
            // chkMTN_g_Gap
            // 
            this.chkMTN_g_Gap.AutoSize = true;
            this.chkMTN_g_Gap.Checked = true;
            this.chkMTN_g_Gap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMTN_g_Gap.Location = new System.Drawing.Point(22, 115);
            this.chkMTN_g_Gap.Name = "chkMTN_g_Gap";
            this.chkMTN_g_Gap.Size = new System.Drawing.Size(120, 17);
            this.chkMTN_g_Gap.TabIndex = 25;
            this.chkMTN_g_Gap.Text = "Gap between Shots";
            this.chkMTN_g_Gap.UseVisualStyleBackColor = true;
            // 
            // cboMTN_k_ColorBkgrd
            // 
            this.cboMTN_k_ColorBkgrd.FormattingEnabled = true;
            this.cboMTN_k_ColorBkgrd.Location = new System.Drawing.Point(172, 137);
            this.cboMTN_k_ColorBkgrd.MaxLength = 6;
            this.cboMTN_k_ColorBkgrd.Name = "cboMTN_k_ColorBkgrd";
            this.cboMTN_k_ColorBkgrd.Size = new System.Drawing.Size(120, 21);
            this.cboMTN_k_ColorBkgrd.TabIndex = 23;
            this.cboMTN_k_ColorBkgrd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cboMTN_k_ColorBkgrd_MouseClick);
            this.cboMTN_k_ColorBkgrd.SelectedIndexChanged += new System.EventHandler(this.cboMTN_k_ColorBkgrd_SelectedIndexChanged);
            // 
            // nudMTN_w_Width
            // 
            this.nudMTN_w_Width.Location = new System.Drawing.Point(172, 87);
            this.nudMTN_w_Width.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nudMTN_w_Width.Name = "nudMTN_w_Width";
            this.nudMTN_w_Width.Size = new System.Drawing.Size(120, 20);
            this.nudMTN_w_Width.TabIndex = 22;
            this.ttApp.SetToolTip(this.nudMTN_w_Width, "Keep 0 for Exact Dimensions");
            this.nudMTN_w_Width.ValueChanged += new System.EventHandler(this.nudMTN_w_Width_ValueChanged);
            // 
            // chkMTN_w_Width
            // 
            this.chkMTN_w_Width.AutoSize = true;
            this.chkMTN_w_Width.Checked = true;
            this.chkMTN_w_Width.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMTN_w_Width.Location = new System.Drawing.Point(22, 90);
            this.chkMTN_w_Width.Name = "chkMTN_w_Width";
            this.chkMTN_w_Width.Size = new System.Drawing.Size(54, 17);
            this.chkMTN_w_Width.TabIndex = 21;
            this.chkMTN_w_Width.Text = "Width";
            this.chkMTN_w_Width.UseVisualStyleBackColor = true;
            // 
            // chkMTN_P_QuitAfterDone
            // 
            this.chkMTN_P_QuitAfterDone.AutoSize = true;
            this.chkMTN_P_QuitAfterDone.Checked = true;
            this.chkMTN_P_QuitAfterDone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMTN_P_QuitAfterDone.Location = new System.Drawing.Point(22, 347);
            this.chkMTN_P_QuitAfterDone.Name = "chkMTN_P_QuitAfterDone";
            this.chkMTN_P_QuitAfterDone.Size = new System.Drawing.Size(96, 17);
            this.chkMTN_P_QuitAfterDone.TabIndex = 20;
            this.chkMTN_P_QuitAfterDone.Text = "&Quit after done";
            this.chkMTN_P_QuitAfterDone.UseVisualStyleBackColor = true;
            this.chkMTN_P_QuitAfterDone.CheckedChanged += new System.EventHandler(this.chkMTN_P_QuitAfterDone_CheckedChanged);
            // 
            // nudMTN_s_TimeStep
            // 
            this.nudMTN_s_TimeStep.Location = new System.Drawing.Point(172, 163);
            this.nudMTN_s_TimeStep.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMTN_s_TimeStep.Name = "nudMTN_s_TimeStep";
            this.nudMTN_s_TimeStep.Size = new System.Drawing.Size(120, 20);
            this.nudMTN_s_TimeStep.TabIndex = 19;
            this.nudMTN_s_TimeStep.ValueChanged += new System.EventHandler(this.nudMTN_s_TimeStep_ValueChanged);
            // 
            // chkMTN_s_TimeStep
            // 
            this.chkMTN_s_TimeStep.AutoSize = true;
            this.chkMTN_s_TimeStep.Location = new System.Drawing.Point(22, 165);
            this.chkMTN_s_TimeStep.Name = "chkMTN_s_TimeStep";
            this.chkMTN_s_TimeStep.Size = new System.Drawing.Size(123, 17);
            this.chkMTN_s_TimeStep.TabIndex = 18;
            this.chkMTN_s_TimeStep.Text = "Time Step (seconds)";
            this.chkMTN_s_TimeStep.UseVisualStyleBackColor = true;
            // 
            // nudMTN_r_Rows
            // 
            this.nudMTN_r_Rows.Location = new System.Drawing.Point(172, 12);
            this.nudMTN_r_Rows.Name = "nudMTN_r_Rows";
            this.nudMTN_r_Rows.Size = new System.Drawing.Size(120, 20);
            this.nudMTN_r_Rows.TabIndex = 17;
            this.nudMTN_r_Rows.ValueChanged += new System.EventHandler(this.nudMTN_r_Rows_ValueChanged);
            // 
            // chkShowMTN
            // 
            this.chkShowMTN.AutoSize = true;
            this.chkShowMTN.Location = new System.Drawing.Point(22, 324);
            this.chkShowMTN.Name = "chkShowMTN";
            this.chkShowMTN.Size = new System.Drawing.Size(122, 17);
            this.chkShowMTN.TabIndex = 11;
            this.chkShowMTN.Text = "Show &MTN Window";
            this.ttApp.SetToolTip(this.chkShowMTN, "Show MTN Window for Debugging purposes. Need to uncheck \"Quit after done\" if you " +
                    "need to keep the Window open as long as you like.");
            this.chkShowMTN.UseVisualStyleBackColor = true;
            this.chkShowMTN.CheckedChanged += new System.EventHandler(this.chkShowMTN_CheckedChanged);
            // 
            // chkMTNRows
            // 
            this.chkMTNRows.AutoSize = true;
            this.chkMTNRows.Checked = true;
            this.chkMTNRows.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkMTNRows.Location = new System.Drawing.Point(22, 15);
            this.chkMTNRows.Name = "chkMTNRows";
            this.chkMTNRows.Size = new System.Drawing.Size(53, 17);
            this.chkMTNRows.TabIndex = 16;
            this.chkMTNRows.Text = "Rows";
            this.chkMTNRows.UseVisualStyleBackColor = true;
            this.chkMTNRows.CheckedChanged += new System.EventHandler(this.chkMTNRows_CheckedChanged);
            // 
            // nudMTN_c_Columns
            // 
            this.nudMTN_c_Columns.Location = new System.Drawing.Point(172, 37);
            this.nudMTN_c_Columns.Name = "nudMTN_c_Columns";
            this.nudMTN_c_Columns.Size = new System.Drawing.Size(120, 20);
            this.nudMTN_c_Columns.TabIndex = 15;
            this.nudMTN_c_Columns.ValueChanged += new System.EventHandler(this.nudMTN_c_Columns_ValueChanged);
            // 
            // chkMTNColumns
            // 
            this.chkMTNColumns.AutoSize = true;
            this.chkMTNColumns.Checked = true;
            this.chkMTNColumns.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkMTNColumns.Location = new System.Drawing.Point(22, 40);
            this.chkMTNColumns.Name = "chkMTNColumns";
            this.chkMTNColumns.Size = new System.Drawing.Size(66, 17);
            this.chkMTNColumns.TabIndex = 14;
            this.chkMTNColumns.Text = "Columns";
            this.chkMTNColumns.UseVisualStyleBackColor = true;
            this.chkMTNColumns.CheckedChanged += new System.EventHandler(this.chkMTNColumns_CheckedChanged);
            // 
            // tpUsage2
            // 
            this.tpUsage2.Controls.Add(this.pgMtn);
            this.tpUsage2.Location = new System.Drawing.Point(4, 22);
            this.tpUsage2.Name = "tpUsage2";
            this.tpUsage2.Padding = new System.Windows.Forms.Padding(3);
            this.tpUsage2.Size = new System.Drawing.Size(834, 387);
            this.tpUsage2.TabIndex = 2;
            this.tpUsage2.Text = "Usage (Advanced)";
            this.tpUsage2.UseVisualStyleBackColor = true;
            // 
            // pgMtn
            // 
            this.pgMtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgMtn.Location = new System.Drawing.Point(3, 3);
            this.pgMtn.Name = "pgMtn";
            this.pgMtn.Size = new System.Drawing.Size(828, 381);
            this.pgMtn.TabIndex = 0;
            // 
            // tpHostingImageShack
            // 
            this.tpHostingImageShack.Controls.Add(this.btnImageShackImages);
            this.tpHostingImageShack.Controls.Add(this.btnImageShackRegCode);
            this.tpHostingImageShack.Controls.Add(this.chkUseImageShackRegCode);
            this.tpHostingImageShack.Controls.Add(this.txtImageShackRegCode);
            this.tpHostingImageShack.Controls.Add(this.chkRandomizeFileNameImageShack);
            this.tpHostingImageShack.Location = new System.Drawing.Point(4, 22);
            this.tpHostingImageShack.Name = "tpHostingImageShack";
            this.tpHostingImageShack.Padding = new System.Windows.Forms.Padding(3);
            this.tpHostingImageShack.Size = new System.Drawing.Size(834, 387);
            this.tpHostingImageShack.TabIndex = 0;
            this.tpHostingImageShack.Text = "ImageShack";
            this.tpHostingImageShack.UseVisualStyleBackColor = true;
            // 
            // btnImageShackImages
            // 
            this.btnImageShackImages.Location = new System.Drawing.Point(540, 36);
            this.btnImageShackImages.Name = "btnImageShackImages";
            this.btnImageShackImages.Size = new System.Drawing.Size(75, 23);
            this.btnImageShackImages.TabIndex = 7;
            this.btnImageShackImages.Text = "MyImages";
            this.btnImageShackImages.UseVisualStyleBackColor = true;
            this.btnImageShackImages.Click += new System.EventHandler(this.btnImageShackImages_Click);
            // 
            // btnImageShackRegCode
            // 
            this.btnImageShackRegCode.Location = new System.Drawing.Point(459, 36);
            this.btnImageShackRegCode.Name = "btnImageShackRegCode";
            this.btnImageShackRegCode.Size = new System.Drawing.Size(75, 23);
            this.btnImageShackRegCode.TabIndex = 6;
            this.btnImageShackRegCode.Text = "RegCode";
            this.btnImageShackRegCode.UseVisualStyleBackColor = true;
            this.btnImageShackRegCode.Click += new System.EventHandler(this.btnImageShackRegCode_Click);
            // 
            // chkUseImageShackRegCode
            // 
            this.chkUseImageShackRegCode.AutoSize = true;
            this.chkUseImageShackRegCode.Location = new System.Drawing.Point(14, 41);
            this.chkUseImageShackRegCode.Name = "chkUseImageShackRegCode";
            this.chkUseImageShackRegCode.Size = new System.Drawing.Size(135, 17);
            this.chkUseImageShackRegCode.TabIndex = 5;
            this.chkUseImageShackRegCode.Text = "Use Registration Code:";
            this.chkUseImageShackRegCode.UseVisualStyleBackColor = true;
            this.chkUseImageShackRegCode.CheckedChanged += new System.EventHandler(this.chkUseImageShackRegCode_CheckedChanged);
            // 
            // txtImageShackRegCode
            // 
            this.txtImageShackRegCode.Location = new System.Drawing.Point(155, 38);
            this.txtImageShackRegCode.Name = "txtImageShackRegCode";
            this.txtImageShackRegCode.Size = new System.Drawing.Size(298, 20);
            this.txtImageShackRegCode.TabIndex = 4;
            // 
            // chkRandomizeFileNameImageShack
            // 
            this.chkRandomizeFileNameImageShack.AutoSize = true;
            this.chkRandomizeFileNameImageShack.Location = new System.Drawing.Point(14, 18);
            this.chkRandomizeFileNameImageShack.Name = "chkRandomizeFileNameImageShack";
            this.chkRandomizeFileNameImageShack.Size = new System.Drawing.Size(207, 17);
            this.chkRandomizeFileNameImageShack.TabIndex = 3;
            this.chkRandomizeFileNameImageShack.Text = "Randomize File Name for ImageShack";
            this.chkRandomizeFileNameImageShack.UseVisualStyleBackColor = true;
            this.chkRandomizeFileNameImageShack.CheckedChanged += new System.EventHandler(this.chkRandomizeFileNameImageShack_CheckedChanged);
            // 
            // tpTorrents
            // 
            this.tpTorrents.Controls.Add(this.btnRefreshTrackers);
            this.tpTorrents.Controls.Add(this.groupBox8);
            this.tpTorrents.Controls.Add(this.gbTrackerMgr);
            this.tpTorrents.Controls.Add(this.cboTrackerGroupActive);
            this.tpTorrents.Controls.Add(this.chkCreateTorrent);
            this.tpTorrents.Location = new System.Drawing.Point(4, 22);
            this.tpTorrents.Name = "tpTorrents";
            this.tpTorrents.Padding = new System.Windows.Forms.Padding(3);
            this.tpTorrents.Size = new System.Drawing.Size(848, 419);
            this.tpTorrents.TabIndex = 1;
            this.tpTorrents.Text = "Torrent Creator";
            this.tpTorrents.UseVisualStyleBackColor = true;
            // 
            // btnRefreshTrackers
            // 
            this.btnRefreshTrackers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshTrackers.Location = new System.Drawing.Point(745, 10);
            this.btnRefreshTrackers.Name = "btnRefreshTrackers";
            this.btnRefreshTrackers.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshTrackers.TabIndex = 5;
            this.btnRefreshTrackers.Text = "&Refresh";
            this.ttApp.SetToolTip(this.btnRefreshTrackers, "Refresh Trackers List from Tracker Manager");
            this.btnRefreshTrackers.UseVisualStyleBackColor = true;
            this.btnRefreshTrackers.Click += new System.EventHandler(this.btnRefreshTrackers_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.chkWritePublish);
            this.groupBox8.Controls.Add(this.chkTorrentOrganize);
            this.groupBox8.Controls.Add(this.btnBrowseTorrentCustomFolder);
            this.groupBox8.Controls.Add(this.txtTorrentCustomFolder);
            this.groupBox8.Controls.Add(this.rbTorrentFolderCustom);
            this.groupBox8.Controls.Add(this.rbTorrentDefaultFolder);
            this.groupBox8.Location = new System.Drawing.Point(17, 288);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(809, 122);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Save Location";
            // 
            // chkWritePublish
            // 
            this.chkWritePublish.AutoSize = true;
            this.chkWritePublish.Location = new System.Drawing.Point(19, 91);
            this.chkWritePublish.Name = "chkWritePublish";
            this.chkWritePublish.Size = new System.Drawing.Size(241, 17);
            this.chkWritePublish.TabIndex = 5;
            this.chkWritePublish.Text = "Write Publish Information of the Torrent to File";
            this.chkWritePublish.UseVisualStyleBackColor = true;
            this.chkWritePublish.CheckedChanged += new System.EventHandler(this.chkWritePublish_CheckedChanged);
            // 
            // chkTorrentOrganize
            // 
            this.chkTorrentOrganize.AutoSize = true;
            this.chkTorrentOrganize.Checked = true;
            this.chkTorrentOrganize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTorrentOrganize.Location = new System.Drawing.Point(114, 67);
            this.chkTorrentOrganize.Name = "chkTorrentOrganize";
            this.chkTorrentOrganize.Size = new System.Drawing.Size(293, 17);
            this.chkTorrentOrganize.TabIndex = 4;
            this.chkTorrentOrganize.Text = "Create torrents in sub-folders according to Tracker Name";
            this.chkTorrentOrganize.UseVisualStyleBackColor = true;
            this.chkTorrentOrganize.CheckedChanged += new System.EventHandler(this.chkTorrentOrganize_CheckedChanged);
            // 
            // btnBrowseTorrentCustomFolder
            // 
            this.btnBrowseTorrentCustomFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseTorrentCustomFolder.Location = new System.Drawing.Point(704, 39);
            this.btnBrowseTorrentCustomFolder.Name = "btnBrowseTorrentCustomFolder";
            this.btnBrowseTorrentCustomFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseTorrentCustomFolder.TabIndex = 3;
            this.btnBrowseTorrentCustomFolder.Text = "&Browse";
            this.btnBrowseTorrentCustomFolder.UseVisualStyleBackColor = true;
            this.btnBrowseTorrentCustomFolder.Click += new System.EventHandler(this.btnBrowseTorrentCustomFolder_Click);
            // 
            // txtTorrentCustomFolder
            // 
            this.txtTorrentCustomFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTorrentCustomFolder.Location = new System.Drawing.Point(114, 41);
            this.txtTorrentCustomFolder.Name = "txtTorrentCustomFolder";
            this.txtTorrentCustomFolder.Size = new System.Drawing.Size(584, 20);
            this.txtTorrentCustomFolder.TabIndex = 2;
            this.txtTorrentCustomFolder.TextChanged += new System.EventHandler(this.txtTorrentCustomFolder_TextChanged);
            // 
            // rbTorrentFolderCustom
            // 
            this.rbTorrentFolderCustom.AutoSize = true;
            this.rbTorrentFolderCustom.Location = new System.Drawing.Point(19, 42);
            this.rbTorrentFolderCustom.Name = "rbTorrentFolderCustom";
            this.rbTorrentFolderCustom.Size = new System.Drawing.Size(89, 17);
            this.rbTorrentFolderCustom.TabIndex = 1;
            this.rbTorrentFolderCustom.Text = "Custom folder";
            this.rbTorrentFolderCustom.UseVisualStyleBackColor = true;
            this.rbTorrentFolderCustom.CheckedChanged += new System.EventHandler(this.rbTorrentFolderCustom_CheckedChanged);
            // 
            // rbTorrentDefaultFolder
            // 
            this.rbTorrentDefaultFolder.AutoSize = true;
            this.rbTorrentDefaultFolder.Location = new System.Drawing.Point(19, 19);
            this.rbTorrentDefaultFolder.Name = "rbTorrentDefaultFolder";
            this.rbTorrentDefaultFolder.Size = new System.Drawing.Size(147, 17);
            this.rbTorrentDefaultFolder.TabIndex = 0;
            this.rbTorrentDefaultFolder.TabStop = true;
            this.rbTorrentDefaultFolder.Text = "Parent folder of the Media";
            this.rbTorrentDefaultFolder.UseVisualStyleBackColor = true;
            this.rbTorrentDefaultFolder.CheckedChanged += new System.EventHandler(this.rbTorrentDefaultFolder_CheckedChanged);
            // 
            // gbTrackerMgr
            // 
            this.gbTrackerMgr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTrackerMgr.Controls.Add(this.tlpTrackers);
            this.gbTrackerMgr.Location = new System.Drawing.Point(17, 40);
            this.gbTrackerMgr.Name = "gbTrackerMgr";
            this.gbTrackerMgr.Size = new System.Drawing.Size(809, 240);
            this.gbTrackerMgr.TabIndex = 3;
            this.gbTrackerMgr.TabStop = false;
            this.gbTrackerMgr.Text = "Tracker Manager";
            // 
            // tlpTrackers
            // 
            this.tlpTrackers.ColumnCount = 3;
            this.tlpTrackers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTrackers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTrackers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTrackers.Controls.Add(this.flpTrackers, 1, 1);
            this.tlpTrackers.Controls.Add(this.pgTracker, 2, 0);
            this.tlpTrackers.Controls.Add(this.flpTrackerGroups, 0, 1);
            this.tlpTrackers.Controls.Add(this.gbTrackerGroups, 0, 0);
            this.tlpTrackers.Controls.Add(this.gbTrackers, 1, 0);
            this.tlpTrackers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTrackers.Location = new System.Drawing.Point(3, 16);
            this.tlpTrackers.Name = "tlpTrackers";
            this.tlpTrackers.RowCount = 2;
            this.tlpTrackers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTrackers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpTrackers.Size = new System.Drawing.Size(803, 221);
            this.tlpTrackers.TabIndex = 0;
            // 
            // flpTrackers
            // 
            this.flpTrackers.Controls.Add(this.btnAddTracker);
            this.flpTrackers.Controls.Add(this.btnRemoveTracker);
            this.flpTrackers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTrackers.Location = new System.Drawing.Point(203, 188);
            this.flpTrackers.Name = "flpTrackers";
            this.flpTrackers.Size = new System.Drawing.Size(194, 30);
            this.flpTrackers.TabIndex = 4;
            // 
            // btnAddTracker
            // 
            this.btnAddTracker.Location = new System.Drawing.Point(3, 3);
            this.btnAddTracker.Name = "btnAddTracker";
            this.btnAddTracker.Size = new System.Drawing.Size(75, 23);
            this.btnAddTracker.TabIndex = 0;
            this.btnAddTracker.Text = "Add";
            this.btnAddTracker.UseVisualStyleBackColor = true;
            this.btnAddTracker.Click += new System.EventHandler(this.BtnAddTrackerClick);
            // 
            // btnRemoveTracker
            // 
            this.btnRemoveTracker.Location = new System.Drawing.Point(84, 3);
            this.btnRemoveTracker.Name = "btnRemoveTracker";
            this.btnRemoveTracker.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveTracker.TabIndex = 1;
            this.btnRemoveTracker.Text = "Remove";
            this.btnRemoveTracker.UseVisualStyleBackColor = true;
            this.btnRemoveTracker.Click += new System.EventHandler(this.btnRemoveTracker_Click);
            // 
            // pgTracker
            // 
            this.pgTracker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgTracker.Location = new System.Drawing.Point(403, 3);
            this.pgTracker.Name = "pgTracker";
            this.pgTracker.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.pgTracker.Size = new System.Drawing.Size(397, 179);
            this.pgTracker.TabIndex = 1;
            this.pgTracker.ToolbarVisible = false;
            this.pgTracker.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PgTrackerPropertyValueChanged);
            // 
            // flpTrackerGroups
            // 
            this.flpTrackerGroups.Controls.Add(this.btnAddTrackerGroup);
            this.flpTrackerGroups.Controls.Add(this.btnRemoveTrackerGroup);
            this.flpTrackerGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTrackerGroups.Location = new System.Drawing.Point(3, 188);
            this.flpTrackerGroups.Name = "flpTrackerGroups";
            this.flpTrackerGroups.Size = new System.Drawing.Size(194, 30);
            this.flpTrackerGroups.TabIndex = 3;
            // 
            // btnAddTrackerGroup
            // 
            this.btnAddTrackerGroup.Location = new System.Drawing.Point(3, 3);
            this.btnAddTrackerGroup.Name = "btnAddTrackerGroup";
            this.btnAddTrackerGroup.Size = new System.Drawing.Size(75, 23);
            this.btnAddTrackerGroup.TabIndex = 0;
            this.btnAddTrackerGroup.Text = "Add";
            this.btnAddTrackerGroup.UseVisualStyleBackColor = true;
            this.btnAddTrackerGroup.Click += new System.EventHandler(this.btnAddTrackerGroup_Click);
            // 
            // btnRemoveTrackerGroup
            // 
            this.btnRemoveTrackerGroup.Location = new System.Drawing.Point(84, 3);
            this.btnRemoveTrackerGroup.Name = "btnRemoveTrackerGroup";
            this.btnRemoveTrackerGroup.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveTrackerGroup.TabIndex = 1;
            this.btnRemoveTrackerGroup.Text = "Remove";
            this.btnRemoveTrackerGroup.UseVisualStyleBackColor = true;
            this.btnRemoveTrackerGroup.Click += new System.EventHandler(this.btnRemoveTrackerGroup_Click);
            // 
            // gbTrackerGroups
            // 
            this.gbTrackerGroups.Controls.Add(this.lbTrackerGroups);
            this.gbTrackerGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTrackerGroups.Location = new System.Drawing.Point(3, 3);
            this.gbTrackerGroups.Name = "gbTrackerGroups";
            this.gbTrackerGroups.Size = new System.Drawing.Size(194, 179);
            this.gbTrackerGroups.TabIndex = 5;
            this.gbTrackerGroups.TabStop = false;
            this.gbTrackerGroups.Text = "Groups";
            // 
            // lbTrackerGroups
            // 
            this.lbTrackerGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTrackerGroups.FormattingEnabled = true;
            this.lbTrackerGroups.Location = new System.Drawing.Point(3, 16);
            this.lbTrackerGroups.Name = "lbTrackerGroups";
            this.lbTrackerGroups.Size = new System.Drawing.Size(188, 160);
            this.lbTrackerGroups.TabIndex = 2;
            this.lbTrackerGroups.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbTrackerGroups_MouseDoubleClick);
            this.lbTrackerGroups.SelectedIndexChanged += new System.EventHandler(this.lbTrackerGroups_SelectedIndexChanged);
            // 
            // gbTrackers
            // 
            this.gbTrackers.Controls.Add(this.lbTrackers);
            this.gbTrackers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTrackers.Location = new System.Drawing.Point(203, 3);
            this.gbTrackers.Name = "gbTrackers";
            this.gbTrackers.Size = new System.Drawing.Size(194, 179);
            this.gbTrackers.TabIndex = 6;
            this.gbTrackers.TabStop = false;
            this.gbTrackers.Text = "Trackers";
            // 
            // lbTrackers
            // 
            this.lbTrackers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTrackers.FormattingEnabled = true;
            this.lbTrackers.Location = new System.Drawing.Point(3, 16);
            this.lbTrackers.Name = "lbTrackers";
            this.lbTrackers.Size = new System.Drawing.Size(188, 160);
            this.lbTrackers.TabIndex = 0;
            this.lbTrackers.SelectedIndexChanged += new System.EventHandler(this.lbTrackers_SelectedIndexChanged);
            // 
            // cboTrackerGroupActive
            // 
            this.cboTrackerGroupActive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTrackerGroupActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrackerGroupActive.FormattingEnabled = true;
            this.cboTrackerGroupActive.Location = new System.Drawing.Point(209, 12);
            this.cboTrackerGroupActive.Name = "cboTrackerGroupActive";
            this.cboTrackerGroupActive.Size = new System.Drawing.Size(530, 21);
            this.cboTrackerGroupActive.TabIndex = 2;
            this.cboTrackerGroupActive.SelectedIndexChanged += new System.EventHandler(this.cboAnnounceURL_SelectedIndexChanged);
            // 
            // chkCreateTorrent
            // 
            this.chkCreateTorrent.AutoSize = true;
            this.chkCreateTorrent.Location = new System.Drawing.Point(17, 14);
            this.chkCreateTorrent.Name = "chkCreateTorrent";
            this.chkCreateTorrent.Size = new System.Drawing.Size(182, 17);
            this.chkCreateTorrent.TabIndex = 0;
            this.chkCreateTorrent.Text = "Automatically create &torrent using";
            this.chkCreateTorrent.UseVisualStyleBackColor = true;
            this.chkCreateTorrent.CheckedChanged += new System.EventHandler(this.chkCreateTorrent_CheckedChanged);
            // 
            // tpAdvanced
            // 
            this.tpAdvanced.Controls.Add(this.pgApp);
            this.tpAdvanced.Location = new System.Drawing.Point(4, 22);
            this.tpAdvanced.Name = "tpAdvanced";
            this.tpAdvanced.Padding = new System.Windows.Forms.Padding(3);
            this.tpAdvanced.Size = new System.Drawing.Size(848, 419);
            this.tpAdvanced.TabIndex = 3;
            this.tpAdvanced.Text = "Advanced";
            this.tpAdvanced.UseVisualStyleBackColor = true;
            // 
            // pgApp
            // 
            this.pgApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgApp.Location = new System.Drawing.Point(3, 3);
            this.pgApp.Name = "pgApp";
            this.pgApp.Size = new System.Drawing.Size(842, 413);
            this.pgApp.TabIndex = 0;
            this.pgApp.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgApp_PropertyValueChanged);
            // 
            // tmrStatus
            // 
            this.tmrStatus.Enabled = true;
            this.tmrStatus.Interval = 1000;
            this.tmrStatus.Tick += new System.EventHandler(this.tmrStatus_Tick);
            // 
            // btnPublish
            // 
            this.btnPublish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPublish.AutoSize = true;
            this.btnPublish.Enabled = false;
            this.btnPublish.Location = new System.Drawing.Point(708, 510);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(106, 23);
            this.btnPublish.TabIndex = 5;
            this.btnPublish.Text = "&Copy to Clipboard";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnalyze.AutoSize = true;
            this.btnAnalyze.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAnalyze.Enabled = false;
            this.btnAnalyze.Location = new System.Drawing.Point(28, 509);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(104, 23);
            this.btnAnalyze.TabIndex = 9;
            this.btnAnalyze.Text = "&Create Description";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // cmsApp
            // 
            this.cmsApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.foldersToolStripMenuItem,
            this.toolStripSeparator1,
            this.tsmUpdatesCheck,
            this.tmsVersionHistory,
            this.cmsAppAbout});
            this.cmsApp.Name = "cmsApp";
            this.cmsApp.Size = new System.Drawing.Size(187, 98);
            // 
            // foldersToolStripMenuItem
            // 
            this.foldersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmScreenshots,
            this.tsmTorrentsDir,
            this.toolStripSeparator2,
            this.tsmLogsDir,
            this.tsmSettingsDir,
            this.tsmTemplates});
            this.foldersToolStripMenuItem.Name = "foldersToolStripMenuItem";
            this.foldersToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.foldersToolStripMenuItem.Text = "&Folders";
            // 
            // tsmScreenshots
            // 
            this.tsmScreenshots.Name = "tsmScreenshots";
            this.tsmScreenshots.Size = new System.Drawing.Size(156, 22);
            this.tsmScreenshots.Text = "&Screenshots...";
            this.tsmScreenshots.Click += new System.EventHandler(this.tsmScreenshots_Click);
            // 
            // tsmTorrentsDir
            // 
            this.tsmTorrentsDir.Name = "tsmTorrentsDir";
            this.tsmTorrentsDir.Size = new System.Drawing.Size(156, 22);
            this.tsmTorrentsDir.Text = "&Torrents...";
            this.tsmTorrentsDir.Click += new System.EventHandler(this.tsmTorrentsDir_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(153, 6);
            // 
            // tsmLogsDir
            // 
            this.tsmLogsDir.Name = "tsmLogsDir";
            this.tsmLogsDir.Size = new System.Drawing.Size(156, 22);
            this.tsmLogsDir.Text = "&Logs...";
            this.tsmLogsDir.Click += new System.EventHandler(this.tsmLogsDir_Click);
            // 
            // tsmSettingsDir
            // 
            this.tsmSettingsDir.Name = "tsmSettingsDir";
            this.tsmSettingsDir.Size = new System.Drawing.Size(156, 22);
            this.tsmSettingsDir.Text = "&Settings...";
            this.tsmSettingsDir.Click += new System.EventHandler(this.tsmSettingsDir_Click);
            // 
            // tsmTemplates
            // 
            this.tsmTemplates.Name = "tsmTemplates";
            this.tsmTemplates.Size = new System.Drawing.Size(156, 22);
            this.tsmTemplates.Text = "Templates...";
            this.tsmTemplates.Click += new System.EventHandler(this.tsmTemplates_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // tsmUpdatesCheck
            // 
            this.tsmUpdatesCheck.Name = "tsmUpdatesCheck";
            this.tsmUpdatesCheck.Size = new System.Drawing.Size(186, 22);
            this.tsmUpdatesCheck.Text = "Check for &Updates...";
            this.tsmUpdatesCheck.Click += new System.EventHandler(this.tsmUpdatesCheck_Click);
            // 
            // tmsVersionHistory
            // 
            this.tmsVersionHistory.Name = "tmsVersionHistory";
            this.tmsVersionHistory.Size = new System.Drawing.Size(186, 22);
            this.tmsVersionHistory.Text = "&Version History...";
            this.tmsVersionHistory.Click += new System.EventHandler(this.tmsVersionHistory_Click);
            // 
            // cmsAppAbout
            // 
            this.cmsAppAbout.Name = "cmsAppAbout";
            this.cmsAppAbout.Size = new System.Drawing.Size(186, 22);
            this.cmsAppAbout.Text = "&About...";
            this.cmsAppAbout.Click += new System.EventHandler(this.cmsAppAbout_Click);
            // 
            // btnCreateTorrent
            // 
            this.btnCreateTorrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateTorrent.AutoSize = true;
            this.btnCreateTorrent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCreateTorrent.Location = new System.Drawing.Point(138, 509);
            this.btnCreateTorrent.Name = "btnCreateTorrent";
            this.btnCreateTorrent.Size = new System.Drawing.Size(85, 23);
            this.btnCreateTorrent.TabIndex = 10;
            this.btnCreateTorrent.Text = "Create &Torrent";
            this.btnCreateTorrent.UseVisualStyleBackColor = true;
            this.btnCreateTorrent.Click += new System.EventHandler(this.btnCreateTorrent_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbLogo.Location = new System.Drawing.Point(242, 506);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(356, 29);
            this.pbLogo.TabIndex = 11;
            this.pbLogo.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.foldersToolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(892, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFileOpenFile,
            this.miFileOpenFolder,
            this.toolStripSeparator,
            this.miFileSaveTorrent,
            this.miFileSaveInfoAs,
            this.toolStripSeparator3,
            this.miFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // miFileOpenFile
            // 
            this.miFileOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("miFileOpenFile.Image")));
            this.miFileOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miFileOpenFile.Name = "miFileOpenFile";
            this.miFileOpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.miFileOpenFile.Size = new System.Drawing.Size(226, 22);
            this.miFileOpenFile.Text = "&Open File...";
            this.miFileOpenFile.Click += new System.EventHandler(this.miFileOpenFile_Click);
            // 
            // miFileOpenFolder
            // 
            this.miFileOpenFolder.Image = ((System.Drawing.Image)(resources.GetObject("miFileOpenFolder.Image")));
            this.miFileOpenFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miFileOpenFolder.Name = "miFileOpenFolder";
            this.miFileOpenFolder.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.O)));
            this.miFileOpenFolder.Size = new System.Drawing.Size(226, 22);
            this.miFileOpenFolder.Text = "&Open Folder...";
            this.miFileOpenFolder.Click += new System.EventHandler(this.miFileOpenFolder_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(223, 6);
            // 
            // miFileSaveTorrent
            // 
            this.miFileSaveTorrent.Image = ((System.Drawing.Image)(resources.GetObject("miFileSaveTorrent.Image")));
            this.miFileSaveTorrent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miFileSaveTorrent.Name = "miFileSaveTorrent";
            this.miFileSaveTorrent.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.miFileSaveTorrent.Size = new System.Drawing.Size(226, 22);
            this.miFileSaveTorrent.Text = "&Save Torrent";
            this.miFileSaveTorrent.Click += new System.EventHandler(this.miFileSaveTorrent_Click);
            // 
            // miFileSaveInfoAs
            // 
            this.miFileSaveInfoAs.Name = "miFileSaveInfoAs";
            this.miFileSaveInfoAs.Size = new System.Drawing.Size(226, 22);
            this.miFileSaveInfoAs.Text = "&Save Publish Info As...";
            this.miFileSaveInfoAs.Click += new System.EventHandler(this.miFileSaveInfoAs_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(223, 6);
            // 
            // miFileExit
            // 
            this.miFileExit.Name = "miFileExit";
            this.miFileExit.Size = new System.Drawing.Size(226, 22);
            this.miFileExit.Text = "E&xit";
            this.miFileExit.Click += new System.EventHandler(this.miFileExit_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEditCopy});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // miEditCopy
            // 
            this.miEditCopy.Image = ((System.Drawing.Image)(resources.GetObject("miEditCopy.Image")));
            this.miEditCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miEditCopy.Name = "miEditCopy";
            this.miEditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.miEditCopy.Size = new System.Drawing.Size(149, 22);
            this.miEditCopy.Text = "&Copy";
            this.miEditCopy.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // foldersToolStripMenuItem1
            // 
            this.foldersToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFoldersScreenshots,
            this.miFoldersTorrents,
            this.toolStripSeparator4,
            this.miFoldersLogs,
            this.miFoldersSettings,
            this.miFoldersTemplates});
            this.foldersToolStripMenuItem1.Name = "foldersToolStripMenuItem1";
            this.foldersToolStripMenuItem1.Size = new System.Drawing.Size(54, 20);
            this.foldersToolStripMenuItem1.Text = "&Folders";
            // 
            // miFoldersScreenshots
            // 
            this.miFoldersScreenshots.Name = "miFoldersScreenshots";
            this.miFoldersScreenshots.Size = new System.Drawing.Size(156, 22);
            this.miFoldersScreenshots.Text = "&Screenshots...";
            this.miFoldersScreenshots.Click += new System.EventHandler(this.miFoldersScreenshots_Click);
            // 
            // miFoldersTorrents
            // 
            this.miFoldersTorrents.Name = "miFoldersTorrents";
            this.miFoldersTorrents.Size = new System.Drawing.Size(156, 22);
            this.miFoldersTorrents.Text = "&Torrents...";
            this.miFoldersTorrents.Click += new System.EventHandler(this.miFoldersTorrents_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(153, 6);
            // 
            // miFoldersLogs
            // 
            this.miFoldersLogs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFoldersLogsDebug});
            this.miFoldersLogs.Name = "miFoldersLogs";
            this.miFoldersLogs.Size = new System.Drawing.Size(156, 22);
            this.miFoldersLogs.Text = "&Logs...";
            this.miFoldersLogs.Click += new System.EventHandler(this.miFoldersLogs_Click);
            // 
            // miFoldersLogsDebug
            // 
            this.miFoldersLogsDebug.Name = "miFoldersLogsDebug";
            this.miFoldersLogsDebug.Size = new System.Drawing.Size(128, 22);
            this.miFoldersLogsDebug.Text = "&Debug...";
            this.miFoldersLogsDebug.Click += new System.EventHandler(this.miFoldersLogsDebug_Click);
            // 
            // miFoldersSettings
            // 
            this.miFoldersSettings.Name = "miFoldersSettings";
            this.miFoldersSettings.Size = new System.Drawing.Size(156, 22);
            this.miFoldersSettings.Text = "&Settings...";
            this.miFoldersSettings.Click += new System.EventHandler(this.miFoldersSettings_Click);
            // 
            // miFoldersTemplates
            // 
            this.miFoldersTemplates.Name = "miFoldersTemplates";
            this.miFoldersTemplates.Size = new System.Drawing.Size(156, 22);
            this.miFoldersTemplates.Text = "&Templates...";
            this.miFoldersTemplates.Click += new System.EventHandler(this.miFoldersTemplates_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHelpCheckUpdates,
            this.miHelpVersionHistory,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // miHelpCheckUpdates
            // 
            this.miHelpCheckUpdates.Name = "miHelpCheckUpdates";
            this.miHelpCheckUpdates.Size = new System.Drawing.Size(186, 22);
            this.miHelpCheckUpdates.Text = "&Check for Updates...";
            this.miHelpCheckUpdates.Click += new System.EventHandler(this.miHelpCheckUpdates_Click);
            // 
            // miHelpVersionHistory
            // 
            this.miHelpVersionHistory.Name = "miHelpVersionHistory";
            this.miHelpVersionHistory.Size = new System.Drawing.Size(186, 22);
            this.miHelpVersionHistory.Text = "&Version History...";
            this.miHelpVersionHistory.Click += new System.EventHandler(this.miHelpVersionHistory_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AcceptButton = this.btnBrowse;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 566);
            this.ContextMenuStrip = this.cmsApp;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnCreateTorrent);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.btnPublish);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TDMaker";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragEnter);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.gbScreenshotFull.ResumeLayout(false);
            this.gbScreenshotFull.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbScreenshot)).EndInit();
            this.gbScreenshotForums.ResumeLayout(false);
            this.gbScreenshotForums.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tcMain.ResumeLayout(false);
            this.tpMedia.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.gbDVD.ResumeLayout(false);
            this.gbDVD.PerformLayout();
            this.gbLocation.ResumeLayout(false);
            this.gbLocation.PerformLayout();
            this.tpMainMediaInfo.ResumeLayout(false);
            this.tpMainMediaInfo.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tlpScreenshots.ResumeLayout(false);
            this.tlpScreenshots2.ResumeLayout(false);
            this.flpScreenshots1.ResumeLayout(false);
            this.flpScreenshots1.PerformLayout();
            this.tpMainPublish.ResumeLayout(false);
            this.tlpPublish.ResumeLayout(false);
            this.tlpPublish.PerformLayout();
            this.gbQuickPublish.ResumeLayout(false);
            this.gbQuickPublish.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tcOptions.ResumeLayout(false);
            this.tpPublish.ResumeLayout(false);
            this.tpPublish.PerformLayout();
            this.gbTemplatesInternal.ResumeLayout(false);
            this.gbTemplatesInternal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSizeIncr)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeading1Size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeading2Size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeading3Size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBodySize)).EndInit();
            this.tpScreenshots.ResumeLayout(false);
            this.tcMtn.ResumeLayout(false);
            this.tpUsage1.ResumeLayout(false);
            this.pMTNUsage.ResumeLayout(false);
            this.pMTNUsage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_B_OmitStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_D_EdgeDetection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_E_OmitEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_h_HeightMin)).EndInit();
            this.gbMTN_i_MediaInfo.ResumeLayout(false);
            this.gbMTN_i_MediaInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_F_FontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_j_JPEGQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_g_Gap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_w_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_s_TimeStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_r_Rows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMTN_c_Columns)).EndInit();
            this.tpUsage2.ResumeLayout(false);
            this.tpHostingImageShack.ResumeLayout(false);
            this.tpHostingImageShack.PerformLayout();
            this.tpTorrents.ResumeLayout(false);
            this.tpTorrents.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.gbTrackerMgr.ResumeLayout(false);
            this.tlpTrackers.ResumeLayout(false);
            this.flpTrackers.ResumeLayout(false);
            this.flpTrackerGroups.ResumeLayout(false);
            this.gbTrackerGroups.ResumeLayout(false);
            this.gbTrackers.ResumeLayout(false);
            this.tpAdvanced.ResumeLayout(false);
            this.cmsApp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.TabPage tpUsage2;
        private System.Windows.Forms.TabPage tpUsage1;

        #endregion

        private System.Windows.Forms.GroupBox gbScreenshotFull;
        private System.Windows.Forms.GroupBox gbScreenshotForums;
        private System.Windows.Forms.Button btnCopy1;
        private System.Windows.Forms.TextBox txtBBScrFull;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker bwApp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sbarIcon;
        private System.Windows.Forms.ToolStripStatusLabel sBar;
        private System.Windows.Forms.ToolStripProgressBar pBar;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpMainMediaInfo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Timer tmrStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCopy2;
        private System.Windows.Forms.TextBox txtBBScrForums;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCopy0;
        private System.Windows.Forms.TextBox txtMediaInfo;
        private System.Windows.Forms.TabPage tpMainPublish;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.GroupBox gbLocation;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox chkScreenshotUpload;
        private System.Windows.Forms.CheckBox chkUploadFullScreenshot;
        private System.Windows.Forms.GroupBox gbTemplatesInternal;
        private System.Windows.Forms.CheckBox chkAlignCenter;
        private System.Windows.Forms.CheckBox chkPre;
        private System.Windows.Forms.NumericUpDown nudBodySize;
        private System.Windows.Forms.NumericUpDown nudHeading3Size;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudFontSizeIncr;
        private System.Windows.Forms.CheckBox chkPreIncreaseFontSize;
        private System.Windows.Forms.ComboBox cboSource;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.LinkLabel txtScrFull;
        private System.Windows.Forms.ContextMenuStrip cmsApp;
        private System.Windows.Forms.ToolStripMenuItem cmsAppAbout;
        private System.Windows.Forms.TabPage tpMedia;
        private System.Windows.Forms.RadioButton rbDir;
        private System.Windows.Forms.RadioButton rbFile;
        private System.Windows.Forms.TextBox txtWebLink;
        private System.Windows.Forms.CheckBox chkWebLink;
        private System.Windows.Forms.GroupBox gbDVD;
        private System.Windows.Forms.CheckBox chkCreateTorrent;
        private System.Windows.Forms.ComboBox cboTrackerGroupActive;
        private System.Windows.Forms.TabControl tcOptions;
        private System.Windows.Forms.TabPage tpScreenshots;
        private System.Windows.Forms.TabPage tpTorrents;
        private System.Windows.Forms.TabPage tpPublish;
        private System.Windows.Forms.Button btnCreateTorrent;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnBrowseTorrentCustomFolder;
        private System.Windows.Forms.TextBox txtTorrentCustomFolder;
        private System.Windows.Forms.RadioButton rbTorrentFolderCustom;
        private System.Windows.Forms.RadioButton rbTorrentDefaultFolder;
        private System.Windows.Forms.GroupBox gbTrackerMgr;
        private System.Windows.Forms.CheckBox chkTorrentOrganize;
        private System.Windows.Forms.ListBox lbStatus;
        private System.Windows.Forms.TextBox txtPublish;
        private System.Windows.Forms.NumericUpDown nudHeading2Size;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudHeading1Size;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbQuickPublish;
        private System.Windows.Forms.CheckBox chkQuickAlignCenter;
        private System.Windows.Forms.CheckBox chkQuickPre;
        private System.Windows.Forms.CheckBox chkQuickFullPicture;
        private System.Windows.Forms.CheckBox chkAuthoring;
        private System.Windows.Forms.ComboBox cboAuthoring;
        private System.Windows.Forms.ComboBox cboExtras;
        private System.Windows.Forms.CheckBox chkExtras;
        private System.Windows.Forms.CheckBox chkWritePublish;
        private System.Windows.Forms.ComboBox cboDiscMenu;
        private System.Windows.Forms.CheckBox chkDiscMenu;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.CheckBox chkTemplatesMode;
        private System.Windows.Forms.ComboBox cboTemplate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem foldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmTorrentsDir;
        private System.Windows.Forms.ToolStripMenuItem tsmScreenshots;
        private System.Windows.Forms.CheckBox chkScreenshot;
        private System.Windows.Forms.ToolStripMenuItem tsmTemplates;
        private System.Windows.Forms.ToolStripMenuItem tsmUpdatesCheck;
        private System.Windows.Forms.ComboBox cboScreenshotDest;
        private System.Windows.Forms.CheckBox chkRandomizeFileNameImageShack;
        private System.Windows.Forms.ToolStripMenuItem tsmLogsDir;
        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.CheckBox chkSource;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ToolStripStatusLabel tssPerc;
        private System.Windows.Forms.ListBox lbScreenshots;
        private System.Windows.Forms.Button btnTemplatesRewrite;
        private System.Windows.Forms.CheckBox chkShowMTN;
        private System.Windows.Forms.TabControl tcMtn;
        private System.Windows.Forms.TabPage tpHostingImageShack;
        private System.Windows.Forms.CheckBox chkUseImageShackRegCode;
        private System.Windows.Forms.TextBox txtImageShackRegCode;
        private System.Windows.Forms.Button btnImageShackRegCode;
        private System.Windows.Forms.Button btnImageShackImages;
        private System.Windows.Forms.ToolStripMenuItem tmsVersionHistory;
        private System.Windows.Forms.ComboBox cboQuickTemplate;
        private System.Windows.Forms.CheckBox chkTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.ComboBox cboMTN_f_FontType;
        private System.Windows.Forms.PictureBox pbScreenshot;
        private System.Windows.Forms.Panel pMTNUsage;
        private System.Windows.Forms.CheckBox chkMTNColumns;
        private System.Windows.Forms.CheckBox chkMTN_f_Font;
        private System.Windows.Forms.NumericUpDown nudMTN_s_TimeStep;
        private System.Windows.Forms.CheckBox chkMTN_s_TimeStep;
        private System.Windows.Forms.NumericUpDown nudMTN_r_Rows;
        private System.Windows.Forms.CheckBox chkMTNRows;
        private System.Windows.Forms.NumericUpDown nudMTN_c_Columns;
        private System.Windows.Forms.CheckBox chkMTN_P_QuitAfterDone;
        private System.Windows.Forms.NumericUpDown nudMTN_w_Width;
        private System.Windows.Forms.CheckBox chkMTN_w_Width;
        private System.Windows.Forms.ToolTip ttApp;
        private System.Windows.Forms.CheckBox chkMTN_F_FontColor;
        private System.Windows.Forms.ComboBox cboMTN_k_ColorBkgrd;
        private System.Windows.Forms.CheckBox chkMTN_k_ColorBackground;
        private System.Windows.Forms.ComboBox cboMTN_F_FontColor;
        private System.Windows.Forms.NumericUpDown nudMTN_g_Gap;
        private System.Windows.Forms.CheckBox chkMTN_g_Gap;
        private System.Windows.Forms.NumericUpDown nudMTN_F_FontSize;
        private System.Windows.Forms.CheckBox chkMTN_F_FontSize;
        private System.Windows.Forms.ComboBox cboMTN_L_LocTimestamp;
        private System.Windows.Forms.CheckBox chkMTN_tL_LocTimestamp;
        private System.Windows.Forms.ComboBox cboMTN_L_LocInfo;
        private System.Windows.Forms.CheckBox chkMTN_L_LocInfo;
        private System.Windows.Forms.NumericUpDown nudMTN_j_JPEGQuality;
        private System.Windows.Forms.CheckBox chkMTN_j_JPEGQuality;
        private System.Windows.Forms.CheckBox chkMTN_i_MediaInfoTurnOff;
        private System.Windows.Forms.GroupBox gbMTN_i_MediaInfo;
        private System.Windows.Forms.CheckBox chkMTN_z_SeekMode;
        private System.Windows.Forms.TextBox txtMTN_N_InfoSuffix;
        private System.Windows.Forms.CheckBox chkMTN_N_WriteInfo;
        private System.Windows.Forms.TextBox txtMTN_o_OutputSuffix;
        private System.Windows.Forms.CheckBox chkMTN_o_OutputSuffix;
        private System.Windows.Forms.CheckBox chkMTN_v_Verbose;
        private System.Windows.Forms.CheckBox chkMTN_T_Title;
        private System.Windows.Forms.TextBox txtMTN_T_Title;
        private System.Windows.Forms.NumericUpDown nudMTN_h_HeightMin;
        private System.Windows.Forms.CheckBox chkMTN_h_Height;
        private System.Windows.Forms.Button btnRefreshTrackers;
        private System.Windows.Forms.NumericUpDown nudMTN_E_OmitEnd;
        private System.Windows.Forms.CheckBox chkMTN_E_OmitEnd;
        private System.Windows.Forms.NumericUpDown nudMTN_D_EdgeDetection;
        private System.Windows.Forms.CheckBox chkMTN_D_EdgeDetection;
        private System.Windows.Forms.NumericUpDown nudMTN_B_OmitStart;
        private System.Windows.Forms.CheckBox chkMTN_B_OmitBegin;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmSettingsDir;
        private System.Windows.Forms.RadioButton rbTExt;
        private System.Windows.Forms.RadioButton rbTInt;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miFileOpenFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem miFileSaveTorrent;
        private System.Windows.Forms.ToolStripMenuItem miFileSaveInfoAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem miFileExit;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miFileOpenFile;
        private System.Windows.Forms.ToolStripMenuItem miEditCopy;
        private System.Windows.Forms.ToolStripMenuItem miHelpCheckUpdates;
        private System.Windows.Forms.ToolStripMenuItem miHelpVersionHistory;
        private System.Windows.Forms.ToolStripMenuItem foldersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miFoldersScreenshots;
        private System.Windows.Forms.ToolStripMenuItem miFoldersTorrents;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem miFoldersLogs;
        private System.Windows.Forms.ToolStripMenuItem miFoldersLogsDebug;
        private System.Windows.Forms.ToolStripMenuItem miFoldersSettings;
        private System.Windows.Forms.ToolStripMenuItem miFoldersTemplates;
        private System.Windows.Forms.PropertyGrid pgMtn;
        private System.Windows.Forms.PropertyGrid pgApp;
        private System.Windows.Forms.TableLayoutPanel tlpPublish;
        private System.Windows.Forms.TableLayoutPanel tlpScreenshots;
        private System.Windows.Forms.TableLayoutPanel tlpScreenshots2;
        private System.Windows.Forms.FlowLayoutPanel flpScreenshots1;
        private System.Windows.Forms.TabPage tpAdvanced;
        private System.Windows.Forms.TableLayoutPanel tlpTrackers;
        private System.Windows.Forms.ListBox lbTrackers;
        private System.Windows.Forms.PropertyGrid pgTracker;
        private System.Windows.Forms.ListBox lbTrackerGroups;
        private System.Windows.Forms.FlowLayoutPanel flpTrackers;
        private System.Windows.Forms.Button btnAddTracker;
        private System.Windows.Forms.Button btnRemoveTracker;
        private System.Windows.Forms.FlowLayoutPanel flpTrackerGroups;
        private System.Windows.Forms.Button btnAddTrackerGroup;
        private System.Windows.Forms.Button btnRemoveTrackerGroup;
        private System.Windows.Forms.GroupBox gbTrackerGroups;
        private System.Windows.Forms.GroupBox gbTrackers;
    }
}

