using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaderConsulting.ControlLibrary
{
    public class ItemClickEventArgs : EventArgs
    {
        public PanelContent Item { get; set; }
    }
}
