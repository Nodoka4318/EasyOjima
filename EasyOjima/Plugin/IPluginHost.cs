using System;
using System.Collections.Generic;
using System.Text;
using EasyOjima.Video;

namespace EasyOjima.Plugin {
    public interface IPluginHost {
        Video.Video Video { get; }

    }
}
