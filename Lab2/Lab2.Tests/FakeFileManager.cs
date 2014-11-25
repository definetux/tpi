using System;

namespace Lab2.Tests
{
    public class FakeFileManager : IFileManager
    {
        public int Call { get; set; }

        public FakeFileManager()
        {
            Call = 0;
        }
        public string[] GetFilesData(string dir)
        {
            Call++;
            return new[]
            {
                "data from file 1",
                "data from file 2",
                "bad data",
                "good data",
                "other data"
            };
        }

        public bool SaveBackup(string dir, string tempData)
        {
            Call++;
            return true;
        }

        public string[] FilesToRemove(string dir)
        {
            Call++;
            return new[] {"file1.txt", "file2.txt", "file3.tmp"};
        }

        public bool RemoveFiles(string[] files)
        {
            Call++;
            return true;
        }
    }
}