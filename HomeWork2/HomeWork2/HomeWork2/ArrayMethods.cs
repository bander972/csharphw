using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class ArrayMethods
    {
        public static double[] GetArray(double[] num)
        { double sum = 0;
            for(int i = 0; i < num.Length; i++)
            {
                sum += num[i];
            }
            Array.Sort(num);
            double max = num[num.Length - 1];
            double min = num[0];
            double avg = sum / num.Length;
            double[] ArrayMethods = new double[] { sum, max, min,avg };
            Console.WriteLine("sum=" + ArrayMethods[0]);
            Console.WriteLine("max=" + ArrayMethods[1]);
            Console.WriteLine("min=" + ArrayMethods[2]);
            Console.WriteLine("avg=" + ArrayMethods[3]);
            return ArrayMethods;

        }
    }
}
