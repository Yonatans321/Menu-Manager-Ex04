using Ex04.Menus.Interfaces;
using System;

namespace Ex04.Menus.Test
{
    public class CountCapitals : IMenuSelectionListener
    {
        public void ReportSelection()
        {
            int capitalsCounter = 0;
            Console.WriteLine("Please enter your text:");
            string userInput = Console.ReadLine();

            if (userInput != null)
            {
                foreach (char ch in userInput)
                {
                    if (char.IsUpper(ch))
                    {
                        capitalsCounter++;
                    }
                }
            }

            Console.WriteLine($"> There are {capitalsCounter} uppercase letters in your text");
        }
    }
}
