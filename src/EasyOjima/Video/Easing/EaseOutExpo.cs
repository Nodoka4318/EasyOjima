using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class EaseOutExpo : IEasing {
        public string Name => "EaseOutExpo";

        public double Calc(double x) {
            return x == 1 ? 1 : 1 - Math.Pow(2, -10 * x);
        }
    }
}
