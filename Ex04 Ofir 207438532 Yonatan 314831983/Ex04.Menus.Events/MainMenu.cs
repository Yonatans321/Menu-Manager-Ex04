using System;
using System.Collections.Generic;

namespace Ex04.Menus.Events
{
    public class MainMenu
    {
        private readonly MenuItem r_RootMenuItem;

        public MainMenu(MenuItem i_RootMenuItem)
        {
            r_RootMenuItem = i_RootMenuItem;
        }

        public void Show()
        {
            List<MenuItem> menuPath = new List<MenuItem>();
            MenuItem currentMenu;
            bool isRoot;
            string exitOrBackText;
            string showExitOrGoBack;
            int userChoice;
            MenuItem selectedItem;
            bool isMenuRunning = true;

            menuPath.Add(r_RootMenuItem);

            while (isMenuRunning)
            {
                currentMenu = menuPath[menuPath.Count - 1];
                isRoot = (menuPath.Count == 1);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"** {currentMenu.Title} **");
                Console.ResetColor();
                Console.WriteLine("--------------------------");

                for (int i = 0; i < currentMenu.SubMenuItems.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {currentMenu.SubMenuItems[i].Title}");
                }

                if (isRoot)
                {
                    exitOrBackText = "Exit";
                    showExitOrGoBack = "exit";
                }
                else
                {
                    exitOrBackText = "Back";
                    showExitOrGoBack = "go back";
                }

                Console.WriteLine($"0. {exitOrBackText}");
                Console.WriteLine($"Please enter your choice (1-{currentMenu.SubMenuItems.Count} or 0 to {showExitOrGoBack}):");
                Console.Write(">> ");

                userChoice = getValidChoice(currentMenu.SubMenuItems.Count);

                if (userChoice == 0)
                {
                    if (isRoot)
                    {
                        isMenuRunning = false;
                    }
                    else
                    {
                        Console.Clear();
                        menuPath.RemoveAt(menuPath.Count - 1);
                    }
                }
                else
                {
                    selectedItem = currentMenu.SubMenuItems[userChoice - 1];

                    if (selectedItem.IsLeaf)
                    {
                        selectedItem.DoWhenSelected();
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Clear();
                        menuPath.Add(selectedItem);
                    }
                }
            }
        }

        private int getValidChoice(int i_MaxChoice)
        {
            int parsedChoice;
            string userInput = Console.ReadLine();
            bool isValid = int.TryParse(userInput, out parsedChoice);

            while (!isValid || parsedChoice < 0 || parsedChoice > i_MaxChoice)
            {
                Console.WriteLine($"Invalid input. Please enter a number between 0 and {i_MaxChoice}:");
                userInput = Console.ReadLine();
                isValid = int.TryParse(userInput, out parsedChoice);

            }

            return parsedChoice;
        }

    }
}
