using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Prime_Factor
    {
        public static void getPrimeFactor(int numInput)
        {
            StringBuilder sb = new StringBuilder();

            int i;

            if (numInput == 1) { Console.WriteLine("Prime Factor=" + numInput); }
            for (i = 2; i <= numInput; i++)
            {
                while (true)
                {
                    if (numInput % i == 0)
                    {
                        sb.Append(i);
                        numInput /= i;
                        if (numInput != 1)
                        {
                            sb.Append("*");
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (numInput != 1)
            {
                sb.Append(numInput);
            }
            Console.WriteLine(sb);
        }
    }
 }
        