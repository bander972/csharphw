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
    public partial class Form3 : Form
    {
        public OrderItem OrderItem { get; set; }

        public Form3()
        {
            InitializeComponent();
        }
        public Form3(OrderItem orderItem) : this()
        {
            this.OrderItem = orderItem;
            this.itemsbindingSource.DataSource = orderItem;
            goodsbindingSource.Add(new Goods("1", "apple", 100.0));
            goodsbindingSource.Add(new Goods("2", "egg", 200.0));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemsbindingSource.ResetBindings(false);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(int.TryParse(textQuantity.Text,out int quantity))
            {
                OrderItem orderItem = new OrderItem(comboBox1.ValueMember, quantity);
                itemsbindingSource.Add(orderItem);
            }
            this.Close();
        }
    }
}
