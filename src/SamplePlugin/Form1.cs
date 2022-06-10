using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamplePlugin_GrayscalePlugin {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        public bool isLaunched = false;
        public bool RunWhenVideoLoaded => checkBox1.Checked;

        private void button1_Click(object sender, EventArgs e) {
            isLaunched = true;
            this.Close();
        }
    }
}
