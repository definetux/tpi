using System.Windows;
using Lab3_1.Infrastructure;
using Ninject;

namespace Lab3_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            var kernel = new StandardKernel(new PathManagerModule());
            var pathManagerView = kernel.Get<IPathManagerView>() as Window;

            if (pathManagerView != null)
            {
                Application.Current.MainWindow = pathManagerView;
                pathManagerView.Show();
            }
            this.Close();
        }
    }
}
