using Do_an;
using Do_an.Class;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
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
using System.Data.SqlClient;
namespace Do_an
{
    /// <summary>
    /// Interaction logic for F_Main.xaml
    /// </summary>
    public partial class F_Main : Window
    {
       
        public F_Main()
        {
            InitializeComponent();
            DataContext = this;
           
        }
        SanPham_DAO sanPham_DAO = new SanPham_DAO();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }

        private void btnTrangChu_Click(object sender, RoutedEventArgs e)
        {
            Const.kiemTraMuaHang = false;
            Const.listgiohang.Clear();
            PhanQuyen.menu = "TrangChu";
            btnBanHang.BorderThickness = new Thickness(0);
            btnDaMua.BorderThickness = new Thickness(0);
            btnTrangChu.BorderThickness = new Thickness(2,0,0,2);
            btnGioHang.BorderThickness = new Thickness(0); 
            btnTrangChu.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
            btnGioHang.Background = null;
            btnDaMua.Background = null;
            btnBanHang.Background = null;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/trangchu1.png", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            UC_MuaSam uC_MuaSam = new UC_MuaSam();
            user.Content = uC_MuaSam;
            btnCaiDat.Background = null;
            btnCaiDat.BorderThickness = new Thickness(0);
            texttimkiem = null;
            btnNguoiMua.Background = null;
            btnNguoiMua.BorderThickness = new Thickness(0);
            btnNguoiBan.Background = null;
            btnNguoiBan.BorderThickness = new Thickness(0);
            btnyeuthich.Background = null;
            btnyeuthich.BorderThickness = new Thickness(0);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //thanhmenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            //thanhmenu.IsChecked = true;
            

            string sql = $"select * from NguoiDung where TaiKhoan='{PhanQuyen.taikhoan}' ";
            Database database = new Database();
            DataTable dt = database.getAllData(sql);
            foreach (DataRow row in dt.Rows)
            {
                tentk.Text = row["HoTen"].ToString();
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(row["Avatar"].ToString(), UriKind.RelativeOrAbsolute);
                bitmap.EndInit();
                avatar.Source = bitmap;
            }
            if (PhanQuyen.loaiTk == "nguoimua")
            {
                btnThemSP.Visibility=Visibility.Collapsed;
                btnBanHang.Visibility = Visibility.Collapsed;
                btnNguoiBan.Visibility= Visibility.Collapsed;
                btnNguoiMua.Visibility=Visibility.Collapsed;
                btnTrangChu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                btnCaiDat.Visibility = Visibility.Collapsed;
            }
            else if (PhanQuyen.loaiTk == "nguoiban")
            {
                btnNguoiBan.Visibility = Visibility.Collapsed;
                btnNguoiMua.Visibility= Visibility.Collapsed;
                btnTrangChu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                BitmapImage bitmap1 = new BitmapImage();
                bitmap1.BeginInit();
                bitmap1.UriSource = new Uri("/image/voucher1.png", UriKind.RelativeOrAbsolute);
                bitmap1.EndInit();
                imagethongke.Source = bitmap1;
                txtthongke.Padding=new Thickness(0,0,30,0);
                txtthongke.Text = "Mã giảm giá";
            }
            else
            {
                btnThemSP.Visibility = Visibility.Collapsed;
                btnBanHang.Visibility = Visibility.Collapsed;
                btnGioHang.Visibility = Visibility.Collapsed;
                btnTrangChu.Visibility = Visibility.Collapsed;
                btnDaMua.Visibility = Visibility.Collapsed;
                btnyeuthich.Visibility= Visibility.Collapsed;
            }
            if (PhanQuyen.taikhoan == "admin")
            {
                txtthongke.Text = "Thống Kê";
                txtthongke.Padding=new Thickness(0,0,45,0);
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("/image/tk1.png", UriKind.RelativeOrAbsolute);
                bitmap.EndInit();
                imageTittle.Source = bitmap;
                BitmapImage bitmap1 = new BitmapImage();
                bitmap1.BeginInit();
                bitmap1.UriSource = new Uri("/image/thongke.png", UriKind.RelativeOrAbsolute);
                bitmap1.EndInit();
                imagethongke.Source = bitmap1;
            }
        }


