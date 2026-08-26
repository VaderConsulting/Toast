using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Native;
using System.Diagnostics;
using System.Reflection;
using System.ServiceModel;
using Contracts;
using System.ServiceModel.Description;
using VaderConsulting.ACControls;
using VaderConsulting.ControlLibrary;
using System.IO;


namespace Action_Center
{
    public partial class ActionCentre : Form
    {
        private Native.FormAnimator _Animator;
        private ServiceHost _ServiceHost = null;
        private bool _HighPriority = false;
        private bool _IconRed = false;
        private List<ACMessageGroup> _Groups = new List<ACMessageGroup>();
        private const int WM_DWMCOLORIZATIONCOLORCHANGED = 800;

        public ActionCentre()
        {
            InitializeComponent();

            Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 1;
            Height = Screen.PrimaryScreen.WorkingArea.Height;

            _Animator = new Native.FormAnimator(this, FormAnimator.AnimationMethod.Slide, FormAnimator.AnimationDirection.RightToLeft, 150);
            notify.Icon = Properties.Resources.NoMessages_Icon;

            Colorise();
            Hide();

            StartServer();
        }

        private void ActionCentre_Deactivate(object sender, EventArgs e)
        {
            // Set up sliding for exiting
            _Animator.Direction = FormAnimator.AnimationDirection.LeftToRight;

            Hide();

            // Set up sliding for loading
            _Animator.Direction = FormAnimator.AnimationDirection.RightToLeft;
        }

        private void ActionCentre_Shown(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void Colorise()
        {
            this.BackColor = Native.Methods.GetChromeColor(SystemColors.Desktop);
            this.lblActionCenter.ForeColor = GetContrastingColor(this.BackColor);
            this.lblClearAll.ForeColor = GetContrastingColor(this.BackColor);
            this.lblNoNewNotifications.ForeColor = GetContrastingColor(this.BackColor);
        }

        private void notify_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void StartServer()
        {
            Uri BaseAddress = new Uri("net.pipe://localhost/Messages/Inbox");
            NetNamedPipeBinding NamedPipeBinding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            ToastMessageService svc = new ToastMessageService();

            _ServiceHost = new ServiceHost(svc, BaseAddress);
            _ServiceHost.AddServiceEndpoint(typeof(IToastMessageService), NamedPipeBinding, "");
            _ServiceHost.Open();

            (_ServiceHost.SingletonInstance as ToastMessageService).ToastMessageReceived += new ToastMessageService.ToastServiceMessageEventHandler(ToastMessageReceived);
        }

        private void ActionCentre_Load(object sender, EventArgs e)
        {
            notify.Icon = Properties.Resources.NoMessages_Icon;
            notify.Text = "No new messages";
        }

        private void ToastMessageReceived(object Sender, ToastMessageReceivedEventArgs e)
        {
            PanelContent NewItem = new PanelContent();

            NewItem.GroupName = e.Message.GroupName;
            NewItem.Subject = e.Message.Subject;
            NewItem.Body = e.Message.Body;
            NewItem.Image = byteArrayToImage(e.Message.ImageByteArray);
            NewItem.SubjectColour = e.Message.SubjectColour;
            NewItem.MessageColour = e.Message.MessageColour;
            NewItem.BackColour = e.Message.BackColour;
            NewItem.HoverColour = e.Message.HoverColour;
            NewItem.SelectedColour = e.Message.SelectedColour;

            MessageArea.Controls.Add(NewItem);
            //panel.AddItem(NewItem);

            if (e.Message.HighPriority)
            {
                _HighPriority = true;
                this.Show();
            }

            tmrNewMessage.Enabled = true;

            notify.Icon = Properties.Resources.NewMessage_Icon;

            notify.Text = "New messages";

            lblClearAll.Visible = true;

            lblNoNewNotifications.Visible = false;
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void lblClearAll_Click(object sender, EventArgs e)
        {
            lblClearAll.Visible = false;

            MessageArea.Controls.Clear();
            //panel.Clear();

            notify.Icon = Properties.Resources.NoMessages_Icon;
            notify.Text = "No new messages";

            _IconRed = false;
            _HighPriority = false;

            lblNoNewNotifications.Visible = true;

            Hide();
        }

        private void tmrHighPriority_Tick(object sender, EventArgs e)
        {
            if (_IconRed)
            {
                notify.Icon = Properties.Resources.Messages_Icon;
            }
            else
            {
                notify.Icon = Properties.Resources.Messages_red_Icon;
            }

            _IconRed = !_IconRed;

            if (!_HighPriority)
            {
                tmrHighPriority.Enabled = false;

                if (MessageArea.Controls.Count > 0)
                {
                    notify.Icon = Properties.Resources.Messages_Icon;
                }
                else
                {
                    notify.Icon = Properties.Resources.NoMessages_Icon;
                }
            }
        }

        private void tmrNewMessage_Tick(object sender, EventArgs e)
        {
            tmrNewMessage.Enabled = false;

            notify.Icon = Properties.Resources.Messages_Icon;

            if (_HighPriority)
            {
                notify.Icon = Properties.Resources.Messages_red_Icon;

                tmrHighPriority.Enabled = true;
            }
            else
            {
                notify.Icon = Properties.Resources.Messages_Icon;
            }

        }

        private Color GetContrastingColor(Color value)
        {
            var d = 0;

            // Counting the perceptive luminance - human eye favors green color... 
            double a = 1 - (0.299 * value.R + 0.587 * value.G + 0.114 * value.B) / 255;

            if (a < 0.5)
                d = 0; // bright colors - black font
            else
                d = 255; // dark colors - white font

            return Color.FromArgb(d, d, d);
        }

        protected override void WndProc(ref Message msg)
        {
            Boolean handled = false;
            msg.Result = IntPtr.Zero;

            if (msg.Msg == WM_DWMCOLORIZATIONCOLORCHANGED)
            {
                Colorise();

                handled = true;
                msg.Result = new IntPtr(1);
            }

            if (handled)
                DefWndProc(ref msg);
            else
                base.WndProc(ref msg);
            
        }
    }
}
