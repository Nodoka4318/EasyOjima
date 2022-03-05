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
            this.playerTick = new System.Windows.Forms.Timer(this.components);
            this.かんたん大島ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // 動画を読み込むToolStripMenuItem
            // 
            this.動画を読み込むToolStripMenuItem.Name = "動画を読み込むToolStripMenuItem";
            this.動画を読み込むToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.動画を読み込むToolStripMenuItem.Text = "動画を読み込む";
            this.動画を読み込むToolStripMenuItem.Click += new System.EventHandler(this.動画を読み込むToolStripMenuItem_Click);
            // 
            // エクスポートToolStripMenuItem
            // 
            this.エクスポートToolStripMenuItem.Name = "エクスポートToolStripMenuItem";
            this.エクスポートToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.エクスポートToolStripMenuItem.Text = "エクスポート";
            this.エクスポートToolStripMenuItem.Click += new System.EventHandler(this.エクスポートToolStripMenuItem_Click);
            // 
            // playerTick
            // 
            this.playerTick.Tick += new System.EventHandler(this.playerTick_Tick);
            // 
            // かんたん大島ToolStripMenuItem
            // 
            this.かんたん大島ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.設定ToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.かんたん大島ToolStripMenuItem.Name = "かんたん大島ToolStripMenuItem";
            this.かんたん大島ToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.かんたん大島ToolStripMenuItem.Text = "かんたん大島";
            // 
            // 設定ToolStripMenuItem
            // 
            this.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            this.設定ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.設定ToolStripMenuItem.Text = "設定";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
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
    }
}
