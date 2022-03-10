using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Plugin {
    public interface IPlugin {
        string Name { get; }
        void Run();
        PluginHost host { get; set; }
    }
}
