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
        public Video.Video Video {
            get {
                return Program.mainView.video;
            }
        }

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
        /// MainViewの動画のフレームをインデックス番号の条件で取捨選択します
        /// </summary>
        /// <param name="func">デリゲート</param>
        public void FrameWhere(Func<int, bool> func) {
            Program.mainView.video.frames = Program.mainView.video.frames.Where((bitmap, index) => func(index)).ToList();
            Program.mainView.controls.trackBar.Maximum = Program.mainView.video.FrameSize;
        }
    }
}
