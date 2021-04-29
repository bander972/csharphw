using OrderApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderForm
{
    public partial class FormMain : Form
    {
        OrderService orderService;
        BindingSource fieldsBS = new BindingSource();
        public string Keyword { get; set; }

        public FormMain()
        {
            InitializeComponent();
            orderService = new OrderService();
            Order order = new Order(1, DateTime.Now, new Shopper("li"), new List<OrderItem>());
            order.AddItem(new OrderItem(1, "apple", 5,10));
            orderService.AddOrder(order);
            Order order2 = new Order(2, DateTime.Now, new Shopper("2", "zhang"), new List<OrderItem>());
            order2.AddItem(new OrderItem(1,  "egg", 6,10));
            orderService.AddOrder(order2);
            orderbindingSource.DataSource = orderService.Orders;
            queryCondition.SelectedIndex = 0;
            queryText.DataBindings.Add("Text", this, "Keyword");
        }

        private void btn_add_Click(object sender, EventArgs e)//添加订单
        {
            Form2 form2 = new Form2(new Order());
            if (form2.ShowDialog() == DialogResult.OK)
            {
                orderService.AddOrder(form2.CurrentOrder);
                QueryAll();
            }
        }

        private void QueryAll()//默认查询全部订单并显示
        {
            orderbindingSource.DataSource = orderService.Orders;
            orderbindingSource.ResetBindings(false);
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            switch (queryCondition.SelectedIndex)
            {
                case 0://查询所有订单
                    orderbindingSource.DataSource = orderService.Orders;
                    break;
                case 1://根据id查询
                    int.TryParse(Keyword, out int id);
                    Order order = orderService.GetOrder((uint)id);
                    List<Order> result = new List<Order>();
                    if (order != null) result.Add(order);
                    orderbindingSource.DataSource = result;
                    break;
                case 2://根据客户查询
                    orderbindingSource.DataSource = orderService.QueryOrdersByShopper(Keyword);
                    break;
                case 3://根据货物查询
                    orderbindingSource.DataSource = orderService.QueryOrdersByGoodsName(Keyword);
                    break;
                case 4://根据总价格查询
                    float.TryParse(Keyword, out float totalPrice);
                    orderbindingSource.DataSource =
                           orderService.QueryByTotalAmount(totalPrice);
                    break;
                default:
                    break;
            }
            orderbindingSource.ResetBindings(true);
        }
              
        private void btn_revise_Click(object sender, EventArgs e)
        {
            EditOrder();
        }

        private void EditOrder()
        {
            Order order = orderbindingSource.Current as Order;
            if (order == null)
            {
                MessageBox.Show("请选择一个订单进行修改");
                return;
            }
            Form2 form2 = new Form2(order, true);
            if (form2.ShowDialog() == DialogResult.OK)
            {
                orderService.UpdateOrder(form2.CurrentOrder);
                QueryAll();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            Order order = orderbindingSource.Current as Order;
            if (order == null)
            {
                MessageBox.Show("请选择一个订单进行删除");
                return;
            }
            orderService.RemoveOrder(order.OrderIndex);
            QueryAll();
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = openFileDialog1.FileName;
                orderService.Import(fileName);
                QueryAll();
            }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = saveFileDialog1.FileName;
                orderService.Export(fileName);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EditOrder();
        }

        private void queryCondition_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
