using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class EaseOutCubic : IEasing {
        public string Name => "EaseOutCubic";

        public double Calc(double x) {
            return 1 - Math.Pow(1 - x, 3);
        }
    }
}
