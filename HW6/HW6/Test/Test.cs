using HW6.hw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW6.Test
{
    [TestClass()]
    class Test
    {
        ClientInfo customer1 = new ClientInfo(1,"alan","wuhan",100487);
        Goods banana = new Goods(30,"banana",5.00);
        Goods bread = new Goods(15, "bread",6.00);

        [TestInitialize()]
        void Init()
        {
            Order order1 = new Order(1,customer1);
            Order order2 = new Order(2, customer1);
            OrderService
        }


    }
}
