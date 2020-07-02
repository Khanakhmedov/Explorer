using System;

namespace Explorer.UI
{
    public class Folder : MenuItem
    {
        public override void Draw()
        {
            if (IsHover)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(Name);
        }
    }
}
