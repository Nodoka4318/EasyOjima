using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public interface IEasing {
        string Name { get; }
        double Calc(double x);
    }
}
