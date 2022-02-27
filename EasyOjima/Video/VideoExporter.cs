using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using FFMpegCore;
using FFMpegCore.Enums;
using EasyOjima.Enums;
using EasyOjima.Forms;

namespace EasyOjima.Video {
    internal class VideoExporter {
        //ファイルについて
        private string cachePath = Loc.EXPORT_CACHE;
        public string ExportPath { get; set; }

        //動画について
        private double frameRate = 60d;

        //ローディング画面についてのデータ
        private LoadingDialog loadingDialog;
        private int processLevel = 1;

        public VideoExporter(Video video, string exportPath, LoadingDialog loadingDialog, int processLevel) {
            this.ExportPath = exportPath;
            this.loadingDialog = loadingDialog;
            this.processLevel = processLevel;
        }

        public VideoExporter(Video video, string exportPath) {
            this.ExportPath = exportPath;
            //this.frameRate = video.FrameRate;
            Process(video);
        }

        public void Process(Video video) {
            MakeCache(video);
            ExportVideo();
        }

        private void MakeCache(Video video) {
            var counter = 1;
            this.loadingDialog = new LoadingDialog($"[{processLevel}] フレーム処理中 ({counter}/{video.FrameSize})", video.FrameSize);
            loadingDialog.Show();
            foreach (Bitmap img in video.frames) {
                loadingDialog.UpdateDialog($"[{processLevel}] フレーム処理中 ({counter}/{video.FrameSize})", counter);
                var _path = @$"{Loc.EXPORT_CACHE}\{counter}.png";
                img.Save(_path, System.Drawing.Imaging.ImageFormat.Png);
                counter++;
            }
            //frameRate = video.FrameRate;
            processLevel++;
            this.loadingDialog.Dispose();
        }

        private void ExportVideo() {
            //var appPath = Directory.GetCurrentDirectory();
            var counter = 1;
            var _caches = Directory.GetFiles(Loc.EXPORT_CACHE).OrderBy(
                c => int.Parse(c.Replace(@$"{Loc.EXPORT_CACHE}\", "").Replace(".png", ""))
                ).ToArray();
            this.loadingDialog = new LoadingDialog($"[{processLevel}] 出力中 ({counter}/{_caches.Length})", _caches.Length * 2);
            loadingDialog.Show();
            var imageInfos = new List<ImageInfo>();
            foreach (var _cache in _caches) {
                //MessageBox.Show(@$"{appPath}\{_cache}");
                loadingDialog.UpdateDialog($"[{processLevel}] 出力中 ({counter}/{_caches.Length})", counter);
                imageInfos.Add(ImageInfo.FromPath(@$"{_cache}"));
                counter++;
            }
            //MessageBox.Show($"{imageInfos.Count}");
            this.loadingDialog.UpdateDialog($"[{processLevel}] 動画ファイル作成中", counter);
            FFMpeg.JoinImageSequence(ExportPath, frameRate, imageInfos.Distinct().ToArray());
            this.loadingDialog.Dispose();
        }
    }
}
