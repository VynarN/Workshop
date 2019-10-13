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
            DirectoryVisualizer visualizer = new DirectoryVisualizer(@"D:\Downloads\Example", new ConsoleUI());
            visualizer.Visualize();
        }
    }
}
