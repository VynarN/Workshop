using System;
using System.Collections.Generic;
using System.Text;
using Exceptions;
namespace Workshop
{
    partial class WorkshopMain
    {
        static void Hometask2()
        {
            int magicNumber = 5;
            var array = new int[magicNumber];
            try
            {
                //ExceptionDemo.FindFactorialRecursively(magicNumber);
                ExceptionDemo.InsertIntoArray(array, magicNumber, magicNumber);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);

            }
            // In this case, this is useless construction because,
            // starting with CLR 2.0, we can no longer handle SO exception
            // unless it was thrown artifically.
            catch (StackOverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Testing DoSomeMath function:");
            ExceptionDemo.DoSomeMath(-2, 3);
            ExceptionDemo.DoSomeMath(2, 3);
        }

    }
}
