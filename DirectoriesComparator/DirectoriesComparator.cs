namespace Comparators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Streams.Interfaces;

    public partial class DirectoriesComparator: IComparable
    {
        public string FirstDirectory { get; private set; }

        public string SecondDirectory { get; private set; }

        private IInteractable UserInterface;
        
        public DirectoriesComparator(string firstDir, string secondDir, IInteractable userInterface)
        {
            if (Check(firstDir) && 
                Check(secondDir) && 
                userInterface != null)
            {
                FirstDirectory = firstDir;
                SecondDirectory = secondDir;
                UserInterface = userInterface;
            }
            else
            {
                throw new ArgumentException($"Invalid directory path:\n{firstDir}\n{secondDir} or user interface was unitialized!"); ;
            }
        }

        public void Compare()
        {
            var listOfFiles = new Dictionary<string, int>();
            try
            {
                GetListOfFiles(FirstDirectory, listOfFiles);
                GetListOfFiles(SecondDirectory, listOfFiles);
                var duplicates = listOfFiles.Where(file => file.Value > 1);
                var distincts = listOfFiles.Where(file => file.Value == 1);
                UserInterface.WriteLine("List of Duplicates:");
                foreach(var file in duplicates)
                {
                    UserInterface.WriteLine($"{file.Key} -- {file.Value}");
                }
                UserInterface.WriteLine("List of distinct files");
                foreach(var file in distincts)
                {
                    UserInterface.WriteLine($"{file.Key}");
                }
            }
            catch (UnauthorizedAccessException e)
            {
                throw e;
            }
        }
    }
}
