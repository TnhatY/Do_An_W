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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using Do_an.Class;
using System.Windows.Media.Animation;
using System.Data;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_DaMua.xaml
    /// </summary>
    public partial class UC_DaMua : UserControl
    {
        
        NguoiDung nguoiDung=new NguoiDung();
        NguoiBan nguoiBan =new NguoiBan();
        public UC_DaMua()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public event RoutedEventHandler ButtonClicked;

        public void CapNhatGioHang()
        {
            listsp.ItemsSource = null;
            listsp.ItemsSource = nguoiDung.ListGioHang();
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Const.kiemTraMuaHang)
                {
                    foreach (var sp in Const.listgiohang)
                    {
                        string sql = $"delete from GioHang Where MaSP='{sp}'";
                        try
                        {
                            nguoiBan.Xoa(sql);
                        }
                        catch (Exception Fail)
                        {
                            MessageBox.Show(Fail.Message);
                        }

                    }
                    Const.listgiohang.Clear();
                    Const.kiemTraMuaHang = false;
                    CapNhatGioHang();
                }
                else
                {
                    MessageBox.Show("Không có sản phẩm nào được chọn!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
            if (PhanQuyen.menu == "BanHang")
            {
                tittle.Text = null;
                spdangban.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            }
            else if (PhanQuyen.menu == "Damua")
            {
                tittle.Text = null;
                spdamua.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            }
            else if (PhanQuyen.menu == "GioHang")
            {
                spdangban.Visibility = spchoxacnhan.Visibility = Visibility.Collapsed;
                spdamua.Visibility = Visibility.Collapsed;
                spchuaxacnhan.Visibility = Visibility.Collapsed;
                listsp.ItemsSource = nguoiDung.ListGioHang();
                if (Const.kiemTraThanhToan)
                {
                    xoa.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    Const.kiemTraThanhToan = false;
                }

            }
        }

        private void spdamua_Click(object sender, RoutedEventArgs e)
        {
            string xacNhan = "yes";
            spdamua.BorderThickness = new Thickness(0, 0, 0, 3);
            spchuaxacnhan.BorderThickness = new Thickness(0, 0, 0, 0);
            xoa.Visibility = Visibility.Hidden;
            mua.Visibility = Visibility.Hidden;
            listsp.ItemsSource = nguoiDung.ListSPDamua(xacNhan);
            spchoxacnhan.Visibility = Visibility.Collapsed;
            spdangban.Visibility = Visibility.Collapsed;
        }

        private void spchuaxacnhan_Click(object sender, RoutedEventArgs e)
        {
            spdangban.Visibility = Visibility.Collapsed;
            spchoxacnhan.Visibility = Visibility.Collapsed;
            string xacNhan = "no";
            spdamua.BorderThickness = new Thickness(0, 0, 0, 0);
            spchuaxacnhan.BorderThickness = new Thickness(0, 0, 0, 3);
            tittle.Text = null;
            mua.Visibility = Visibility.Hidden;
            xoa.Visibility = Visibility.Hidden;
            listsp.ItemsSource = nguoiDung.ListSPDamua(xacNhan);
        }

        private void spdangban_Click(object sender, RoutedEventArgs e)
        {
            spchoxacnhan.BorderThickness = new Thickness(0, 0, 0, 0);
            spdangban.BorderThickness = new Thickness(0, 0, 0, 3);
            spdamua.Visibility = Visibility.Collapsed;
            spchuaxacnhan.Visibility = Visibility.Collapsed;
            mua.Visibility = Visibility.Hidden;
            xoa.Visibility = Visibility.Collapsed;

            string sql = $"SELECT * FROM SP_Ban inner join SanPham on SP_Ban.MaSP=SanPham.MaSP where SP_Ban.TaiKhoan='{PhanQuyen.taikhoan}'";
            listsp.ItemsSource = nguoiBan.ListSPDangBan(sql, false);

        }
        string sql1 = $"SELECT * FROM SP_Ban INNER JOIN SP_DaMua ON SP_Ban.MaSP = SP_DaMua.MaSP inner join SanPham on SanPham.MaSP=SP_Ban.MaSP WHERE SP_Ban.TaiKhoan = '{PhanQuyen.taikhoan}' and SP_DaMua.XacNhan='no'";

        private void spchoxacnhan_Click(object sender, RoutedEventArgs e)
        {
            spdamua.Visibility = Visibility.Collapsed;
            spchuaxacnhan.Visibility = Visibility.Collapsed;
            spdangban.BorderThickness = new Thickness(0, 0, 0, 0);
            spchoxacnhan.BorderThickness = new Thickness(0, 0, 0, 3);
            mua.Visibility = Visibility.Hidden;
            listsp.ItemsSource = nguoiBan.ListSPDangBan(sql1, true);
        }

        private void mua_Click(object sender, RoutedEventArgs e)
        {
            ThanhToan_Window thanhToan_Window = new ThanhToan_Window();
            if(Const.kiemTraMuaHang!=true||Const.listgiohang==null)
            {
                MessageBox.Show("Chưa có sản phẩm nào được chọn!","Thông báo");
            }
            else
            {
                thanhToan_Window.ShowDialog();
            }

        }
    }
}
