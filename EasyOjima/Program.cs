using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using EasyOjima.Forms;
using EasyOjima.Utils;
using EasyOjima.Enums;

namespace EasyOjima {
    internal static class Program {
        public static MainView mainView = new MainView();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            foreach (string path in Loc.Locs) {
                if (!Directory.Exists(path)) {
                    FileUtil.CreateDirectory(path);
                }
            }
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mainView);
        }
    }
}
