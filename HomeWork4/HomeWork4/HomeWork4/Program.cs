using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HomeWork4.Clock;

namespace HomeWork4
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            Random ra = new Random();
            for(int i = 0; i < 10; i++)
            { 
                int randomRecord=ra.Next(10, 100);
                list.Add(randomRecord);
            }
            list.ForEach(data=>Console.WriteLine(data));
            //make a sum
            int sum = 0;
            list.ForEach(data => sum += data);
            Console.WriteLine($"sum:{sum}");

            //get the minimum value
            int min = list.Head.Data;
            list.ForEach(data => min = data<min?data:min) ;
            Console.WriteLine($"minimum:{ min}");
            //get the maximum value
            int max = list.Head.Data;
            list.ForEach(data => max = data>max?data:max);
            Console.WriteLine($"maximum:{max}");
            

            //clock(第四题:)
            Clock clk = new Clock(22, 49);
            MyClock myClock = clk.Tick;
            myClock += clk.Alarm;
            myClock();
            Console.ReadLine();
        }
    }
}
