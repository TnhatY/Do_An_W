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
using System.Windows.Forms;
namespace Do_an.Class
{
    internal class SanPham_DAO
    {
        Database database = new Database();
        public List<SanPham> List_SP(string sql)
        {
            List<SanPham> sanPhams = new List<SanPham>();
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

        public List<SanPham> ListYeuThich(string sql1)
        {
            List<SanPham> listSP = new List<SanPham>();
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

        public void LayThongTin_SP_LenFormChinhSua(string masp, ThemSP_Window sp)
        {
            try
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
                            sp.dtpNgayMua.Text = reader["NgayMua"].ToString();
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
                            sp.imgHinhAnh.Source = bitmap;
                            bitmap.EndInit();
                            BitmapImage bitmap2 = new BitmapImage();
                            bitmap2.BeginInit();
                            bitmap2.UriSource = new Uri(reader["HinhAnh2"].ToString(), UriKind.RelativeOrAbsolute);
                            sp.imgHinhAnh2.Source = bitmap2;
                            bitmap2.EndInit();
                        }
                    }
                }
          
            }catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
        public void HienThiThongTin(string masp,string diachi)
        {
            try {
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
                            tt.Theloai.Text = reader["TheLoai"].ToString();
                            tt.MaSP.Text = reader["MaSP"].ToString();
                            tt.TenSP.Text = reader["TenSP"].ToString();
                            tt.TenShop.Text = reader["TenShop"].ToString();
                            tt.GiaGoc.Text = reader["GiaGoc"].ToString();
                            tt.GiaBan.Text = reader["GiaHTai"].ToString();
                            tt.TinhTrang.Text = reader["TinhTrang"].ToString();
                            tt.MoTa.Text = reader["MoTa"].ToString();
                            tt.TinhTrang.Text = reader["TinhTrang"].ToString();
                            DateTime ngaymua = (DateTime)reader["NgayMua"];
                            tt.Ngaymua.Text = ngaymua.ToShortDateString();
                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.UriSource = new Uri(reader["HinhAnh"].ToString(), UriKind.RelativeOrAbsolute);
                            bitmap.EndInit();
                            tt.HinhAnh.Source = bitmap;
                            tt.diachi.Text = diachi;
                        }
                    }
                }
                tt.ShowDialog();
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
           
        }


        public List<UC_TopTimKiem> TopDanhMucTimKiem(string sql)
        {
            List<UC_TopTimKiem> categoriesList = new List<UC_TopTimKiem>();
            try
            {
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
            catch
            {
                return null;
            }
          
        }
      
        public List<string> LoadHinhAnh(string maSP)
        {
            try
            {
                List<string> listHinhAnh = new List<string>();
                Database database = new Database();
                SqlConnection conn = database.getConnection();
                {
                    conn.Open();
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
            }catch(Exception ex)
            {
                return null;
            }
          
        }


        public void CapNhatSoLanTimKiem(string tenSP)
        {
            try
            {
                Database database = new Database();
                using (SqlConnection conn = database.getConnection())
                {
                    conn.Open();
                    string maSP = LayMaSanPham(tenSP, conn);
                    if (!string.IsNullOrEmpty(maSP))
                    {
                        CapNhatSoLanTimKiemSanPham(maSP, conn);
                        string category = LayDanhMucSanPham(maSP, conn);
                        if (!string.IsNullOrEmpty(category))
                        {
                            CapNhatSoLanTimKiemDanhMuc(category, conn);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private string LayMaSanPham(string tenSP, SqlConnection conn)
        {
            string query = "SELECT MaSP FROM SanPham WHERE TenSP = @TenSP";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TenSP", tenSP);
                return cmd.ExecuteScalar()?.ToString();
            }
        }

        private void CapNhatSoLanTimKiemSanPham(string maSP, SqlConnection conn)
        {
            string query = "UPDATE SanPham SET SoLanTimKiem = SoLanTimKiem + 1 WHERE MaSP = @MaSP";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaSP", maSP);
                cmd.ExecuteNonQuery();
            }
        }

        private string LayDanhMucSanPham(string maSP, SqlConnection conn)
        {
            string query = "SELECT TheLoai FROM SanPham WHERE MaSP = @MaSP";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaSP", maSP);
                return cmd.ExecuteScalar()?.ToString();
            }
        }

        private void CapNhatSoLanTimKiemDanhMuc(string category, SqlConnection conn)
        {
            string checkQuery = "SELECT COUNT(*) FROM TopDanhMuc WHERE DanhMucSP = @Category";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@Category", category);
                int categoryCount = (int)checkCmd.ExecuteScalar();

                string query;
                if (categoryCount == 0)
                {
                    query = "INSERT INTO TopDanhMuc (DanhMucSP, LuotTimKiem) VALUES (@Category, 1)";
                }
                else
                {
                    query = "UPDATE TopDanhMuc SET LuotTimKiem = LuotTimKiem + 1 WHERE DanhMucSP = @Category";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void themvoucher(string mkm,string tenkm,string phantram)
        {
            try
            {
                SqlConnection sqlConnection = database.getConnection();
                string sql = "insert into Voucher values (@MaKM,@TenKM,@PhanTramGiam,@TenShop)";
                using (SqlConnection connection = new SqlConnection(database.conStr))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@MaKM", mkm);
                        command.Parameters.AddWithValue("@TenKM", tenkm);
                        command.Parameters.AddWithValue("@PhanTramGiam", phantram);
                        command.Parameters.AddWithValue("@TenShop", PhanQuyen.ten);
                        command.ExecuteNonQuery();
                    }
                }
                System.Windows.MessageBox.Show("Thêm Voucher thành công!");
            }
            catch (Exception Fail)
            {
                System.Windows.Forms.MessageBox.Show(Fail.Message);
            }
        }
    }
}
