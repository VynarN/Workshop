namespace Threads
{
    using System;
    using System.Threading.Tasks;

    public class MyMatrix
    {
        public int[,] Matrix { get; set; }

        public (uint, uint) Size { get; private set; }

        public uint SectionSize { get; private set; }

        private uint Remaining = 0;

        private const uint PROCESSES = 4;

        private bool SectionByRow;

        public MyMatrix((uint, uint) size)
        {
            Size = size;
            Matrix = new int[Size.Item1, Size.Item2];

            // Here we decide whether by row or by column the matrix 
            // will be sectioned. If rows < columns then by columns,
            // in other cases by rows.
            if(Size.Item1 < Size.Item2)
            {
                SectionByRow = false;
                SectionSize = Size.Item2 / PROCESSES;
                Remaining = Size.Item2 - (SectionSize * PROCESSES);
            }
            else
            {
                SectionByRow = true;
                SectionSize = Size.Item1 / PROCESSES;
                Remaining = Size.Item1 - (SectionSize * PROCESSES);
            }
            FillInMatrix();
        }

        public int ParallelCalculation()
        {
            var tasks = new Task<int>[PROCESSES];
            tasks[0] = Task<int>.Factory.StartNew(() => Sum(0));
            tasks[1] = Task<int>.Factory.StartNew(() => Sum(SectionSize));
            tasks[2] = Task<int>.Factory.StartNew(() => Sum(SectionSize * 2));
            tasks[3] = Task<int>.Factory.StartNew(() => Sum(SectionSize * 3));
            return tasks[0].Result + tasks[1].Result + tasks[2].Result + tasks[3].Result;
        }

        public int SequentialCalculation()
        {
            var sum = 0;
            for (var i = 0; i < Size.Item1; i++)
            {
                for (var j = 0; j < Size.Item2; j++)
                {
                    sum += Matrix[i, j];
                }
            }
            return sum;
        }

        private int Sum(uint from)
        {
            var sum = 0;
            var section = CheckLastSection(from);
            if (SectionByRow)
            {
                for (var i = from; i < from + section; i++)
                {
                    for (var j = 0; j < Size.Item2; j++)
                    {
                        sum += Matrix[i, j];
                    }
                }
            }
            else
            {
                for (var i = 0; i < Size.Item1; i++)
                {
                    for (var j = from; j < from + section; j++)
                    {
                        sum += Matrix[i, j];
                    }
                }
            }
            return sum;
        }

        private uint CheckLastSection(uint from)
        {
            if(Remaining != 0)
            {
                return (from + SectionSize + Remaining) == (SectionByRow ? Size.Item1 : Size.Item2)
                                   ? (SectionSize + Remaining)
                                   : (SectionByRow ? (Size.Item1 / PROCESSES) : (Size.Item2 / PROCESSES));
            }
            else
            {
                return SectionSize;
            }
        }

        private void FillInMatrix()
        {
            var rand = new Random();
            for (var i = 0; i < Size.Item1; i++)
            {
                for (var j = 0; j < Size.Item2; j++)
                {
                    Matrix[i, j] = rand.Next(1, 10);
                }
            }
        }
    }
}
