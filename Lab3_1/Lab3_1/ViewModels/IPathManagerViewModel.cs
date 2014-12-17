using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Lab3_1.ViewModels
{
    public interface IPathManagerViewModel : INotifyPropertyChanged
    {
        string CurrentPath { get; set; }
        ObservableCollection<string> TruePathesList { get; set; }
        ObservableCollection<string> FalsePatherList { get; set; }
        ICommand MoveToCurrentCommand { get; }
        ICommand MoveToFalseCommand { get;  }
        ICommand AddPathCommand { get; }
        ICommand RemoveFromTrueListCommand { get; }
        ICommand RemoveFromFalseListCommand { get; }
        bool CheckPath(string path);
        void MoveToFalse(object item);
        void MoveToCurrent(object item);
        void AddPath();
        void RemoveFromTrueList(object item);
        void RemoveFromFalseList(object item);
    }
}