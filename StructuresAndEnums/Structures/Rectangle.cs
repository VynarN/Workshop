using System;
using System.Collections.Generic;
using System.Text;

namespace StructuresAndEnums.Structures
{
    public struct Rectangle: ICoordinates, ISize
    {   
        // In this case we assume that rectangle
        // lies directly on X-axis according to the zero point.
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle(double x, double y)
        {
            X = x;
            Y = y;
            Width = x < 0 ? -x : x;
            Height = y < 0 ? -y : y;
        }
        public double Perimeter()
        {
            return (Height + Width) * 2;
        }
    }
}
