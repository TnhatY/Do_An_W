using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Data.SqlClient;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Drawing;
using System.Collections.ObjectModel;

namespace Do_an.Class
{
    internal class SanPham_DAO
    {
        public List<SanPham> Getlist(string sql)
        {
            List<SanPham> sanPhams = new List<SanPham>();
            Database database = new Database();
            try
            {
                DataTable dt = database.getAllData(sql);
                foreach (DataRow row in dt.Rows)
                {
                    string maSP = row["MaSP"].ToString();
                    string tenSP = row["TenSP"].ToString();
                    string tenShop = row["TenShop"].ToString();
                    float giaGoc = Convert.ToSingle(row["GiaGoc"]);
                    float giaHTai = Convert.ToSingle(row["GiaHTai"]);
                    string ngayMua = row["NgayMua"].ToString();
                    string tinhTrang = row["TinhTrang"].ToString();
                    string moTa = row["MoTa"].ToString();
                    string hinhAnh = row["HinhAnh"].ToString();
                    string danhMucSP = row["DanhMucSP"].ToString();
                    string theloai = row["TheLoai"].ToString();
                    sanPhams.Add(new SanPham(maSP, tenSP, tenShop, giaGoc, giaHTai, ngayMua, tinhTrang, moTa, hinhAnh, danhMucSP, theloai));
                }
                return sanPhams;
            }
            catch
            {
                return null;
            }

        }
        public void Them_Sua(SanPham sp, string query)
        {
            try
            {
                Database database = new Database();
                SqlConnection sqlConnection = database.getConnection();
                using (SqlConnection connection = new SqlConnection(database.conStr))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaSP", sp.MaSP);
                        command.Parameters.AddWithValue("@TenSP", sp.TenSP);
                        command.Parameters.AddWithValue("@TenShop", sp.TenShop);
                        command.Parameters.AddWithValue("@GiaGoc", sp.GiaGoc);
                        command.Parameters.AddWithValue("@GiaHTai", sp.GiaHTai);
                        command.Parameters.AddWithValue("@NgayMua", sp.NgayMua);
                        command.Parameters.AddWithValue("@TinhTrang", sp.TinhTrang);
                        command.Parameters.AddWithValue("@MoTa", sp.MoTa);
                        command.Parameters.AddWithValue("@HinhAnh", sp.HinhAnh);
                        command.Parameters.AddWithValue("@DanhMucSP", sp.DanhMucSP);
                        command.Parameters.AddWithValue("@SoLanTimKiem", 0);
                        command.Parameters.AddWithValue("@TheLoai", sp.TheLoai);
                        command.Parameters.AddWithValue("@HinhAnh2", sp.HinhAnh2);
                        command.Parameters.AddWithValue("@HinhAnh3", sp.HinhAnh3);
                        command.Parameters.AddWithValue("@HinhAnh4", sp.HinhAnh4);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception Fail)
            {
                MessageBox.Show(Fail.Message);
            }
        }
        public void xoa(string masp, string query)
        {
            try
            {
                Database database = new Database();
                SqlConnection sqlConnection = database.getConnection();
                using (SqlConnection connection = new SqlConnection(database.conStr))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaSP", masp);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception Fail)
            {
                MessageBox.Show(Fail.Message);
            }
        }

        public bool themGioHang(string masp, string taikhoan, string query)
        {
            try
            {
                Database database = new Database();
                SqlConnection sqlConnection = database.getConnection();
                using (SqlConnection connection = new SqlConnection(database.conStr))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaSP", masp);
                        command.Parameters.AddWithValue("@TaiKhoan", taikhoan);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception Fail)
            {
                return false;
            }
            return true;
        }
        public ObservableCollection<UC_SpGioHang> listGioHang()
        {
            string sql1 = $"Select * from GioHang inner join SanPham on GioHang.MaSP=SanPham.MaSP where GioHang.TaiKhoan='{PhanQuyen.taikhoan}'";

            ObservableCollection<UC_SpGioHang> listSP = new ObservableCollection<UC_SpGioHang>();
            Database database = new Database();
            DataTable dt = database.getAllData(sql1);
            try
            {
                if (dt != null & dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        UC_SpGioHang sp = new UC_SpGioHang();
                        sp.masp.Text = row["MaSP"].ToString();
                        sp.lblTenSP.Text = row["TenSP"].ToString();
                        sp.lblTenShop.Text = row["TenShop"].ToString();
                        sp.lblGiaGoc.Text = row["GiaGoc"].ToString();
                        sp.lblGiaHTai.Text = row["GiaHTai"].ToString();
                        sp.tinhtrang.Text = row["TinhTrang"].ToString();
                        sp.mota.Text = row["MoTa"].ToString();
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(row["HinhAnh"].ToString(), UriKind.RelativeOrAbsolute);
                        bitmap.EndInit();
                        sp.hinhanh.Source = bitmap;
                        listSP.Add(sp);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listSP;
        }


        public List<SanPham> listYeuThich(string sql1)
        {
            List<SanPham> listSP = new List<SanPham>();
            Database database = new Database();
            DataTable dt = database.getAllData(sql1);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SanPham sp = new SanPham();
                    sp.MaSP = dr["MaSP"].ToString();
                    sp.TenSP = dr["TenSP"].ToString();
                    sp.TenShop = dr["TenShop"].ToString();
                    sp.GiaGoc = float.Parse(dr["GiaGoc"].ToString());
                    sp.GiaHTai = float.Parse(dr["GiaHTai"].ToString());
                    sp.TinhTrang = dr["TinhTrang"].ToString();
                    sp.MoTa = dr["MoTa"].ToString();
                    sp.DanhMucSP = dr["DanhMucSP"].ToString();
                    sp.HinhAnh = dr["HinhAnh"].ToString();
                    listSP.Add(sp);
                }
            }
            return listSP;
        }
        public ObservableCollection<UC_SP_DaMua> listSPDamua(string xacNhan)
        {
            ObservableCollection<UC_SP_DaMua> SanPhamList = new ObservableCollection<UC_SP_DaMua>();

            string taikhoan = PhanQuyen.taikhoan;
            try
            {
                Database database = new Database();
                string sql = "SELECT * FROM SP_DaMua INNER JOIN SanPham ON SP_DaMua.MaSP = SanPham.MaSP WHERE SP_DaMua.TaiKhoan = @TaiKhoan AND SP_DaMua.XacNhan = @XacNhan";

                using (SqlConnection connection = new SqlConnection(database.conStr))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@TaiKhoan", taikhoan);
                        command.Parameters.AddWithValue("@XacNhan", xacNhan);

                        DataTable dt = new DataTable();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                        foreach (DataRow dr in dt.Rows)
                        {
                            UC_SP_DaMua sp = new UC_SP_DaMua();
                            sp.tensp.Text = dr["TenSP"].ToString();
                            sp.masp.Text = dr["MaSP"].ToString();
                            sp.giagoc.Text = dr["GiaGoc"].ToString();
                            sp.giaban.Text = dr["GiaHTai"].ToString();
                            sp.tinhtrang.Text = dr["TinhTrang"].ToString();
                            sp.tenshop.Text = dr["TenShop"].ToString();

                            if (xacNhan == "no")
                            {
                                sp.giaohang.Text = "Đang chờ xác nhận từ người bán!";
                                sp.btndanhgia.Visibility = Visibility.Collapsed;
                            }
                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.UriSource = new Uri(dr["HinhAnh"].ToString(), UriKind.RelativeOrAbsolute);
                            bitmap.EndInit();
                            sp.hinhanh.Source = bitmap;
                            SanPhamList.Add(sp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return SanPhamList;
        }

        public void edit(string masp, ThemSP_Window sp)
        {
            Database database = new Database();
            SqlConnection conn = database.getConnection();
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand($"SELECT * FROM SanPham where MaSP='{masp}'", conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sp.txtMaSP.Text = reader["MaSP"].ToString();
                        sp.txtTenSP.Text = reader["TenSP"].ToString();
                        //sp.txtTenShop.Text = reader["TenShop"].ToString();
                        sp.txtGiaGoc.Text = reader["GiaGoc"].ToString();
                        sp.txtGiaBan.Text = reader["GiaHTai"].ToString();
                        sp.txtTinhTrang.Text = reader["TinhTrang"].ToString();
                        sp.txtMoTa.Text = reader["MoTa"].ToString();
                        sp.txtTinhTrang.Text = reader["TinhTrang"].ToString();
                        sp.cbDanhMuc.SelectedItem = reader["DanhMucSP"].ToString();
                        sp.cbTheLoai.SelectedItem = reader["TheLoai"].ToString();
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(reader["HinhAnh"].ToString(), UriKind.RelativeOrAbsolute);
                        bitmap.EndInit();
                        sp.imgHinhAnh.Source = bitmap;
                    }
                }
            }
        }
        public void HienThiThongTin(string masp)
        {
            ThongTin_Window tt = new ThongTin_Window();

            Database database = new Database();
            SqlConnection conn = database.getConnection();
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand($"SELECT * FROM SanPham where MaSP='{masp}'", conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tt.MaSP.Text = reader["MaSP"].ToString();
                        tt.TenSP.Text = reader["TenSP"].ToString();
                        tt.TenShop.Text = reader["TenShop"].ToString();
                        tt.GiaGoc.Text = reader["GiaGoc"].ToString();
                        tt.GiaBan.Text = reader["GiaHTai"].ToString();
                        tt.TinhTrang.Text = reader["TinhTrang"].ToString();
                        tt.MoTa.Text = reader["MoTa"].ToString();
                        tt.TinhTrang.Text = reader["TinhTrang"].ToString();
                        //tt.cbDanhMuc.SelectedItem = reader["DanhMucSP"].ToString();
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(reader["HinhAnh"].ToString(), UriKind.RelativeOrAbsolute);
                        bitmap.EndInit();
                        tt.HinhAnh.Source = bitmap;
                    }
                }
            }
            //MessageBox.Show(tt.TenShop.Text);
            tt.ShowDialog();
        }


