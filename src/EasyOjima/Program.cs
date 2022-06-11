using System;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Linq;
using EasyOjima.Forms;
using EasyOjima.Utils;
using EasyOjima.Enums;
using EasyOjima.Bezier;
using System.Diagnostics;

namespace EasyOjima {
    internal static class Program {
        public const string VERSION = "2.0.0��";
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
                CreateId();
            }

            CheckUpdate();
            Notify();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mainView);
        }

        static void FirstLaunch() {
            string _write = "askwhenclosing\n";
            var _up = MessageUtil.InfoYesNo("�N�����ɃA�b�v�f�[�g���m�F���܂����H");
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
                int _current = int.Parse(VERSION.Replace(".", "").Replace("��", "").Replace("��", ""));

                if (int.Parse(_latest[0].Replace(".", "").Replace("��", "").Replace("��", "")) > _current) {
                    var _updatemsg = string.Join("\n", _latest[1].Split("<br>").Select(s => "*" + s));
                    var _dlg = MessageUtil.InfoYesNo($"���݂̃o�[�W����: {VERSION}\n�ŐV��: {_latest[0]}\n\n�X�V���:\n{_updatemsg}\n\n�_�E�����[�h�y�[�W���J���܂����H");
                    if (_dlg == DialogResult.Yes) {
                        OpenUrl(@"https://github.com/Nodoka4318/EasyOjima/releases");
                    }
                } else if (VERSION.Contains('��') || VERSION.Contains('��')) {
                    if (int.Parse(_latest[0].Replace(".", "").Replace("��", "").Replace("��", "")) == _current) {
                        var _updatemsg = string.Join("\n", _latest[1].Split("<br>").Select(s => "*" + s));
                        var _dlg = MessageUtil.InfoYesNo($"���݂̃o�[�W����: {VERSION}\n�ŐV��: {_latest[0]}\n\n�X�V���:\n{_updatemsg}\n\n�_�E�����[�h�y�[�W���J���܂����H");
                        if (_dlg == DialogResult.Yes) {
                            OpenUrl(@"https://github.com/Nodoka4318/EasyOjima/releases");
                        }
                    }
                }

                web.Dispose();
            } catch (WebException) { /*�l�b�g�ɂȂ����ĂȂ��Ƃ�*/ }
        }

        static void CreateId() {
            Ident ident = new Ident() {
                Id = Guid.NewGuid()
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

        static void Notify() {
            if (!File.Exists(Loc.NOTIFYHISTORY))
                FileUtil.CreateTextFile(Loc.NOTIFYHISTORY);

            string remote = @"https://raw.githubusercontent.com/Nodoka4318/Nodoka4318/main/data/EasyOjimaNotify.txt";
            try {
                var web = new WebClient();
                var st = web.OpenRead(remote);
                var sr = new StreamReader(st);
                var lines = sr.ReadToEnd().Replace("\r\n", "\n").Split(new[] { '\n', '\r' });

                var hsr = new StreamReader(Loc.NOTIFYHISTORY);
                var history = hsr.ReadToEnd().Replace("\r\n", "\n").Split(new[] { '\n', '\r' });

                string notification = "";
                string historyToWrite = "";
                for (int i = 0; i < lines.Length; i++) {
                    var line = lines[i];
                    var words = line.Split(' ');

                    if (words[0] == "ID") {
                        if (!history.Contains(words[1])) {
                            var msg = string.Join("\n", lines[i + 1].Split("<br>").Select(s => " - " + s));
                            notification += $"{words[2]}\n{msg}\n\n";

                            historyToWrite += $"{words[1]}\n";
                        }
                    }
                }

                web.Dispose();
                hsr.Dispose();
                sr.Dispose();

                if (notification != "") {
                    File.AppendAllText(Loc.NOTIFYHISTORY, historyToWrite);
                    MessageUtil.InfoMessage($"**���m�点**\n\n{notification}");
                }
            } catch (WebException) { /*�l�b�g�ɂȂ����ĂȂ��Ƃ�*/ } 
        }
    }
}