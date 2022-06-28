using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using EasyOjima.Forms;

namespace EasyOjima.Video {
    public class Video : IDisposable {
        public string path;
        public List<Bitmap> frames = new List<Bitmap>();
        public int CurrentFrame { get; set; } = 0;
        public int FrameSize => this.frames.Count;
        public double FrameRate { get; set; }
        public int Width { get; private set; }
        public int Heigth { get; private set; }
        public int Height => Heigth; // タイポしちゃったけど修正するとプラグインの互換性がなくなるから

        public bool isInitialized = false; // 動画のフレームが読み込まれたかどうか

        public Video(string path) {
            this.path = path;
        }

        public Video(List<Bitmap> frames, int frameRate) {
            this.frames = frames.ToList();
            //FrameSize = frames.Count;
            FrameRate = frameRate;
            Width = frames[0].Width;
            Heigth = frames[0].Height;

            this.isInitialized = true;
        }

        /// <summary>
        /// 非常に頭の悪い読み込み方
        /// </summary>
        public void Init() {
            if (path == null)
                return;

            using (VideoCapture vcap = new VideoCapture(path)) {
                //this.FrameSize = vcap.FrameCount;
                this.FrameRate = vcap.Fps;
                this.Width = vcap.FrameWidth;
                this.Heigth = vcap.FrameHeight;
                var frameCounter = 0;
                var loadingDialog = new LoadingDialog(vcap.FrameCount);
                loadingDialog.Show();

                while (vcap.IsOpened()) {
                    using (Mat mat = new Mat()) {
                        if (vcap.Read(mat)) {
                            if (mat.IsContinuous()) {
                                frames.Add(mat.ToBitmap());
                            } else {
                                break;
                            }
                        } else {
                            break;
                        }
                    }
                    frameCounter++;
                    loadingDialog.UpdateDialog($"動画を読み込み中… ({frameCounter}/{vcap.FrameCount})", frameCounter);
                }
                loadingDialog.Dispose();
                //FrameSize = frames.Count;
                this.isInitialized = true;
            }
        }

        public Bitmap GetFrame(int index) {
            if (frames.Count < 1)
                return null;
            return frames[index];
        }

        public Bitmap GetCurrentFrame() {
            if (frames.Count < 1)
                return null;
            return frames[CurrentFrame];
        }

        /// <summary>
        /// エセDispose
        /// </summary>
        public void Dispose() {
            GC.SuppressFinalize(this);
        }
    }
}
