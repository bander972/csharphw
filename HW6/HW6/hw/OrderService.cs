using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace HW6.hw
{
    class OrderService
    {
        public List<Order> orders = new List<Order>();
        public OrderService() { }
        public void AddOrder(Order order)
        {
            if (orders.Contains(order))
            {
                throw new ApplicationException($"this order{order}  already exists!");
            }
            orders.Add(order);
        }
        public void RemoveOrder( int orderIndex)
        {
            if (!orders.All(o=>o.OrderIndex==orderIndex))
            {
                throw new ApplicationException("the order you are searching for is missing");
            }
            orders.RemoveAll(o => o.OrderIndex == orderIndex);
        }
        public List<Order> QueryAll()
        {
            return orders;
        }
        public void Update(Order order)
        {
            RemoveOrder(order.OrderIndex);
            orders.Add(order);
        }
        public Order GetById(int orderIndex)
        {
            return orders.Where(o => o.OrderIndex == orderIndex).FirstOrDefault();
        }
        public IEnumerable<Order> Query(Predicate<Order> condition)
        {
            return orders.Where(o => condition(o));
        }
        public List<Order> QueryByGoodsName(string goodsName)
        {
            var query = orders.Where(o => o.Details.Any(d => d.Goods.GoodsName == goodsName));
            return query.ToList();
        }
        public List<Order> QueryByTotalAmount(float totalAmount)
        {
            var query = orders.Where(o => o.TotalPrice >= totalAmount);
            return query.ToList();
        }

        public List<Order> QueryByCustomerName(string customerName)
        {
            var query = orders
                .Where(o => o.Client.name == customerName);
            return query.ToList();
        }
        public void Sort(Comparison<Order> comparison)
        {
            orders.Sort(comparison);
        }
        public void Export()
        {
            XmlSerializer xsl = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("s.xml", FileMode.Create))
            {
                xsl.Serialize(fs, orders);
            }
            Console.WriteLine("\nSerialized as XML:");
            Console.WriteLine(File.ReadAllText("s.xml"));
        }
        public void Import()
        {
            XmlSerializer xsl = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("s.xml", FileMode.Open))
            {
                List<Order> orders = (List<Order>)xsl.Deserialize(fs);
                orders.ForEach(order => Console.WriteLine(order));
            }

        }
    }
}
