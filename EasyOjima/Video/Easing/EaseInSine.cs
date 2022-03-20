using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class EaseInSine : IEasing {
        public string Name => "EaseInSine";

        public double Calc(double x) {
            return 1 - Math.Cos((x * Math.PI) / 2);
        }
    }
}
