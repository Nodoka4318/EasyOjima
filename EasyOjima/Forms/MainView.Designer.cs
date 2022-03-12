namespace EasyOjima.Forms {
    partial class MainView {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.ViewBox = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.動画を読み込むToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.エクスポートToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.拡張機能PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.かんたん大島ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.バグ報告要望ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerTick = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ViewBox)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ViewBox
            // 
            this.ViewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewBox.Location = new System.Drawing.Point(0, 24);
            this.ViewBox.Name = "ViewBox";
            this.ViewBox.Size = new System.Drawing.Size(384, 257);
            this.ViewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ViewBox.TabIndex = 0;
            this.ViewBox.TabStop = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.拡張機能PToolStripMenuItem,
            this.かんたん大島ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(384, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.動画を読み込むToolStripMenuItem,
            this.エクスポートToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.ファイルToolStripMenuItem.ShowShortcutKeys = false;
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ファイルToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // 動画を読み込むToolStripMenuItem
            // 
            this.動画を読み込むToolStripMenuItem.Name = "動画を読み込むToolStripMenuItem";
            this.動画を読み込むToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.動画を読み込むToolStripMenuItem.ShowShortcutKeys = false;
            this.動画を読み込むToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.動画を読み込むToolStripMenuItem.Text = "動画を読み込む(&O)…";
            this.動画を読み込むToolStripMenuItem.Click += new System.EventHandler(this.動画を読み込むToolStripMenuItem_Click);
            // 
            // エクスポートToolStripMenuItem
            // 
            this.エクスポートToolStripMenuItem.Name = "エクスポートToolStripMenuItem";
            this.エクスポートToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.エクスポートToolStripMenuItem.ShowShortcutKeys = false;
            this.エクスポートToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.エクスポートToolStripMenuItem.Text = "エクスポート(&S)…";
            this.エクスポートToolStripMenuItem.Click += new System.EventHandler(this.エクスポートToolStripMenuItem_Click);
            // 
            // 拡張機能PToolStripMenuItem
            // 
            this.拡張機能PToolStripMenuItem.Name = "拡張機能PToolStripMenuItem";
            this.拡張機能PToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.拡張機能PToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.拡張機能PToolStripMenuItem.Text = "拡張機能(&P)";
            // 
            // かんたん大島ToolStripMenuItem
            // 
            this.かんたん大島ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.設定ToolStripMenuItem,
            this.バグ報告要望ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.かんたん大島ToolStripMenuItem.Name = "かんたん大島ToolStripMenuItem";
            this.かんたん大島ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.かんたん大島ToolStripMenuItem.ShowShortcutKeys = false;
            this.かんたん大島ToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.かんたん大島ToolStripMenuItem.Text = "かんたん大島(&H)";
            // 
            // 設定ToolStripMenuItem
            // 
            this.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            this.設定ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.設定ToolStripMenuItem.ShowShortcutKeys = false;
            this.設定ToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.設定ToolStripMenuItem.Text = "設定(&E)";
            this.設定ToolStripMenuItem.Click += new System.EventHandler(this.設定ToolStripMenuItem_Click);
            // 
            // バグ報告要望ToolStripMenuItem
            // 
            this.バグ報告要望ToolStripMenuItem.Name = "バグ報告要望ToolStripMenuItem";
            this.バグ報告要望ToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.バグ報告要望ToolStripMenuItem.Text = "バグ報告・要望";
            this.バグ報告要望ToolStripMenuItem.Click += new System.EventHandler(this.バグ報告要望ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(144, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // playerTick
            // 
            this.playerTick.Tick += new System.EventHandler(this.playerTick_Tick);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 281);
            this.Controls.Add(this.ViewBox);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainView";
            this.Text = "かんたん大島";
            ((System.ComponentModel.ISupportInitialize)(this.ViewBox)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ViewBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 動画を読み込むToolStripMenuItem;
        private System.Windows.Forms.Timer playerTick;
        private System.Windows.Forms.ToolStripMenuItem エクスポートToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem かんたん大島ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem バグ報告要望ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 拡張機能PToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
