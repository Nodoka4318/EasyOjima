using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;
using EasyOjima.Video;
using EasyOjima.Enums;
using System.Diagnostics;

namespace EasyOjima.Score.Processing {
    public class FrameProcessor {
        public Parser Score { get; private set; }
        public List<Bitmap> Frames { get; set; }
        private int startFrame;
        private int endFrame;
        private int easeRate;

        public FrameProcessor(Parser parser, int startFrame, int endFrame, int easeRate) { 
            this.Score = parser;
            this.startFrame = startFrame;
            this.endFrame = endFrame;
            this.easeRate = easeRate;
            this.Frames = new List<Bitmap>();

            Debug.WriteLine("frameprocessorはいったよ");
        }

        public void Process(ref Video.Video video) { 
            var _frameRange = endFrame - startFrame;

            foreach (var note in Score.Tokens) {
                NoteType _type = note.Type;
                var _reqFrame = note.ActualFrameLength;
                var _frameBase = ConvertFrameSize(_frameRange, _reqFrame);

                if (_type == NoteType.SEI) {
                    var _frameCounter = 0;
                    for (int i = 0; i < _frameBase.Count; i++) {
                        Debug.WriteLine($"Process SEI {_frameCounter}, {i}/{_reqFrame}");
                        var _currentVideoFrame = startFrame - 1 + _frameCounter;

                        if (_frameBase[i] == 2) {
                            Debug.WriteLine($"Process 2");
                            var _mid = FrameInterpolator.GetMiddleFrame(
                                this.Frames[this.Frames.Count - 1],
                                video.GetFrame(_currentVideoFrame)
                                );
                            this.Frames.Add(_mid);
                            continue;
                        } else if (_frameBase[i] != 0) {
                            this.Frames.Add(video.GetFrame(_currentVideoFrame));
                        }

                        _frameCounter++;
                    }
                } else if (_type == NoteType.FU) {
                    var _frameCounter = _frameRange;
                    for (int i = 0; i < _frameBase.Count; i++) {
                        Debug.WriteLine($"Process FU {_frameCounter}, {i}/{_reqFrame}");
                        var _currentVideoFrame = startFrame - 1 + _frameCounter;
                        
                        if (_frameBase[i] == 2) {
                            Debug.WriteLine($"Process 2");
                            var _mid = FrameInterpolator.GetMiddleFrame(
                                this.Frames[this.Frames.Count - 1],
                                video.GetFrame(_currentVideoFrame)
                                );
                            this.Frames.Add(_mid);
                            continue;
                        } else if (_frameBase[i] != 0) {
                            this.Frames.Add(video.GetFrame(_currentVideoFrame));
                        }

                        _frameCounter--;
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
        private List<int> ConvertFrameSize(int actualSize, int reqSize) {
            var _base = Enumerable.Repeat(1, actualSize).ToList();
            if (actualSize == reqSize)
                return _base;
            if (actualSize > reqSize) {
                _base = GetFrameBase(actualSize, easeRate);
                var _counter = 1;
                while (_base.Where(c => c == 1).Count() != reqSize) {
                    if (_base.Where(c => c == 1).Count() > reqSize) {
                        Debug.WriteLine($"confs><< {actualSize}, {reqSize}, {_base.Where(c => c == 1).Count()}");
                        if (_counter >= reqSize) {
                            _base[RandomInt(1, _base.Count - 2)] = 0;
                        } else {
                            _base[_counter] = 0;
                            _counter += 2;
                        }
                    } else {
                        Debug.WriteLine($"confs<<< {actualSize}, {reqSize}, {_base.Where(c => c == 1).Count()}");
                        _base[RandomInt(1, _base.Count - 2)] = 1;
                    }
                }
            } else {
                while (_base.Count != reqSize) {
                    Debug.WriteLine($"confs>> {actualSize}, {reqSize}, {_base.Count}");
                    _base.Insert(RandomInt(1, _base.Count - 2), 2);
                }
            }
            return _base.ToList();
        }

        public static List<int> GetFrameBase(int size, int easeRate) { //TODO: イージング
            var _base = Enumerable.Repeat(0, size).ToArray();
            double _rate = Math.Abs(easeRate) / 100;
            if (easeRate > 0) {
                double _counter = _base.Length - 1;
                for (int i = 0; _counter > 1; i++) {
                    _base[(int)_counter] = 1;
                    _counter -= Math.Ceiling(i * _rate);
                    //Debug.WriteLine($"{_counter} {i}");
                }
            } else if (easeRate < 0) {
                var _counter = 0;
                for (int i = 0; _counter < _base.Length - 1; i++) {
                    _base[_counter] = 1;
                    _counter += (int)Math.Ceiling(i * _rate);
                    //Debug.WriteLine(_counter);
                }
            } else {
                _base = _base.Select((number, index) => {
                    if (index == 0 || index == size - 1 || index % 2 == 0) {
                        return 1;
                    } else {
                        return 0;
                    }
                }).ToArray();
            }
            (_base[0], _base[_base.Length - 1]) = (1, 1);
            return _base.ToList();
        }

        private static int RandomInt(int min, int max) {
            var r = new Random();
            return r.Next(min, max + 1);
        }
    }
}
