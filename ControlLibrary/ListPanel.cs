using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VaderConsulting.ControlLibrary
{
    public class ListPanel : Panel
    {
        #region Delegates

        public delegate void ItemClickEventHandler(object sender, ItemClickEventArgs e);

        #endregion

        #region Events

        public event ItemClickEventHandler ItemClick;

        #endregion

        #region Fields

        private List<PanelContent> _Items = new List<PanelContent>();
        private PanelContent _SelectedItem = null;
        private int _SelectedIndex = -1;

        #endregion

        #region Constructors

        public ListPanel()
        {
            AutoScroll = true;
            BorderStyle = BorderStyle.FixedSingle;
        }

        #endregion

        #region Properties

        public int SelectedIndex
        {
            get
            {
                return _SelectedIndex;
            }

            set
            {
                _SelectedIndex = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<PanelContent> Items
        {
            get
            {
                return _Items;
            }

            set
            {
                _Items = value;
            }
        }

        public PanelContent SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
        }

        #endregion

        #region Event Handlers

        private void Item_Clicked(object sender, EventArgs e)
        {
            PanelContent Item = sender as PanelContent;

            if (_SelectedItem != null)
            {
                _SelectedItem.Selected = false;
            }

            _SelectedItem = Item;
            _SelectedIndex = Item.Index;

            Item.Selected = true;

            if (ItemClick != null)
            {
                ItemClick(this, new ItemClickEventArgs() { Item = Item });
            }
        }

        #endregion

        #region Public Methods

        public void AddItem(PanelContent Item)
        {
            Item.Index = _Items.Count;

            _Items.Add(Item);

            Item.Dock = DockStyle.Top;
            Item.Parent = this;

            Controls.Add(Item);
            Item.Width = this.Width - 6;

            Item.BringToFront();
            Item.Click += Item_Clicked;
        }

        public void Clear()
        {
            _Items.Clear();
            Controls.Clear();
        }

        public new void Refresh()
        {

        }

        #endregion
    }
}
