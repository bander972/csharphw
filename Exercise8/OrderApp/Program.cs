using System;
using System.Collections.Generic;
using System.Text;


namespace OrderApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
          OrderItem item1 = new OrderItem(1, "1", 1, 1);       
          OrderItem item2 = new OrderItem(1, "1", 1, 1);
          Console.WriteLine(item1 == item2);
          Console.WriteLine(item1.Equals(item2));
          */

            OrderItem Apple = new OrderItem(1, "Apple", 5, 30);
            OrderItem Orange = new OrderItem(2, "Orange", 3, 100);
            OrderItem milk = new OrderItem(3, "milk", 5, 60);

            Shopper shopper1 = new Shopper("lby");
            Shopper shopper2 = new Shopper("681");

            Order order1 = new Order(DateTime.Now, shopper1, new List<OrderItem> { Apple, Orange, milk });
            Order order2 = new Order(DateTime.Now, shopper2, new List<OrderItem> { Apple, Orange });
            Order order3 = new Order(DateTime.Now, shopper1, new List<OrderItem> { Orange, milk });

            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);

            Console.WriteLine("GetAllOrders:");
            os.Orders.ForEach(order => Console.WriteLine(order));
            Console.WriteLine("-----------------------");

            os.Orders.Sort((o1, o2) => o1.TotalPrice.CompareTo(o2.TotalPrice));
            Console.WriteLine("GetAllOrdersAfterSort");
            os.Orders.ForEach(order => Console.WriteLine(order));
            Console.WriteLine("-----------------------");


            Console.WriteLine("GetOrdersByCustomerName:'lby'");
            os.QueryOrdersByShopper("lby").ForEach(o => Console.WriteLine(o));
            Console.WriteLine("-----------------------");

            Console.WriteLine("GetOrdersByGoodsName:'Apple'");
            os.QueryOrdersByGoodsName("Apple").ForEach(o => Console.WriteLine(o));
            Console.WriteLine("-----------------------");

            Console.WriteLine("Remove order(id=2) and qurey all");
            os.RemoveOrder(2);
            os.Orders.ForEach(o => Console.WriteLine(o));
            Console.WriteLine("-----------------------");


        }
    }
}
