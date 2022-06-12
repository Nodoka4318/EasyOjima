using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace EasyOjima.Bezier {
    public class CubicEquation {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }

        public Complex[] Solutions => this.Solve(); //解

        public double _P => (3.0 * A * C - Math.Pow(B, 2)) / (3.0 * Math.Pow(A, 2)); //(3ac-b^2)/3a^2
        private double _Q => (2.0 * Math.Pow(B, 3) - 9.0 * A * B * C + 27.0 * Math.Pow(A, 2) * D) / (27.0 * Math.Pow(A, 3)); //(2b^3-9abc+27a^2d)/27a^3
        private double _Discriminant => (27.0 * Math.Pow(_Q, 2) + 4.0 * Math.Pow(_P, 3)) / 108.0; //判別式

        //ax^3+bx^2+cx+d=0
        public CubicEquation(double a, double b, double c, double d) { 
            if (a == 0) {
                throw new ArgumentException("不正なパラメーターです。a=0が渡されました。");
            }

            this.A = a;
            this.B = b;
            this.C = c;
            this.D = d;
        }

        private Complex[] Solve() {
            Complex[] y = new Complex[3];
            Complex[] x = new Complex[3];

            if (_P == 0d && _Q == 0d) {
                var _y = new Complex(0, 0);

                y = new Complex[3] { _y, _y, _y };
            } else if (_Discriminant > 0d) {
                var alpha = Root(-_Q / 2.0 + Math.Sqrt(_Discriminant), 3);
                var beta = Root(-_Q / 2.0 - Math.Sqrt(_Discriminant), 3);

                var _y0 = new Complex(alpha + beta, 0);
                var _y1 = new Complex(-1.0 / 2.0 * (alpha + beta), Math.Sqrt(3.0) / 2.0 * (alpha - beta));
                var _y2 = new Complex(-1.0 / 2.0 * (alpha + beta), -Math.Sqrt(3.0) / 2.0 * (alpha - beta));

                y = new Complex[3] { _y0, _y1, _y2 };
            } else if (_Discriminant == 0d) {
                var _y0 = new Complex(-2 * Root(_Q / 2.0, 3), 0);
                var _y1y2 = new Complex(Root(_Q / 2.0, 3), 0);

                y = new Complex[3] { _y0, _y1y2, _y1y2 };
            } else {
                var alpha = -_Q / 2.0;
                var beta = Math.Sqrt(-_Discriminant);

                for (int i = 0; i < 3; i++) {
                    y[i] = 2 * Root(Math.Pow(alpha, 2.0) + Math.Pow(beta, 2.0), 6) * Math.Cos((Math.Atan2(beta, alpha) + 2.0 * i * Math.PI) / 3.0);
                }
            }

            for (int i = 0; i < 3; i++) {
                x[i] = y[i] - new Complex(-B / 3.0 * A, 0);
            }

            return x;
        }

        /// <summary>
        /// n乗根
        /// </summary>
        /// <param name="x">ルートの中身</param>
        /// <param name="n">累乗根</param>
        /// <returns></returns>
        private static double Root(double x, int n) {
            if (x >= 0) {
                return Math.Pow(x, 1.0 / (double)n);
            } else {
                if ((n % 2) != 0) {
                    return -Math.Pow(-x, 1.0 / (double)n);
                } else { 
                    return double.NaN;
                }
            }
        }
    }
}
