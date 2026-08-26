namespace Action_Center
{
    partial class ActionCentre
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
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.lblActionCenter = new System.Windows.Forms.Label();
            this.lblNoNewNotifications = new System.Windows.Forms.Label();
            this.lblClearAll = new System.Windows.Forms.Label();
            this.tmrHighPriority = new System.Windows.Forms.Timer(this.components);
            this.tmrNewMessage = new System.Windows.Forms.Timer(this.components);
            this.MessageArea = new System.Windows.Forms.FlowLayoutPanel();
            this.tlpTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // notify
            // 
            this.notify.Text = "No new notifications";
            this.notify.Visible = true;
            this.notify.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notify_MouseClick);
            // 
            // tlpTitle
            // 
            this.tlpTitle.BackColor = System.Drawing.Color.Transparent;
            this.tlpTitle.ColumnCount = 2;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 266F));
            this.tlpTitle.Controls.Add(this.lblActionCenter, 0, 0);
            this.tlpTitle.Controls.Add(this.lblNoNewNotifications, 0, 1);
            this.tlpTitle.Controls.Add(this.lblClearAll, 1, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(0, 0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.tlpTitle.RowCount = 2;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTitle.Size = new System.Drawing.Size(532, 94);
            this.tlpTitle.TabIndex = 2;
            // 
            // lblActionCenter
            // 
            this.lblActionCenter.AutoSize = true;
            this.lblActionCenter.BackColor = System.Drawing.Color.Transparent;
            this.lblActionCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActionCenter.Location = new System.Drawing.Point(3, 15);
            this.lblActionCenter.Name = "lblActionCenter";
            this.lblActionCenter.Size = new System.Drawing.Size(212, 25);
            this.lblActionCenter.TabIndex = 1;
            this.lblActionCenter.Text = "MESSAGE CENTRE";
            // 
            // lblNoNewNotifications
            // 
            this.lblNoNewNotifications.AutoSize = true;
            this.lblNoNewNotifications.BackColor = System.Drawing.Color.Transparent;
            this.lblNoNewNotifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoNewNotifications.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblNoNewNotifications.Location = new System.Drawing.Point(3, 49);
            this.lblNoNewNotifications.Name = "lblNoNewNotifications";
            this.lblNoNewNotifications.Size = new System.Drawing.Size(188, 25);
            this.lblNoNewNotifications.TabIndex = 3;
            this.lblNoNewNotifications.Text = "No new messages";
            // 
            // lblClearAll
            // 
            this.lblClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClearAll.AutoSize = true;
            this.lblClearAll.BackColor = System.Drawing.Color.Transparent;
            this.lblClearAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearAll.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblClearAll.Location = new System.Drawing.Point(453, 15);
            this.lblClearAll.Name = "lblClearAll";
            this.lblClearAll.Size = new System.Drawing.Size(76, 20);
            this.lblClearAll.TabIndex = 4;
            this.lblClearAll.Text = "Clear All";
            this.lblClearAll.Visible = false;
            this.lblClearAll.Click += new System.EventHandler(this.lblClearAll_Click);
            // 
            // tmrHighPriority
            // 
            this.tmrHighPriority.Interval = 500;
            this.tmrHighPriority.Tick += new System.EventHandler(this.tmrHighPriority_Tick);
            // 
            // tmrNewMessage
            // 
            this.tmrNewMessage.Interval = 2000;
            this.tmrNewMessage.Tick += new System.EventHandler(this.tmrNewMessage_Tick);
            // 
            // MessageArea
            // 
            this.MessageArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageArea.Location = new System.Drawing.Point(0, 100);
            this.MessageArea.Name = "MessageArea";
            this.MessageArea.Size = new System.Drawing.Size(532, 692);
            this.MessageArea.TabIndex = 3;
            // 
            // ActionCentre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(532, 791);
            this.ControlBox = false;
            this.Controls.Add(this.MessageArea);
            this.Controls.Add(this.tlpTitle);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActionCentre";
            this.Opacity = 0.77D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.ActionCentre_Deactivate);
            this.Load += new System.EventHandler(this.ActionCentre_Load);
            this.Shown += new System.EventHandler(this.ActionCentre_Shown);
            this.tlpTitle.ResumeLayout(false);
            this.tlpTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.TableLayoutPanel tlpTitle;
        private System.Windows.Forms.Label lblActionCenter;
        private System.Windows.Forms.Label lblNoNewNotifications;
        private System.Windows.Forms.Label lblClearAll;
        private System.Windows.Forms.Timer tmrHighPriority;
        private System.Windows.Forms.Timer tmrNewMessage;
        private System.Windows.Forms.FlowLayoutPanel MessageArea;
    }
}

