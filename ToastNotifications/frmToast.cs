using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CreateToastNotifications
{
    public partial class frmToast : Form
    {
        private static List<frmToast> _OpenNotifications = new List<frmToast>();
        private bool _AllowFocus;
        private readonly Native.FormAnimator _Animator;
        private IntPtr _CurrentForegroundWindow;
        private string _Title = "";
        private string _Subject = "";
        private string _Message = "";
        private string _Reference = "";
        private Image _Image = null;
        private int _Duration = 0;
        Native.FormAnimator.AnimationMethod _Animation = Native.FormAnimator.AnimationMethod.Slide;
        Native.FormAnimator.AnimationDirection _Direction = Native.FormAnimator.AnimationDirection.Up;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Message"></param>
        /// <param name="Reference"></param>
        /// <param name="Image"></param>
        /// <param name="duration"></param>
        /// <param name="Animation"></param>
        /// <param name="Direction"></param>
        public frmToast(string Title, string Subject, string Message, string Reference, byte[] Image, int Duration, Native.FormAnimator.AnimationMethod Animation, Native.FormAnimator.AnimationDirection Direction)
        {
            InitializeComponent();

            _Title = Title;
            _Subject = Subject;
            _Message = Message;
            _Reference = Reference;
            _Image = byteArrayToImage(Image);
            _Duration = Duration;
            _Animation = Animation;
            _Direction = Direction;

            //if (Duration < 0)
            //    Duration = int.MaxValue;
            //else
            //    Duration = Duration * 1000;

            //lifeTimer.Interval = Duration;
            //lblTitle.Text = Title;
            //lblSubject.Text = Subject;
            //lblMessage.Text = Message;
            //lblReference.Text = Reference;
            //picToast.BackgroundImage = Image;

            _Animator = new Native.FormAnimator(this, Animation, Direction, 500);

            // Rounded corners
            //Region = Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, Width - 5, Height - 5, 20, 20));
        }

        #region Methods

        /// <summary>
        /// Displays the form
        /// </summary>
        /// <remarks>
        /// Required to allow the form to determine the current foreground window before being displayed
        /// </remarks>
        public new void Show()
        {
            // Determine the current foreground window so it can be reactivated each time this form tries to get the focus
            _CurrentForegroundWindow = Native.Methods.GetForegroundWindow();

            base.Show();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        #endregion // Methods

        #region Event Handlers

        private void Notification_Load(object sender, EventArgs e)
        {
            // Display the form just above the system tray.
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width, Screen.PrimaryScreen.WorkingArea.Height - Height);

            // Move each open form upwards to make room for this one
            foreach (frmToast openForm in _OpenNotifications)
            {
                openForm.Top -= Height;
            }

            _OpenNotifications.Add(this);
            lifeTimer.Start();
        }

        private void Notification_Activated(object sender, EventArgs e)
        {
            // Prevent the form taking focus when it is initially shown
            if (!_AllowFocus)
            {
                // Activate the window that previously had focus
                Native.Methods.SetForegroundWindow(_CurrentForegroundWindow);
            }
        }

        private void Notification_Shown(object sender, EventArgs e)
        {
            switch (_Duration)
            {
                case -2:
                    lifeTimer.Interval = int.MaxValue;
                    break;
                case -1:
                    lifeTimer.Interval = int.MaxValue;
                    break;
                case 0:

                    lifeTimer.Interval = int.MaxValue;
                    break;
                default:
                    lifeTimer.Interval = _Duration * 1000;
                    break;
            }

            // lifeTimer.Interval = Duration;
            lblTitle.Text = _Title;
            lblSubject.Text = _Subject;
            lblMessage.Text = _Message;
            lblReference.Text = _Reference;
            picToast.BackgroundImage = _Image;

            // Once the animation has completed the form can receive focus
            _AllowFocus = true;

            // Close the form by sliding down.
            _Animator.Duration = 0;
            _Animator.Direction = Native.FormAnimator.AnimationDirection.Down;
        }

        private void Notification_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Move down any open forms above this one
            foreach (frmToast openForm in _OpenNotifications)
            {
                if (openForm == this)
                {
                    // Remaining forms are below this one
                    break;
                }
                openForm.Top += Height;
            }

            _OpenNotifications.Remove(this);
        }

        private void lifeTimer_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        #endregion // Event Handlers

        private void AlertTimer_Tick(object sender, EventArgs e)
        {

        }
    }
}