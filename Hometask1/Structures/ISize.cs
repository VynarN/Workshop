using System;
using System.Collections.Generic;
using System.Text;

namespace Hometask1
{
    public interface ISize
    {
        double Width { get; set; }
        double Height { get; set; }
        double Perimeter();
    }
}
