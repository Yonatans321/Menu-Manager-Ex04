using System;
using InterfacesMenu = Ex04.Menus.Interfaces;
using EventsMenu = Ex04.Menus.Events;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            runInterfacesMenu();
            Console.Clear();
            runEventsMenu();
        }

        private static void runInterfacesMenu()
        {
            InterfacesMenu.MenuItem mainMenu = new InterfacesMenu.MenuItem("Interfaces Main Menu");
            InterfacesMenu.MenuItem dateTimeMenu = new InterfacesMenu.MenuItem("Show Current Date/Time");
            InterfacesMenu.MenuItem showDateItem = new InterfacesMenu.MenuItem("Show Current Date");
            InterfacesMenu.MenuItem showTimeItem = new InterfacesMenu.MenuItem("Show Current Time");
            InterfacesMenu.MenuItem versionCapitalsMenu = new InterfacesMenu.MenuItem("Version and Capitals");
            InterfacesMenu.MenuItem countCapitalsItem = new InterfacesMenu.MenuItem("Count Capitals");
            InterfacesMenu.MenuItem showVersionItem = new InterfacesMenu.MenuItem("Show Version");
            InterfacesMenu.MainMenu menuManager;

            showDateItem.AddListener(new ShowCurrentDate());
            showTimeItem.AddListener(new ShowCurrentTime());
            dateTimeMenu.AddSubItem(showDateItem);
            dateTimeMenu.AddSubItem(showTimeItem);

            countCapitalsItem.AddListener(new CountCapitals());
            showVersionItem.AddListener(new ShowVersion());
            versionCapitalsMenu.AddSubItem(countCapitalsItem);
            versionCapitalsMenu.AddSubItem(showVersionItem);

            mainMenu.AddSubItem(dateTimeMenu);
            mainMenu.AddSubItem(versionCapitalsMenu);

            menuManager = new InterfacesMenu.MainMenu(mainMenu);
            menuManager.Show();
        }

        private static void runEventsMenu()
        {
            EventsMenu.MenuItem mainMenu = new EventsMenu.MenuItem("Delegates Main Menu");
            EventsMenu.MenuItem dateTimeMenu = new EventsMenu.MenuItem("Show Current Date/Time");
            EventsMenu.MenuItem showDateItem = new EventsMenu.MenuItem("Show Current Date");
            EventsMenu.MenuItem showTimeItem = new EventsMenu.MenuItem("Show Current Time");
            EventsMenu.MenuItem versionCapitalsMenu = new EventsMenu.MenuItem("Version and Capitals");
            EventsMenu.MenuItem countCapitalsItem = new EventsMenu.MenuItem("Count Capitals");
            EventsMenu.MenuItem showVersionItem = new EventsMenu.MenuItem("Show Version");
            EventsMenu.MainMenu menuManager;

            showDateItem.Selected += showDateItem_Selected;
            showTimeItem.Selected += showTimeItem_Selected;
            dateTimeMenu.AddSubItem(showDateItem);
            dateTimeMenu.AddSubItem(showTimeItem);

            countCapitalsItem.Selected += countCapitalsItem_Selected;
            showVersionItem.Selected += showVersionItem_Selected;
            versionCapitalsMenu.AddSubItem(countCapitalsItem);
            versionCapitalsMenu.AddSubItem(showVersionItem);

            mainMenu.AddSubItem(dateTimeMenu);
            mainMenu.AddSubItem(versionCapitalsMenu);

            menuManager = new EventsMenu.MainMenu(mainMenu);
            menuManager.Show();
        }





        private static void showDateItem_Selected(EventsMenu.MenuItem i_Sender)
        {
            Console.WriteLine($"> Current Date is {DateTime.Now.ToString("dd/MM/yyyy")}");
        }

        private static void showTimeItem_Selected(EventsMenu.MenuItem i_Sender)
        {
            Console.WriteLine($"> Current Time is {DateTime.Now.ToString("HH:mm:ss")}");
        }

        private static void countCapitalsItem_Selected(EventsMenu.MenuItem i_Sender)
        {
            int capitalsCount = 0;

            Console.WriteLine("Please enter your text:");
            string userInput = Console.ReadLine();

            if (userInput != null)
            {
                foreach (char c in userInput)
                {
                    if (char.IsUpper(c))
                    {
                        capitalsCount++;
                    }
                }
            }
            Console.WriteLine($"> There are {capitalsCount} uppercase letters in your text");
        }

        private static void showVersionItem_Selected(EventsMenu.MenuItem i_Sender)
        {
            Console.WriteLine("App Version: 26.2.4.7310");
        }
    }
}
