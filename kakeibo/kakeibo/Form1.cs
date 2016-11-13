using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kakeibo
{
    public partial class Form1 : Form
    {
        //入力ファイル名
        public const String path = "MoneyData.csv";

        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            //型付きデータセットのデータテーブルに「給料」などの分類データを準備する
            /*
             *   分類　入出金分類
             * 0 給料  入金
             * 1 食費  出金
             * 2 雑費  出金
             * 3 住居  出金
             */
            categoryDataSet1.CategoryDataTable.AddCategoryDataTableRow("給料", "入金");
            categoryDataSet1.CategoryDataTable.AddCategoryDataTableRow("食費", "出金");
            categoryDataSet1.CategoryDataTable.AddCategoryDataTableRow("雑費", "出金");
            categoryDataSet1.CategoryDataTable.AddCategoryDataTableRow("住居", "出金");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddData();
        }
        private void 追加AToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddData();
        }

        private void AddData()
        {
            //登録フォーム作成
            ItemForm frmItem = new ItemForm(categoryDataSet1);
            /* 
             * 登録画面のフォームをモーダル画面で表示
             * Windowsフォームの処理結果として、
             * 登録ボタンはOK、キャンセルボタンはCancelが
             * 返される 
             */
            DialogResult drret = frmItem.ShowDialog();
            //登録画面が登録ボタンで閉じられたことを確認
            if (drret == DialogResult.OK)
            {
                /* 
                 * データセットのテーブルの列にデータを追加
                 * 引数は追加する行の各行のデータです。
                 * 今回は登録画面のコントロールの値を取得し、
                 * 引数に設定しています。
                 */
                moneyDataSet.moneyDataTable.AddmoneyDataTableRow(
                    frmItem.monCalender.SelectionRange.Start,
                    frmItem.cmbCategory.Text,
                    frmItem.txtItem.Text,
                    int.Parse(frmItem.mtxtMoney.Text),
                    frmItem.txtRemarks.Text);
            }

        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SaveData()
        {
            //1行分のデータ
            String strData = "";
            /*
             * path:ファイル名 
             * 新規作成か今のファイルに書き込むか false 新規作成
             * System.Text.Encoding.Default 文字コードの種類
             */ 
            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                path,
                false,
                System.Text.Encoding.Default);
            /*
             * 拡張for文
             * レコードの数だけループ
             */
            foreach(MoneyDataSet.moneyDataTableRow drMoney
                    in moneyDataSet.moneyDataTable)
            {
                strData = drMoney.日付.ToShortDateString() + ","
                        + drMoney.分類 + ","
                        + drMoney.品名 + ","
                        + drMoney.金額.ToString() + ","
                        + drMoney.備考;
                //1行分のデータを出力
                sw.WriteLine(strData);
            }
            //ファイルを閉じる
            sw.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        private void LoadData()
        {
            //区切り文字
            string delimStr = ",";
            //区切り文字をまとめる
            char[] delimiter = delimStr.ToCharArray();
            //分解後の文字の入れ物
            string[] strData;
            //1行分のデータ
            string strLine;
            //ファイルが存在するか確認する
            bool fileExists = System.IO.File.Exists(path);
            if(fileExists)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(
                                                path,
                                                System.Text.Encoding.Default);
                /*
                 * Peek() 読み取り可能な文字があるかを調べる
                 * -1がかえってくるとファイルにデータがない
                 */
                while(sr.Peek() >= 0)
                {
                    //1行読み込む
                    strLine = sr.ReadLine();
                    //区切り文字ごとに分解する
                    strData = strLine.Split(delimiter);
                    //データテーブルの列に値を挿入する
                    moneyDataSet.moneyDataTable.AddmoneyDataTableRow(
                                                DateTime.Parse(strData[0]),
                                                strData[1],
                                                strData[2],
                                                int.Parse(strData[3]),
                                                strData[4]);
                }
                sr.Close();
            }
        }
        private void UpdateData()
        {
            /*
             * 現在選択されているDataGridView
             * コントロールの行を取得します
             */
            int nowRow = dgv.CurrentRow.Index;
            /*
             * 変更前のデータは、DataGridViewコントロールから
             * 取得しています。dgv.CurrentRow.Indexで取得した
             * 行のn番目の列の値を取得・設定しています。
             */
            DateTime oldDate
                = DateTime.Parse(dgv.Rows[nowRow].Cells[0].Value.ToString());
            string oldCategory = dgv.Rows[nowRow].Cells[1].Value.ToString();
            string oldItem = dgv.Rows[nowRow].Cells[2].Value.ToString();
            int oldMoney
                = int.Parse(dgv.Rows[nowRow].Cells[3].Value.ToString());
            string oldRemarks = dgv.Rows[nowRow].Cells[4].Value.ToString();
            /*
             * ItemFormメソッドのコンストラクタに
             * 6つの引数を渡してインスタンスを生成します
             */
            ItemForm frmItem = new ItemForm(categoryDataSet1,
                                            oldDate,
                                            oldCategory,
                                            oldItem,
                                            oldMoney,
                                            oldRemarks);
            /*
             * 登録画面で登録ボタンがクリックされた
             * 場合の処理を指定します
             */
            DialogResult drRet = frmItem.ShowDialog();
            if(drRet==DialogResult.OK)
            {
                /*
                 * DataGridViewコントロールの1列目から
                 * 5列目に値を設定します
                 */
                dgv.Rows[nowRow].Cells[0].Value
                    = frmItem.monCalender.SelectionRange.Start;
                dgv.Rows[nowRow].Cells[1].Value = frmItem.cmbCategory.Text;
                dgv.Rows[nowRow].Cells[2].Value = frmItem.txtItem.Text;
                dgv.Rows[nowRow].Cells[3].Value = int.Parse(frmItem.mtxtMoney.Text);
                dgv.Rows[nowRow].Cells[4].Value = frmItem.txtRemarks.Text;
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void 変更CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateData();
        }
        private void DeleteData()
        {
            /*
             * 現在選択されているDataGridView
             * コントロールの行を取得します
             */
            int nowRow = dgv.CurrentRow.Index;
            /*
             * RemoveAt()メソッドで変数nowRowで示されている
             * DataGridViewコントロールの行を消去します
             */
            dgv.Rows.RemoveAt(nowRow);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void 削除DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteData();
        }



    }
}
