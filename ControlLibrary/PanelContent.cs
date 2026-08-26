using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VaderConsulting.ControlLibrary
{
    public partial class PanelContent : UserControl
    {
        #region Fields

        private int _Index = -1;
        private bool _MouseOver = false;
        private bool _Selected = false;
        private bool _Viewed = false;
        private DateTime _TimeStamp = DateTime.Now;
        private string _GroupName = "";
        private string _Subject = "";
        private string _Body = "";
        private string _Reference = "";
        private Image _Image = null;
        private Color _SubjectColour = SystemColors.WindowText;
        private Color _MessageColour = SystemColors.GrayText;
        private Color _HoverColour = SystemColors.ButtonShadow;
        private Color _SelectedColour = SystemColors.ActiveCaptionText;
        private Color _BackColour = SystemColors.ActiveCaptionText;

        #endregion

        #region Constructors 

        public PanelContent()
        {
            InitializeComponent();

            DoubleBuffered = true;

            Update();

            //CaptionColour = SystemColors.ButtonFace;
            //ContentColour = SystemColors.ButtonHighlight;
            //CaptionFont = new Font(Font.FontFamily, 13, FontStyle.Bold | FontStyle.Underline);
            //ContentFont = new Font(Font.FontFamily, 10, FontStyle.Regular);
            //SelectedColour = SystemColors.ActiveCaptionText;
            //HoverColour = SystemColors.ButtonShadow;
            //Caption = "";
            //Content = "";
            //BackColor = SystemColors.ActiveCaptionText;

        }

        #endregion

        #region Properties

        //public string Caption
        //{
        //    get; set;
        //}

        //public Color CaptionColour
        //{
        //    get; set;
        //}

        //public Font CaptionFont
        //{
        //    get; set;
        //}

        //public string Content
        //{
        //    get; set;
        //}

        //public Color ContentColour
        //{
        //    get; set;
        //}

        //public Font ContentFont
        //{
        //    get; set;
        //}

        //public Color HoverColour
        //{
        //    get; set;
        //}

        //public Image Image
        //{
        //    get; set;
        //}

        //public Size ImageSize
        //{
        //    get; set;
        //}

        //public int Index
        //{
        //    get; set;
        //}

        //public bool Selected
        //{
        //    get
        //    {
        //        return _Selected;
        //    }
        //    set
        //    {
        //        _Selected = value;
        //        Invalidate();
        //    }
        //}

        //public Color SelectedColour
        //{
        //    get; set;
        //}

        //public Color BackColour
        //{
        //    get; set;
        //}

        #endregion

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    // Draw separating line
        //    e.Graphics.DrawLine(Pens.Silver, new Point(ClientRectangle.Left, ClientRectangle.Bottom - 1), new Point(ClientRectangle.Right, ClientRectangle.Bottom - 1));

        //    base.OnPaint(e);
        //}

        #region Properties

        public int Index
        {
            get
            {
                return _Index;
            }
            set
            {
                _Index = value;
            }
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
            }
        }

        public bool Viewed
        {
            get
            {
                return _Viewed;
            }
            set
            {
                _Viewed = value;
            }
        }

        public DateTime TimeStamp
        {
            get
            {
                return _TimeStamp;
            }
            set
            {
                _TimeStamp = value;
            }
        }

        public string GroupName
        {
            get
            {
                return _GroupName;
            }
            set
            {
                _GroupName = value;
            }
        }

        public string Subject
        {
            get
            {
                return _Subject;
            }
            set
            {
                _Subject = value;

                Update();
            }
        }

        public string Body
        {
            get
            {
                return _Body;
            }
            set
            {
                _Body = value;

                Update();
            }
        }

        public string Reference
        {
            get
            {
                return _Reference;
            }
            set
            {
                _Reference = value;

                Update();
            }
        }

        public Image Image
        {
            get
            {
                return _Image;
            }
            set
            {
                _Image = value;

                Update();
            }
        }

        public Color SubjectColour
        {
            get
            {
                return _SubjectColour;
            }
            set
            {
                _SubjectColour = value;

                Update();
            }
        }

        public Color MessageColour
        {
            get
            {
                return _MessageColour;
            }
            set
            {
                _MessageColour = value;

                Update();
            }
        }

        public Color HoverColour
        {
            get
            {
                return _HoverColour;
            }
            set
            {
                _HoverColour = value;

                Update();
            }
        }

        public Color SelectedColour
        {
            get
            {
                return _SelectedColour;
            }
            set
            {
                _SelectedColour = value;

                Update();
            }
        }

        public Color BackColour
        {
            get
            {
                return _BackColour;
            }
            set
            {
                _BackColour = value;

                Update();
            }
        }

        #endregion

        #region Event Handlers

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

        #endregion

        #region Public Methods

        public new void Update()
        {
            lblSubject.Text = _Subject;
            lblReference.Text = _Reference;
            lblBody.Text = _Body;
            lblTimestamp.Text = _TimeStamp.ToString("HH:mm");
            picImage.BackgroundImage = Image;
            this.BackColor = BackColour;
            //lblSubject.BackColor = SubjectColour;
            //lblBody.BackColor = MessageColour;

            this.Refresh();
        }

        #endregion

        private void picClose_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
        }
    }
}
