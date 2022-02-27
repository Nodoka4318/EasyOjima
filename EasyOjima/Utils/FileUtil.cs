using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace EasyOjima.Utils {
    internal class FileUtil {
        public static void CreateTextFile(string path) {
            try {
                var sw = File.CreateText(path);
                sw.Close();
            } catch (Exception ex) {
                MessageUtil.ErrorMessage(ex.Message);
            }
        }

        public static void CreateDirectory(string path) {
            try {
                Directory.CreateDirectory(path);
            } catch (Exception ex) {
                MessageUtil.ErrorMessage(ex.Message);
            }
        }

        public static string ReadTextFile(string path) {
            try {
                return File.ReadAllText(path);
            } catch (Exception ex) {
                MessageUtil.ErrorMessage(ex.Message);
                return null;
            }
        }
    }
}
