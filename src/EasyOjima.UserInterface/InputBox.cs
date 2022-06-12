using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyOjima.UserInterface {
    public partial class InputBox : Form {
        private bool _isValidClose = false;

        public InputBox(string message) {
            InitializeComponent();
            this.messageLabel.Text = message;
            this.FormClosing += Inputbox_FormClosing;
        }

        private void Inputbox_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                if (!this._isValidClose) {
                    this.Result = DialogResult.Cancel;
                }
            }
        }

        public string ResultText => this.textBox.Text;
        public DialogResult Result { get; private set; }

        private void Inputbox_Load(object sender, EventArgs e) {
            //none
        }

        private void submitButton_Click(object sender, EventArgs e) {
            this.Result = DialogResult.OK;
            this._isValidClose = true;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            this.Result = DialogResult.Cancel;
            this._isValidClose = true;
            this.Close();
        }
    }
}
