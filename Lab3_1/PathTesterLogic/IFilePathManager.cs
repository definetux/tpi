using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PathTesterLogic
{
    public interface IFilePathManager : INotifyPropertyChanged
    {
        string CurrentPath { get; set; }
        ObservableCollection<string> TruePathesList { get; set; }
        ObservableCollection<string> FalsePatherList { get; set; }
        bool CheckPath(string path);
        void MoveToFalse(string item);
        void MoveToCurrent(string item);
        void AddPath();
        string RemoveFromTrueList(object item);
        string RemoveFromFalseList(object item);
    }
}