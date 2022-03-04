using System;
using System.Collections.Generic;
using System.Text;
using EasyOjima.Forms;
using EasyOjima.Video;

namespace EasyOjima.Score.Processing {
    internal class ProcessManager {
        private string score;
        private int bpm;
        private int startFrame;
        private int endFrame;
        public FrameProcessor Processor { get; private set; }

        public LoadingDialog loadingDialog = new LoadingDialog("処理中です…", 4);

        public ProcessManager(string score, int bpm, int startFrame, int endFrame) {
            this.score = score;
            this.bpm = bpm;
            this.startFrame = startFrame;
            this.endFrame = endFrame;
        }

        public void Process(Video.Video video) {
            loadingDialog.Show();
            Score sc = new Score(score, bpm);
            loadingDialog.UpdateDialog(1);
            Parser ps = new Parser(sc, (int)video.FrameRate);
            loadingDialog.UpdateDialog(2);
            this.Processor = new FrameProcessor(ps, startFrame, endFrame);
            Processor.Process(video);
            loadingDialog.UpdateDialog(4);
            loadingDialog.Dispose();
        }
    }
}
