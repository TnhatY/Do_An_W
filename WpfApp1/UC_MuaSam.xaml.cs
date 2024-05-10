using Do_an;
using Do_an.Class;
using MaterialDesignThemes.Wpf;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Xml.Linq;
using static MaterialDesignThemes.Wpf.Theme;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_MuaSam.xaml
    /// </summary>
    public partial class UC_MuaSam : UserControl
    {
        
        Database data = new Database();
        SanPham_DAO sanPham_DAO = new SanPham_DAO();
        

        public UC_MuaSam()
        {
            InitializeComponent();
            DataContext = this;
            
                
        }

       
        private void DanhMuc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (sender == SpDienThoai)
                {
                    SpDienThoai.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
                    SpDoDienTu.Background = SpDoDung.Background = SpXeMay.Background = Spthethao.Background = Spthoitrang.Background = null ;

                    string query = "select * from SanPham where DanhMucSP like N'%" + dienthoai.Text + "%'";
                    thongtin.ItemsSource = sanPham_DAO.List_SP(query);
                }
                else if (sender == SpDoDienTu)
                {
                    SpDoDienTu.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
                    SpDienThoai.Background  = SpDoDung.Background = SpXeMay.Background = Spthethao.Background = Spthoitrang.Background = null;

                    string query = "select * from SanPham where DanhMucSP like N'%" + dodien.Text + "%'";
                    thongtin.ItemsSource = sanPham_DAO.List_SP(query);
                }
                else if (sender == SpDoDung)
                {
                    SpDoDung.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
                    SpDienThoai.Background = SpDoDienTu.Background = SpXeMay.Background = Spthethao.Background = Spthoitrang.Background = null;

                    string query = "select * from SanPham where DanhMucSP like N'%" + giadung.Text + "%'";
                    thongtin.ItemsSource = sanPham_DAO.List_SP(query);
                }
                else if (sender == Spthethao)
                {
                    Spthethao.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
                    SpDienThoai.Background = SpDoDienTu.Background = SpDoDung.Background = SpXeMay.Background = Spthoitrang.Background = null;

                    string query = "select * from SanPham where DanhMucSP like N'%" + thethao.Text + "%'";
                    thongtin.ItemsSource = sanPham_DAO.List_SP(query);
                }
                else if (sender == Spthoitrang)
                {
                    Spthoitrang.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
                    SpDienThoai.Background = SpDoDienTu.Background = SpDoDung.Background = SpXeMay.Background = Spthethao.Background = null;

                    string query = "select * from SanPham where DanhMucSP like N'%" + thoitrang.Text + "%'";
                    thongtin.ItemsSource = sanPham_DAO.List_SP(query);
                }
                else if (sender == SpXeMay)
                {
                    SpXeMay.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204)); 
                    SpDienThoai.Background = SpDoDienTu.Background = SpDoDung.Background  = Spthethao.Background = Spthoitrang.Background = null;
                    string query = "select * from SanPham where DanhMucSP like N'%" + xe.Text + "%'";
                    thongtin.ItemsSource = sanPham_DAO.List_SP(query);
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string sql1 = $"select MaSP from SP_YeuThich where TaiKhoan='{PhanQuyen.taikhoan}'";
            string sql2 = "Select * from TopDanhMuc where LuotTimKiem > 0 ORDER BY LuotTimKiem DESC";
            spTopTimKiem.ItemsSource = sanPham_DAO.TopDanhMucTimKiem(sql2);
            try
            {
                if (string.IsNullOrWhiteSpace(F_Main.texttimkiem))
                {
                    string sql = "Select * from SanPham";
                    thongtin.ItemsSource = sanPham_DAO.List_SP(sql);
                }
                else
                {
                    string timkiem = F_Main.texttimkiem;
                    string sql = "select * from SanPham where TenSP like N'%" + timkiem + "%'";
                    thongtin.ItemsSource = sanPham_DAO.List_SP(sql);
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Không có sản phẩm này!","Thông báo");
            }
           
        }
    }
}
