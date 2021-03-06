using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using EasyOjima.Enums;
using EasyOjima.Utils;
using EasyOjima.Video;
using EasyOjima.Score;
using EasyOjima.Score.Processing;
using EasyOjima.Bezier;

namespace EasyOjima.Forms {
    public partial class ControlPanel : Form {
        public string ScoreText { get; private set; }

        private BezierCurve _curve;

        public ControlPanel() {
            InitializeComponent();
            this.Icon = Resource.ICON_16;
            trackBar.Minimum = 0;
            trackBar.Enabled = false;
            bezierSettingButton.Visible = false;

            this.FormClosing += ControlPanel_FormClosing;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(ControlPanel_KeyDown);
            this.easingTypeBox.TextChanged += EasingTypeBox_TextChanged;

            _curve = new BezierCurve(20, 20, 80, 80);

            foreach (var e in new Easing().EasingList) {
                this.easingTypeBox.Items.Add(e.Name);
            }

            foreach (var o in ModeExtention.modes.Values) {
                this.selectModeBox.Items.Add(o);
            }
            this.selectModeBox.Items.Remove("unknown");
        }

        private void EasingTypeBox_TextChanged(object sender, EventArgs e) {
            var text = easingTypeBox.Text;
            if (text == "ベジェ曲線")
                bezierSettingButton.Visible = true;
            else
                bezierSettingButton.Visible = false;
        }

        private void ControlPanel_Load(object sender, EventArgs e) {
            //何もなし
        }

