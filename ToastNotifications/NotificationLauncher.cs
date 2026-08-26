using Contracts;
using System;
using System.Drawing;
using System.IO;
using System.ServiceModel;
using System.Windows.Forms;

namespace CreateToastNotifications
{
    public partial class NotificationLauncher : Form
    {
        private bool _initialLoad = true;
        private Color _Panel5Colour = SystemColors.WindowText;

        public NotificationLauncher()
        {
            InitializeComponent();
            PopulateComboBoxes();
        }

        private void PopulateComboBoxes()
        {
            foreach (Native.FormAnimator.AnimationMethod method in Enum.GetValues(typeof(Native.FormAnimator.AnimationMethod)))
            {
                comboBoxAnimation.Items.Add(method.ToString());
            }
            comboBoxAnimation.SelectedIndex = 2;

            foreach (Native.FormAnimator.AnimationDirection direction in Enum.GetValues(typeof(Native.FormAnimator.AnimationDirection)))
            {
                comboBoxAnimationDirection.Items.Add(direction.ToString());
            }
            comboBoxAnimationDirection.SelectedIndex = 3;

            var soundsFolder = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds"));
            foreach (var file in soundsFolder.GetFiles())
            {
                comboBoxSound.Items.Add(Path.GetFileNameWithoutExtension(file.FullName));
            }
            comboBoxSound.SelectedIndex = 5;
            _initialLoad = false;

            comboBoxDuration.SelectedIndex = 0;
        }

        private void ShowNotification()
        {
            int duration;
            int.TryParse(comboBoxDuration.SelectedItem.ToString(), out duration);
            if (duration <= 0)
            {
                duration = -1;
            }

            var animationMethod = Native.FormAnimator.AnimationMethod.Slide;
            foreach (Native.FormAnimator.AnimationMethod method in Enum.GetValues(typeof(Native.FormAnimator.AnimationMethod)))
            {
                if (string.Equals(method.ToString(), comboBoxAnimation.SelectedItem))
                {
                    animationMethod = method;
                    break;
                }
            }

            var animationDirection = Native.FormAnimator.AnimationDirection.Up;
            foreach (Native.FormAnimator.AnimationDirection direction in Enum.GetValues(typeof(Native.FormAnimator.AnimationDirection)))
            {
                if (string.Equals(direction.ToString(), comboBoxAnimationDirection.SelectedItem))
                {
                    animationDirection = direction;
                    break;
                }
            }

            var toastNotification = new frmToast(txtApplication.Text, txtSubject.Text, txtMessage.Text, txtReference.Text, imageToByteArray(picToast.BackgroundImage), duration, animationMethod, animationDirection);
            //PlayNotificationSound(comboBoxSound.Text);
            toastNotification.Show();
        }

        private void buttonShowNotification_Click(object sender, EventArgs e)
        {
            ToastMessage NewMessage = new ToastMessage();

            NewMessage.GroupName = txtApplication.Text;
            NewMessage.Body = txtMessage.Text;
            NewMessage.ImageByteArray = imageToByteArray(picToast.BackgroundImage);
            NewMessage.Reference = txtReference.Text;
            NewMessage.Subject = txtSubject.Text;
            NewMessage.HighPriority = chkHighPriority.Checked;

            #region Duration

            int Duration = 0;

            switch (comboBoxDuration.SelectedItem.ToString())
            {
                case "Sticky":
                    Duration = -1;
                    break;
                case "1":
                    Duration = 1;
                    break;
                case "3":
                    Duration = 3;
                    break;
                case "5":
                    Duration = 5;
                    break;
                case "10":
                    Duration = 5;
                    break;
                case "Alert":
                    Duration = 0;
                    break;
            }



            NewMessage.Duration = Duration;

            #endregion

            #region Animation Method

            foreach (Native.FormAnimator.AnimationMethod method in Enum.GetValues(typeof(Native.FormAnimator.AnimationMethod)))
            {
                if (string.Equals(method.ToString(), comboBoxAnimation.SelectedItem))
                {
                    NewMessage.Method = method;
                    break;
                }
            }

            #endregion

            #region Animation Direction

            foreach (Native.FormAnimator.AnimationDirection direction in Enum.GetValues(typeof(Native.FormAnimator.AnimationDirection)))
            {
                if (string.Equals(direction.ToString(), comboBoxAnimationDirection.SelectedItem))
                {
                    NewMessage.Direction = direction;
                    break;
                }
            }

            #endregion

            #region Colours

            NewMessage.SubjectColour = panel1.BackColor;
            NewMessage.MessageColour = panel2.BackColor;
            NewMessage.SelectedColour = panel3.BackColor;
            NewMessage.HoverColour = panel4.BackColor;
            NewMessage.BackColour = panel5.BackColor;

            #endregion

            SendToast(NewMessage); 
        }

        private static void PlayNotificationSound(string sound)
        {
            var soundsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds");
            var soundFile = Path.Combine(soundsFolder, sound + ".wav");

            using (var player = new System.Media.SoundPlayer(soundFile))
            {
                player.Play();
            }
        }

        private void comboBoxSound_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                PlayNotificationSound(comboBoxSound.Text);
            }
        }

        private void SendToast(ToastMessage Message)
        {
            Uri BaseAddress = new Uri("net.pipe://localhost/Messages/Inbox");

            NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            EndpointAddress ep = new EndpointAddress(BaseAddress);
            IToastMessageService channel = ChannelFactory<IToastMessageService>.CreateChannel(binding, ep);

            try
            {
                channel.Submit(Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();

            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);

            return ms.ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            DialogResult dr = cd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                panel1.BackColor = cd.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            DialogResult dr = cd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                panel2.BackColor = cd.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            DialogResult dr = cd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                panel3.BackColor = cd.Color;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            DialogResult dr = cd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                panel4.BackColor = cd.Color;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            DialogResult dr = cd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                panel5.BackColor = cd.Color;
            }
        }

        private void chkHighPriority_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHighPriority.Checked)
            {
                _Panel5Colour = panel5.BackColor;
                panel5.BackColor = Color.Red;
            }
            else
            {
                panel5.BackColor = _Panel5Colour;
            }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }

        //public Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    Image returnImage = Image.FromStream(ms);
        //    return returnImage;
        //}

    }
}
