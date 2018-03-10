using System;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }
        //Вывод переданной ошибки.
        public Form2(string info)
        {
            InitializeComponent();
            label2.Text = info;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
