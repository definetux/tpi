using Lab3_1.ViewModels;
using Ninject.Modules;

namespace Lab3_1.Infrastructure
{
    public class PathManagerModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISupportService>().To<SupportService>();
            Bind<IPathManagerViewModel>().To<PathManagerViewModel>();
            Bind<IPathManagerView>().To<PathManagerView>();
        }
    }
}