namespace Os_lab2
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
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBoxWith = new System.Windows.Forms.RichTextBox();
            this.richTextBoxWithout = new System.Windows.Forms.RichTextBox();
            this.textBoxWith = new System.Windows.Forms.TextBox();
            this.labelWith = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxWithout = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(247, 422);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Старт";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // richTextBoxWith
            // 
            this.richTextBoxWith.Location = new System.Drawing.Point(12, 62);
            this.richTextBoxWith.Name = "richTextBoxWith";
            this.richTextBoxWith.Size = new System.Drawing.Size(269, 354);
            this.richTextBoxWith.TabIndex = 1;
            this.richTextBoxWith.Text = "";
            // 
            // richTextBoxWithout
            // 
            this.richTextBoxWithout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxWithout.Location = new System.Drawing.Point(311, 62);
            this.richTextBoxWithout.Name = "richTextBoxWithout";
            this.richTextBoxWithout.Size = new System.Drawing.Size(270, 354);
            this.richTextBoxWithout.TabIndex = 3;
            this.richTextBoxWithout.Text = "";
            // 
            // textBoxWith
            // 
            this.textBoxWith.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxWith.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxWith.Location = new System.Drawing.Point(230, 36);
            this.textBoxWith.Name = "textBoxWith";
            this.textBoxWith.Size = new System.Drawing.Size(48, 13);
            this.textBoxWith.TabIndex = 4;
            // 
            // labelWith
            // 
            this.labelWith.AutoSize = true;
            this.labelWith.Location = new System.Drawing.Point(12, 11);
            this.labelWith.Name = "labelWith";
            this.labelWith.Size = new System.Drawing.Size(244, 13);
            this.labelWith.TabIndex = 5;
            this.labelWith.Text = "Время работы планировщика c блокировками";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Время работы планировщика без блокировок";
            // 
            // textBoxWithout
            // 
            this.textBoxWithout.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxWithout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxWithout.Location = new System.Drawing.Point(311, 36);
            this.textBoxWithout.Name = "textBoxWithout";
            this.textBoxWithout.Size = new System.Drawing.Size(49, 13);
            this.textBoxWithout.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(619, 464);
            this.Controls.Add(this.textBoxWithout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelWith);
            this.Controls.Add(this.textBoxWith);
            this.Controls.Add(this.richTextBoxWithout);
            this.Controls.Add(this.richTextBoxWith);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Планировщик";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBoxWith;
        private System.Windows.Forms.RichTextBox richTextBoxWithout;
        private System.Windows.Forms.TextBox textBoxWith;
        private System.Windows.Forms.Label labelWith;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxWithout;
    }
}

