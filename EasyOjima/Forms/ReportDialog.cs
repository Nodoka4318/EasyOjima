using EasyOjima.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace EasyOjima.Forms {
    public partial class ReportDialog : Form {
        public ReportDialog() {
            InitializeComponent();
            this.Icon = Resource.ICON_16;
            this.typeBox.TextChanged += typeBox_SelectedIndexChanged;
        }

        private void sendButton_Click(object sender, EventArgs e) {
            //webhook url
            var bug_webhook = Resource.BUGREPORT_WEBHOOK;
            var req_webhook = Resource.REQUEST_WEBHOOK;

            var guid = Ident.Read().Id.ToString();
            var app_version = Program.VERSION;
            var win_version = Environment.OSVersion.ToString();

            try {
                string type = typeBox.Text;
                string name = nameBox.Text;
                string message = messageBox.Text;

                string content = "";
                if (name == "" || message == "") {
                    MessageUtil.WarnMessage("全ての項目を記入してください。");
                    return;
                }

                content += $"{win_version}\nEasyOjima-v{app_version}\nguid: {guid}\n\nname:\n  {name}\nmessage:\n  {message}";

                if (type == "バグ報告") {
                    Send(name, content, bug_webhook);
                } else {
                    Send(name, content, req_webhook);
                }

                MessageUtil.InfoMessage("送信しました。\nご協力ありがとうございます。");
                this.Close();

            } catch (WebException) {
                MessageUtil.WarnMessage("送信できませんでした。\nネットワークを確認してください。");
                return;
            } catch (Exception ex) {
                MessageUtil.ErrorMessage(ex.Message);
                return;
            }
        }

        private void Send(string name, string content, string webhook) {
            using (var wb = new WebClient()) {
                var post = new NameValueCollection();
                post.Add("username", $"{name} さん");
                post.Add("content", content);

                wb.UploadValues(webhook, post);
            }
        }

        private void typeBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (typeBox.Text != "バグ報告" && typeBox.Text != "要望") {
                typeBox.Text = "バグ報告";
            }
        }
    }
}
