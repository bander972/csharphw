﻿using System;
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
        public List<char> inputstr = new List<char>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_minus_Click(object sender, RoutedEventArgs e)
        {
            inputstr.Add('-');
            txtbox_1.Text += btn_0.Content;

        }

        private void btn_plus_Click(object sender, RoutedEventArgs e)
        {
            inputstr.Add('+');
            txtbox_1.Text += btn_plus.Content;
        }

        private void btn_equals_Click(object sender, RoutedEventArgs e)
        {
            inputstr.Add('=');
            txtbox_1.Text += btn_equal.Content;


        }

        private void btn_9_Click(object sender, RoutedEventArgs e)
        {
            inputstr.Add('9');
            txtbox_1.Text += btn_9.Content;
        }
        private void btn_8_Click(object sender, RoutedEventArgs e)
        {
            inputstr.Add('8');
            txtbox_1.Text += btn_8.Content;
        }
        private void btn_7_Click(object sender, RoutedEventArgs e)
        {
            inputstr.Add('7');
            txtbox_1.Text += btn_7.Content;
        }
        private void btn_6_Click(object sender, RoutedEventArgs e)
        {
            inputstr.Add('6');
            txtbox_1.Text += btn_6.Content;
        }

        private void btn_5_Click(object sender, RoutedEventArgs e)
        {
            inputstr.Add('5');
            txtbox_1.Text += btn_5.Content;
        }

        private void btn_4_Click(object sender, RoutedEventArgs e)
        {
            inputstr.Add('4');
            txtbox_1.Text += btn_4.Content;
        }
        private void btn_3_Click(object sender, RoutedEventArgs e)
        {
            inputstr.Add('3');
            txtbox_1.Text+=btn_3.Content;
        }

        private void btn_2_Click(object sender, RoutedEventArgs e)
        {
            inputstr.Add('2');
            txtbox_1.Text += btn_2.Content;
        }

        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            inputstr.Add('1');
            txtbox_1.Text += btn_1.Content;
        }

        private void btn_0_Click(object sender, RoutedEventArgs e)
        {
            inputstr.Add('0');
            txtbox_1.Text += btn_0.Content;
        }

        private void btn_dot_Click(object sender, RoutedEventArgs e)
        {
            inputstr.Add('.');
            txtbox_1.Text += btn_dot.Content;
        }

        private void btn_pi_Click(object sender, RoutedEventArgs e)
        {
            inputstr.Add('π');
            txtbox_1.Text += btn_pi.Content;
        }

        private void btn_multiple_Click(object sender, RoutedEventArgs e)
        {
            inputstr.Add('*');
            txtbox_1.Text += btn_multiple.Content;
        }

        private void btn_divide_Click(object sender, RoutedEventArgs e)
        {
            inputstr.Add('/');
            txtbox_1.Text += btn_divide.Content;
        }

        private void txtbox_1_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

    }
  }

