using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class EaseInCirc : IEasing {
        public string Name => "EaseInCirc";

        public double Calc(double x) {
            return 1 - Math.Sqrt(1 - Math.Pow(x, 2));
        }
    }
}
