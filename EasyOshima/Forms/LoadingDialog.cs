using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EasyOshima.Forms {
    public partial class LoadingDialog : Form {
        public LoadingDialog(string message, int maxFrame) {
            InitializeComponent();
            FormClosing += LoadingDialog_FormClosing;
            label1.Text = message;
            label1.Update();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = maxFrame;
            progressBar1.Value = 0;
        }

        public LoadingDialog(int maxFrame) {
            InitializeComponent();
            this.FormClosing += LoadingDialog_FormClosing;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = maxFrame;
            progressBar1.Value = 0;
        }

        private void LoadingDialog_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
        }

        private void LoadingDialog_Load(object sender, EventArgs e) {

        }

        public void UpdateDialog(string message, int frame) {
            this.label1.Text = message;
            label1.Update();
            progressBar1.Value = frame;
        }

        public void UpdateDialog(int frame) {
            progressBar1.Value = frame;
        }
    }
}
