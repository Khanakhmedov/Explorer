namespace Explorer.UI
{
    public static class ItemPosition
    {
        public static int X { get; set; } = 1;
        public static int Y { get; set; } = 2;
        public static int LastIndexPosition { get; set; } = 0;

        static public void Reset()
        {
            X = 1;
            Y = 2;
        }
    }
}
