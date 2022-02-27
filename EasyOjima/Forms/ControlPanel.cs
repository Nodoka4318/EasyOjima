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

namespace EasyOjima.Forms {
    public partial class ControlPanel : Form {
        public string ScoreText { get; private set; }

        public ControlPanel() {
            InitializeComponent();
            trackBar.Minimum = 0;
            trackBar.Enabled = false;
            this.FormClosing += ControlPanel_FormClosing;
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
        }

        private void EndFrameBox_TextChanged(object sender, EventArgs e) {
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
                selectedScoreLabel.Update();
                return;
            }
            this.ScoreText = selectDialog.ResultScore;
            selectedScoreLabel.Text = selectDialog.ResultFileName.Replace(".score", "");
            selectedScoreLabel.Update();
            selectDialog.Dispose();
        }
    }
}
