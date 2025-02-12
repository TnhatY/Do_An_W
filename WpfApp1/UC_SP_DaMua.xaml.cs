﻿using Do_an.Class;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_SP_DaMua.xaml
    /// </summary>
    public partial class UC_SP_DaMua : UserControl
    {
        public UC_SP_DaMua()
        {
            InitializeComponent();
        }
        NguoiBan nguoiBan=new NguoiBan();
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (PhanQuyen.menu == "YeuThich")
            {

            }
        }

        private void btndanhgia_Click(object sender, RoutedEventArgs e)
        {
            DanhGiaSp_Window danhGiaSp_Window = new DanhGiaSp_Window();
            danhGiaSp_Window.tenshop.Text = tenshop.Text;
            danhGiaSp_Window.ShowDialog();
        }

        private void btnhuydon_Click(object sender, RoutedEventArgs e)
        {
            LyDoHuyDon_WD f=new LyDoHuyDon_WD();
            f.ShowDialog();
            if (LyDoHuyDon_WD.confirm == "yes")
            {
                string query = $"delete from SP_DaMua where MaSP='{masp.Text}'";
                SanPham_DAO sanPham_DAO = new SanPham_DAO();
                nguoiBan.Xoa(query);
                btnhuydonhang.Visibility = Visibility.Collapsed;
                thongbaohuydon.Text = "Đơn hàng đã được huỷ!";
                giaohang.Text = "Cảm ơn bạn đã quan tâm!";
            }
        }
    }
}
