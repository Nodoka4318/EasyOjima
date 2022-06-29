using System;
using System.Collections.Generic;
using System.Text;
using EasyOjima.Forms;
using EasyOjima.Utils;
using EasyOjima.Video;
using EasyOjima.Enums;
using EasyOjima.Bezier;

namespace EasyOjima.Score.Processing {
    public class ProcessManager {
        private string _score;
        private int _bpm;
        private int _startFrame;
        private int _endFrame;
        private string _easeType;
        private int _frameDensityRate;
        private int _interpolateRate;
        private Mode _mode;
        private BezierCurve _bezierCurve;

        public FrameProcessor Processor { get; private set; }
        public OptionManager Option { get; private set; }

        public LoadingDialog loadingDialog = new LoadingDialog("処理中です…", 4);

        //パラメーター多すぎて草
        public ProcessManager(string score, int bpm, int startFrame, int endFrame, string easeType, int frameDensityRate, int interpolateRate, Mode mode, BezierCurve curve) {
            this._score = score;
            this._bpm = bpm;
            this._startFrame = startFrame;
            this._endFrame = endFrame;
            this._easeType = easeType;
            this._frameDensityRate = frameDensityRate;
            this._interpolateRate = interpolateRate;
            this._mode = mode;
            this._bezierCurve = curve;
        }

        public void Process(Video.Video video) {
            //try {
                loadingDialog.Show();
                Score sc = new Score(_score, _bpm);
                loadingDialog.UpdateDialog(1);
                if (_interpolateRate > 1) {
                    FrameInterpolator.Interpolate(ref video, _interpolateRate);
                }
                loadingDialog.UpdateDialog(2);
                Parser ps = new Parser(sc, video.FrameRate * _frameDensityRate);
                loadingDialog.UpdateDialog(3);

                Easing easing = new Easing();
                easing.BezierCurve = _bezierCurve;
                easing.Set(_easeType);
                //easing = easing.Selected.Name == "Linear" ? null : easing;

                if (_interpolateRate == 1) {
                    this.Processor = new FrameProcessor(
                        ps,
                        _startFrame,
                        _endFrame,
                        easing
                        );
                } else {
                    this.Processor = new FrameProcessor(
                        ps,
                        _startFrame * (int)Math.Pow(2, _interpolateRate - 1),
                        _endFrame * (int)Math.Pow(2, _interpolateRate - 1) - 1,
                        easing
                        );
                }

                if (_mode == Mode.NORMAL) { //オプションなし通常
                    Processor.Process(ref video);
                } else { //オプションあり
                    Option = new OptionManager(Processor);
                    Option.Set(_mode.GetName());
                    Option.Process(ref video);
                }

                loadingDialog.UpdateDialog(4);
                loadingDialog.Dispose();
            //} catch (Exception ex) {
            //    loadingDialog.Dispose();
            //    throw ex;
            //}
        }
    }
}
