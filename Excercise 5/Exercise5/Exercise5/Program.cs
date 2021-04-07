using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientInfo client1 = new ClientInfo(1001,"xtt","chengdu",060425413);
            Order order01 = new Order(1, client1);

            Goods pens = new Goods(13, "pens", 2.5);
            Goods meat = new Goods(15, "meat", 10);
            Goods wallet = new Goods(10, "wallet", 20);

            order01.AddDetails(new OrderDetails(meat, 3));
            order01.AddDetails(new OrderDetails(wallet, 1));

            order01.ToString();
        }
    }
}
