using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Проверка входных данных.
            int isOkay = 0;
            float s = 0;
            float[] inputs = new float[10];
            try
            {
                s = float.Parse(textBox1.Text.Replace(".",","));
                if (s <= 0)
                    isOkay = 1;    
            }
            catch (Exception)
            {
                isOkay = 1;
            }
            try
            {
                for (int i = 0; i < 10; ++i)
                    inputs[i] = float.Parse(panel1.Controls["Input_" + i.ToString()].Text.Replace(".", ","));
            }
            catch (Exception)
            {
                isOkay = 2;
            }
            
            //Вывод окна ошибки или же продолжение расчета.
            switch (isOkay)
            {
                case 0: Calculate(s,inputs); break;
                case 1: ShowDialog("Значение 'а' должно быть больше нуля.");  break;
                case 2: ShowDialog("Значения 'x' введены неверно."); break;
            }
        }

        float L_BOUND,
              R_BOUND;
        private void Calculate(float z,float[] arr)
        {
            //Создание полотна для рисования графика.
            var g = pictureBox1.CreateGraphics();
            g.Clear(BackColor);
            L_BOUND = arr.Min();
            R_BOUND = arr.Max();
            if(checkBox1.Checked) g.SmoothingMode = SmoothingMode.AntiAlias;
            DrawPic(ref g, Y, L_BOUND, R_BOUND, z, arr);

        }

        static Matrix transform;
        //Данная функция. 
        private float Y(float a,float x)
        {
            return (float)Math.Pow(a, x)/(x*x); 
        }
        float minv = float.MaxValue;
        float maxv = float.MinValue;
        private void DrawPic(ref Graphics gr, Func<float, float, float> f, float lb, float ub, float a,float[] ar)
        {
            Array.Sort(ar);
            List<float> arr = new List<float>();
            //Построение списка из неповторяющихся значений входных данных.
            arr.Add(ar[0]);
            for (int i = 1; i < ar.Length; ++i)
                if (ar[i] != ar[i - 1]) arr.Add(ar[i]);
            
            dataGridView1.Rows.Clear();
            //Нахождение пар (x, y(x)).
            PointF[] pf = new PointF[arr.Count];
            for (int i = 0;i<arr.Count; ++i)
            {
                float x = arr[i];
                float y = f(a, x);
                dataGridView1.Rows.Add(x, y);
                if (y > 32767)
                    y = 32767;
                else
                if (y < -32767)
                    y = -32767;
                pf[i] = new PointF(x, y);
            }
            minv = pf.Min((PointF x) => { return x.Y; });
            maxv = pf.Max((PointF x) => { return x.Y; });

            //Трансформация полотна для корректного отображения.
            transform = new Matrix();
            transform.Translate(pictureBox1.Width / 2, pictureBox1.Height / 2);
            transform.Scale(pictureBox1.Width / (ub - lb), -pictureBox1.Height / (maxv-minv));
            PointF[] lims = new[]
            {
                new PointF(pf.Min((PointF x) => { return x.X; }),0),//lx
                new PointF(pf.Max((PointF x) => { return x.X; }),0),//rx
                new PointF(0,pf.Min((PointF x) => { return x.Y; })),//dy
                new PointF(0,pf.Max((PointF x) => { return x.Y; }))//uy
            };
            transform.Translate(-(lims[0].X+lims[1].X)/2,
                                -(lims[2].Y+lims[3].Y)/2);
            transform.TransformPoints(pf);

            //Отрисовка линий и кругов на полотне.
            gr.DrawLines(Pens.Black, pf);
            for (int i = 0; i < pf.Count(); ++i)
                gr.DrawEllipse(Pens.Black, new RectangleF(pf[i].X-2,pf[i].Y-2,4,4));
        }
        private void ShowDialog(string info)
        {
            Form2 s = new Form2(info);
            s.ShowDialog();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //Обновление трансформации полотна при изменении размеров окна.
            transform = new Matrix();
            transform.Translate(pictureBox1.Width / 2, pictureBox1.Height / 2);
            transform.Scale(pictureBox1.Width / (R_BOUND - L_BOUND), -pictureBox1.Height / (maxv - minv));
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Открытие окна справки.
            (new HelpForm()).ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Добавление начальных столбцов Х и У в таблицу 
            dataGridView1.Columns.Add("X","X");
            dataGridView1.Columns.Add("Y", "Y");
            pictureBox2.ImageLocation = @"F:\4semester\Labs\Process of Development\Lab1_alter\Lab1\CodeCogsEqn.gif";
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
        }
    }
}
