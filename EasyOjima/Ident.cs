using EasyOjima.Enums;
using EasyOjima.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace EasyOjima {
    [Serializable]
    internal class Ident {
        public Guid Id { get; set; }
        public Ident() { }

        public void Write() {
            try {
                using (var fs = new FileStream(Loc.IDENT, FileMode.Create, FileAccess.Write)) {
                    var bf = new BinaryFormatter();
                    bf.Serialize(fs, this);
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        public static Ident Read() {
            try {
                using (var fs = new FileStream(Loc.IDENT, FileMode.Open, FileAccess.Read)) {
                    var bf = new BinaryFormatter();
                    object obj = bf.Deserialize(fs);
                    return (Ident)obj;
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                return new Ident() { Id = new Guid("0000000000000000000000000000000") };
            }
        }
    }
}
