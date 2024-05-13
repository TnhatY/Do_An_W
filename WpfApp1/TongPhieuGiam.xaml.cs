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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for TongPhieuGiam.xaml
    /// </summary>
    public partial class TongPhieuGiam : Window
    {
        public TongPhieuGiam()
        {
            InitializeComponent();
        }
        Database data=new Database();
        public static bool checkgiamgia = false;
        public static string ten = "";
      
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = $"select * from Voucher where TenShop=N'{tenshop.Text}'";
                List<PhieuGiamGia> list = new List<PhieuGiamGia>();
                DataTable dt = data.getAllData(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    PhieuGiamGia phieuGiamGia = new PhieuGiamGia();
                    phieuGiamGia.TenKM.Text = dr["TenKM"].ToString();
                    phieuGiamGia.giamgia.Text = dr["PhanTramGiam"].ToString();
                    list.Add(phieuGiamGia);
                }
                phieugiamgia.ItemsSource = list;
            }catch(Exception ex)
            {
                MessageBox.Show("Hiện chưa có mã giảm giá nào!");
                Close();
            }
        }

        private void chon_Click(object sender, RoutedEventArgs e)
        {
            checkgiamgia=true;
            Close();
        }
    }
}
