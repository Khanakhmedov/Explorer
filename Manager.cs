
using Explorer.Logic.Interfaces;
using Explorer.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Explorer
{
    public class Manager
    {
        private Menu activeMenu;
        private Stack<UI.Menu> history;
        private Stack<int> indexHistory;
        private int index;
        private readonly IFileManager fileManager;

        public Manager(IFileManager fileManager)
        {
            history = new Stack<UI.Menu>();
            indexHistory = new Stack<int>();
            this.fileManager = fileManager;
            index = 0;

            var items = fileManager.GetDrives();
            List<MenuItem> drives = new List<MenuItem>();
            foreach (var i in items)
            {
                drives.Add(
                    new Folder() { Path = i, Name = i.Replace("\\", String.Empty), Action = () => next(i) }
                );
            }

            Menu menu = new Menu
            {
                Items = drives,
                Path = "This PC"
            };
            activeMenu = menu;

        }

        public void Start()
        {
            while (true)
            {
                ItemPosition.Reset();
                activeMenu.Run();
                Console.Title = activeMenu.Path;
                for (int i = 0; i < activeMenu.Items.Count; i++)
                {
                    if (i == index)
                    {
                        activeMenu.Items[i].IsHover = true;
                        activeMenu.Items[i].Draw();
                    }
                    else
                    {
                        activeMenu.Items[i].IsHover = false;
                        activeMenu.Items[i].Draw();
                    }
                }

                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (index == 0)
                            {
                                index = activeMenu.Items.Count - 1;
                            }
                            else { index--; }
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (index == activeMenu.Items.Count - 1)
                            {
                                index = 0;
                            }
                            else { index++; }
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (activeMenu.Items.Count > 0)
                            {
                                var item = activeMenu.Items[index];
                                if (activeMenu.Items[index] is Folder)
                                {
                                    indexHistory.Push(index);
                                    index = 0;
                                    history.Push(activeMenu);
                                    item.Action?.Invoke();
                                }
                                else
                                {
                                    item.Action?.Invoke();
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Backspace:
                        {
                            if (history.Count > 0)
                            {
                                Console.Clear();
                                back();
                            }
                        }
                        break;
                    case ConsoleKey.Escape:
                        {
                            Process.GetCurrentProcess().Kill();
                        }
                        break;
                }
            }
        }

        private void next(string path)
        {
            Console.Clear();
            var items = fileManager.GetItems(path);
            List<MenuItem> menuItems = new List<MenuItem>();

            foreach (var i in items)
            {
                if (Directory.Exists(i))
                {
                    menuItems.Add(
                        new Folder()
                        {
                            Path = i,
                            Name = i.Split("\\").Last(),
                            Action = () => next(i)
                        });
                }
                else
                {
                    menuItems.Add(
                        new UI.File()
                        {
                            Path = i,
                            Name = i.Split("\\").Last(),
                            Action = () => launch(i)
                        });
                }

            }

            Menu menu = new Menu()
            {
                Path = path,
                Items = menuItems
            };
            activeMenu = menu;
        }

        private void launch(string path)
        {
            try
            {
                Process.Start(path);
            }
            catch
            {
                Process.Start(Environment.GetEnvironmentVariable("WINDIR") + @"\explorer.exe", path);
            }
        }

        private void back()
        {
            index = indexHistory.Pop();
            activeMenu = history.Pop();
        }
    }
}
