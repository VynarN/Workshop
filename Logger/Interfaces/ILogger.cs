using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Interfaces
{
    interface ILogger
    {
        string ReadMessage();
        void WriteMessage(Exception e);
    }
}
