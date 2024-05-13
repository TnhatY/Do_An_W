using Do_an.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Media;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for ThongTin_Window.xaml
    /// </summary>
    public partial class ThongTin_Window : Window
    {
        NguoiDung nguoiDung =new NguoiDung();
        public ThongTin_Window()
        {
            InitializeComponent();
        }
        SanPham_DAO sanPham_DAO = new SanPham_DAO();
        NguoiBan nguoiBan = new NguoiBan();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }

        public static bool kthongtin= false;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Const.ktThongTin = true;
            string theloai = Theloai.Text;
            string sql1 = $"SELECT * FROM SanPham where TheLoai=N'{theloai}' and MaSP!='{MaSP.Text}'";
            if (sanPham_DAO.List_SP(sql1) == null)
            {
                chuDG.Text = "Không có sản phẩm nào";
            }else
                thongtin.ItemsSource = sanPham_DAO.List_SP(sql1);
           
            DanhGia_DAO danhGia_DAO = new DanhGia_DAO();
            string sql = "SELECT COUNT(*) FROM DanhGia_SP WHERE TenShop = @TenShop GROUP BY TenShop";

            sodanhgia.Text= danhGia_DAO.SoDanhGia(sql, TenShop.Text);
            string query = "Select sum(SoSao) FROM DanhGia_SP WHERE TenShop = @TenShop GROUP BY TenShop ";
            int sosao= int.Parse(danhGia_DAO.SoDanhGia(query, TenShop.Text));
            int sodanhgia1 = int.Parse(sodanhgia.Text);
            if (sodanhgia1 == 0)
            {
                danhGia_DAO.HienThiSoSao(0,starPanel);
            }
            else 
            {
                danhGia_DAO.HienThiSoSao(sosao / sodanhgia1,starPanel);
            }
            if (PhanQuyen.menu == "YeuThich")
            {
                titleyeuthich.Text = "Đã thích";
                kthongtin = true;
            }
        }

        private void btnThoat_Click_1(object sender, RoutedEventArgs e)
        {
            Const.ktThongTin = false;
            Close();
        }

        private void btnMua_Click(object sender, RoutedEventArgs e)
        {
            ThanhToan_Window thanhToan_Window = new ThanhToan_Window();
            thanhToan_Window.masp.Text = MaSP.Text;
            thanhToan_Window.Show();
            this.Hide();
        }

        private void btnThemGioHang_Click(object sender, RoutedEventArgs e)
        {
            string query = "insert into GioHang values (@MaSP,@TaiKhoan)";
            if (nguoiDung.ThemGioHang(MaSP.Text, PhanQuyen.taikhoan, query)==true|| nguoiDung.ThemGioHang(MaSP.Text, PhanQuyen.taikhoan, query) == false)
            {
                MessageBox.Show("Đã thêm sản phẩm vào giỏ hàng");
            };
        }

        private void xem_Click(object sender, RoutedEventArgs e)
        {
            XemDanhGia_Window xemDanhGia_Window =new XemDanhGia_Window();
            xemDanhGia_Window.tenshop.Text = TenShop.Text;
            xemDanhGia_Window.ShowDialog();
        }

        private void yeuthich_Click(object sender, RoutedEventArgs e)
        {
            if(titleyeuthich.Text=="Yêu Thích")
            {
                string sql = "Insert into SP_YeuThich values (@MaSP,@TaiKhoan)";
                if (nguoiDung.ThemGioHang(MaSP.Text, PhanQuyen.taikhoan, sql))
                {
                    MessageBox.Show("Đã thêm sản phẩm vào mục yêu thich", "Thông Báo");
                    titleyeuthich.Text = "Đã Thích";
                }
            }
            else
            {
                string sql = $"delete from SP_YeuThich where MaSP='{MaSP.Text}'";
                nguoiBan.Xoa(sql);
                MessageBox.Show("Bạn đã bỏ yêu thích sản phẩm!", "Thông báo");
                titleyeuthich.Text = "Yêu Thích";
            }
        }
        private int _currentImageIndex = 0;

        private void CapNhatHinhAnh()
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(sanPham_DAO.LoadHinhAnh(MaSP.Text)[_currentImageIndex], UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            HinhAnh.Source = bitmap;
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentImageIndex > 0)
            {
                _currentImageIndex--;
                CapNhatHinhAnh();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentImageIndex < sanPham_DAO.LoadHinhAnh(MaSP.Text).Count - 1)
            {
                _currentImageIndex++;
                CapNhatHinhAnh();
            }
        }

        private void spcuashop_Click(object sender, RoutedEventArgs e)
        {
            TopSanPham_Window topSanPham_Window = new TopSanPham_Window();
            topSanPham_Window.tenshop.Text = TenShop.Text;
            topSanPham_Window.ShowDialog();
        }
    }
}
