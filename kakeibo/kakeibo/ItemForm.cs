﻿using System;
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
    public partial class ItemForm : Form
    {
        private ItemForm()
        {
       
        }
        public ItemForm(CategoryDataSet dsCategory)
        {
            InitializeComponent();
            /* 引数の値を、分類コンボボックスにひも付いている
             * データセットに代入します。
            */
            categoryDataSet.Merge(dsCategory);
        }
        public ItemForm(CategoryDataSet dsCategory,
                        DateTime nowDate,
                        string category,
                        string item,
                        int money,
                        string remarks)
        {
            InitializeComponent();
            categoryDataSet.Merge(dsCategory);
            monCalender.SetDate(nowDate);
            cmbCategory.Text = category;
            txtItem.Text = item;
            mtxtMoney.Text = money.ToString();
            txtRemarks.Text = remarks;
        }



    }
}
