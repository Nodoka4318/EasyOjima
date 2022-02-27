using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Linq;
using EasyOjima.Enums;
using EasyOjima.Forms;
using OpenCvSharp;
using System.Drawing.Imaging;

namespace EasyOjima.Video {
    internal class VideoExporter {
        //ファイルについて
        private string cachePath = Loc.EXPORT_CACHE;
        public string ExportPath { get; set; }

        //動画について
        private double frameRate = 60d;

        //ローディング画面についてのデータ
        private LoadingDialog loadingDialog;

        public VideoExporter(Video video, string exportPath, LoadingDialog loadingDialog) {
            this.ExportPath = exportPath;
            this.loadingDialog = loadingDialog;
        }

        public VideoExporter(Video video, string exportPath) {
            this.ExportPath = exportPath;
            this.frameRate = video.FrameRate;
            Process(video);
        }

        public void Process(Video video) {
            //MakeCache(video);
            ExportVideo(video);
        }

        //使わなくなったやつ
        private void MakeCache(Video video) {
            var counter = 1;
            this.loadingDialog = new LoadingDialog($"フレーム処理中 ({counter}/{video.FrameSize})", video.FrameSize);
            loadingDialog.Show();
            foreach (Bitmap img in video.frames) {
                loadingDialog.UpdateDialog($"フレーム処理中 ({counter}/{video.FrameSize})", counter);
                var _path = @$"{Loc.EXPORT_CACHE}\{counter}.png";
                img.Save(_path, System.Drawing.Imaging.ImageFormat.Png);
                counter++;
            }
            //frameRate = video.FrameRate;
            //processLevel++;
            this.loadingDialog.Dispose();
        }

        private void ExportVideo(Video video) {
            var counter = 1;
            this.loadingDialog = new LoadingDialog($"動画ファイル出力中… ({counter}/{video.FrameSize})", video.FrameSize);
            loadingDialog.Show();
            using (var Writer = new VideoWriter(ExportPath, FourCC.H264, frameRate, new OpenCvSharp.Size(video.Width, video.Heigth))) {                
                foreach (var img in video.frames) {
                    var image = Mat.FromImageData(Delegate(() => {
                        using (var ms = new MemoryStream()) {
                            img.Save(ms, ImageFormat.Png);
                            return ms.GetBuffer();
                        }
                    }));
                    //var image = Mat.FromStream(File.OpenRead(img), ImreadModes.Color);
                    Writer.Write(image);
                    loadingDialog.UpdateDialog($"動画ファイル出力中… ({counter}/{video.FrameSize})", counter);
                    counter++;
                }
            }
            loadingDialog.Dispose();
        }

        /// <summary>
        /// なんか迷走してる
        /// これいる?
        /// </summary>
        /// <param name="func">byte[]を返すデリゲート</param>
        /// <returns>引数のデリゲートの返り値そのまま</returns>
        public static byte[] Delegate(Func<byte[]> func) {
            return func();
        }
    }
}
