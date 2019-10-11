using System;
using System.Collections.Generic;
using System.Text;
using StructuresAndEnums.Structures;
using StructuresAndEnums.Enums;
namespace Workshop
{
    partial class WorkshopMain
    {
        static void Hometask1()
        {
            Person Nazar = new Person { Name = "Nazar", Surname = "Vynar", Age = 20 };
            Console.WriteLine($"Nazar is {Nazar.Age} years old");
            Console.WriteLine(Nazar.IsOlderOrYounger(21));
            Console.WriteLine(Nazar.IsOlderOrYounger(18));
            Console.WriteLine();
            Rectangle rectangle = new Rectangle(5.5, 3.4);
            Console.WriteLine($"X = {rectangle.X}\t Y = {rectangle.Y}");
            Console.WriteLine($"Width = {rectangle.Width}\t Height = {rectangle.Height}");
            Console.WriteLine($"Perimeter of the rectangle equals {rectangle.Perimeter()}");
            Rectangle rectangleOnMinusAxises = new Rectangle(-5.5, -3.4);
            Console.WriteLine($"X = {rectangleOnMinusAxises.X}\t Y = {rectangleOnMinusAxises.Y}");
            Console.WriteLine($"Width = {rectangleOnMinusAxises.Width}\t Height = {rectangleOnMinusAxises.Height}");
            Console.WriteLine($"Perimeter of the rectangle on minus axises equals {rectangleOnMinusAxises.Perimeter()}");
            Console.WriteLine();
            Console.WriteLine("Enter the number of month you want to check:");
            if (Int32.TryParse(Console.ReadLine(), out int month))
            {
                if (month >= 0 && month < 12)
                {
                    Console.WriteLine($"{(Months)(month)} - {month}");
                }
                else
                {
                    Console.WriteLine("There is no month corresponding to that numeric!");
                }
            }
            else
            {
                Console.WriteLine("ERROR! Invalid input!");
            }
            Console.WriteLine();
            Colors color = new Colors();
            color.DisplaySortedColors();
            Console.WriteLine();
            foreach (long value in Enum.GetValues(typeof(LongRange)))
            {
                Console.WriteLine($"INT64 {(LongRange)value} = {value}");
            }
        }
    }
}
