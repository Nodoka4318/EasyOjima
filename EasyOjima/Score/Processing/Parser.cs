using System;
using System.Collections.Generic;
using System.Text;
using EasyOjima.Enums;

namespace EasyOjima.Score.Processing {
    internal class Parser {
        public Score Score { get; private set; }
        public List<Token> Tokens { get; private set; }
        public int Fps { get; private set; }

        public Parser(Score score, int fps) {
            this.Score = score;
            this.Fps = fps;
            this.Tokens = new List<Token>();

            this.ParseNotes();
            //Debug.WriteLine("parserはいったよ");
        }

        private void ParseNotes() {
            for (int i = 0; i < Score.Length; i++) { 
                var _lit = Score.GetChar(i);
                double _relLength = 0;
                NoteType _type;
                //ハイフン先読み
                if (_lit != '-' && i != Score.Length - 1) {
                    char _temp = Score.GetChar(i + 1);
                    var _hCounter = 0;
                    if (_temp == '-') {
                        _hCounter++;
                        while (_temp == '-' && i + _hCounter + 1 != Score.Length - 1) {
                            _temp = Score.GetChar(i + _hCounter + 1);
                            if (_temp == '-')
                                _hCounter++;
                        }

                        _relLength += _hCounter * GetRelLength(_lit);
                        i += _hCounter + 1;
                    }
                }

                //休符
                if (_lit == '~') {
                    //TODO: 休符の実装
                    continue;
                }

                _type = GetType(_lit);
                _relLength += GetRelLength(_lit);

                Tokens.Add(new Token(_type, ToActualFrameLength(_relLength)));
            }
        }

        private double GetRelLength(char lit) {
            double _rel;
            switch (lit) {
                case 'd':
                case 'b':
                    _rel = 1; break;
                case 'q':
                case 'p':
                    _rel = 0.5; break;
                default:
                    _rel = 0; break;
            }
            return _rel;
        }

        private NoteType GetType(char lit) {
            NoteType _type;
            switch (lit) {
                case 'd':
                case 'q':
                    _type = NoteType.SEI; break;
                case 'b':
                case 'p':
                    _type = NoteType.FU; break;
                default:
                    _type = NoteType.ILLEGAL; break;
            }
            return _type;
        }

        private int ToActualFrameLength(double relLength) {
            double _framePerBeat = Fps * 60 / Score.Bpm;
            return (int)(_framePerBeat * relLength);
        }
    }

    public class Token {
        public NoteType Type { get; set; }
        public int ActualFrameLength { get; set; }

        public Token(NoteType type, int actualFrameLength) {
            this.Type = type;
            this.ActualFrameLength = actualFrameLength;
        }
    }
}
