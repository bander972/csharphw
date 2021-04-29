using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderApp
{
    public class Order
    {
        public static uint orderIndex = 1;

        public DateTime OrderDate { get; set; }

        public uint OrderIndex { get; set; }

        public Shopper Shopper { get; set; }

        public List<OrderItem> Items { get; }

        public Order() { }

        public Order(DateTime OrderDate, Shopper Shopper, List<OrderItem> Items)
        {
            this.OrderDate = OrderDate == null ? DateTime.Now : OrderDate;
            this.OrderIndex = Order.orderIndex++;
            this.Shopper = Shopper;
            this.Items = Items != null ? Items : new List<OrderItem>();
        }

        public Order(uint OrderIndex, DateTime OrderDate, Shopper Shopper, List<OrderItem> Items)
        {
            this.OrderDate = OrderDate == null ? DateTime.Now : OrderDate;
            this.OrderIndex = OrderIndex;
            this.Shopper = Shopper;
            this.Items = Items != null ? Items : new List<OrderItem>();
        }
        
        public void AddItem(OrderItem orderItem)
        {
            if (Items.Contains(orderItem))
                throw new ApplicationException($"添加错误：订单项{orderItem.GoodsName} 已经存在!");
            Items.Add(orderItem);
        }

        public void RemoveItem(OrderItem orderItem)
        {
            Items.Remove(orderItem);
        }

        public double TotalPrice
        {
            get => Items.Sum(Item => Item.TotalPrice);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"[OrderId: {OrderIndex} OrderDate:{OrderDate} OrderShopper:{Shopper} TotalPrice:{TotalPrice}]");
            Items.ForEach(item => stringBuilder.Append("\n\t" + item.ToString()));
            return stringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null && this.OrderIndex == order.OrderIndex;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
