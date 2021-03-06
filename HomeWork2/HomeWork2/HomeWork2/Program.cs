using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] num1 = { 10, 20, 50, 14, 32, 79 };
            ArrayMethods.GetArray(num1);
            
            int n=Console.Read();
            Prime_Factor.getPrimeFactor(n);
            Console.ReadKey();
        }
    }
}
