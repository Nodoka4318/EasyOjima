﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using EasyOjima.Enums;
using EasyOjima.Utils;

namespace EasyOjima.Forms {
    public partial class SelectScoreDialog : Form {
        private List<string> scoreFiles;
        public string ResultScore { get; private set; }
        public string ResultFileName { get; private set; }

        public SelectScoreDialog() {
            InitializeComponent();
            this.FormClosing += SelectScoreDialog_FormClosing;
        }

        private void SelectScoreDialog_FormClosing(object sender, FormClosingEventArgs e) {
            //何もなし
        }

        private void SelectScoreDialog_Load(object sender, EventArgs e) {
            try {
                scoreFiles = Directory.GetFiles(Loc.SCORES, "*.score", SearchOption.AllDirectories).ToList();
                if (scoreFiles.Count < 1) {
                    MessageUtil.InfoMessage("楽譜ファイルが見つかりませんでした。");
                    this.Dispose();
                }
                foreach (string file in scoreFiles) {
                    listBox1.Items.Add(file);
                }
            } catch (Exception ex) {
                MessageUtil.ErrorMessage(ex.Message);
                this.Dispose();
            }
        }

        private void selectButton_Click(object sender, EventArgs e) {
            var selectedItem = (string)listBox1.SelectedItem;
            if (selectedItem == null) {
                MessageUtil.InfoMessage("いずれかの項目を選択してください。");
                return;
            }
            this.ResultScore = FileUtil.ReadTextFile(selectedItem);
            this.ResultFileName = selectedItem.Split('\\')[selectedItem.Split('\\').Length - 1];
            this.Close(); //Disposeしちゃだめ
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            //何もなし
        }       
    }
}
