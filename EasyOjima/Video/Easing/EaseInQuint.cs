using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class EaseInQuint : IEasing {
        public string Name => "EaseInQuint";

        public double Calc(double x) {
            return x * x * x * x * x;
        }
    }
}
