using EasyOjima.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamplePlugin {
    public class PluginMain : IPlugin {
        public string Name => "さんぷるぷらぐいん！";
        public string Description => "プラグインのサンプルだよ";
        public string Author => "@Nodoka_Oto_Mad";
        public PluginHost Host { get; set; }

        /// <summary>
        /// プラグインのエントリポイントです
        /// </summary>
        public void Run() {
            MessageBox.Show("プラグインが実行されたよ！！");
            new Form1().ShowDialog(); //WinForms対応
        }

        [OnLoadEvent]
        public void OnLoad() {
            MessageBox.Show("ロードされたよ！");
        }

        [OnUnloadEvent]
        public void OnUnload() {
            MessageBox.Show("アンロードされたよ！");
        }
    }
}
