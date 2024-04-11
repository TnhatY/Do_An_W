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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Do_an
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
      
        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Database database = new Database();
            DataTable dt =new DataTable();
            passwordTextBox.Text = passwordBox.Password;
            try
            {
                string query = "select * from NguoiDung ";
                dt = database.getAllData(query);

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            if (string.IsNullOrWhiteSpace(txtDangNhap.Text) || string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                System.Windows.MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Cảnh báo");
                txtDangNhap.Focus();
                return;
            }
            else
            {
                bool check = false;
                foreach (DataRow row in dt.Rows)
                {
                    if (txtDangNhap.Text == row["TaiKhoan"].ToString() && passwordTextBox.Text == row["MatKhau"].ToString())
                    {
                        check = true;
                        PhanQuyen.loaiTk = row["LoaiTK"].ToString();
                        PhanQuyen.taikhoan = row["TaiKhoan"].ToString();
                        PhanQuyen.ten = row["HoTen"].ToString();
                    }
                }
                if (check)
                {
                    F_Main f = new F_Main();
                    f.ShowDialog();
                }
                else
                {
                    System.Windows.MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Cảnh báo");
                }
            }
            

        }

       
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Text = passwordBox.Password;
            passwordTextBox.Visibility = Visibility.Visible;
            passwordBox.Visibility = Visibility.Collapsed;
            eye.Source = new BitmapImage(new Uri("/image/eye.png", UriKind.Relative));
            
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordBox.Password = passwordTextBox.Text;
            passwordBox.Visibility = Visibility.Visible;
            passwordTextBox.Visibility = Visibility.Collapsed;
            eye.Source = new BitmapImage(new Uri("/image/uneye.png", UriKind.Relative));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
    }
}
