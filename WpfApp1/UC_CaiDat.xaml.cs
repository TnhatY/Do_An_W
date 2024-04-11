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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_CaiDat.xaml
    /// </summary>
    public partial class UC_CaiDat : UserControl
    {
        public UC_CaiDat()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string tk = PhanQuyen.taikhoan;
            string sql = $"select * from NguoiDung where TaiKhoan='{tk}' ";
            Database database = new Database();
            DataTable dt = database.getAllData(sql);
            List<NguoiDung> list = new List<NguoiDung>();
            foreach (DataRow row in dt.Rows)
            {
                string hoten = row["HoTen"].ToString();
                DateTime ngaySinh = (DateTime)row["NgaySinh"];
                string ngayThangNam = ngaySinh.ToShortDateString();
                string gioitinh = row["GioiTinh"].ToString();
                string sodt = row["SoDT"].ToString();
                string email = row["Email"].ToString();
                string taikhoan = row["TaiKhoan"].ToString();
                string matkhau = row["MatKhau"].ToString();
                string diachi = row["DiaChi"].ToString();
                list.Add(new NguoiDung(hoten, ngayThangNam, gioitinh, sodt, email, taikhoan, matkhau, diachi));
            }
            hoten.Text= list[0].hoten;
            ngaysinh.Text= list[0].ngaysinh;
            gioitinh.Text  = list[0].gioitinh;
            sodt.Text= list[0].sodt;
            email.Text= list[0].email;
            diachi.Text= list[0].diachi;

        }
    }
}
