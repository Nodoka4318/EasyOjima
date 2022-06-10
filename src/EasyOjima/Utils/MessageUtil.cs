using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EasyOjima.Utils {
    internal class MessageUtil {
        public static void ErrorMessage(string msg) {
            MessageBox.Show($"エラーが発生しました。\n\nInfo: {msg}", "かんたん大島", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void WarnMessage(string msg) {
            MessageBox.Show(msg, "かんたん大島", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void InfoMessage(string msg) {
            MessageBox.Show(msg, "かんたん大島", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult InfoYesNo(string msg) {
            var _dlg = MessageBox.Show(msg, "かんたん大島", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            return _dlg;
        }
    }
}
