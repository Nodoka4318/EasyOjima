using EasyOjima.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyOjima.Plugin {
    //参考: https://codezine.jp/article/detail/1
    public class PluginInfo {
        private string location;
        private string className;
        public string Location => this.location;
        public string ClassName => this.className;

        public PluginInfo(string location, string className) {
            this.location = location;
            this.className = className;
        }

        public static PluginInfo[] FindPlugins() {
            System.Collections.ArrayList plugins = new System.Collections.ArrayList();
            string ipluginName = typeof(IPlugin).FullName;
            var folder = Loc.PLUGINS;

            if (!Directory.Exists(folder))
                return new PluginInfo[] { };

            string[] dlls = Directory.GetFiles(folder, "*.dll");

            foreach (string dll in dlls) {
                try {
                    Assembly asm = Assembly.LoadFrom(dll);
                    foreach (Type t in asm.GetTypes()) {
                        if (t.IsClass && t.IsPublic && !t.IsAbstract && t.GetInterface(ipluginName) != null) {
                            plugins.Add(new PluginInfo(dll, t.FullName));
                        }
                    }
                } catch {
                }
            }

            return (PluginInfo[])plugins.ToArray(typeof(PluginInfo));
        }

        public IPlugin CreateInstance() {
            try {
                Assembly asm = Assembly.LoadFrom(this.Location);
                var plugin = (IPlugin)asm.CreateInstance(this.ClassName);
                plugin.Host = new PluginHost();
                return plugin;
            } catch {
                return null;
            }
        }

        /// <summary>
        /// 特定の属性を持ったメソッドを実行しちゃいます
        /// </summary>
        /// <param name="att">属性</param>
        public static void InvokeEvent(string attName, IPlugin[] plugins) {
            //var plugins = Program.mainView.plugins; なぜか動かん
            foreach (var p in plugins) {
                var mi = p.GetType().GetMethods()
                    .Where(m => m.CustomAttributes.ToString() == attName)
                    .ToList();
                if (mi != null) {
                    foreach (var m in mi) {
                        WorkBackground(() => {
                            new Thread(new ThreadStart(() => {
                                m.Invoke(p, null);
                            })).Start();
                            return Task.CompletedTask;
                        });
                    }
                }
            }
        }

        private static async void WorkBackground(Func<Task> func) {
            await func();
        }
    }
}
