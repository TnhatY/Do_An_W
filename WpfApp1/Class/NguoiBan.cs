using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Data;
using System.Windows.Media.Imaging;

namespace Do_an.Class
{
    class NguoiBan:NguoiDung
    {
        Database database=new Database();

        public NguoiBan() { }
        public void Them_Sua_SP(SanPham sp, string query)
        {
            try
            {
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
        public void Xoa_SP(string masp, string query)
        {
            try
            {
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
        public void Xoa(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(database.conStr))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (Exception Fail)
            {
                MessageBox.Show(Fail.Message);
            }
        }
        public override bool ThemGioHang(string masp, string taikhoan, string query)
        {
            return base.ThemGioHang(masp, taikhoan, query);
        }

        public List<UC_SpBan> ListSPDangBan(string sql, bool check)
        {
            try
            {
                List<UC_SpBan> SanPhamList = new List<UC_SpBan>();
                List<string> listsp = new List<string>();
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
        public void ThemSP_Ban(string masp)
        {
            string query2 = "insert into SP_Ban values (@MaSP,@TaiKhoan)";
            try
            {
                using (SqlConnection connection = new SqlConnection(database.conStr))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query2, connection))
                    {
                        command.Parameters.AddWithValue("@MaSP", masp);
                        command.Parameters.AddWithValue("@TaiKhoan", PhanQuyen.taikhoan);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Thêm sản phẩm thành công");
            }
            catch (Exception Fail)
            {
                MessageBox.Show(Fail.Message);
            }
        }

        public override void Dat_Hang(string masp)
        {
            base.Dat_Hang(masp);
        }
       
    }
}
