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
        /// プラグインの作者です
        /// </summary>
        string Author { get; }

        /// <summary>
        /// プラグインの説明です
        /// </summary>
        string Description { get; }

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
