using System;

namespace Explorer.UI
{
    public abstract class MenuItem
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Action Action { get; set; }
        public bool IsHover { get; set; }

        public virtual void Draw()
        {
            
        }
    }
}
