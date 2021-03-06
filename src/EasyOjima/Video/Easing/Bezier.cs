using EasyOjima.Bezier;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class Bezier : IEasing {
        public string Name => "ベジェ曲線";
        public BezierCurve Curve { get; set; }

        public double Calc(double x) {
            return Curve.Calc(x);
        }
    }
}
