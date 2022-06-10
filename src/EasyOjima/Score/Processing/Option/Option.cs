using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace EasyOjima.Score.Processing {
    public abstract class Option : FrameProcessor {
        public Option(FrameProcessor p)
            : base(p.Score, p.startFrame, p.endFrame, p.easing) {
            // 空
        }

        public abstract string Name { get; }

        public abstract void OptionProcess(ref Video.Video video);

        public List<Bitmap> GetFrames() {
            return this.Frames;
        }
    }
}
