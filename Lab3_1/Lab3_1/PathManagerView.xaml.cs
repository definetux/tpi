using System;
using System.Windows;
using Lab3_1.ViewModels;

namespace Lab3_1
{
    /// <summary>
    /// Interaction logic for PathManagerView.xaml
    /// </summary>
    public partial class PathManagerView : IPathManagerView
    {
        private readonly IPathManagerViewModel _pathManagerViewModel;

        public IPathManagerViewModel PathManagerViewModel
        {
            get { return _pathManagerViewModel; } 
        }

        public PathManagerView(IPathManagerViewModel pathManagerViewModel)
        {
            if (pathManagerViewModel == null)
            {
                throw new ArgumentException();
            }
            _pathManagerViewModel = pathManagerViewModel;

            InitializeComponent();
        }
    }
}
