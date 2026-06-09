using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private string m_Title;
        private readonly List<MenuItem> r_SubMenuItems = new List<MenuItem>();
        private readonly List<IMenuSelectionListener> r_MenuListeners = new List<IMenuSelectionListener>();

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

        public void AddListener(IMenuSelectionListener i_Listener)
        {
            r_MenuListeners.Add(i_Listener);
        }

        public void RemoveListener(IMenuSelectionListener i_Listener)
        {
            r_MenuListeners.Remove(i_Listener);
        }

        public bool IsLeaf
        {
            get
            {
                return r_SubMenuItems.Count == 0;
            }
        }


        public void OnSelected()
        {
            foreach (IMenuSelectionListener listener in r_MenuListeners)
            {
                listener.ReportSelection();
            }
        }
    }
}
