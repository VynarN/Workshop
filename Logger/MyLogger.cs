namespace Logger
{
    using System;
    using System.IO;
    using System.Text;

    public class MyLogger : Interfaces.ILogger
    {
        private Configuration Configuration;
        private LoggerWriter Writer;
        private LoggerReader Reader;
       
        public MyLogger(Configuration configuration)
        {
            if (configuration != null)
            {
                Configuration = configuration;
                TurnOn();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        private delegate void LoggerWriter(Exception e);

        private delegate string LoggerReader();

        public void TurnOn()
        {
            Writer = WriteMessage;
            Reader = ReadMessage;
        }

        public void TurnOff()
        {
            Writer = null;
            Reader = null;
        }

        public string ReadLog()
        {
            if(Reader != null)
            {
                return Reader();
            }
            else
            {
                NullReferenceException e = new NullReferenceException("Logger has been turned off! " +
                       "To use it, turn it on by invoking TunrOn() funcntion!");
                WriteMessage(e);
                return String.Empty;
            }
        }

        public void Log(Exception exception)
        {
            if (Writer != null)
            {
                Writer(exception);
            }
            else
            {
                NullReferenceException e = new NullReferenceException("Logger has been turned off! " +
                    "To use it, turn it on by invoking TunrOn() funcntion!");
                WriteMessage(e);
            }
        }

        private string ReadMessage()
        {
            StringBuilder message = new StringBuilder(String.Empty);
            using(StreamReader reader = new StreamReader(Configuration.Location))
            {
                while (!reader.EndOfStream)
                {
                    message.Append(reader.ReadLine() + "\n");
                }
            }
            return message.ToString();
        }

        private void WriteMessage(Exception e)
        {
            using (StreamWriter writer = new StreamWriter(Configuration.Location, true))
            {
                switch (Configuration.Level)
                {
                    case LevelOfDetalization.INFO:
                         writer.WriteLine($"{DateTime.Now} {e.Source}: {e.Message}");
                         break;
                    case LevelOfDetalization.TRACE:
                        writer.WriteLine($"{DateTime.Now} {e.Source}: {e.StackTrace}");
                        break;
                    default:
                        writer.WriteLine($"{DateTime.Now} {e.Source}: {e.Message}");
                        break;
                }
            }
        }
    }
}
