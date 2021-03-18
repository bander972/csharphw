using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Triangle:Shape
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        private double p;//calculate for (a+b+c)/2
        public Triangle()
        {
            this.A = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0)).Next(10,200);
            this.B = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0)).Next(10, 200);
            this.C = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0)).Next(10, 200);
        }
        public bool isLegal()
        {
            if (A <= 0 || B <= 0 || C <= 0 || A + B <= C || B + C <= A || A + C <= B) return false;
            return true;
        }
        public double getArea()
        { if (!isLegal()) return -1;
            p = (A + B + C) / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
        public void GetInfo()
        {
            try
            {
                if (!isLegal())
                {
                    Console.WriteLine("this Triangle has  edge length(a,b,c):{0}, {1}, {2},and its area is {3}", A, B, C, getArea());
                }
                else Console.WriteLine("Invalid Shape,please reset the triangle");
            }
            catch (NotImplementedException e)
            {
                Console.WriteLine("ERROR:missing implement method");
            }
        }
    }
}
