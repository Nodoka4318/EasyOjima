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
            this.resetButton = new System.Windows.Forms.Button();
            this.dotCoordsBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveCurveButton = new System.Windows.Forms.Button();
            this.deleteCurveButton = new System.Windows.Forms.Button();
            this.setCurveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.beziersBox = new System.Windows.Forms.ComboBox();
            this.submitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.editorBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // editorBox
            // 
            this.editorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editorBox.Location = new System.Drawing.Point(0, 0);
            this.editorBox.Name = "editorBox";
            this.editorBox.Size = new System.Drawing.Size(284, 284);
            this.editorBox.TabIndex = 0;
            this.editorBox.TabStop = false;
            this.editorBox.Click += new System.EventHandler(this.editorBox_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(209, 287);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(63, 23);
            this.resetButton.TabIndex = 2;
            this.resetButton.Text = "リセット";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // dotCoordsBox
            // 
            this.dotCoordsBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dotCoordsBox.Location = new System.Drawing.Point(12, 287);
            this.dotCoordsBox.Name = "dotCoordsBox";
            this.dotCoordsBox.Size = new System.Drawing.Size(191, 23);
            this.dotCoordsBox.TabIndex = 3;
            this.dotCoordsBox.TextChanged += new System.EventHandler(this.dotCoordsBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.saveCurveButton);
            this.groupBox1.Controls.Add(this.deleteCurveButton);
            this.groupBox1.Controls.Add(this.setCurveButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.beziersBox);
            this.groupBox1.Controls.Add(this.submitButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 316);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 119);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "設定";
            // 
            // saveCurveButton
            // 
            this.saveCurveButton.Location = new System.Drawing.Point(9, 85);
            this.saveCurveButton.Name = "saveCurveButton";
            this.saveCurveButton.Size = new System.Drawing.Size(142, 23);
            this.saveCurveButton.TabIndex = 3;
            this.saveCurveButton.Text = "現在の曲線を保存する";
            this.saveCurveButton.UseVisualStyleBackColor = true;
            this.saveCurveButton.Click += new System.EventHandler(this.saveCurveButton_Click);
            // 
            // deleteCurveButton
            // 
            this.deleteCurveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deleteCurveButton.Location = new System.Drawing.Point(9, 51);
            this.deleteCurveButton.Name = "deleteCurveButton";
            this.deleteCurveButton.Size = new System.Drawing.Size(97, 23);
            this.deleteCurveButton.TabIndex = 3;
            this.deleteCurveButton.Text = "削除する";
            this.deleteCurveButton.UseVisualStyleBackColor = true;
            // 
            // setCurveButton
            // 
            this.setCurveButton.Location = new System.Drawing.Point(112, 51);
            this.setCurveButton.Name = "setCurveButton";
            this.setCurveButton.Size = new System.Drawing.Size(142, 23);
            this.setCurveButton.TabIndex = 3;
            this.setCurveButton.Text = "選択した曲線を呼び出す";
            this.setCurveButton.UseVisualStyleBackColor = true;
            this.setCurveButton.Click += new System.EventHandler(this.setCurveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "保存した曲線";
            // 
            // beziersBox
            // 
            this.beziersBox.FormattingEnabled = true;
            this.beziersBox.Location = new System.Drawing.Point(87, 22);
            this.beziersBox.Name = "beziersBox";
            this.beziersBox.Size = new System.Drawing.Size(167, 23);
            this.beziersBox.TabIndex = 1;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(157, 79);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(97, 34);
            this.submitButton.TabIndex = 0;
            this.submitButton.Text = "使用する";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 447);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dotCoordsBox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.editorBox);
            this.Location = new System.Drawing.Point(300, 300);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 486);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 486);
            this.Name = "Editor";
            this.Text = "ベジェ曲線を編集";
            ((System.ComponentModel.ISupportInitialize)(this.editorBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox editorBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.TextBox dotCoordsBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button saveCurveButton;
        private System.Windows.Forms.Button setCurveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox beziersBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button deleteCurveButton;
    }
}