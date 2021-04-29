using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW6.hw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW6.hw.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
         ClientInfo customer1 = new ClientInfo(1, "alan", "wuhan", 100487);
            ClientInfo customer2 = new ClientInfo(2, "dylan", "shanghai", 105241);
            Goods banana = new Goods(30, "banana", 5.00);
            Goods bread = new Goods(15, "bread", 6.00);
            Goods eggs = new Goods(20, "eggs", 10.00);
            Goods milk = new Goods(23, "milk", 12.00);
            OrderService service = new OrderService();
            [TestInitialize()]
            void Init()
            {
                Order order1 = new Order(1, customer1);
                order1.AddDetails(new OrderDetails(eggs, 1));
                order1.AddDetails(new OrderDetails(bread, 2));
                Order order2 = new Order(2, customer1);
                order2.AddDetails(new OrderDetails(banana, 4));
                order2.AddDetails(new OrderDetails(eggs, 2));
                Order order3 = new Order(3, customer2);
                order3.AddDetails(new OrderDetails(banana, 3));
                order3.AddDetails(new OrderDetails(milk, 2));

                service.AddOrder(order1);
                service.AddOrder(order2);
                service.AddOrder(order3);
            }
            [TestMethod()]
            public void AddOrderTest()
            {

                Order order4 = new Order(4, customer2);
                order4.AddDetails(new OrderDetails(milk, 1));
                order4.AddDetails(new OrderDetails(banana, 5));
                service.AddOrder(order4);
            }
            [TestMethod()]
            public void RemoveTest()
            {
                service.RemoveOrder(1);
                Assert.AreEqual(0, service.orders.Count);
            }
            [TestMethod()]
            public void UpdateTest()
            {
                Order order3 = new Order(3, customer1);
                order3.AddDetails(new OrderDetails(milk, 4));
                service.Update(order3);
                Assert.AreEqual(1, service.orders.Count);
                Assert.IsNotNull(order3);
            }
            [TestMethod()]
            public void QueryTest()
            {
                List<Order> orders;
                orders = service.QueryAll();
                orders.ForEach(o => Console.WriteLine(o));
                orders = service.QueryByCustomerName("alan");
                orders.ForEach(o => Console.WriteLine(o));
                orders = service.QueryByGoodsName("milk");
                orders.ForEach(o => Console.WriteLine(o));
                Assert.IsTrue(orders.All(o => o.Details.Any(d => d.Goods.GoodsName == "milk")));
            }
            [TestMethod()]
            public void ExportTest()
            {
                String path = "Order.xml";
                service.Export(path);
                Assert.AreEqual(File.ReadAllText(path), File.ReadAllText("TestXML.xml"));
                File.Delete(path);
            }
            [TestMethod()]
            public void ImportTest()
            {
                String path = "TestXML.xml";
                OrderService Service = new OrderService();
                Service.Import(path);
                CollectionAssert.AreEqual(Service.orders, service.orders);
            }
    
    }
}