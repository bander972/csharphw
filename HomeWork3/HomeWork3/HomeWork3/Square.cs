using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    internal class Square:Shape
    {
        public int Length { get; set; }
        
        public Square()
        {
            this.Length = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0)).Next(10,200);
        }
        public  bool isLegal() {
            return Length >= 0;
        }

        public  double getArea()
        { if (!isLegal()) return -1;
            return Length * Length;
        }
        public  void GetInfo()
        {
            try {
                if (isLegal())
                {
                    Console.WriteLine("this square has a edge length:{0} , and its area is {1}", Length, getArea());
                }
                else Console.WriteLine("Invalid Shape, it's illegal, please reset the square");
            }
            catch (NotImplementedException e)
            {
                Console.WriteLine("ERROR:missing implement method");
            }
        }
    }
}
