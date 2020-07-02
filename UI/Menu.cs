using System;
using System.Collections.Generic;

namespace Explorer.UI
{
    public class Menu
    {
        public string Path { get; set; }
        public List<MenuItem> Items { get; set; }

        public virtual void Run()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(ItemPosition.X, 1);
            Console.WriteLine(Path);
            foreach (MenuItem item in Items)
            {
                item.Y = ItemPosition.Y;
                ItemPosition.Y += 1;
                item.X = ItemPosition.X;
            }
        }
    }
}
