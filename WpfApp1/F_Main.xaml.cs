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
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }

        private void btnTrangChu_Click(object sender, RoutedEventArgs e)
        {
            //thanhmenu.IsChecked = true;
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

            btnyeuthich.Background = null;
            btnyeuthich.BorderThickness = new Thickness(0);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //thanhmenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            //thanhmenu.IsChecked = true;
            btnTrangChu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            if (PhanQuyen.loaiTk == "nguoimua")
            {
                btnThemSP.Visibility=Visibility.Collapsed;
                btnBanHang.Visibility = Visibility.Collapsed;
            }
        }


        private void btnDangXuat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDaMua_Click(object sender, RoutedEventArgs e)  
        {
            //thanhmenu.IsChecked = true;

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
            bitmap.UriSource = new Uri("/image/spdamua.png", UriKind.RelativeOrAbsolute); // Thay đổi path_to_your_image.jpg thành đường dẫn của ảnh của bạn
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnCaiDat.Background = null;
            btnCaiDat.BorderThickness = new Thickness(0);

            btnyeuthich.Background = null;
            btnyeuthich.BorderThickness = new Thickness(0);
        }

        private void btnGioHang_Click(object sender, RoutedEventArgs e)
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
            bitmap.UriSource = new Uri("/image/giohang1.png", UriKind.RelativeOrAbsolute); // Thay đổi path_to_your_image.jpg thành đường dẫn của ảnh của bạn
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnGioHang.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
            btnDaMua.Background = null;
            btnTrangChu.Background = null;
            btnBanHang.Background= null;
            btnCaiDat.Background = null;
            btnCaiDat.BorderThickness = new Thickness(0);

            btnyeuthich.Background = null;
            btnyeuthich.BorderThickness = new Thickness(0);
        }

        private void btnBanHang_Click(object sender, RoutedEventArgs e)
        {
            //thanhmenu.IsChecked = true;

            btnBanHang.BorderThickness= new Thickness(2,0,0,2);
            btnDaMua.BorderThickness = new Thickness(0);
            btnTrangChu.BorderThickness = new Thickness(0);
            btnGioHang.BorderThickness = new Thickness(0);
            // btnThongKe.BorderThickness = new Thickness(0);
            PhanQuyen.menu = "BanHang";
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/banhang.png", UriKind.RelativeOrAbsolute); // Thay đổi path_to_your_image.jpg thành đường dẫn của ảnh của bạn
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
            // btnThongKe.Background = null;

            btnyeuthich.Background = null;
            btnyeuthich.BorderThickness = new Thickness(0);
        }
        private void Them_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCaiDat_Click(object sender, RoutedEventArgs e)
        {
            UC_CaiDat uC_CaiDat = new UC_CaiDat();
            user.Content = uC_CaiDat;
            //thanhmenu.IsChecked = true;

            btnyeuthich.Background = null;
            btnyeuthich.BorderThickness = new Thickness(0);

            btnBanHang.BorderThickness = new Thickness(0);
            btnDaMua.BorderThickness = new Thickness(0);
            btnTrangChu.BorderThickness = new Thickness(0);
            btnGioHang.BorderThickness = new Thickness(0);
            btnCaiDat.BorderThickness = new Thickness(2,0,0,2);
            //btnThongKe.BorderThickness = new Thickness(0);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/caidat3.png", UriKind.RelativeOrAbsolute); // Thay đổi path_to_your_image.jpg thành đường dẫn của ảnh của bạn
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnBanHang.Background = null;
            btnDaMua.Background = null;
            btnTrangChu.Background = null;
            btnGioHang.Background = null;
            btnCaiDat.Background=new SolidColorBrush(Color.FromRgb(136, 0, 204));
           // btnThongKe.Background = null;

        }
        public static string texttimkiem = "";
        private void timkiem_Click(object sender, RoutedEventArgs e)
        {


            timkiem1.Text = null;
            texttimkiem = txttimkiem.Text;
            UpdateSearchCount(texttimkiem);

            UC_MuaSam uc = new UC_MuaSam();
            user.Content = uc;
        }

        private void btnYeuThich_Click(object sender, RoutedEventArgs e)
        {
            PhanQuyen.menu = "YeuThich";

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
        private void UpdateSearchCount(string tenSP)
        {
            try
            {
                // Kết nối đến cơ sở dữ liệu
                Database database = new Database();
                using (SqlConnection conn = database.getConnection())
                {
                    conn.Open();

                    // Lấy mã sản phẩm dựa trên tên sản phẩm
                    string getMaSPQuery = $"SELECT MaSP FROM SanPham WHERE TenSP = @TenSP";
                    SqlCommand getMaSPCommand = new SqlCommand(getMaSPQuery, conn);
                    getMaSPCommand.Parameters.AddWithValue("@TenSP", tenSP);
                    string maSP = getMaSPCommand.ExecuteScalar()?.ToString();
                    if (!string.IsNullOrEmpty(maSP))
                    {
                        string updateQuery = $"UPDATE SanPham SET SoLanTimKiem = SoLanTimKiem + 1 WHERE MaSP = @MaSP";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, conn);
                        updateCommand.Parameters.AddWithValue("@MaSP", maSP);
                        updateCommand.ExecuteNonQuery();

                        // Lấy danh mục sản phẩm của sản phẩm
                        string getCategoryQuery = $"SELECT TheLoai FROM SanPham WHERE MaSP = @MaSP";
                        SqlCommand getCategoryCommand = new SqlCommand(getCategoryQuery, conn);
                        getCategoryCommand.Parameters.AddWithValue("@MaSP", maSP);
                        string category = getCategoryCommand.ExecuteScalar()?.ToString();

                        if (!string.IsNullOrEmpty(category))
                        {
                            string checkCategoryQuery = $"SELECT COUNT(*) FROM TopDanhMuc WHERE DanhMucSP = @Category";
                            SqlCommand checkCategoryCommand = new SqlCommand(checkCategoryQuery, conn);
                            checkCategoryCommand.Parameters.AddWithValue("@Category", category);
                            int categoryCount = (int)checkCategoryCommand.ExecuteScalar();

                            if (categoryCount == 0)
                            {
                                // Nếu danh mục sản phẩm chưa được đếm trong tài khoản của người dùng, thêm mới vào bảng TopDanhMuc
                                string insertCategoryQuery = $"INSERT INTO TopDanhMuc (DanhMucSP, LuotTimKiem) VALUES (@Category, 1)";
                                SqlCommand insertCategoryCommand = new SqlCommand(insertCategoryQuery, conn);
                                insertCategoryCommand.Parameters.AddWithValue("@Category", category);
                                //insertCategoryCommand.Parameters.AddWithValue("@MaSP", maSP);
                                insertCategoryCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                // Nếu danh mục sản phẩm đã được đếm trong tài khoản của người dùng, cập nhật số lần tìm kiếm
                                string updateCategoryQuery = $"UPDATE TopDanhMuc SET LuotTimKiem = LuotTimKiem + 1 WHERE DanhMucSP = @Category";
                                SqlCommand updateCategoryCommand = new SqlCommand(updateCategoryQuery, conn);
                                updateCategoryCommand.Parameters.AddWithValue("@Category", category);
                                updateCategoryCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating search count: " + ex.Message);
            }
        }
    }
}
