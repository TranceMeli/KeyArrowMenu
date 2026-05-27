using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyArrowMenu
{
    public class ConsoleMenu
    {
        public string Title { get; set; } = string.Empty;
        public ConsoleColor HighlightBackground { get; set; } = ConsoleColor.Gray;
        public ConsoleColor HighlightForeground { get; set; } = ConsoleColor.White;
        public bool AutoReturn { get; set; } = false;

        private readonly List<(string Label, Action Handler)> _entries = new();

        public ConsoleMenu Add(string label, Action handler)
        {
            if (string.IsNullOrWhiteSpace(label))
                throw new ArgumentException("Label must not be empty.", nameof(label));

            _entries.Add((label, handler ?? (() => { })));
            return this;
        }

        public ConsoleMenu AddExit(string label = "Exit")
            => Add(label, () => Environment.Exit(0));

        public void Show()
        {
            if (_entries.Count == 0)
                throw new InvalidOperationException("The menu has no entries.");

            int selectedIndex = 0;
            bool running = true;
            Console.CursorVisible = false;

            while (running)
            {
                Render(selectedIndex);

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = selectedIndex == 0
                            ? _entries.Count - 1
                            : selectedIndex - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        selectedIndex = selectedIndex == _entries.Count - 1
                            ? 0
                            : selectedIndex + 1;
                        break;

                    case ConsoleKey.Enter:
                        ExecuteEntry(selectedIndex, ref running);
                        break;

                    case ConsoleKey.Escape:
                        running = false;
                        break;
                }
            }

            Console.CursorVisible = true;
            Console.ResetColor();
            Console.Clear();
        }

        private void Render(int selectedIndex)
        {
            string hint = "Up/Down to navigate  |  Enter to select  |  ESC to close";

            int lineWidth = _entries.Max(e => e.Label.Length + 5);
            lineWidth = Math.Max(lineWidth, hint.Length);
            if (!string.IsNullOrWhiteSpace(Title))
                lineWidth = Math.Max(lineWidth, Title.Length);

            string line = new string('-', lineWidth);

            Console.Clear();

            if (!string.IsNullOrWhiteSpace(Title))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(Title);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(line);
                Console.ResetColor();
            }

            for (int i = 0; i < _entries.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = HighlightBackground;
                    Console.ForegroundColor = HighlightForeground;
                    Console.WriteLine($" > {_entries[i].Label} < ");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"   {_entries[i].Label}");
                    Console.ResetColor();
                }
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(line);
            Console.WriteLine(hint);
            Console.ResetColor();
        }

        private void ExecuteEntry(int index, ref bool running)
        {
            string header = $"> {_entries[index].Label}";
            string line = new string('-', header.Length);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(header);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(line);
            Console.ResetColor();
            Console.WriteLine();

            try
            {
                _entries[index].Handler();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }

            if (!AutoReturn)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Press any key to return to the menu...");
                Console.ResetColor();
                Console.ReadKey(true);
            }
        }
    }
}