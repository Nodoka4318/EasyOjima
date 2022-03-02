﻿using EasyOjima.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Score {
    public class Token {
        public NoteType Type { get; set; }
        public int ActualFrameLength { get; set; }
        public double BeatLength { get; set; }

        //後付けてbeatlengthつけたせいでぐちゃぐちゃ
        public Token(NoteType type, int actualFrameLength, double beatLength) {
            this.Type = type;
            this.ActualFrameLength = actualFrameLength;
            this.BeatLength = beatLength;
        }
    }
}
