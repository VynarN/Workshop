using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Streams.Interfaces;
using IO = System.IO;
namespace Streams
{
    public class DirectoryVisualizer : IVisualizable, ICheckable<string>
    {
        public Logger Logger { get; private set; }
        public string Directory { get; private set; }
        private IInteractable UserInterface;

        public DirectoryVisualizer(string directory, IInteractable userInterface)
        {
            UserInterface = userInterface;
            Logger = new Logger();

            if (Check(directory))
            {
                Directory = directory;
            }
            else
            {
               string message = "Specified directory does not exist!";
               Logger.Log($"{this.GetType()}: {message}");
               throw new ArgumentException(message);
            }
        }

        public void Visualize()
        {
            GetListOfFilesAndDirectories(Directory, 0);
        }

        private void GetListOfFilesAndDirectories(string directory, int padding)
        {
            DirectoryInfo currentDirrectory = new DirectoryInfo(directory);
            DirectoryInfo[] directories = currentDirrectory.GetDirectories();
            FileInfo[] files = currentDirrectory.GetFiles();
            foreach (var dir in directories)
            {
                UserInterface.Write(MakePadding(padding) + dir.Name);
                GetListOfFilesAndDirectories(dir.ToString(), padding + 2);
            }
            foreach (var file in files)
            {
                UserInterface.Write(MakePadding(padding) + " " + file.Name);
            }
        }
        private static string MakePadding(int padding)
        {
            string str = String.Empty;
            for (int i = 0; i < padding; i++)
            {
                str += " ";
            }
            return str;
        }
        public bool Check(string path)
        {
            if (String.IsNullOrEmpty(path) &&
                    !IO.Directory.Exists(path.Substring(0, path.LastIndexOf("\\"))))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
    }
}
