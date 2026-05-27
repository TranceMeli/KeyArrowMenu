using System;
using KeyArrowMenu;

namespace KeyArrowMenu
{
    internal static class App
    {
        public static void Run()
        {
            new ConsoleMenu
            {
                Title = "My Program"
            }
            .Add("Option 1", OptionOne)
            .Add("Option 2", OptionTwo)
            .Add("Option 3", OptionThree)
            .AddExit("Exit")
            .Show();
        }

        private static void OptionOne()
        {
            Console.WriteLine("Option 1 selected.");
        }

        private static void OptionTwo()
        {
            Console.WriteLine("Option 2 selected.");
        }

        private static void OptionThree()
        {
            Console.WriteLine("Option 3 selected.");
        }
    }
}