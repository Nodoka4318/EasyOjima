using EasyOjima.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace EasyOjima.Score.Processing {
    internal class KakukakuOption : Option {
        public KakukakuOption(FrameProcessor p) : base(p) { }

        public override string Name => "瞬間移動";

        public override void OptionProcess(ref Video.Video video) {
            var _frameRange = endFrame - startFrame;
            var formerFrame = video.GetFrame(startFrame);
            var latterFrame = video.GetFrame(endFrame);

            foreach (var note in Score.Tokens) {
                NoteType _type = note.Type;
                var _reqFrame = note.ActualFrameLength;
                var _frameBase = ConvertFrameSize(_frameRange, _reqFrame);

                //一時的においておく
                var _tempFrames = new List<Bitmap>();

                if (_type == NoteType.SEI) {
                    for (int i = 0; i < _frameBase.Count; i++) {
                        if (_frameBase[i] != 0) {
                            _tempFrames.Add(formerFrame);
                        }
                    }
                } else if (_type == NoteType.FU) {
                    for (int i = 0; i < _frameBase.Count; i++) {
                        if (_frameBase[i] != 0) {
                            _tempFrames.Add(latterFrame);
                        }
                    }
                } else if (_type == NoteType.YASUMI) {
                    _tempFrames.AddRange(
                        Enumerable.Repeat(this.Frames[this.Frames.Count - 1], _reqFrame)
                        );
                }

                this.Frames.AddRange(_tempFrames);
            }
        }
    }
}
