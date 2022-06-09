using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EasyOjima.Enums {
    public enum Mode {
        NORMAL, //通常モード
        KAKUKAKU,　//瞬間移動モード
        UNKNOWN //未知
    }

    //参照用
    public static class ModeExtention {
        private static Dictionary<Mode, string> modes = new Dictionary<Mode, string>() {
            { Mode.NORMAL, "通常" },
            { Mode.KAKUKAKU, "瞬間移動" },
            { Mode.UNKNOWN, "unknown" }
        };

        public static string GetName(this Mode mode) {
            return modes[mode];
        }

        public static Mode GetModeFromName(this string name) {
            return modes.Values.Contains(name) ? modes.ToList().Find(m => m.Value == name).Key : Mode.UNKNOWN;
        }
    }
}
