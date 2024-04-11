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
            //int saoCount = int.Parse(sosao.Text);
             // Xóa bỏ nội dung hiện tại của sosao.Text
           
        }
        private void DisplayStars(int numberOfStars)
        {
            starPanel.Children.Clear();
            for (int i = 0; i < numberOfStars; i++)
            {
                TextBlock saoTextBlock = new TextBlock();
                saoTextBlock.Foreground = Brushes.Red;
                saoTextBlock.Text = "☆";
                starPanel.Children.Add(saoTextBlock);
            }

            for (int i = numberOfStars; i < 5; i++)
            {
                TextBlock saoTextBlock = new TextBlock();
                saoTextBlock.Text = "☆";
                starPanel.Children.Add(saoTextBlock); 
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            int saoCount = int.Parse(sosao.Text);
            DisplayStars(saoCount);
        }
    }
}
