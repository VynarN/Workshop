using System;
using System.Collections.Generic;
using System.Text;

namespace Streams.Interfaces
{
    interface ICheckable<T>
    {
        bool Check(T param);
    }
}
