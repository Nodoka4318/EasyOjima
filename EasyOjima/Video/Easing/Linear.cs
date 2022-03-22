using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class Linear : IEasing {
        public string Name => "Linear";
        public double Calc(double x) => x;
    }
}
