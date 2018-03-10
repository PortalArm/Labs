namespace WindowsFormsApp1
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
            this.DictBox = new System.Windows.Forms.TextBox();
            this.Dictlabel = new System.Windows.Forms.Label();
            this.SC1_1label = new System.Windows.Forms.Label();
            this.SC2_1label = new System.Windows.Forms.Label();
            this.SC1_1 = new System.Windows.Forms.TextBox();
            this.SC2_1 = new System.Windows.Forms.TextBox();
            this.FirstBox = new System.Windows.Forms.TextBox();
            this.Firstlabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Oplabel = new System.Windows.Forms.Label();
            this.Secondlabel = new System.Windows.Forms.Label();
            this.SecondBox = new System.Windows.Forms.TextBox();
            this.SC1_2 = new System.Windows.Forms.TextBox();
            this.SC1_2label = new System.Windows.Forms.Label();
            this.ResultBox = new System.Windows.Forms.TextBox();
            this.Resultlabel = new System.Windows.Forms.Label();
            this.SCR = new System.Windows.Forms.TextBox();
            this.SCRlabel = new System.Windows.Forms.Label();
            this.Resultbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DictBox
            // 
            this.DictBox.Location = new System.Drawing.Point(165, 6);
            this.DictBox.Name = "DictBox";
            this.DictBox.Size = new System.Drawing.Size(200, 20);
            this.DictBox.TabIndex = 0;
            this.DictBox.Text = "0123456789abcdef";
            // 
            // Dictlabel
            // 
            this.Dictlabel.AutoSize = true;
            this.Dictlabel.Location = new System.Drawing.Point(12, 9);
            this.Dictlabel.Name = "Dictlabel";
            this.Dictlabel.Size = new System.Drawing.Size(147, 13);
            this.Dictlabel.TabIndex = 12;
            this.Dictlabel.Text = "Алфавит систем счисления";
            // 
            // SC1_1label
            // 
            this.SC1_1label.AutoSize = true;
            this.SC1_1label.Location = new System.Drawing.Point(259, 61);
            this.SC1_1label.Name = "SC1_1label";
            this.SC1_1label.Size = new System.Drawing.Size(21, 13);
            this.SC1_1label.TabIndex = 2;
            this.SC1_1label.Text = "Из";
            // 
            // SC2_1label
            // 
            this.SC2_1label.AutoSize = true;
            this.SC2_1label.Location = new System.Drawing.Point(319, 61);
            this.SC2_1label.Name = "SC2_1label";
            this.SC2_1label.Size = new System.Drawing.Size(13, 13);
            this.SC2_1label.TabIndex = 3;
            this.SC2_1label.Text = "в";
            // 
            // SC1_1
            // 
            this.SC1_1.Location = new System.Drawing.Point(286, 58);
            this.SC1_1.Name = "SC1_1";
            this.SC1_1.Size = new System.Drawing.Size(27, 20);
            this.SC1_1.TabIndex = 5;
            // 
            // SC2_1
            // 
            this.SC2_1.Location = new System.Drawing.Point(338, 58);
            this.SC2_1.Name = "SC2_1";
            this.SC2_1.Size = new System.Drawing.Size(27, 20);
            this.SC2_1.TabIndex = 6;
            // 
            // FirstBox
            // 
            this.FirstBox.Location = new System.Drawing.Point(141, 58);
            this.FirstBox.Name = "FirstBox";
            this.FirstBox.Size = new System.Drawing.Size(111, 20);
            this.FirstBox.TabIndex = 4;
            // 
            // Firstlabel
            // 
            this.Firstlabel.AutoSize = true;
            this.Firstlabel.Location = new System.Drawing.Point(12, 61);
            this.Firstlabel.Name = "Firstlabel";
            this.Firstlabel.Size = new System.Drawing.Size(123, 13);
            this.Firstlabel.TabIndex = 14;
            this.Firstlabel.Text = "Введите первое число:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Сложение",
            "Вычитание",
            "Деление",
            "Умножение",
            "Перевод"});
            this.comboBox1.Location = new System.Drawing.Point(131, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Oplabel
            // 
            this.Oplabel.AutoSize = true;
            this.Oplabel.Location = new System.Drawing.Point(12, 34);
            this.Oplabel.Name = "Oplabel";
            this.Oplabel.Size = new System.Drawing.Size(113, 13);
            this.Oplabel.TabIndex = 19;
            this.Oplabel.Text = "Выберите операцию:";
            // 
            // Secondlabel
            // 
            this.Secondlabel.AutoSize = true;
            this.Secondlabel.Location = new System.Drawing.Point(12, 87);
            this.Secondlabel.Name = "Secondlabel";
            this.Secondlabel.Size = new System.Drawing.Size(122, 13);
            this.Secondlabel.TabIndex = 15;
            this.Secondlabel.Text = "Введите второе число:";
            // 
            // SecondBox
            // 
            this.SecondBox.Location = new System.Drawing.Point(141, 84);
            this.SecondBox.Name = "SecondBox";
            this.SecondBox.Size = new System.Drawing.Size(111, 20);
            this.SecondBox.TabIndex = 7;
            // 
            // SC1_2
            // 
            this.SC1_2.Location = new System.Drawing.Point(286, 84);
            this.SC1_2.Name = "SC1_2";
            this.SC1_2.Size = new System.Drawing.Size(27, 20);
            this.SC1_2.TabIndex = 8;
            // 
            // SC1_2label
            // 
            this.SC1_2label.AutoSize = true;
            this.SC1_2label.Location = new System.Drawing.Point(259, 87);
            this.SC1_2label.Name = "SC1_2label";
            this.SC1_2label.Size = new System.Drawing.Size(14, 13);
            this.SC1_2label.TabIndex = 10;
            this.SC1_2label.Text = "В";
            // 
            // ResultBox
            // 
            this.ResultBox.Location = new System.Drawing.Point(80, 110);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.ReadOnly = true;
            this.ResultBox.Size = new System.Drawing.Size(172, 20);
            this.ResultBox.TabIndex = 16;
            // 
            // Resultlabel
            // 
            this.Resultlabel.AutoSize = true;
            this.Resultlabel.Location = new System.Drawing.Point(12, 113);
            this.Resultlabel.Name = "Resultlabel";
            this.Resultlabel.Size = new System.Drawing.Size(62, 13);
            this.Resultlabel.TabIndex = 17;
            this.Resultlabel.Text = "Результат:";
            // 
            // SCR
            // 
            this.SCR.Location = new System.Drawing.Point(286, 110);
            this.SCR.Name = "SCR";
            this.SCR.Size = new System.Drawing.Size(27, 20);
            this.SCR.TabIndex = 9;
            // 
            // SCRlabel
            // 
            this.SCRlabel.AutoSize = true;
            this.SCRlabel.Location = new System.Drawing.Point(259, 113);
            this.SCRlabel.Name = "SCRlabel";
            this.SCRlabel.Size = new System.Drawing.Size(14, 13);
            this.SCRlabel.TabIndex = 18;
            this.SCRlabel.Text = "В";
            // 
            // Resultbutton
            // 
            this.Resultbutton.Location = new System.Drawing.Point(15, 136);
            this.Resultbutton.Name = "Resultbutton";
            this.Resultbutton.Size = new System.Drawing.Size(237, 23);
            this.Resultbutton.TabIndex = 20;
            this.Resultbutton.Text = "Посчитать";
            this.Resultbutton.UseVisualStyleBackColor = true;
            this.Resultbutton.Click += new System.EventHandler(this.Resultbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 169);
            this.Controls.Add(this.Resultbutton);
            this.Controls.Add(this.SCR);
            this.Controls.Add(this.SCRlabel);
            this.Controls.Add(this.Resultlabel);
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.Secondlabel);
            this.Controls.Add(this.SecondBox);
            this.Controls.Add(this.SC1_2);
            this.Controls.Add(this.SC1_2label);
            this.Controls.Add(this.Oplabel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Firstlabel);
            this.Controls.Add(this.FirstBox);
            this.Controls.Add(this.SC2_1);
            this.Controls.Add(this.SC1_1);
            this.Controls.Add(this.SC2_1label);
            this.Controls.Add(this.SC1_1label);
            this.Controls.Add(this.Dictlabel);
            this.Controls.Add(this.DictBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DictBox;
        private System.Windows.Forms.Label Dictlabel;
        private System.Windows.Forms.Label SC1_1label;
        private System.Windows.Forms.Label SC2_1label;
        private System.Windows.Forms.TextBox SC1_1;
        private System.Windows.Forms.TextBox SC2_1;
        private System.Windows.Forms.TextBox FirstBox;
        private System.Windows.Forms.Label Firstlabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label Oplabel;
        private System.Windows.Forms.Label Secondlabel;
        private System.Windows.Forms.TextBox SecondBox;
        private System.Windows.Forms.TextBox SC1_2;
        private System.Windows.Forms.Label SC1_2label;
        private System.Windows.Forms.TextBox ResultBox;
        private System.Windows.Forms.Label Resultlabel;
        private System.Windows.Forms.TextBox SCR;
        private System.Windows.Forms.Label SCRlabel;
        private System.Windows.Forms.Button Resultbutton;
    }
}

