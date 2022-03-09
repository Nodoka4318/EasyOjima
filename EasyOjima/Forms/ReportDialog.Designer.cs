namespace EasyOjima.Forms {
    partial class ReportDialog {
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
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // typeBox
            // 
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Items.AddRange(new object[] {
            "バグ報告",
            "要望"});
            this.typeBox.Location = new System.Drawing.Point(49, 12);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(223, 23);
            this.typeBox.TabIndex = 0;
            this.typeBox.Text = "バグ報告";
            this.typeBox.SelectedIndexChanged += new System.EventHandler(this.typeBox_SelectedIndexChanged);
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(12, 114);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(260, 135);
            this.messageBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "種別";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(135, 85);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(137, 23);
            this.nameBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "お名前 (ニックネーム可)";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(12, 41);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(260, 38);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "送信";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // ReportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.typeBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "ReportDialog";
            this.Text = "バグ報告・要望";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sendButton;
    }
}