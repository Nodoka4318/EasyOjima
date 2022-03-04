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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EndFrameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BeginFrameBox = new System.Windows.Forms.TextBox();
            this.frameLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bpmBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.selectedScoreLabel = new System.Windows.Forms.Label();
            this.openFolderButton = new System.Windows.Forms.Button();
            this.selectScoreButton = new System.Windows.Forms.Button();
            this.launchButton = new System.Windows.Forms.Button();
            this.easingRateUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.easingRateUpDown)).BeginInit();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.EndFrameBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BeginFrameBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 89);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "範囲設定";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "終了フレーム";
            // 
            // EndFrameBox
            // 
            this.EndFrameBox.Location = new System.Drawing.Point(77, 51);
            this.EndFrameBox.Name = "EndFrameBox";
            this.EndFrameBox.Size = new System.Drawing.Size(58, 23);
            this.EndFrameBox.TabIndex = 0;
            this.EndFrameBox.Text = "50";
            this.EndFrameBox.TextChanged += new System.EventHandler(this.EndFrameBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "開始フレーム";
            // 
            // BeginFrameBox
            // 
            this.BeginFrameBox.Location = new System.Drawing.Point(77, 22);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bpmBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.selectedScoreLabel);
            this.groupBox2.Controls.Add(this.openFolderButton);
            this.groupBox2.Controls.Add(this.selectScoreButton);
            this.groupBox2.Location = new System.Drawing.Point(162, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 89);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "楽譜設定";
            // 
            // bpmBox
            // 
            this.bpmBox.Location = new System.Drawing.Point(44, 51);
            this.bpmBox.Name = "bpmBox";
            this.bpmBox.Size = new System.Drawing.Size(56, 23);
            this.bpmBox.TabIndex = 3;
            this.bpmBox.Text = "120";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "BPM";
            // 
            // selectedScoreLabel
            // 
            this.selectedScoreLabel.AutoSize = true;
            this.selectedScoreLabel.Location = new System.Drawing.Point(6, 26);
            this.selectedScoreLabel.Name = "selectedScoreLabel";
            this.selectedScoreLabel.Size = new System.Drawing.Size(118, 15);
            this.selectedScoreLabel.TabIndex = 1;
            this.selectedScoreLabel.Text = "何も選択されていません";
            // 
            // openFolderButton
            // 
            this.openFolderButton.Location = new System.Drawing.Point(106, 51);
            this.openFolderButton.Name = "openFolderButton";
            this.openFolderButton.Size = new System.Drawing.Size(102, 23);
            this.openFolderButton.TabIndex = 0;
            this.openFolderButton.Text = "楽譜フォルダを開く";
            this.openFolderButton.UseVisualStyleBackColor = true;
            this.openFolderButton.Click += new System.EventHandler(this.openFolderButton_Click);
            // 
            // selectScoreButton
            // 
            this.selectScoreButton.Location = new System.Drawing.Point(134, 22);
            this.selectScoreButton.Name = "selectScoreButton";
            this.selectScoreButton.Size = new System.Drawing.Size(74, 23);
            this.selectScoreButton.TabIndex = 0;
            this.selectScoreButton.Text = "楽譜を選択";
            this.selectScoreButton.UseVisualStyleBackColor = true;
            this.selectScoreButton.Click += new System.EventHandler(this.selectScoreButton_Click);
            // 
            // launchButton
            // 
            this.launchButton.Location = new System.Drawing.Point(382, 114);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(90, 33);
            this.launchButton.TabIndex = 5;
            this.launchButton.Text = "実行";
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // easingRateUpDown
            // 
            this.easingRateUpDown.Location = new System.Drawing.Point(382, 86);
            this.easingRateUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.easingRateUpDown.Name = "easingRateUpDown";
            this.easingRateUpDown.Size = new System.Drawing.Size(90, 23);
            this.easingRateUpDown.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "イージング設定";
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 161);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.easingRateUpDown);
            this.Controls.Add(this.launchButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.frameLabel);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.easingRateUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button stopButton;
        public System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EndFrameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BeginFrameBox;
        private System.Windows.Forms.Label frameLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox bpmBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label selectedScoreLabel;
        private System.Windows.Forms.Button openFolderButton;
        private System.Windows.Forms.Button selectScoreButton;
        private System.Windows.Forms.Button launchButton;
        private System.Windows.Forms.NumericUpDown easingRateUpDown;
        private System.Windows.Forms.Label label3;
    }
}