namespace GUI
{
    partial class MainForm
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
            this.chkStyle = new System.Windows.Forms.CheckBox();
            this.txbOutput = new System.Windows.Forms.TextBox();
            this.chkManual = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnStyle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbT1
            // 
            this.rbT1.AutoSize = true;
            this.rbT1.Checked = true;
            this.rbT1.Location = new System.Drawing.Point(330, 12);
            this.rbT1.Name = "rbT1";
            this.rbT1.Size = new System.Drawing.Size(14, 13);
            this.rbT1.TabIndex = 3;
            this.rbT1.TabStop = true;
            this.rbT1.UseVisualStyleBackColor = true;
            // 
            // rbT2
            // 
            this.rbT2.AutoSize = true;
            this.rbT2.Location = new System.Drawing.Point(438, 12);
            this.rbT2.Name = "rbT2";
            this.rbT2.Size = new System.Drawing.Size(14, 13);
            this.rbT2.TabIndex = 2;
            this.rbT2.UseVisualStyleBackColor = true;
            // 
            // chkComma
            // 
            this.chkComma.AutoSize = true;
            this.chkComma.Location = new System.Drawing.Point(460, 11);
            this.chkComma.Name = "chkComma";
            this.chkComma.Size = new System.Drawing.Size(15, 14);
            this.chkComma.TabIndex = 5;
            this.chkComma.TabStop = false;
            this.chkComma.UseVisualStyleBackColor = true;
            // 
            // cmbQual
            // 
            this.cmbQual.Font = new System.Drawing.Font("DejaVu Sans Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbQual.FormattingEnabled = true;
            this.cmbQual.Location = new System.Drawing.Point(102, 7);
            this.cmbQual.MaxDropDownItems = 50;
            this.cmbQual.Name = "cmbQual";
            this.cmbQual.Size = new System.Drawing.Size(136, 21);
            this.cmbQual.TabIndex = 2;
            // 
            // txbRange
            // 
            this.txbRange.Location = new System.Drawing.Point(49, 7);
            this.txbRange.Name = "txbRange";
            this.txbRange.Size = new System.Drawing.Size(45, 20);
            this.txbRange.TabIndex = 1;
            // 
            // txbT11
            // 
            this.txbT11.Location = new System.Drawing.Point(244, 8);
            this.txbT11.Name = "txbT11";
            this.txbT11.ReadOnly = true;
            this.txbT11.Size = new System.Drawing.Size(35, 20);
            this.txbT11.TabIndex = 11;
            // 
            // txbT21
            // 
            this.txbT21.Location = new System.Drawing.Point(352, 8);
            this.txbT21.Name = "txbT21";
            this.txbT21.ReadOnly = true;
            this.txbT21.Size = new System.Drawing.Size(35, 20);
            this.txbT21.TabIndex = 12;
            // 
            // txbT12
            // 
            this.txbT12.Location = new System.Drawing.Point(287, 8);
            this.txbT12.Name = "txbT12";
            this.txbT12.ReadOnly = true;
            this.txbT12.Size = new System.Drawing.Size(35, 20);
            this.txbT12.TabIndex = 13;
            // 
            // txbT22
            // 
            this.txbT22.Location = new System.Drawing.Point(395, 8);
            this.txbT22.Name = "txbT22";
            this.txbT22.ReadOnly = true;
            this.txbT22.Size = new System.Drawing.Size(35, 20);
            this.txbT22.TabIndex = 14;
            // 
            // chkStyle
            // 
            this.chkStyle.AutoSize = true;
            this.chkStyle.Location = new System.Drawing.Point(483, 11);
            this.chkStyle.Name = "chkStyle";
            this.chkStyle.Size = new System.Drawing.Size(15, 14);
            this.chkStyle.TabIndex = 15;
            this.chkStyle.UseVisualStyleBackColor = true;
            // 
            // txbOutput
            // 
            this.txbOutput.Location = new System.Drawing.Point(6, 33);
            this.txbOutput.Name = "txbOutput";
            this.txbOutput.ReadOnly = true;
            this.txbOutput.Size = new System.Drawing.Size(169, 20);
            this.txbOutput.TabIndex = 16;
            // 
            // chkManual
            // 
            this.chkManual.AutoSize = true;
            this.chkManual.Location = new System.Drawing.Point(506, 11);
            this.chkManual.Name = "chkManual";
            this.chkManual.Size = new System.Drawing.Size(15, 14);
            this.chkManual.TabIndex = 17;
            this.chkManual.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "-",
            "Ø",
            "R",
            "M"});
            this.comboBox1.Location = new System.Drawing.Point(6, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(35, 21);
            this.comboBox1.TabIndex = 18;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(529, 8);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(89, 21);
            this.comboBox2.TabIndex = 19;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(624, 9);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(20, 18);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStyle
            // 
            this.btnStyle.Location = new System.Drawing.Point(529, 33);
            this.btnStyle.Name = "btnStyle";
            this.btnStyle.Size = new System.Drawing.Size(75, 23);
            this.btnStyle.TabIndex = 21;
            this.btnStyle.Text = "Color";
            this.btnStyle.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(655, 63);
            this.Controls.Add(this.btnStyle);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chkManual);
            this.Controls.Add(this.txbOutput);
            this.Controls.Add(this.chkStyle);
            this.Controls.Add(this.txbT22);
            this.Controls.Add(this.txbT12);
            this.Controls.Add(this.txbT21);
            this.Controls.Add(this.txbT11);
            this.Controls.Add(this.txbRange);
            this.Controls.Add(this.cmbQual);
            this.Controls.Add(this.chkComma);
            this.Controls.Add(this.rbT2);
            this.Controls.Add(this.rbT1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = " ";
            this.Load += new System.EventHandler(this.MainForm_Load);
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
        public System.Windows.Forms.CheckBox chkStyle;
        public System.Windows.Forms.TextBox txbOutput;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.CheckBox chkManual;
        private System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.ColorDialog colorDialog1;
        public System.Windows.Forms.Button btnStyle;
    }
}

