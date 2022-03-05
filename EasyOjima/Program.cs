using System;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Linq;
using EasyOjima.Forms;
using EasyOjima.Utils;
using EasyOjima.Enums;
using System.Diagnostics;

namespace EasyOjima {
    internal static class Program {
        public const string VERSION = "1.0.0";
        public static MainView mainView = new MainView();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            foreach (string path in Loc.Locs) {
                if (!Directory.Exists(path)) {
                    FileUtil.CreateDirectory(path);
                }
            }

            if (!File.Exists(Loc.PREFERENCE)) {
                FirstLaunch();
            }

            CheckUpdate();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mainView);
        }

        static void FirstLaunch() {
            string _write = "";
            var _up = MessageUtil.InfoYesNo("起動時にアップデートを確認しますか？");
            if (_up == DialogResult.Yes) {
                _write += "checkupdate\n";
            }
            FileUtil.CreateTextFile(Loc.PREFERENCE, _write);
        }

        static void CheckUpdate() {
            var isCheck = FileUtil.ReadTextFile(Loc.PREFERENCE)
                .Replace("\r\n", "\n")
                .Split(new[] { '\n', '\r' })
                .ToList()
                .Contains("checkupdate");

            if (!isCheck)
                return;

            string _remote = @"https://raw.githubusercontent.com/Nodoka4318/EasyOjima/master/version.txt";
            try {
                var web = new WebClient();
                var st = web.OpenRead(_remote);
                var sr = new StreamReader(st);
                var _latest = sr.ReadToEnd().Replace("\r\n", "\n").Split(new[] { '\n', '\r' })[0];
                int _current = int.Parse(VERSION.Replace(".", "").Replace("beta-", ""));

                if (int.Parse(_latest.Replace(".", "").Replace("beta-", "")) > _current) {
                    var _dlg = MessageUtil.InfoYesNo($"現在のバージョン: {VERSION}\n最新版: {_latest}\n\nダウンロードページを開きますか？");
                    if (_dlg == DialogResult.Yes) {
                        OpenUrl(@"https://github.com/Nodoka4318/EasyOjima/releases");
                    }
                }
            } catch { /*ネットにつながってないとき*/ }
        }

        static Process OpenUrl(string url) {
            ProcessStartInfo pi = new ProcessStartInfo() {
                FileName = url,
                UseShellExecute = true,
            };
            return Process.Start(pi);
        }
    }
}
