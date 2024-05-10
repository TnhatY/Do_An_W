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
    /// Interaction logic for UC_DanhGia.xaml
    /// </summary>
    public partial class UC_DanhGia : UserControl
    {
        public UC_DanhGia()
        {
            InitializeComponent();
           
        }
        DanhGia_DAO danhGia_DAO = new DanhGia_DAO();
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            int saoCount = int.Parse(sosao.Text);
            danhGia_DAO.HienThiSoSao(saoCount,starPanel);
        }
    }
}
