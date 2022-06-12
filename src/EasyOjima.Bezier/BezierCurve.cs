using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EasyOjima.Bezier {
    public class BezierCurve {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }

        public BezierCurve(int x1, int y1, int x2, int y2) {
            this.X1 = x1 / 100;
            this.Y1 = y1 / 100;
            this.X2 = x2 / 100;
            this.Y2 = y2 / 100;
        }

        public BezierCurve() {
            this.X1 = 0;
            this.Y1 = 0;
            this.X2 = 0;
            this.Y2 = 0;
        }

        public double Calc(double x) {
            //var x = t * t * t * x4 + 3 * t * t * tp * x3 + 3 * t * tp * tp * x2 + tp * tp * tp * x1;
            var eq = new CubicEquation(1 - 3 * X1 + 3 * X2, 3 * X1 - 6 * X2, 3 * X2, -x);
            var t = eq.Solutions
                .Where(c => c.Imaginary == 0)
                .Where(c => c.Real <= 1.0d && c.Real >= 0d)
                .First()
                .Real;

            var tp = 1 - t;
            var y = t * t * t * 1 + 3 * t * t * tp * Y2 + 3 * t * tp * tp * Y1 ;
            Debug.WriteLine($"bezier: y: {y}");
            return y;
        }
    }
}
