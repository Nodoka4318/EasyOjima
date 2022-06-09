using System;
using System.Collections.Generic;
using System.Text;
using EasyOjima.Forms;
using EasyOjima.Utils;
using EasyOjima.Video;
using EasyOjima.Enums;

namespace EasyOjima.Score.Processing {
    public class ProcessManager {
        private string score;
        private int bpm;
        private int startFrame;
        private int endFrame;
        private string easeType;
        private int frameDensityRate;
        private int interpolateRate;
        private Mode mode;

        public FrameProcessor Processor { get; private set; }

        public LoadingDialog loadingDialog = new LoadingDialog("処理中です…", 4);

        //パラメーター多すぎて草
        public ProcessManager(string score, int bpm, int startFrame, int endFrame, string easeType, int frameDensityRate, int interpolateRate, Mode mode) {
            this.score = score;
            this.bpm = bpm;
            this.startFrame = startFrame;
            this.endFrame = endFrame;
            this.easeType = easeType;
            this.frameDensityRate = frameDensityRate;
            this.interpolateRate = interpolateRate;
            this.mode = mode;
        }

        public void Process(Video.Video video) {
            try {
                loadingDialog.Show();
                Score sc = new Score(score, bpm);
                loadingDialog.UpdateDialog(1);
                if (interpolateRate > 1) {
                    FrameInterpolator.Interpolate(ref video, interpolateRate);
                }
                loadingDialog.UpdateDialog(2);
                Parser ps = new Parser(sc, video.FrameRate * frameDensityRate);
                loadingDialog.UpdateDialog(3);

                Easing easing = new Easing();
                easing.Set(easeType);
                easing = easing.Selected.Name == "Linear" ? null : easing;

                if (interpolateRate == 1) {
                    this.Processor = new FrameProcessor(
                        ps,
                        startFrame,
                        endFrame,
                        easing
                        );
                } else {
                    this.Processor = new FrameProcessor(
                        ps,
                        startFrame * (int)Math.Pow(2, interpolateRate - 1),
                        endFrame * (int)Math.Pow(2, interpolateRate - 1) - 1,
                        easing
                        );
                }
                Processor.Process(ref video);
                loadingDialog.UpdateDialog(4);
                loadingDialog.Dispose();
            } catch (Exception ex) {
                loadingDialog.Dispose();
                throw ex;
            }
        }
    }
}
