namespace Keisan
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.Input1TextBox = new System.Windows.Forms.TextBox();
            this.PlusLabel = new System.Windows.Forms.Label();
            this.Input2TextBox = new System.Windows.Forms.TextBox();
            this.EquallLabel = new System.Windows.Forms.Label();
            this.AncwerTextBox = new System.Windows.Forms.TextBox();
            this.CalcButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Input1TextBox
            // 
            this.Input1TextBox.Location = new System.Drawing.Point(-3, 12);
            this.Input1TextBox.Name = "Input1TextBox";
            this.Input1TextBox.Size = new System.Drawing.Size(100, 19);
            this.Input1TextBox.TabIndex = 0;
            // 
            // PlusLabel
            // 
            this.PlusLabel.AutoSize = true;
            this.PlusLabel.Location = new System.Drawing.Point(104, 12);
            this.PlusLabel.Name = "PlusLabel";
            this.PlusLabel.Size = new System.Drawing.Size(11, 12);
            this.PlusLabel.TabIndex = 1;
            this.PlusLabel.Text = "+";
            // 
            // Input2TextBox
            // 
            this.Input2TextBox.Location = new System.Drawing.Point(121, 12);
            this.Input2TextBox.Name = "Input2TextBox";
            this.Input2TextBox.Size = new System.Drawing.Size(100, 19);
            this.Input2TextBox.TabIndex = 2;
            // 
            // EquallLabel
            // 
            this.EquallLabel.AutoSize = true;
            this.EquallLabel.Location = new System.Drawing.Point(228, 13);
            this.EquallLabel.Name = "EquallLabel";
            this.EquallLabel.Size = new System.Drawing.Size(11, 12);
            this.EquallLabel.TabIndex = 3;
            this.EquallLabel.Text = "=";
            // 
            // AncwerTextBox
            // 
            this.AncwerTextBox.Location = new System.Drawing.Point(245, 10);
            this.AncwerTextBox.Name = "AncwerTextBox";
            this.AncwerTextBox.Size = new System.Drawing.Size(100, 19);
            this.AncwerTextBox.TabIndex = 4;
            // 
            // CalcButton
            // 
            this.CalcButton.Location = new System.Drawing.Point(-3, 38);
            this.CalcButton.Name = "CalcButton";
            this.CalcButton.Size = new System.Drawing.Size(348, 29);
            this.CalcButton.TabIndex = 5;
            this.CalcButton.Text = "計算する";
            this.CalcButton.UseVisualStyleBackColor = true;
            this.CalcButton.Click += new System.EventHandler(this.CalcButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 79);
            this.Controls.Add(this.CalcButton);
            this.Controls.Add(this.AncwerTextBox);
            this.Controls.Add(this.EquallLabel);
            this.Controls.Add(this.Input2TextBox);
            this.Controls.Add(this.PlusLabel);
            this.Controls.Add(this.Input1TextBox);
            this.Name = "Form1";
            this.Text = "簡単計算プログラム";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Input1TextBox;
        private System.Windows.Forms.Label PlusLabel;
        private System.Windows.Forms.TextBox Input2TextBox;
        private System.Windows.Forms.Label EquallLabel;
        private System.Windows.Forms.TextBox AncwerTextBox;
        private System.Windows.Forms.Button CalcButton;
    }
}

