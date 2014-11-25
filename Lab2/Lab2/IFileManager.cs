using System;

namespace Lab2
{
    public interface IFileManager
    {
        String[] GetFilesData(string dir);
        bool SaveBackup(string dir, string tempData);

        String[] FilesToRemove(string dir);

        bool RemoveFiles(string[] files);
    }
}