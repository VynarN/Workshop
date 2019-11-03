namespace Workshop
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Threads;

    public partial class WorkshopMain
    {
        static void ThreadsPractise()
        {
            MyMatrix matrix = new MyMatrix((999, 400));
            Console.WriteLine($"Sequential calculation: {matrix.SequentialCalculation(), -20}");
            Console.WriteLine($"Parallel calculation: {matrix.ParallelCalculation(), -20}");

            MyMatrix matrix2 = new MyMatrix((1000, 1000));
            Console.WriteLine($"Sequential calculation: {matrix2.SequentialCalculation(), -20}");
            Console.WriteLine($"Parallel calculation: {matrix2.ParallelCalculation(), -20}");

            DelayAndClear();
        }

    }
}
