using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class EaseInExpo : IEasing {
        public string Name => "EaseInExpo";

        public double Calc(double x) {
            return x == 0 ? 0 : Math.Pow(2, 10 * x - 10);
        }
    }
}
