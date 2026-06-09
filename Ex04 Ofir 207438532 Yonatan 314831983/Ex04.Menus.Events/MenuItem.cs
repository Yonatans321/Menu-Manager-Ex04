using System;
using System.Collections.Generic;

namespace Ex04.Menus.Events
{
    public class MenuItem
    {
        private string m_Title;
        private readonly List<MenuItem> r_SubMenuItems = new List<MenuItem>();
        public event Action<MenuItem> Selected;

        public MenuItem(string i_Title)
        {
            m_Title = i_Title;
        }

        public string Title
        {
            get
            {
                return m_Title;
            }

            set
            {
                m_Title = value;
            }
        }

        public List<MenuItem> SubMenuItems
        {
            get
            {
                return r_SubMenuItems;
            }
        }

        public void AddSubItem(MenuItem i_Item)
        {
            r_SubMenuItems.Add(i_Item);
        }

        public void RemoveSubItem(MenuItem i_Item)
        {
            r_SubMenuItems.Remove(i_Item);
        }

        public bool IsLeaf
        {
            get
            {
                return r_SubMenuItems.Count == 0;
            }
        }

        public void DoWhenSelected()
        {
            OnSelected();
        }

        protected virtual void OnSelected()
        {
            if (Selected != null)
            {
                Selected.Invoke(this);
            }
        }
    }
}
