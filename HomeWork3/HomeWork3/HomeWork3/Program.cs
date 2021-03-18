using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Program
    {
        static void Main(string[] args)
        {  double ans=0;
            Shape[] Shape = new Shape[10];
            int[] ShapeNum = new int[10];
            for (int i = 0; i < 10; i++)
            {
                ShapeNum[i] = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0)).Next(1,4);
            }
            for(int i = 0; i < 10; i++)
            {
                Shape[i] = new ShapeFactory().GetShape(ShapeNum[i]);
                if (Shape[i].isLegal())
                {
                    ans += Shape[i].getArea();
                }
                else ans = 0;
            }
            Console.WriteLine($"total area of Random Shape:{ans} ");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine( "\nthe random shape {0} is a {1}",i+1,Shape[i].GetType());
                Shape[i].GetInfo();
            }
            Console.ReadKey();
        }
    }
}
