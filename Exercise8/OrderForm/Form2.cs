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
    public partial class Form2 : Form
    {
        public Order CurrentOrder { get; set; }
        public Form2()
        {
            InitializeComponent();
            shopperbindingSource.Add(new Shopper("li"));
            shopperbindingSource.Add(new Shopper("zhang"));
        }

        public Form2(Order order, bool editMode = false) : this()
        {    
            CurrentOrder = order;
            orderbindingSource.DataSource = CurrentOrder;
            textOrderID.Enabled = !editMode;
            if (!editMode)
            {
                CurrentOrder.Shopper = (Shopper)shopperbindingSource.Current;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(new OrderItem());
            try
            {
                if (form3.ShowDialog() == DialogResult.OK)
                {
                    uint index = 0;
                    if (CurrentOrder.Items.Count != 0)
                    {
                        index = CurrentOrder.Items.Max(i => i.Index) + 1;
                    }
                    form3.OrderItem.Index = index;
                    CurrentOrder.AddItem(form3.OrderItem);
                    itemsbindingSource.ResetBindings(false);
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void btn_revise_Click(object sender, EventArgs e)
        {
            EditItem();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            OrderItem orderItem = itemsbindingSource.Current as OrderItem;
            if (orderItem == null)
            {
                MessageBox.Show("请选择一个订单项进行删除");
                return;
            }
            CurrentOrder.RemoveItem(orderItem);
            itemsbindingSource.ResetBindings(false);
        }

        private void EditItem()
        {
            OrderItem orderItem = itemsbindingSource.Current as OrderItem;
            if (orderItem == null)
            {
                MessageBox.Show("请选择一个订单项进行修改");
                return;
            }
            Form3 form3 = new Form3(orderItem);
            if (form3.ShowDialog() == DialogResult.OK)
            {
                itemsbindingSource.ResetBindings(false);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EditItem();
        }

    }
}
