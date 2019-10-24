using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Interfaces
{
    interface ILogger
    {
        string ReadLog();
        void Log(Exception e);
    }
}
