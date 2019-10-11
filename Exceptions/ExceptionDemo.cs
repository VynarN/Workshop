using System;

namespace Exceptions
{
    public class ExceptionDemo
    {
        public static int FindFactorialRecursively(int x)
        {
            return FindFactorialRecursively(x) + FindFactorialRecursively(x - 1);

        }
        public static void InsertIntoArray(int[] arr, int number, int pos)
        {
            arr[pos] = number;
        }
        public static void DoSomeMath(int a, int b)
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
