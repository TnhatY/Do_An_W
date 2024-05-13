using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for PhieuGiamGia.xaml
    /// </summary>
    public partial class PhieuGiamGia : System.Windows.Controls.UserControl
    {
        public PhieuGiamGia()
        {
            InitializeComponent();
        }
        public static int phantramgiamgia = 0;
        public static string tenkm = "";
        public static string makm = "";
        public static int sokm = 0;
        private void phieugiamgia_Click(object sender, RoutedEventArgs e)
        {
            if(sokm == 0 || tenkm!=TenKM.Text)
            {
                tenkm = TenKM.Text;
                sokm++;
                phantramgiamgia = int.Parse(giamgia.Text);
            }
            phieugiamgia.Background = new SolidColorBrush(Color.FromRgb(190, 157, 196));
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            phantramgiamgia = 0;
        }
    }
}
