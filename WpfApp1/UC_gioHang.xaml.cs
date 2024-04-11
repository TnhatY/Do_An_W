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
       // SELECT* FROM SanPham where MaSP='{msp}'"


        private void UC_gioHang_Loaded(object sender, RoutedEventArgs e)
        {
            SanPham_DAO sanPham_DAO =new SanPham_DAO();
            SP_GioHang.ItemsSource= sanPham_DAO.listYeuThich(sql);
        }
        public void ReloadData()
        {
            SanPhamList.Clear();
            SanPham_DAO sp = new SanPham_DAO();
            SP_GioHang.ItemsSource= sp.listYeuThich(sql);
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            // Database database = new Database();
            if (UC_SpGioHang.check)
            {
                foreach (var sp in UC_SpGioHang.listmasp)
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
    }
}
