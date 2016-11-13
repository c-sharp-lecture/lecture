using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memo
{
    public partial class FormFusen : Form
    { 

        private int mouseX; //マウスの横位置(x座標)
        private int mouseY; //マウスの縦位置(y座標)
        public FormFusen()
        {
            InitializeComponent();
        }

        //テキストボックスにキーボードから文字を入力したとき
        private void textFusenMemo_KeyDown(object sender, KeyEventArgs e)
        {

            //押されたキーがエスケープキー？
            if(e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }
        //テキストボックスをマウスでクリックしたとき
        private void textFusenMemo_MouseDown(object sender, MouseEventArgs e)
        {
            //押されたボタンがマウスの左ボタン？
            if (e.Button == MouseButtons.Left)
            {
                this.mouseX = e.X; //　マウスの横位置(X座標)を記憶
                this.mouseY = e.Y; // マウスの縦位置(Y座標)を記憶
            }

        }
        //テキストボックスでクリックしたマウスを移動させたとき
        private void textFusenMemo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //新しいFormコントロールの位置=古いFormコントロール位置+マウスの移動距離
                //マウスの移動距離=新しいマウスの位置-古いマウスの位置 e.X-mouseX
                this.Left += e.X - mouseX;//フォームの横位置を更新
                this.Top += e.Y - mouseY;//フォームの縦位置を更新
            }

        }
        //テキストボックスをマウスでダブルクリックしたとき
        private void textFusenMemo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //色の設定ダイアログを表示する
            colorDialogFusen.ShowDialog();
            //テキストボックスぼ背景色を色の設定ダイアログで選んだ色に設定する
            textFusenMemo.BackColor = colorDialogFusen.Color;

        }
    }
}
