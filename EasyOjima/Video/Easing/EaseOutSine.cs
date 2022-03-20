using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class EaseOutSine : IEasing {
        public string Name => "EaseOutSine";

        public double Calc(double x) {
            return Math.Sin((x * Math.PI) / 2);
        }
    }
}
