using System;

namespace Explorer.UI
{
    public class File : MenuItem
    {
        public override void Draw()
        {
            if (IsHover)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(Name);
        }
    }
}
