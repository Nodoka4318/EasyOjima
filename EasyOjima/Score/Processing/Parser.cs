using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Score.Processing {
    internal class Parser {
        public Score Score { get; private set; }
        public int CurrentIndex { get; private set; }

        public Parser(Score score) {
            this.Score = score;
        }


    }
}
