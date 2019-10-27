namespace StyleCop
{
    using System;

    public partial class Rectangle: Streams.Interfaces.ICheckable<Rectangle>
    {
        public bool Check(Rectangle obj)
        {
            return obj != null;
        }

        private bool CheckParams(Rectangle first, Rectangle second)
        {
            if (Check(first) && Check(second))
            {
                return true;
            }
            else
            {
                ArgumentException exception = new ArgumentException("Argument can not be null! Each rectangle should be initialized!");
                Logger.Log(exception);
                throw exception;
            }
        }
    }
}
