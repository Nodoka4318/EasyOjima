using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class EaseInOutQuint : IEasing {
        public string Name => "EaseInOutQuint";

        public double Calc(double x) {
            return x < 0.5 ? 16 * x * x * x * x * x : 1 - Math.Pow(-2 * x + 2, 5) / 2;
        }
    }
}
