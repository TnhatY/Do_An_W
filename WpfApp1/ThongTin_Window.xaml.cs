using Do_an.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Media.Imaging;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for ThongTin_Window.xaml
    /// </summary>
    public partial class ThongTin_Window : Window
    {
        public ThongTin_Window()
        {
            InitializeComponent();
        }
        SanPham_DAO sanPham_DAO = new SanPham_DAO();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string tenshop = TenShop.Text;


            //sanPham_DAO.HienThiThongTin(MaSP.Text);

            
            string sql1 = $"SELECT * FROM SanPham where TenShop='{tenshop}' and MaSP!='{MaSP.Text}'";
            if (sanPham_DAO.Getlist(sql1) == null)
            {
                chuDG.Text = "Không có sản phẩm nào";
            }else
                thongtin.ItemsSource = sanPham_DAO.Getlist(sql1);

            Database database = new Database();
            try {
                using (SqlConnection connection = new SqlConnection(database.conStr))
                {
                    connection.Open();
                    string sql = "SELECT COUNT(*) FROM DanhGia_SP WHERE TenShop = @tenshop GROUP BY TenShop";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                       
                        command.Parameters.AddWithValue("@tenshop", tenshop);

                        int count = (int)command.ExecuteScalar();
                        sodanhgia.Text = count.ToString();
                    }
                }
            }catch (Exception ex)
            {
                sodanhgia.Text = "0";
            }
           
        }

        private void btnThoat_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMua_Click(object sender, RoutedEventArgs e)
        {
            ThanhToan_Window thanhToan_Window = new ThanhToan_Window();
            thanhToan_Window.masp.Text = MaSP.Text;
            thanhToan_Window.tensp.Text = TenSP.Text;
            thanhToan_Window.tenshop.Text = TenShop.Text;
            thanhToan_Window.giaban.Text = GiaBan.Text;
            thanhToan_Window.hinhanh.Source = HinhAnh.Source;
            thanhToan_Window.Show();
            this.Hide();
        }

        private void btnThemGioHang_Click(object sender, RoutedEventArgs e)
        {
            string query = "insert into GioHang values (@MaSP,@TaiKhoan)";

            if (sanPham_DAO.themGioHang(MaSP.Text, PhanQuyen.taikhoan, query))
            {
                MessageBox.Show("Đã thêm sản phẩm vào giỏ hàng");
            };
            Close();
        }

        private void xem_Click(object sender, RoutedEventArgs e)
        {
            XemDanhGia_Window xemDanhGia_Window =new XemDanhGia_Window();
            xemDanhGia_Window.tenshop.Text = TenShop.Text;
            xemDanhGia_Window.ShowDialog();
        }

        private void yeuthich_Click(object sender, RoutedEventArgs e)
        {
            
            string sql = "Insert into SP_YeuThich values (@MaSP,@TaiKhoan)";
            if (sanPham_DAO.themGioHang(MaSP.Text, PhanQuyen.taikhoan, sql))
            {
                MessageBox.Show("Đã thêm sản phẩm vào mục yêu thich","Thông Báo");

            }
        }
        private int _currentImageIndex = 0;

        private void UpdateImage()
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
                UpdateImage();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentImageIndex < sanPham_DAO.LoadHinhAnh(MaSP.Text).Count - 1)
            {
                _currentImageIndex++;
                UpdateImage();
            }
        }
    }
}
