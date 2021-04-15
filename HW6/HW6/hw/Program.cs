using HW6.hw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ClientInfo client1 = new ClientInfo(1001, "xtt", "chengdu", 060425413);
                ClientInfo client2 = new ClientInfo(1002, "zyc", "wuhan", 1000542673);
                Order order01 = new Order(1, client1);

                Goods pens = new Goods(13, "pens", 2.5);
                Goods meat = new Goods(15, "meat", 10);
                Goods wallet = new Goods(10, "wallet", 20);

                order01.AddDetails(new OrderDetails(meat, 3));
                order01.AddDetails(new OrderDetails(wallet, 1));

                order01.ToString();
                Order order02 = new Order(2, client1);
                order02.AddDetails(new OrderDetails(pens, 20));
                order02.AddDetails(new OrderDetails(meat, 1));
                order02.ToString();

                Order order03 = new Order(3, client2);
                order03.AddDetails(new OrderDetails(meat, 2));
                order03.AddDetails(new OrderDetails(meat, 15));
                order03.ToString();

                OrderService service = new OrderService();
                service.AddOrder(order01);
                service.AddOrder(order02);
                service.AddOrder(order03);

                service.Export();
                List<Order> orders = service.QueryAll();
                orders.ForEach(order => Console.WriteLine(order));
                orders = service.QueryByCustomerName(client1.name);

            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.ReadLine();
        }
    }
 }

