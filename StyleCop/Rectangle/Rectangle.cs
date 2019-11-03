namespace StyleCop
{
    using System;
    using Logger;

    // This class defines a functionality of a rectangle on the Cartesian coordinate system.
    public partial class Rectangle : IMovable<double>
    {
        public double Length { get; private set; }

        public double Width { get; private set; }

        public (double, double) TopLeft { get; private set; }

        public (double, double) BottomRight { get; private set; }

        public Rectangle((double, double) topLeft, (double, double) bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
            Length = Math.Abs(bottomRight.Item1 - topLeft.Item1);
            Width = Math.Abs(topLeft.Item2 - bottomRight.Item2);
        }

        public void Move(double value, Direction direction)
        {
            double step = Math.Abs(value);
            switch (direction)
            {
                case Direction.BOTTOM:
                    TopLeft = (TopLeft.Item1, TopLeft.Item2 - step);
                    BottomRight = (BottomRight.Item1, BottomRight.Item2 - step);
                    break;
                case Direction.TOP:
                    TopLeft = (TopLeft.Item1, TopLeft.Item2 + step);
                    BottomRight = (BottomRight.Item1, BottomRight.Item2 + step);
                    break;
                case Direction.LEFT:
                    TopLeft = (TopLeft.Item1 - step, TopLeft.Item2);
                    BottomRight = (BottomRight.Item1 - step, BottomRight.Item2);
                    break;
                case Direction.RIGHT:
                    TopLeft = (TopLeft.Item1 + step, TopLeft.Item2);
                    BottomRight = (BottomRight.Item1 + step, BottomRight.Item2);
                    break;
            }
        }

    }
}
