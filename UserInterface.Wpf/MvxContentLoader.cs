using System;
using System.Collections.Generic;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Wpf.Views;
using FirstFloor.ModernUI.Windows;

namespace UserInterface.Wpf
{
    public class MvxContentLoader : DefaultContentLoader
    {
        private readonly Dictionary<Uri, MvxViewModelRequest> _cachedRequests;

        public MvxContentLoader()
        {
            _cachedRequests = new Dictionary<Uri, MvxViewModelRequest>();
        }

        protected override object LoadContent(Uri uri)
        {
            MvxTrace.Trace("Loading content for uri: {0}", uri);

            MvxViewModelRequest request;

            if (!_cachedRequests.TryGetValue(uri, out request))
            {
                request = uri.ToMvxViewModelRequest();
                _cachedRequests.Add(uri, request);
            }

            var viewLoader = Mvx.Resolve<IMvxSimpleWpfViewLoader>();

            var frameworkElement = viewLoader.CreateView(request);

            return frameworkElement;
        }
    }
}