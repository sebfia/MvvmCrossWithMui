using Cirrious.MvvmCross.ViewModels;

namespace Core.ViewModels
{
    public class SecondViewModel : MvxViewModel
    {
        private MvxCommand _goToLastPage;

        public IMvxCommand GoToLastPage
        {
            get { return _goToLastPage ?? (_goToLastPage = new MvxCommand(() => ShowViewModel<LastViewModel>())); }
        }
    }
}
