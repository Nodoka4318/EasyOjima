using EasyOjima.Enums;
using EasyOjima.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        /// 特定の属性を持ったメソッドを別スレッドで実行しちゃいます
        /// </summary>
        /// <param name="attType">属性の型</param>
        public static void InvokeEventAsync(Type attType, IPlugin[] plugins) {
            if (plugins == null)
                return;
            //var plugins = Program.mainView.plugins; なぜか動かん
            foreach (var p in plugins) {
                var mi = p.GetType().GetMethods()
                    .Where(m => {
                        var atts = m.CustomAttributes;
                        //Type→MethodInfo→CustomAttributeData→Type… もうちょい省略できそう
                        return atts.Select(a => a.AttributeType).Contains(attType);
                        })
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

        /// <summary>
        /// 特定の属性を持ったメソッドを引数付きで別スレッドで実行しちゃいます
        /// </summary>
        /// <param name="attType">属性の型</param>
        public static void InvokeEventAsync(Type attType, object[] args, IPlugin[] plugins) {
            if (plugins == null)
                return;
            foreach (var p in plugins) {
                var mi = p.GetType().GetMethods()
                    .Where(m => {
                        var atts = m.CustomAttributes;
                        return atts.Select(a => a.AttributeType).Contains(attType);
                    })
                    .ToList();
                if (mi != null) {
                    foreach (var m in mi) {
                        WorkBackground(() => {
                            new Thread(new ThreadStart(() => {
                                try {
                                    m.Invoke(p, args);
                                } catch (Exception ex) {
                                    MessageUtil.ErrorMessage(ex.Message);
                                }
                            })).Start();
                            return Task.CompletedTask;
                        });
                    }
                }
            }
        }

        /// <summary>
        /// 特定の属性を持ったメソッドを実行しちゃいます
        /// </summary>
        /// <param name="attType">属性の型</param>
        public static void InvokeEvent(Type attType, IPlugin[] plugins) {
            if (plugins == null)
                return;
            foreach (var p in plugins) {
                var mi = p.GetType().GetMethods()
                    .Where(m => {
                        var atts = m.CustomAttributes;
                        return atts.Select(a => a.AttributeType).Contains(attType);
                    })
                    .ToList();
                if (mi != null) {
                    foreach (var m in mi) {
                        m.Invoke(p, null);
                    }
                }
            }
        }

        /// <summary>
        /// 特定の属性を持ったメソッドを引数付きで実行しちゃいます
        /// </summary>
        /// <param name="attType">属性の型</param>
        public static void InvokeEvent(Type attType, object[] args, IPlugin[] plugins) {
            if (plugins == null)
                return;
            foreach (var p in plugins) {
                var mi = p.GetType().GetMethods()
                    .Where(m => {
                        var atts = m.CustomAttributes;
                        return atts.Select(a => a.AttributeType).Contains(attType);
                    })
                    .ToList();
                if (mi != null) {
                    foreach (var m in mi) {
                        try {
                            m.Invoke(p, args);
                        } catch (Exception ex) {
                            MessageUtil.ErrorMessage(ex.Message);
                        }
                    }
                }
            }
        }

        private static async void WorkBackground(Func<Task> func) {
            await func();
        }
    }
}
