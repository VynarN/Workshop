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
            const int TASKS = 4;
            MyMatrix matrix = new MyMatrix(1000);
            Task<int>[] tasks = new Task<int>[TASKS];
            var size = MyMatrix.Size;
            var seqResult = 0;
            var seqMatrix = MyMatrix.Matrix;
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    seqResult += seqMatrix[i, j];
                }
            }
            Console.WriteLine("Sequentional computition: " + seqResult);have
            tasks[0] = Task<int>.Factory.StartNew(() => MyMatrix.Sum(0));
            tasks[1] = Task<int>.Factory.StartNew(() => MyMatrix.Sum(tasks[0].Result));
            tasks[2] = Task<int>.Factory.StartNew(() => MyMatrix.Sum(tasks[1].Result));
            tasks[3] = Task<int>.Factory.StartNew(() => MyMatrix.Sum(tasks[2].Result));
            Console.WriteLine("Parallel: " + tasks[3].Result);
            DelayAndClear();
        }

    }
}
