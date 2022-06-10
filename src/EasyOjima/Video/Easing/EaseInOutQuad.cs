using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class EaseInOutQuad : IEasing {
        public string Name => "EaseInOutQuad";

        public double Calc(double x) {
            return x < 0.5 ? 2 * x * x : 1 - Math.Pow(-2 * x + 2, 2) / 2;
        }
    }
}
