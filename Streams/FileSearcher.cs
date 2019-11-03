namespace Streams
{
    using System;
    using System.IO;
    using Streams.Interfaces;
    using Logger.Interfaces;

    public class FileSearcher: ICheckable<string>
    {
        public string Filename { get; private set; }

        public string FileLocation { get; private set; } 

        private IInteractable UI;

        private ILogger Logger;

        public FileSearcher(string filename, ILogger logger)
        {
            UI = new ConsoleUI();
            Logger = logger;
            if (Check(filename))
            {
                Filename = filename;
            }
            else
            {
                Logger.Log(new ArgumentException("Filename can not be null or empty string!"));
            }
        }

        public string SearchFile()
        {
            UI.WriteLine("This may take a few minutes.Please, do not close the window. ");
            UI.WriteLine($"Warning: not all directories are accessible!\nTo see which ones, look into the exception log.");
            if (Filename != null)
            {
                Search("D:\\");
                if (FileLocation == null)
                    Search("C:\\");
            }
            return FileLocation != null ? FileLocation : "File Location can not be determined!";
        }

        public bool Check(string file)
        {
            return !String.IsNullOrEmpty(file);
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
            catch (UnauthorizedAccessException e)
            {
                Logger.Log(e);
            }
        }
    }
}
