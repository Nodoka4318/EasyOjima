using EasyOjima.Bezier.Extentions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
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

        private bool _isMovingDot1 = false;
        private bool _isMovingDot2 = false;

        //定数
        internal const int DOT_DIAMETER = 30;
        internal const int DOT_RADIUS = 15;

        public Editor() {
            this.X1 = 20;
            this.Y1 = 20;
            this.X2 = 80;
            this.Y2 = 80;

            
            InitializeComponent();
            this.editorBox.Paint += EditorBox_Paint;
            this.editorBox.MouseDown += EditorBox_MouseDown;
            this.editorBox.MouseMove += EditorBox_MouseMove;
            this.editorBox.MouseUp += EditorBox_MouseUp;
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
                editorBox.Refresh();
            }

            if (_isMovingDot2) {
                X2 = e.X.ToRateX();
                Y2 = e.Y.ToRateY();
                editorBox.Refresh();
            }
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
            e.Graphics.DrawLine(
                new Pen(Brushes.DarkCyan, 2),
                new Point(0, this.editorBox.Height),
                new Point(Cx1, Cy1)
                );
            e.Graphics.DrawLine(
                new Pen(Brushes.DarkCyan, 2),
                new Point(Cx2, Cy2),
                new Point(this.editorBox.Width, 0)
                );
        }

        private void editorBox_Click(object sender, EventArgs e) {
            // none
        }

        
    }
}
