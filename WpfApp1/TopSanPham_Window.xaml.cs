using Do_an.Class;
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
using System.Windows.Shapes;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for TopSanPham_Window.xaml
    /// </summary>
    public partial class TopSanPham_Window : Window
    {
        SanPham_DAO SanPham_DAO = new SanPham_DAO();
        public TopSanPham_Window()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Const.ktThongTin == false)
                {
                    string query = "select * from SanPham where TheLoai like N'%" + DanhMuc.Text + "%' and SoLanTimKiem > 0";
                    title.Text = "Top sản phẩm được tìm kiếm nhiều";
                    item.ItemsSource = SanPham_DAO.List_SP(query);
                }
                else
                {
                    string query = $"select * from SanPham where TenShop = N'{tenshop.Text}'";
                    title.Text = "Các sản phẩm đang được bán của shop";

                    item.ItemsSource = SanPham_DAO.List_SP(query);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void thoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
