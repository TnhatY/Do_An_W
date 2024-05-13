using Do_an.Class;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for ThemSP_Window.xaml
    /// </summary>
    public partial class ThemSP_Window : Window
    {
        SanPham_DAO sanPham_DAO = new SanPham_DAO();
        NguoiBan nguoiBan = new NguoiBan();
        public ThemSP_Window()
        {
            InitializeComponent();
        }
        List<string> DanhMuc = new List<string> { "Điện thoại", "Đồ gia dụng", "Xe cộ", "Đồ điện tử", "Thời trang","Thể thao" };
        List<string> TheLoai = new List<string> { "Iphone", "Bàn ghế", "Ô tô", "Xe máy", "Xe đạp","MacBook", "Máy tính", "Tivi", "Giày đá banh","Vợt cầu lông", "Đồ nội trợ", "Điện tử", "Máy tính bàn", "Laptop" };
        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Image_Button(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(filePath, UriKind.RelativeOrAbsolute);
                bitmap.EndInit();
                imgHinhAnh.Source = bitmap;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbDanhMuc.ItemsSource = DanhMuc;
            cbTheLoai.ItemsSource= TheLoai;
        }
        static bool IsNumeric(string str)
        {
            double num;
            return double.TryParse(str, out num);
        }

        private void btnThem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                SanPham sanPhamMoi = new SanPham();
                if(cbDanhMuc.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn danh mục sản phẩm!", "Thông báo");
                    return;
                }
                if (cbTheLoai.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn thể loại sản phẩm!", "Thông báo");
                    return;
                }
                if (txtMaSP.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mã sản phẩm!", "Thông báo");
                    return;
                }
                if (txtTenSP.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Thông báo");
                    return;
                }
                if (txtTinhTrang.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập tình trạng sản phẩm!", "Thông báo");
                    return;
                }
                if (txtMoTa.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mô tả sản phẩm!", "Thông báo");
                    return;
                }
                if (dtpNgayMua.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn ngày mua sản phẩm!", "Thông báo");
                    return;
                }
                if (IsNumeric(txtGiaGoc.Text) && IsNumeric(txtGiaBan.Text))
                {
                    sanPhamMoi.GiaGoc = float.Parse(txtGiaGoc.Text);
                    sanPhamMoi.GiaHTai = float.Parse(txtGiaBan.Text);
                }
                else
                {
                    MessageBox.Show("Giá nhập vào không đúng định dạng!", "Thông báo");
                    return;
                }
                if (imgHinhAnh.Source.ToString() == "")
                {
                    MessageBox.Show("Vui lòng thêm hình ảnh cho sản phẩm", "Thông báo");
                    return;
                }
                sanPhamMoi.DanhMucSP = cbDanhMuc.Text;
                sanPhamMoi.MaSP = txtMaSP.Text;
                sanPhamMoi.TenSP = txtTenSP.Text;
                sanPhamMoi.TenShop = PhanQuyen.ten;
                sanPhamMoi.TinhTrang = txtTinhTrang.Text;
                sanPhamMoi.NgayMua = dtpNgayMua.Text;
                sanPhamMoi.MoTa = txtMoTa.Text;
                sanPhamMoi.TheLoai = cbTheLoai.Text;
                sanPhamMoi.HinhAnh = imgHinhAnh.Source.ToString();
                sanPhamMoi.HinhAnh2 = imgHinhAnh2.Source.ToString();
                sanPhamMoi.HinhAnh3 = imgHinhAnh3.Source.ToString();
                sanPhamMoi.HinhAnh4 = imgHinhAnh4.Source.ToString();
                string query = "insert into SanPham values (@MaSP,@TenSP,@TenShop,@GiaGoc,@GiaHTai,@NgayMua,@TinhTrang,@MoTa,@HinhAnh,@DanhMucSP,@SoLanTimKiem,@TheLoai,@HinhAnh2,@HinhAnh3,@HinhAnh4)";

                nguoiBan.Them_Sua_SP(sanPhamMoi, query);
                nguoiBan.ThemSP_Ban(txtMaSP.Text);
                Close();
            }
            catch
            {

            }
               
          
          
        }

        private void btnChinhSua(object sender, RoutedEventArgs e)
        {
            string query = "update SanPham set TenSP=@TenSP, TenShop=@TenShop,GiaGoc=@GiaGoc,GiaHTai=@GiaHTai," +
                "NgayMua=@NgayMua,TinhTrang=@TinhTrang,MoTa=@MoTa,HinhAnh=@HinhAnh,DanhMucSP=@DanhMucSP,SoLanTimKiem=@SoLanTimKiem, TheLoai=@TheLoai,HinhAnh2=@HinhAnh2,HinhAnh3=@HinhAnh3,HinhAnh4=@HinhAnh4 where MaSP=@MaSP";
            SanPham sanPham = new SanPham(txtMaSP.Text, txtTenSP.Text, PhanQuyen.ten, float.Parse(txtGiaGoc.Text), float.Parse(txtGiaBan.Text), dtpNgayMua.Text, txtTinhTrang.Text, txtMoTa.Text, imgHinhAnh.Source.ToString(), cbDanhMuc.Text,cbTheLoai.Text,imgHinhAnh2.Source.ToString(), imgHinhAnh3.Source.ToString(), imgHinhAnh4.Source.ToString());
            nguoiBan.Them_Sua_SP(sanPham, query);
            MessageBox.Show("Sản phẩm đã được chỉnh sửa");
            Close();

        }
        private void Image_Button2(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(filePath, UriKind.RelativeOrAbsolute);
                bitmap.EndInit();
                imgHinhAnh2.Source = bitmap;
            }
        }

        private void Image_Button3(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(filePath, UriKind.RelativeOrAbsolute);
                bitmap.EndInit();
                imgHinhAnh3.Source = bitmap;
            }
        }

        private void Image_Button4(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
              
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(filePath, UriKind.RelativeOrAbsolute);
                bitmap.EndInit();
                imgHinhAnh4.Source = bitmap;
            }
        }
    }
}