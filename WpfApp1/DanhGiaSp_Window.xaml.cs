using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using Do_an.Class;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for DanhGiaSp_Window.xaml
    /// </summary>
    public partial class DanhGiaSp_Window : Window
    {
        
        public DanhGiaSp_Window()
        {
            InitializeComponent();
            DateTime ngays = DateTime.Now;
            ngayDg.Text = ngays.ToString();
        }
        private void Star_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton clickedStar = sender as ToggleButton;
            int dem = 0;
            if (clickedStar != null)
            {
                int clickedIndex = int.Parse(clickedStar.Name.Substring(4)); // Lấy chỉ số của sao được nhấp vào

                // Đặt các sao trước đó theo trạng thái của sao hiện tại
                for (int i = 1; i <= clickedIndex; i++)
                {
                    ToggleButton star = FindName("star" + i) as ToggleButton;
                    if (star != null)
                    {
                        star.IsChecked = true;
                        dem++;
                    }
                }

                // Bỏ chọn các sao sau đó
                for (int i = clickedIndex + 1; i <= 5; i++)
                {
                    ToggleButton star = FindName("star" + i) as ToggleButton;
                    if (star != null)
                    {
                        star.IsChecked = false;
                    }
                }
                sosao.Text=dem.ToString();
            }
        }
        

        private void nhanXet_Click(object sender, RoutedEventArgs e)
        {

            if (sender == nx1)
            {
                nhanxet.Text += nx1.Content.ToString() + Environment.NewLine;
            }
            else if (sender == nx2)
            {
                nhanxet.Text += nx2.Content.ToString() + Environment.NewLine;
            }
            else if (sender == nx3)
            {
                nhanxet.Text += nx3.Content.ToString() + Environment.NewLine;
            }
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        

        private void GuiNhanXet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DanhGia_DAO danhGia_DAO = new DanhGia_DAO();
                DanhGiaSP danhGiaSP = new DanhGiaSP(tenshop.Text,PhanQuyen.ten,ngayDg.Text,nhanxet.Text,sosao.Text);  
                danhGia_DAO.themDG(danhGiaSP);
                MessageBox.Show("Cảm ơn bạn đã đánh giá!");
                Close();
            }
            catch (Exception Fail)
            {
                MessageBox.Show(Fail.Message);
            }
        }
    }
}
