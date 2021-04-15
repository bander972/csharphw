using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6.hw
{
    class OrderDetails
    {
        public Goods Goods { get; set; }

        public int Quantity { get; set; }

        public double Amount
        {
            get => Goods.GoodsPrice * Quantity;
        }

        public OrderDetails(Goods goods, int quantity)
        {
            this.Goods = goods;
            this.Quantity = quantity;
        }

        public override bool Equals(object obj)
        {
            var details = obj as OrderDetails;
            return details != null &&
                   EqualityComparer<Goods>.Default.Equals(Goods, details.Goods);
        }

        public override int GetHashCode()
        {
            return 785010553 + EqualityComparer<Goods>.Default.GetHashCode(Goods);
        }

        public override string ToString()
        {
            return $"OrderDetail:{Goods},{Quantity}";
        }
    }
}
