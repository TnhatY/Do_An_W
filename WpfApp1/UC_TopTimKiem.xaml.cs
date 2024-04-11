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

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_TopTimKiem.xaml
    /// </summary>
    public partial class UC_TopTimKiem : UserControl
    {
        public UC_TopTimKiem()
        {
            InitializeComponent();
        }

        private void btnSpTop_Click(object sender, RoutedEventArgs e)
        {
            TopSanPham_Window topSanPham_Window = new TopSanPham_Window();
            topSanPham_Window.DanhMuc.Text = danhmuc.Text;
            topSanPham_Window.ShowDialog();
        }
    }
}
