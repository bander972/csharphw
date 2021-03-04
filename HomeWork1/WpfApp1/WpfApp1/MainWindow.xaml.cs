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
        public List<char> inputstr = new List<char>();
        public MainWindow()
        {
            InitializeComponent();
        }
       
        private void btn_minus_Click(object sender, RoutedEventArgs e)
        {
            inputstr.Add('-');
            txtbox_1.Text.Append<char>('-');

        }

    

        private void btn_plus_Click(object sender, RoutedEventArgs e)
        {
            inputstr.Add('+');
            txtbox_1.Text.Append<char>('+');
        }

        private void btn_equals_Click(object sender, RoutedEventArgs e)
        {
            inputstr.Add('=');
            txtbox_1.Text.Append<char>('=');

        }

        private void btn_9_Click(object sender, RoutedEventArgs e)
        {
            inputstr.Add('9');
            txtbox_1.Text.Append<char>('9');
        }
    }
}
