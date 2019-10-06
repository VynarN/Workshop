using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Hometask1.Enums
{
    public static class EnumsExtensions
    {
        public static void DisplaySortedColors(this Colors colors)
        {
            foreach(int value in Enum.GetValues(typeof(Colors)))
            {
                Console.WriteLine($"{(Colors)value} - {value}");
            }
        }
    }
}
