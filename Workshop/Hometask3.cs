using System;
using System.Collections.Generic;
using System.Text;
using Streams;
namespace Workshop
{
    partial class WorkshopMain
    {
        static void Hometask3()
        {
            Console.WriteLine("Enter directory you want visualize:");
            string directory = Console.ReadLine();
            DirectoryVisualizer visualizer = new DirectoryVisualizer(directory, new ConsoleUI());
            visualizer.Visualize();
            DelayAndClear();
            Console.WriteLine("Enter a file name you are looking for:");
            string filename = Console.ReadLine();
            FileSearcher fs = new FileSearcher(filename);
            Console.WriteLine($"File location: {fs.SearchFile()}");
        }
    }
}
