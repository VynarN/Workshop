namespace Comparators
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using Streams.Interfaces;

    public partial class DirectoriesComparator: ICheckable<string>
    {
       public bool Check(string path)
       {
           return (!String.IsNullOrEmpty(path) &&
                   Directory.Exists(path.Substring(0, path.LastIndexOf("\\"))));
       }

       private Dictionary<string, int> GetListOfFiles(string directory, Dictionary<string, int> listOfFiles)
       {
            var currentDirectory = new DirectoryInfo(directory);
            var directories = currentDirectory.GetDirectories();
            var files = currentDirectory.GetFiles();
            foreach (DirectoryInfo dir in directories)
            {
                GetListOfFiles(dir.FullName, listOfFiles);
            }
            foreach (FileInfo file in files)
            {
                if (listOfFiles.ContainsKey(file.Name))
                {
                    listOfFiles[file.Name]++;
                }
                else
                {
                    listOfFiles.Add(file.Name, 1);
                }
            }
            return listOfFiles;
       }
    }
}
