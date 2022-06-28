using EasyOjima.Bezier.Extensions;
using EasyOjima.UserInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EasyOjima.Bezier {
    public partial class Editor : Form {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public int Cx1 => X1.ToSizeX();
        public int Cx2 => X2.ToSizeX();
        public int Cy1 => Y1.ToSizeY();
        public int Cy2 => Y2.ToSizeY();

        private Point Center => new Point(this.Width / 2, editorBox.Height / 2);
        private string DotCoordsText => $"(x1, y1, x2, y2) = ({X1}, {Y1}, {X2}, {Y2})";
        
        private bool _isMovingDot1 = false;
        private bool _isMovingDot2 = false;
        private Dictionary<string, BezierCurve> _curves;

        //定数
        internal const int DOT_DIAMETER = 30;
        internal const int DOT_RADIUS = 15;
        const string PATH_BEZIERS = @"data\beziers";

        public Editor() {
            this.X1 = 20;
            this.Y1 = 20;
            this.X2 = 80;
            this.Y2 = 80;
            
            InitializeComponent();

            this.dotCoordsBox.Text = this.DotCoordsText;

            this.editorBox.Paint += EditorBox_Paint;
            this.editorBox.MouseDown += EditorBox_MouseDown;
            this.editorBox.MouseMove += EditorBox_MouseMove;
            this.editorBox.MouseUp += EditorBox_MouseUp;

            this.SetCurves();
        }

        private void SetCurves() {
            var files = Directory.GetFiles(PATH_BEZIERS, "*.obz");
            _curves = new Dictionary<string, BezierCurve>();

            this.beziersBox.Items.Clear();
            foreach (var file in files) {
                try {
                    using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read)) {
                        var bf = new BinaryFormatter();
                        object obj = bf.Deserialize(fs);
                        var name = file.Split('\\')[file.Split('\\').Length - 1].Replace(".obz", "");
                        var curve = (BezierCurve)obj;
                        
                        _curves.Add(name, curve);
                        this.beziersBox.Items.Add(name); //TODO: 重複防止
                    }
                    
                } catch { }
            }
        }

        private void SaveCurve() {
            using (var dlg = new InputBox("保存したい名前を入力してください。")) {
                dlg.ShowDialog();
                if (dlg.Result == DialogResult.Cancel)
                    return;

                if (dlg.ResultText == "" || dlg.ResultText.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0) {
                    MessageBox.Show("名前が不正です。\n他の名前を試してください。", "かんたん大島", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var curve = new BezierCurve(X1, Y1, X2, Y2);
                try {
                    if (File.Exists(PATH_BEZIERS + $@"\{dlg.ResultText}.obz")) {
                        var yn = MessageBox.Show("同じ名前の曲線が見つかりました。\n上書きしますか？", "かんたん大島", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (yn == DialogResult.No)
                            return;
                        else
                            File.Delete(PATH_BEZIERS + $@"\{dlg.ResultText}.obz");
                    }

                    using (var fs = new FileStream(PATH_BEZIERS + $@"\{dlg.ResultText}.obz", FileMode.Create, FileAccess.Write)) {
                        var bf = new BinaryFormatter();
                        bf.Serialize(fs, curve);
                    }

                    this.SetCurves();
                } catch (Exception ex) { 
                    throw ex; 
                }
            }
        }

        private void LoadCurve(string name) {
            try {
                using (var fs = new FileStream(PATH_BEZIERS + $@"\{name}.obz", FileMode.Open, FileAccess.Read)) {
                    var bf = new BinaryFormatter();
                    var obj = bf.Deserialize(fs);
                    var curve = (BezierCurve)obj;
                    
                    this.X1 = curve.X1;
                    this.Y1 = curve.Y1;
                    this.X2 = curve.X2;
                    this.Y2 = curve.Y2;

                    editorBox.Refresh();
                    this.dotCoordsBox.Text = this.DotCoordsText;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void EditorBox_MouseUp(object sender, MouseEventArgs e) {
            _isMovingDot1 = false;
            _isMovingDot2 = false;            
        }

        private void EditorBox_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right)
                return;

            if (_isMovingDot1) {
                X1 = e.X.ToRateX();
                Y1 = e.Y.ToRateY();
                KeepXInner();
                editorBox.Refresh();
            }

            if (_isMovingDot2) {
                X2 = e.X.ToRateX();
                Y2 = e.Y.ToRateY();
                KeepXInner();
                editorBox.Refresh();
            }
            this.dotCoordsBox.Text = this.DotCoordsText;
        }

        private void KeepXInner() {
            if (X1 >= 100)
                X1 = 100;
            if (X2 >= 100)
                X2 = 100;
            if (X1 <= 0)
                X1 = 0;
            if (X2 <= 0)
                X2 = 0;
        }

        private void EditorBox_MouseDown(object sender, MouseEventArgs e) {
            if (e.Location.IsOnDot(Cx1, Cy1)) {
                Debug.WriteLine($"dot1: {e.X} {e.Y} / {Cx1} {Cy1} / {X1} {Y1}");
                _isMovingDot1 = true;
            } else if (e.Location.IsOnDot(Cx2, Cy2)) { //else必須
                Debug.WriteLine($"dot2: {e.X} {e.Y} / {Cx2} {Cy2} / {X2} {Y2}");
                _isMovingDot2 = true;
            }
        }

        private void EditorBox_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;
            g.FillEllipse(Brushes.DarkCyan, Cx1 - DOT_RADIUS, Cy1 - DOT_RADIUS, DOT_DIAMETER, DOT_DIAMETER);
            g.FillEllipse(Brushes.DarkCyan, Cx2 - DOT_RADIUS, Cy2 - DOT_RADIUS, DOT_DIAMETER, DOT_DIAMETER);
            g.DrawBezier(
                new Pen(Brushes.DarkBlue, 3),
                new Point(0, this.editorBox.Height),
                new Point(Cx1, Cy1),
                new Point(Cx2, Cy2),
                new Point(this.editorBox.Width, 0)
                );
            g.DrawLine(
                new Pen(Brushes.DarkCyan, 2),
                new Point(0, this.editorBox.Height),
                new Point(Cx1, Cy1)
                );
            g.DrawLine(
                new Pen(Brushes.DarkCyan, 2),
                new Point(Cx2, Cy2),
                new Point(this.editorBox.Width, 0)
                );
        }

        private void editorBox_Click(object sender, EventArgs e) {
            // none
        }

        private void resetButton_Click(object sender, EventArgs e) {
            this.X1 = 20;
            this.Y1 = 20;
            this.X2 = 80;
            this.Y2 = 80;
            editorBox.Refresh();
            this.dotCoordsBox.Text = this.DotCoordsText;
        }

        private void dotCoordsBox_TextChanged(object sender, EventArgs e) {
            var reg = new Regex("[(x1, y1, x2, y2) = (](?<x1>[+-]?[0-9]+$*), (?<y1>[+-]?[0-9]+$*), (?<x2>[+-]?[0-9]+$*), (?<y2>[+-]?[0-9]+$*)[)]");
            var match = reg.Match(dotCoordsBox.Text);

            try {
                this.X1 = int.Parse(match.Groups["x1"].Value);
                this.Y1 = int.Parse(match.Groups["y1"].Value);
                this.X2 = int.Parse(match.Groups["x2"].Value);
                this.Y2 = int.Parse(match.Groups["y2"].Value);

                KeepXInner();
                this.editorBox.Refresh();
            } catch { }
        }

        private void saveCurveButton_Click(object sender, EventArgs e) {
            SaveCurve();
        }

        private void setCurveButton_Click(object sender, EventArgs e) {
            var name = this.beziersBox.Text;
            if (!File.Exists(PATH_BEZIERS + $@"\{name}.obz")) {
                MessageBox.Show("指定した曲線が見つかりませんでした。", "かんたん大島", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadCurve(name);
        }
    }
}
