using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_Center
{
    public class ToastMessageReceivedEventArgs : EventArgs
    {
        private ToastMessage _Message = null;
        private DateTime _Timestamp = DateTime.MinValue;

        public ToastMessage Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        public DateTime Timestamp
        {
            get
            {
                return _Timestamp;
            }
            set
            {
                _Timestamp = value;
            }
        }

        public ToastMessageReceivedEventArgs()
        {

        }

        public ToastMessageReceivedEventArgs(ToastMessage Message)
        {
            _Message = Message;
            _Timestamp = DateTime.Now;
        }
    }
}
