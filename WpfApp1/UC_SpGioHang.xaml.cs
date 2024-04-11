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

       
        private void btnHienThiThonTin_Click(object sender, RoutedEventArgs e)
        {
            ThongTin_Window thongTin_Window = new ThongTin_Window();
            thongTin_Window.TenSP.Text = lblTenSP.Text;
            thongTin_Window.TenShop.Text = lblTenShop.Text;
            thongTin_Window.GiaBan.Text = lblGiaHTai.Text;
            thongTin_Window.GiaGoc.Text = lblGiaGoc.Text;
            thongTin_Window.MoTa.Text = mota.Text;
            thongTin_Window.TinhTrang.Text = tinhtrang.Text;
            thongTin_Window.HinhAnh.Source = hinhanh.Source;
            thongTin_Window.btnThemGioHang.Visibility = Visibility.Hidden;

            thongTin_Window.ShowDialog();
        }

        private void Thoat_Click(object sender, RoutedEventArgs e)
        {
            //btnHienThiThonTin.Visibility = Visibility.Hidden;
        }
        public static bool check = false;
        public static List<string> listmasp= new List<string>();
           
        private void Thoat_Checked(object sender, RoutedEventArgs e)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/check.png", UriKind.Relative);
            bitmap.EndInit();
            imagecheck.Source = bitmap;
            listmasp.Add(masp.Text);
            check = true;
        }

        private void Thoat_Unchecked(object sender, RoutedEventArgs e)
        {
            imagecheck.Source = null;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
