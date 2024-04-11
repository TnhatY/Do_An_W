using Do_an;
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
    /// Interaction logic for UC_SanPham.xaml
    /// </summary>
    public partial class UC_SanPham : UserControl
    {
        public UC_SanPham()
        {
            InitializeComponent();
        }
        //public event EventHandler<DataEventArgs> DataRequested;

      
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //ThongTin_Window thongTin = new ThongTin_Window();
            //thongTin.TenSP.Text = ten.Text;
           // thongTin.MaSP.Text = masp.Text;
            //thongTin.TenShop.Text =tenshop.Text;
            //thongTin.GiaGoc.Text = giagoc.Text;
            //thongTin.GiaBan.Text = giaBan.Text;
            //thongTin.NgayMua.Text = ngaymua.Text;
            //thongTin.TinhTrang.Text = tinhtrang.Text;
            //thongTin.MoTa.Text = mota.Text;
            //thongTin.HinhAnh.Source = hinhanh.Source;
            //MessageBox.Show(ngaymua.Text);
            SanPham_DAO sanPham_DAO = new SanPham_DAO();
            sanPham_DAO.HienThiThongTin(masp.Text);

           // thongTin.ShowDialog(); 
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (PhanQuyen.menu == "YeuThich")
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("/image/datim.png", UriKind.RelativeOrAbsolute);
                bitmap.EndInit();
                imagetim.Source = bitmap;
            }
        }

        private void tim_Checked(object sender, RoutedEventArgs e)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/datim.png", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            imagetim.Source = bitmap;
            SanPham_DAO sanPham_DAO = new SanPham_DAO();
            string sql = "Insert into SP_YeuThich values (@MaSP,@TaiKhoan)";
            if (sanPham_DAO.themGioHang(masp.Text, PhanQuyen.taikhoan, sql))
            {
                return;
            }
        }
    }
}
