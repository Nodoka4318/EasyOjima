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

        public Editor() {
            this.X1 = 0;
            this.Y1 = 0;
            this.X2 = 0;
            this.Y2 = 0;

            
            InitializeComponent();
            editorBox.Paint += EditorBox_Paint;
        }

        private void EditorBox_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;
            g.FillEllipse(Brushes.AliceBlue, X1, Y1, 5, 5);
            g.FillEllipse(Brushes.AliceBlue, X2, Y2, 5, 5);
        }

        private void editorBox_Click(object sender, EventArgs e) {
            // none
        }
    }
}
