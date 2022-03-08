using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using EasyOjima.Forms;

namespace EasyOjima.Video {
    public class FrameInterpolator {
        public static void Interpolate(ref Video video, int rate) {
            if (rate == 1)
                return;

            for (int k = 1; k < rate; k++) {
                LoadingDialog dlg = new LoadingDialog(video.FrameSize * 2 + 2);
                dlg.Show();
                for (int i = 0; i <= video.frames.Count - 2; i += 3) {
                    dlg.UpdateDialog($"フレーム補間中… ({k}/{rate - 1})", i);
                    video.frames.Insert(i + 1, GetMiddleFrame(video.GetFrame(i), video.GetFrame(i + 1)));
                }
                video.FrameRate = video.FrameRate * 2;
                dlg.Dispose();
            }
        }

        public static Bitmap GetMiddleFrame(Bitmap img0, Bitmap img1) {
            var image0 = Mat.FromImageData(VideoExporter.Delegate(() => {
                using (var ms = new MemoryStream()) {
                    img0.Save(ms, ImageFormat.Png);
                    return ms.GetBuffer();
                }
            }));

            var image1 = Mat.FromImageData(VideoExporter.Delegate(() => {
                using (var ms = new MemoryStream()) {
                    img1.Save(ms, ImageFormat.Png);
                    return ms.GetBuffer();
                }
            }));
            var midframe = image0 / 2 + image1 / 2;
            return midframe.ToMat().ToBitmap();

        }
    }
}