        public ObservableCollection<UC_TopTimKiem> topDanhMucTimKiem(string sql)
        {
            ObservableCollection<UC_TopTimKiem> categoriesList = new ObservableCollection<UC_TopTimKiem>();
            Database database = new Database();

            DataTable dt = database.getAllData(sql);
            foreach (DataRow row in dt.Rows)
            {
                UC_TopTimKiem uc_topdanhmuc = new UC_TopTimKiem();
                uc_topdanhmuc.soluong.Text = row["LuotTimKiem"].ToString();
                uc_topdanhmuc.danhmuc.Text = row["DanhMucSP"].ToString();
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(row["HinhAnh"].ToString(), UriKind.RelativeOrAbsolute);
                bitmap.EndInit();
                uc_topdanhmuc.hinhanh.Source = bitmap;
                categoriesList.Add(uc_topdanhmuc);
            }
            return categoriesList;
        }

        public ObservableCollection<UC_SpBan> listSPDangBan(string sql, bool check)
        {
            try
            {
                ObservableCollection<UC_SpBan> SanPhamList = new ObservableCollection<UC_SpBan>();
                List<string> listsp = new List<string>();
                Database database = new Database();
                DataTable dataTable = database.getAllData(sql);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        UC_SpBan sp = new UC_SpBan();
                        sp.masp.Text = row["MaSP"].ToString();
                        sp.tensp.Text = row["TenSP"].ToString();
                        sp.mota.Text = row["MoTa"].ToString();
                        // sp.giagoc.Text = reader["GiaGoc"].ToString();
                        sp.giaban.Text = row["GiaHTai"].ToString();
                        sp.tinhtrang.Text = row["TinhTrang"].ToString();
                        if (check)
                        {
                            sp.edit.Visibility = sp.delete.Visibility = Visibility.Collapsed;
                        }
                        else
                        {
                            sp.xacnhan.Visibility = Visibility.Collapsed;
                            sp.txtxacnhan.Visibility = Visibility.Collapsed;
                        }
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(row["HinhAnh"].ToString(), UriKind.RelativeOrAbsolute);
                        bitmap.EndInit();
                        sp.hinhanh.Source = bitmap;
                        SanPhamList.Add(sp);
                    }
                }
                return SanPhamList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
        public List<string> LoadHinhAnh(string maSP)
        {
            List<string> listHinhAnh = new List<string>();
            Database database = new Database();
            SqlConnection conn = database.getConnection();
            {
                conn.Open();
                string taikhoan = PhanQuyen.taikhoan;
                using (SqlCommand command = new SqlCommand($"SELECT * FROM SanPham where MaSP = '{maSP}'", conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listHinhAnh.Add(reader["HinhAnh"].ToString());
                        listHinhAnh.Add(reader["HinhAnh2"].ToString());
                        listHinhAnh.Add(reader["HinhAnh3"].ToString());
                        listHinhAnh.Add(reader["HinhAnh4"].ToString());
                    }
                }
                conn.Close();
            }
            return listHinhAnh;
        }
    }
}
