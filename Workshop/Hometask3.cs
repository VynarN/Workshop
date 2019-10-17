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
            //DirectoryVisualizer visualizer = new DirectoryVisualizer(@"D:\Downloads", new ConsoleUI());
            //visualizer.Visualize();
            FileSearcher fs = new FileSearcher("new");
            Console.WriteLine($"File location: {fs.SearchFile()}");
        }
    }
}
