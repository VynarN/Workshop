namespace StyleCop
{
    using System;
    using Logger;

    // This class defines a functionality of a rectangle on Cartesian coordinate system.
    public class Rectangle: Streams.Interfaces.ICheckable<Rectangle>
    {
        public double Length { get; private set; }

        public double Width { get; private set; }

        public (double, double) TopLeft { get; private set; }

        public (double, double) BottomRight { get; private set; }

        private MyLogger logger;
        
        public Rectangle((double, double) topLeft, (double, double) bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
            Length = Math.Abs(bottomRight.Item1 - topLeft.Item1);
            Width = Math.Abs(topLeft.Item2 - bottomRight.Item2);
            logger = new MyLogger(new Configuration(LevelOfDetalization.INFO, String.Empty));
        }

        public void Move(Direction direction, double step)
        {
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

        public void ChangeLenght(double length, Direction direction = default)
        {
            switch (direction)
            {
                case Direction.LEFT:
                    TopLeft = (TopLeft.Item1 - length, TopLeft.Item2);
                    break;
                case Direction.RIGHT:
                    BottomRight = (BottomRight.Item1 + length, BottomRight.Item2);
                    break;
                default:
                    TopLeft = (TopLeft.Item1 - (length / 2.0), TopLeft.Item2);
                    BottomRight = (BottomRight.Item1 + (length / 2.0), BottomRight.Item2);
                    break;
            }
            Length = Length + length;
        }

        public void ChangeWidth(double width, Direction direction = default)
        {
            switch (direction)
            {
                case Direction.TOP:
                    TopLeft = (TopLeft.Item1, TopLeft.Item2 + width);
                    break;
                case Direction.BOTTOM:
                    BottomRight = (BottomRight.Item1, BottomRight.Item2 - width);
                    break;
                default:
                    TopLeft = (TopLeft.Item1, TopLeft.Item2 + (width / 2.0));
                    BottomRight = (BottomRight.Item1, BottomRight.Item2 - (width / 2.0));
                    break;
            }
            Width = Width + width;
        }

        public Rectangle GetRectangleThatConsistsOfTwo(Rectangle firstRectangle, Rectangle secondRectangle)
        {
            if (Check(firstRectangle) && Check(secondRectangle))
            {
                var topLeft = firstRectangle.Width > secondRectangle.Width
                             ? (0.0, firstRectangle.TopLeft.Item2)
                             : (0.0, secondRectangle.TopLeft.Item2);
                var bottomRight = firstRectangle.Length > secondRectangle.Length
                            ? (firstRectangle.BottomRight.Item1, 0.0)
                            : (secondRectangle.BottomRight.Item1, 0.0);
                return new Rectangle(topLeft, bottomRight);
            }
            else
            {
                return null;
            }
        }

        public Rectangle GetCrossRectangle(Rectangle firstRectangle, Rectangle secondRectangle)
        {
            if (Check(firstRectangle) && Check(secondRectangle))
            {
                var xRangeOfLeftmostRectangle = (leftBound: 0.0, rightBound: 0.0);
                var xRangeOfRightmostRectangle = (leftBound: 0.0, rightBound: 0.0);
                var yRangeOfUppermostRectangle = (upperBound: 0.0, lowerBound: 0.0);
                var yRangeOfLowermostRectangle = (upperBound: 0.0, lowerBound: 0.0);

                // Find X-ranges of the leftmost and rightmost rectangle.
                FindRangesOfRectanglesOnCertainAxis(firstRectangle, secondRectangle, 'x', ref xRangeOfLeftmostRectangle, ref xRangeOfRightmostRectangle);

                // If right bound of the leftmost rectangle is not greater than the left bound
                // of the rightmost one, there is no cross.
                if (xRangeOfLeftmostRectangle.rightBound > xRangeOfRightmostRectangle.leftBound)
                {
                    // Find Y-ranges of the uppermost and lowermost rectangle
                    FindRangesOfRectanglesOnCertainAxis(firstRectangle, secondRectangle, 'y', ref yRangeOfUppermostRectangle, ref yRangeOfLowermostRectangle);

                    // If lower bound of the upper rectangle is not greater than the upper bound
                    // of the lower one, there is no cross on Y-axis even if it is on X-axis.
                    if (yRangeOfUppermostRectangle.lowerBound > yRangeOfLowermostRectangle.upperBound)
                    {
                        return new Rectangle((xRangeOfRightmostRectangle.leftBound, yRangeOfLowermostRectangle.upperBound),
                                            (xRangeOfLeftmostRectangle.rightBound, yRangeOfUppermostRectangle.lowerBound));
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                ArgumentException exception = new ArgumentException("Argument can not be null! Each rectangle should be initialized!");
                logger.Log(exception);
                throw exception;
            }
        }

        public bool Check(Rectangle obj)
        {
            return obj == null ? false : true;
        }
        
        private void FindRangesOfRectanglesOnCertainAxis(Rectangle firstRectangle, Rectangle secondRectangle, char axis, ref (double, double) firstRange, ref(double, double) secondRange)
        {
            if (char.ToLower(axis) == 'x')
            {
                if (firstRectangle.TopLeft.Item1 < secondRectangle.TopLeft.Item1)
                {
                    firstRange = (firstRectangle.TopLeft.Item1, firstRectangle.BottomRight.Item1);
                    secondRange = (secondRectangle.TopLeft.Item1, secondRectangle.BottomRight.Item1);
                }
                else
                {
                    firstRange = (secondRectangle.TopLeft.Item1, secondRectangle.BottomRight.Item1);
                    secondRange = (firstRectangle.TopLeft.Item1, firstRectangle.BottomRight.Item1);
                }
            }
            else if (char.ToLower(axis) == 'y')
            {
                if (firstRectangle.TopLeft.Item2 > secondRectangle.TopLeft.Item2)
                {
                    firstRange = (firstRectangle.TopLeft.Item2, firstRectangle.BottomRight.Item2);
                    secondRange = (secondRectangle.TopLeft.Item2, secondRectangle.BottomRight.Item2);
                }
                else
                {
                    firstRange = (secondRectangle.TopLeft.Item2, secondRectangle.BottomRight.Item2);
                    secondRange = (firstRectangle.TopLeft.Item2, firstRectangle.BottomRight.Item2);
                }
            }
            else
            {
                ArgumentException exception = new ArgumentException($"{axis} does not exist!");
                logger.Log(exception);
                throw exception;
            }
        }
    }
}
