namespace VynarN.Workshop.DependecyInjection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DiContainer
    {
        private List<ServiceDescriptor> ServiceDescriptors { get; }

        public DiContainer(List<ServiceDescriptor> descriptors)
        {
            ServiceDescriptors = descriptors;
        }

        public object GetService(Type serviceType)
        {
            var descriptor = ServiceDescriptors.SingleOrDefault(x => x.ServiceType == serviceType);

            if (descriptor == null)
            {
                throw new Exception($"Service of type {serviceType.Name} isn't registered!");
            }

            if (descriptor.Implementation != null)
            {
                return descriptor.Implementation;
            }

            var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;
            if (actualType.IsAbstract || actualType.IsInterface)
            {
                throw new Exception("Cannot instatiate abstract classes or interfaces");
            }

            var constructorInfo = actualType.GetConstructors().First();
            var parameters = constructorInfo.GetParameters().Select(x => GetService(x.ParameterType)).ToArray();

            var implementation = Activator.CreateInstance(actualType, parameters);

            if (descriptor.Lifetime == ServiceLifetime.Singleton)
            {
                descriptor.Implementation = implementation;
            }

            return implementation;
        }

        public TService GetService<TService>()
        {
            return (TService)GetService(typeof(TService));
        }
    }
}
