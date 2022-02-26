using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EasyOjima.Utils {
    internal class MessageUtil {
        public static void ErrorMessage(string msg) {
            MessageBox.Show($"エラーが発生しました。\n\nErrorMessage: {msg}", "かんたん大島", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
