using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tableoftruth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("   A   |   B   | A and B |  A or B |  not A |  not B ");
            for (int i = 0; i < 4; ++i)
            {
                bool a = (i >> 1) == 1 ? true : false,
                     b = (i % 2) == 1 ? true : false;
                Console.WriteLine(" {0,5} | {1,5} | {2,7} | {3,7} | {4,6} | {5,6} ",a,b,a&b,a|b,!a,!b );
            }
            Console.ReadKey();
        }
    }
}