        private void ControlPanel_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Space) {
                this.label1.Select();
                if (Program.mainView.isPlaying) {
                    Program.mainView.PauseVideo();
                } else {
                    Program.mainView.PlayVideo();
                }
            }
        }

        private void ControlPanel_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
        }

        private void playButton_Click(object sender, EventArgs e) {
            Program.mainView.PlayVideo();
        }

        private void pauseButton_Click(object sender, EventArgs e) {
            Program.mainView.PauseVideo();
        }

        private void stopButton_Click(object sender, EventArgs e) {
            Program.mainView.StopVideo();
        }

        private void trackBar_Scroll(object sender, EventArgs e) {
            var val = trackBar.Value;
            Program.mainView.SetFrame(val);
            SetFrameLabelText(val + 1, Program.mainView.video.FrameSize);
        }

        public void SetFrameLabelText(int v1, int v2) {
            frameLabel.Text = $"({v1} / {v2})";
            frameLabel.Update();
        }

        private void BeginFrameBox_TextChanged(object sender, EventArgs e) {
            /*
            var maxframe = Program.mainView.video.FrameSize;
            try {
                if (BeginFrameBox.Text == "") {
                    BeginFrameBox.Text = "1";
                }                
                BeginFrameBox.Text = int.Parse(BeginFrameBox.Text) < maxframe ? BeginFrameBox.Text : maxframe.ToString();
                BeginFrameBox.Text = int.Parse(BeginFrameBox.Text) > 0 ? BeginFrameBox.Text : "1";
                BeginFrameBox.Text = int.Parse(EndFrameBox.Text) > int.Parse(BeginFrameBox.Text) ? BeginFrameBox.Text : (int.Parse(EndFrameBox.Text) - 1).ToString();
            } catch {
                BeginFrameBox.Text = "1";
            } 
            */
        }

        private void EndFrameBox_TextChanged(object sender, EventArgs e) {
            /*
            var maxframe = Program.mainView.video.FrameSize;
            try {               
                if (BeginFrameBox.Text == "") {
                    BeginFrameBox.Text = maxframe.ToString();
                }               
                EndFrameBox.Text = int.Parse(BeginFrameBox.Text) > 0 ? EndFrameBox.Text : "1";
                EndFrameBox.Text = int.Parse(EndFrameBox.Text) < int.Parse(BeginFrameBox.Text) ? EndFrameBox.Text : (int.Parse(BeginFrameBox.Text) + 1).ToString();
                EndFrameBox.Text = int.Parse(BeginFrameBox.Text) < maxframe ? EndFrameBox.Text : maxframe.ToString();
            } catch {
                EndFrameBox.Text = "2";
            }
            */
        }

        private void openFolderButton_Click(object sender, EventArgs e) {
            Process.Start("EXPLORER.EXE", Loc.SCORES);
        }

        private void selectScoreButton_Click(object sender, EventArgs e) {
            var selectDialog = new SelectScoreDialog();
            selectDialog.ShowDialog();

            if (selectDialog.ResultScore == null || selectDialog.ResultScore == "") {
                if (selectDialog.ResultScore == "")
                    MessageUtil.InfoMessage("楽譜が不正です。");
                selectedScoreLabel.Text = "何も選択されていません";
                this.ScoreText = "";
                selectedScoreLabel.Update();
                return;
            }
            this.ScoreText = selectDialog.ResultScore;
            selectedScoreLabel.Text = selectDialog.ResultFileName.Replace(".score", "");
            selectedScoreLabel.Update();
            selectDialog.Dispose();
        }

        int bpm;
        int beginFrame;
        int endFrame;
        double fps;
        string easingType;
        int frameDensityRate;
        int frameInterpolationRate;
        Mode mode;

        private void launchButton_Click(object sender, EventArgs e) {
            /*
            var _d = FrameProcessor.GetFrameBase(100, 10);
            foreach (var i in _d) {
                Debug.WriteLine(i);
            }
            
            return;
            */
            var _dlg = MessageUtil.InfoYesNo("実行しますか？");
            if (_dlg == DialogResult.No)
                return;
                
            ProcessManager process;
            try {
                bpm = int.Parse(bpmBox.Text);
                beginFrame = int.Parse(BeginFrameBox.Text);
                endFrame = int.Parse(EndFrameBox.Text);
                fps = Program.mainView.video.FrameRate;
                easingType = this.easingTypeBox.Text;
                frameDensityRate = (int)this.frameDensityBox.Value;
                frameInterpolationRate = (int)this.frameInterpolationBox.Value;
                mode = selectModeBox.Text.GetModeFromName();

                if (!useFrameInterpolationCheck.Enabled) {
                    frameInterpolationRate = 1;
                }

            } catch {
                MessageUtil.WarnMessage("入力内容が不正です。");
                return;
            }

            //try {
                bool flag1 = bpm == 0;
                bool flag2 = beginFrame > endFrame;
                bool flag3 = beginFrame > Program.mainView.video.FrameSize || beginFrame <= 0;
                bool flag4 = endFrame > Program.mainView.video.FrameSize || endFrame <= 0;
                bool flag5 = ScoreText == "" || ScoreText == null;

                if (flag1 || flag2 || flag3 || flag4 || flag5) {
                    MessageUtil.WarnMessage("入力内容が不正です。");
                    return;
                }

                process = new ProcessManager(
                    ScoreText, 
                    bpm, 
                    beginFrame, 
                    endFrame, 
                    easingType, 
                    frameDensityRate, 
                    frameInterpolationRate,
                    mode,
                    _curve
                    );
                process.Process(Program.mainView.video);
                Program.mainView.video.Dispose();
                
                if (mode == Mode.NORMAL) {
                    Program.mainView.video = new Video.Video(process.Processor.Frames, (int)(fps * frameDensityRate * Math.Pow(2, frameInterpolationRate - 1)));
                } else {
                    Program.mainView.video = new Video.Video(process.Option.Selected.GetFrames(), (int)(fps * frameDensityRate * Math.Pow(2, frameInterpolationRate - 1)));
                }
                this.trackBar.Maximum = Program.mainView.video.FrameSize;
            //} catch (Exception ex) {
            //    MessageUtil.ErrorMessage(ex.Message);
            //}           
        }

        private void showEasingGraphsButton_Click(object sender, EventArgs e) {
            var dialog = new Form() {
                Text = "イージング一覧",
                ShowIcon = false,
                BackgroundImageLayout = ImageLayout.Zoom,
                BackgroundImage = Resource.IMAGE_EASINGS,
                Size = new Size(Resource.IMAGE_EASINGS.Width / 2, Resource.IMAGE_EASINGS.Height / 2)
            };
            dialog.Show(this);
        }
        
        //プラグイン用
        public void SetScore(string scoreText, string title) {
            this.ScoreText = scoreText;
            selectedScoreLabel.Text = title;
            selectedScoreLabel.Update();
        }

        private void bezierSettingButton_Click(object sender, EventArgs e) {
            var editor = new Editor();
            editor.Icon = Resource.ICON_16;
            editor.ShowDialog(this);

            _curve = editor.Curve;
            editor.Dispose();
        }
    }
}
