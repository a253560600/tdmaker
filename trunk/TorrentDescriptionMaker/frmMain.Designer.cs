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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboMtnArgs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMtn = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCopy0 = new System.Windows.Forms.Button();
            this.txtImageShackURL = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCopy2 = new System.Windows.Forms.Button();
            this.txtBBScrForums = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.txtBBScrFull = new System.Windows.Forms.TextBox();
            this.bwApp = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sbarIcon = new System.Windows.Forms.ToolStripStatusLabel();
            this.sBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.pBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtMediaInfo = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtPublish = new System.Windows.Forms.TextBox();
            this.tmrStatus = new System.Windows.Forms.Timer(this.components);
            this.btnPublish = new System.Windows.Forms.Button();
            this.txtMediaFile = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
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
            this.label6.Location = new System.Drawing.Point(32, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Arguments:";
            // 
            // cboMtnArgs
            // 
            this.cboMtnArgs.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TorrentDescriptionMaker.Properties.Settings.Default, "MTNArg", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboMtnArgs.FormattingEnabled = true;
            this.cboMtnArgs.Location = new System.Drawing.Point(114, 54);
            this.cboMtnArgs.Name = "cboMtnArgs";
            this.cboMtnArgs.Size = new System.Drawing.Size(442, 21);
            this.cboMtnArgs.TabIndex = 7;
            this.cboMtnArgs.Text = global::TorrentDescriptionMaker.Properties.Settings.Default.MTNArg;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Location:";
            // 
            // txtMtn
            // 
            this.txtMtn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtMtn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtMtn.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TorrentDescriptionMaker.Properties.Settings.Default, "MTNPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtMtn.Location = new System.Drawing.Point(114, 25);
            this.txtMtn.Name = "txtMtn";
            this.txtMtn.Size = new System.Drawing.Size(442, 20);
            this.txtMtn.TabIndex = 0;
            this.txtMtn.Text = global::TorrentDescriptionMaker.Properties.Settings.Default.MTNPath;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnCopy0);
            this.groupBox2.Controls.Add(this.txtImageShackURL);
            this.groupBox2.Location = new System.Drawing.Point(16, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(706, 79);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ImageShack";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Full Image:";
            // 
            // btnCopy0
            // 
            this.btnCopy0.AutoSize = true;
            this.btnCopy0.Enabled = false;
            this.btnCopy0.Location = new System.Drawing.Point(562, 30);
            this.btnCopy0.Name = "btnCopy0";
            this.btnCopy0.Size = new System.Drawing.Size(106, 23);
            this.btnCopy0.TabIndex = 3;
            this.btnCopy0.Text = "&Copy to Clipboard";
            this.btnCopy0.UseVisualStyleBackColor = true;
            this.btnCopy0.Click += new System.EventHandler(this.btnCopy0_Click);
            // 
            // txtImageShackURL
            // 
            this.txtImageShackURL.Location = new System.Drawing.Point(114, 33);
            this.txtImageShackURL.Name = "txtImageShackURL";
            this.txtImageShackURL.ReadOnly = true;
            this.txtImageShackURL.Size = new System.Drawing.Size(442, 20);
            this.txtImageShackURL.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnCopy2);
            this.groupBox3.Controls.Add(this.txtBBScrForums);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnCopy);
            this.groupBox3.Controls.Add(this.txtBBScrFull);
            this.groupBox3.Location = new System.Drawing.Point(16, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(706, 144);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "BBCode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Forums:";
            // 
            // btnCopy2
            // 
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
            this.txtBBScrForums.Location = new System.Drawing.Point(114, 80);
            this.txtBBScrForums.Name = "txtBBScrForums";
            this.txtBBScrForums.ReadOnly = true;
            this.txtBBScrForums.Size = new System.Drawing.Size(442, 20);
            this.txtBBScrForums.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Full Image:";
            // 
            // btnCopy
            // 
            this.btnCopy.AutoSize = true;
            this.btnCopy.Enabled = false;
            this.btnCopy.Location = new System.Drawing.Point(562, 40);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(106, 23);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "&Copy to Clipboard";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // txtBBScrFull
            // 
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 550);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(794, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sbarIcon
            // 
            this.sbarIcon.Image = global::TorrentDescriptionMaker.Properties.Resources.info_16_xp;
            this.sbarIcon.Name = "sbarIcon";
            this.sbarIcon.Size = new System.Drawing.Size(16, 17);
            // 
            // sBar
            // 
            this.sBar.Name = "sBar";
            this.sBar.Size = new System.Drawing.Size(661, 17);
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
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 92);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 409);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtMediaInfo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(752, 383);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Media Info";
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
            this.txtMediaInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMediaInfo.Size = new System.Drawing.Size(746, 377);
            this.txtMediaInfo.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(752, 383);
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
            this.tabPage3.Size = new System.Drawing.Size(752, 383);
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
            this.txtPublish.ReadOnly = true;
            this.txtPublish.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPublish.Size = new System.Drawing.Size(746, 377);
            this.txtPublish.TabIndex = 1;
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
            this.btnPublish.Location = new System.Drawing.Point(594, 512);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(106, 23);
            this.btnPublish.TabIndex = 5;
            this.btnPublish.Text = "&Copy to Clipboard";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // txtMediaFile
            // 
            this.txtMediaFile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtMediaFile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtMediaFile.Location = new System.Drawing.Point(26, 29);
            this.txtMediaFile.Name = "txtMediaFile";
            this.txtMediaFile.Size = new System.Drawing.Size(530, 20);
            this.txtMediaFile.TabIndex = 6;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnBrowse);
            this.groupBox4.Controls.Add(this.txtMediaFile);
            this.groupBox4.Location = new System.Drawing.Point(32, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(706, 70);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Analyze Media File...";
            // 
            // btnBrowse
            // 
            this.btnBrowse.AutoSize = true;
            this.btnBrowse.Location = new System.Drawing.Point(562, 29);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(106, 23);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "&Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 572);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnPublish);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmMain";
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
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtImageShackURL;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCopy;
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
        private System.Windows.Forms.TextBox txtMediaFile;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnBrowse;
    }
}

