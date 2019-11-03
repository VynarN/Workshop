namespace Streams
{
    using System;
    using System.IO;
    using Streams.Interfaces;

    public class MyLogger: ICheckable<string>
    {
        public string DefaultFile { get; private set; } = Directory.GetCurrentDirectory() + "\\log.txt";

        public StreamWriter Writer { get; private set; }

        public MyLogger() { }

        public MyLogger(string path)
        {
            if (Check(path))
            {
                DefaultFile = path;
            }
            else
            {
                string message = "Specified directory does not exist! For this reason, the default directory will be used!";
                Log($"{this.GetType()}: {message}");
                throw new ArgumentException(message);
            }
        }

        public void Log(string message)
        {
            using (Writer = new StreamWriter(DefaultFile, true))
            {
                Writer.WriteLine(message);
            }
        }

        public bool Check(string path)
        {
            return (!String.IsNullOrEmpty(path) &&
                    Directory.Exists(path.Substring(0, path.LastIndexOf("\\"))));
        }
    }
}
