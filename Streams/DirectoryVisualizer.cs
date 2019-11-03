namespace Streams
{
    using System;
    using System.IO;
    using Streams.Interfaces;
    using Logger.Interfaces;
    using IO = System.IO;

    public class DirectoryVisualizer : IVisualizable, ICheckable<string>
    {
        public string Directory { get; private set; }

        private IInteractable UserInterface;

        private ILogger Logger;

        public DirectoryVisualizer(string directory, IInteractable userInterface, ILogger logger)
        {
            UserInterface = userInterface;
            Logger = logger;
            if (Check(directory))
            {
                Directory = directory;
            }
            else
            {
               Logger.Log(new ArgumentException("Specified directory does not exist!"));
            }
        }

        public void Visualize()
        {
            try
            {
                GetListOfFilesAndDirectories(Directory, 0);
            }
            catch (UnauthorizedAccessException e)
            {
                Logger.Log(e);
            }
        }

        private void GetListOfFilesAndDirectories(string directory, int padding)
        {
            var currentDirrectory = new DirectoryInfo(directory);
            var directories = currentDirrectory.GetDirectories();
            var files = currentDirrectory.GetFiles();
            foreach (var dir in directories)
            {
                if (dir.Name.StartsWith("$"))
                    continue;

                UserInterface.WriteLine(MakePadding(padding) + dir.Name + ":");
                GetListOfFilesAndDirectories(dir.ToString(), padding + 2);
            }
            foreach (var file in files)
            {
                UserInterface.WriteLine(MakePadding(padding) + file.Name);
            }
        }

        private static string MakePadding(int padding)
        {
            var str = String.Empty;
            for (int i = 0; i < padding; i++)
            {
                str += " ";
            }
            return str;
        }

        public bool Check(string path)
        {
            return (!String.IsNullOrEmpty(path) &&
                    IO.Directory.Exists(path.Substring(0, path.LastIndexOf("\\"))));
        }
    }
}
