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
        SanPham_DAO sanPham_DAO = new SanPham_DAO();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            phivanchuyen.Text = "120";
            float giaBan = 0;
            float phiVanChuyen = float.Parse(phivanchuyen.Text);
            spmua.ItemsSource = null;
           
            sodiachi.ItemsSource = nguoiDung.SoDiaChi();
            sodiachi.SelectedIndex = 0;

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
                            uC_SP_ThanhToan.ButtonClicked += themVoucher_Click;
                            tenshop.Text= dr["TenShop"].ToString();
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
                        uC_SP_ThanhToan.ButtonClicked += themVoucher_Click;
                        tenshop.Text = dr["TenShop"].ToString();
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
            
        }
       
        private void themVoucher_Click(object sender, RoutedEventArgs e)
        {
            TongPhieuGiam tongPhieuGiam = new TongPhieuGiam();
            tongPhieuGiam.tenshop.Text = tenshop.Text;
            tongPhieuGiam.ShowDialog();
            if (TongPhieuGiam.checkgiamgia)
            {
                float phantramgiam = float.Parse(giaban1.Text) * PhieuGiamGia.phantramgiamgia / 100;
                float gb1 = float.Parse(giaban1.Text)- phantramgiam;
                float gb2 = float.Parse(tongthanhtoan.Text) - phantramgiam;
                tongthanhtoan.Text = tongthanhtoan1.Text = gb2.ToString();   
                giaban1.Text = gb1.ToString();
            }
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
            MessageBox.Show("Đơn hàng đã được đặt! Vui lòng kiểm tra trạng thái giao hàng!", "Thông báo");

            Close();
        }
        
        private void thoat_Click(object sender, RoutedEventArgs e)
        {
            Const.kiemTraThanhToan = false;
            Close();
        }
    }
}
