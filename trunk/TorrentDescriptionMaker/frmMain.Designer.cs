﻿namespace TorrentDescriptionMaker
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
            this.label6 = new System.Windows.Forms.Label();
            this.cboMtnArgs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMtn = new System.Windows.Forms.TextBox();
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
            this.chkWebLink = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbDir = new System.Windows.Forms.RadioButton();
            this.rbFile = new System.Windows.Forms.RadioButton();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtMediaLocation = new System.Windows.Forms.TextBox();
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.cboSource = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtMediaInfo = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtPublish = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.chkAnalyzeAuto = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.chkKeepScreenshot = new System.Windows.Forms.CheckBox();
            this.chkOptImageShack = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.nudHeadingsText = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudBodyText = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkUploadFullScreenshot = new System.Windows.Forms.CheckBox();
            this.nudFontSizeIncr = new System.Windows.Forms.NumericUpDown();
            this.chkPre = new System.Windows.Forms.CheckBox();
            this.chkPreIncreaseFontSize = new System.Windows.Forms.CheckBox();
            this.chkAlignCenter = new System.Windows.Forms.CheckBox();
            this.tmrStatus = new System.Windows.Forms.Timer(this.components);
            this.btnPublish = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.cmsApp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsAppAbout = new System.Windows.Forms.ToolStripMenuItem();
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
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeadingsText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBodyText)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSizeIncr)).BeginInit();
            this.cmsApp.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboMtnArgs);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMtn);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(706, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Movie Thumbnailer Settings";
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
            // cboMtnArgs
            // 
            this.cboMtnArgs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMtnArgs.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TDMaker.Properties.Settings.Default, "MTNArg", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboMtnArgs.FormattingEnabled = true;
            this.cboMtnArgs.Location = new System.Drawing.Point(114, 54);
            this.cboMtnArgs.Name = "cboMtnArgs";
            this.cboMtnArgs.Size = new System.Drawing.Size(442, 21);
            this.cboMtnArgs.TabIndex = 7;
            this.cboMtnArgs.Text = global::TDMaker.Properties.Settings.Default.MTNArg;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Location:";
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
            this.txtMtn.Size = new System.Drawing.Size(442, 20);
            this.txtMtn.TabIndex = 0;
            this.txtMtn.Text = global::TDMaker.Properties.Settings.Default.MTNPath;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtScrFull);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnCopy0);
            this.groupBox2.Location = new System.Drawing.Point(16, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(706, 79);
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
            this.txtScrFull.Size = new System.Drawing.Size(442, 20);
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
            this.btnCopy0.Location = new System.Drawing.Point(562, 31);
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
            this.groupBox3.Location = new System.Drawing.Point(16, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(706, 124);
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
            this.btnCopy2.Location = new System.Drawing.Point(562, 78);
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
            this.txtBBScrForums.Size = new System.Drawing.Size(442, 20);
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
            this.btnCopy1.Location = new System.Drawing.Point(562, 40);
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
            this.txtBBScrFull.Size = new System.Drawing.Size(442, 20);
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
            this.tabControl1.Size = new System.Drawing.Size(750, 479);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.gbProperties);
            this.tabPage5.Controls.Add(this.groupBox4);
            this.tabPage5.Controls.Add(this.gbSource);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(742, 453);
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
            this.gbProperties.Controls.Add(this.chkWebLink);
            this.gbProperties.Location = new System.Drawing.Point(12, 111);
            this.gbProperties.Name = "gbProperties";
            this.gbProperties.Size = new System.Drawing.Size(714, 318);
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
            this.txtWebLink.Size = new System.Drawing.Size(561, 20);
            this.txtWebLink.TabIndex = 10;
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
            this.groupBox4.Size = new System.Drawing.Size(550, 93);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Location";
            // 
            // rbDir
            // 
            this.rbDir.AutoSize = true;
            this.rbDir.Location = new System.Drawing.Point(232, 27);
            this.rbDir.Name = "rbDir";
            this.rbDir.Size = new System.Drawing.Size(80, 17);
            this.rbDir.TabIndex = 9;
            this.rbDir.Text = "&DVD Folder";
            this.rbDir.UseVisualStyleBackColor = true;
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
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.AutoSize = true;
            this.btnBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowse.Location = new System.Drawing.Point(469, 48);
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
            this.txtMediaLocation.Size = new System.Drawing.Size(426, 20);
            this.txtMediaLocation.TabIndex = 6;
            // 
            // gbSource
            // 
            this.gbSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSource.Controls.Add(this.cboSource);
            this.gbSource.Location = new System.Drawing.Point(571, 13);
            this.gbSource.Name = "gbSource";
            this.gbSource.Size = new System.Drawing.Size(155, 92);
            this.gbSource.TabIndex = 8;
            this.gbSource.TabStop = false;
            this.gbSource.Text = "Source";
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtMediaInfo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(742, 453);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtMediaInfo
            // 
            this.txtMediaInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMediaInfo.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMediaInfo.Location = new System.Drawing.Point(3, 3);
            this.txtMediaInfo.Multiline = true;
            this.txtMediaInfo.Name = "txtMediaInfo";
            this.txtMediaInfo.ReadOnly = true;
            this.txtMediaInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMediaInfo.Size = new System.Drawing.Size(736, 447);
            this.txtMediaInfo.TabIndex = 0;
            this.txtMediaInfo.WordWrap = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(742, 453);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Screenshots";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtPublish);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(742, 453);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Publish";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtPublish
            // 
            this.txtPublish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPublish.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPublish.Location = new System.Drawing.Point(3, 3);
            this.txtPublish.Multiline = true;
            this.txtPublish.Name = "txtPublish";
            this.txtPublish.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPublish.Size = new System.Drawing.Size(736, 447);
            this.txtPublish.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.chkAnalyzeAuto);
            this.tabPage4.Controls.Add(this.groupBox7);
            this.tabPage4.Controls.Add(this.groupBox6);
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(742, 453);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Options";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // chkAnalyzeAuto
            // 
            this.chkAnalyzeAuto.AutoSize = true;
            this.chkAnalyzeAuto.Checked = global::TDMaker.Properties.Settings.Default.AnalyzeAuto;
            this.chkAnalyzeAuto.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "AnalyzeAuto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkAnalyzeAuto.Location = new System.Drawing.Point(32, 17);
            this.chkAnalyzeAuto.Name = "chkAnalyzeAuto";
            this.chkAnalyzeAuto.Size = new System.Drawing.Size(260, 17);
            this.chkAnalyzeAuto.TabIndex = 9;
            this.chkAnalyzeAuto.Text = "&Process media immediately after loading file/folder";
            this.chkAnalyzeAuto.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.chkKeepScreenshot);
            this.groupBox7.Controls.Add(this.chkOptImageShack);
            this.groupBox7.Location = new System.Drawing.Point(16, 45);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(431, 78);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Screenshots";
            // 
            // chkKeepScreenshot
            // 
            this.chkKeepScreenshot.AutoSize = true;
            this.chkKeepScreenshot.Checked = global::TDMaker.Properties.Settings.Default.KeepScreenshot;
            this.chkKeepScreenshot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeepScreenshot.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TDMaker.Properties.Settings.Default, "KeepScreenshot", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkKeepScreenshot.Location = new System.Drawing.Point(16, 46);
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
            this.chkOptImageShack.Location = new System.Drawing.Point(16, 23);
            this.chkOptImageShack.Name = "chkOptImageShack";
            this.chkOptImageShack.Size = new System.Drawing.Size(192, 17);
            this.chkOptImageShack.TabIndex = 0;
            this.chkOptImageShack.Text = "Upload Screenshot to &ImageShack";
            this.chkOptImageShack.UseVisualStyleBackColor = true;
            this.chkOptImageShack.CheckedChanged += new System.EventHandler(this.chkOptImageShack_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.nudHeadingsText);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.nudBodyText);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Location = new System.Drawing.Point(455, 128);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(190, 113);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Font Size";
            // 
            // nudHeadingsText
            // 
            this.nudHeadingsText.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::TDMaker.Properties.Settings.Default, "FontSizeHeading", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudHeadingsText.Location = new System.Drawing.Point(103, 32);
            this.nudHeadingsText.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeadingsText.Name = "nudHeadingsText";
            this.nudHeadingsText.Size = new System.Drawing.Size(55, 20);
            this.nudHeadingsText.TabIndex = 4;
            this.nudHeadingsText.Value = global::TDMaker.Properties.Settings.Default.FontSizeHeading;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Body";
            // 
            // nudBodyText
            // 
            this.nudBodyText.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::TDMaker.Properties.Settings.Default, "FontSizeBody", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudBodyText.Location = new System.Drawing.Point(103, 58);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Headings";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkUploadFullScreenshot);
            this.groupBox5.Controls.Add(this.nudFontSizeIncr);
            this.groupBox5.Controls.Add(this.chkPre);
            this.groupBox5.Controls.Add(this.chkPreIncreaseFontSize);
            this.groupBox5.Controls.Add(this.chkAlignCenter);
            this.groupBox5.Location = new System.Drawing.Point(16, 128);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(431, 113);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Publish Template";
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
            this.btnPublish.Location = new System.Drawing.Point(599, 505);
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
            this.btnAnalyze.Location = new System.Drawing.Point(58, 505);
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
            // frmMain
            // 
            this.AcceptButton = this.btnBrowse;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.ContextMenuStrip = this.cmsApp;
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.btnPublish);
            this.Controls.Add(this.statusStrip1);
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
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeadingsText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBodyText)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSizeIncr)).EndInit();
            this.cmsApp.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox txtPublish;
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
        private System.Windows.Forms.NumericUpDown nudHeadingsText;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudFontSizeIncr;
        private System.Windows.Forms.CheckBox chkPreIncreaseFontSize;
        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.ComboBox cboSource;
        private System.Windows.Forms.GroupBox groupBox7;
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
    }
}
