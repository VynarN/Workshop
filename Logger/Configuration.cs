namespace Logger
{
    using System;
    using System.IO;

    public class Configuration
    {
        public LevelOfDetalization Level { get; private set; }

        public string Location { get; private set; }

        public Configuration(LevelOfDetalization level, string location)
        {
            Level = level;
            if (IsEligible(location))
            {
                Location = location;
            }
            else
            {
                Location = Directory.GetCurrentDirectory() + "\\Errors.txt";
                MyLogger logger = new MyLogger(this);
                logger.Log(new ArgumentException($"Specified location is incorrect! Default location will be used: {Location}"));
            }
           
        }

        private bool IsEligible(string path)
        {
            return (!string.IsNullOrEmpty(path) &&
                    Directory.Exists(path.Substring(0, path.LastIndexOf("\\"))));
        }
    }
}
