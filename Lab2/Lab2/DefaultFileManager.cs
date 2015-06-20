using System;

namespace Lab2
{
    public class DefaultFileManager : IFileManager
    {
        public string[] GetFilesData(string dir)
        {
            return new[] {String.Empty};
        }

        public bool SaveBackup(string dir, string tempData)
        {
            return true;
        }

        public string[] FilesToRemove(string dir)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFiles(string[] files)
        {
            return true;
        }
    }
}