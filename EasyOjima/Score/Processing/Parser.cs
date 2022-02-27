using System;
using System.Collections.Generic;
using System.Text;
using EasyOjima.Enums;

namespace EasyOjima.Score.Processing {
    //独立させる必要なかったかも()
    internal class Parser {
        public Score Score { get; private set; }
        public int CurrentIndex { get; private set; }
        public List<Token> Tokens { get; private set; }
        public int Fps { get; private set; }

        public Parser(Score score, int fps) {
            this.Score = score;
            this.Fps = fps;
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
                    if (_temp == '-')
                        _hCounter++;
                    while (_temp == '-' && i + _hCounter + 1 != Score.Length - 1) { 
                        _temp = Score.GetChar(i + _hCounter + 1);
                        if (_temp == '-')
                            _hCounter++;
                    }

                    for (int j = 0; j < _hCounter; j++)
                        _relLength += GetRelLength(GetType(_lit));
                    i += _hCounter + 1;                    
                } else {
                    throw new Exception("スコアの解析に失敗しました");
                }

                _type = GetType(_lit);
                _relLength += GetRelLength(_type);

                Tokens.Add(new Token(_type, ToActualFrameLength(_relLength)));
            }
        }

        private double GetRelLength(NoteType type) {
            double _rel = 0;
            switch (type) {
                case NoteType.SHIBU_SEI:
                    _rel = 1; break;
                case NoteType.SHIBU_FU:
                    _rel = 1; break;
                case NoteType.HACHIBU_SEI:
                    _rel = 0.5; break;
                case NoteType.HACHIBU_FU:
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
                    _type = NoteType.SHIBU_SEI; break;
                case 'b':
                    _type = NoteType.SHIBU_FU; break;
                case 'q':
                    _type = NoteType.HACHIBU_SEI; break;
                case 'p':
                    _type = NoteType.HACHIBU_FU; break;
                default:
                    _type = NoteType.ILLEGAL; break;
            }
            return _type;
        }

        private int ToActualFrameLength(double relLength) {
            return (int)(relLength);
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
