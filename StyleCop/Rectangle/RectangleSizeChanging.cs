namespace StyleCop
{
    using System;

    public partial class Rectangle
    {
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

        public Rectangle GetRectangleConsistingOfTwo(Rectangle firstRectangle, Rectangle secondRectangle)
        {
            CheckParams(firstRectangle, secondRectangle);
            var topLeft = firstRectangle.Width > secondRectangle.Width
                        ? (0.0, firstRectangle.TopLeft.Item2)
                        : (0.0, secondRectangle.TopLeft.Item2);
            var bottomRight = firstRectangle.Length > secondRectangle.Length
                            ? (firstRectangle.BottomRight.Item1, 0.0)
                            : (secondRectangle.BottomRight.Item1, 0.0);
            return new Rectangle(topLeft, bottomRight);

        }

        public Rectangle GetCrossRectangle(Rectangle firstRectangle, Rectangle secondRectangle)
        {
            CheckParams(firstRectangle, secondRectangle);
            var xRangeOfLeftmostRectangle = (leftBound: 0.0, rightBound: 0.0);
            var xRangeOfRightmostRectangle = (leftBound: 0.0, rightBound: 0.0);
            var yRangeOfUppermostRectangle = (upperBound: 0.0, lowerBound: 0.0);
            var yRangeOfLowermostRectangle = (upperBound: 0.0, lowerBound: 0.0);

            // Find X-ranges of the leftmost and rightmost rectangle.
            FindRangeOfRectangleOnCertainAxis(firstRectangle, secondRectangle, 'x', ref xRangeOfLeftmostRectangle, ref xRangeOfRightmostRectangle);

            // If right bound of the leftmost rectangle is not greater than the left bound
            // of the rightmost one, there is no cross.
            if (xRangeOfLeftmostRectangle.rightBound > xRangeOfRightmostRectangle.leftBound)
            {
                // Find Y-ranges of the uppermost and lowermost rectangle
                FindRangeOfRectangleOnCertainAxis(firstRectangle, secondRectangle, 'y', ref yRangeOfUppermostRectangle, ref yRangeOfLowermostRectangle);

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

        private void FindRangeOfRectangleOnCertainAxis(Rectangle firstRectangle, Rectangle secondRectangle, char axis, ref (double, double) leftmostFigure, ref (double, double) rightmostFigure)
        {
            if (char.ToLower(axis) == 'x')
            {
                if (firstRectangle.TopLeft.Item1 < secondRectangle.TopLeft.Item1)
                {
                    leftmostFigure = (firstRectangle.TopLeft.Item1, firstRectangle.BottomRight.Item1);
                    rightmostFigure = (secondRectangle.TopLeft.Item1, secondRectangle.BottomRight.Item1);
                }
                else
                {
                    leftmostFigure = (secondRectangle.TopLeft.Item1, secondRectangle.BottomRight.Item1);
                    rightmostFigure = (firstRectangle.TopLeft.Item1, firstRectangle.BottomRight.Item1);
                }
            }
            else if (char.ToLower(axis) == 'y')
            {
                if (firstRectangle.TopLeft.Item2 > secondRectangle.TopLeft.Item2)
                {
                   leftmostFigure = (firstRectangle.TopLeft.Item2, firstRectangle.BottomRight.Item2);
                   rightmostFigure = (secondRectangle.TopLeft.Item2, secondRectangle.BottomRight.Item2);
                }
                else
                {
                    leftmostFigure = (secondRectangle.TopLeft.Item2, secondRectangle.BottomRight.Item2);
                    rightmostFigure = (firstRectangle.TopLeft.Item2, firstRectangle.BottomRight.Item2);
                }
            }
            else
            {
                ArgumentException exception = new ArgumentException($"{axis} does not exist!");
                Logger.Log(exception);
                throw exception;
            }
        }
    }
}
