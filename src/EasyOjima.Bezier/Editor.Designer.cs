namespace EasyOjima.Bezier {
    partial class Editor {
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
            this.editorBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.editorBox)).BeginInit();
            this.SuspendLayout();
            // 
            // editorBox
            // 
            this.editorBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorBox.Location = new System.Drawing.Point(0, 0);
            this.editorBox.Name = "editorBox";
            this.editorBox.Size = new System.Drawing.Size(284, 261);
            this.editorBox.TabIndex = 0;
            this.editorBox.TabStop = false;
            this.editorBox.Click += new System.EventHandler(this.editorBox_Click);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.editorBox);
            this.Location = new System.Drawing.Point(300, 300);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Editor";
            this.Text = "ベジェ曲線エディタ";
            ((System.ComponentModel.ISupportInitialize)(this.editorBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox editorBox;
    }
}