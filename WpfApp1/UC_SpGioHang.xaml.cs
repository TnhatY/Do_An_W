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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_SpGioHang.xaml
    /// </summary>
    public partial class UC_SpGioHang : UserControl
    {
        public UC_SpGioHang()
        {
            InitializeComponent();
        }

        SanPham_DAO sanpham_dao= new SanPham_DAO();
        private void btnHienThiThonTin_Click(object sender, RoutedEventArgs e)
        {
           
        }

       
           
        private void Thoat_Checked(object sender, RoutedEventArgs e)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/check.png", UriKind.Relative);
            bitmap.EndInit();
            imagecheck.Source = bitmap;
            Const.listgiohang.Add(masp.Text);
            Const.kiemTraMuaHang = true;
        }

        private void Thoat_Unchecked(object sender, RoutedEventArgs e)
        {
            imagecheck.Source = null;
            Const.kiemTraMuaHang = false;
            Const.listgiohang.Remove(masp.Text);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
