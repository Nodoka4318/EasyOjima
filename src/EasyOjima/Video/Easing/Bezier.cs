using EasyOjima.Bezier;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class Bezier : IEasing {
        public string Name => "ベジェ曲線";
        public BezierCurve Curve { get; set; } = new BezierCurve(16, 99, 40, 13);

        public double Calc(double x) {
            return Curve.Calc(x);
        }
    }
}
