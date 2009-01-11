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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowseMTN = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtScrFull = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCopy0 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
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
            this.pBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.gbProperties = new System.Windows.Forms.GroupBox();
            this.txtWebLink = new System.Windows.Forms.TextBox();
            this.lbStatus = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbDir = new System.Windows.Forms.RadioButton();
            this.rbFile = new System.Windows.Forms.RadioButton();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtMediaLocation = new System.Windows.Forms.TextBox();
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtMediaInfo = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtPublish = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tcOptions = new System.Windows.Forms.TabControl();
            this.tpScreenshots = new System.Windows.Forms.TabPage();
            this.tpTorrents = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnBrowseTorrentCustomFolder = new System.Windows.Forms.Button();
            this.rbTorrentFolderCustom = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dgvTrackers = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnnounceURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpPublish = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tmrStatus = new System.Windows.Forms.Timer(this.components);
            this.btnPublish = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.cmsApp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsAppAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreateTorrent = new System.Windows.Forms.Button();
            this.gbQuickPublish = new System.Windows.Forms.GroupBox();
            this.chkQuickPre = new System.Windows.Forms.CheckBox();
            this.chkQuickAlignCenter = new System.Windows.Forms.CheckBox();
            this.chkWebLink = new System.Windows.Forms.CheckBox();
            this.cboSource = new System.Windows.Forms.ComboBox();
            this.chkAnalyzeAuto = new System.Windows.Forms.CheckBox();
            this.chkKeepScreenshot = new System.Windows.Forms.CheckBox();
            this.chkOptImageShack = new System.Windows.Forms.CheckBox();
            this.cboMtnArgs = new System.Windows.Forms.ComboBox();
            this.txtMtn = new System.Windows.Forms.TextBox();
            this.chkTorrentOrganize = new System.Windows.Forms.CheckBox();
            this.txtTorrentCustomFolder = new System.Windows.Forms.TextBox();
            this.rbTorrentDefaultFolder = new System.Windows.Forms.RadioButton();
            this.cboAnnounceURL = new System.Windows.Forms.ComboBox();
            this.chkCreateTorrent = new System.Windows.Forms.CheckBox();
            this.chkUploadFullScreenshot = new System.Windows.Forms.CheckBox();
            this.nudFontSizeIncr = new System.Windows.Forms.NumericUpDown();
            this.chkPre = new System.Windows.Forms.CheckBox();
            this.chkPreIncreaseFontSize = new System.Windows.Forms.CheckBox();
            this.chkAlignCenter = new System.Windows.Forms.CheckBox();
            this.nudFontSizeHeading1 = new System.Windows.Forms.NumericUpDown();
            this.nudHeading2Size = new System.Windows.Forms.NumericUpDown();
            this.nudHeading3Size = new System.Windows.Forms.NumericUpDown();
            this.nudBodyText = new System.Windows.Forms.NumericUpDown();
            this.chkQuickFullPicture = new System.Windows.Forms.CheckBox();
            this.trackerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.gbProperties.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbSource.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tcOptions.SuspendLayout();
            this.tpScreenshots.SuspendLayout();
            this.tpTorrents.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrackers)).BeginInit();
            this.tpPublish.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.cmsApp.SuspendLayout();
            this.gbQuickPublish.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSizeIncr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSizeHeading1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeading2Size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeading3Size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBodyText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnBrowseMTN);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboMtnArgs);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMtn);
            this.groupBox1.Location = new System.Drawing.Point(15, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(720, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Movie Thumbnailer Settings";
            // 
            // btnBrowseMTN
            // 
            this.btnBrowseMTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseMTN.Location = new System.Drawing.Point(577, 23);
            this.btnBrowseMTN.Name = "btnBrowseMTN";
            this.btnBrowseMTN.Size = new System.Drawing.Size(106, 23);
            this.btnBrowseMTN.TabIndex = 9;
            this.btnBrowseMTN.Text = "&Browse";
            this.btnBrowseMTN.UseVisualStyleBackColor = true;
            this.btnBrowseMTN.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Arguments:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "MTN Path:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtScrFull);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnCopy0);
            this.groupBox2.Location = new System.Drawing.Point(16, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(724, 79);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "URL for IRC/IM";
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
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnCopy2);
            this.groupBox3.Controls.Add(this.txtBBScrForums);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnCopy1);
            this.groupBox3.Controls.Add(this.txtBBScrFull);
            this.groupBox3.Location = new System.Drawing.Point(16, 101);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(724, 124);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "URL for Forums";
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
            this.pBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sbarIcon
            // 
            this.sbarIcon.Image = global::TDMaker.Properties.Resources.info_16_xp;
            this.sbarIcon.Name = "sbarIcon";
            this.sbarIcon.Size = new System.Drawing.Size(16, 17);
            // 
            // sBar
            // 
            this.sBar.Name = "sBar";
            this.sBar.Size = new System.Drawing.Size(659, 17);
            this.sBar.Spring = true;
            this.sBar.Text = "Ready";
            this.sBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pBar
            // 
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(100, 16);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(768, 487);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.gbProperties);
            this.tabPage5.Controls.Add(this.groupBox4);
            this.tabPage5.Controls.Add(this.gbSource);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(760, 461);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Media";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // gbProperties
            // 
            this.gbProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbProperties.Controls.Add(this.txtWebLink);
            this.gbProperties.Controls.Add(this.lbStatus);
            this.gbProperties.Controls.Add(this.chkWebLink);
            this.gbProperties.Location = new System.Drawing.Point(12, 111);
            this.gbProperties.Name = "gbProperties";
            this.gbProperties.Size = new System.Drawing.Size(732, 326);
            this.gbProperties.TabIndex = 11;
            this.gbProperties.TabStop = false;
            this.gbProperties.Text = "Properties";
            // 
            // txtWebLink
            // 
            this.txtWebLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWebLink.Location = new System.Drawing.Point(108, 20);
            this.txtWebLink.Name = "txtWebLink";
            this.txtWebLink.Size = new System.Drawing.Size(579, 20);
            this.txtWebLink.TabIndex = 10;
            // 
            // lbStatus
            // 
            this.lbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lbStatus.FormattingEnabled = true;
            this.lbStatus.Location = new System.Drawing.Point(26, 208);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.ScrollAlwaysVisible = true;
            this.lbStatus.Size = new System.Drawing.Size(670, 56);
            this.lbStatus.TabIndex = 11;
            this.lbStatus.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.rbDir);
            this.groupBox4.Controls.Add(this.rbFile);
            this.groupBox4.Controls.Add(this.btnBrowse);
            this.groupBox4.Controls.Add(this.txtMediaLocation);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(568, 93);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Location";
            // 
            // rbDir
            // 
            this.rbDir.AutoSize = true;
            this.rbDir.Checked = true;
            this.rbDir.Location = new System.Drawing.Point(232, 27);
            this.rbDir.Name = "rbDir";
            this.rbDir.Size = new System.Drawing.Size(80, 17);
            this.rbDir.TabIndex = 9;
            this.rbDir.TabStop = true;
            this.rbDir.Text = "&DVD Folder";
            this.rbDir.UseVisualStyleBackColor = true;
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
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.AutoSize = true;
            this.btnBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowse.Location = new System.Drawing.Point(487, 48);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(61, 23);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "&Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtMediaLocation
            // 
            this.txtMediaLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMediaLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtMediaLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtMediaLocation.Location = new System.Drawing.Point(26, 50);
            this.txtMediaLocation.Name = "txtMediaLocation";
            this.txtMediaLocation.Size = new System.Drawing.Size(444, 20);
            this.txtMediaLocation.TabIndex = 6;
            // 
            // gbSource
            // 
            this.gbSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSource.Controls.Add(this.cboSource);
            this.gbSource.Location = new System.Drawing.Point(589, 13);
            this.gbSource.Name = "gbSource";
            this.gbSource.Size = new System.Drawing.Size(155, 92);
            this.gbSource.TabIndex = 8;
            this.gbSource.TabStop = false;
            this.gbSource.Text = "Source";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtMediaInfo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(760, 461);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Info";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.txtMediaInfo.Size = new System.Drawing.Size(754, 455);
            this.txtMediaInfo.TabIndex = 0;
            this.txtMediaInfo.WordWrap = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(760, 461);
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
            this.tabPage3.Size = new System.Drawing.Size(760, 461);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Publish";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            this.txtPublish.Size = new System.Drawing.Size(613, 455);
            this.txtPublish.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.chkAnalyzeAuto);
            this.tabPage4.Controls.Add(this.tcOptions);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(760, 461);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Options";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tcOptions
            // 
            this.tcOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcOptions.Controls.Add(this.tpScreenshots);
            this.tcOptions.Controls.Add(this.tpTorrents);
            this.tcOptions.Controls.Add(this.tpPublish);
            this.tcOptions.Location = new System.Drawing.Point(0, 49);
            this.tcOptions.Name = "tcOptions";
            this.tcOptions.SelectedIndex = 0;
            this.tcOptions.Size = new System.Drawing.Size(760, 412);
            this.tcOptions.TabIndex = 11;
            // 
            // tpScreenshots
            // 
            this.tpScreenshots.Controls.Add(this.chkKeepScreenshot);
            this.tpScreenshots.Controls.Add(this.chkOptImageShack);
            this.tpScreenshots.Controls.Add(this.groupBox1);
            this.tpScreenshots.Location = new System.Drawing.Point(4, 22);
            this.tpScreenshots.Name = "tpScreenshots";
            this.tpScreenshots.Padding = new System.Windows.Forms.Padding(3);
            this.tpScreenshots.Size = new System.Drawing.Size(752, 386);
            this.tpScreenshots.TabIndex = 0;
            this.tpScreenshots.Text = "Screenshots";
            this.tpScreenshots.UseVisualStyleBackColor = true;
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
            this.tpTorrents.Size = new System.Drawing.Size(752, 386);
            this.tpTorrents.TabIndex = 1;
            this.tpTorrents.Text = "Torrents";
            this.tpTorrents.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.chkTorrentOrganize);
            this.groupBox8.Controls.Add(this.btnBrowseTorrentCustomFolder);
            this.groupBox8.Controls.Add(this.txtTorrentCustomFolder);
            this.groupBox8.Controls.Add(this.rbTorrentFolderCustom);
            this.groupBox8.Controls.Add(this.rbTorrentDefaultFolder);
            this.groupBox8.Location = new System.Drawing.Point(17, 225);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(713, 95);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Save Location";
            // 
            // btnBrowseTorrentCustomFolder
            // 
            this.btnBrowseTorrentCustomFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseTorrentCustomFolder.Location = new System.Drawing.Point(608, 39);
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
            this.groupBox7.Size = new System.Drawing.Size(713, 180);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Tracker Manager";
            // 
            // dgvTrackers
            // 
            this.dgvTrackers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTrackers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrackers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colAnnounceURL});
            this.dgvTrackers.Location = new System.Drawing.Point(6, 19);
            this.dgvTrackers.Name = "dgvTrackers";
            this.dgvTrackers.Size = new System.Drawing.Size(701, 148);
            this.dgvTrackers.TabIndex = 1;
            this.dgvTrackers.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrackers_CellMouseLeave);
            this.dgvTrackers.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvTrackers_CellValidating);
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colName.HeaderText = "Tracker Name";
            this.colName.Name = "colName";
            // 
            // colAnnounceURL
            // 
            this.colAnnounceURL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAnnounceURL.HeaderText = "Announce URL";
            this.colAnnounceURL.Name = "colAnnounceURL";
            // 
            // tpPublish
            // 
            this.tpPublish.Controls.Add(this.groupBox5);
            this.tpPublish.Controls.Add(this.groupBox6);
            this.tpPublish.Location = new System.Drawing.Point(4, 22);
            this.tpPublish.Name = "tpPublish";
            this.tpPublish.Padding = new System.Windows.Forms.Padding(3);
            this.tpPublish.Size = new System.Drawing.Size(752, 386);
            this.tpPublish.TabIndex = 2;
            this.tpPublish.Text = "Publish";
            this.tpPublish.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkUploadFullScreenshot);
            this.groupBox5.Controls.Add(this.nudFontSizeIncr);
            this.groupBox5.Controls.Add(this.chkPre);
            this.groupBox5.Controls.Add(this.chkPreIncreaseFontSize);
            this.groupBox5.Controls.Add(this.chkAlignCenter);
            this.groupBox5.Location = new System.Drawing.Point(16, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(431, 148);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Publish Template";
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
            this.groupBox6.Location = new System.Drawing.Point(455, 16);
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
            this.btnPublish.Location = new System.Drawing.Point(612, 505);
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
            this.cmsAppAbout});
            this.cmsApp.Name = "cmsApp";
            this.cmsApp.Size = new System.Drawing.Size(116, 26);
            // 
            // cmsAppAbout
            // 
            this.cmsAppAbout.Name = "cmsAppAbout";
            this.cmsAppAbout.Size = new System.Drawing.Size(115, 22);
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
            // gbQuickPublish
            // 
            this.gbQuickPublish.Controls.Add(this.chkQuickFullPicture);
            this.gbQuickPublish.Controls.Add(this.chkQuickAlignCenter);
            this.gbQuickPublish.Controls.Add(this.chkQuickPre);
            this.gbQuickPublish.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbQuickPublish.Location = new System.Drawing.Point(625, 3);
            this.gbQuickPublish.Name = "gbQuickPublish";
            this.gbQuickPublish.Size = new System.Drawing.Size(132, 455);
            this.gbQuickPublish.TabIndex = 1;
            this.gbQuickPublish.TabStop = false;
            this.gbQuickPublish.Text = "Options";
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
            // chkWebLink
            // 
            this.chkWebLink.AutoSize = true;
            this.chkWebLink.Checked = global::TDMaker.Properties.Settings.Default.WebLink;
            this.chkWebLink.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWebLink.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "WebLink", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkWebLink.Location = new System.Drawing.Point(22, 23);
            this.chkWebLink.Name = "chkWebLink";
            this.chkWebLink.Size = new System.Drawing.Size(75, 17);
            this.chkWebLink.TabIndex = 9;
            this.chkWebLink.Text = "&Web Link:";
            this.chkWebLink.UseVisualStyleBackColor = true;
            // 
            // cboSource
            // 
            this.cboSource.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TDMaker.Properties.Settings.Default, "Source", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboSource.FormattingEnabled = true;
            this.cboSource.Location = new System.Drawing.Point(16, 49);
            this.cboSource.Name = "cboSource";
            this.cboSource.Size = new System.Drawing.Size(102, 21);
            this.cboSource.TabIndex = 0;
            this.cboSource.Text = global::TDMaker.Properties.Settings.Default.Source;
            // 
            // chkAnalyzeAuto
            // 
            this.chkAnalyzeAuto.AutoSize = true;
            this.chkAnalyzeAuto.Checked = global::TDMaker.Properties.Settings.Default.AnalyzeAuto;
            this.chkAnalyzeAuto.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "AnalyzeAuto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkAnalyzeAuto.Location = new System.Drawing.Point(12, 15);
            this.chkAnalyzeAuto.Name = "chkAnalyzeAuto";
            this.chkAnalyzeAuto.Size = new System.Drawing.Size(270, 17);
            this.chkAnalyzeAuto.TabIndex = 9;
            this.chkAnalyzeAuto.Text = "&Process media immediately after loading file or folder";
            this.chkAnalyzeAuto.UseVisualStyleBackColor = true;
            // 
            // chkKeepScreenshot
            // 
            this.chkKeepScreenshot.AutoSize = true;
            this.chkKeepScreenshot.Checked = global::TDMaker.Properties.Settings.Default.KeepScreenshot;
            this.chkKeepScreenshot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeepScreenshot.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "KeepScreenshot", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkKeepScreenshot.Location = new System.Drawing.Point(16, 39);
            this.chkKeepScreenshot.Name = "chkKeepScreenshot";
            this.chkKeepScreenshot.Size = new System.Drawing.Size(189, 17);
            this.chkKeepScreenshot.TabIndex = 1;
            this.chkKeepScreenshot.Text = "Keep Screenshot in Pictures\\MTN";
            this.chkKeepScreenshot.UseVisualStyleBackColor = true;
            // 
            // chkOptImageShack
            // 
            this.chkOptImageShack.AutoSize = true;
            this.chkOptImageShack.Checked = global::TDMaker.Properties.Settings.Default.UploadImageShack;
            this.chkOptImageShack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOptImageShack.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "UploadImageShack", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkOptImageShack.Location = new System.Drawing.Point(16, 16);
            this.chkOptImageShack.Name = "chkOptImageShack";
            this.chkOptImageShack.Size = new System.Drawing.Size(192, 17);
            this.chkOptImageShack.TabIndex = 0;
            this.chkOptImageShack.Text = "Upload Screenshot to &ImageShack";
            this.chkOptImageShack.UseVisualStyleBackColor = true;
            this.chkOptImageShack.CheckedChanged += new System.EventHandler(this.chkOptImageShack_CheckedChanged);
            // 
            // cboMtnArgs
            // 
            this.cboMtnArgs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMtnArgs.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TDMaker.Properties.Settings.Default, "MTNArg", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboMtnArgs.FormattingEnabled = true;
            this.cboMtnArgs.Location = new System.Drawing.Point(114, 54);
            this.cboMtnArgs.Name = "cboMtnArgs";
            this.cboMtnArgs.Size = new System.Drawing.Size(456, 21);
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
            this.txtMtn.Size = new System.Drawing.Size(456, 20);
            this.txtMtn.TabIndex = 0;
            this.txtMtn.Text = global::TDMaker.Properties.Settings.Default.MTNPath;
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
            this.txtTorrentCustomFolder.Size = new System.Drawing.Size(488, 20);
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
            // cboAnnounceURL
            // 
            this.cboAnnounceURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAnnounceURL.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TDMaker.Properties.Settings.Default, "AnnounceURL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboAnnounceURL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnnounceURL.FormattingEnabled = true;
            this.cboAnnounceURL.Location = new System.Drawing.Point(209, 12);
            this.cboAnnounceURL.Name = "cboAnnounceURL";
            this.cboAnnounceURL.Size = new System.Drawing.Size(521, 21);
            this.cboAnnounceURL.TabIndex = 2;
            this.cboAnnounceURL.Text = global::TDMaker.Properties.Settings.Default.AnnounceURL;
            this.cboAnnounceURL.SelectedIndexChanged += new System.EventHandler(this.cboAnnounceURL_SelectedIndexChanged);
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
            // chkUploadFullScreenshot
            // 
            this.chkUploadFullScreenshot.AutoSize = true;
            this.chkUploadFullScreenshot.Checked = global::TDMaker.Properties.Settings.Default.UseFullPicture;
            this.chkUploadFullScreenshot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUploadFullScreenshot.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "UseFullPicture", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkUploadFullScreenshot.Location = new System.Drawing.Point(17, 79);
            this.chkUploadFullScreenshot.Name = "chkUploadFullScreenshot";
            this.chkUploadFullScreenshot.Size = new System.Drawing.Size(200, 17);
            this.chkUploadFullScreenshot.TabIndex = 1;
            this.chkUploadFullScreenshot.Text = "Use &Full Image instead of Thumbnail ";
            this.chkUploadFullScreenshot.UseVisualStyleBackColor = true;
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
            // trackerBindingSource
            // 
            this.trackerBindingSource.DataSource = typeof(TDMaker.Tracker);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnBrowse;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.ContextMenuStrip = this.cmsApp;
            this.Controls.Add(this.btnCreateTorrent);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnPublish);
            this.Controls.Add(this.tabControl1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.gbProperties.ResumeLayout(false);
            this.gbProperties.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbSource.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tcOptions.ResumeLayout(false);
            this.tpScreenshots.ResumeLayout(false);
            this.tpScreenshots.PerformLayout();
            this.tpTorrents.ResumeLayout(false);
            this.tpTorrents.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrackers)).EndInit();
            this.tpPublish.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.cmsApp.ResumeLayout(false);
            this.gbQuickPublish.ResumeLayout(false);
            this.gbQuickPublish.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSizeIncr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSizeHeading1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeading2Size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeading3Size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBodyText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCopy1;
        private System.Windows.Forms.TextBox txtBBScrFull;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker bwApp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sbarIcon;
        private System.Windows.Forms.ToolStripStatusLabel sBar;
        private System.Windows.Forms.ToolStripProgressBar pBar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
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
        private System.Windows.Forms.TextBox txtMediaLocation;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox chkOptImageShack;
        private System.Windows.Forms.CheckBox chkUploadFullScreenshot;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkAlignCenter;
        private System.Windows.Forms.CheckBox chkPre;
        private System.Windows.Forms.NumericUpDown nudBodyText;
        private System.Windows.Forms.NumericUpDown nudHeading3Size;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudFontSizeIncr;
        private System.Windows.Forms.CheckBox chkPreIncreaseFontSize;
        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.ComboBox cboSource;
        private System.Windows.Forms.CheckBox chkKeepScreenshot;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.LinkLabel txtScrFull;
        private System.Windows.Forms.ContextMenuStrip cmsApp;
        private System.Windows.Forms.ToolStripMenuItem cmsAppAbout;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.RadioButton rbDir;
        private System.Windows.Forms.RadioButton rbFile;
        private System.Windows.Forms.TextBox txtWebLink;
        private System.Windows.Forms.CheckBox chkWebLink;
        private System.Windows.Forms.GroupBox gbProperties;
        private System.Windows.Forms.CheckBox chkAnalyzeAuto;
        private System.Windows.Forms.DataGridView dgvTrackers;
        private System.Windows.Forms.CheckBox chkCreateTorrent;
        private System.Windows.Forms.ComboBox cboAnnounceURL;
        private System.Windows.Forms.BindingSource trackerBindingSource;
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
    }
}

