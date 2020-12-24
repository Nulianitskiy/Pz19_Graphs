namespace Pz19_1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Calculation = new System.Windows.Forms.Button();
            this.tb_q = new System.Windows.Forms.TextBox();
            this.tb_p = new System.Windows.Forms.TextBox();
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Calculation
            // 
            this.Calculation.Location = new System.Drawing.Point(203, 6);
            this.Calculation.Name = "Calculation";
            this.Calculation.Size = new System.Drawing.Size(75, 26);
            this.Calculation.TabIndex = 0;
            this.Calculation.Text = "Вычислить";
            this.Calculation.UseVisualStyleBackColor = true;
            this.Calculation.Click += new System.EventHandler(this.Calculation_Click);
            // 
            // tb_q
            // 
            this.tb_q.Location = new System.Drawing.Point(137, 12);
            this.tb_q.Name = "tb_q";
            this.tb_q.Size = new System.Drawing.Size(46, 20);
            this.tb_q.TabIndex = 1;
            // 
            // tb_p
            // 
            this.tb_p.Location = new System.Drawing.Point(47, 11);
            this.tb_p.Name = "tb_p";
            this.tb_p.Size = new System.Drawing.Size(46, 20);
            this.tb_p.TabIndex = 2;
            // 
            // rtb
            // 
            this.rtb.Enabled = false;
            this.rtb.Location = new System.Drawing.Point(-1, 34);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(289, 63);
            this.rtb.TabIndex = 3;
            this.rtb.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "(p =         ,q =        )";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 97);
            this.Controls.Add(this.Calculation);
            this.Controls.Add(this.tb_q);
            this.Controls.Add(this.tb_p);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtb);
            this.Name = "Form1";
            this.Text = "Pz19_1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Calculation;
        private System.Windows.Forms.TextBox tb_q;
        private System.Windows.Forms.TextBox tb_p;
        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.Label label1;
    }
}

