using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class EaseOutQuint : IEasing {
        public string Name => "EaseOutQuint";

        public double Calc(double x) {
            return 1 - Math.Pow(1 - x, 5);
        }
    }
}
