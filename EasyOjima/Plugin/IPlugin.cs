using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Plugin {
    public interface IPlugin {
        /// <summary>
        /// プラグインの名前です
        /// </summary>
        string Name { get; }

        /// <summary>
        /// プラグインが呼び出された時の処理です
        /// </summary>
        void Run();

        /// <summary>
        /// ホスト
        /// </summary>
        PluginHost Host { get; set; }
    }
}
