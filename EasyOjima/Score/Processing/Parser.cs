using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using EasyOjima.Enums;

namespace EasyOjima.Score.Processing {
    public class Parser {
        public Score Score { get; private set; }
        public List<Token> Tokens { get; private set; }
        public double Fps { get; private set; }

        public Parser(Score score, double fps) {
            this.Score = score;
            this.Fps = fps;
            this.Tokens = new List<Token>();

            this.ParseNotes();
            if (correctingInterval < 0) {
                this.Correct();
            }
            //Debug.WriteLine("parserはいったよ");
        }

        private double correctingInterval = -1d; //ズレ補正の間隔

        private void ParseNotes() {
            double _beatCounter = 0; //ズレ補正用、4小節ごとに更新
            int _lastCorrectedFrame = 0;

            for (int i = 0; i < Score.Length; i++) {
                //Debug.WriteLine("a");
                var _lit = Score.GetChar(i);
                double _relLength = 0;
                NoteType _type;

                //休符
                if (_lit == '_' || _lit == 's' || _lit == 'r') {
                    switch (_lit) {
                        case '_':
                            _relLength = 4; break;
                        case 's':
                            _relLength = 1; break;
                        case 'r':
                            _relLength = 0.5; break;
                    }
                    var reqLength = (int)Math.Round(ToActualFrameLength(_relLength));
                    _type = NoteType.YASUMI;
                    Tokens.Add(new Token(_type, reqLength, _relLength));
                    if (i != Score.Length - 1 && Score.GetChar(i + 1) == '-')
                        throw new Exception("楽譜の解析に失敗しました。\n休符を伸ばすことはできません。");
                    continue;
                }

                //ハイフン先読み
                if (_lit != '-' && i != Score.Length - 1) {
                    //Debug.WriteLine("b");
                    char _temp = Score.GetChar(i + 1);
                    var _hCounter = 0;
                    if (_temp == '-') {
                        _hCounter++;
                        while (_temp == '-' && i + _hCounter + 1 < Score.Length) {
                            //Debug.WriteLine("c");
                            _temp = Score.GetChar(i + _hCounter + 1);
                            if (_temp == '-')
                                _hCounter++;
                        }

                        _relLength += _hCounter * GetRelLength(_lit);
                        i += _hCounter;
                    }
                } else {
                    if (_lit == '-') {
                        throw new Exception($"楽譜の解析に失敗しました\nindex: {i}");
                    }
                }
                               
                _type = GetType(_lit);
                _relLength += GetRelLength(_lit);
                var _reqLength = (int)Math.Round(ToActualFrameLength(_relLength));

                Tokens.Add(new Token(_type, _reqLength, _relLength));

                _beatCounter += _relLength;

                if (_beatCounter ==  correctingInterval && _lastCorrectedFrame < Tokens.Count - 1) { //ズレ補正、バグ起きそう
                    this.Correct(_lastCorrectedFrame, Tokens.Count - 1);
                    _beatCounter = 0;
                    _lastCorrectedFrame = i + 1;
                }
            }
            
            if (correctingInterval > 0 && _lastCorrectedFrame < Tokens.Count - 1) {
                this.Correct(_lastCorrectedFrame, Tokens.Count - 1);
            }
            
        }

        /// <summary>
        /// フレームのズレ補正
        /// 結局ランダムだよ、頭悪い
        /// </summary>
        //TODO: ズレ補正改良
        private void Correct() {
            if (Tokens == null)
                return;

            var targetLength = Math.Ceiling(ToActualFrameLength(Tokens.Select(c => c.BeatLength).Sum())); //目標のおおきさ, 大は小を兼ねる((
            var addList = new List<int>();
            while (GetActualLengthSum(0, Tokens.Count - 1) != targetLength) {
                var index = RandomInt(0, Tokens.Count - 1);
                if (addList.Contains(index))
                    continue;

                if (GetActualLengthSum(0, Tokens.Count - 1) < targetLength) {
                    Tokens[index].ActualFrameLength += 1;
                } else {
                    Tokens[index].ActualFrameLength -= 1;
                }

                addList.Add(index);
                if (addList.Count == Tokens.Count)
                    addList = new List<int>();
                Debug.WriteLine(GetActualLengthSum(0, Tokens.Count - 1));
            }
        }

        
        private void Correct(int fr0, int fr1) {
            if (Tokens == null)
                return;
            Debug.WriteLine($"correcting between {fr0}, {fr1}");

            var targetLength = Math.Ceiling(ToActualFrameLength(correctingInterval));
            var addList = new List<int>();
            while (GetActualLengthSum(fr0, fr1) != targetLength) {
                var index = RandomInt(fr0, fr1);
                if (addList.Contains(index))
                    continue;

                if (GetActualLengthSum(fr0, fr1) < targetLength) {                    
                    Tokens[index].ActualFrameLength += 1;
                } else {
                    Tokens[index].ActualFrameLength -= 1;                    
                }

                addList.Add(index);
                if (addList.Count == fr1 - fr0)
                    addList = new List<int>();
                Debug.WriteLine(GetActualLengthSum(fr0, fr1));
            }
        }

        /// <summary>
        /// 指定した範囲の、計算されたフレーム長の合計
        /// </summary>
        private double GetActualLengthSum(int fr0, int fr1) {
            double ret = 0;
            for (int i = fr0; i <= fr1; i++) {
                ret += Tokens[i].ActualFrameLength;
            }
            return ret;
        }

        private static int RandomInt(int min, int max) {
            var r = new Random();
            return r.Next(min, max + 1);
        }

        private double GetRelLength(char lit) {
            double _rel;
            switch (lit) {
                case 'o':
                case 'c':
                    _rel = 4; break;
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
                case 'o':
                    _type = NoteType.SEI; break;
                case 'b':
                case 'p':
                case 'c':
                    _type = NoteType.FU; break;
                default:
                    _type = NoteType.ILLEGAL; break;
            }
            return _type;
        }

        //TODO: このせいでちょっとズレるんだよな
        private double ToActualFrameLength(double relLength) {
            double _framePerBeat = Fps * 60 / Score.Bpm;
            return _framePerBeat * relLength;
        }
    }
}
