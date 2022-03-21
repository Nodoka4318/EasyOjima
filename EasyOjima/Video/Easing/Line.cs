using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class Line : IEasing {
        public string Name => "Line";
        public double Calc(double x) => x;
    }
}
