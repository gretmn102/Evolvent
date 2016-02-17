namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbT1 = new System.Windows.Forms.RadioButton();
            this.rbT2 = new System.Windows.Forms.RadioButton();
            this.chkComma = new System.Windows.Forms.CheckBox();
            this.cmbQual = new System.Windows.Forms.ComboBox();
            this.txbRange = new System.Windows.Forms.TextBox();
            this.txbT11 = new System.Windows.Forms.TextBox();
            this.txbT21 = new System.Windows.Forms.TextBox();
            this.txbT12 = new System.Windows.Forms.TextBox();
            this.txbT22 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txbOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rbT1
            // 
            this.rbT1.AutoSize = true;
            this.rbT1.Checked = true;
            this.rbT1.Location = new System.Drawing.Point(252, 15);
            this.rbT1.Name = "rbT1";
            this.rbT1.Size = new System.Drawing.Size(14, 13);
            this.rbT1.TabIndex = 3;
            this.rbT1.TabStop = true;
            this.rbT1.UseVisualStyleBackColor = true;
            // 
            // rbT2
            // 
            this.rbT2.AutoSize = true;
            this.rbT2.Location = new System.Drawing.Point(354, 15);
            this.rbT2.Name = "rbT2";
            this.rbT2.Size = new System.Drawing.Size(14, 13);
            this.rbT2.TabIndex = 2;
            this.rbT2.UseVisualStyleBackColor = true;
            // 
            // chkComma
            // 
            this.chkComma.AutoSize = true;
            this.chkComma.Location = new System.Drawing.Point(383, 14);
            this.chkComma.Name = "chkComma";
            this.chkComma.Size = new System.Drawing.Size(29, 17);
            this.chkComma.TabIndex = 5;
            this.chkComma.TabStop = false;
            this.chkComma.Text = ",";
            this.chkComma.UseVisualStyleBackColor = true;
            this.chkComma.CheckedChanged += new System.EventHandler(this.chkTable_CheckedChanged);
            // 
            // cmbQual
            // 
            this.cmbQual.FormattingEnabled = true;
            this.cmbQual.Location = new System.Drawing.Point(52, 12);
            this.cmbQual.Name = "cmbQual";
            this.cmbQual.Size = new System.Drawing.Size(100, 21);
            this.cmbQual.TabIndex = 2;
            // 
            // txbRange
            // 
            this.txbRange.Location = new System.Drawing.Point(2, 12);
            this.txbRange.Name = "txbRange";
            this.txbRange.Size = new System.Drawing.Size(45, 20);
            this.txbRange.TabIndex = 1;
            // 
            // txbT11
            // 
            this.txbT11.Location = new System.Drawing.Point(170, 12);
            this.txbT11.Name = "txbT11";
            this.txbT11.ReadOnly = true;
            this.txbT11.Size = new System.Drawing.Size(35, 20);
            this.txbT11.TabIndex = 11;
            // 
            // txbT21
            // 
            this.txbT21.Location = new System.Drawing.Point(272, 12);
            this.txbT21.Name = "txbT21";
            this.txbT21.ReadOnly = true;
            this.txbT21.Size = new System.Drawing.Size(35, 20);
            this.txbT21.TabIndex = 12;
            this.txbT21.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txbT12
            // 
            this.txbT12.Location = new System.Drawing.Point(211, 12);
            this.txbT12.Name = "txbT12";
            this.txbT12.ReadOnly = true;
            this.txbT12.Size = new System.Drawing.Size(35, 20);
            this.txbT12.TabIndex = 13;
            // 
            // txbT22
            // 
            this.txbT22.Location = new System.Drawing.Point(313, 12);
            this.txbT22.Name = "txbT22";
            this.txbT22.ReadOnly = true;
            this.txbT22.Size = new System.Drawing.Size(35, 20);
            this.txbT22.TabIndex = 14;
            this.txbT22.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(418, 14);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txbOutput
            // 
            this.txbOutput.Location = new System.Drawing.Point(2, 39);
            this.txbOutput.Name = "txbOutput";
            this.txbOutput.ReadOnly = true;
            this.txbOutput.Size = new System.Drawing.Size(169, 20);
            this.txbOutput.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 34);
            this.Controls.Add(this.txbOutput);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txbT22);
            this.Controls.Add(this.txbT12);
            this.Controls.Add(this.txbT21);
            this.Controls.Add(this.txbT11);
            this.Controls.Add(this.txbRange);
            this.Controls.Add(this.cmbQual);
            this.Controls.Add(this.chkComma);
            this.Controls.Add(this.rbT2);
            this.Controls.Add(this.rbT1);
            this.Name = "Form1";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RadioButton rbT1;
        public System.Windows.Forms.RadioButton rbT2;
        public System.Windows.Forms.CheckBox chkComma;
        public System.Windows.Forms.ComboBox cmbQual;
        public System.Windows.Forms.TextBox txbRange;
        public System.Windows.Forms.TextBox txbT11;
        public System.Windows.Forms.TextBox txbT21;
        public System.Windows.Forms.TextBox txbT12;
        public System.Windows.Forms.TextBox txbT22;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.TextBox txbOutput;
    }
}

