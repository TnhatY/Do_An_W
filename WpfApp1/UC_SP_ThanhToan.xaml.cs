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
    /// Interaction logic for UC_SP_ThanhToan.xaml
    /// </summary>
    public partial class UC_SP_ThanhToan : UserControl
    {
        public UC_SP_ThanhToan()
        {
            InitializeComponent();
        }
        public event RoutedEventHandler ButtonClicked;
       
        private void voucher_Click(object sender, RoutedEventArgs e)
        {
            
            ButtonClicked?.Invoke(this, e);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (TongPhieuGiam.checkgiamgia)
            {
                tenvoucher.Text = "Đã giảm";
            }
        }
    }
}
