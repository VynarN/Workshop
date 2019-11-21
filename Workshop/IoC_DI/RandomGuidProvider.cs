namespace Workshop.IoC_DI
{
    using Workshop.IoC_DI.Interfaces;
    using System;

    public class RandomGuidProvider: IRandomGuidProvider
    {
        public Guid RandomGuid { get; } = Guid.NewGuid();
    }
}
