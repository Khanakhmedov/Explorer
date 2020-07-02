using Explorer.Logic;
using System;
using System.Text;

namespace Explorer
{
    class Program
    {
        static void Main(string[] args)
        {        
            Console.OutputEncoding = Encoding.UTF8;
            Manager manager = new Manager(new FileManager());
            manager.Start();
        }
    }
}
