using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class EaseInOutCubic : IEasing {
        public string Name => "EaseInOutCubic";

        public double Calc(double x) {
            return x < 0.5 ? 4 * x * x * x : 1 - Math.Pow(-2 * x + 2, 3) / 2;
        }
    }
}
