using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Enums {
    //これenumじゃないけど許して
    internal class Loc {
        public static readonly string SCORES = @"scores";
        public static readonly string DATA = @"data";
        public static readonly string EXPORT_CACHE = @"data\export";

        public static List<string> Locs {
            get {
                var _temp = new List<string>();
                _temp.Add(@SCORES);
                _temp.Add(@DATA);
                _temp.Add(@EXPORT_CACHE);
                return _temp;
            }
        }
    }
}
