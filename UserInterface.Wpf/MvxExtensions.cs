using System;
using System.IO;
using Cirrious.MvvmCross.ViewModels;

namespace UserInterface.Wpf
{
    internal static class MvxExtensions
    {
        public const string Scheme = "pack";

        public static Uri ToUri(this Type value)
        {
            var host = Path.GetFileName(value.Assembly.Location);
            var localPath = "/" + value.FullName.Replace('.', '/');

            var builder = new UriBuilder { Scheme = Scheme, Path = localPath, Host = host };

            return builder.Uri;
        }

        public static MvxViewModelRequest ToMvxViewModelRequest(this Uri value)
        {
            var assemblyName = value.Host;
            var fullTypeName = value.LocalPath.Replace('/', '.').Substring(1);

            var loadedType = AssemblyScanner.ScanLocalAssemblyForType(assemblyName, fullTypeName);

            return MvxViewModelRequest.GetDefaultRequest(loadedType);
        }
    }
}