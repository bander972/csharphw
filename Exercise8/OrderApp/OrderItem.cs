using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApp
{
    public class OrderItem
    {
        public uint Index { get; set; }        

        public string GoodsName { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public OrderItem() { }

        public OrderItem(uint Index, string GoodsName, double Price, int Quantity)
        {
            this.Index = Index;
            this.GoodsName = GoodsName;
            this.Price = Price;
            this.Quantity = Quantity;
        }


        public OrderItem(string GoodsName, int quantity)
        {
            this.GoodsName = GoodsName;
            this.Quantity = quantity;
        }

        public double TotalPrice { get => Price * Quantity; }

        public override string ToString()
        {
            return $"[NO:{Index} Goods:{GoodsName} Quantity:{Quantity} TotalPrice:{TotalPrice}]";
        }

        public override bool Equals(object obj)
        {
            var Item = obj as OrderItem;
            return Item != null && this.GoodsName == Item.GoodsName;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
