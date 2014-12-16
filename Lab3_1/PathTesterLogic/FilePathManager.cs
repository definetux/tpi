using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace PathTesterLogic
{
    public class FilePathManager : IFilePathManager
    {
        private string _currentPath;
        private ObservableCollection<string> _truePathesList;
        private ObservableCollection<string> _falsePatherList;

        public string CurrentPath
        {
            get { return _currentPath; }
            set
            {
                if (value == _currentPath) return;
                _currentPath = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> TruePathesList
        {
            get { return _truePathesList; }
            set
            {
                if (Equals(value, _truePathesList)) return;
                _truePathesList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> FalsePatherList
        {
            get { return _falsePatherList; }
            set
            {
                if (Equals(value, _falsePatherList)) return;
                _falsePatherList = value;
                OnPropertyChanged();
            }
        }

        public FilePathManager()
        {
            TruePathesList = new ObservableCollection<string>();
            FalsePatherList = new ObservableCollection<string>();
            CurrentPath = String.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool CheckPath(string path)
        {
            var regular = new Regex(@"(^\w:)$|(^\w:)\\$|^[a-zA-Z]:(\\[\w|_|\s]+)+$");
            return regular.IsMatch(path);
        }

        public void MoveToFalse(string item)
        {
            if (item == String.Empty)
            {
                return;
            }
            TruePathesList.Remove(item);
            FalsePatherList.Add(item);
        }

        public void MoveToCurrent(string item)
        {
            if (item == String.Empty)
            {
                throw new Exception("You haven’t chosen a path to re-check!");
            }
            FalsePatherList.Remove(item);
            CurrentPath = item;
        }

        public void AddPath()
        {
            if (CurrentPath == String.Empty)
            {
                throw new Exception("Empty string!");
            }

            var result = CheckPath(CurrentPath);

            if (result)
            {
                TruePathesList.Add(CurrentPath);
            }
            else
            {
                FalsePatherList.Add(CurrentPath);
            }
            CurrentPath = String.Empty;
        }

        public string RemoveFromTrueList(object item)
        {
            var path = item == null ? String.Empty : item.ToString();

            TruePathesList.Remove(path);
            return path;
        }

        public string RemoveFromFalseList(object item)
        {
            var path = item == null ? String.Empty : item.ToString();

            FalsePatherList.Remove(path);
            return path;
        }
    }
}