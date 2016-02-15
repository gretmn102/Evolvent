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
            this.lblRange = new System.Windows.Forms.Label();
            this.rbPoint = new System.Windows.Forms.RadioButton();
            this.rbComma = new System.Windows.Forms.RadioButton();
            this.chkTable = new System.Windows.Forms.CheckBox();
            this.cmbQual = new System.Windows.Forms.ComboBox();
            this.txbRange = new System.Windows.Forms.TextBox();
            this.lblQual = new System.Windows.Forms.Label();
            this.btn = new System.Windows.Forms.Button();
            this.txbOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblRange
            // 
            this.lblRange.AutoSize = true;
            this.lblRange.Location = new System.Drawing.Point(9, 18);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(46, 13);
            this.lblRange.TabIndex = 0;
            this.lblRange.Text = "Размер";
            // 
            // rbPoint
            // 
            this.rbPoint.AutoSize = true;
            this.rbPoint.Checked = true;
            this.rbPoint.Location = new System.Drawing.Point(12, 111);
            this.rbPoint.Name = "rbPoint";
            this.rbPoint.Size = new System.Drawing.Size(132, 17);
            this.rbPoint.TabIndex = 3;
            this.rbPoint.Text = "Разделитель \"точка\"";
            this.rbPoint.UseVisualStyleBackColor = true;
            // 
            // rbComma
            // 
            this.rbComma.AutoSize = true;
            this.rbComma.Location = new System.Drawing.Point(12, 134);
            this.rbComma.Name = "rbComma";
            this.rbComma.Size = new System.Drawing.Size(145, 17);
            this.rbComma.TabIndex = 2;
            this.rbComma.Text = "Разделитель \"запятая\"";
            this.rbComma.UseVisualStyleBackColor = true;
            // 
            // chkTable
            // 
            this.chkTable.AutoSize = true;
            this.chkTable.Location = new System.Drawing.Point(12, 88);
            this.chkTable.Name = "chkTable";
            this.chkTable.Size = new System.Drawing.Size(102, 17);
            this.chkTable.TabIndex = 5;
            this.chkTable.TabStop = false;
            this.chkTable.Text = "Новая таблица";
            this.chkTable.UseVisualStyleBackColor = true;
            // 
            // cmbQual
            // 
            this.cmbQual.FormattingEnabled = true;
            this.cmbQual.Location = new System.Drawing.Point(69, 51);
            this.cmbQual.Name = "cmbQual";
            this.cmbQual.Size = new System.Drawing.Size(100, 21);
            this.cmbQual.TabIndex = 2;
            // 
            // txbRange
            // 
            this.txbRange.Location = new System.Drawing.Point(69, 15);
            this.txbRange.Name = "txbRange";
            this.txbRange.Size = new System.Drawing.Size(100, 20);
            this.txbRange.TabIndex = 1;
            // 
            // lblQual
            // 
            this.lblQual.AutoSize = true;
            this.lblQual.Location = new System.Drawing.Point(9, 54);
            this.lblQual.Name = "lblQual";
            this.lblQual.Size = new System.Drawing.Size(54, 13);
            this.lblQual.TabIndex = 8;
            this.lblQual.Text = "Квалитет";
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(162, 105);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(75, 23);
            this.btn.TabIndex = 9;
            this.btn.TabStop = false;
            this.btn.Text = "Вывод";
            this.btn.UseVisualStyleBackColor = true;
            // 
            // txbOutput
            // 
            this.txbOutput.Location = new System.Drawing.Point(12, 161);
            this.txbOutput.Name = "txbOutput";
            this.txbOutput.Size = new System.Drawing.Size(225, 20);
            this.txbOutput.TabIndex = 10;
            this.txbOutput.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 193);
            this.Controls.Add(this.txbOutput);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.lblQual);
            this.Controls.Add(this.txbRange);
            this.Controls.Add(this.cmbQual);
            this.Controls.Add(this.chkTable);
            this.Controls.Add(this.rbComma);
            this.Controls.Add(this.rbPoint);
            this.Controls.Add(this.lblRange);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblRange;
        public System.Windows.Forms.RadioButton rbPoint;
        public System.Windows.Forms.RadioButton rbComma;
        public System.Windows.Forms.CheckBox chkTable;
        public System.Windows.Forms.ComboBox cmbQual;
        public System.Windows.Forms.TextBox txbRange;
        public System.Windows.Forms.Label lblQual;
        public System.Windows.Forms.Button btn;
        public System.Windows.Forms.TextBox txbOutput;
    }
}

