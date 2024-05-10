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
        DanhGia_DAO danhGia_DAO = new DanhGia_DAO();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            itemdanhgia.ItemsSource = danhGia_DAO.XemDanhGia(tenshop.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
