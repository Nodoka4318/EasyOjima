using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class Easing {
        public List<IEasing> EasingList { get; private set; }

        public Easing() {
            EasingList = new List<IEasing>();
            //Sine
            EasingList.Add(new EaseInSine());
            EasingList.Add(new EaseOutSine());
            EasingList.Add(new EaseInOutSine());
            //Quad
            EasingList.Add(new EaseInQuad());
            EasingList.Add(new EaseOutQuad());
            EasingList.Add(new EaseInOutQuad());
            //Cubic
            EasingList.Add(new EaseInCubic());
            EasingList.Add(new EaseOutCubic());
            EasingList.Add(new EaseInOutCubic());
            //Quart
            EasingList.Add(new EaseInQuart());
            EasingList.Add(new EaseOutQuart());
            EasingList.Add(new EaseInOutQuart());
            //Quint
            EasingList.Add(new EaseInQuint());
            EasingList.Add(new EaseOutQuint());
            EasingList.Add(new EaseInOutQuint());
            //Expo
            EasingList.Add(new EaseInExpo());
            EasingList.Add(new EaseOutExpo());
            EasingList.Add(new EaseInOutExpo());
            //Circ
            EasingList.Add(new EaseInCirc());
            EasingList.Add(new EaseOutCirc());
            EasingList.Add(new EaseInOutCirc());
        }
    }
}
