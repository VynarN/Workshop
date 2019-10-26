namespace Logger.Interfaces
{
    using System;
    
    interface ILogger
    {
        string ReadLog();
        void Log(Exception e);
    }
}
