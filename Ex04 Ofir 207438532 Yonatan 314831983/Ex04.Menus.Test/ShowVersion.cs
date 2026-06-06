using Ex04.Menus.Interfaces;
using System;


namespace Ex04.Menus.Test
{
    public class ShowVersion : IMenuSelectionListener
    {
        public void ReportSelection()
        {
            Console.WriteLine("App Version: 26.2.4.7310");
        }
    }
}
