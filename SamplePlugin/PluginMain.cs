using EasyOjima.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamplePlugin {
    public class PluginMain : IPlugin {
        public string Name => "����Ղ�Ղ炮����I";
        public string Description => "�v���O�C���̃T���v������";
        public string Author => "@Nodoka_Oto_Mad";
        public PluginHost Host { get; set; }

        /// <summary>
        /// �v���O�C���̃G���g���|�C���g�ł�
        /// </summary>
        public void Run() {
            MessageBox.Show("�v���O�C�������s���ꂽ��I�I");
            new Form1().ShowDialog(); //WinForms�Ή�
        }

        [OnLoadEvent]
        public void OnLoad() {
            MessageBox.Show("���[�h���ꂽ��I");
        }

        [OnUnloadEvent]
        public void OnUnload() {
            MessageBox.Show("�A�����[�h���ꂽ��I");
        }
    }
}
