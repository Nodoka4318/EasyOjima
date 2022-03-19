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
        public string Name => "さんぷるぷらぐいん！";
        public string Description => "プラグインのサンプルだよ。\n動画をグレースケール化します。";
        public string Author => "Nodoka";
        public PluginHost Host { get; set; }
        public Form1 Dialog { get; set; }

        public PluginMain() {
            Dialog = new Form1();
        }

        /// <summary>
        /// プラグインのエントリポイントです
        /// </summary>
        public void Run() {
            MessageBox.Show("プラグインが実行されたよ！！");
           
            Dialog.ShowDialog(); //WinForms対応

            if (Dialog.isLaunched) {
                if (Host.Video == null) {
                    MessageBox.Show("動画が読み込まれていません");
                    Dialog.isLaunched = false;
                    return;
                }

                LoadingDialog dlg = new LoadingDialog("処理中", Host.Video.FrameSize);
                dlg.Show();
                int curFrame = 0;

                Host.EditVideo(b => {
                    dlg.UpdateDialog($"処理中 ({curFrame}/{Host.Video.FrameSize})", curFrame);
                    curFrame++;
                    return CreateGrayscaleImage(b);
                });
                Dialog.isLaunched = false;
                dlg.Dispose();
            }
        }

        [OnLoadEvent]
        public void OnLoad() {
            MessageBox.Show("ロードされたよ！");
        }

        [OnUnloadEvent]
        public void OnUnload() {
            MessageBox.Show("アンロードされたよ！");
        }

        [OnLoadVideoEvent] //動画ロード時に実行されます
        public void OnOnLoadVideo() { 
            if (Dialog.RunWhenVideoLoaded) {
                LoadingDialog dlg = new LoadingDialog("処理中", Host.Video.FrameSize);
                dlg.Show();
                int curFrame = 0;
                
                Host.EditVideo(b => {
                    dlg.UpdateDialog($"処理中 ({curFrame}/{Host.Video.FrameSize})", curFrame);
                    curFrame++;
                    return CreateGrayscaleImage(b);
                });
                dlg.Dispose();
            }
        }

        // https://xn--dobon-pd4d5e.net/vb/dotnet/graphics/grayscale.html より引用
        public static Bitmap CreateGrayscaleImage(Bitmap img) {
            //グレースケールの描画先となるImageオブジェクトを作成
            Bitmap newImg = new Bitmap(img.Width, img.Height);
            //newImgのGraphicsオブジェクトを取得
            Graphics g = Graphics.FromImage(newImg);

            //ColorMatrixオブジェクトの作成
            //グレースケールに変換するための行列を指定する
            System.Drawing.Imaging.ColorMatrix cm =
                new System.Drawing.Imaging.ColorMatrix(
                    new float[][]{
                new float[]{0.299f, 0.299f, 0.299f, 0 ,0},
                new float[]{0.587f, 0.587f, 0.587f, 0, 0},
                new float[]{0.114f, 0.114f, 0.114f, 0, 0},
                new float[]{0, 0, 0, 1, 0},
                new float[]{0, 0, 0, 0, 1}
                    });
            //ImageAttributesオブジェクトの作成
            System.Drawing.Imaging.ImageAttributes ia =
                new System.Drawing.Imaging.ImageAttributes();
            //ColorMatrixを設定する
            ia.SetColorMatrix(cm);

            //ImageAttributesを使用してグレースケールを描画
            g.DrawImage(img,
                new Rectangle(0, 0, img.Width, img.Height),
                0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);

            //リソースを解放する
            g.Dispose();

            return newImg;
        }
    }
}
