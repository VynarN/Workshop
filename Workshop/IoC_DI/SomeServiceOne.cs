namespace Workshop.IoC_DI
{
    using System;
    using Workshop.IoC_DI.Interfaces;

    public class SomeServiceOne: ISomeService
    {
        private readonly IRandomGuidProvider _randomGuidProvider;

        public SomeServiceOne(IRandomGuidProvider provider)
        {
            _randomGuidProvider = provider;
        }

        public void PrintSomething()
        {
            Console.WriteLine(_randomGuidProvider.RandomGuid);
        }
    }
}
