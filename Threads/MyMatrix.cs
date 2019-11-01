namespace Threads
{
    using System;

    public class MyMatrix
    {
        public static int[,] Matrix { get; set; }

        public static uint Size { get; private set; }

        public static uint SectionSize { get; private set; }

        public static uint RowIdx { get; private set; } = 0;
        
        public MyMatrix(uint size)
        {
            Size = size;
            SectionSize = size / 4;
            Matrix = new int[size, size];
            FillInMatrix();
            
        }
        
        public static int Sum(int sum)
        {
            int currentSum = sum;
            for(var i = RowIdx; i < RowIdx + SectionSize; i++)
            {
                for(var j = 0; j < Size; j++)
                {
                    currentSum += Matrix[i, j];
                }
            }
            RowIdx = RowIdx < Size - SectionSize ? RowIdx + SectionSize : RowIdx;
            return currentSum;
        }

        private void FillInMatrix()
        {
            var rand = new Random();
            for(var i = 0; i < Size; i++)
            {
                for(var j = 0; j < Size; j++)
                {
                    Matrix[i, j] = rand.Next(0, 1000);
                }
            }
        }
    }
}
