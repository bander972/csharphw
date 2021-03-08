using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Prime_Factor
    {
        //求一个数的素数因数
        public static void getPrimeFactor(int numInput)
        {
            Console.WriteLine("整数"+numInput+"的素数因子是：");
            for (int i = 2; i * i < numInput+1; i++)
            {
                while (numInput % i == 0)
                {
                    Console.Write(i+" ");
                    numInput /= i;

                }
            }
            if (numInput != 1)
            {
                Console.Write(numInput);
            }
    }
    }
}
        