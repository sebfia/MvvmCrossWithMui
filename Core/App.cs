using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Core.ViewModels;

namespace Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<FirstViewModel>());
        }
    }
}
