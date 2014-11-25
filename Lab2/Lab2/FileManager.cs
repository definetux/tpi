using System;
using System.Collections.Generic;
using System.IO;

namespace Lab2
{
    public class FileManager : IFileManager
    {
        private const string TO_REMOVE = @"\ToRemove.txt";

        private string _path = "";

        public string[] GetFilesData(string dir)
        {
            var files = Directory.GetFiles(dir, "*.tmp");
            var filesData = new List<String>();
            foreach (var file in files)
            {
                filesData.AddRange(File.ReadAllLines(file));
                File.Delete(file);
            }
            return filesData.ToArray();
        }

        public bool SaveBackup(string dir, string tempData)
        {
            File.WriteAllText(dir + "\\backup.tmp", tempData);
            return true;
        }

        public string[] FilesToRemove(string dir)
        {
            if (!File.Exists(dir + TO_REMOVE))
            {
                throw new ArgumentException();
            }

            _path = dir;
            return File.ReadAllLines(dir + TO_REMOVE);
        }

        public bool RemoveFiles(string[] files)
        {
            foreach (var file in files)
            {
                if (!File.Exists(file))
                {
                    File.AppendAllText(_path + "\\error.log", "Файл " + file + " не был найден");
                }
                else
                {
                    File.Delete(file);
                }
            }
            return true;
        }
    }
}