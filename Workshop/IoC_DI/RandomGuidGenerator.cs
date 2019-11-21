using System;
using System.Collections.Generic;
using System.Text;
using Workshop;

namespace Workshop.IoC_DI
{
    public class RandomGuidGenerator
    {
        public Guid RandomGuid { get; set; } = Guid.NewGuid();
    }
}
