using System;
using VynarN.Workshop.CustomContainer;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using ConsoleApplicationBase.Models;

namespace ConsoleApplicationBase.Commands
{
    public static class Container
    {
        public static DiServiceCollection collection = new DiServiceCollection();

        public static DiContainer container;

        public static string RegisterService(string service, string implementation, string lifetime)
        {
            try
            {
                var serviceType = Type.GetType(service);
                var implementationType = Type.GetType(implementation);
                Assembly assembly = Assembly.Load("VynarN.Workshop.CustomContainer");
                var types = assembly.GetTypes();
                var diCollection = types.First(type => type.Name.Equals("DiServiceCollection"));
                MethodInfo method = null;
                if (lifetime.ToLower().Equals("singleton"))
                {
                    method = diCollection.GetMethods().Where(m => m.Name.Equals("RegisterSingleton")).Last();
                }
                else
                {
                    method = diCollection.GetMethods().Where(m => m.Name.Equals("RegisterTransient")).Last();
                }
                var methodToInvoke = method.MakeGenericMethod(serviceType, implementationType);
                methodToInvoke.Invoke(collection, null);
                return $"Service {service} and its implementation {implementation} were successfuly registered!";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "Something went wrong...";
        }

        public static string GenerateContainer()
        {
            container = collection.GenerateContainer();
            return "Container was generated!";
        }

        public static string GetService(string strType)
        {
            var type = Type.GetType(strType);
            if (container != null)
            {
                return container.GetService(type).ToString();
            }
            return "At first, you need register this service!";
        }
    }
}
