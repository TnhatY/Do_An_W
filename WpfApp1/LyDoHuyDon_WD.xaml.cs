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
using System.Windows.Shapes;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for LyDoHuyDon_WD.xaml
    /// </summary>
    public partial class LyDoHuyDon_WD : Window
    {
        public LyDoHuyDon_WD()
        {
            InitializeComponent();
        }
        public static string confirm = "";

        private void xacnhanhuy_Click(object sender, RoutedEventArgs e)
        {
            confirm = "yes";
            Close();
        }

        private void thoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
