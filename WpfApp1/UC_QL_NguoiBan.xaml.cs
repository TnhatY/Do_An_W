using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_QL_NguoiBan.xaml
    /// </summary>
    public partial class UC_QL_NguoiBan : UserControl
    {
        public UC_QL_NguoiBan()
        {
            InitializeComponent();
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "Select DanhGia_SP.TenShop,NguoiDung.DiaChi,NguoiDung.SoDT,NguoiDung.Avatar, Count(*) as SoDanhGia, Sum(SoSao) as TongSao from NguoiDung inner join DanhGia_SP on DanhGia_SP.TenShop=NguoiDung.HoTen Group by DanhGia_SP.TenShop,NguoiDung.DiaChi,NguoiDung.SoDT,NguoiDung.Avatar";
            try
            {
                Database database = new Database();
               // string sql = "Select * From NguoiDung";

                DataTable dt = database.getAllData(sql);
                List<UC_NguoiBan> listuytin = new List<UC_NguoiBan>();
                List<UC_NguoiBan> listkouytin = new List<UC_NguoiBan>();
                foreach (DataRow row in dt.Rows)
                {
                    UC_NguoiBan uc_topdanhmuc = new UC_NguoiBan();
                    uc_topdanhmuc.ten.Text = row["TenShop"].ToString();
                    uc_topdanhmuc.diachi.Text = row["DiaChi"].ToString();
                    uc_topdanhmuc.sdt.Text = row["SoDT"].ToString();
                    int sodanhgia = int.Parse(row["SoDanhGia"].ToString());
                    int sosao = int.Parse(row["TongSao"].ToString());
                    uc_topdanhmuc.sodanhgia.Text = row["SoDanhGia"].ToString();
                    uc_topdanhmuc.sosao.Text = (sosao / sodanhgia).ToString();
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(row["Avatar"].ToString(), UriKind.RelativeOrAbsolute);
                    bitmap.EndInit();
                    uc_topdanhmuc.hinhanh.Source = bitmap;
                    if (sosao / sodanhgia > 3)
                        listuytin.Add(uc_topdanhmuc);
                    else
                        listkouytin.Add(uc_topdanhmuc);

                }
                listNguoibanuytin.ItemsSource = listuytin;
                listNguoibankouytin.ItemsSource = listkouytin;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
