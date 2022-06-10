using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class EaseInOutSine : IEasing {
        public string Name => "EaseInOutSine";

        public double Calc(double x) {
            return -(Math.Cos(Math.PI * x) - 1) / 2;
        }
    }
}
