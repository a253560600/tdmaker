namespace TDMaker
{
    partial class MediaWizard
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
            this.gbQuestion = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpTasks = new System.Windows.Forms.FlowLayoutPanel();
            this.chkScreenshotsInclude = new System.Windows.Forms.CheckBox();
            this.chkCreateTorrent = new System.Windows.Forms.CheckBox();
            this.lblUserActionMsg = new System.Windows.Forms.Label();
            this.rbFilesAsIndiv = new System.Windows.Forms.RadioButton();
            this.rbFilesAsColl = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbQuestion.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flpTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbQuestion
            // 
            this.gbQuestion.Controls.Add(this.flowLayoutPanel1);
            this.gbQuestion.Controls.Add(this.flpTasks);
            this.gbQuestion.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbQuestion.Location = new System.Drawing.Point(8, 48);
            this.gbQuestion.Name = "gbQuestion";
            this.gbQuestion.Size = new System.Drawing.Size(463, 184);
            this.gbQuestion.TabIndex = 1;
            this.gbQuestion.TabStop = false;
            this.gbQuestion.Text = "What would you like to do?";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.rbFilesAsIndiv);
            this.flowLayoutPanel1.Controls.Add(this.rbFilesAsColl);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(440, 64);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // flpTasks
            // 
            this.flpTasks.Controls.Add(this.chkScreenshotsInclude);
            this.flpTasks.Controls.Add(this.chkCreateTorrent);
            this.flpTasks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpTasks.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpTasks.Location = new System.Drawing.Point(8, 104);
            this.flpTasks.Name = "flpTasks";
            this.flpTasks.Size = new System.Drawing.Size(440, 64);
            this.flpTasks.TabIndex = 2;
            // 
            // chkScreenshotsInclude
            // 
            this.chkScreenshotsInclude.AutoSize = true;
            this.chkScreenshotsInclude.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkScreenshotsInclude.Location = new System.Drawing.Point(3, 3);
            this.chkScreenshotsInclude.Name = "chkScreenshotsInclude";
            this.chkScreenshotsInclude.Size = new System.Drawing.Size(150, 22);
            this.chkScreenshotsInclude.TabIndex = 1;
            this.chkScreenshotsInclude.Text = "Include screenshots";
            this.chkScreenshotsInclude.UseVisualStyleBackColor = true;
            this.chkScreenshotsInclude.CheckedChanged += new System.EventHandler(this.chkScreenshotsInclude_CheckedChanged);
            // 
            // chkCreateTorrent
            // 
            this.chkCreateTorrent.AutoSize = true;
            this.chkCreateTorrent.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCreateTorrent.Location = new System.Drawing.Point(3, 31);
            this.chkCreateTorrent.Name = "chkCreateTorrent";
            this.chkCreateTorrent.Size = new System.Drawing.Size(125, 22);
            this.chkCreateTorrent.TabIndex = 0;
            this.chkCreateTorrent.Text = "Create a torrent";
            this.chkCreateTorrent.UseVisualStyleBackColor = true;
            this.chkCreateTorrent.CheckedChanged += new System.EventHandler(this.chkCreateTorrent_CheckedChanged);
            // 
            // lblUserActionMsg
            // 
            this.lblUserActionMsg.AutoSize = true;
            this.lblUserActionMsg.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserActionMsg.Location = new System.Drawing.Point(16, 16);
            this.lblUserActionMsg.Name = "lblUserActionMsg";
            this.lblUserActionMsg.Size = new System.Drawing.Size(131, 18);
            this.lblUserActionMsg.TabIndex = 3;
            this.lblUserActionMsg.Text = "You about to import";
            // 
            // rbFilesAsIndiv
            // 
            this.rbFilesAsIndiv.AutoSize = true;
            this.rbFilesAsIndiv.Location = new System.Drawing.Point(3, 3);
            this.rbFilesAsIndiv.Name = "rbFilesAsIndiv";
            this.rbFilesAsIndiv.Size = new System.Drawing.Size(179, 22);
            this.rbFilesAsIndiv.TabIndex = 0;
            this.rbFilesAsIndiv.TabStop = true;
            this.rbFilesAsIndiv.Text = "Process files individually";
            this.rbFilesAsIndiv.UseVisualStyleBackColor = true;
            this.rbFilesAsIndiv.CheckedChanged += new System.EventHandler(this.rbFilesAsIndiv_CheckedChanged);
            // 
            // rbFilesAsColl
            // 
            this.rbFilesAsColl.AutoSize = true;
            this.rbFilesAsColl.Location = new System.Drawing.Point(3, 31);
            this.rbFilesAsColl.Name = "rbFilesAsColl";
            this.rbFilesAsColl.Size = new System.Drawing.Size(237, 22);
            this.rbFilesAsColl.TabIndex = 1;
            this.rbFilesAsColl.TabStop = true;
            this.rbFilesAsColl.Text = "Process files as a Media Collection";
            this.rbFilesAsColl.UseVisualStyleBackColor = true;
            this.rbFilesAsColl.CheckedChanged += new System.EventHandler(this.rbFilesAsColl_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(384, 240);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // MediaWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 280);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblUserActionMsg);
            this.Controls.Add(this.gbQuestion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MediaWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TDMaker - Media Wizard";
            this.gbQuestion.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flpTasks.ResumeLayout(false);
            this.flpTasks.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbQuestion;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flpTasks;
        private System.Windows.Forms.CheckBox chkCreateTorrent;
        private System.Windows.Forms.Label lblUserActionMsg;
        private System.Windows.Forms.CheckBox chkScreenshotsInclude;
        private System.Windows.Forms.RadioButton rbFilesAsIndiv;
        private System.Windows.Forms.RadioButton rbFilesAsColl;
        private System.Windows.Forms.Button btnOK;


    }
}