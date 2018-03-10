using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using ELW.Library.Math;
using ELW.Library.Math.Expressions;
using ELW.Library.Math.Tools;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PreparedExpression preparedExpression;
        CompiledExpression compiledExpression;
        List<VariableValue> vars;
        private void button1_Click(object sender, EventArgs e)
        {
            //Проверка входных данных.
            int isOkay = 0;
            float s = 0;
            float[] inputs = new float[10];
            float from = 1, to = -1, step = 0;
            if (!(float.TryParse(FromX.Text.Replace(".",","), out from) && float.TryParse(ToX.Text.Replace(".", ","), out to))) //|| from > to)
                isOkay = 1;
            else
            if (from > to)
                isOkay = 2;
            else
            if (!float.TryParse(Step.Text.Replace(".", ","), out step))
                isOkay = 3;
            else
            if (step > to - from)
                isOkay = 4;
            //Проверка на правильность ввода функции.
            try
            {
                preparedExpression = ToolsHelper.Parser.Parse(FuncBox.Text.Replace(" ",""));
                compiledExpression = ToolsHelper.Compiler.Compile(preparedExpression);
                F = (xx) => { vars[0] = new VariableValue(xx, VarName.Text); return (float)ToolsHelper.Calculator.Calculate(compiledExpression, vars); };
                F(0.332f);
            }
            catch (Exception) 
            {
                isOkay = 5;
            }
            //Вывод сообщения об ошибке или построение графика.
            switch (isOkay)
            {
                case 0: PackIntoListBox(VarName.Text,FuncBox.Text,from,to,step); Calculate(from, to, step); break;
                case 1: MessageBox.Show( "Неверно введены границы интервала.", "Ошибка.", MessageBoxButtons.OK); break;
                case 2: MessageBox.Show( "Левая граница должна быть меньше правой границы.", "Ошибка.", MessageBoxButtons.OK); break;
                case 3: MessageBox.Show( "Неверно введен шаг.", "Ошибка.", MessageBoxButtons.OK); break;
                case 4: MessageBox.Show( "Длина шага не должна превышать длину интервала.", "Ошибка.", MessageBoxButtons.OK); break;
                case 5: MessageBox.Show( "Неверно введена функция или название параметра.", "Ошибка.", MessageBoxButtons.OK); break;
            }
        }

        void PackIntoListBox(string vari, string function, float from, float to, float st)
        {
            //Упаковка информации о функции в элемент списка.
            string res = "f(" + vari + ") = " + function + " | " + from.ToString() + " | " + to.ToString() + " | " + st.ToString();
            listBox1.Items.Add(res);
        }

        void UnpackFromListBox(int index)
        {
            //Получение значения из текущего элемента списка.
            string[] ins = listBox1.Items[index].ToString().Replace(" ", "").Split('|');
            string varstr = ins[0].Substring(ins[0].IndexOf("(") + 1, ins[0].IndexOf(")") - ins[0].IndexOf("(") - 1);
            ins[0] = ins[0].Remove(0, ins[0].IndexOf('=') + 1);
            FuncBox.Text = ins[0]; FromX.Text = ins[1]; ToX.Text = ins[2]; Step.Text = ins[3];
            preparedExpression = ToolsHelper.Parser.Parse(ins[0]);
            compiledExpression = ToolsHelper.Compiler.Compile(preparedExpression);
            
            F = (xx) => { vars[0] = new VariableValue(xx, varstr); return (float)ToolsHelper.Calculator.Calculate(compiledExpression, vars); };
        }
        Func<float,float> F;
        float LEFT_BOUND,
              RIGHT_BOUND,
              LOWER_BOUND,
              UPPER_BOUND;
        private void Calculate(float fromX, float toX, float step)
        {
            //Создание полотна для рисования графика.
            var g = pictureBox1.CreateGraphics();
            g.Clear(BackColor);
            LEFT_BOUND = fromX;
            RIGHT_BOUND = toX;
            if (UseAA.Checked) g.SmoothingMode = SmoothingMode.AntiAlias;
            //Вычисление значений и отрисовка графика.
            DrawPic(ref g, LEFT_BOUND, RIGHT_BOUND,step);

        }

        static Matrix transform;
        private void DrawPic(ref Graphics gr, float fromX, float toX, float step)
        {
            List<float> arr = new List<float>();
            dataGridView1.Rows.Clear(); 
            //Нахождение пар (x, y(x)).
            PointF[] pf = new PointF[(int)((toX - fromX) / step) + 1];
            for (int i = 0; fromX + i*step <= toX; ++i) 
            {
                float x = fromX+i*step;
                float y = F(x);
                dataGridView1.Rows.Add(x, y);
                if (y > 32767)
                    y = 32767;
                else
                if (y < -32767)
                    y = -32767;
                pf[i] = new PointF(x, y);
            }
            LOWER_BOUND = pf.Min((PointF x) => { return x.Y; });
            UPPER_BOUND = pf.Max((PointF x) => { return x.Y; });

            //Трансформация полотна для корректного отображения.
            transform = new Matrix();
            transform.Translate(pictureBox1.Width / 2, pictureBox1.Height / 2);
            transform.Scale(pictureBox1.Width / (toX - fromX), -pictureBox1.Height / (UPPER_BOUND - LOWER_BOUND));
            PointF[] lims = new[]
            {
                new PointF(pf.Min((PointF x) => { return x.X; }),0),//lx
                new PointF(pf.Max((PointF x) => { return x.X; }),0),//rx
                new PointF(0,pf.Min((PointF x) => { return x.Y; })),//dy
                new PointF(0,pf.Max((PointF x) => { return x.Y; }))//uy
            };
            transform.Translate(-(lims[0].X + lims[1].X) / 2,
                                -(lims[2].Y + lims[3].Y) / 2);
            transform.TransformPoints(pf);

            //Отрисовка линий на полотне.
            gr.DrawLines(Pens.Black, pf);
        }
        private void ShowDialog(string info)
        {
            Form2 s = new Form2(info);
            s.ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Выбор текущего графика из списка.
            if (listBox1.SelectedIndex == -1)
                return;
            UnpackFromListBox(listBox1.SelectedIndex);
            Calculate(
                float.Parse(FromX.Text),
                float.Parse(ToX.Text),
                float.Parse(Step.Text)
                );
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Удаление всех элементов из списка.
            listBox1.Items.Clear();
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //Удаление одного элемента из списка.
            if(listBox1.SelectedIndex!=-1)
                if (e.KeyCode == Keys.Delete)
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    e.Handled = true;
                }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //Обновление трансформации полотна при изменении размеров окна.
            transform = new Matrix();
            transform.Translate(pictureBox1.Width / 2, pictureBox1.Height / 2);
            transform.Scale(pictureBox1.Width / (RIGHT_BOUND - LEFT_BOUND), -pictureBox1.Height / (UPPER_BOUND - LOWER_BOUND));
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
            dataGridView1.Columns.Add("X", "X");
            dataGridView1.Columns.Add("Y", "Y");
            vars = new List<VariableValue>();
            vars.Add(new VariableValue(0,"Z"));
        }
    }
}
