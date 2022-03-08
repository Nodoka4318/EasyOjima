﻿using System;
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
        private int easeRate;
        private int frameDensityRate;
        private int interpolateRate;

        public FrameProcessor Processor { get; private set; }

        public LoadingDialog loadingDialog = new LoadingDialog("処理中です…", 4);

        //パラメーター多すぎて草
        public ProcessManager(string score, int bpm, int startFrame, int endFrame, int easeRate, int frameDensityRate, int interpolateRate) {
            this.score = score;
            this.bpm = bpm;
            this.startFrame = startFrame;
            this.endFrame = endFrame;
            this.easeRate = easeRate;
            this.frameDensityRate = frameDensityRate;
            this.interpolateRate = interpolateRate;
        }

        public void Process(Video.Video video) {
            loadingDialog.Show();
            Score sc = new Score(score, bpm);
            loadingDialog.UpdateDialog(1);
            FrameInterpolator.Interpolate(ref video, interpolateRate);           
            loadingDialog.UpdateDialog(2);
            Parser ps = new Parser(sc, video.FrameRate * frameDensityRate);
            loadingDialog.UpdateDialog(3);
            this.Processor = new FrameProcessor(ps, startFrame * (int)Math.Pow(2, interpolateRate - 1), endFrame * (int)Math.Pow(2, interpolateRate - 1), easeRate);
            Processor.Process(video);
            loadingDialog.UpdateDialog(4);
            loadingDialog.Dispose();
        }
    }
}
