using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EasyOjima.Utils;
using EasyOjima.Enums;

namespace EasyOjima.Forms {
    //その場しのぎの設定
    //TODO: 設定の一般化
    public partial class Preference : Form {
        public static List<string> Settings { 
            get {
                return FileUtil.ReadTextFile(Loc.PREFERENCE)
                .Replace("\r\n", "\n")
                .Split(new[] { '\n', '\r' })
                .ToList();
            } 
        }

        public Preference() {
            InitializeComponent();
        }

        private void Preference_Load(object sender, EventArgs e) {
            foreach (var s in Settings) {
                switch (s) {
                    case "checkupdate":
                        this.checkUpdateBox.Checked = true;
                        break;
                    case "askwhenclosing":
                        this.askWhenCloseBox.Checked = true;
                        break;
                 }
            }
        }

        private void confirmButton_Click(object sender, EventArgs e) {
            string _write = "";
            if (checkUpdateBox.Checked) {
                _write += "checkupdate\n";
            }
            if (askWhenCloseBox.Checked) {
                _write += "askwhenclosing\n";
            }
            FileUtil.CreateTextFile(Loc.PREFERENCE, _write);
            this.Dispose();
        }
    }
}
