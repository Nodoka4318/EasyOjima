namespace EasyOjima.Forms {
    partial class Preference {
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
            this.checkUpdateBox = new System.Windows.Forms.CheckBox();
            this.askWhenCloseBox = new System.Windows.Forms.CheckBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkUpdateBox
            // 
            this.checkUpdateBox.AutoSize = true;
            this.checkUpdateBox.Location = new System.Drawing.Point(12, 12);
            this.checkUpdateBox.Name = "checkUpdateBox";
            this.checkUpdateBox.Size = new System.Drawing.Size(154, 19);
            this.checkUpdateBox.TabIndex = 0;
            this.checkUpdateBox.Text = "起動時にアップデートを確認";
            this.checkUpdateBox.UseVisualStyleBackColor = true;
            // 
            // askWhenCloseBox
            // 
            this.askWhenCloseBox.AutoSize = true;
            this.askWhenCloseBox.Location = new System.Drawing.Point(12, 37);
            this.askWhenCloseBox.Name = "askWhenCloseBox";
            this.askWhenCloseBox.Size = new System.Drawing.Size(165, 19);
            this.askWhenCloseBox.TabIndex = 0;
            this.askWhenCloseBox.Text = "アプリ終了時に確認メッセージ";
            this.askWhenCloseBox.UseVisualStyleBackColor = true;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(126, 65);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(96, 34);
            this.confirmButton.TabIndex = 1;
            this.confirmButton.Text = "設定を更新";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // Preference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 111);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.askWhenCloseBox);
            this.Controls.Add(this.checkUpdateBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(250, 150);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 150);
            this.Name = "Preference";
            this.Text = "設定";
            this.Load += new System.EventHandler(this.Preference_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkUpdateBox;
        private System.Windows.Forms.CheckBox askWhenCloseBox;
        private System.Windows.Forms.Button confirmButton;
    }
}