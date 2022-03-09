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
        public const string VERSION = "-1";
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

            if (!File.Exists(Loc.IDENT)) {
                CreateID();
            }

            CheckUpdate();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mainView);
        }

        static void FirstLaunch() {
            string _write = "askwhenclosing\n";
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
                var _latest = sr.ReadToEnd().Replace("\r\n", "\n").Split(new[] { '\n', '\r' });
                int _current = int.Parse(VERSION.Replace(".", "").Replace("β", "").Replace("α", ""));

                if (int.Parse(_latest[0].Replace(".", "").Replace("β", "").Replace("α", "")) > _current) {
                    var _updatemsg = string.Join("\n", _latest[1].Split("<br>").Select(s => "*" + s));
                    var _dlg = MessageUtil.InfoYesNo($"現在のバージョン: {VERSION}\n最新版: {_latest[0]}\n\n更新情報:\n{_updatemsg}\n\nダウンロードページを開きますか？");
                    if (_dlg == DialogResult.Yes) {
                        OpenUrl(@"https://github.com/Nodoka4318/EasyOjima/releases");
                    }
                } else if (VERSION.Contains('β') || VERSION.Contains('α')) {
                    if (int.Parse(_latest[0].Replace(".", "").Replace("β", "").Replace("α", "")) == _current) {
                        var _updatemsg = string.Join("\n", _latest[1].Split("<br>").Select(s => "*" + s));
                        var _dlg = MessageUtil.InfoYesNo($"現在のバージョン: {VERSION}\n最新版: {_latest[0]}\n\n更新情報:\n{_updatemsg}\n\nダウンロードページを開きますか？");
                        if (_dlg == DialogResult.Yes) {
                            OpenUrl(@"https://github.com/Nodoka4318/EasyOjima/releases");
                        }
                    }
                }
            } catch { /*ネットにつながってないとき*/ }
        }

        static void CreateID() {
            Ident ident = new Ident() {
                Id = Guid.NewGuid().ToString()
            };
            ident.Write();
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