        private void btnDangXuat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDaMua_Click(object sender, RoutedEventArgs e)  
        {
            //thanhmenu.IsChecked = true;
            Const.listgiohang.Clear(); 
            Const.kiemTraMuaHang = false;


            UC_DaMua uC_DaMua = new UC_DaMua();
            user.Content = uC_DaMua;
            btnDaMua.BorderThickness = new Thickness(2,0,0,2);
            btnTrangChu.BorderThickness = new Thickness(0);
            btnGioHang.BorderThickness = new Thickness(0);
            btnBanHang.BorderThickness = new Thickness(0);
            PhanQuyen.menu = "Damua";
            btnBanHang.Background = null;
            btnTrangChu.Background = null;
            btnGioHang.Background = null;
            btnDaMua.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/spdamua.png", UriKind.RelativeOrAbsolute); 
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnCaiDat.Background = null;
            btnCaiDat.BorderThickness = new Thickness(0);
            btnNguoiMua.Background = null;
            btnNguoiMua.BorderThickness = new Thickness(0);
            btnNguoiBan.Background = null;
            btnNguoiBan.BorderThickness = new Thickness(0);
            btnyeuthich.Background = null;
            btnyeuthich.BorderThickness = new Thickness(0);
        }

        public void btnGioHang_Click(object sender, RoutedEventArgs e)
        {
            //thanhmenu.IsChecked = true;

            UC_DaMua uC_GioHang = new UC_DaMua();
            uC_GioHang.tittle.Text = "Sản phẩm đã thêm vào giỏ";
            user.Content = uC_GioHang;
            btnDaMua.BorderThickness = new Thickness(0);
            btnTrangChu.BorderThickness = new Thickness(0);
            btnGioHang.BorderThickness = new Thickness(2, 0, 0, 2);
            btnBanHang.BorderThickness = new Thickness(0);
            PhanQuyen.menu = "GioHang";

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/giohang1.png", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnGioHang.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
            btnDaMua.Background = null;
            btnTrangChu.Background = null;
            btnBanHang.Background= null;
            btnCaiDat.Background = null;
            btnCaiDat.BorderThickness = new Thickness(0);
            btnNguoiMua.Background = null;
            btnNguoiMua.BorderThickness = new Thickness(0);
            btnNguoiBan.Background = null;
            btnNguoiBan.BorderThickness = new Thickness(0);
            btnyeuthich.Background = null;
            btnyeuthich.BorderThickness = new Thickness(0);
        }

        private void btnBanHang_Click(object sender, RoutedEventArgs e)
        {
            //thanhmenu.IsChecked = true;
            Const.listgiohang.Clear();
            Const.kiemTraMuaHang = false;

            btnBanHang.BorderThickness= new Thickness(2,0,0,2);
            btnDaMua.BorderThickness = new Thickness(0);
            btnTrangChu.BorderThickness = new Thickness(0);
            btnGioHang.BorderThickness = new Thickness(0);
            // btnThongKe.BorderThickness = new Thickness(0);
            PhanQuyen.menu = "BanHang";
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/banhang.png", UriKind.RelativeOrAbsolute); 
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnBanHang.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
            btnDaMua.Background = null;
            btnTrangChu.Background = null;
            btnGioHang.Background= null;
            btnCaiDat.Background = null;
            UC_DaMua uC_BanHang = new UC_DaMua();
            uC_BanHang.tittle.Text = "Sản phẩm đang bán";
            user.Content = uC_BanHang;
            btnCaiDat.BorderThickness = new Thickness(0);
            btnNguoiMua.Background = null;
            btnNguoiMua.BorderThickness = new Thickness(0);
            btnNguoiBan.Background = null;
            btnNguoiBan.BorderThickness = new Thickness(0);
            btnyeuthich.Background = null;
            btnyeuthich.BorderThickness = new Thickness(0);
        }
        private void Them_Click(object sender, EventArgs e)
        {
           
        }

