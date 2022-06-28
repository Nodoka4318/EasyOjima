using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EasyOjima.Bezier {
    [Serializable]
    public class BezierCurve {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }

        private double Dx1 => X1 / 100d;
        private double Dy1 => Y1 / 100d;
        private double Dx2 => X2 / 100d;
        private double Dy2 => Y2 / 100d;

        public Guid Id { get; private set; }

        public BezierCurve(int x1, int y1, int x2, int y2) {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;

            this.Id = Guid.NewGuid();
        }

        public double Calc(double x) {
            //var x = t * t * t * x4 + 3 * t * t * tp * x3 + 3 * t * tp * tp * x2 + tp * tp * tp * x1;
            var eq = new CubicEquation(1 - 3 * Dx1 + 3 * Dx2, 3 * Dx1 - 6 * Dx2, 3 * Dx2, -x);
            var t = eq.Solutions
                .Where(c => c.Imaginary == 0)
                .Where(c => c.Real <= 1.0d && c.Real >= 0d)
                .First()
                .Real;

            var tp = 1 - t;
            var y = t * t * t * 1 + 3 * t * t * tp * Dy2 + 3 * t * tp * tp * Dy1 ;
            Debug.WriteLine($"bezier: y: {y}");
            return y;
        }
    }
}
