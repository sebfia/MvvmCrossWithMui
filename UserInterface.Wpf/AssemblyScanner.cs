using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace UserInterface.Wpf
{
    public static class AssemblyScanner
    {
        public static Type ScanLocalAssemblyForType(string assemblyName, string typeName)
        {
            IEnumerable<FileInfo> files = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).GetFiles(assemblyName,
                    SearchOption.AllDirectories);

            var file = files.FirstOrDefault();

            if (file == null)
                throw new FileNotFoundException(String.Format("Could not load assembly: {0}", assemblyName));

            var assembly = Assembly.LoadFrom(file.FullName);

            var type = assembly.GetTypes().FirstOrDefault(x => x.FullName == typeName);

            return type;
        }
    }
}