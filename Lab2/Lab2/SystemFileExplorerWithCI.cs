using System;
using System.IO;
using System.Linq;

namespace Lab2
{
    public class SystemFileExplorerWithCI
    {
        private readonly IFileManager _fileManager;

        public SystemFileExplorerWithCI(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public bool MergeTemporaryFiles(string dir)
        {
            var filesData = _fileManager.GetFilesData(dir);
            try
            {
                return _fileManager.SaveBackup(dir, String.Concat(filesData));
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
        }

        public bool RemoveTemporaryFiles(string dir)
        {
            var files = _fileManager.FilesToRemove(dir);
            return _fileManager.RemoveFiles(files);
        }
    }
}
