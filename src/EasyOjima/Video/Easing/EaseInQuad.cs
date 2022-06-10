using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class EaseInQuad : IEasing {
        public string Name => "EaseInQuad";

        public double Calc(double x) {
            return x * x;
        }
    }
}
