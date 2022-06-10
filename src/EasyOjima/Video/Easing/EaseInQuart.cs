using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class EaseInQuart : IEasing {
        public string Name => "EaseInQuart";

        public double Calc(double x) {
            return x * x * x * x;
        }
    }
}
