using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6.hw
{
    public class Order
    {
        public int OrderIndex { get; set; }
        public double TotalPrice { get => Details.Sum(d => d.Amount); }
        public DateTime OrderTime { get; set; }
        public ClientInfo Client { get; set; }
        public List<OrderDetails> Details { get; } = new List<OrderDetails>();
        public Order() { }
        public Order(int order, ClientInfo client)
        {
            this.OrderIndex = order;
            this.Client = client;
            this.OrderTime = DateTime.Now;
        }
        public override bool Equals(Object obj)
        {
            var order = obj as Order;
            return order != null && order.OrderIndex == this.OrderIndex;

        }
        public void AddDetails(OrderDetails orderDetails)
        {
            if (this.Details.Contains(orderDetails))
            {
                throw new ApplicationException($"This goods {orderDetails.Goods.GoodsName} is already exists in the list!");

            }
            Details.Add(orderDetails);
        }
        public void RemoveDetails(int num)
        {
            Details.RemoveAt(num);
        }
        public override string ToString()
        {
            String result = $"OrderIndex:{OrderIndex}, Client:({Client.name})";
            Details.ForEach(detail => result += "\n\t" + detail);
            return result;
        }
        public override int GetHashCode()
        {
            return 2108858624 + OrderIndex.GetHashCode();
        }

        public int CompareTo(Order other)
        {
            if (other == null)
                return 1;
            return this.OrderIndex - other.OrderIndex;

        }
    }
}
