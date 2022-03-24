using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace EasyOjima.Plugin {
    public class PluginHost {
        /// <summary>
        /// 現在MainViewウインドウに読み込まれている動画です
        /// </summary>
        public Video.Video Video => Program.mainView.video;

        /// <summary>
        /// ホストのバージョンです
        /// </summary>
        public string AppVersion => Program.VERSION;

        /// <summary>
        /// メインウインドウの座標です
        /// </summary>
        public Point MainViewLocation => Program.mainView.Location;

        /// <summary>
        /// メインウインドウの再生窓の座標です
        /// </summary>
        public Point ViewBoxLocation => Program.mainView.ViewBox.Location;

        /// <summary>
        /// 動画が再生中かどうかを示します
        /// </summary>
        public bool IsPlaying => Program.mainView.isPlaying;

        /// <summary>
        /// 読み込まれたプラグインです
        /// </summary>
        public IPlugin[] LoadedPlugins => Program.mainView.plugins;

        /// <summary>
        /// MainViewの動画を差し替えます
        /// </summary>
        /// <param name="video">差し替えたい動画</param>
        public void SetVideo(Video.Video video) { 
            Program.mainView.video = video;
            Program.mainView.controls.trackBar.Maximum = video.FrameSize;
        }

        /// <summary>
        /// MainViewの動画を改変します
        /// </summary>
        /// <param name="func">デリゲート</param>
        public void EditVideo(Func<Bitmap, Bitmap> func) { 
            Program.mainView.video.frames = Program.mainView.video.frames.Select(c => func(c)).ToList();
        }

        /// <summary>
        /// MainViewの動画のフレームをインデックス番号の条件で選択します
        /// </summary>
        /// <param name="func">デリゲート</param>
        public void FrameWhere(Func<int, bool> func) {
            var _baseSize = Program.mainView.video.FrameSize;
            Program.mainView.video.frames = Program.mainView.video.frames.Where((bitmap, index) => func(index)).ToList();
            Program.mainView.video.FrameRate = (int)(Program.mainView.video.FrameRate * Program.mainView.video.FrameSize / _baseSize);
            Program.mainView.controls.trackBar.Maximum = Program.mainView.video.FrameSize;
        }

        /// <summary>
        /// MainViewの動画を再生します
        /// </summary>
        public void PlayVideo() {
            Program.mainView.PlayVideo();
        }

        /// <summary>
        /// MainViewの動画を一時停止します
        /// </summary>
        public void PauseVideo() {
            Program.mainView.PauseVideo();
        }

        /// <summary>
        /// MainViewの動画を停止します
        /// </summary>
        public void StopVideo() {
            Program.mainView.StopVideo();
        }

        /// <summary>
        /// MainViewの動画の位置を変えます
        /// </summary>
        /// <param name="index">フレームのインデックス番号</param>
        /// <exception cref="Exception">フレームの大きさを超えたとき</exception>
        public void SetViewFrame(int index) {
            if (index >= Video.FrameSize)
                throw new Exception("フレームが大きすぎます");
            Program.mainView.SetFrame(index);
        }

        /// <summary>
        /// 動画の指定したフレームを取り出します
        /// </summary>
        /// <param name="index">フレームのインデックス番号</param>
        /// <returns>指定したインデックス番号のフレーム</returns>
        public Bitmap GetFrame(int index) => Program.mainView.video.GetFrame(index);

        /// <summary>
        /// 動画の指定したフレームを置き換えます
        /// </summary>
        /// <param name="index">置き換えたいのインデックス番号</param>
        /// <param name="frame">置き換えたいフレーム</param>
        public void ReplaceFrame(int index, Bitmap frame) => Program.mainView.video.frames[index] = frame;

        /// <summary>
        /// メインウインドウの再生窓を再読み込みします
        /// </summary>
        public void RefreshViewBox() => Program.mainView.ViewBox.Refresh(); 
    }
}
