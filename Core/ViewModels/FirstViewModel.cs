using Cirrious.MvvmCross.ViewModels;

namespace Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private string _hello;

        public string Hello
        {
            get { return _hello; }

            set
            {
                _hello = value;
                RaisePropertyChanged(() => Hello);
            }
        }
    }
}
