using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class EaseInOutExpo : IEasing {
        public string Name => "EaseInOutExpo";

        public double Calc(double x) {
            return x == 0 ? 0 : x == 1 ? 1 : x < 0.5 ? Math.Pow(2, 20 * x - 10) / 2 : (2 - Math.Pow(2, -20 * x + 10)) / 2;
        }
    }
}
