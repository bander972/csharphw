using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class ShapeFactory
    {

        public Shape GetShape(int shapeNum)
        {
            switch (shapeNum)
            {
                case 1:
                    Console.WriteLine("a rectangle is created");
                    return new Rectangle();
                case 2:
                    Console.WriteLine("a triangle is created");
                    return new Triangle();
                case 3:
                    Console.WriteLine("a square is created");
                    return new Square();
                default:
                    Console.WriteLine("Can't creat a new Shape,please retry");
                    return null;
            }
        }
    }
}
