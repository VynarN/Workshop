using System;

namespace Hometask2.Exceptions
{
    public class Hometask2
    {
        public static void Main(string[] args)
        {
            int magicNumber = 5;
            var array = new int[magicNumber];
            try
            {
                //FindFactorialRecursively(magicNumber);
                InsertIntoArray(array, magicNumber, magicNumber);
            }catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                
            }
            // In this case, this is useless constraction because,
            // starting with CLR 2.0, we can no longer handle SO exception
            // unless it was thrown artifically.
            catch (StackOverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Testin DoSomeMath function:");
            DoSomeMath(-2, 3);
            DoSomeMath(2, 3);
        }
        static int FindFactorialRecursively(int x)
        {
            return FindFactorialRecursively(x) + FindFactorialRecursively(x - 1);
           
        }
        static void InsertIntoArray(int[] arr, int number, int pos)
        {
            arr[pos] = number;
        }
        static void DoSomeMath(int a, int b)
        {
            try
            {
                if (a < 0)
                {
                    throw new ArgumentException("Parameter should be greater than 0!", "a");
                }
                else if (b > 0)
                {
                    throw new ArgumentException("Parameter should be less than 0!", "b");
                }
            }
            catch (ArgumentException e)
            when (e.ParamName.Equals("a"))
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            when (e.ParamName.Equals("b"))
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
