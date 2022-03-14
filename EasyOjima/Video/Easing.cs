using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Video {
    public class Easing {
        public int startFrame;
        public int endFrame;
        public int easeRate;

        public void Ease(ref Video video) {
            if (easeRate == 0)
                return;
            else {
                if (startFrame >= endFrame || endFrame >= video.FrameSize)
                    throw new Exception("与えられたフレーム番号が不正です。");
                if (easeRate > 0)
                    this.EaseIn(ref video);
                else
                    this.EaseOut(ref video);
            }
        }

        public void EaseIn(ref Video video) {

        }

        public void EaseOut(ref Video video) {

        }
    }
}
