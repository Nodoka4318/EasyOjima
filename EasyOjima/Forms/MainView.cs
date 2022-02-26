using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using EasyOjima.Video;

namespace EasyOjima.Forms {
    public partial class MainView : Form {
        public ControlPanel controls = new ControlPanel();
        public string VideoPath { get; set; } //動画のパス
        public Video.Video video;
        public bool isPlaying = false; //再生中か否か

        public MainView() {
            InitializeComponent();
            controls.Show(this);
        }

        private void 動画を読み込むToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var dlg = new OpenFileDialog() {
                Title = "動画を読み込む",
                Filter = "MP4動画|*.mp4|全てのファイル|*.*"
            }) {
                DialogResult dialogResult = dlg.ShowDialog();
                if (dialogResult == DialogResult.OK) {
                    this.VideoPath = dlg.FileName;
                    this.video = new Video.Video(VideoPath);
                    this.video.Init();
                    ViewBox.Image = this.video.GetCurrentFrame();
                    playerTick.Interval = (int)(1000 / video.FrameRate);
                    controls.trackBar.Enabled = true;
                    controls.trackBar.Maximum = video.FrameSize - 1;
                }
            }
        }

        private void playerTick_Tick(object sender, EventArgs e) {
            if (!this.isPlaying)
                return;
           
            if (video.CurrentFrame < video.FrameSize - 1) {
                ViewBox.Image = video.GetCurrentFrame();
                controls.trackBar.Value = video.CurrentFrame;
                controls.SetFrameLabelText(video.CurrentFrame + 1, video.FrameSize);
                video.CurrentFrame++;
            } else {
                video.CurrentFrame = 0;
                this.isPlaying = false;
                this.playerTick.Stop();
                controls.trackBar.Value = video.CurrentFrame;
            }
        }

        public void PlayVideo() {
            this.isPlaying = true;
            this.playerTick.Start();
        }

        public void PauseVideo() {
            this.isPlaying = false;
            this.playerTick.Stop();
        }

        public void StopVideo() {
            video.CurrentFrame = 0;
            this.isPlaying = false;
            this.playerTick.Stop();
            controls.trackBar.Value = video.CurrentFrame;
        }

        public void SetFrame(int frame) {
            if (frame >= video.FrameSize)
                return;
            this.isPlaying = false;
            this.playerTick.Stop();
            video.CurrentFrame = frame;
            controls.trackBar.Value = video.CurrentFrame;
            ViewBox.Image = video.GetCurrentFrame();
        }
    }
}
