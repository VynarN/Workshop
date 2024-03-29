﻿namespace StyleCop
{
    using System;

    public partial class FloatingPointCircle: IOperation<FloatingPointCircle>
    {
        public FloatingPointCircle GetFigureConsistingOfTwo(FloatingPointCircle firstCircle, FloatingPointCircle secondCircle)
        {
            CheckParams(firstCircle, secondCircle);
            var diameterOfFirstCircle = firstCircle.Radius + firstCircle.Radius;
            var diameterOfSecondCircle = secondCircle.Radius + secondCircle.Radius;
            var radiusOfNewCircle = (diameterOfFirstCircle + diameterOfSecondCircle) / 2;
            return new FloatingPointCircle((0.0, 0.0), radiusOfNewCircle);
        }

        public FloatingPointCircle GetCrossOfTwoFigures(FloatingPointCircle firstCirle, FloatingPointCircle secondCircle)
        {
            CheckParams(firstCirle, secondCircle);
            var leftmost = (Left: 0.0, Right: 0.0);
            var rightmost = (Left: 0.0, Right: 0.0);
            var uppermost = (Top: 0.0, Bottom: 0.0);
            var lowermost = (Top: 0.0, Bottom: 0.0);
            FindRangeOfCircleOnCertainAxis(firstCirle, secondCircle, 'x', ref leftmost, ref rightmost);
            if (leftmost.Right > rightmost.Left)
            {
                FindRangeOfCircleOnCertainAxis(firstCirle, secondCircle, 'y', ref uppermost, ref lowermost);
                if (uppermost.Bottom > lowermost.Top)
                {
                    var diameterOnX = leftmost.Right - rightmost.Left;
                    var diameterOnY = uppermost.Bottom - lowermost.Top;
                    var diameter = diameterOnX > diameterOnY ? diameterOnX : diameterOnY;
                    var centerX = (leftmost.Right + rightmost.Left) / 2;
                    var centerY = (uppermost.Bottom + lowermost.Top) / 2;
                    return new FloatingPointCircle((centerX, centerY), diameter / 2);
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
        public bool Check(FloatingPointCircle obj)
        {
            return obj != null;
        }

        private bool CheckParams(FloatingPointCircle first, FloatingPointCircle second)
        {
            if (Check(first) && Check(second))
            {
                return true;
            }
            else
            {
                throw new ArgumentException("Argument can not be null! Each circle should be initialized!");
            }
        }
        
        private void FindRangeOfCircleOnCertainAxis (FloatingPointCircle first, FloatingPointCircle second, char axis, ref (double, double) rangeOfTheLeftmostFigure, ref (double, double) rangeOfTheRightmostFigure)
        {
            if (char.ToLower(axis) == 'x')
            {
                if (first.Center.Item1 > second.Center.Item1)
                {
                    rangeOfTheLeftmostFigure = (first.Center.Item1 - first.Radius, first.Center.Item1 + first.Radius);
                    rangeOfTheRightmostFigure = (second.Center.Item1 - second.Radius, second.Center.Item1 + second.Radius);
                }
                else
                {
                    rangeOfTheLeftmostFigure = (second.Center.Item1 - second.Radius, second.Center.Item1 + second.Radius);
                    rangeOfTheRightmostFigure = (first.Center.Item1 - first.Radius, first.Center.Item1 + first.Radius);
                }
            }
            else if (char.ToLower(axis) == 'y')
            {
                if (first.Center.Item2 > second.Center.Item2)
                {
                    rangeOfTheLeftmostFigure = (first.Center.Item2 - first.Radius, first.Center.Item2 + first.Radius);
                    rangeOfTheRightmostFigure = (second.Center.Item2 - second.Radius, second.Center.Item2 + second.Radius);
                }
                else
                {
                    rangeOfTheLeftmostFigure = (second.Center.Item2 - second.Radius, second.Center.Item2 + second.Radius);
                    rangeOfTheRightmostFigure = (first.Center.Item2 - second.Radius, first.Center.Item2 + second.Radius);
                }
            }
            else
            {
                throw new ArgumentException("Specified axis does not exist!");
            }
        }
    }
}
