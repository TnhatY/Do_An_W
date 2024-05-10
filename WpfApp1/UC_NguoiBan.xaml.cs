using System;
using System.Collections.Generic;
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
    /// Interaction logic for UC_NguoiBan.xaml
    /// </summary>
    public partial class UC_NguoiBan : UserControl
    {
        public UC_NguoiBan()
        {
            InitializeComponent();
          
        }
        DanhGia_DAO danhGia_DAO = new DanhGia_DAO();

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            int sosa = 0;

            if (sosao.Text =="" )
            {
                sosa = 0;
            }else
                sosa = int.Parse(sosao.Text);
            danhGia_DAO.HienThiSoSao(sosa, stackSoSao);
        }

        private void xemdanhgia_Click(object sender, RoutedEventArgs e)
        {
            XemDanhGia_Window xemDanhGia_=new XemDanhGia_Window();
            xemDanhGia_.tenshop.Text = ten.Text;
            xemDanhGia_.ShowDialog();
            //danhGia_DAO.XemDanhGia(ten.Text);
        }
    }
}
