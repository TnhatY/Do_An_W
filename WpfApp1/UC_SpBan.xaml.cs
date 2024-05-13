using Do_an.Class;
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
using System.Windows.Media.Animation;
using System.Data.SqlClient;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_SpBan.xaml
    /// </summary>
    public partial class UC_SpBan : UserControl
    {
        public UC_SpBan()
        {
            InitializeComponent();
        }
        public static bool checkxoa=false;
        NguoiBan nguoiBan=new NguoiBan();
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            ThemSP_Window themSP_Window = new ThemSP_Window();
            themSP_Window.btnThem.Visibility = Visibility.Hidden;
            string ma = masp.Text;
            SanPham_DAO sanPham_DAO = new SanPham_DAO();
            sanPham_DAO.LayThongTin_SP_LenFormChinhSua(ma, themSP_Window);
            themSP_Window.ShowDialog();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            checkxoa = true;
            try
            {
                string query = $"delete from SanPham where MaSP='{masp.Text}'";
                string query2 = $"delete from SP_Ban where MaSP='{masp.Text}'";
                MessageBoxResult tb = MessageBox.Show("Bạn có muốn xoá sản phẩm này không", "Cảnh báo", MessageBoxButton.YesNo);
                if(tb == MessageBoxResult.Yes)
                {
                    nguoiBan.Xoa(query);
                    nguoiBan.Xoa(query2);
                    MessageBox.Show("Sản phẩm đã được xoá");
                }
            }
            catch
            {
                   
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void xacnhan_Click(object sender, RoutedEventArgs e)
        {
            txtxacnhan.Text = "Đã xác nhận!";
            xacnhan.Visibility = Visibility.Collapsed;
            try
            {
                string taikhoan = PhanQuyen.taikhoan;
                DateTime now = DateTime.Now;
                Database database = new Database();
                string xacNhan = "yes";
                SqlConnection sqlConnection = database.getConnection();
                string sql = "update SP_DaMua set XacNhan=@XacNhan where MaSP=@MaSP";
                using (SqlConnection connection = new SqlConnection(database.conStr))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@MaSP", masp.Text);
                       // command.Parameters.AddWithValue("@TaiKhoan", PhanQuyen.taikhoan);
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
    }
}
