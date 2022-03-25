using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EasyOjima.Score {
    public class Score {
        public List<char> Source { get; private set; }
        public int Length { get; private set; }
        public int CurrentIndex { get; set; } = 0;
        public int Bpm { get; private set; }

        public Score(string source, int bpm) {
            bool isComment = false;
            var _tempLits = new List<char>();
            //コメントアウト飛ばし読み
            for (int i = 0; i < source.Length; i++) {
                var c = source[i];
                if (isComment) {
                    if (c == ')')
                        isComment = false;
                    else if (c == '(')
                        throw new Exception($"コメント中に丸括弧「()」を含めることはできません。\nindex: {i}");
                    continue;
                }

                if (c == '(') {
                    isComment = true;
                    continue;
                } else if (c == ')') {
                    throw new Exception($"コメントの始まり「(」がありません。\nindex: {i}");
                }

                _tempLits.Add(c);
            }

            if (isComment)
                throw new Exception($"コメントの終わり「)」がありません。\nindex: {source.Length - 1}");

            this.Source = _tempLits.Where(
                c => AllowedToken.Contains(c)
                ).ToList();
            this.Length = this.Source.Count;
            this.Bpm = bpm;
        }

        public char GetCurrentChar() {
            if (CurrentIndex > Length)
                return new char();
            return Source[CurrentIndex];
        }

        public char GetChar(int index) {
            if (index > Length || index < 0)
                return new char();
            return Source[index];
        }

        public static List<char> AllowedToken { 
            get {
                var _temp = new List<char>();
                _temp.Add('d'); //四分音符
                _temp.Add('b'); //四分音符逆
                _temp.Add('q'); //八分音符
                _temp.Add('p'); //八分音符逆
                _temp.Add('-'); //伸ばし
                _temp.Add('~'); //休符
                return _temp;
            } 
        }
    }
}
