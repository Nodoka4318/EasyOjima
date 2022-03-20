using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class EaseInCubic : IEasing {
        public string Name => "EaseInCubic";

        public double Calc(double x) {
            return x * x * x;
        }
    }
}
