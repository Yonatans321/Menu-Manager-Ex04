using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;

namespace Ex04.Menus.Test
{
    public class ShowCurrentTime : IMenuSelectionListener
    {
        public void ReportSelection()
        {
            Console.WriteLine($"> Current Time is {DateTime.Now.ToString("HH:mm:ss")}");
        }
    }
}
