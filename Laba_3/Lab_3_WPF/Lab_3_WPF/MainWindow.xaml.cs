using Microsoft.Win32;
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

namespace Lab_3_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt_1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string fname = ofd.FileName;

            card_1.Name.Content = tb_1.Text;
            card_1.Pic = new BitmapImage(new Uri(fname));
        }

        private void bt_2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string fname = ofd.FileName;

            card_2.Name.Content = tb_2.Text;
            card_2.Pic = new BitmapImage(new Uri(fname));
        }

        private void bt_3_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string fname = ofd.FileName;

            card_3.Name.Content = tb_3.Text;
            card_3.Pic = new BitmapImage(new Uri(fname));
        }
    }
}
