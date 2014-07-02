using AlienRegistrationCoreLibrary.Attributes;
using AlienRegistrationCoreLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AlienRegistrationCoreLibrary
{
    public static class FileWriterHostProvider
    {
        private static List<FileWriterHost> f_Writers;

        public static List<FileWriterHost> Writers
        {
            get
            {
                if (null == f_Writers)
                    Reload();
                return f_Writers;
            }
        }

        public static void Reload()
        {
            if (null == f_Writers)
                f_Writers = new List<FileWriterHost>();
            else
                f_Writers.Clear();

            
            List<Assembly> plugInAssemblies = LoadPlugInAssemblies();
            List<IFileWriter> plugIns = GetPlugIns(plugInAssemblies);

            foreach(IFileWriter fw in plugIns)
            {
                f_Writers.Add(new FileWriterHost(fw));
            }
        }

        private static List<Assembly> LoadPlugInAssemblies()
        {
            DirectoryInfo dInfo = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "Plugins"));
            FileInfo[] files = dInfo.GetFiles("*.dll");

            List<Assembly> plugInAssemblyList = new List<Assembly>();
            
            if(null!=files)
            {
                foreach(FileInfo file in files)
                {
                    plugInAssemblyList.Add(Assembly.LoadFile(file.FullName));
                }
            }

            return plugInAssemblyList;
        }

        static List<IFileWriter> GetPlugIns(List<Assembly> assemblies)
        {
            List<Type> availableTypes = new List<Type>();

            foreach(Assembly currentAssembly in assemblies)
            {
                availableTypes.AddRange(currentAssembly.GetTypes());
            }

            // get list of objects implementing IFileWriter interface and have the FileWritingPlugInAttribute
            List<Type> writerList=availableTypes.FindAll(delegate(Type t)
            {
                List<Type> interfaceTypes = new List<Type>(t.GetInterfaces());
                object[] arr = t.GetCustomAttributes(typeof(FileWritingPlugInAttribute), true);
                return !(arr == null || arr.Length == 0) && interfaceTypes.Contains(typeof(IFileWriter));
            });

            // converting list of objects to the instantiated list of IFileWriters
            return writerList.ConvertAll<IFileWriter>(delegate(Type t)
            {
                return Activator.CreateInstance(t) as IFileWriter;
            });
        }
    }
}
