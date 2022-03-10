using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Enums {
    //これenumじゃないけど許して
    internal class Loc {
        //フォルダ
        public static readonly string SCORES = @"scores";
        public static readonly string DATA = @"data";
        public static readonly string EXPORT_CACHE = @"data\export";
        public static readonly string LOCALAPPDATA = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static readonly string APPCONF = $@"{LOCALAPPDATA}\EasyOjima";
        public static readonly string PLUGINS = @"plugins";
        //ファイル
        public static readonly string PREFERENCE = $@"{APPCONF}\conf";
        public static readonly string IDENT = $@"{APPCONF}\hw";

        public static List<string> Locs {
            get {
                var _temp = new List<string>();
                _temp.Add(@SCORES);
                _temp.Add(@DATA);
                _temp.Add(@EXPORT_CACHE);
                _temp.Add(@APPCONF);
                _temp.Add(@PLUGINS);
                return _temp;
            }
        }

        public static List<string> Files {
            get {
                var _temp = new List<string>();
                _temp.Add(PREFERENCE);
                _temp.Add(IDENT);
                return _temp;
            }
        }
    }
}
