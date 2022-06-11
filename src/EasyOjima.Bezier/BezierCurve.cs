using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Bezier {
    public class BezierCurve {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }

        public BezierCurve(int x1, int y1, int x2, int y2) {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }

        public BezierCurve() {
            this.X1 = 0;
            this.Y1 = 0;
            this.X2 = 0;
            this.Y2 = 0;
        }

        public double Calc(int x) {
            throw new NotImplementedException();
        }
    }
}
