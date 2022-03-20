using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public interface IEasing {
        public string Name { get; }
        public abstract double Calc(double x);
    }
}
