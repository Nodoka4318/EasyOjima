using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOjima.Score.Processing {
    public class OptionManager {
        public List<Option> Options { get; private set; }
        public Option Selected { get; private set; }
        public FrameProcessor Processor { get; private set; }

        public OptionManager(FrameProcessor processor) {
            this.Processor = processor;
            this.Options = new List<Option>();

            //options
            Options.Add(new KakukakuOption(processor));
        }

        public void Set(string name) {
            foreach (Option option in Options) {
                if (option.Name == name) {
                    this.Selected = option;
                    return;
                }
            }
        }

        public void Process(ref Video.Video video) {
            this.Selected.OptionProcess(ref video);
        }
    }
}
