using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Drawing;
using System.Diagnostics;

namespace EasyOjima.Video {
    public class Easing {
        public List<IEasing> EasingList { get; private set; }
        public IEasing Selected { get; set; }

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
            //Bezier
            EasingList.Add(new Bezier());
        }

        public void Set(string name) {
            foreach (var item in EasingList) {
                if (name == item.Name) {
                    this.Selected = item;
                    return;
                }
            }
            this.Selected = new Linear();
            return;
        }

        private double Calc(double x) {
            return this.Selected.Calc(x);
        }

        public void Ease(ref Video video, int startFrame, int endFrame) {
            if (startFrame >= endFrame || endFrame >= video.FrameSize)
                throw new Exception("与えられたフレーム番号が不正です。");
            //video.frames = video.frames.Where((bitmap, index) => index >= startFrame && index <= endFrame).ToList();
            var result = new List<Bitmap>();
            var range = endFrame - startFrame + 1;
            double interval = 1d / (double)range;
            var _temp = (int)Math.Round(range * Calc(0));
            for (double i = 0; Math.Floor(i) <= 1; i += interval) {
                var _cur = (int)Math.Round(range * Calc(i));

                //ベジェ曲線のチェック
                if (this.Selected.Name == "ベジェ曲線") {
                    if (Calc(i) > 1d) {
                        throw new Exception($"ベジェ曲線の範囲が不正です。\n値: {Calc(i)}");
                    }
                }

                if (_temp == _cur && result.Count != 0) {
                    result.Add(FrameInterpolator.GetMiddleFrame(
                        result[result.Count - 1],
                        video.GetFrame(startFrame - 1 + _cur)
                        ));
                } else {
                    result.Add(video.GetFrame(startFrame - 1 + _cur));
                }                
                Debug.WriteLine($"easing.. <> {interval}, {i}, {_cur}, {range}");

                if (result.Count >= range) {
                    Debug.WriteLine("broke");
                    break;                    
                }
            }
            video.frames.InsertRange(startFrame - 1, result.ToList());

            //リソースの解放
            /*
            foreach (var item in result) {
                item.Dispose();
            }
            */
        }

        public void Ease(ref List<Bitmap> video) {
            var startFrame = 0;
            var endFrame = video.Count - 1;

            //video.frames = video.frames.Where((bitmap, index) => index >= startFrame && index <= endFrame).ToList();
            var result = new List<Bitmap>();
            var range = endFrame - startFrame;
            double interval = 1d / (double)range;
            var _temp = (int)Math.Round(range * Calc(0));
            for (double i = 0; Math.Floor(i) <= 1; i += interval) {
                var _cur = (int)Math.Round(range * Calc(i));
                if (_temp == _cur && result.Count != 0) {
                    result.Add(FrameInterpolator.GetMiddleFrame(
                        result[result.Count - 1],
                        video[startFrame + _cur]
                        ));
                } else {
                    result.Add(video[startFrame + _cur]);
                }
                Debug.WriteLine($"easing.. <> {interval}, {i}, {_cur}, {range}");

                if (result.Count >= video.Count) {
                    Debug.WriteLine("broke");
                    break;
                }
            }
            video = result.ToList();

            //リソースの解放
            /*
            foreach (var item in result) {
                item.Dispose();
            }
            */
        }
    }
}
