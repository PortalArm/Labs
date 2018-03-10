using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;

        }

        string irdhgj8xe45ygvj8dxuyjvxdlxhy = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String("ZWNrc2RlZQ=="));
        int kgoprjybpe5js9ybh5ofx9yupsoiy = 0;

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == irdhgj8xe45ygvj8dxuyjvxdlxhy[kgoprjybpe5js9ybh5ofx9yupsoiy])
                kgoprjybpe5js9ybh5ofx9yupsoiy += 1;
            else
                kgoprjybpe5js9ybh5ofx9yupsoiy = 0;
            if (kgoprjybpe5js9ybh5ofx9yupsoiy == irdhgj8xe45ygvj8dxuyjvxdlxhy.Count())
            {
                MessageBox.Show(System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String("0J/RgNC+0LPRgNCw0LzQvNGDINC90LDQv9C40YHQsNC7INCa0LjQvCDQldCy0LPQtdC90LjQuSwg0LPRgNGD0L/Qv9CwINCS0KItMTYtMi4=")), "Автор");
                kgoprjybpe5js9ybh5ofx9yupsoiy = 0;
            }
        }

        double[,] arr;
        void FillArray(ref double[,] a, double b,int size)
        {
            Random r = new Random();
            a = new double[size,size];
            for (int i = 0; i < a.GetLength(0); ++i)
                for (int j = 0; j < a.GetLength(1); ++j)
                        a[i,j] = Math.Round(((r.NextDouble()-0.5)*2*b),1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double bound = 0;
            int size = 0;
            if(!double.TryParse(textBox2.Text.Replace(".",","),out bound)||!int.TryParse(textBox1.Text,out size)||size == 0)
            { MessageBox.Show("Неверные данные", "Ошибка"); return; }
            FillArray(ref arr, bound, size);

            double[] tmp = new double[arr.GetLength(1)];
            dataGridView1.RowCount = arr.GetLength(0);
            dataGridView1.ColumnCount = arr.GetLength(1);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            for (int i = 0; i < arr.GetLength(0); ++i)
            {
                for (int j = 0; j < arr.GetLength(1); ++j)
                    dataGridView1.Rows[i].Cells[j].Value = arr[i, j];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (arr == null) return;
            double sum = 0,
                   sumIf = 0,
                   countIf = 0;
            for (int i = 0; i < arr.GetLength(0); ++i)
                for (int j = 0; j < arr.GetLength(1); ++j)
                {
                    sum += arr[i, j];
                    if ((i + j) % 2 == 0)
                    {
                        sumIf += arr[i, j];
                        countIf += 1;
                    }
                }
            textBox3.Text = sum.ToString();
            if (countIf == 0) textBox4.Text = textBox5.Text = textBox6.Text = "Нет значений, удовлетворяющих условию.";
            else
            {
                textBox4.Text = sumIf.ToString();
                textBox5.Text = countIf.ToString();
                textBox6.Text = (sumIf/countIf).ToString();
            }
        }
    }
}
