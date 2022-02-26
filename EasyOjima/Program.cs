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
            if (!Directory.Exists(Loc.SCORES)) {
                FileUtil.CreateDirectory(Loc.SCORES);
            }
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mainView);
        }
    }
}
