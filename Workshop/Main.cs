using System;
using Hometask1;
using Hometask2.Exceptions;
namespace Workshop
{
    class WorkshopMain
    {
        static void Main(string[] args)
        {
            Hometask1.Hometask1.Main(args);
            Hometask2.Exceptions.Hometask2.Main(args);
            Console.ReadKey();

        }
    }
}
