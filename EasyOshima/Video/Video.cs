using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using EasyOshima.Forms;

namespace EasyOshima.Video {
    public class Video : IDisposable {
        public string path;
        public List<Bitmap> frames = new List<Bitmap>();
        public int CurrentFrame { get; set; } = 0;
        public int FrameSize { get; private set; }
        public double FrameRate { get; private set; }

        public Video(string path) {
            this.path = path;
        }

        public Video(List<Bitmap> frames) {
            this.frames = frames.ToList();
            this.FrameSize = frames.Count;
        }

        /// <summary>
        /// 非常に頭の悪い読み込み方
        /// </summary>
        public void Init() {
            if (this.path == null)
                return;

            using (VideoCapture vcap = new VideoCapture(path)) {
                this.FrameSize = vcap.FrameCount;
                this.FrameRate = vcap.Fps;
                var frameCounter = 0;
                LoadingDialog loadingDialog = new LoadingDialog(FrameSize);
                loadingDialog.Show();

                while (vcap.IsOpened()) {
                    using (Mat mat = new Mat()) {
                        if (vcap.Read(mat)) {
                            if (mat.IsContinuous()) {
                                this.frames.Add(BitmapConverter.ToBitmap(mat));
                            } else {
                                break;
                            }
                        } else {
                            break;
                        }
                    }
                    frameCounter++;
                    loadingDialog.UpdateDialog($"動画を読み込み中 ({frameCounter}/{FrameSize})", frameCounter);
                }
                loadingDialog.Close();
                loadingDialog.Dispose();
                this.FrameSize = frames.Count;
            }
        }

        public Bitmap GetFrame(int index) {
            if (this.frames.Count < 1)
                return null;
            return frames[index];
        }

        public Bitmap GetCurrentFrame() {
            if (this.frames.Count < 1)
                return null;
            return frames[CurrentFrame];
        }

        /// <summary>
        /// エセDispose
        /// </summary>
        public void Dispose() {
            this.frames = null;
            this.path = null;
        }
    }
}
