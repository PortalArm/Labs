using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        enum MODES { ADDITION, SUBTRACTION, DIVISION, MULTIPLICATION, CHANGE };

        private MODES curr_mode = MODES.ADDITION;
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
            
        }
        private void Activate(MODES mode)
        {
            switch(mode)
            {
                case MODES.CHANGE:
                    SC2_1.Visible = true;
                    SC2_1label.Visible = true;

                    Firstlabel.Text = "Введите число:";
                    SC1_1label.Text = "Из";

                    Secondlabel.Visible = false;
                    SecondBox.Visible = false;
                    SC1_2label.Visible = false;
                    SC1_2.Visible = false;
                    SCRlabel.Visible = false;
                    SCR.Visible = false;
                    break;
                case MODES.ADDITION:
                case MODES.DIVISION:
                case MODES.MULTIPLICATION:
                case MODES.SUBTRACTION:

                    SC2_1.Visible = false;
                    SC2_1label.Visible = false;

                    Firstlabel.Text = "Введите первое число:";
                    SC1_1label.Text = "В";

                    Secondlabel.Visible = true;
                    SecondBox.Visible = true;
                    SC1_2label.Visible = true;
                    SC1_2.Visible = true;
                    SCRlabel.Visible = true;
                    SCR.Visible = true;

                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            curr_mode = (MODES)comboBox1.SelectedIndex;
            Activate(curr_mode);
        }

        class DifferentNum
        {
            public List<int> before, after;
            public int system;
            public int sign;
            public DifferentNum()
            {
                before = new List<int>();
                after = new List<int>();
                system = -1;
                sign = 1;
            }
            public static bool tryParse(string input, int sys, Dictionary<char, int> d, out DifferentNum num)
            {
                num = new DifferentNum();
                num.system = sys;
                input = input.Replace(".", ",");
                int indexofcomma = input.IndexOf(",");
                if (input[0] == '-')
                {
                    num.sign = -1;
                    input = input.Remove(0, 1);
                }
                string bef = indexofcomma == -1 ? input : input.Substring(0, indexofcomma);
                for (int i = 0; i < bef.Length; ++i)
                {
                    int tmp = 0; if (!d.TryGetValue(bef[i], out tmp) || tmp >= sys) return false;
                    num.before.Add(tmp);
                }

                if (indexofcomma != -1)
                {
                    string aft = input.Substring(indexofcomma + 1);
                    for (int i = 0; i < aft.Length; ++i)
                    {
                        int tmp = 0; if (!d.TryGetValue(aft[i], out tmp) || tmp >= sys) return false;
                        num.after.Add(tmp);
                    }
                }
                return true;
            }

            public string ToString(List<char> decoder)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var i in before)
                    sb.Append(decoder[i]);
                if (after.Count != 0)
                {
                    sb.Append(',');
                    foreach (var i in after)
                        sb.Append(decoder[i]);
                }
                if (sign == -1) sb.Insert(0, '-');
                return sb.ToString();
            }
            public static Dictionary<char, int> DecimalDecoder = new Dictionary<char, int>() {
                { '0', 0 },{ '1', 1 },{ '2', 2 },{ '3', 3 },{ '4', 4 },{ '5', 5 },{ '6', 6 },{ '7', 7 },{ '8', 8 },{ '9', 9 }
            };
            public static List<char> DecimalDec = new char[] { '0','1','2','3','4','5','6','7','8','9' }.ToList();
            public DifferentNum ConvertToSys(int sys)
            {
                DifferentNum val = ConvertTo10();
                if (sys == 10) return val;
                string value = val.ToString(DecimalDec);
                double dval = 0;
                long ival = 0;
                bool usingInt = false;
                if (val.after.Count == 0)
                {
                    ival = Convert.ToInt64(value);
                    usingInt = true;
                }
                else
                {
                    ival = Convert.ToInt64(value.Substring(0, value.IndexOf(",")));
                    dval = Convert.ToDouble("0" + value.Substring(value.IndexOf(",")));
                }
                        
                DifferentNum r = new DifferentNum();
                r.system = sys;
                r.sign = sign;
                if (sign == -1)
                    ival = -ival;
                Stack<int> stack = new Stack<int>();
                while (ival >= sys)
                {
                    stack.Push((int)ival % sys);
                    ival /= sys;
                }
                stack.Push((int)ival);
                while (stack.Count != 0) r.before.Add(stack.Pop());

                if (!usingInt)
                {
                    Queue<int> q = new Queue<int>();
                    int step = -1;
                    while(Math.Pow(sys,step)>=0.0001&&!dval.Equals(0))
                    {
                        dval *= sys;
                        q.Enqueue((int)dval);
                        dval = dval -(int)dval;
                        --step;
                    }
                    while (q.Count != 0) r.after.Add(q.Dequeue());
                }

                return r;
            }

            private DifferentNum ConvertTo10()
            {
                DifferentNum r = new DifferentNum();
                r.system = 10;
                r.sign = sign;
                long p = 1;
                long x = 0;
                for (int i = before.Count-1;i>=0;--i)
                {
                    x += before[i] * p;
                    p *= system;
                }
                var str = x.ToString();
                for (int i = 0; i < str.Length; ++i)
                    r.before.Add(str[i] - '0');
                if(after.Count!=0)
                {
                    double k = 1.0/system;
                    double z = 0;
                    for (int i = 0;i<after.Count;++i)
                    {
                        z += after[i] * k;
                        k /= system;
                    }
                    
                    var st = z.ToString().Substring(z.ToString().IndexOf(",")+1);
                    for (int i = 0; i < st.Length; ++i)
                        r.after.Add(st[i] - '0');
                }
                return r;
            }

            public DifferentNum Addition(DifferentNum y)
            {
                DifferentNum result = new DifferentNum();
                DifferentNum x = ConvertTo10();
                y = y.ConvertTo10();
                string sx = x.ToString(DecimalDec);
                string sy = y.ToString(DecimalDec);
                if(x.after.Count != 0 || y.after.Count != 0)
                    tryParse((Convert.ToDouble(sx) + Convert.ToDouble(sy)).ToString(), 10, DecimalDecoder, out result);
                else
                    tryParse((Convert.ToInt32(sx) + Convert.ToInt32(sy)).ToString(), 10, DecimalDecoder, out result);
                return result;
            }

            public DifferentNum Subtraction(DifferentNum y)
            {
                DifferentNum result = new DifferentNum();
                DifferentNum x = ConvertTo10();
                y = y.ConvertTo10();
                string sx = x.ToString(DecimalDec);
                string sy = y.ToString(DecimalDec);
                if (x.after.Count != 0 || y.after.Count != 0)
                    tryParse((Convert.ToDouble(sx) - Convert.ToDouble(sy)).ToString(), 10, DecimalDecoder, out result);
                else
                    tryParse((Convert.ToInt32(sx) - Convert.ToInt32(sy)).ToString(), 10, DecimalDecoder, out result);
                return result;
            }

            public DifferentNum Multiplication(DifferentNum y)
            {
                DifferentNum result = new DifferentNum();
                DifferentNum x = ConvertTo10();
                y = y.ConvertTo10();
                string sx = x.ToString(DecimalDec);
                string sy = y.ToString(DecimalDec);
                if (x.after.Count != 0 || y.after.Count != 0)
                    tryParse((Convert.ToDouble(sx) * Convert.ToDouble(sy)).ToString(), 10, DecimalDecoder, out result);
                else
                    tryParse((Convert.ToInt32(sx) * Convert.ToInt32(sy)).ToString(), 10, DecimalDecoder, out result);
                return result;
            }

            public DifferentNum Division(DifferentNum y)
            {
                DifferentNum result = new DifferentNum();
                DifferentNum x = ConvertTo10();
                y = y.ConvertTo10();
                string sx = x.ToString(DecimalDec);
                string sy = y.ToString(DecimalDec);
                tryParse((Convert.ToDouble(sx) / Convert.ToDouble(sy)).ToString(), 10, DecimalDecoder, out result);
                return result;
            }

        }
        Dictionary<char, int> dict;
        List<char> alphabet;
        private void Resultbutton_Click(object sender, EventArgs e)
        {

            if (DictBox.Text.Distinct().Count() == DictBox.Text.Length)
                dict = ConstructDict(DictBox.Text, out alphabet);
            else
            {
                MessageBox.Show("Wrong dictionary set", "Error", MessageBoxButtons.OK);
                return;
            }
            int from1 = 0, to1 = 0,ress = 0;
            if(curr_mode == MODES.CHANGE)
            { 
                if (!int.TryParse(SC1_1.Text, out from1) || !int.TryParse(SC2_1.Text, out to1) || !(from1 > 1 && to1 > 1))
                {
                    MessageBox.Show("Wrong systems", "Error", MessageBoxButtons.OK);
                    return;
                }
                DifferentNum result = null;
                if(!DifferentNum.tryParse(FirstBox.Text,from1,dict,out result))
                {
                    MessageBox.Show("Wrong number or system", "Error", MessageBoxButtons.OK);
                    return;
                }
                ResultBox.Text = result.ConvertToSys(to1).ToString(alphabet);
            }
            else
            {
                if (!int.TryParse(SC1_1.Text, out from1) || !int.TryParse(SC1_2.Text, out to1) || !int.TryParse(SCR.Text,out ress) || !(from1 > 1 && to1 > 1 && ress > 1))
                {
                    MessageBox.Show("Wrong systems", "Error", MessageBoxButtons.OK);
                    return;
                }
                DifferentNum op1 = null,op2 = null;
                if (!DifferentNum.tryParse(FirstBox.Text, from1, dict, out op1) || !DifferentNum.tryParse(SecondBox.Text, to1, dict, out op2) || (Convert.ToDouble(op2.ConvertToSys(10).ToString(DifferentNum.DecimalDec)).Equals(0) && curr_mode == MODES.DIVISION))
                {
                    MessageBox.Show("Wrong numbers or system", "Error", MessageBoxButtons.OK);
                    return;
                }
                
                switch(curr_mode)
                {
                    case MODES.ADDITION:
                        ResultBox.Text = op1.Addition(op2).ConvertToSys(ress).ToString(alphabet);
                        break;
                    case MODES.SUBTRACTION:
                        ResultBox.Text = op1.Subtraction(op2).ConvertToSys(ress).ToString(alphabet);
                        break;
                    case MODES.MULTIPLICATION:
                        ResultBox.Text = op1.Multiplication(op2).ConvertToSys(ress).ToString(alphabet);
                        break;
                    case MODES.DIVISION:
                        ResultBox.Text = op1.Division(op2).ConvertToSys(ress).ToString(alphabet);
                        break;
                }

            }
        }

        private Dictionary<char, int> ConstructDict(string input,out List<char> to)
        {
            Dictionary<char, int> res = new Dictionary<char, int>();
            to = new List<char>();
            for (int i = 0; i < input.Length; ++i)
            {
                res.Add(input[i], i);
                to.Add(input[i]);
            }
            return res;
        }
    }
}
