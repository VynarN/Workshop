using System;
using System.IO;
using System.Text;
namespace Logger
{
    public class MyLogger: Interfaces.ILogger
    {
        private Configuration Configuration;

        public MyLogger(Configuration configuration)
        {
            Configuration = configuration;
        }
        public string ReadMessage()
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
        public void WriteMessage(Exception e)
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
