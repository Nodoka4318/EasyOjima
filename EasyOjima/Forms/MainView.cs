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
using System.IO;

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
            this.ViewBox.Paint += ViewBox_Paint;
            this.AllowDrop = true;
            this.DragDrop += MainView_DragDrop;
            this.DragEnter += MainView_DragEnter;
            this.ViewBox.MouseClick += ViewBox_MouseClick;
            this.Icon = Resource.ICON_64;
        }

        private void ViewBox_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Right)
                return;

            var menu = new ContextMenuStrip();
            menu.RenderMode = ToolStripRenderMode.System;
            menu.Items.Add(new ToolStripMenuItem() {
                Text = "画像として保存",
                Enabled = this.video == null ? false : true
            });
            menu.Show(this.Location.X + e.Location.X, this.Location.Y + e.Location.Y);
            menu.ItemClicked += ViewBox_ContextMenuStripItemClick;
        }

        private void ViewBox_ContextMenuStripItemClick(object sender, ToolStripItemClickedEventArgs e) {
            var text = e.ClickedItem.Text;
            e.ClickedItem.Dispose();
            if (text == "画像として保存") {
                using (var dlg = new SaveFileDialog() {
                    Title = "画像として保存",
                    Filter = "PNGイメージ|*.png"
                }) {
                    var result = dlg.ShowDialog();
                    if (result == DialogResult.OK) {
                        try {
                            var image = ViewBox.Image;
                            image.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        } catch (Exception ex) {
                            MessageUtil.ErrorMessage(ex.Message);
                            return;
                        }
                    }
                }
            }
        }

        private void MainView_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                var drags = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (drags.Length != 1)
                    return;
                foreach (string d in drags) {
                    if (!File.Exists(d)) {
                        return;
                    }
                }
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void MainView_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length != 1)
                return;
            var file = files[0];

            try {
                this.VideoPath = file;
                this.video = new Video.Video(VideoPath);
                this.video.Init();
                ViewBox.Image = this.video.GetCurrentFrame();
                playerTick.Interval = (int)(1000 / video.FrameRate);
                controls.trackBar.Enabled = true;
                controls.trackBar.Maximum = video.FrameSize - 1;

                try {
                    //フレーム密度の自動設定
                    int i = 1;
                    var fps = Program.mainView.video.FrameRate;
                    while (i * fps < 100)
                        i++;
                    this.controls.frameDensityBox.Value = i;

                    this.controls.Show(this);
                } catch (InvalidOperationException) { /*既にコントロールが表示されていたとき*/ }

                PluginInfo.InvokeEvent(typeof(OnLoadVideoEventAttribute), plugins);
            } catch (Exception ex) {
                MessageUtil.ErrorMessage(ex.Message);
                return;
            }
        }

        private void ViewBox_Paint(object sender, PaintEventArgs e) {
            PluginInfo.InvokeEvent(typeof(OnPaintEventAttribute), new object[] { sender, e }, plugins);
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e) {
            if (this.video == null || !Preference.Settings.Contains("askwhenclosing")) {
                //OnUnLoadEvent実行
                PluginInfo.InvokeEvent(typeof(OnUnloadEventAttribute), plugins);
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
            PluginInfo.InvokeEventAsync(typeof(OnUnloadEventAttribute), plugins);
        }

        private void 動画を読み込むToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var dlg = new OpenFileDialog() {
                Title = "動画を読み込む",
                Filter = "MP4動画|*.mp4|全てのファイル|*.*"
            }) {
                DialogResult dialogResult = dlg.ShowDialog();
                if (dialogResult == DialogResult.OK) {
                    try {
                        this.VideoPath = dlg.FileName;
                        this.video = new Video.Video(VideoPath);
                        this.video.Init();
                    } catch (Exception ex) {
                        MessageUtil.ErrorMessage(ex.Message);
                        return;
                    }

                    ViewBox.Image = this.video.GetCurrentFrame();
                    playerTick.Interval = (int)(1000 / video.FrameRate);
                    controls.trackBar.Enabled = true;
                    controls.trackBar.Maximum = video.FrameSize - 1;

                    try {
                        //フレーム密度の自動設定
                        int i = 1;
                        var fps = Program.mainView.video.FrameRate;
                        while (i * fps < 100)
                            i++;
                        this.controls.frameDensityBox.Value = i;

                        this.controls.Show(this);
                    } catch (InvalidOperationException) { /*既にコントロールが表示されていたとき*/ }

                    PluginInfo.InvokeEvent(typeof(OnLoadVideoEventAttribute), plugins);
                }
            }
        }

        private void playerTick_Tick(object sender, EventArgs e) {
            if (!this.isPlaying)
                return;
           
            if (video.CurrentFrame < video.FrameSize - 1) {
                ViewBox.Image = video.GetCurrentFrame();
                ViewBox.Refresh();
                controls.trackBar.Value = video.CurrentFrame;
                controls.SetFrameLabelText(video.CurrentFrame + 1, video.FrameSize);
                video.CurrentFrame++;

                PluginInfo.InvokeEvent(typeof(OnFrameUpdateEventAttribute), plugins);
            } else {
                video.CurrentFrame = 0;
                this.isPlaying = false;
                this.playerTick.Stop();
                controls.trackBar.Value = video.CurrentFrame;
            }
        }

        public void PlayVideo() {
            //OnPlayEvent実行
            PluginInfo.InvokeEvent(typeof(OnPlayEventAttribute), plugins);
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
            ViewBox.Refresh();
        }

        private void エクスポートToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this.video == null) {
                MessageUtil.WarnMessage("エクスポートできません。");
                return;
            }

            PluginInfo.InvokeEvent(typeof(OnExportVideoEventAttribute), plugins);

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
                PluginInfo.InvokeEventAsync(typeof(OnLoadEventAttribute), plugins);
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
