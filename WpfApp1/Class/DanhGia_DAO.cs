using Do_an.Class;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Do_an
{
    class DanhGia_DAO
    {
        public void themDG(DanhGiaSP dg)
        {
            try
            {
                Database database = new Database();
                SqlConnection sqlConnection = database.getConnection();
                string query = "insert into DanhGia_SP values (@TenShop,@TenNgDG,@NgayDG,@SoSao,@DanhGia)";
                using (SqlConnection connection = new SqlConnection(database.conStr))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TenShop", dg.tenshop);
                        command.Parameters.AddWithValue("@TenNgDG", dg.ten);
                        command.Parameters.AddWithValue("@SoSao",dg.sosao);
                        command.Parameters.AddWithValue("@DanhGia", dg.danhgiasp);
                        command.Parameters.AddWithValue("@NgayDG", dg.ngay);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception Fail)
            {
                MessageBox.Show(Fail.Message);
            }
        }
    }
}
