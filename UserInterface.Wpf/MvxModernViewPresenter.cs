using System;
using System.Windows;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Wpf.Views;
using FirstFloor.ModernUI.Windows.Controls;

namespace UserInterface.Wpf
{
    public class MvxModernViewPresenter : IMvxWpfViewPresenter
    {
        private readonly ModernWindow _window;

        public MvxModernViewPresenter(Window window)
        {
            _window = window as ModernWindow;

            if(_window == null)
                throw new InvalidOperationException("Window is not a ModernWindow instance!");

            _window.ContentLoader = new MvxContentLoader();
        }

        public void Show(MvxViewModelRequest request)
        {
            var uri = request.ViewModelType.ToUri();
            _window.ContentSource = uri;
        }

        public void ChangePresentation(MvxPresentationHint hint)
        {
            MvxTrace.Warning("Hint ignored {0}", new object[1]
            {
                (object) ((object) hint).GetType().Name
            });
        }
    }
}