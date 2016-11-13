﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer
{
    public partial class FormTimer : Form
    {
        int endTime;//終了時間
        int nowTime;//経過時間

        public FormTimer()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

            //時間設定のTextBoxの内容を終了時間に変数に取得
            if (!int.TryParse(textSetTime.Text, out endTime)) //textSetTimeの値をendTimeに代入 出来ない場合は1を代入
            {
                endTime = 1;
            }

            //残り時間を計算するため経過時間に変数を0で初期化
            nowTime = 0;
            //タイマースタート
            timerControl.Start();
        }

        private void timerControl_Tick(object sender, EventArgs e)
        {
            int remainingTime;//残り時間の変数を整数型で定義
            //経過時間に1秒を加える
            nowTime++;
            //残り時間を計算して表示
            remainingTime = endTime - nowTime;
            textRemaingTime.Text = remainingTime.ToString();
            //時間になった？
            if(endTime==nowTime)
            {
                //タイマーを止める
                timerControl.Stop();
                //終了時間になった事を知らせる
                MessageBox.Show("時間になりました");
            }
        }


    }
}
