using System;

namespace VynarN.Workshop.DynamicObjectCreator
{
    public class InstanceInfo<T>
    {
        public T Instance { get; }

        public string TypeName { get; }

        public string AssemblyName { get; }

        public InstanceInfo( T instance, string typeName, string assemblyName)
        {
            if (instance != null && typeName != null && assemblyName != null)
            {
                Instance = instance;
                TypeName = typeName;
                AssemblyName = assemblyName;
            }
            else
            {
                throw new ArgumentNullException($"Specified arguments can not be null: " +
                    $"instance: {instance}, typeName: {typeName}, assemblyName: {assemblyName}!");
            }
        }
    }
}
