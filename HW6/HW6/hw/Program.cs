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
                ClientInfo customer1 = new ClientInfo(1, "Customer1", "wuhan", 10081);
                ClientInfo customer2 = new ClientInfo(2, "Customer2", "chengdu", 10086);

                Goods milk = new Goods(1, "Milk", 6.00);
                Goods eggs = new Goods(2, "eggs", 4.99);
                Goods apple = new Goods(3, "apple", 5.59);

                Order order1 = new Order(1, customer1);
                order1.AddDetails(new OrderDetails(apple, 8));
                order1.AddDetails(new OrderDetails(eggs, 10));
                //order1.AddDetails(new OrderDetail(eggs, 8));
                //order1.AddDetails(new OrderDetail(milk, 10));

                Order order2 = new Order(2, customer2);
                order2.AddDetails(new OrderDetails(eggs, 10));
                order2.AddDetails(new OrderDetails(milk, 10));

                Order order3 = new Order(3, customer2);
                order3.AddDetails(new OrderDetails(milk, 100));

                OrderService orderService = new OrderService();
                orderService.AddOrder(order1);
                orderService.AddOrder(order2);
                orderService.AddOrder(order3);

                Console.WriteLine("\n GetById");
                Console.WriteLine(orderService.GetById(1));
                Console.WriteLine(orderService.GetById(5) == null);

                Console.WriteLine("\nGetAllOrders");
                List<Order> orders = orderService.QueryAll();
                orders.ForEach(o => Console.WriteLine(o));

                Console.WriteLine("\nGetOrdersByCustomerName:'Customer2'");
                orders = orderService.QueryByCustomerName("Customer2");
                orders.ForEach(o => Console.WriteLine(o));

                Console.WriteLine("\nGetOrdersByGoodsName:'eggs'");
                orders = orderService.QueryByGoodsName("eggs");
                orders.ForEach(o => Console.WriteLine(o));

                Console.WriteLine("\nGetOrdersTotalAmount:1000");
                orders = orderService.QueryByTotalAmount(1000);
                orders.ForEach(o => Console.WriteLine(o));

                Console.WriteLine("\nRemove order(id=2) and qurey all");
                orderService.RemoveOrder(2);
                orderService.QueryAll().ForEach(
                    o => Console.WriteLine(o));

                Console.WriteLine("\n order by Amount");
                orderService.Sort(
                  (o1, o2) => o2.TotalPrice.CompareTo(o1.TotalPrice));
                orderService.QueryAll().ForEach(
                    o => Console.WriteLine(o));
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
        }
    }

