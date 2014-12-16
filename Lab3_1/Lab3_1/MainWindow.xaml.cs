using System;
using System.Windows;
using PathTesterLogic;

namespace Lab3_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly IFilePathManager _filePathManager;

        public MainWindow()
        {
            _filePathManager = new FilePathManager();
            InitializeComponent();
        }

        public IFilePathManager FilePathManager
        {
            get { return _filePathManager; }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FilePathManager.AddPath();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         }

        private void btnMoveTrue_Click(object sender, RoutedEventArgs e)
        {
            var path = FilePathManager.RemoveFromTrueList(lstTruePath.SelectedItem);
            FilePathManager.MoveToFalse(path);
        }

        private void btnBackFalse_Click(object sender, RoutedEventArgs e)
        {
            var path = FilePathManager.RemoveFromTrueList(lstFalsePath.SelectedItem);
            try
            {
                FilePathManager.MoveToCurrent(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemoveFalse_Click(object sender, RoutedEventArgs e)
        {
            FilePathManager.RemoveFromFalseList(lstFalsePath.SelectedItem);
        }

        private void btnRemoveTrue_Click(object sender, RoutedEventArgs e)
        {
            FilePathManager.RemoveFromTrueList(lstTruePath.SelectedItem);
        }
    }
}
