namespace Workshop
{
    using System;
    using System.Reflection;

    partial class WorkshopMain
    {
        static void Hometask5()
        {
            Streams.Interfaces.IInteractable display = new Streams.ConsoleUI();
            Assembly assembly = Assembly.LoadFrom(@"C:\Users\vynar\source\repos\Workshop\Reflection\bin\Debug\netstandard2.0\Reflection.dll");
            display.WriteLine($"Assembly name: \n{assembly.FullName}");
            display.WriteLine($"Assembly location: \n{assembly.Location}");
            Type[] types = assembly.GetExportedTypes();
            display.WriteLine($"Types defined in {assembly.FullName}:");
            foreach(Type type in types)
            {
                display.WriteLine($"-{type.FullName}");
                MemberInfo[] members = type.GetMembers();
                foreach(MemberInfo member in members)
                {
                    if (member.MemberType == MemberTypes.Method)
                    {
                        display.WriteLine($" {member.Name}");
                        ParameterInfo[] parameters = ((MethodInfo)member).GetParameters();
                        foreach(ParameterInfo param in parameters)
                        {
                            display.Write($" {param.ParameterType}");
                            display.WriteLine($" {param.Name}");
                        }
                    }
                    else
                    {
                        display.WriteLine($"  {member.Name}");
                    }
                   
                }
            }
            DelayAndClear();
        }
    }
}
