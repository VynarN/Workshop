namespace Logger.Interfaces
{
    using System;
    
    public interface ILogger
    {
        string ReadLog();
        void Log(Exception e);
    }
}
