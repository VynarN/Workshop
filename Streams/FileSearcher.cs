using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Streams.Interfaces;
namespace Streams
{
    public class FileSearcher: ICheckable<string>
    {
        public string Filename { get; private set; }
        public string FileLocation { get; private set; } 
        private IInteractable UI;
        private Logger Logger;

        public FileSearcher(string filename) {
            UI = new ConsoleUI();
            Logger = new Logger();

            if (Check(filename))
            {
                Filename = filename;
            }
            else
            {
                string message = "Filename can not be null or empty string!";
                Logger.Log($"{this.GetType()}: {message}");
                throw new ArgumentException(message);
            }
        }
        private void Search(string directory)
        {
            DirectoryInfo currentDirectory = new DirectoryInfo(directory);
            if (File.Exists($"{currentDirectory.FullName}\\{Filename}.txt"))
            {
                FileLocation = currentDirectory.FullName;
                return;
            }
            try
            {
                var directories = currentDirectory.EnumerateDirectories();
                foreach (DirectoryInfo dir in directories)
                {
                    if (dir.Name.StartsWith("$"))
                        continue;
                    Search(dir.FullName);
                }
            }
            catch(UnauthorizedAccessException e)
            {
                Logger.Log($"{this.GetType()}: {e.Message}");
            }
            
        }
        public string SearchFile()
        {
            UI.Write("This may take a few minutes.Please, do not close the window.");
            UI.Write($"Warning: not all directories are accessible.To see which ones, look into {Logger.DefaultFile}");
            if (Filename != null)
            {
                Search("D:\\");
                if (FileLocation == null)
                    Search("C:\\");
            }
            Console.Clear();
            return FileLocation != null ? FileLocation : "File Location can not be determined!";
        }
        public bool Check(string file)
        {
            return !String.IsNullOrEmpty(file);
        }
    }
}
