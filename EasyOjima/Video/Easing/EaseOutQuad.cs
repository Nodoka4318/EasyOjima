using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class EaseOutQuad : IEasing {
        public string Name => "EaseOutQuad";

        public double Calc(double x) {
            return 1 - (1 - x) * (1 - x);
        }
    }
}
