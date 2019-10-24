using System;
using System.Collections.Generic;
using System.Text;

namespace Streams.Interfaces
{
    public interface IInteractable
    {
        string Read();
        void Write(string message);
        void WriteLine(string message);
    }
}
