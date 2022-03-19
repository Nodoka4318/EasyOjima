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
using EasyOjima.Video;
using EasyOjima.Utils;
using EasyOjima.Plugin;
using System.Diagnostics;
using EasyOjima.Enums;

namespace EasyOjima.Forms {
    public partial class MainView : Form {
        public ControlPanel controls = new ControlPanel();
        public string VideoPath { get; set; } //動画のパス
        public Video.Video video;
        public bool isPlaying = false; //再生中か否か

        public IPlugin[] plugins; //TODO: プラグイン関連を整理

        public MainView() {
            InitializeComponent();
            InitPlugins();
            this.FormClosing += MainView_FormClosing;
            this.拡張機能PToolStripMenuItem.DropDownItemClicked += 拡張機能PToolStripMenuItem_DropDownItemClicked;
            this.拡張機能PToolStripMenuItem.DropDown.ShowItemToolTips = true;
        }       

        private void MainView_FormClosing(object sender, FormClosingEventArgs e) {
            if (this.video == null || !Preference.Settings.Contains("askwhenclosing")) {
                //OnUnLoadEvent実行
                PluginInfo.InvokeEvent(typeof(OnUnloadEvent), plugins);
                return;
            }
            if (e.CloseReason == CloseReason.UserClosing) {
                var _dlg = MessageUtil.InfoYesNo("終了してもよろしいですか？");
                if (_dlg == DialogResult.No) {
                    e.Cancel = true;
                    return;
                }
            }
            //OnUnLoadEvent実行
            PluginInfo.InvokeEvent(typeof(OnUnloadEvent), plugins);
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

                    try {
                        this.controls.Show(this);
                    } catch { }

                    PluginInfo.InvokeEvent(typeof(OnLoadVideoEvent), plugins);
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

                PluginInfo.InvokeEvent(typeof(OnFrameUpdateEvent), plugins);
            } else {
                video.CurrentFrame = 0;
                this.isPlaying = false;
                this.playerTick.Stop();
                controls.trackBar.Value = video.CurrentFrame;
            }
        }

        public void PlayVideo() {
            //OnPlayEvent実行
            PluginInfo.InvokeEvent(typeof(OnPlayEvent), plugins);
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

        private void エクスポートToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this.video == null) {
                MessageUtil.WarnMessage("エクスポートできません。");
                return;
            }

            PluginInfo.InvokeEvent(typeof(OnExportVideoEvent), plugins);

            using (var dlg = new SaveFileDialog() {
                Title = "エクスポート",
                Filter = "MP4動画|*.mp4"
            }) { 
                var result = dlg.ShowDialog();
                if (result == DialogResult.OK) {
                    VideoExporter ve = new VideoExporter(this.video, dlg.FileName);
                    ve.Export(this.video);
                }
            }
        }

        private void 設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            (new Preference()).ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show($"EasyOjima v{Program.VERSION}\n\nAuthor: @Nodoka_Oto_Mad\nIcon: @Yunon_Oto_mad\n\nCredits:\n  OpenCvSharp3-AnyCPU", "かんたん大島");
        }

        private void バグ報告要望ToolStripMenuItem_Click(object sender, EventArgs e) {
            ReportDialog dlg = new ReportDialog();
            dlg.ShowDialog();
            dlg.Dispose();
        }

        private void InitPlugins() {
            var pluginInfos = PluginInfo.FindPlugins();
            if (pluginInfos.Length == 0) {
                var _item = new ToolStripMenuItem();
                _item.Text = "プラグインはありません";
                _item.Enabled = false;
                this.拡張機能PToolStripMenuItem.DropDownItems.Add(_item);
            } else {
                plugins = new IPlugin[pluginInfos.Length];
                for (int i = 0; i < pluginInfos.Length; i++) {
                    var p = pluginInfos[i].CreateInstance();

                    var _pitem = new ToolStripMenuItem();
                    _pitem.Text = p.Name;
                    _pitem.ToolTipText = $"{p.Description}\nAuthor: {p.Author}";

                    this.拡張機能PToolStripMenuItem.DropDownItems.Add(_pitem);
                    plugins[i] = p;
                }
                //OnLoadEvent実行
                PluginInfo.InvokeEvent(typeof(OnLoadEvent), plugins);
            }

            this.拡張機能PToolStripMenuItem.DropDownItems.Add("-");
            this.拡張機能PToolStripMenuItem.DropDownItems.Add("プラグインフォルダを開く");
        }

        private void 拡張機能PToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            var item = e.ClickedItem;
            if (item.Text == "プラグインフォルダを開く") {
                Process.Start("EXPLORER.EXE", Loc.PLUGINS);
                return;
            }
            if (plugins == null)
                return;
            foreach (var p in plugins) {
                if (item.Text == p.Name) {
                    p.Run();
                }
            }
        }
    }
}
