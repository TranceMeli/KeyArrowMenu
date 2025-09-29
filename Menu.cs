using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyArrowMenu
{
    class Menu
    {    
        public static void HauptMenu()
        {
            int selectedIndex = 0; // currently highlighted option
            Console.CursorVisible = false; // hide blinking cursor
            bool menuLoop = true;

            string[] menuOptions =
            {
            "Option 1",
            "Option 2",
            "Option 3",
            "Option 4",
            "Exit",
            };

            while (menuLoop)
            {
                Console.Clear();

                for (int i = 0; i < menuOptions.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine($" > {menuOptions[i]} < ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"   {menuOptions[i]}");
                    }
                }
                Console.ResetColor();

                var key = Console.ReadKey(true).Key; // read a key press

                if (key == ConsoleKey.UpArrow)
                {
                    if (selectedIndex == 0)
                    {
                        selectedIndex = menuOptions.Length - 1; // if at the top go to the last option
                    }
                    else
                    {
                        selectedIndex--; // otherwise, move up
                    }
                }
                else if (key == ConsoleKey.DownArrow) // if at the bottom go to the first option
                {

                    if (selectedIndex == menuOptions.Length - 1)
                    {
                        selectedIndex = 0; // otherwise, move down
                    }
                    else
                    {
                        selectedIndex++;
                    }
                }
                else if (key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.WriteLine($"You have selected {menuOptions[selectedIndex]}");


                    if (selectedIndex == 0)
                    {

                    }
                    else if (selectedIndex == 1)
                    {

                    }
                    else if (selectedIndex == 2)
                    {

                    }
                    else if (selectedIndex == 3)
                    {

                    }
                    else if (selectedIndex == 4)
                    {
                        Console.WriteLine("Goodbye");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice");

                    }
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey(true);
                }
                else if (key == ConsoleKey.Escape)
                { Console.WriteLine("Goodbye");
                    menuLoop = false;
                }
            }
        }
    }  
}
