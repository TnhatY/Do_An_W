using Microsoft.Identity.Client;
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
    internal class NguoiDung
    {
        Database database =new Database();
        public string hoten { get; set; }   
        public string ngaysinh { get; set; }
        public string gioitinh { get; set; }
        public string sodt { get; set; }
        public string email { get; set; }
        public string taikhoan { get; set; }
        public string matkhau { get; set; }
        public string diachi { get; set; }

        public NguoiDung(string hoten, string ngaysinh, string gioitinh, string sodt, string email, string taikhoan, string matkhau, string diachi)
        {
            this.hoten = hoten;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.sodt = sodt;
            this.email = email;
            this.taikhoan = taikhoan;
            this.matkhau = matkhau;
            this.diachi = diachi;
        }
        public NguoiDung() { }

        public virtual bool ThemGioHang(string masp, string taikhoan, string query)
        {
            try
            {
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
            catch
            {
                return false;
            }
            return true;
        }
        public virtual void Dat_Hang(string masp)
        {
            try
            {
                string taikhoan = PhanQuyen.taikhoan;
                DateTime now = DateTime.Now;
                string xacNhan = "no";
                SqlConnection sqlConnection = database.getConnection();
                string sql = "insert into SP_DaMua values (@MaSP,@TaiKhoan,@XacNhan)";
                using (SqlConnection connection = new SqlConnection(database.conStr))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@MaSP", masp);
                        command.Parameters.AddWithValue("@TaiKhoan", PhanQuyen.taikhoan);
                        command.Parameters.AddWithValue("@XacNhan", xacNhan);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception Fail)
            {
                MessageBox.Show(Fail.Message);
            }
        }
        public List<string> SoDiaChi()
        {
            try
            {
                List<string> sodiachi = new List<string>();
                Database database = new Database();
                SqlConnection conn = database.getConnection();
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand($"SELECT * FROM NguoiDung where TaiKhoan = '{PhanQuyen.taikhoan}'", conn))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sodiachi.Add(reader["DiaChi"].ToString());
                            sodiachi.Add(reader["DiaChi2"].ToString());
                            sodiachi.Add(reader["DiaChi3"].ToString());
                        }
                    }
                    conn.Close();
                }
                return sodiachi;
            }catch (Exception Fail)
            {
                MessageBox.Show(Fail.Message);
                return null;
            }
            
        }
        public List<UC_SP_DaMua> ListSPDamua(string xacNhan)
        {
            List<UC_SP_DaMua> SanPhamList = new List<UC_SP_DaMua>();

            string taikhoan = PhanQuyen.taikhoan;
            try
            {
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
                            else
                                sp.btnhuydonhang.Visibility = Visibility.Collapsed;
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
                return null;
                // MessageBox.Show(ex.Message);
            }
            return SanPhamList;
        }
        public List<UC_SpGioHang> ListGioHang()
        {
            string sql1 = $"Select * from GioHang inner join SanPham on GioHang.MaSP=SanPham.MaSP where GioHang.TaiKhoan='{PhanQuyen.taikhoan}'";

            List<UC_SpGioHang> listSP = new List<UC_SpGioHang>();

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
                else
                    return null;
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
                return null;
            }
            return listSP;
        }
    }

}
