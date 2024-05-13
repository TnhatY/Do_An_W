using Do_an;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_SanPham.xaml
    /// </summary>
    public partial class UC_SanPham : UserControl
    {
        public UC_SanPham()
        {
            InitializeComponent();
        }
        //public event EventHandler<DataEventArgs> DataRequested;

        NguoiDung nguoiDung=new NguoiDung();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SanPham_DAO sanPham_DAO = new SanPham_DAO();
            sanPham_DAO.HienThiThongTin(masp.Text,diachi.Text);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (PhanQuyen.menu == "YeuThich")
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("/image/datim.png", UriKind.RelativeOrAbsolute);
                bitmap.EndInit();
                imagetim.Source = bitmap;
            }
            if (ThongTin_Window.kthongtin) {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("/image/chuatim.png", UriKind.RelativeOrAbsolute);
                bitmap.EndInit();
                imagetim.Source = bitmap;
            }
            try
            {
                string query = $"select top 1 DiaChi From NguoiDung where HoTen=N'{tenshop.Text}'";
                Database database = new Database();
                DataTable dt = database.getAllData(query);
                foreach (DataRow dr in dt.Rows)
                {
                    diachi.Text = dr["DiaChi"].ToString();
                }
                PhanQuyen.diachi = diachi.Text;
            }
            catch (Exception ex)
            {

            }
           
        }

    }
}
