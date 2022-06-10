using EasyOjima.Plugin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamplePlugin_WatermarkPlugin {
    public class PluginMain : IPlugin {
        public string Name => "ウォーターマークぷらぐいん！";
        public string Description => "動画にウォーターマークを入れるプラグインです。";
        public string Author => "Nodoka";
        public PluginHost Host { get; set; }

        public bool isEnabled = false;

        public void Run() {
            isEnabled = MessageBox.Show("有効化する？", "さんぷる", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;
        }

        [OnPaintEvent]
        public void OnPaint(object sender, PaintEventArgs e) {
            if (isEnabled) {
                Graphics g = e.Graphics;
                g.DrawRectangle(new Pen(Brushes.Aqua), new Rectangle(50, 50, 50, 50));
            }
        }
    }
}
