using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keisan
{
    public partial class Form1 : Form
    {
        public Form1()　
        {
            InitializeComponent();
        }

        //object sender どのオブジェクトから呼ばれたかという情報が渡されている
        //EventArgs e どんな手段で呼ばれたかという情報が入っている。マウスでクリックした場合とEnterキーを押した場合では入っている値が異なる

        private void CalcButton_Click(object sender, EventArgs e)
        {
            int valueLeft;   //入力1用の整数型変数
            int valueRight;  //入力2用の整数型変数
            int valueAnser;  //計算結果用の整数型変数


            valueLeft = int.Parse(Input1TextBox.Text); //入力値1を整数型に変換代入
            valueRight = int.Parse(Input2TextBox.Text); //入力値2を整数型に変換代入
            valueAnser = valueLeft + valueRight; //計算
            //計算結果を出力
            AncwerTextBox.Text = valueAnser.ToString(); //文字列に変換後代入
        }
    }
}