        private void btnVoucher_Click(object sender, RoutedEventArgs e)
        {
            PhanQuyen.menu = "Voucher";
            if (PhanQuyen.loaiTk == "admin")
            {
                UC_Thongke uC_Thongke = new UC_Thongke();
                user.Content = uC_Thongke;
            }
            else if (PhanQuyen.loaiTk == "nguoiban")
            {
                
                UC_gioHang uC_GioHang = new UC_gioHang();
                user.Content = uC_GioHang;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("/image/giamgia.png", UriKind.RelativeOrAbsolute);
                bitmap.EndInit();
                imageTittle.Source = bitmap;
            }
            Const.listgiohang.Clear();
            Const.kiemTraMuaHang = false;
            btnyeuthich.Background = null;
            btnyeuthich.BorderThickness = new Thickness(0);
            btnBanHang.BorderThickness = new Thickness(0);
            btnDaMua.BorderThickness = new Thickness(0);
            btnTrangChu.BorderThickness = new Thickness(0);
            btnGioHang.BorderThickness = new Thickness(0);
            btnCaiDat.BorderThickness = new Thickness(2,0,0,2);
            btnBanHang.Background = null;
            btnDaMua.Background = null;
            btnTrangChu.Background = null;
            btnGioHang.Background = null;
            btnCaiDat.Background=new SolidColorBrush(Color.FromRgb(136, 0, 204)); 
            btnNguoiMua.Background = null;
            btnNguoiMua.BorderThickness = new Thickness(0);
            btnNguoiBan.Background = null;
            btnNguoiBan.BorderThickness = new Thickness(0);
        }
        public static string texttimkiem = "";
        private void timkiem_Click(object sender, RoutedEventArgs e)
        {
            timkiem1.Text = null;
            texttimkiem = txttimkiem.Text;
            sanPham_DAO.CapNhatSoLanTimKiem(texttimkiem);
            UC_MuaSam uc = new UC_MuaSam();
            user.Content = uc;
        }

        private void btnYeuThich_Click(object sender, RoutedEventArgs e)
        {
            PhanQuyen.menu = "YeuThich";
            Const.listgiohang.Clear();
            Const.kiemTraMuaHang = false;
            UC_gioHang uc = new UC_gioHang();
            user.Content = uc;
            btnBanHang.BorderThickness = new Thickness(0);
            btnDaMua.BorderThickness = new Thickness(0);
            btnTrangChu.BorderThickness = new Thickness(0);
            btnGioHang.BorderThickness = new Thickness(0);
            btnCaiDat.BorderThickness = new Thickness(0);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/yeuthichtile.png", UriKind.RelativeOrAbsolute); 
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnBanHang.Background = null;
            btnDaMua.Background = null;
            btnTrangChu.Background = null;
            btnGioHang.Background = null;
            btnCaiDat.Background = null;
            btnyeuthich.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
            btnyeuthich.BorderThickness = new Thickness(2, 0, 0, 2);
            btnNguoiMua.Background = null;
            btnNguoiMua.BorderThickness = new Thickness(0);
            btnNguoiBan.Background = null;
            btnNguoiBan.BorderThickness = new Thickness(0);

        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            logo.Visibility = Visibility.Collapsed;
            content.Margin = new Thickness(15, 100, 0, 10);
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Visible;
            logo.Visibility = Visibility.Visible;
            content.Margin = new Thickness(170, 100, 0, 10);
        }

        private void btnThemSP_Click(object sender, RoutedEventArgs e)
        {
            ThemSP_Window themSP_Window = new ThemSP_Window();
            themSP_Window.chinhsua.Visibility = Visibility.Collapsed;
            themSP_Window.Show();
        }

        private void btnNguoiBan_Click(object sender, RoutedEventArgs e)
        {
            UC_QL_NguoiBan uC_QL_NguoiBan=new UC_QL_NguoiBan();
            user.Content = uC_QL_NguoiBan;
            btnCaiDat.BorderThickness = new Thickness(0);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/nguoiban.png", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnCaiDat.Background = null;
            btnyeuthich.Background = null;
            btnyeuthich.BorderThickness = new Thickness(0);
            btnNguoiMua.Background = null;
            btnNguoiMua.BorderThickness = new Thickness(0);
            btnNguoiBan.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
            btnNguoiBan.BorderThickness = new Thickness(2, 0, 0, 2);
        }

        private void btnNguoiMua_Click(object sender, RoutedEventArgs e)
        {
            PhanQuyen.menu = "nguoimua";
            UC_gioHang uc = new UC_gioHang();
            user.Content=uc;
            btnCaiDat.BorderThickness = new Thickness(0);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/nguoimua.png", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnCaiDat.Background = null;
            btnyeuthich.BorderThickness = new Thickness(0);
            btnNguoiBan.Background = null;
            btnNguoiBan.BorderThickness = new Thickness(0);
            btnNguoiMua.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
            btnNguoiMua.BorderThickness = new Thickness(2, 0, 0, 2);
        }
    }
}
