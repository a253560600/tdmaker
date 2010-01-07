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
            this.flpTasks = new System.Windows.Forms.FlowLayoutPanel();
            this.chk = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblUserActionMsg = new System.Windows.Forms.Label();
            this.gbQuestion.SuspendLayout();
            this.flpTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbQuestion
            // 
            this.gbQuestion.Controls.Add(this.flowLayoutPanel1);
            this.gbQuestion.Location = new System.Drawing.Point(16, 48);
            this.gbQuestion.Name = "gbQuestion";
            this.gbQuestion.Size = new System.Drawing.Size(480, 216);
            this.gbQuestion.TabIndex = 1;
            this.gbQuestion.TabStop = false;
            this.gbQuestion.Text = "What would you like to do?";
            // 
            // flpTasks
            // 
            this.flpTasks.Controls.Add(this.chk);
            this.flpTasks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpTasks.Location = new System.Drawing.Point(48, 296);
            this.flpTasks.Name = "flpTasks";
            this.flpTasks.Size = new System.Drawing.Size(200, 100);
            this.flpTasks.TabIndex = 2;
            // 
            // chk
            // 
            this.chk.AutoSize = true;
            this.chk.Location = new System.Drawing.Point(3, 3);
            this.chk.Name = "chk";
            this.chk.Size = new System.Drawing.Size(80, 17);
            this.chk.TabIndex = 0;
            this.chk.Text = "checkBox1";
            this.chk.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(360, 104);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblUserActionMsg
            // 
            this.lblUserActionMsg.AutoSize = true;
            this.lblUserActionMsg.Location = new System.Drawing.Point(16, 16);
            this.lblUserActionMsg.Name = "lblUserActionMsg";
            this.lblUserActionMsg.Size = new System.Drawing.Size(99, 13);
            this.lblUserActionMsg.TabIndex = 3;
            this.lblUserActionMsg.Text = "You about to import";
            // 
            // RunOnceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 435);
            this.Controls.Add(this.lblUserActionMsg);
            this.Controls.Add(this.flpTasks);
            this.Controls.Add(this.gbQuestion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RunOnceWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Media Wizard";
            this.gbQuestion.ResumeLayout(false);
            this.flpTasks.ResumeLayout(false);
            this.flpTasks.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbQuestion;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flpTasks;
        private System.Windows.Forms.CheckBox chk;
        private System.Windows.Forms.Label lblUserActionMsg;


    }
}