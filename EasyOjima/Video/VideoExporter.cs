using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;
using FFMpegCore;
using EasyOjima.Enums;
using EasyOjima.Forms;
using EasyOjima.Utils;
using Splicer.Timeline;
using Splicer.Renderer;
using Splicer.WindowsMedia;

namespace EasyOjima.Video {
    internal class VideoExporter {
        //ファイルについて
        private string cachePath = Loc.EXPORT_CACHE;
        public string ExportPath { get; set; }

        //動画について
        private double frameRate = 30d;

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
            this.frameRate = video.FrameRate;
            Process(video);
        }

        public void Process(Video video) {
            //MakeCache(video);
            ExportVideo(video);
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

        /*
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
        */

        private void ExportVideo(Video video) {
            
            //var appPath = Directory.GetCurrentDirectory();
            var counter = 1;
            var frames = video.frames.ToList();
            
            this.loadingDialog = new LoadingDialog($"[{processLevel}] 動画ファイル出力中 ({counter}/{frames.Count})", frames.Count);
            loadingDialog.Show();


            //MessageBox.Show($"{imageInfos.Count}");
            
            int width = 1280;
            int height = 720;
            if (frames == null || frames.Count == 0)
                return;
            try {
                using (ITimeline timeline = new DefaultTimeline(frameRate)) {
                    IGroup group = timeline.AddVideoGroup(32, width, height);
                    ITrack videoTrack = group.AddTrack();

                    int i = 0;
                    double miniDuration = 1.0 / frameRate;
                    foreach (var bmp in frames) {
                        IClip clip = videoTrack.AddImage(bmp, 0, i * miniDuration, (i + 1) * miniDuration);
                        this.loadingDialog.UpdateDialog($"動画ファイル出力中 ({counter}/{frames.Count})", counter);
                        i++;
                        counter++;
                    }

                    this.loadingDialog.UpdateDialog($"[{processLevel}] 仕上げ中…", counter - 1);
                    timeline.AddAudioGroup();
                    IRenderer renderer = new WindowsMediaRenderer(timeline, ExportPath, WindowsMediaProfiles.HighQualityVideo);
                    renderer.Render();
                }
            } catch (Exception ex) {
                MessageUtil.ErrorMessage(ex.Message);
                this.loadingDialog.Dispose();
                return;
            }

            this.loadingDialog.Dispose();
        }

        public void CreateVideo(List<Bitmap> bitmaps, string outputFile, double fps) {
            int width = 640;
            int height = 480;
            if (bitmaps == null || bitmaps.Count == 0) 
                return;
            try {
                using (ITimeline timeline = new DefaultTimeline(fps)) {
                    IGroup group = timeline.AddVideoGroup(32, width, height);
                    ITrack videoTrack = group.AddTrack();

                    int i = 0;
                    double miniDuration = 1.0 / fps;
                    foreach (var bmp in bitmaps) {
                        IClip clip = videoTrack.AddImage(bmp, 0, i * miniDuration, (i + 1) * miniDuration);
                    }
                    timeline.AddAudioGroup();
                    IRenderer renderer = new WindowsMediaRenderer(timeline, outputFile, WindowsMediaProfiles.HighQualityVideo);
                    renderer.Render();
                }
            } catch { 
                return; 
            }
        }
    }
}
