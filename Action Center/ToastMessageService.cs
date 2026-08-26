using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using System.ServiceModel;
using System.Diagnostics;

namespace Action_Center
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ToastMessageService : IToastMessageService
    {
        public event ToastServiceMessageEventHandler ToastMessageReceived = delegate { };
        public delegate void ToastServiceMessageEventHandler(object sender, ToastMessageReceivedEventArgs e);

        public bool Submit(ToastMessage Message)
        {
            bool Result = false;

            try
            {
                Debug.Print("Message received:" + Message.Body);

                // Add the received message to the Action Center;
                ShowNotification(Message);

                Result = true;
            }
            catch
            {
            }

            return Result;
        }

        private void ShowNotification(ToastMessage Message)
        {
            frmToast toastNotification = new frmToast(Message.GroupName, 
                                                      Message.Subject, 
                                                      Message.Body, 
                                                      Message.Reference, 
                                                      Message.ImageByteArray, 
                                                      Message.Duration, 
                                                      Message.Method, 
                                                      Message.Direction);
            
            //PlayNotificationSound(comboBoxSound.Text);
            toastNotification.Show();

            ToastMessageReceivedEventArgs e = new ToastMessageReceivedEventArgs(Message);

            OnToastMessageReceived(e);

        }

        public virtual void OnToastMessageReceived(ToastMessageReceivedEventArgs e)
        {
            ToastServiceMessageEventHandler handler = ToastMessageReceived;

            if (handler != null)
            {
                handler(this, e);
            }
        }

    }
}
