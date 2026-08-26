namespace VaderConsulting.ControlLibrary
{
    partial class PanelContent
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.lblBody = new System.Windows.Forms.Label();
            this.lblTimestamp = new System.Windows.Forms.Label();
            this.lblReference = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picImage.Location = new System.Drawing.Point(3, 3);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(28, 28);
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // lblSubject
            // 
            this.lblSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubject.AutoEllipsis = true;
            this.lblSubject.BackColor = System.Drawing.Color.Transparent;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(37, 3);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(324, 28);
            this.lblSubject.TabIndex = 1;
            this.lblSubject.Text = "Subject";
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.BackgroundImage = global::VaderConsulting.ControlLibrary.Properties.Resources.cancel;
            this.picClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Location = new System.Drawing.Point(367, 3);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(28, 28);
            this.picClose.TabIndex = 2;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // lblBody
            // 
            this.lblBody.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBody.AutoEllipsis = true;
            this.lblBody.BackColor = System.Drawing.Color.Transparent;
            this.lblBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBody.Location = new System.Drawing.Point(3, 34);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(392, 40);
            this.lblBody.TabIndex = 3;
            this.lblBody.Text = "Body";
            // 
            // lblTimestamp
            // 
            this.lblTimestamp.BackColor = System.Drawing.Color.Transparent;
            this.lblTimestamp.Location = new System.Drawing.Point(3, 74);
            this.lblTimestamp.Name = "lblTimestamp";
            this.lblTimestamp.Size = new System.Drawing.Size(101, 21);
            this.lblTimestamp.TabIndex = 4;
            this.lblTimestamp.Text = "Timestamp";
            // 
            // lblReference
            // 
            this.lblReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReference.AutoEllipsis = true;
            this.lblReference.BackColor = System.Drawing.Color.Transparent;
            this.lblReference.Location = new System.Drawing.Point(102, 74);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(282, 21);
            this.lblReference.TabIndex = 5;
            this.lblReference.Text = "Reference";
            // 
            // PanelContent
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblReference);
            this.Controls.Add(this.lblTimestamp);
            this.Controls.Add(this.lblBody);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.picImage);
            this.DoubleBuffered = true;
            this.Name = "PanelContent";
            this.Size = new System.Drawing.Size(398, 98);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.Label lblTimestamp;
        private System.Windows.Forms.Label lblReference;
    }
}
