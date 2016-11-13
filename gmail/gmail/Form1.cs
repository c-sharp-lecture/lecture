﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gmail
{
    public partial class FormGMailCheck : Form
    {
        private int count = -1;
        public FormGMailCheck()
        {
            InitializeComponent();
        }

        private void butStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true; //タイマー実行

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            OpenPop.Pop3.Pop3Client client = new OpenPop.Pop3.Pop3Client();

            client.Connect("pop.gmail.com", 995, true);

            client.Authenticate(txtAddress.Text, txtPassword.Text);

            int messageCount = client.GetMessageCount();
            if (count == -1)
            {
                count = messageCount;
            }

            for (int i = messageCount; i > count; i--)
            {
                txtNewMail.Text += client.GetMessage(i).Headers.Subject + "\r\n";
                notifyIcon1.BalloonTipTitle = "メールが届きました";
                notifyIcon1.BalloonTipText = client.GetMessage(i).Headers.Subject;
                notifyIcon1.ShowBalloonTip(3000); //指定した時間だけ表示
            }

            count = messageCount;
        }
    }
}
