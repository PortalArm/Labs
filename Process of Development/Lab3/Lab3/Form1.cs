using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string irdhgj8xe45ygvj8dxuyjvxdlxhy = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String("ZWNrc2RlZQ=="));
        int kgoprjybpe5js9ybh5ofx9yupsoiy = 0;

        private void xdrjgipoxjh0h95j9phjch(object podrjgpoxdjorxdoitjoirxdjy3, KeyPressEventArgs rdujgxjrd9gjxo95xdhljxe)
        {
            if (rdujgxjrd9gjxo95xdhljxe.KeyChar == irdhgj8xe45ygvj8dxuyjvxdlxhy[kgoprjybpe5js9ybh5ofx9yupsoiy])
                kgoprjybpe5js9ybh5ofx9yupsoiy += 1;
            else
                kgoprjybpe5js9ybh5ofx9yupsoiy = 0;
            if (kgoprjybpe5js9ybh5ofx9yupsoiy == irdhgj8xe45ygvj8dxuyjvxdlxhy.Count())
            {
                MessageBox.Show(System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String("0J/RgNC+0LPRgNCw0LzQvNGDINC90LDQv9C40YHQsNC7INCa0LjQvCDQldCy0LPQtdC90LjQuSwg0LPRgNGD0L/Qv9CwINCS0KItMTYtMi4=")), "Автор");
                kgoprjybpe5js9ybh5ofx9yupsoiy = 0;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private bool StrToList(string input, out List<double> output)
        {
            output = new List<double>();
            var strarray = input.Replace(".",",").Split(' ');
            for (int i = 0; i < strarray.Length; ++i)
            {
                double temp = 0; if (!double.TryParse(strarray[i], out temp)) return false;
                output.Add(temp);
            }
            return true;
        }
        Vector vector1, vector2;
        private void button1_Click(object sender, EventArgs e)
        {
            List<double> info1 = new List<double>(), info2 = new List<double>();
            if (!StrToList(textBox1.Text, out info1) || !StrToList(textBox2.Text, out info2)) { MessageBox.Show("Неправильно введены данные!", "Ошибка"); return; }
            vector1 = new Vector(info1);
            vector2 = new Vector(info2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double m1 = 0, m2 = 0;
            if (!double.TryParse(textBox7.Text.Replace(".", ","), out m1) || !double.TryParse(textBox8.Text.Replace(".", ","), out m2)) { MessageBox.Show("Неправильно введены множители!", "Ошибка"); return; }

            try
            {
                textBox3.Text = (vector1 + vector2).ToString();
                textBox4.Text = vector1.ScalarProduct(vector2).ToString();
                textBox5.Text = (m1 * vector1).ToString();
                textBox6.Text = (m2 * vector1).ToString();
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message,"Ошибка"); return;
            }
        }
    }

    class Vector
    {
        List<double> values;

        public int GetLength() => values.Count;
        public List<double> Values { get => values; set => values = value; }

        public Vector(List<double> arr)
        {
            values = new List<double>(arr);
        }
        public Vector()
        {
            values = new List<double>();
        }


        public double this[int key]
        {
            get => values[key];
            set => values[key] = value;
        }
        public void MultiplyBy(double M)
        {
            for (int i = 0; i < values.Count; ++i)
                values[i] *= M;
        }
        static public Vector operator+ (Vector X, Vector Y)
        {
            if (Y.GetLength() != X.GetLength()) throw new Exception("Количество элементов в векторах должно быть одинаковым.");
            Vector R = new Vector(X.Values);
            for (int i = 0; i < R.GetLength(); ++i)
                R[i] = R[i] + Y[i];
            return R;
        }
        static public Vector operator* (double Y, Vector V)
        {
            Vector R = new Vector(V.Values);
            for (int i = 0; i < R.GetLength(); ++i)
                R[i] *= Y;
            return R;
        }
        static public Vector operator *(Vector V, double Y)
        {
            Vector R = new Vector(V.Values);
            for (int i = 0; i < R.GetLength(); ++i)
                R[i] *= Y;
            return R;
        }
        public double ScalarProduct(Vector Y)
        {
            if (Y.GetLength() != GetLength()) throw new Exception("Vectors' lengths aren't equal");
            double res = 0;
            for (int i = 0; i < values.Count; ++i)
                res += values[i] * Y[i];
            return res;
        }

        public override string ToString()
        {
            StringBuilder SB = new StringBuilder();
            for(int i = 0;i<values.Count;++i)
                SB.AppendFormat("{0} ",values[i]);
            return SB.ToString();
        }
    }
}