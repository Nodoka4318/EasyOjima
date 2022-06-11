using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EasyOjima.Bezier {
    public partial class Editor : Form {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }

        private Point Center => new Point(this.Width / 2, editorBox.Height / 2);

        //定数
        const int DOTSIZE = 30;

        public Editor() {
            this.X1 = 0;
            this.Y1 = 0;
            this.X2 = 0;
            this.Y2 = 0;

            
            InitializeComponent();
            this.editorBox.Paint += EditorBox_Paint;
            this.editorBox.MouseDown += EditorBox_MouseDown;
            this.editorBox.MouseMove += EditorBox_MouseMove;
            this.editorBox.MouseUp += EditorBox_MouseUp;
        }

        private void EditorBox_MouseUp(object sender, MouseEventArgs e) {
            throw new NotImplementedException();
        }

        private void EditorBox_MouseMove(object sender, MouseEventArgs e) {
            throw new NotImplementedException();
        }

        private void EditorBox_MouseDown(object sender, MouseEventArgs e) {
            throw new NotImplementedException();
        }

        private void EditorBox_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;
            g.FillEllipse(Brushes.DarkCyan, X1, Y1, DOTSIZE, DOTSIZE);
            g.FillEllipse(Brushes.DarkCyan, X2, Y2, DOTSIZE, DOTSIZE);
        }

        private void editorBox_Click(object sender, EventArgs e) {
            // none
        }
    }
}
