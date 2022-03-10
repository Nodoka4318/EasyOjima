using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Plugin {
    public interface IPlugin {
        string Name { get; }
        void Run();
        PluginHost Host { get; set; }
    }
}
