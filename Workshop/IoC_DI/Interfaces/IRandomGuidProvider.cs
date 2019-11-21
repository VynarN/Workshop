namespace Workshop.IoC_DI.Interfaces
{
    using System;

    public interface IRandomGuidProvider
    {
        Guid RandomGuid { get; }
    }
}
