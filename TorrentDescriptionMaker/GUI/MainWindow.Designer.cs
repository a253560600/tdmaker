namespace TorrentDescriptionMaker
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnMTNHelp = new System.Windows.Forms.Button();
            this.btnBrowseMTN = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbScreenshotFull = new System.Windows.Forms.GroupBox();
            this.lbScreenshots = new System.Windows.Forms.ListBox();
            this.txtScrFull = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCopy0 = new System.Windows.Forms.Button();
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
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtWebLink = new System.Windows.Forms.TextBox();
            this.gbDVD = new System.Windows.Forms.GroupBox();
            this.gbLocation = new System.Windows.Forms.GroupBox();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.rbFile = new System.Windows.Forms.RadioButton();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tpMediaInfo = new System.Windows.Forms.TabPage();
            this.txtMediaInfo = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gbQuickPublish = new System.Windows.Forms.GroupBox();
            this.cboQuickTemplate = new System.Windows.Forms.ComboBox();
            this.chkQuickFullPicture = new System.Windows.Forms.CheckBox();
            this.chkQuickAlignCenter = new System.Windows.Forms.CheckBox();
            this.chkQuickPre = new System.Windows.Forms.CheckBox();
            this.txtPublish = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tcOptions = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.tpPublish = new System.Windows.Forms.TabPage();
            this.btnTemplatesRewrite = new System.Windows.Forms.Button();
            this.cboTemplate = new System.Windows.Forms.ComboBox();
            this.gbTemplatesInternal = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tpScreenshots = new System.Windows.Forms.TabPage();
            this.tcHosting = new System.Windows.Forms.TabControl();
            this.tpHostingImageShack = new System.Windows.Forms.TabPage();
            this.btnImageShackImages = new System.Windows.Forms.Button();
            this.btnImageShackRegCode = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboScreenshotDest = new System.Windows.Forms.ComboBox();
            this.tpTorrents = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnBrowseTorrentCustomFolder = new System.Windows.Forms.Button();
            this.rbTorrentFolderCustom = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dgvTrackers = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnnounceURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboAnnounceURL = new System.Windows.Forms.ComboBox();
            this.tmrStatus = new System.Windows.Forms.Timer(this.components);
            this.btnPublish = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.cmsApp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.foldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmScreenshots = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLogsDir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTemplates = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTorrentsDir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmUpdatesCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsVersionHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsAppAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreateTorrent = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.chkTitle = new System.Windows.Forms.CheckBox();
            this.chkWebLink = new System.Windows.Forms.CheckBox();
            this.chkSource = new System.Windows.Forms.CheckBox();
            this.cboSource = new System.Windows.Forms.ComboBox();
            this.cboDiscMenu = new System.Windows.Forms.ComboBox();
            this.chkDiscMenu = new System.Windows.Forms.CheckBox();
            this.cboExtras = new System.Windows.Forms.ComboBox();
            this.chkExtras = new System.Windows.Forms.CheckBox();
            this.cboAuthoring = new System.Windows.Forms.ComboBox();
            this.chkSourceEdit = new System.Windows.Forms.CheckBox();
            this.rbDir = new System.Windows.Forms.RadioButton();
            this.chkScreenshot = new System.Windows.Forms.CheckBox();
            this.chkUpdateCheck = new System.Windows.Forms.CheckBox();
            this.chkAnalyzeAuto = new System.Windows.Forms.CheckBox();
            this.nudFontSizeIncr = new System.Windows.Forms.NumericUpDown();
            this.chkPre = new System.Windows.Forms.CheckBox();
            this.chkPreIncreaseFontSize = new System.Windows.Forms.CheckBox();
            this.chkAlignCenter = new System.Windows.Forms.CheckBox();
            this.nudFontSizeHeading1 = new System.Windows.Forms.NumericUpDown();
            this.nudHeading2Size = new System.Windows.Forms.NumericUpDown();
            this.nudHeading3Size = new System.Windows.Forms.NumericUpDown();
            this.nudBodyText = new System.Windows.Forms.NumericUpDown();
            this.chkUploadFullScreenshot = new System.Windows.Forms.CheckBox();
            this.chkTemplatesMode = new System.Windows.Forms.CheckBox();
            this.chkUseImageShackRegCode = new System.Windows.Forms.CheckBox();
            this.txtImageShackRegCode = new System.Windows.Forms.TextBox();
            this.chkRandomizeFileNameImageShack = new System.Windows.Forms.CheckBox();
            this.chkKeepScreenshot = new System.Windows.Forms.CheckBox();
            this.chkOptImageShack = new System.Windows.Forms.CheckBox();
            this.cboMTNFont = new System.Windows.Forms.ComboBox();
            this.chkShowMTN = new System.Windows.Forms.CheckBox();
            this.cboMtnArgs = new System.Windows.Forms.ComboBox();
            this.txtMtn = new System.Windows.Forms.TextBox();
            this.chkWritePublish = new System.Windows.Forms.CheckBox();
            this.chkTorrentOrganize = new System.Windows.Forms.CheckBox();
            this.txtTorrentCustomFolder = new System.Windows.Forms.TextBox();
            this.rbTorrentDefaultFolder = new System.Windows.Forms.RadioButton();
            this.chkCreateTorrent = new System.Windows.Forms.CheckBox();
            this.pbScreenshot = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.gbScreenshotFull.SuspendLayout();
            this.gbScreenshotForums.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tpMedia.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.gbDVD.SuspendLayout();
            this.gbLocation.SuspendLayout();
            this.tpMediaInfo.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.gbQuickPublish.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tcOptions.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.tpPublish.SuspendLayout();
            this.gbTemplatesInternal.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tpScreenshots.SuspendLayout();
            this.tcHosting.SuspendLayout();
            this.tpHostingImageShack.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tpTorrents.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrackers)).BeginInit();
            this.cmsApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSizeIncr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSizeHeading1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeading2Size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeading3Size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBodyText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbScreenshot)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cboMTNFont);
            this.groupBox1.Controls.Add(this.chkShowMTN);
            this.groupBox1.Controls.Add(this.btnMTNHelp);
            this.groupBox1.Controls.Add(this.btnBrowseMTN);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboMtnArgs);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMtn);
            this.groupBox1.Location = new System.Drawing.Point(15, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(712, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Movie Thumbnailer Settings";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(67, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Font:";
            this.label10.Visible = false;
            // 
            // btnMTNHelp
            // 
            this.btnMTNHelp.Location = new System.Drawing.Point(569, 52);
            this.btnMTNHelp.Name = "btnMTNHelp";
            this.btnMTNHelp.Size = new System.Drawing.Size(82, 23);
            this.btnMTNHelp.TabIndex = 10;
            this.btnMTNHelp.Text = "&Usage...";
            this.btnMTNHelp.UseVisualStyleBackColor = true;
            this.btnMTNHelp.Click += new System.EventHandler(this.btnMTNHelp_Click);
            // 
            // btnBrowseMTN
            // 
            this.btnBrowseMTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseMTN.Location = new System.Drawing.Point(569, 23);
            this.btnBrowseMTN.Name = "btnBrowseMTN";
            this.btnBrowseMTN.Size = new System.Drawing.Size(82, 23);
            this.btnBrowseMTN.TabIndex = 9;
            this.btnBrowseMTN.Text = "&Browse";
            this.btnBrowseMTN.UseVisualStyleBackColor = true;
            this.btnBrowseMTN.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Arguments:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "MTN Path:";
            // 
            // gbScreenshotFull
            // 
            this.gbScreenshotFull.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbScreenshotFull.Controls.Add(this.lbScreenshots);
            this.gbScreenshotFull.Controls.Add(this.txtScrFull);
            this.gbScreenshotFull.Controls.Add(this.label4);
            this.gbScreenshotFull.Controls.Add(this.btnCopy0);
            this.gbScreenshotFull.Location = new System.Drawing.Point(20, 50);
            this.gbScreenshotFull.Name = "gbScreenshotFull";
            this.gbScreenshotFull.Size = new System.Drawing.Size(724, 171);
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
            this.lbScreenshots.Size = new System.Drawing.Size(460, 82);
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
            this.txtScrFull.Size = new System.Drawing.Size(460, 20);
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
            this.btnCopy0.Location = new System.Drawing.Point(580, 31);
            this.btnCopy0.Name = "btnCopy0";
            this.btnCopy0.Size = new System.Drawing.Size(106, 23);
            this.btnCopy0.TabIndex = 3;
            this.btnCopy0.Text = "&Copy to Clipboard";
            this.btnCopy0.UseVisualStyleBackColor = true;
            this.btnCopy0.Click += new System.EventHandler(this.btnCopy0_Click);
            // 
            // gbScreenshotForums
            // 
            this.gbScreenshotForums.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbScreenshotForums.Controls.Add(this.label2);
            this.gbScreenshotForums.Controls.Add(this.btnCopy2);
            this.gbScreenshotForums.Controls.Add(this.txtBBScrForums);
            this.gbScreenshotForums.Controls.Add(this.label5);
            this.gbScreenshotForums.Controls.Add(this.btnCopy1);
            this.gbScreenshotForums.Controls.Add(this.txtBBScrFull);
            this.gbScreenshotForums.Location = new System.Drawing.Point(20, 238);
            this.gbScreenshotForums.Name = "gbScreenshotForums";
            this.gbScreenshotForums.Size = new System.Drawing.Size(724, 124);
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
            this.btnCopy2.Location = new System.Drawing.Point(580, 78);
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
            this.txtBBScrForums.Size = new System.Drawing.Size(460, 20);
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
            this.btnCopy1.Location = new System.Drawing.Point(580, 40);
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
            this.txtBBScrFull.Size = new System.Drawing.Size(460, 20);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
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
            this.sBar.Size = new System.Drawing.Size(651, 17);
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
            this.tcMain.Controls.Add(this.tpMediaInfo);
            this.tcMain.Controls.Add(this.tabPage2);
            this.tcMain.Controls.Add(this.tabPage3);
            this.tcMain.Controls.Add(this.tabPage4);
            this.tcMain.Location = new System.Drawing.Point(12, 12);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(760, 483);
            this.tcMain.TabIndex = 4;
            // 
            // tpMedia
            // 
            this.tpMedia.Controls.Add(this.groupBox10);
            this.tpMedia.Controls.Add(this.groupBox9);
            this.tpMedia.Controls.Add(this.gbDVD);
            this.tpMedia.Controls.Add(this.gbLocation);
            this.tpMedia.Location = new System.Drawing.Point(4, 22);
            this.tpMedia.Name = "tpMedia";
            this.tpMedia.Size = new System.Drawing.Size(752, 457);
            this.tpMedia.TabIndex = 4;
            this.tpMedia.Text = "Media";
            this.tpMedia.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.lbStatus);
            this.groupBox10.Location = new System.Drawing.Point(12, 327);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(718, 116);
            this.groupBox10.TabIndex = 13;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Progress";
            // 
            // lbStatus
            // 
            this.lbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lbStatus.FormattingEnabled = true;
            this.lbStatus.Location = new System.Drawing.Point(26, 30);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.ScrollAlwaysVisible = true;
            this.lbStatus.Size = new System.Drawing.Size(670, 69);
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
            this.groupBox9.Location = new System.Drawing.Point(297, 181);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(433, 133);
            this.groupBox9.TabIndex = 12;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Source Properties";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(117, 59);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(292, 20);
            this.txtTitle.TabIndex = 15;
            // 
            // txtWebLink
            // 
            this.txtWebLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWebLink.Location = new System.Drawing.Point(117, 89);
            this.txtWebLink.Name = "txtWebLink";
            this.txtWebLink.Size = new System.Drawing.Size(292, 20);
            this.txtWebLink.TabIndex = 10;
            // 
            // gbDVD
            // 
            this.gbDVD.Controls.Add(this.cboDiscMenu);
            this.gbDVD.Controls.Add(this.chkDiscMenu);
            this.gbDVD.Controls.Add(this.cboExtras);
            this.gbDVD.Controls.Add(this.chkExtras);
            this.gbDVD.Controls.Add(this.cboAuthoring);
            this.gbDVD.Controls.Add(this.chkSourceEdit);
            this.gbDVD.Location = new System.Drawing.Point(12, 181);
            this.gbDVD.Name = "gbDVD";
            this.gbDVD.Size = new System.Drawing.Size(269, 133);
            this.gbDVD.TabIndex = 11;
            this.gbDVD.TabStop = false;
            this.gbDVD.Text = "DVD Properties";
            // 
            // gbLocation
            // 
            this.gbLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLocation.Controls.Add(this.lbFiles);
            this.gbLocation.Controls.Add(this.rbDir);
            this.gbLocation.Controls.Add(this.rbFile);
            this.gbLocation.Controls.Add(this.btnBrowse);
            this.gbLocation.Location = new System.Drawing.Point(12, 12);
            this.gbLocation.Name = "gbLocation";
            this.gbLocation.Size = new System.Drawing.Size(718, 163);
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
            this.lbFiles.Size = new System.Drawing.Size(676, 82);
            this.lbFiles.TabIndex = 13;
            // 
            // rbFile
            // 
            this.rbFile.AutoSize = true;
            this.rbFile.Location = new System.Drawing.Point(26, 27);
            this.rbFile.Name = "rbFile";
            this.rbFile.Size = new System.Drawing.Size(71, 17);
            this.rbFile.TabIndex = 8;
            this.rbFile.Text = "&Video File";
            this.rbFile.UseVisualStyleBackColor = true;
            this.rbFile.CheckedChanged += new System.EventHandler(this.rbFile_CheckedChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.AutoSize = true;
            this.btnBrowse.Location = new System.Drawing.Point(630, 24);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(72, 23);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "&Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tpMediaInfo
            // 
            this.tpMediaInfo.Controls.Add(this.txtMediaInfo);
            this.tpMediaInfo.Location = new System.Drawing.Point(4, 22);
            this.tpMediaInfo.Name = "tpMediaInfo";
            this.tpMediaInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpMediaInfo.Size = new System.Drawing.Size(752, 457);
            this.tpMediaInfo.TabIndex = 0;
            this.tpMediaInfo.Text = "Info";
            this.tpMediaInfo.UseVisualStyleBackColor = true;
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
            this.txtMediaInfo.Size = new System.Drawing.Size(746, 451);
            this.txtMediaInfo.TabIndex = 0;
            this.txtMediaInfo.WordWrap = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pbScreenshot);
            this.tabPage2.Controls.Add(this.gbScreenshotForums);
            this.tabPage2.Controls.Add(this.gbScreenshotFull);
            this.tabPage2.Controls.Add(this.chkScreenshot);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(752, 457);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Screenshots";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gbQuickPublish);
            this.tabPage3.Controls.Add(this.txtPublish);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(752, 457);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Publish";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gbQuickPublish
            // 
            this.gbQuickPublish.Controls.Add(this.cboQuickTemplate);
            this.gbQuickPublish.Controls.Add(this.chkQuickFullPicture);
            this.gbQuickPublish.Controls.Add(this.chkQuickAlignCenter);
            this.gbQuickPublish.Controls.Add(this.chkQuickPre);
            this.gbQuickPublish.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbQuickPublish.Location = new System.Drawing.Point(598, 3);
            this.gbQuickPublish.Name = "gbQuickPublish";
            this.gbQuickPublish.Size = new System.Drawing.Size(151, 451);
            this.gbQuickPublish.TabIndex = 1;
            this.gbQuickPublish.TabStop = false;
            this.gbQuickPublish.Text = "Options";
            // 
            // cboQuickTemplate
            // 
            this.cboQuickTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuickTemplate.FormattingEnabled = true;
            this.cboQuickTemplate.Location = new System.Drawing.Point(15, 104);
            this.cboQuickTemplate.Name = "cboQuickTemplate";
            this.cboQuickTemplate.Size = new System.Drawing.Size(121, 21);
            this.cboQuickTemplate.TabIndex = 3;
            this.cboQuickTemplate.SelectedIndexChanged += new System.EventHandler(this.cboQuickTemplate_SelectedIndexChanged);
            // 
            // chkQuickFullPicture
            // 
            this.chkQuickFullPicture.AutoSize = true;
            this.chkQuickFullPicture.Location = new System.Drawing.Point(15, 81);
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
            this.chkQuickAlignCenter.Location = new System.Drawing.Point(15, 58);
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
            this.chkQuickPre.Location = new System.Drawing.Point(15, 35);
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
            this.txtPublish.Size = new System.Drawing.Size(597, 455);
            this.txtPublish.TabIndex = 0;
            this.txtPublish.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPublish_KeyPress);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tcOptions);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(752, 457);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Options";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tcOptions
            // 
            this.tcOptions.Controls.Add(this.tpGeneral);
            this.tcOptions.Controls.Add(this.tpPublish);
            this.tcOptions.Controls.Add(this.tpScreenshots);
            this.tcOptions.Controls.Add(this.tpTorrents);
            this.tcOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcOptions.Location = new System.Drawing.Point(0, 0);
            this.tcOptions.Name = "tcOptions";
            this.tcOptions.SelectedIndex = 0;
            this.tcOptions.Size = new System.Drawing.Size(752, 457);
            this.tcOptions.TabIndex = 11;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.chkUpdateCheck);
            this.tpGeneral.Controls.Add(this.chkAnalyzeAuto);
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(744, 431);
            this.tpGeneral.TabIndex = 3;
            this.tpGeneral.Text = "General";
            this.tpGeneral.UseVisualStyleBackColor = true;
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
            this.tpPublish.Size = new System.Drawing.Size(744, 431);
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
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.nudFontSizeHeading1);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.nudHeading2Size);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.nudHeading3Size);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.nudBodyText);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Location = new System.Drawing.Point(455, 72);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(190, 148);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Font Size";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Heading 2";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Heading 3";
            // 
            // tpScreenshots
            // 
            this.tpScreenshots.Controls.Add(this.tcHosting);
            this.tpScreenshots.Controls.Add(this.groupBox5);
            this.tpScreenshots.Controls.Add(this.groupBox1);
            this.tpScreenshots.Location = new System.Drawing.Point(4, 22);
            this.tpScreenshots.Name = "tpScreenshots";
            this.tpScreenshots.Padding = new System.Windows.Forms.Padding(3);
            this.tpScreenshots.Size = new System.Drawing.Size(744, 431);
            this.tpScreenshots.TabIndex = 0;
            this.tpScreenshots.Text = "Movie Thumbnailer";
            this.tpScreenshots.UseVisualStyleBackColor = true;
            // 
            // tcHosting
            // 
            this.tcHosting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcHosting.Controls.Add(this.tpHostingImageShack);
            this.tcHosting.Location = new System.Drawing.Point(15, 214);
            this.tcHosting.Name = "tcHosting";
            this.tcHosting.SelectedIndex = 0;
            this.tcHosting.Size = new System.Drawing.Size(712, 198);
            this.tcHosting.TabIndex = 5;
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
            this.tpHostingImageShack.Size = new System.Drawing.Size(704, 172);
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
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.cboScreenshotDest);
            this.groupBox5.Controls.Add(this.chkKeepScreenshot);
            this.groupBox5.Controls.Add(this.chkOptImageShack);
            this.groupBox5.Location = new System.Drawing.Point(15, 14);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(712, 60);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Save Locations";
            // 
            // cboScreenshotDest
            // 
            this.cboScreenshotDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboScreenshotDest.FormattingEnabled = true;
            this.cboScreenshotDest.Items.AddRange(new object[] {
            "ImageShack",
            "TinyPic",
            "ImageShack (Legacy Method)"});
            this.cboScreenshotDest.Location = new System.Drawing.Point(463, 21);
            this.cboScreenshotDest.Name = "cboScreenshotDest";
            this.cboScreenshotDest.Size = new System.Drawing.Size(196, 21);
            this.cboScreenshotDest.TabIndex = 2;
            this.cboScreenshotDest.SelectedIndexChanged += new System.EventHandler(this.cboScreenshotDest_SelectedIndexChanged);
            // 
            // tpTorrents
            // 
            this.tpTorrents.Controls.Add(this.groupBox8);
            this.tpTorrents.Controls.Add(this.groupBox7);
            this.tpTorrents.Controls.Add(this.cboAnnounceURL);
            this.tpTorrents.Controls.Add(this.chkCreateTorrent);
            this.tpTorrents.Location = new System.Drawing.Point(4, 22);
            this.tpTorrents.Name = "tpTorrents";
            this.tpTorrents.Padding = new System.Windows.Forms.Padding(3);
            this.tpTorrents.Size = new System.Drawing.Size(744, 431);
            this.tpTorrents.TabIndex = 1;
            this.tpTorrents.Text = "Torrent Creator";
            this.tpTorrents.UseVisualStyleBackColor = true;
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
            this.groupBox8.Location = new System.Drawing.Point(17, 225);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(705, 122);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Save Location";
            // 
            // btnBrowseTorrentCustomFolder
            // 
            this.btnBrowseTorrentCustomFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseTorrentCustomFolder.Location = new System.Drawing.Point(600, 39);
            this.btnBrowseTorrentCustomFolder.Name = "btnBrowseTorrentCustomFolder";
            this.btnBrowseTorrentCustomFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseTorrentCustomFolder.TabIndex = 3;
            this.btnBrowseTorrentCustomFolder.Text = "&Browse";
            this.btnBrowseTorrentCustomFolder.UseVisualStyleBackColor = true;
            this.btnBrowseTorrentCustomFolder.Click += new System.EventHandler(this.btnBrowseTorrentCustomFolder_Click);
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
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.dgvTrackers);
            this.groupBox7.Location = new System.Drawing.Point(17, 39);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(705, 180);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Tracker Manager";
            // 
            // dgvTrackers
            // 
            this.dgvTrackers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTrackers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTrackers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrackers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colAnnounceURL});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTrackers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTrackers.Location = new System.Drawing.Point(6, 19);
            this.dgvTrackers.Name = "dgvTrackers";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTrackers.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTrackers.Size = new System.Drawing.Size(693, 148);
            this.dgvTrackers.TabIndex = 1;
            this.dgvTrackers.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvTrackers_CellValidating);
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colName.HeaderText = "Tracker Name";
            this.colName.Name = "colName";
            this.colName.Width = 92;
            // 
            // colAnnounceURL
            // 
            this.colAnnounceURL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAnnounceURL.HeaderText = "Announce URL";
            this.colAnnounceURL.Name = "colAnnounceURL";
            // 
            // cboAnnounceURL
            // 
            this.cboAnnounceURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAnnounceURL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnnounceURL.FormattingEnabled = true;
            this.cboAnnounceURL.Location = new System.Drawing.Point(209, 12);
            this.cboAnnounceURL.Name = "cboAnnounceURL";
            this.cboAnnounceURL.Size = new System.Drawing.Size(513, 21);
            this.cboAnnounceURL.TabIndex = 2;
            this.cboAnnounceURL.SelectedIndexChanged += new System.EventHandler(this.cboAnnounceURL_SelectedIndexChanged);
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
            this.btnPublish.Location = new System.Drawing.Point(604, 505);
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
            this.btnAnalyze.Location = new System.Drawing.Point(28, 505);
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
            this.cmsApp.Size = new System.Drawing.Size(181, 98);
            // 
            // foldersToolStripMenuItem
            // 
            this.foldersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmScreenshots,
            this.tsmLogsDir,
            this.tsmTemplates,
            this.tsmTorrentsDir});
            this.foldersToolStripMenuItem.Name = "foldersToolStripMenuItem";
            this.foldersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.foldersToolStripMenuItem.Text = "&Folders";
            // 
            // tsmScreenshots
            // 
            this.tsmScreenshots.Name = "tsmScreenshots";
            this.tsmScreenshots.Size = new System.Drawing.Size(146, 22);
            this.tsmScreenshots.Text = "&Screenshots...";
            this.tsmScreenshots.Click += new System.EventHandler(this.tsmScreenshots_Click);
            // 
            // tsmLogsDir
            // 
            this.tsmLogsDir.Name = "tsmLogsDir";
            this.tsmLogsDir.Size = new System.Drawing.Size(146, 22);
            this.tsmLogsDir.Text = "&Logs...";
            this.tsmLogsDir.Click += new System.EventHandler(this.tsmLogsDir_Click);
            // 
            // tsmTemplates
            // 
            this.tsmTemplates.Name = "tsmTemplates";
            this.tsmTemplates.Size = new System.Drawing.Size(146, 22);
            this.tsmTemplates.Text = "Templates...";
            this.tsmTemplates.Click += new System.EventHandler(this.tsmTemplates_Click);
            // 
            // tsmTorrentsDir
            // 
            this.tsmTorrentsDir.Name = "tsmTorrentsDir";
            this.tsmTorrentsDir.Size = new System.Drawing.Size(146, 22);
            this.tsmTorrentsDir.Text = "&Torrents...";
            this.tsmTorrentsDir.Click += new System.EventHandler(this.tsmTorrentsDir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmUpdatesCheck
            // 
            this.tsmUpdatesCheck.Name = "tsmUpdatesCheck";
            this.tsmUpdatesCheck.Size = new System.Drawing.Size(180, 22);
            this.tsmUpdatesCheck.Text = "Check for &Updates...";
            this.tsmUpdatesCheck.Click += new System.EventHandler(this.tsmUpdatesCheck_Click);
            // 
            // tmsVersionHistory
            // 
            this.tmsVersionHistory.Name = "tmsVersionHistory";
            this.tmsVersionHistory.Size = new System.Drawing.Size(180, 22);
            this.tmsVersionHistory.Text = "&Version History...";
            this.tmsVersionHistory.Click += new System.EventHandler(this.tmsVersionHistory_Click);
            // 
            // cmsAppAbout
            // 
            this.cmsAppAbout.Name = "cmsAppAbout";
            this.cmsAppAbout.Size = new System.Drawing.Size(180, 22);
            this.cmsAppAbout.Text = "&About...";
            this.cmsAppAbout.Click += new System.EventHandler(this.cmsAppAbout_Click);
            // 
            // btnCreateTorrent
            // 
            this.btnCreateTorrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateTorrent.AutoSize = true;
            this.btnCreateTorrent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCreateTorrent.Location = new System.Drawing.Point(138, 505);
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
            this.pbLogo.Location = new System.Drawing.Point(242, 497);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(356, 40);
            this.pbLogo.TabIndex = 11;
            this.pbLogo.TabStop = false;
            // 
            // chkTitle
            // 
            this.chkTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkTitle.AutoSize = true;
            this.chkTitle.Checked = global::TDMaker.Properties.Settings.Default.bTitle;
            this.chkTitle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTitle.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "bTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkTitle.Location = new System.Drawing.Point(22, 60);
            this.chkTitle.Name = "chkTitle";
            this.chkTitle.Size = new System.Drawing.Size(49, 17);
            this.chkTitle.TabIndex = 14;
            this.chkTitle.Text = "&Title:";
            this.chkTitle.UseVisualStyleBackColor = true;
            // 
            // chkWebLink
            // 
            this.chkWebLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkWebLink.AutoSize = true;
            this.chkWebLink.Checked = global::TDMaker.Properties.Settings.Default.WebLink;
            this.chkWebLink.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "WebLink", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkWebLink.Location = new System.Drawing.Point(22, 90);
            this.chkWebLink.Name = "chkWebLink";
            this.chkWebLink.Size = new System.Drawing.Size(75, 17);
            this.chkWebLink.TabIndex = 9;
            this.chkWebLink.Text = "&Web Link:";
            this.chkWebLink.UseVisualStyleBackColor = true;
            // 
            // chkSource
            // 
            this.chkSource.AutoSize = true;
            this.chkSource.Checked = global::TDMaker.Properties.Settings.Default.bSource;
            this.chkSource.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSource.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "bSource", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkSource.Location = new System.Drawing.Point(22, 31);
            this.chkSource.Name = "chkSource";
            this.chkSource.Size = new System.Drawing.Size(60, 17);
            this.chkSource.TabIndex = 13;
            this.chkSource.Text = "&Source";
            this.chkSource.UseVisualStyleBackColor = true;
            // 
            // cboSource
            // 
            this.cboSource.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TDMaker.Properties.Settings.Default, "Source", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboSource.FormattingEnabled = true;
            this.cboSource.Location = new System.Drawing.Point(117, 29);
            this.cboSource.Name = "cboSource";
            this.cboSource.Size = new System.Drawing.Size(121, 21);
            this.cboSource.TabIndex = 0;
            this.cboSource.Text = global::TDMaker.Properties.Settings.Default.Source;
            // 
            // cboDiscMenu
            // 
            this.cboDiscMenu.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TDMaker.Properties.Settings.Default, "DiscMenu", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboDiscMenu.FormattingEnabled = true;
            this.cboDiscMenu.Location = new System.Drawing.Point(121, 58);
            this.cboDiscMenu.Name = "cboDiscMenu";
            this.cboDiscMenu.Size = new System.Drawing.Size(121, 21);
            this.cboDiscMenu.TabIndex = 18;
            this.cboDiscMenu.Text = global::TDMaker.Properties.Settings.Default.DiscMenu;
            // 
            // chkDiscMenu
            // 
            this.chkDiscMenu.AutoSize = true;
            this.chkDiscMenu.Checked = global::TDMaker.Properties.Settings.Default.bDiscMenu;
            this.chkDiscMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDiscMenu.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "bDiscMenu", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkDiscMenu.Location = new System.Drawing.Point(26, 60);
            this.chkDiscMenu.Name = "chkDiscMenu";
            this.chkDiscMenu.Size = new System.Drawing.Size(56, 17);
            this.chkDiscMenu.TabIndex = 17;
            this.chkDiscMenu.Text = "Menu:";
            this.chkDiscMenu.UseVisualStyleBackColor = true;
            // 
            // cboExtras
            // 
            this.cboExtras.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TDMaker.Properties.Settings.Default, "ExtrasMode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboExtras.FormattingEnabled = true;
            this.cboExtras.Location = new System.Drawing.Point(121, 86);
            this.cboExtras.Name = "cboExtras";
            this.cboExtras.Size = new System.Drawing.Size(121, 21);
            this.cboExtras.TabIndex = 16;
            this.cboExtras.Text = global::TDMaker.Properties.Settings.Default.ExtrasMode;
            // 
            // chkExtras
            // 
            this.chkExtras.AutoSize = true;
            this.chkExtras.Checked = global::TDMaker.Properties.Settings.Default.bExtras;
            this.chkExtras.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExtras.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "bExtras", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkExtras.Location = new System.Drawing.Point(26, 88);
            this.chkExtras.Name = "chkExtras";
            this.chkExtras.Size = new System.Drawing.Size(58, 17);
            this.chkExtras.TabIndex = 15;
            this.chkExtras.Text = "E&xtras:";
            this.chkExtras.UseVisualStyleBackColor = true;
            // 
            // cboAuthoring
            // 
            this.cboAuthoring.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TDMaker.Properties.Settings.Default, "SourceEdit", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboAuthoring.FormattingEnabled = true;
            this.cboAuthoring.Location = new System.Drawing.Point(121, 29);
            this.cboAuthoring.Name = "cboAuthoring";
            this.cboAuthoring.Size = new System.Drawing.Size(121, 21);
            this.cboAuthoring.TabIndex = 14;
            this.cboAuthoring.Text = global::TDMaker.Properties.Settings.Default.SourceEdit;
            // 
            // chkSourceEdit
            // 
            this.chkSourceEdit.AutoSize = true;
            this.chkSourceEdit.Checked = global::TDMaker.Properties.Settings.Default.bVideoEdits;
            this.chkSourceEdit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSourceEdit.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "bVideoEdits", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkSourceEdit.Location = new System.Drawing.Point(26, 32);
            this.chkSourceEdit.Name = "chkSourceEdit";
            this.chkSourceEdit.Size = new System.Drawing.Size(74, 17);
            this.chkSourceEdit.TabIndex = 13;
            this.chkSourceEdit.Text = "Authoring:";
            this.chkSourceEdit.UseVisualStyleBackColor = true;
            // 
            // rbDir
            // 
            this.rbDir.AutoSize = true;
            this.rbDir.Checked = global::TDMaker.Properties.Settings.Default.BrowseDir;
            this.rbDir.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "BrowseDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rbDir.Location = new System.Drawing.Point(232, 27);
            this.rbDir.Name = "rbDir";
            this.rbDir.Size = new System.Drawing.Size(80, 17);
            this.rbDir.TabIndex = 9;
            this.rbDir.TabStop = true;
            this.rbDir.Text = "&DVD Folder";
            this.rbDir.UseVisualStyleBackColor = true;
            this.rbDir.CheckedChanged += new System.EventHandler(this.rbDir_CheckedChanged);
            // 
            // chkScreenshot
            // 
            this.chkScreenshot.AutoSize = true;
            this.chkScreenshot.Checked = global::TDMaker.Properties.Settings.Default.TakeScreenshot;
            this.chkScreenshot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScreenshot.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "TakeScreenshot", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkScreenshot.Location = new System.Drawing.Point(122, 16);
            this.chkScreenshot.Name = "chkScreenshot";
            this.chkScreenshot.Size = new System.Drawing.Size(114, 17);
            this.chkScreenshot.TabIndex = 11;
            this.chkScreenshot.Text = "&Create Screenshot";
            this.chkScreenshot.UseVisualStyleBackColor = true;
            this.chkScreenshot.CheckedChanged += new System.EventHandler(this.chkScreenshot_CheckedChanged);
            // 
            // chkUpdateCheck
            // 
            this.chkUpdateCheck.AutoSize = true;
            this.chkUpdateCheck.Checked = global::TDMaker.Properties.Settings.Default.UpdateCheckAuto;
            this.chkUpdateCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdateCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "UpdateCheckAuto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkUpdateCheck.Location = new System.Drawing.Point(20, 43);
            this.chkUpdateCheck.Name = "chkUpdateCheck";
            this.chkUpdateCheck.Size = new System.Drawing.Size(180, 17);
            this.chkUpdateCheck.TabIndex = 12;
            this.chkUpdateCheck.Text = "Automatically Check for Updates";
            this.chkUpdateCheck.UseVisualStyleBackColor = true;
            // 
            // chkAnalyzeAuto
            // 
            this.chkAnalyzeAuto.AutoSize = true;
            this.chkAnalyzeAuto.Checked = global::TDMaker.Properties.Settings.Default.AnalyzeAuto;
            this.chkAnalyzeAuto.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "AnalyzeAuto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkAnalyzeAuto.Location = new System.Drawing.Point(20, 20);
            this.chkAnalyzeAuto.Name = "chkAnalyzeAuto";
            this.chkAnalyzeAuto.Size = new System.Drawing.Size(270, 17);
            this.chkAnalyzeAuto.TabIndex = 9;
            this.chkAnalyzeAuto.Text = "&Process media immediately after loading file or folder";
            this.chkAnalyzeAuto.UseVisualStyleBackColor = true;
            // 
            // nudFontSizeIncr
            // 
            this.nudFontSizeIncr.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::TDMaker.Properties.Settings.Default, "FontSizeIncr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudFontSizeIncr.Location = new System.Drawing.Point(319, 55);
            this.nudFontSizeIncr.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFontSizeIncr.Name = "nudFontSizeIncr";
            this.nudFontSizeIncr.Size = new System.Drawing.Size(55, 20);
            this.nudFontSizeIncr.TabIndex = 9;
            this.nudFontSizeIncr.Value = global::TDMaker.Properties.Settings.Default.FontSizeIncr;
            // 
            // chkPre
            // 
            this.chkPre.AutoSize = true;
            this.chkPre.Checked = global::TDMaker.Properties.Settings.Default.PreText;
            this.chkPre.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "PreText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkPre.Location = new System.Drawing.Point(17, 56);
            this.chkPre.Name = "chkPre";
            this.chkPre.Size = new System.Drawing.Size(132, 17);
            this.chkPre.TabIndex = 1;
            this.chkPre.Text = "Use Preformatted Text";
            this.chkPre.UseVisualStyleBackColor = true;
            // 
            // chkPreIncreaseFontSize
            // 
            this.chkPreIncreaseFontSize.AutoSize = true;
            this.chkPreIncreaseFontSize.Checked = global::TDMaker.Properties.Settings.Default.LargerPreText;
            this.chkPreIncreaseFontSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreIncreaseFontSize.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "LargerPreText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkPreIncreaseFontSize.Location = new System.Drawing.Point(165, 56);
            this.chkPreIncreaseFontSize.Name = "chkPreIncreaseFontSize";
            this.chkPreIncreaseFontSize.Size = new System.Drawing.Size(148, 17);
            this.chkPreIncreaseFontSize.TabIndex = 8;
            this.chkPreIncreaseFontSize.Text = "and increase Font Size by";
            this.chkPreIncreaseFontSize.UseVisualStyleBackColor = true;
            // 
            // chkAlignCenter
            // 
            this.chkAlignCenter.AutoSize = true;
            this.chkAlignCenter.Checked = global::TDMaker.Properties.Settings.Default.AlignCenter;
            this.chkAlignCenter.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "AlignCenter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkAlignCenter.Location = new System.Drawing.Point(17, 33);
            this.chkAlignCenter.Name = "chkAlignCenter";
            this.chkAlignCenter.Size = new System.Drawing.Size(83, 17);
            this.chkAlignCenter.TabIndex = 0;
            this.chkAlignCenter.Text = "Align &Center";
            this.chkAlignCenter.UseVisualStyleBackColor = true;
            // 
            // nudFontSizeHeading1
            // 
            this.nudFontSizeHeading1.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::TDMaker.Properties.Settings.Default, "FontSizeHeading1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudFontSizeHeading1.Location = new System.Drawing.Point(106, 30);
            this.nudFontSizeHeading1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFontSizeHeading1.Name = "nudFontSizeHeading1";
            this.nudFontSizeHeading1.Size = new System.Drawing.Size(55, 20);
            this.nudFontSizeHeading1.TabIndex = 10;
            this.nudFontSizeHeading1.Value = global::TDMaker.Properties.Settings.Default.FontSizeHeading1;
            // 
            // nudHeading2Size
            // 
            this.nudHeading2Size.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::TDMaker.Properties.Settings.Default, "FontSizeHeading2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudHeading2Size.Location = new System.Drawing.Point(106, 53);
            this.nudHeading2Size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeading2Size.Name = "nudHeading2Size";
            this.nudHeading2Size.Size = new System.Drawing.Size(55, 20);
            this.nudHeading2Size.TabIndex = 8;
            this.nudHeading2Size.Value = global::TDMaker.Properties.Settings.Default.FontSizeHeading2;
            // 
            // nudHeading3Size
            // 
            this.nudHeading3Size.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::TDMaker.Properties.Settings.Default, "FontSizeHeading3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudHeading3Size.Location = new System.Drawing.Point(106, 79);
            this.nudHeading3Size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeading3Size.Name = "nudHeading3Size";
            this.nudHeading3Size.Size = new System.Drawing.Size(55, 20);
            this.nudHeading3Size.TabIndex = 4;
            this.nudHeading3Size.Value = global::TDMaker.Properties.Settings.Default.FontSizeHeading3;
            // 
            // nudBodyText
            // 
            this.nudBodyText.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::TDMaker.Properties.Settings.Default, "FontSizeBody", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudBodyText.Location = new System.Drawing.Point(106, 105);
            this.nudBodyText.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBodyText.Name = "nudBodyText";
            this.nudBodyText.Size = new System.Drawing.Size(55, 20);
            this.nudBodyText.TabIndex = 5;
            this.nudBodyText.Value = global::TDMaker.Properties.Settings.Default.FontSizeBody;
            // 
            // chkUploadFullScreenshot
            // 
            this.chkUploadFullScreenshot.AutoSize = true;
            this.chkUploadFullScreenshot.Checked = global::TDMaker.Properties.Settings.Default.UseFullPicture;
            this.chkUploadFullScreenshot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUploadFullScreenshot.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "UseFullPicture", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkUploadFullScreenshot.Location = new System.Drawing.Point(16, 41);
            this.chkUploadFullScreenshot.Name = "chkUploadFullScreenshot";
            this.chkUploadFullScreenshot.Size = new System.Drawing.Size(200, 17);
            this.chkUploadFullScreenshot.TabIndex = 1;
            this.chkUploadFullScreenshot.Text = "Use &Full Image instead of Thumbnail ";
            this.chkUploadFullScreenshot.UseVisualStyleBackColor = true;
            // 
            // chkTemplatesMode
            // 
            this.chkTemplatesMode.AutoSize = true;
            this.chkTemplatesMode.Checked = global::TDMaker.Properties.Settings.Default.TemplatesMode;
            this.chkTemplatesMode.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "TemplatesMode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkTemplatesMode.Location = new System.Drawing.Point(16, 16);
            this.chkTemplatesMode.Name = "chkTemplatesMode";
            this.chkTemplatesMode.Size = new System.Drawing.Size(230, 17);
            this.chkTemplatesMode.TabIndex = 0;
            this.chkTemplatesMode.Text = "Create description using External &Template:";
            this.chkTemplatesMode.UseVisualStyleBackColor = true;
            this.chkTemplatesMode.CheckedChanged += new System.EventHandler(this.chkTemplatesMode_CheckedChanged);
            // 
            // chkUseImageShackRegCode
            // 
            this.chkUseImageShackRegCode.AutoSize = true;
            this.chkUseImageShackRegCode.Checked = global::TDMaker.Properties.Settings.Default.UseImageShackRegCode;
            this.chkUseImageShackRegCode.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "UseImageShackRegCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkUseImageShackRegCode.Location = new System.Drawing.Point(14, 41);
            this.chkUseImageShackRegCode.Name = "chkUseImageShackRegCode";
            this.chkUseImageShackRegCode.Size = new System.Drawing.Size(135, 17);
            this.chkUseImageShackRegCode.TabIndex = 5;
            this.chkUseImageShackRegCode.Text = "Use Registration Code:";
            this.chkUseImageShackRegCode.UseVisualStyleBackColor = true;
            // 
            // txtImageShackRegCode
            // 
            this.txtImageShackRegCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TDMaker.Properties.Settings.Default, "ImageShackRegCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtImageShackRegCode.Location = new System.Drawing.Point(155, 38);
            this.txtImageShackRegCode.Name = "txtImageShackRegCode";
            this.txtImageShackRegCode.Size = new System.Drawing.Size(298, 20);
            this.txtImageShackRegCode.TabIndex = 4;
            this.txtImageShackRegCode.Text = global::TDMaker.Properties.Settings.Default.ImageShackRegCode;
            // 
            // chkRandomizeFileNameImageShack
            // 
            this.chkRandomizeFileNameImageShack.AutoSize = true;
            this.chkRandomizeFileNameImageShack.Checked = global::TDMaker.Properties.Settings.Default.ImageShakeRandomizeFileName;
            this.chkRandomizeFileNameImageShack.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "ImageShakeRandomizeFileName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkRandomizeFileNameImageShack.Location = new System.Drawing.Point(14, 18);
            this.chkRandomizeFileNameImageShack.Name = "chkRandomizeFileNameImageShack";
            this.chkRandomizeFileNameImageShack.Size = new System.Drawing.Size(207, 17);
            this.chkRandomizeFileNameImageShack.TabIndex = 3;
            this.chkRandomizeFileNameImageShack.Text = "Randomize File Name for ImageShack";
            this.chkRandomizeFileNameImageShack.UseVisualStyleBackColor = true;
            // 
            // chkKeepScreenshot
            // 
            this.chkKeepScreenshot.AutoSize = true;
            this.chkKeepScreenshot.Checked = global::TDMaker.Properties.Settings.Default.KeepScreenshot;
            this.chkKeepScreenshot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeepScreenshot.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "KeepScreenshot", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkKeepScreenshot.Location = new System.Drawing.Point(18, 23);
            this.chkKeepScreenshot.Name = "chkKeepScreenshot";
            this.chkKeepScreenshot.Size = new System.Drawing.Size(189, 17);
            this.chkKeepScreenshot.TabIndex = 1;
            this.chkKeepScreenshot.Text = "Keep Screenshot in Pictures\\MTN";
            this.chkKeepScreenshot.UseVisualStyleBackColor = true;
            // 
            // chkOptImageShack
            // 
            this.chkOptImageShack.AutoSize = true;
            this.chkOptImageShack.Checked = global::TDMaker.Properties.Settings.Default.UploadScreenshot;
            this.chkOptImageShack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOptImageShack.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "UploadScreenshot", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkOptImageShack.Location = new System.Drawing.Point(328, 23);
            this.chkOptImageShack.Name = "chkOptImageShack";
            this.chkOptImageShack.Size = new System.Drawing.Size(129, 17);
            this.chkOptImageShack.TabIndex = 0;
            this.chkOptImageShack.Text = "Upload Screenshot to";
            this.chkOptImageShack.UseVisualStyleBackColor = true;
            this.chkOptImageShack.CheckedChanged += new System.EventHandler(this.chkOptImageShack_CheckedChanged);
            // 
            // cboMTNFont
            // 
            this.cboMTNFont.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMTNFont.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.cboMTNFont.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TDMaker.Properties.Settings.Default, "MTNFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboMTNFont.FormattingEnabled = true;
            this.cboMTNFont.Location = new System.Drawing.Point(114, 81);
            this.cboMTNFont.Name = "cboMTNFont";
            this.cboMTNFont.Size = new System.Drawing.Size(214, 21);
            this.cboMTNFont.TabIndex = 12;
            this.cboMTNFont.Text = global::TDMaker.Properties.Settings.Default.MTNFont;
            this.cboMTNFont.Visible = false;
            // 
            // chkShowMTN
            // 
            this.chkShowMTN.AutoSize = true;
            this.chkShowMTN.Checked = global::TDMaker.Properties.Settings.Default.ShowMTNWindow;
            this.chkShowMTN.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "ShowMTNWindow", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkShowMTN.Location = new System.Drawing.Point(440, 81);
            this.chkShowMTN.Name = "chkShowMTN";
            this.chkShowMTN.Size = new System.Drawing.Size(122, 17);
            this.chkShowMTN.TabIndex = 11;
            this.chkShowMTN.Text = "Show &MTN Window";
            this.chkShowMTN.UseVisualStyleBackColor = true;
            // 
            // cboMtnArgs
            // 
            this.cboMtnArgs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMtnArgs.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TDMaker.Properties.Settings.Default, "MTNArg", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboMtnArgs.FormattingEnabled = true;
            this.cboMtnArgs.Location = new System.Drawing.Point(114, 54);
            this.cboMtnArgs.Name = "cboMtnArgs";
            this.cboMtnArgs.Size = new System.Drawing.Size(448, 21);
            this.cboMtnArgs.TabIndex = 7;
            this.cboMtnArgs.Text = global::TDMaker.Properties.Settings.Default.MTNArg;
            // 
            // txtMtn
            // 
            this.txtMtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMtn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtMtn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtMtn.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TDMaker.Properties.Settings.Default, "MTNPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtMtn.Location = new System.Drawing.Point(114, 25);
            this.txtMtn.Name = "txtMtn";
            this.txtMtn.Size = new System.Drawing.Size(448, 20);
            this.txtMtn.TabIndex = 0;
            this.txtMtn.Text = global::TDMaker.Properties.Settings.Default.MTNPath;
            // 
            // chkWritePublish
            // 
            this.chkWritePublish.AutoSize = true;
            this.chkWritePublish.Checked = global::TDMaker.Properties.Settings.Default.WritePublish;
            this.chkWritePublish.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "WritePublish", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkWritePublish.Location = new System.Drawing.Point(19, 91);
            this.chkWritePublish.Name = "chkWritePublish";
            this.chkWritePublish.Size = new System.Drawing.Size(241, 17);
            this.chkWritePublish.TabIndex = 5;
            this.chkWritePublish.Text = "Write Publish Information of the Torrent to File";
            this.chkWritePublish.UseVisualStyleBackColor = true;
            // 
            // chkTorrentOrganize
            // 
            this.chkTorrentOrganize.AutoSize = true;
            this.chkTorrentOrganize.Checked = global::TDMaker.Properties.Settings.Default.TorrentsOrganize;
            this.chkTorrentOrganize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTorrentOrganize.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "TorrentsOrganize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkTorrentOrganize.Location = new System.Drawing.Point(114, 67);
            this.chkTorrentOrganize.Name = "chkTorrentOrganize";
            this.chkTorrentOrganize.Size = new System.Drawing.Size(293, 17);
            this.chkTorrentOrganize.TabIndex = 4;
            this.chkTorrentOrganize.Text = "Create torrents in sub-folders according to Tracker Name";
            this.chkTorrentOrganize.UseVisualStyleBackColor = true;
            // 
            // txtTorrentCustomFolder
            // 
            this.txtTorrentCustomFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTorrentCustomFolder.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TDMaker.Properties.Settings.Default, "TorrentsCustomDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtTorrentCustomFolder.Location = new System.Drawing.Point(114, 41);
            this.txtTorrentCustomFolder.Name = "txtTorrentCustomFolder";
            this.txtTorrentCustomFolder.Size = new System.Drawing.Size(480, 20);
            this.txtTorrentCustomFolder.TabIndex = 2;
            this.txtTorrentCustomFolder.Text = global::TDMaker.Properties.Settings.Default.TorrentsCustomDir;
            // 
            // rbTorrentDefaultFolder
            // 
            this.rbTorrentDefaultFolder.AutoSize = true;
            this.rbTorrentDefaultFolder.Checked = global::TDMaker.Properties.Settings.Default.TorrentFolderDefault;
            this.rbTorrentDefaultFolder.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "TorrentFolderDefault", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rbTorrentDefaultFolder.Location = new System.Drawing.Point(19, 19);
            this.rbTorrentDefaultFolder.Name = "rbTorrentDefaultFolder";
            this.rbTorrentDefaultFolder.Size = new System.Drawing.Size(147, 17);
            this.rbTorrentDefaultFolder.TabIndex = 0;
            this.rbTorrentDefaultFolder.TabStop = true;
            this.rbTorrentDefaultFolder.Text = "Parent folder of the Media";
            this.rbTorrentDefaultFolder.UseVisualStyleBackColor = true;
            // 
            // chkCreateTorrent
            // 
            this.chkCreateTorrent.AutoSize = true;
            this.chkCreateTorrent.Checked = global::TDMaker.Properties.Settings.Default.CreateTorrent;
            this.chkCreateTorrent.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "CreateTorrent", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkCreateTorrent.Location = new System.Drawing.Point(17, 14);
            this.chkCreateTorrent.Name = "chkCreateTorrent";
            this.chkCreateTorrent.Size = new System.Drawing.Size(182, 17);
            this.chkCreateTorrent.TabIndex = 0;
            this.chkCreateTorrent.Text = "Automatically create &torrent using";
            this.chkCreateTorrent.UseVisualStyleBackColor = true;
            // 
            // pbScreenshot
            // 
            this.pbScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbScreenshot.Location = new System.Drawing.Point(20, 368);
            this.pbScreenshot.Name = "pbScreenshot";
            this.pbScreenshot.Size = new System.Drawing.Size(724, 70);
            this.pbScreenshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbScreenshot.TabIndex = 12;
            this.pbScreenshot.TabStop = false;
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnBrowse;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.ContextMenuStrip = this.cmsApp;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCreateTorrent);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.btnPublish);
            this.Controls.Add(this.tcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Torrent Description Maker";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmMain_DragEnter);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbScreenshotFull.ResumeLayout(false);
            this.gbScreenshotFull.PerformLayout();
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
            this.tpMediaInfo.ResumeLayout(false);
            this.tpMediaInfo.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.gbQuickPublish.ResumeLayout(false);
            this.gbQuickPublish.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tcOptions.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tpGeneral.PerformLayout();
            this.tpPublish.ResumeLayout(false);
            this.tpPublish.PerformLayout();
            this.gbTemplatesInternal.ResumeLayout(false);
            this.gbTemplatesInternal.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tpScreenshots.ResumeLayout(false);
            this.tcHosting.ResumeLayout(false);
            this.tpHostingImageShack.ResumeLayout(false);
            this.tpHostingImageShack.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tpTorrents.ResumeLayout(false);
            this.tpTorrents.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrackers)).EndInit();
            this.cmsApp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSizeIncr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSizeHeading1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeading2Size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeading3Size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBodyText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbScreenshot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMtn;
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
        private System.Windows.Forms.TabPage tpMediaInfo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboMtnArgs;
        private System.Windows.Forms.Timer tmrStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCopy2;
        private System.Windows.Forms.TextBox txtBBScrForums;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCopy0;
        private System.Windows.Forms.TextBox txtMediaInfo;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.GroupBox gbLocation;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox chkOptImageShack;
        private System.Windows.Forms.CheckBox chkUploadFullScreenshot;
        private System.Windows.Forms.GroupBox gbTemplatesInternal;
        private System.Windows.Forms.CheckBox chkAlignCenter;
        private System.Windows.Forms.CheckBox chkPre;
        private System.Windows.Forms.NumericUpDown nudBodyText;
        private System.Windows.Forms.NumericUpDown nudHeading3Size;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudFontSizeIncr;
        private System.Windows.Forms.CheckBox chkPreIncreaseFontSize;
        private System.Windows.Forms.ComboBox cboSource;
        private System.Windows.Forms.CheckBox chkKeepScreenshot;
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
        private System.Windows.Forms.CheckBox chkAnalyzeAuto;
        private System.Windows.Forms.DataGridView dgvTrackers;
        private System.Windows.Forms.CheckBox chkCreateTorrent;
        private System.Windows.Forms.ComboBox cboAnnounceURL;
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
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox chkTorrentOrganize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnnounceURL;
        private System.Windows.Forms.ListBox lbStatus;
        private System.Windows.Forms.Button btnBrowseMTN;
        private System.Windows.Forms.TextBox txtPublish;
        private System.Windows.Forms.NumericUpDown nudHeading2Size;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudFontSizeHeading1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbQuickPublish;
        private System.Windows.Forms.CheckBox chkQuickAlignCenter;
        private System.Windows.Forms.CheckBox chkQuickPre;
        private System.Windows.Forms.CheckBox chkQuickFullPicture;
        private System.Windows.Forms.CheckBox chkSourceEdit;
        private System.Windows.Forms.ComboBox cboAuthoring;
        private System.Windows.Forms.ComboBox cboExtras;
        private System.Windows.Forms.CheckBox chkExtras;
        private System.Windows.Forms.CheckBox chkWritePublish;
        private System.Windows.Forms.ComboBox cboDiscMenu;
        private System.Windows.Forms.CheckBox chkDiscMenu;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.CheckBox chkTemplatesMode;
        private System.Windows.Forms.ComboBox cboTemplate;
        private System.Windows.Forms.Button btnMTNHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem foldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmTorrentsDir;
        private System.Windows.Forms.ToolStripMenuItem tsmScreenshots;
        private System.Windows.Forms.CheckBox chkScreenshot;
        private System.Windows.Forms.ToolStripMenuItem tsmTemplates;
        private System.Windows.Forms.ToolStripMenuItem tsmUpdatesCheck;
        private System.Windows.Forms.ComboBox cboScreenshotDest;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.CheckBox chkUpdateCheck;
        private System.Windows.Forms.CheckBox chkRandomizeFileNameImageShack;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ToolStripMenuItem tsmLogsDir;
        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.CheckBox chkSource;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ToolStripStatusLabel tssPerc;
        private System.Windows.Forms.ListBox lbScreenshots;
        private System.Windows.Forms.Button btnTemplatesRewrite;
        private System.Windows.Forms.CheckBox chkShowMTN;
        private System.Windows.Forms.TabControl tcHosting;
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
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboMTNFont;
        private System.Windows.Forms.PictureBox pbScreenshot;
    }
}

