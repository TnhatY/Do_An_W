using Do_an;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Collections;
using Do_an.Class;
using System.Data;
using System.Windows.Markup;
using System.Data.Entity;

namespace Do_an
{
    public partial class UC_gioHang : UserControl
    {
        public ObservableCollection<UC_SpGioHang> SanPhamList { get; set; }

        public UC_gioHang()
        {
            InitializeComponent();
            SanPhamList = new ObservableCollection<UC_SpGioHang>();

            this.DataContext = this;
            this.Loaded += UC_gioHang_Loaded;
        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listview_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        string sql = $"select * from SP_YeuThich inner join SanPham on SanPham.MaSP=SP_YeuThich.MaSP where SP_YeuThich.TaiKhoan='{PhanQuyen.taikhoan}'";
        Database database = new Database();


        private void UC_gioHang_Loaded(object sender, RoutedEventArgs e)
        {

            if (PhanQuyen.menu == "nguoimua")
            {
                themvoucher.Visibility = Visibility.Collapsed;
                string sql1 = "Select NguoiDung.HoTen,NguoiDung.DiaChi,NguoiDung.SoDT, NguoiDung.Avatar, count(MaSP)+10 as soluotmua From NguoiDung inner join SP_DaMua on NguoiDung.TaiKhoan=SP_DaMua.TaiKhoan group by NguoiDung.TaiKhoan,NguoiDung.HoTen,NguoiDung.DiaChi,NguoiDung.SoDT,NguoiDung.Avatar";

                tittle.Text = "Top người mua nhiều";
                try
                {
                    DataTable dt = database.getAllData(sql1);
                    List<UC_NguoiBan> listuytin = new List<UC_NguoiBan>();
                    List<UC_NguoiBan> listkouytin = new List<UC_NguoiBan>();
                    if (dt == null)
                        MessageBox.Show("rỗng");
                    else
                        foreach (DataRow row in dt.Rows)
                        {
                            UC_NguoiBan uc_topdanhmuc = new UC_NguoiBan();
                            uc_topdanhmuc.ten.Text = row["HoTen"].ToString();
                            uc_topdanhmuc.diachi.Text = row["DiaChi"].ToString();
                            uc_topdanhmuc.sdt.Text = row["SoDT"].ToString();
                            uc_topdanhmuc.stackSoSao.Visibility = Visibility.Collapsed;
                            uc_topdanhmuc.luotmua.Text = row["soluotmua"].ToString() + " lượt mua";
                            uc_topdanhmuc.luotmua.Margin = new Thickness(100, 50, 0, 0);
                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.UriSource = new Uri(row["Avatar"].ToString(), UriKind.RelativeOrAbsolute);
                            bitmap.EndInit();
                            uc_topdanhmuc.hinhanh.Source = bitmap;
                            listuytin.Add(uc_topdanhmuc);
                            uc_topdanhmuc.xemdanhgia.Visibility = Visibility.Collapsed;
                        }
                    SP_GioHang.ItemsSource = listuytin;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (PhanQuyen.menu == "YeuThich")
            {
                themvoucher.Visibility = Visibility.Collapsed;
                ThongTin_Window.kthongtin = false;
                SanPham_DAO sanPham_DAO = new SanPham_DAO();
                SP_GioHang.ItemsSource = sanPham_DAO.ListYeuThich(sql);
            }
            else if (PhanQuyen.loaiTk == "nguoiban")
            {
                try
                {
                    tittle.Text = "Danh sách mã giảm giá!";
                    themvoucher.Visibility = Visibility.Visible;
                    string sql = $"select * from Voucher where TenShop=N'{PhanQuyen.ten}'";
                    List<PhieuGiamGia> list = new List<PhieuGiamGia>();
                    DataTable dt = database.getAllData(sql);
                    foreach (DataRow dr in dt.Rows)
                    {
                        PhieuGiamGia phieuGiamGia = new PhieuGiamGia();
                        phieuGiamGia.TenKM.Text = dr["TenKM"].ToString();
                        phieuGiamGia.giamgia.Text = dr["PhanTramGiam"].ToString();
                        list.Add(phieuGiamGia);
                    }
                    SP_GioHang.ItemsSource = list;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void ReloadData()
        {
            SanPhamList.Clear();
            SanPham_DAO sp = new SanPham_DAO();
            SP_GioHang.ItemsSource= sp.ListYeuThich(sql);
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            if (Const.kiemTraMuaHang)
            {
                foreach (var sp in Const.listgiohang)
                {
                    string sql = "delete from GioHang Where MaSP=@MaSP";
                    try
                    {
                        Database database = new Database();
                        SqlConnection sqlConnection = database.getConnection();
                        using (SqlConnection connection = new SqlConnection(database.conStr))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(sql, connection))
                            {
                                command.Parameters.AddWithValue("@MaSP", sp);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception Fail)
                    {
                        MessageBox.Show(Fail.Message);
                    }
                }
                ReloadData();
            }
            else
            {
                MessageBox.Show("Không có sản phẩm nào được chọn!");
            }
           
        }

        private void themvoucher_Click(object sender, RoutedEventArgs e)
        {
            tittle.Text = "Danh sách mã giảm giá";
            ThemVoucher themVoucher = new ThemVoucher();
            themVoucher.ShowDialog();
        }
    }
}
