using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Logger
{
    public class Configuration
    {
        public LevelOfDetalization Level { get; private set; }
        public string Location { get; private set; } = Directory.GetCurrentDirectory() + "\\Errors.txt";

        public Configuration(LevelOfDetalization level, string location)
        {
            Level = level;
            if (IsEligible(location))
            {
                Location = location;
            }
            else
            {
                MyLogger logger = new MyLogger(this);
                logger.WriteMessage(new ArgumentException("Configuration ERROR!" +
                    "\nSpecified location is incorrect!\nDefault location will be used!"));
            }
           
        }

        private bool IsEligible(string path)
        {
            return (!String.IsNullOrEmpty(path) &&
                    Directory.Exists(path.Substring(0, path.LastIndexOf("\\"))));
        }
    }
}
