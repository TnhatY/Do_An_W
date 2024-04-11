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
                //MessageBox.Show(DanhMuc.Text);
                //string danhmuc = DanhMuc.Text;
                string query = "select * from SanPham where TheLoai like N'%" + DanhMuc.Text + "%' and SoLanTimKiem > 0";
                // string sql = $"Select * from SanPham where DanhMucSP='{danhmuc}'";
                string sql2 = "Select * from TopDanhMuc where LuotTimKiem >= 0";
                //string query = $"select * from SanPham where DanhMucSP like N'%" + category + "%' and SoLanTimKiem > 0";

                item.ItemsSource = SanPham_DAO.Getlist(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
