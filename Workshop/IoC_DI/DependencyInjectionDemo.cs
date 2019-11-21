namespace Workshop
{
    using VynarN.Workshop.DependecyInjection;
    using Workshop.IoC_DI;
    using Workshop.IoC_DI.Interfaces;

    public partial class WorkshopMain
    {
        static void DependencyInjectionDemo()
        {
            var services = new DiServiceCollection();
            //services.RegisterSingleton<RandomGuidGenerator>();
            //services.RegisterTransient<RandomGuidGenerator>();
            services.RegisterSingleton<ISomeService, SomeServiceOne>();
            services.RegisterTransient<IRandomGuidProvider, RandomGuidProvider>();
            var container = services.GenerateContainer();
            var service1 = container.GetService<ISomeService>();
            var service2 = container.GetService<ISomeService>();

            service1.PrintSomething();
            service2.PrintSomething();
        }
    }
}
