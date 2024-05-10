using System;
using System.Collections.Generic;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using Do_an.Class;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for ThanhToan_Window.xaml
    /// </summary>
    public partial class ThanhToan_Window : Window
    {
        public ThanhToan_Window()
        {
            InitializeComponent();
        }
        Database database = new Database();
        NguoiDung nguoiDung =new NguoiDung();
      
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            phivanchuyen.Text = "120";
            float giaBan = 0;
            float phiVanChuyen = float.Parse(phivanchuyen.Text);
            spmua.ItemsSource = null;
            try
            {
                List<UC_SP_ThanhToan> list = new List<UC_SP_ThanhToan>();
                DataTable dtt = new DataTable();
                if (PhanQuyen.menu=="GioHang")
                {
                    foreach (var sp in Const.listgiohang)
                    {
                        string sql1 = $"select * from SanPham Where MaSP='{sp}'";
                        dtt = database.getAllData(sql1);
                        foreach (DataRow dr in dtt.Rows)
                        {
                            UC_SP_ThanhToan uC_SP_ThanhToan = new UC_SP_ThanhToan();
                            uC_SP_ThanhToan.tensp.Text = dr["TenSP"].ToString();
                            uC_SP_ThanhToan.giaban.Text = dr["GiaHTai"].ToString();
                            giaBan += float.Parse(dr["GiaHTai"].ToString());
                            uC_SP_ThanhToan.tinhtrang.Text = dr["TinhTrang"].ToString();
                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.UriSource = new Uri(dr["HinhAnh"].ToString(), UriKind.RelativeOrAbsolute);
                            bitmap.EndInit();
                            uC_SP_ThanhToan.hinhanhsp.Source = bitmap;
                            list.Add(uC_SP_ThanhToan);
                        }
                    }
                   
                    spmua.ItemsSource= list;
                }
                else
                {
                    string sql1 = $"select * from SanPham Where MaSP='{masp.Text}'";
                    dtt = database.getAllData(sql1);
                    foreach (DataRow dr in dtt.Rows)
                    {
                        UC_SP_ThanhToan uC_SP_ThanhToan = new UC_SP_ThanhToan();
                        uC_SP_ThanhToan.tensp.Text = dr["TenSP"].ToString();
                        uC_SP_ThanhToan.giaban.Text = dr["GiaHTai"].ToString();
                        giaBan += float.Parse(dr["GiaHTai"].ToString());
                        uC_SP_ThanhToan.tinhtrang.Text= dr["TinhTrang"].ToString();
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(dr["HinhAnh"].ToString(), UriKind.RelativeOrAbsolute);
                        bitmap.EndInit();
                        uC_SP_ThanhToan.hinhanhsp.Source = bitmap;
                        list.Add(uC_SP_ThanhToan);
                    }
                    spmua.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            giaban1.Text = giaBan.ToString();
            float tongThanToan = giaBan + phiVanChuyen;
            tongthanhtoan.Text = tongthanhtoan1.Text = tongThanToan.ToString();
            string sql = $"select DiaChi From NguoiDung where TaiKhoan='{PhanQuyen.taikhoan}'";
            DataTable dt = database.getAllData(sql);
            diachi.Text = dt.Rows[0]["DiaChi"].ToString();
        }
        private void btnMua_Click(object sender, RoutedEventArgs e)
        {
            if (PhanQuyen.menu == "GioHang")
            {
                foreach(var masp in Const.listgiohang)
                {
                    nguoiDung.Dat_Hang(masp);
                }
                Const.kiemTraThanhToan = true;
            }
            else
            {
                nguoiDung.Dat_Hang(masp.Text);
            }
            Close();
        }

        private void thoat_Click(object sender, RoutedEventArgs e)
        {
            Const.kiemTraThanhToan = false;
            Close();
        }
    }
}
