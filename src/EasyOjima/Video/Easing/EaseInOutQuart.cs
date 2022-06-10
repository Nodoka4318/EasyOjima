using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class EaseInOutQuart : IEasing {
        public string Name => "EaseInOutQuart";

        public double Calc(double x) {
            return x < 0.5 ? 8 * x * x * x * x : 1 - Math.Pow(-2 * x + 2, 4) / 2;
        }
    }
}
