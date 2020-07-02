using System.Collections.Generic;

namespace Explorer.Logic.Interfaces
{
    public interface IFileManager
    {
        IEnumerable<string> GetItems(string path);
        string[] GetDrives();
    }
}
