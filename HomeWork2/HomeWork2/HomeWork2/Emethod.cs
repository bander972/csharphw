using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Emethod
    {
        public static void PrimeEMethod()
        {
            int[] a = new int[200];
            a[0] = 0;
            a[1] = 0; 
          for(int i = 2; i <= 100; i++)
            {
                a[i] = 1;
            }
            for(int i = 2; i <= 100; i++)
            {
              
                for (int j = 2; i * j <= 100; j++) {
                    a[i * j] = 0;
                }
               
            }
            for(int i = 0; i <= 100; i++)
            {
                if (a[i] == 1)
                { 
                    Console.WriteLine(i);
                   
                }
            }  
        }
        
    }
}
