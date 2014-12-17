using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Lab3_1.Infrastructure;

namespace Lab3_1.ViewModels
{
    public class PathManagerViewModel : IPathManagerViewModel
    {
        private string _currentPath;
        private readonly ISupportService _service;
        private ObservableCollection<string> _truePathesList;
        private ObservableCollection<string> _falsePatherList;
        private string _selectedTrueItem;
        private string _selectedFalseItem;

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

        public string SelectedFalseItem
        {
            get { return _selectedFalseItem; }
            set
            {
                if (value == _selectedFalseItem) return;
                _selectedFalseItem = value;
                OnPropertyChanged();
            }
        }

        public string SelectedTrueItem
        {
            get { return _selectedTrueItem; }
            set
            {
                if (value == _selectedTrueItem) return;
                _selectedTrueItem = value;
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

        public ICommand MoveToCurrentCommand { get; private set; }
        public ICommand MoveToFalseCommand { get; private set; }
        public ICommand AddPathCommand { get; private set; }
        public ICommand RemoveFromTrueListCommand { get; private set; }
        public ICommand RemoveFromFalseListCommand { get; private set; }

        public PathManagerViewModel(ISupportService service)
        {
            if (service == null)
            {
                throw new ArgumentException();
            }
            _service = service;

            MoveToFalseCommand = new Command( MoveToFalse );
            MoveToCurrentCommand = new Command(MoveToCurrent);
            AddPathCommand = new Command(_ => AddPath());
            RemoveFromTrueListCommand = new Command(RemoveFromTrueList);
            RemoveFromFalseListCommand = new Command(RemoveFromFalseList);

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

        public void MoveToFalse(object item)
        {
            if (item == null || item.ToString() == String.Empty)
            {
                return;
            }
            RemoveFromTrueList(item);
            FalsePatherList.Add(item.ToString());
        }

        public void MoveToCurrent(object item)
        {
            if ( item == null || item.ToString() == String.Empty)
            {
                _service.Show("You haven’t chosen a path to re-check!");
                return;
            }
            RemoveFromFalseList(item);
            CurrentPath = item.ToString();
        }

        public void AddPath()
        {
            if (CurrentPath == String.Empty)
            {
                _service.Show("Empty string!");
                return;
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

        public void RemoveFromTrueList(object item)
        {
            var path = item == null ? String.Empty : item.ToString();

            TruePathesList.Remove(path);
        }

        public void RemoveFromFalseList(object item)
        {
            var path = item == null ? String.Empty : item.ToString();

            FalsePatherList.Remove(path);
        }
    }
}