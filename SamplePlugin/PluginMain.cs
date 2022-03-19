using EasyOjima.Plugin;
using EasyOjima.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamplePlugin {
    public class PluginMain : IPlugin {
        public string Name => "����Ղ�Ղ炮����I";
        public string Description => "�v���O�C���̃T���v������B\n������O���[�X�P�[�������܂��B";
        public string Author => "Nodoka";
        public PluginHost Host { get; set; }
        public Form1 Dialog { get; set; }

        public PluginMain() {
            Dialog = new Form1();
        }

        /// <summary>
        /// �v���O�C���̃G���g���|�C���g�ł�
        /// </summary>
        public void Run() {
            MessageBox.Show("�v���O�C�������s���ꂽ��I�I");
           
            Dialog.ShowDialog(); //WinForms�Ή�

            if (Dialog.isLaunched) {
                if (Host.Video == null) {
                    MessageBox.Show("���悪�ǂݍ��܂�Ă��܂���");
                    Dialog.isLaunched = false;
                    return;
                }

                LoadingDialog dlg = new LoadingDialog("������", Host.Video.FrameSize);
                dlg.Show();
                int curFrame = 0;

                Host.EditVideo(b => {
                    dlg.UpdateDialog($"������ ({curFrame}/{Host.Video.FrameSize})", curFrame);
                    curFrame++;
                    return CreateGrayscaleImage(b);
                });
                Dialog.isLaunched = false;
                dlg.Dispose();
            }
        }

        [OnLoadEvent]
        public void OnLoad() {
            MessageBox.Show("���[�h���ꂽ��I");
        }

        [OnUnloadEvent]
        public void OnUnload() {
            MessageBox.Show("�A�����[�h���ꂽ��I");
        }

        [OnLoadVideoEvent] //���惍�[�h���Ɏ��s����܂�
        public void OnOnLoadVideo() { 
            if (Dialog.RunWhenVideoLoaded) {
                LoadingDialog dlg = new LoadingDialog("������", Host.Video.FrameSize);
                dlg.Show();
                int curFrame = 0;
                
                Host.EditVideo(b => {
                    dlg.UpdateDialog($"������ ({curFrame}/{Host.Video.FrameSize})", curFrame);
                    curFrame++;
                    return CreateGrayscaleImage(b);
                });
                dlg.Dispose();
            }
        }

        // https://xn--dobon-pd4d5e.net/vb/dotnet/graphics/grayscale.html �����p
        public static Bitmap CreateGrayscaleImage(Bitmap img) {
            //�O���[�X�P�[���̕`���ƂȂ�Image�I�u�W�F�N�g���쐬
            Bitmap newImg = new Bitmap(img.Width, img.Height);
            //newImg��Graphics�I�u�W�F�N�g���擾
            Graphics g = Graphics.FromImage(newImg);

            //ColorMatrix�I�u�W�F�N�g�̍쐬
            //�O���[�X�P�[���ɕϊ����邽�߂̍s����w�肷��
            System.Drawing.Imaging.ColorMatrix cm =
                new System.Drawing.Imaging.ColorMatrix(
                    new float[][]{
                new float[]{0.299f, 0.299f, 0.299f, 0 ,0},
                new float[]{0.587f, 0.587f, 0.587f, 0, 0},
                new float[]{0.114f, 0.114f, 0.114f, 0, 0},
                new float[]{0, 0, 0, 1, 0},
                new float[]{0, 0, 0, 0, 1}
                    });
            //ImageAttributes�I�u�W�F�N�g�̍쐬
            System.Drawing.Imaging.ImageAttributes ia =
                new System.Drawing.Imaging.ImageAttributes();
            //ColorMatrix��ݒ肷��
            ia.SetColorMatrix(cm);

            //ImageAttributes���g�p���ăO���[�X�P�[����`��
            g.DrawImage(img,
                new Rectangle(0, 0, img.Width, img.Height),
                0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);

            //���\�[�X���������
            g.Dispose();

            return newImg;
        }
    }
}
