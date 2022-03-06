namespace EasyOjima.Forms {
    partial class ControlPanel {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.playButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.EndFrameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BeginFrameBox = new System.Windows.Forms.TextBox();
            this.frameLabel = new System.Windows.Forms.Label();
            this.bpmBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.selectedScoreLabel = new System.Windows.Forms.Label();
            this.openFolderButton = new System.Windows.Forms.Button();
            this.selectScoreButton = new System.Windows.Forms.Button();
            this.launchButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.easingRateUpDown = new System.Windows.Forms.NumericUpDown();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.easingTypeBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.useFrameInterpolationCheck = new System.Windows.Forms.CheckBox();
            this.frameInterpolationBox = new System.Windows.Forms.NumericUpDown();
            this.frameDensityBox = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easingRateUpDown)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frameInterpolationBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameDensityBox)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(12, 12);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(364, 45);
            this.trackBar.TabIndex = 0;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(414, 12);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(26, 23);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "▶";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(446, 12);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(26, 23);
            this.pauseButton.TabIndex = 1;
            this.pauseButton.Text = "❙❙";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(382, 12);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(26, 23);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "■";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "終了フレーム";
            // 
            // EndFrameBox
            // 
            this.EndFrameBox.Location = new System.Drawing.Point(77, 45);
            this.EndFrameBox.Name = "EndFrameBox";
            this.EndFrameBox.Size = new System.Drawing.Size(58, 23);
            this.EndFrameBox.TabIndex = 0;
            this.EndFrameBox.Text = "50";
            this.EndFrameBox.TextChanged += new System.EventHandler(this.EndFrameBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "開始フレーム";
            // 
            // BeginFrameBox
            // 
            this.BeginFrameBox.Location = new System.Drawing.Point(77, 11);
            this.BeginFrameBox.Name = "BeginFrameBox";
            this.BeginFrameBox.Size = new System.Drawing.Size(58, 23);
            this.BeginFrameBox.TabIndex = 0;
            this.BeginFrameBox.Text = "1";
            this.BeginFrameBox.TextChanged += new System.EventHandler(this.BeginFrameBox_TextChanged);
            // 
            // frameLabel
            // 
            this.frameLabel.AutoSize = true;
            this.frameLabel.Location = new System.Drawing.Point(382, 38);
            this.frameLabel.Name = "frameLabel";
            this.frameLabel.Size = new System.Drawing.Size(38, 15);
            this.frameLabel.TabIndex = 3;
            this.frameLabel.Text = "(0 / 0)";
            // 
            // bpmBox
            // 
            this.bpmBox.Location = new System.Drawing.Point(44, 45);
            this.bpmBox.Name = "bpmBox";
            this.bpmBox.Size = new System.Drawing.Size(56, 23);
            this.bpmBox.TabIndex = 3;
            this.bpmBox.Text = "120";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "BPM";
            // 
            // selectedScoreLabel
            // 
            this.selectedScoreLabel.AutoSize = true;
            this.selectedScoreLabel.Location = new System.Drawing.Point(86, 14);
            this.selectedScoreLabel.Name = "selectedScoreLabel";
            this.selectedScoreLabel.Size = new System.Drawing.Size(118, 15);
            this.selectedScoreLabel.TabIndex = 1;
            this.selectedScoreLabel.Text = "何も選択されていません";
            // 
            // openFolderButton
            // 
            this.openFolderButton.Location = new System.Drawing.Point(248, 39);
            this.openFolderButton.Name = "openFolderButton";
            this.openFolderButton.Size = new System.Drawing.Size(102, 33);
            this.openFolderButton.TabIndex = 0;
            this.openFolderButton.Text = "楽譜フォルダを開く";
            this.openFolderButton.UseVisualStyleBackColor = true;
            this.openFolderButton.Click += new System.EventHandler(this.openFolderButton_Click);
            // 
            // selectScoreButton
            // 
            this.selectScoreButton.Location = new System.Drawing.Point(6, 10);
            this.selectScoreButton.Name = "selectScoreButton";
            this.selectScoreButton.Size = new System.Drawing.Size(74, 23);
            this.selectScoreButton.TabIndex = 0;
            this.selectScoreButton.Text = "楽譜を選択";
            this.selectScoreButton.UseVisualStyleBackColor = true;
            this.selectScoreButton.Click += new System.EventHandler(this.selectScoreButton_Click);
            // 
            // launchButton
            // 
            this.launchButton.Location = new System.Drawing.Point(382, 116);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(90, 33);
            this.launchButton.TabIndex = 5;
            this.launchButton.Text = "実行";
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "割合";
            // 
            // easingRateUpDown
            // 
            this.easingRateUpDown.Location = new System.Drawing.Point(43, 12);
            this.easingRateUpDown.Name = "easingRateUpDown";
            this.easingRateUpDown.Size = new System.Drawing.Size(90, 23);
            this.easingRateUpDown.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(364, 106);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.EndFrameBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.BeginFrameBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(356, 78);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "範囲設定";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.openFolderButton);
            this.tabPage2.Controls.Add(this.bpmBox);
            this.tabPage2.Controls.Add(this.selectedScoreLabel);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.selectScoreButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(356, 78);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "楽譜設定";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.easingTypeBox);
            this.tabPage3.Controls.Add(this.easingRateUpDown);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(356, 78);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "イージング設定";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // easingTypeBox
            // 
            this.easingTypeBox.FormattingEnabled = true;
            this.easingTypeBox.Items.AddRange(new object[] {
            "なし",
            "イーズイン",
            "イーズアウト"});
            this.easingTypeBox.Location = new System.Drawing.Point(43, 44);
            this.easingTypeBox.Name = "easingTypeBox";
            this.easingTypeBox.Size = new System.Drawing.Size(121, 23);
            this.easingTypeBox.TabIndex = 8;
            this.easingTypeBox.Text = "なし";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "タイプ";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.useFrameInterpolationCheck);
            this.tabPage4.Controls.Add(this.frameInterpolationBox);
            this.tabPage4.Controls.Add(this.frameDensityBox);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(356, 78);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "動画設定";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // useFrameInterpolationCheck
            // 
            this.useFrameInterpolationCheck.AutoSize = true;
            this.useFrameInterpolationCheck.Location = new System.Drawing.Point(214, 50);
            this.useFrameInterpolationCheck.Name = "useFrameInterpolationCheck";
            this.useFrameInterpolationCheck.Size = new System.Drawing.Size(136, 19);
            this.useFrameInterpolationCheck.TabIndex = 2;
            this.useFrameInterpolationCheck.Text = "フレーム補間を使用する";
            this.useFrameInterpolationCheck.UseVisualStyleBackColor = true;
            // 
            // frameInterpolationBox
            // 
            this.frameInterpolationBox.Location = new System.Drawing.Point(107, 46);
            this.frameInterpolationBox.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.frameInterpolationBox.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.frameInterpolationBox.Name = "frameInterpolationBox";
            this.frameInterpolationBox.Size = new System.Drawing.Size(49, 23);
            this.frameInterpolationBox.TabIndex = 1;
            this.frameInterpolationBox.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // frameDensityBox
            // 
            this.frameDensityBox.Location = new System.Drawing.Point(100, 12);
            this.frameDensityBox.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.frameDensityBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.frameDensityBox.Name = "frameDensityBox";
            this.frameDensityBox.Size = new System.Drawing.Size(49, 23);
            this.frameDensityBox.TabIndex = 1;
            this.frameDensityBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "フレーム補間 (FPS)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "フレーム密度 (倍)";
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 161);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.launchButton);
            this.Controls.Add(this.frameLabel);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.trackBar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "ControlPanel";
            this.Text = "コントロール";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.easingRateUpDown)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frameInterpolationBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameDensityBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button stopButton;
        public System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EndFrameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BeginFrameBox;
        private System.Windows.Forms.Label frameLabel;
        private System.Windows.Forms.TextBox bpmBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label selectedScoreLabel;
        private System.Windows.Forms.Button openFolderButton;
        private System.Windows.Forms.Button selectScoreButton;
        private System.Windows.Forms.Button launchButton;
        private System.Windows.Forms.NumericUpDown easingRateUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox easingTypeBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox useFrameInterpolationCheck;
        private System.Windows.Forms.NumericUpDown frameInterpolationBox;
        private System.Windows.Forms.NumericUpDown frameDensityBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}