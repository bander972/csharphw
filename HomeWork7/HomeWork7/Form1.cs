using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.Add(new ColorName() { Color = Color.Red ,Name="红色"});
            comboBox1.Items.Add(new ColorName() { Color = Color.Green, Name = "绿色" });
            comboBox1.Items.Add(new ColorName() { Color = Color.Blue, Name = "蓝色" });
            comboBox1.Items.Add(new ColorName() { Color = Color.Black, Name = "黑色" });
            comboBox1.Items.Add(new ColorName() { Color = Color.Cyan, Name = "青色" });
            comboBox1.SelectedIndex = 0;
        }
        private Graphics graphics=null;
        int depth;
        double th1;
        double th2;
        double per1;
        double per2;
        double len;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        { //递归深度
            if (numericUpDown1.Value <= 0 || numericUpDown1.Value > 15)
            {
                throw new ApplicationException("递归深度必须大于0!");
            }
            numericUpDown1.Maximum = 15;
            numericUpDown1.Minimum = 0;
            numericUpDown1.Increment = 1;
            this.depth = (int)numericUpDown1.Value;
        }
        void drawCayleyTree(int n,double x0,double y0,double len,double th)
        {
            if (n == 0)
            {
                return;
            }
            double x1 = x0 + len * Math.Cos(th);
            double y1 = y0 + len * Math.Sin(th);
            drawline(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * len, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * len, th - th2);
        }
        void drawline(double x0,double y0,double x1,double y1) {
            // 用指定颜色做直线
            ColorName colorName = (ColorName)comboBox1.SelectedItem;
            Brush brush = new SolidBrush(colorName.Color);
            Pen pen = new Pen(brush, 3);
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null)
            {
                graphics = panel3.CreateGraphics();
            }
            
            drawCayleyTree(depth,500,700, len,-Math.PI/2);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        { //右分支长度比
            numericUpDown2.Maximum = 3.0M;
            numericUpDown2.Minimum = 0.0M;
            numericUpDown2.Increment = 0.1M;
            if (numericUpDown2.Value < 0.0M || numericUpDown2.Value > 3.0M)
            {
                throw new ApplicationException("右分支长度比必须大于0，尽量小于3！");
                
            }
            this.per1=(double)numericUpDown2.Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown3.Maximum = 3.0M;
            numericUpDown3.Minimum = 0M;
            numericUpDown3.Increment = 0.1M;
            if (numericUpDown3.Value < 0.0M || numericUpDown3.Value > 3.0M)
            {
                throw new ApplicationException("左分支长度比必须大于0，尽量小于3！");

            }
            this.per2 = (double)numericUpDown3.Value;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown4.Maximum = 180.0M;
            numericUpDown4.Minimum = 0.0M;
            numericUpDown4.Increment =1.0M ;
            if (numericUpDown4.Value < 0.0M || numericUpDown4.Value > 180.0M)
            {
                throw new ApplicationException("角度必须在0-180之间！");
            }
            this.th1 =( (double)numericUpDown4.Value) * (Math.PI / 180);
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown5.Maximum = 180.0M;
            numericUpDown5.Minimum = 0.0M;
            numericUpDown5.Increment = 1.0M;
            if (numericUpDown5.Value < 0.0M || numericUpDown5.Value > 180.0M)
            {
                throw new ApplicationException("角度必须在0-180之间！");
            }
            this.th2 = ((double)numericUpDown5.Value) * (Math.PI / 180);
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown6.Maximum = 500M;
            numericUpDown6.Minimum = 0.0M;
            numericUpDown6.Increment = 1M;
            if (numericUpDown6.Value < 0.0M || numericUpDown5.Value > 500M)
            {
                throw new ApplicationException("主干长度必须大于0，最好控制在150以内！");
            }
            this.len = (double)numericUpDown6.Value;
        }

 
    }
    class ColorName
    {
        public Color Color;
        public string Name;

        public override string ToString()
        {
            return Name;
        }
    }
}
