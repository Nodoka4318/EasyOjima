using EasyOjima.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Score {
    public class Token {
        public NoteType Type { get; private set; }
        public int ActualFrameLength { get; private set; }
        public double BeatLength { get; private set; }

        //後付けてbeatlengthつけたせいでぐちゃぐちゃ
        public Token(NoteType type, int actualFrameLength, double beatLength) {
            this.Type = type;
            this.ActualFrameLength = actualFrameLength;
            this.BeatLength = beatLength;
        }
    }
}
