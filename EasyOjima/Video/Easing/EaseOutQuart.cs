using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class EaseOutQuart : IEasing {
        public string Name => "EasOutQuart";

        public double Calc(double x) {
            return 1 - Math.Pow(1 - x, 4);
        }
    }
}
