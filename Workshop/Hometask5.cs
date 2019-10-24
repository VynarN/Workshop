using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Workshop
{
    partial class WorkshopMain
    {
        static void Hometask5()
        {
            Streams.Interfaces.IInteractable display = new Streams.ConsoleUI();
            Assembly assembly = Assembly.LoadFrom(@"C:\Users\vynar\source\repos\Workshop\Reflection\bin\Debug\netstandard2.0\Reflection.dll");
            display.Write($"Assembly name: {assembly.FullName}");
            display.Write($"Assembly location: {assembly.Location}");
            Type[] types = assembly.GetExportedTypes();
            display.WriteLine($"Types defined in {assembly.FullName}:");
            foreach(Type type in types)
            {
                display.Write("Type:");
                display.WriteLine(type.FullName);
                MemberInfo[] members = type.GetMembers();
                display.WriteLine($"Methods in {type.Name}:");
                foreach(MemberInfo member in members)
                {
                    if (member.MemberType == MemberTypes.Method)
                    {
                        display.WriteLine($" {member.Name}");
                        ParameterInfo[] parameters = ((MethodInfo)member).GetParameters();
                        foreach(ParameterInfo param in parameters)
                        {
                            display.WriteLine($"  {param.Name}");
                        }
                    }
                    else
                    {
                        display.WriteLine($"  {member.Name}");
                    }
                   
                }
            }

        }
    }
}
