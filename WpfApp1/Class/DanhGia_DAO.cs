using Do_an.Class;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media ;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;

namespace Do_an
{
    class DanhGia_DAO
    {
        public void ThemDG(DanhGiaSP dg,string avatar)
        {
            try
            {
                Database database = new Database();
                SqlConnection sqlConnection = database.getConnection();
                string query = "insert into DanhGia_SP values (@TenShop,@TenNgDG,@NgayDG,@SoSao,@DanhGia,@Avatar)";
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
                        command.Parameters.AddWithValue("@Avatar", avatar);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception Fail)
            {
                MessageBox.Show(Fail.Message);
            }
        }
        public string SoDanhGia(string sql,string tenshop)
        {
            string sodangia = "";
            Database database = new Database();
            try
            {
                using (SqlConnection connection = new SqlConnection(database.conStr))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@TenShop", tenshop);

                        int count = (int)command.ExecuteScalar();
                        sodangia = count.ToString();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                sodangia = "0";
            }
            return sodangia;

        }
        public void HienThiSoSao(int numberOfStars, StackPanel starPanel)
        {
            try
            {
                starPanel.Children.Clear();
                for (int i = 0; i < numberOfStars; i++)
                {
                    TextBlock saoTextBlock = new TextBlock();
                    saoTextBlock.Foreground = System.Windows.Media.Brushes.Red;
                    saoTextBlock.FontSize = 16;
                    saoTextBlock.Text = "☆";
                    starPanel.Children.Add(saoTextBlock);
                }

                for (int i = numberOfStars; i < 5; i++)
                {
                    TextBlock saoTextBlock = new TextBlock();
                    saoTextBlock.FontSize = 16;
                    saoTextBlock.Text = "☆";
                    starPanel.Children.Add(saoTextBlock);
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        public List<DanhGiaSP> XemDanhGia(string tenshop)
        {
            try
            {
                List<DanhGiaSP> listdg = new List<DanhGiaSP>();
                string sql = $"select * from DanhGia_SP where TenShop = N'{tenshop}'";
                Database database = new Database();
                DataTable dt = database.getAllData(sql);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string ten = row["TenNgDG"].ToString();
                        int soSao = int.Parse(row["SoSao"].ToString());
                        DateTime ngay = (DateTime)row["NgayDG"];
                        string ngaydg = ngay.ToShortDateString();
                        string danhgias = row["DanhGia"].ToString();
                        string avt = row["Avatar"].ToString();
                        listdg.Add(new DanhGiaSP(ten, ngaydg, danhgias, soSao, avt));
                    }
                    return listdg;
                }
                else
                {
                    return null;
                }
            }
            catch 
            {
                return null;
            }
          
        }
    }
}
