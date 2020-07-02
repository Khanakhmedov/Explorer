using Explorer.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Explorer.Logic
{
    public class FileManager : IFileManager
    {
        public IEnumerable<string> GetItems(string path)
        {
            EnumerationOptions options = new EnumerationOptions()
            {
                AttributesToSkip = FileAttributes.Hidden,
                RecurseSubdirectories = false
            };
            return Directory.EnumerateFileSystemEntries(path, "*" ,options);
        }

        public string[] GetDrives()
        {
            return Environment.GetLogicalDrives();
        }
    }
}
