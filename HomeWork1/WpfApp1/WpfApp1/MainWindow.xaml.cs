using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp1
{
   
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        const double pi = 3.14;
        double num1, num2=0.0;
        String op="";
        public MainWindow()
        {
            InitializeComponent();
        }

            
        private void btn_minus_Click(object sender, RoutedEventArgs e)
        {
            num1 = double.Parse(txtbox_2.Text);
            txtbox_1.Text += btn_minus.Content;
            txtbox_2.Text = "";
            op = "-";

        }

        private void btn_plus_Click(object sender, RoutedEventArgs e)
        {
            num1 = double.Parse(txtbox_2.Text);
            txtbox_1.Text += btn_plus.Content;
            txtbox_2.Text = "";
            op = "+";
        }

        private void btn_equal_Click(object sender, RoutedEventArgs e)
        {
            num2 = double.Parse(txtbox_2.Text);
            switch (op)
            {
                case "+": txtbox_2.Text = (num1 + num2).ToString();
                    txtbox_1.Text += ("=" + txtbox_2.Text);
                    break;
                case "-":
                    txtbox_2.Text = (num1 - num2).ToString();
                    txtbox_1.Text += ("=" + txtbox_2.Text);
                    break;
                case "*":
                    txtbox_2.Text = (num1 * num2).ToString();
                    txtbox_1.Text += ("=" + txtbox_2.Text);
                    break;
                case "/":
                    if (num2 == 0) {
                        Console.WriteLine("MathException error");
                        return;
                    }
                    else
                    {
                        txtbox_2.Text = (num1 / num2).ToString();
                        txtbox_1.Text += ("=" + txtbox_2.Text);
                    }
                    break;
                default: Console.WriteLine("Invalid op");
                    return;
            }
        }

        private void btn_9_Click(object sender, RoutedEventArgs e)
        { 
            txtbox_1.Text += btn_9.Content;
            txtbox_2.Text += btn_9.Content;
        }
        private void btn_8_Click(object sender, RoutedEventArgs e)
        {  
            txtbox_1.Text += btn_8.Content;
            txtbox_2.Text += btn_8.Content;
        }
        private void btn_7_Click(object sender, RoutedEventArgs e)
        {   
            txtbox_1.Text += btn_7.Content;
            txtbox_2.Text += btn_7.Content;
        }
        private void btn_6_Click(object sender, RoutedEventArgs e)
        {           
            txtbox_1.Text += btn_6.Content;
            txtbox_2.Text += btn_6.Content;
        }

        private void btn_5_Click(object sender, RoutedEventArgs e)
        {            
            txtbox_1.Text += btn_5.Content;
            txtbox_2.Text += btn_5.Content;
        }

        private void btn_4_Click(object sender, RoutedEventArgs e)
        {        
            txtbox_1.Text += btn_4.Content;
            txtbox_2.Text += btn_4.Content;
        }
        private void btn_3_Click(object sender, RoutedEventArgs e)
        {           
            txtbox_1.Text+=btn_3.Content;
            txtbox_2.Text += btn_3.Content;
        }

        private void btn_2_Click(object sender, RoutedEventArgs e)
        {           
            txtbox_1.Text += btn_2.Content;
            txtbox_2.Text += btn_2.Content;
        }

        private void btn_1_Click(object sender, RoutedEventArgs e)
        {          
            txtbox_1.Text += btn_1.Content;
            txtbox_2.Text += btn_1.Content;
        }

        private void btn_0_Click(object sender, RoutedEventArgs e)
        {           
            txtbox_1.Text += btn_0.Content;
            txtbox_2.Text += btn_0.Content;
        }

        private void btn_dot_Click(object sender, RoutedEventArgs e)
        {           
            txtbox_1.Text += btn_dot.Content;
            txtbox_2.Text += btn_dot.Content;
        }

        private void btn_ac_Click(object sender, RoutedEventArgs e)
        {
            txtbox_1.Text = "";
            txtbox_2.Text = "";
        }

        private void btn_multiple_Click(object sender, RoutedEventArgs e)
        {
            num1 = double.Parse(txtbox_2.Text);
            txtbox_1.Text += btn_multiple.Content;
            txtbox_2.Text = "";
            op = "*";
        }

        private void btn_divide_Click(object sender, RoutedEventArgs e)
        {
            num1 = double.Parse(txtbox_2.Text);
            txtbox_1.Text += btn_divide.Content;
            txtbox_2.Text = "";
            op = "/";
        }

        private void txtbox_1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine("nothing here");
        }

    }
  }

