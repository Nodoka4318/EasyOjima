using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class EaseOutCirc : IEasing {
        public string Name => "EaseOutCirc";

        public double Calc(double x) {
            return Math.Sqrt(1 - Math.Pow(x - 1, 2));
        }
    }
}
