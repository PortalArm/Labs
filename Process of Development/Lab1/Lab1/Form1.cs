using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //private double a;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float s = 0;
            try
            {
                s = float.Parse(textBox1.Text);
                if (s > 0)
                    Calculate(s);
                else
                    ShowDialog();
            }
            catch (FormatException)
            {
                ShowDialog();
            }
        }

        float L_BOUND = -20,
              R_BOUND = 20;
        private void Calculate(float z)
        {

            var g = pictureBox1.CreateGraphics();
            g.Clear(BackColor);
            //g.Transform = transform;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            DrawPic(ref g, Y, L_BOUND, R_BOUND, z);
            
            //g.DrawLine(Pens.Black,new Point(0,0), new Point(200,200));

        }

        Matrix transform;
        private float Y(float a,float x)
        {
            return (float)Math.Sin(Math.Sin(x));//(float)Math.Pow(a, x)/(x*x); 
        }
        private void DrawPic(ref Graphics gr, Func<float, float, float> f, float lb, float ub, float a)
        {
            float step = 0.1f;
            PointF[] pf = new PointF[(int)((ub - lb) / step) + 1];
            float y = Math.Min(f(a, lb), 1000f);
            pf[0] = new PointF(lb,y);

            Console.WriteLine(lb + " " + y);
            float minv = float.MaxValue;
            float maxv = float.MinValue;
            for (int i = 1;lb+i*step<=ub; ++i)//lb+step; i <= ub; i += step)
            {
                //double prevy = f(a, i)/step;
                float x = lb + i * step; y = Math.Min(f(a, x),1000f);
                if (y < minv) minv = y; else if (y > maxv) maxv = y;
                pf[i] = new PointF(x, y);
                Console.WriteLine(x + " " + y);
                //gr.DrawLine(Pens.Black,new Point(Convert.ToInt32(i/step),(int)y),new Point(Convert.ToInt32(i-step),(int)prevy));
            }
            transform.TransformPoints(pf);
            gr.DrawLines(Pens.Black, pf);
            Console.WriteLine("MAX V = {0}, MIN V = {1}",maxv,minv);
        }
        private void ShowDialog()
        {
            Form2 s = new Form2();
            s.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            transform = new Matrix();
            transform.Translate(pictureBox1.Width / 2, pictureBox1.Height / 2);
            transform.Scale(1*pictureBox1.Width/(R_BOUND-L_BOUND), -1* pictureBox1.Height / (R_BOUND - L_BOUND));

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.Transform = transform;
            //pictureBox1.Invalidate();
        }
    }
}
