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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for XemDanhGia_Window.xaml
    /// </summary>
    public partial class XemDanhGia_Window : Window
    {
        public XemDanhGia_Window()
        {
            InitializeComponent();
        }
        class danhgia
        {
            public string ten { get; set; }
            public string ngay { get; set; }
            public string danhgiasp { get; set; }
            public int sosao { get; set; }
            public danhgia(string _ten, string _ngay, string _danhgia, int sao)
            {
                ten = _ten;
                ngay = _ngay;
                danhgiasp = _danhgia;
                sosao = sao;
            }
        }
        List<danhgia> listdg = new List<danhgia>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = $"select * from DanhGia_SP where TenShop='{tenshop.Text}'";
            //MessageBox.Show(MaSP.Text);
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

                    listdg.Add(new danhgia(ten, ngaydg, danhgias, soSao));
                }
                thongtin.ItemsSource = listdg;
            }
            else
            {
                txtdanhgia.Text = "Chưa có đánh giá nào!";
                // thongtin.ItemsSource = null; 
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
