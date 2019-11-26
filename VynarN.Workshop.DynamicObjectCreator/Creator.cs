using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System;

namespace VynarN.Workshop.DynamicObjectCreator
{
    public class Creator<TInterface> where TInterface : class
    {
        public List<InstanceInfo<TInterface>> Instances { get; } = new List<InstanceInfo<TInterface>>();

        public string PathToDlls { get; }

        public Creator(string pathToDlls)
        {
            if (!Directory.Exists(pathToDlls))
            {
                throw new ArgumentException("Specified directory does not exist!");
            }
            PathToDlls = pathToDlls;
        }

        public void CreateInstances () 
        {
            var dlls = Directory.EnumerateFiles(PathToDlls, "*.dll", SearchOption.TopDirectoryOnly);

            foreach (var dll in dlls)
            {
                var assembly = Assembly.LoadFrom(dll);

                foreach (var type in assembly.ExportedTypes)
                {
                    if (type.IsClass &&
                        typeof(TInterface).IsAssignableFrom(type))
                    {
                        TInterface instance = Activator.CreateInstance(type) as TInterface;
                        Instances.Add(new InstanceInfo<TInterface>(
                            instance, 
                            type.Name,
                            assembly.FullName));
                    }
                }
            }
        }
    }
}
