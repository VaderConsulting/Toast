using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [DataContract]
    public class ToastMessage
    {
        [DataMember(IsRequired = true)]
        public string GroupName
        {
            get; set;
        }

        [DataMember(IsRequired = true)]
        public string Subject
        {
            get; set;
        }

        [DataMember(IsRequired = true)]
        public string Body
        {
            get; set;
        }

        [DataMember(IsRequired = false)]
        public string Reference
        {
            get; set;
        }

        [DataMember(IsRequired = false)]
        public byte[] ImageByteArray
        {
            get; set;
        }

        [DataMember(IsRequired = false)]
        public int Duration
        {
            get; set;
        }

        [DataMember(IsRequired = false)]
        public Native.FormAnimator.AnimationMethod Method
        {
            get; set;
        }

        [DataMember(IsRequired = false)]
        public Native.FormAnimator.AnimationDirection Direction
        {
            get; set;
        }

        [DataMember(IsRequired = false)]
        public Color SubjectColour
        {
            get; set;
        }

        [DataMember(IsRequired = false)]
        public Color MessageColour
        {
            get; set;
        }

        [DataMember(IsRequired = false)]
        public Color SelectedColour
        {
            get; set;
        }

        [DataMember(IsRequired = false)]
        public Color HoverColour
        {
            get; set;
        }

        [DataMember(IsRequired = false)]
        public Color BackColour
        {
            get; set;
        }

        [DataMember(IsRequired = false)]
        public bool HighPriority
        {
            get; set;
        }

    }
}
