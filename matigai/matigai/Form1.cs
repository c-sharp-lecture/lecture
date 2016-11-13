using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace matigai
{
    public partial class FormGame : Form
    {
        string correctText = "萩"; //正解の文字
        string mistakeText = "荻"; //間違いの文字
        double nowTime; //経過時間
        public FormGame()
        {
            InitializeComponent();
        }

        //画面下部の25個のボタンのいずれかをクリックしたとき(共通で呼ばれる)
        private void buttons_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == correctText) //押されたボタンのテキストが合っているかどうか
            {
                timer1.Stop();
            }
            else
            {
                nowTime = nowTime + 10; //ペナルティ
            }

        }
        // スタートボタンをクリックしたとき
        private void buttonStart_Click(object sender, EventArgs e)
        {
            textHunt.Text = correctText;  //探す文字を表示
            Random rnd = new System.Random(); // 乱数を生成するためのインスタンスを生成
            int randomResult = rnd.Next(25); //0～24の乱数を取得

            //splitContainerの下部のPanel2に乗っている
            //ButtonのTextを全て間違いの文字にする
            //splitContainer1.Panel2.Controls.Count Panelコントロールの上に乗っているコントロールの数分 25
            for (int i = 0; i < splitContainer1.Panel2.Controls.Count; i++) 
            {
                splitContainer1.Panel2.Controls[i].Text = mistakeText; //パネルに乗っているコントロールのi番目のテキストに間違いの文字を設定
            }
            //ランダムで1つだけ正解の文字にする。
            splitContainer1.Panel2.Controls[randomResult].Text = correctText;

            //タイマースタート
            nowTime = 0; //タイマー初期化
            timer1.Start();
        }

        //0.02秒置きに呼ばれるタイマーのイベントハンドラ
        private void timer1_Tick(object sender, EventArgs e)
        {
            nowTime = nowTime + 0.02;
            textTimer.Text = nowTime.ToString("0.00"); //少数部2桁を表示 ToStringの引数で表示する形式を指定
        }









    }
}
