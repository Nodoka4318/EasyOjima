namespace EasyOjima.Forms {
    partial class SelectScoreDialog {
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.rootFolderBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(560, 199);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(454, 217);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(118, 32);
            this.selectButton.TabIndex = 1;
            this.selectButton.Text = "決定";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // rootFolderBox
            // 
            this.rootFolderBox.FormattingEnabled = true;
            this.rootFolderBox.Items.AddRange(new object[] {
            "<root>"});
            this.rootFolderBox.Location = new System.Drawing.Point(312, 223);
            this.rootFolderBox.Name = "rootFolderBox";
            this.rootFolderBox.Size = new System.Drawing.Size(136, 23);
            this.rootFolderBox.TabIndex = 2;
            this.rootFolderBox.Text = "<root>";
            this.rootFolderBox.SelectedIndexChanged += new System.EventHandler(this.rootFolderBox_SelectedIndexChanged);
            // 
            // SelectScoreDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.rootFolderBox);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.listBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "SelectScoreDialog";
            this.Text = "楽譜を選択";
            this.Load += new System.EventHandler(this.SelectScoreDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.ComboBox rootFolderBox;
    }
}