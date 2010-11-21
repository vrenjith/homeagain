namespace HomeAgain
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showNotificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkIntervalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minutesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.minutesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.hourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hoursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Checking Status";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Checking Status";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkStatusToolStripMenuItem,
            this.showNotificationsToolStripMenuItem,
            this.checkIntervalToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(163, 98);
            // 
            // checkStatusToolStripMenuItem
            // 
            this.checkStatusToolStripMenuItem.Name = "checkStatusToolStripMenuItem";
            this.checkStatusToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.checkStatusToolStripMenuItem.Text = "Check &Status";
            this.checkStatusToolStripMenuItem.Click += new System.EventHandler(this.checkStatusToolStripMenuItem_Click);
            // 
            // showNotificationsToolStripMenuItem
            // 
            this.showNotificationsToolStripMenuItem.Checked = true;
            this.showNotificationsToolStripMenuItem.CheckOnClick = true;
            this.showNotificationsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showNotificationsToolStripMenuItem.Name = "showNotificationsToolStripMenuItem";
            this.showNotificationsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.showNotificationsToolStripMenuItem.Text = "Show &Notifications";
            this.showNotificationsToolStripMenuItem.Click += new System.EventHandler(this.showNotificationsToolStripMenuItem_Click);
            // 
            // checkIntervalToolStripMenuItem
            // 
            this.checkIntervalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.secondsToolStripMenuItem,
            this.minuteToolStripMenuItem,
            this.minutesToolStripMenuItem,
            this.minutesToolStripMenuItem1,
            this.minutesToolStripMenuItem2,
            this.hourToolStripMenuItem,
            this.hoursToolStripMenuItem});
            this.checkIntervalToolStripMenuItem.Name = "checkIntervalToolStripMenuItem";
            this.checkIntervalToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.checkIntervalToolStripMenuItem.Text = "Check Interval";
            // 
            // secondsToolStripMenuItem
            // 
            this.secondsToolStripMenuItem.CheckOnClick = true;
            this.secondsToolStripMenuItem.Name = "secondsToolStripMenuItem";
            this.secondsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.secondsToolStripMenuItem.Tag = "30";
            this.secondsToolStripMenuItem.Text = "30 Seconds";
            this.secondsToolStripMenuItem.Click += new System.EventHandler(this.updateIntervalStripMenuItem_Click);
            // 
            // minuteToolStripMenuItem
            // 
            this.minuteToolStripMenuItem.CheckOnClick = true;
            this.minuteToolStripMenuItem.Name = "minuteToolStripMenuItem";
            this.minuteToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.minuteToolStripMenuItem.Tag = "60";
            this.minuteToolStripMenuItem.Text = "1 Minute";
            this.minuteToolStripMenuItem.Click += new System.EventHandler(this.updateIntervalStripMenuItem_Click);
            // 
            // minutesToolStripMenuItem
            // 
            this.minutesToolStripMenuItem.CheckOnClick = true;
            this.minutesToolStripMenuItem.Name = "minutesToolStripMenuItem";
            this.minutesToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.minutesToolStripMenuItem.Tag = "300";
            this.minutesToolStripMenuItem.Text = "5 Minutes";
            this.minutesToolStripMenuItem.Click += new System.EventHandler(this.updateIntervalStripMenuItem_Click);
            // 
            // minutesToolStripMenuItem1
            // 
            this.minutesToolStripMenuItem1.CheckOnClick = true;
            this.minutesToolStripMenuItem1.Name = "minutesToolStripMenuItem1";
            this.minutesToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.minutesToolStripMenuItem1.Tag = "600";
            this.minutesToolStripMenuItem1.Text = "10 Minutes";
            this.minutesToolStripMenuItem1.Click += new System.EventHandler(this.updateIntervalStripMenuItem_Click);
            // 
            // minutesToolStripMenuItem2
            // 
            this.minutesToolStripMenuItem2.CheckOnClick = true;
            this.minutesToolStripMenuItem2.Name = "minutesToolStripMenuItem2";
            this.minutesToolStripMenuItem2.Size = new System.Drawing.Size(129, 22);
            this.minutesToolStripMenuItem2.Tag = "1800";
            this.minutesToolStripMenuItem2.Text = "30 Minutes";
            this.minutesToolStripMenuItem2.Click += new System.EventHandler(this.updateIntervalStripMenuItem_Click);
            // 
            // hourToolStripMenuItem
            // 
            this.hourToolStripMenuItem.CheckOnClick = true;
            this.hourToolStripMenuItem.Name = "hourToolStripMenuItem";
            this.hourToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.hourToolStripMenuItem.Tag = "3600";
            this.hourToolStripMenuItem.Text = "1 Hour";
            this.hourToolStripMenuItem.Click += new System.EventHandler(this.updateIntervalStripMenuItem_Click);
            // 
            // hoursToolStripMenuItem
            // 
            this.hoursToolStripMenuItem.CheckOnClick = true;
            this.hoursToolStripMenuItem.Name = "hoursToolStripMenuItem";
            this.hoursToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.hoursToolStripMenuItem.Tag = "7200";
            this.hoursToolStripMenuItem.Text = "2 Hours";
            this.hoursToolStripMenuItem.Click += new System.EventHandler(this.updateIntervalStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 200);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem checkStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showNotificationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkIntervalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secondsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minuteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minutesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem minutesToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem hourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hoursToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

