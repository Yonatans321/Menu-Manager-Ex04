using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowCurrentDate : IMenuSelectionListener
    {
        public void ReportSelection()
        {
            Console.WriteLine($"> Current Date is {DateTime.Now.ToString("dd/MM/yyyy")}");
        }
    }
}
