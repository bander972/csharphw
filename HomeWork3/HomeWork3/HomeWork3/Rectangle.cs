using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Rectangle:Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
       public Rectangle()
        {
            this.Height = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0)).Next(10,200);
            this.Width =  new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0)).Next(10,200) ;
        }
        public bool isLegal()
        {
            if (Width <= 0 || Height <= 0)
            {
                return false;
            }
            return true;
        }
        public double getArea() {
            if (!isLegal()) return -1;
            return Width * Height;
        }
        public void GetInfo()  {
            try
            {
                if (isLegal())
                {
                    Console.WriteLine("The Rectangle is {0}  wide, {1} high,and has an area of {2}", Width, Height, getArea());
                }
                else Console.WriteLine("Invalid Shape, it's illegal, please reset the rectangle");
            }
            catch(NotImplementedException e) {
                Console.WriteLine("ERROR:missing implement method");
            }
        }
    }
}
