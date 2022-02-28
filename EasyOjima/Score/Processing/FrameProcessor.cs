using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;
using EasyOjima.Video;
using EasyOjima.Enums;
using System.Diagnostics;

namespace EasyOjima.Score.Processing {
    internal class FrameProcessor {
        public Parser Score { get; private set; }
        public List<Bitmap> Frames { get; set; }
        private int startFrame;
        private int endFrame;

        public FrameProcessor(Parser parser, Video.Video video, int startFrame, int endFrame) { 
            this.Score = parser;
            this.startFrame = startFrame;
            this.endFrame = endFrame;
            this.Frames = new List<Bitmap>();

            Debug.WriteLine("frameprocessorはいったよ");

            this.Process(video);
        }

        public void Process(Video.Video video) { 
            var _frameRange = endFrame - startFrame;

            foreach (var note in Score.Tokens) {
                NoteType _type = note.Type;
                var _reqFrame = note.ActualFrameLength;
                var _frameBase = ConvertFrameSize(_frameRange, _reqFrame);

                if (_type == NoteType.SEI) {
                    var _frameCounter = 0;
                    for (int i = 0; i < _reqFrame; i++) {
                        Debug.WriteLine($"Process SEI {_frameCounter}, {i}/{_reqFrame}");
                        var _currentVideoFrame = startFrame - 1 + _frameCounter;
                        if (_frameBase[i] == 1) {
                            this.Frames.Add(video.GetFrame(_currentVideoFrame));
                            _frameCounter++;
                        } else if (_frameBase[i] == 2) {
                            this.Frames.Add(this.Frames[this.Frames.Count - 1]);
                        }
                    }
                } else if (_type == NoteType.FU) {
                    var _frameCounter = _reqFrame;
                    for (int i = _reqFrame; i >= 0; i--) {
                        Debug.WriteLine($"Process FU {_frameCounter}, {i}/{_reqFrame}");
                        var _currentVideoFrame = startFrame - 1 + _frameCounter;
                        if (_frameBase[i] == 1) {
                            this.Frames.Add(video.GetFrame(_currentVideoFrame));
                            _frameCounter--;
                        } else if (_frameBase[i] == 2) {
                            this.Frames.Add(this.Frames[this.Frames.Count - 1]);
                        }
                    }
                }
            }
            Debug.WriteLine(Score.Tokens.Count);
        }

        /// <summary>
        /// フレーム数変換
        /// ほんとはもっといい方法あるけど書くのが面倒((
        /// 気が向いたら修正します
        /// </summary>
        /// <param name="actualSize">ほんとのおおきさ</param>
        /// <param name="reqSize">ほしいおおきさ</param>
        /// <returns>消すのを0, 残すのを1, 直前のを繰り返すのを2</returns>
        //TODO: フレーム数変換の改良
        public List<int> ConvertFrameSize(int actualSize, int reqSize) {
            var _base = Enumerable.Repeat(1, actualSize).ToList();
            if (actualSize == reqSize)
                return _base;
            if (actualSize > reqSize) {
                while (_base.Where(c => c == 1).Count() > reqSize) {
                    Debug.WriteLine($"confs<< {actualSize}, {reqSize}, {_base.Where(c => c == 1).Count()}");
                    _base[RandomInt(1, _base.Count - 1)] = 0;
                }
            } else {
                while (_base.Count < reqSize) {
                    Debug.WriteLine($"confs>> {actualSize}, {reqSize}, {_base.Count}");
                    _base.Insert(RandomInt(1, _base.Count - 1), 2);
                }
            }
            return _base.ToList();
        }

        private static int RandomInt(int min, int max) {
            var r = new Random();
            return r.Next(min, max + 1);
        }
    }
}
