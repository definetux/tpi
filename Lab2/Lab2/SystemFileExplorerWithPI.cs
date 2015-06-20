using System;
using System.Linq;

namespace Lab2
{
    public class SystemFileExplorerWithPI
    {
        private IFileManager _fileManager = null;
        public IFileManager FileManager
        {
            get
            {
                return _fileManager ?? new DefaultFileManager();
            }
            set { _fileManager = value; }
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