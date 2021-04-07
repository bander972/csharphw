using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class Goods
    {
        private double price;
        public double GoodsPrice { get { return price; }
            set {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("the price should be>=0!");
                }
                price = value;
            }
        }
       
        public string GoodsName { get; set; }
        public int Id { get; set; }
        public Goods(int id,string name,double price)
        {
            this.Id = id;
            this.GoodsName = name;
            this.GoodsPrice = price;
        }

        public override string ToString()
        {
            return $"ID:{Id},Name:{GoodsName},value:{GoodsPrice} ";
        }
        public override bool Equals(object obj)
        {
            var goods = obj as Goods;
            return goods != null && goods.GoodsName == this.GoodsName;
        }
        public override int GetHashCode()
        {
            return int.MaxValue + Id.GetHashCode();
        }
    }
}
