using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CaculatorConsole
{
    class caculator
    {
        public static void GetValue(String func, double n1, double n2)
        {

            double res = 0;
            try
            {
                switch (func)
                {
                    case "+":
                        res = n1 + n2;
                        break;
                    case "-":
                        res = n1 - n2;
                        break;
                    case "*":
                        res = n1 * n2;
                        break;
                    case "/":
                        if (n2 == 0) { Console.WriteLine("Invalid number!"); }
                        res = n1 / n2;
                        break;
                    default:
                        Console.WriteLine("Invalid op! input your op again!");
                        String s = Console.ReadLine();
                        GetValue(s, n1, n2);
                        break;
                }
                Console.WriteLine("= " + res);
            }
            catch (FormatException e)
            {
                Console.WriteLine("wrong input");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("please input the first number,the op and the second number and the op in order(use space key):");
            String[] s = Console.ReadLine().Split(' ');
            double num1 = double.Parse(s[0]);
            double num2 = double.Parse(s[2]);
            string func = s[1];
            GetValue(func, num1, num2);
            Console.ReadLine();
        }
    }
}

