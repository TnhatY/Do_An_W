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
                        bitmap.EndInit();
                        sp.imgHinhAnh.Source = bitmap;
                    }
                }
            }
        }
        public void HienThiThongTin(string masp,string diachi)
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


        public List<UC_TopTimKiem> TopDanhMucTimKiem(string sql)
        {
            List<UC_TopTimKiem> categoriesList = new List<UC_TopTimKiem>();

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
       
        public void CapNhatSoLanTimKiem(string tenSP)
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
                MessageBox.Show(ex.Message);
            }
        }
    }
}
