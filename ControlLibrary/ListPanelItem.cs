using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VaderConsulting.ControlLibrary
{
    public class ListPanelItem : Panel
    {
        private bool _MouseOver = false;
        private bool _Selected = false;
        private DateTime _TimeStamp = DateTime.Now;

        public ListPanelItem()
        {
            DoubleBuffered = true;
            ImageSize = new Size(30, 30);
            CaptionColour = SystemColors.ButtonFace;
            ContentColour = SystemColors.ButtonHighlight;
            CaptionFont = new Font(Font.FontFamily, 13, FontStyle.Bold | FontStyle.Underline);
            ContentFont = new Font(Font.FontFamily, 10, FontStyle.Regular);
            Dock = DockStyle.Top;
            SelectedColour = SystemColors.ActiveCaptionText;
            HoverColour = SystemColors.ButtonShadow;
            Caption = "";
            Content = "";
            BackColor = SystemColors.ActiveCaptionText;
        }

        #region Properties

        public string Caption
        {
            get; set;
        }

        public Color CaptionColour
        {
            get; set;
        }

        public Font CaptionFont
        {
            get; set;
        }

        public string Content
        {
            get; set;
        }

        public Color ContentColour
        {
            get; set;
        }

        public Font ContentFont
        {
            get; set;
        }

        public Color HoverColour
        {
            get; set;
        }

        public Image Image
        {
            get; set;
        }

        public Size ImageSize
        {
            get; set;
        }

        public int Index
        {
            get; set;
        }

        public bool Selected
        {
            get
            {
                return _Selected;
            }
            set
            {
                _Selected = value;
                Invalidate();
            }
        }

        public Color SelectedColour
        {
            get; set;
        }

        public Color BackColour
        {
            get; set;
        }

        public DateTime Timestamp
        {
            get
            {
                return _TimeStamp;
            }

        }

        #endregion

        protected override void OnMouseEnter(EventArgs e)
        {
            _MouseOver = true;
            base.OnMouseEnter(e);
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _MouseOver = false;
            base.OnMouseLeave(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color color1 = _MouseOver ? Color.FromArgb(0, HoverColour) : Color.FromArgb(0, SelectedColour);
            Color color2 = _MouseOver ? HoverColour : SelectedColour;
            Rectangle actualRect = new Rectangle(ClientRectangle.Left, ClientRectangle.Top, ClientRectangle.Width, ClientRectangle.Height - 2);
            SolidBrush Brush = new SolidBrush(color2);

            BackColor = BackColour;

            if (_MouseOver)
            {
                e.Graphics.FillRectangle(Brush, actualRect);
            }
            else if (Selected)
            {
                e.Graphics.FillRectangle(Brush, actualRect);
            }

            if (Image != null)
            {
                e.Graphics.DrawImage(Image, new Rectangle(new Point(10, 10), ImageSize));
            }

            // Draw caption
            StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center };
            e.Graphics.DrawString(Caption, CaptionFont, new SolidBrush(CaptionColour), new RectangleF(ImageSize.Width + 10, 5, Width - ImageSize.Width - 10, CaptionFont.SizeInPoints * 1.5f), sf);

            // Draw content
            int textWidth = Width - ImageSize.Width - 10;
            SizeF textSize = e.Graphics.MeasureString(Content, ContentFont);
            float textHeight = (textSize.Width / textWidth) * textSize.Height + textSize.Height;
            int dynamicHeight = (int)(CaptionFont.SizeInPoints * 1.5) + (int)textHeight + 1;

            if (Height != dynamicHeight)
            {
                Height = dynamicHeight > ImageSize.Height + 10 ? dynamicHeight : ImageSize.Height + 10;
            }

            e.Graphics.DrawString(Content, ContentFont, new SolidBrush(ContentColour), new RectangleF(ImageSize.Width + 10, CaptionFont.SizeInPoints * 1.5f + 5, Width - ImageSize.Width - 10, textHeight));

            // Draw separating line
            e.Graphics.DrawLine(Pens.Silver, new Point(ClientRectangle.Left, ClientRectangle.Bottom - 1), new Point(ClientRectangle.Right, ClientRectangle.Bottom - 1));

            base.OnPaint(e);
        }

        private void InitializeComponent()
        {
            //this.pictureBox1 = new System.Windows.Forms.PictureBox();
            //((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            //this.SuspendLayout();
            //// 
            //// pictureBox1
            //// 
            //this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            //this.pictureBox1.Name = "pictureBox1";
            //this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            //this.pictureBox1.TabIndex = 0;
            //this.pictureBox1.TabStop = false;
            //((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            //this.ResumeLayout(false);

        }
    }

    public class ListPanelItem2 : Panel
    {
        private bool _MouseOver = false;
        private bool _Selected = false;
        private DateTime _TimeStamp = DateTime.Now;

        public ListPanelItem2()
        {
            DoubleBuffered = true;
            ImageSize = new Size(30, 30);
            CaptionColour = SystemColors.ButtonFace;
            ContentColour = SystemColors.ButtonHighlight;
            CaptionFont = new Font(Font.FontFamily, 13, FontStyle.Bold | FontStyle.Underline);
            ContentFont = new Font(Font.FontFamily, 10, FontStyle.Regular);
            Dock = DockStyle.Top;
            SelectedColour = SystemColors.ActiveCaptionText;
            HoverColour = SystemColors.ButtonShadow;
            Caption = "";
            Content = "";
            BackColor = SystemColors.ActiveCaptionText;
        }

        #region Properties

        public string Caption
        {
            get; set;
        }

        public Color CaptionColour
        {
            get; set;
        }

        public Font CaptionFont
        {
            get; set;
        }

        public string Content
        {
            get; set;
        }

        public Color ContentColour
        {
            get; set;
        }

        public Font ContentFont
        {
            get; set;
        }

        public Color HoverColour
        {
            get; set;
        }

        public Image Image
        {
            get; set;
        }

        public Size ImageSize
        {
            get; set;
        }

        public int Index
        {
            get; set;
        }

        public bool Selected
        {
            get
            {
                return _Selected;
            }
            set
            {
                _Selected = value;
                Invalidate();
            }
        }

        public Color SelectedColour
        {
            get; set;
        }

        public Color BackColour
        {
            get; set;
        }

        public DateTime Timestamp
        {
            get
            {
                return _TimeStamp;
            }

        }

        #endregion

        protected override void OnMouseEnter(EventArgs e)
        {
            _MouseOver = true;
            base.OnMouseEnter(e);
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _MouseOver = false;
            base.OnMouseLeave(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color color1 = _MouseOver ? Color.FromArgb(0, HoverColour) : Color.FromArgb(0, SelectedColour);
            Color color2 = _MouseOver ? HoverColour : SelectedColour;
            Rectangle actualRect = new Rectangle(ClientRectangle.Left, ClientRectangle.Top, ClientRectangle.Width, ClientRectangle.Height - 2);
            SolidBrush Brush = new SolidBrush(color2);

            BackColor = BackColour;

            if (_MouseOver)
            {
                e.Graphics.FillRectangle(Brush, actualRect);
            }
            else if (Selected)
            {
                e.Graphics.FillRectangle(Brush, actualRect);
            }

            if (Image != null)
            {
                e.Graphics.DrawImage(Image, new Rectangle(new Point(10, 10), ImageSize));
            }

            // Draw caption
            StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center };
            e.Graphics.DrawString(Caption, CaptionFont, new SolidBrush(CaptionColour), new RectangleF(ImageSize.Width + 10, 5, Width - ImageSize.Width - 10, CaptionFont.SizeInPoints * 1.5f), sf);

            // Draw content
            int textWidth = Width - ImageSize.Width - 10;
            SizeF textSize = e.Graphics.MeasureString(Content, ContentFont);
            float textHeight = (textSize.Width / textWidth) * textSize.Height + textSize.Height;
            int dynamicHeight = (int)(CaptionFont.SizeInPoints * 1.5) + (int)textHeight + 1;

            if (Height != dynamicHeight)
            {
                Height = dynamicHeight > ImageSize.Height + 10 ? dynamicHeight : ImageSize.Height + 10;
            }

            e.Graphics.DrawString(Content, ContentFont, new SolidBrush(ContentColour), new RectangleF(ImageSize.Width + 10, CaptionFont.SizeInPoints * 1.5f + 5, Width - ImageSize.Width - 10, textHeight));

            // Draw separating line
            e.Graphics.DrawLine(Pens.Silver, new Point(ClientRectangle.Left, ClientRectangle.Bottom - 1), new Point(ClientRectangle.Right, ClientRectangle.Bottom - 1));

            base.OnPaint(e);
        }

        private void InitializeComponent()
        {
            //this.pictureBox1 = new System.Windows.Forms.PictureBox();
            //((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            //this.SuspendLayout();
            //// 
            //// pictureBox1
            //// 
            //this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            //this.pictureBox1.Name = "pictureBox1";
            //this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            //this.pictureBox1.TabIndex = 0;
            //this.pictureBox1.TabStop = false;
            //((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            //this.ResumeLayout(false);

        }
    }

}
