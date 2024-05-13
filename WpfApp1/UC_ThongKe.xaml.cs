using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_Thongke.xaml
    /// </summary>
    public partial class UC_Thongke : UserControl
    {
        public UC_Thongke()
        {
            InitializeComponent();
           
        }
     
        private void CartesianChart_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadChartData();
        }
        private void LoadChartData()
        {
            Database database = new Database();
            try
            {
                string query = "select NguoiDung.HoTen, sum(SanPham.GiaHTai) as tong From SanPham inner join SP_DaMua on SanPham.MaSP=SP_DaMua.MaSP inner join SP_Ban on SP_Ban.MaSP=SP_DaMua.MaSP inner join NguoiDung on SP_Ban.TaiKhoan=NguoiDung.TaiKhoan Group by SP_Ban.TaiKhoan, NguoiDung.HoTen";
              
                DataTable dt = database.getAllData(query);
                var values = new ChartValues<double>();
                var labels = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    labels.Add(row["HoTen"].ToString());
                    values.Add(double.Parse(row["tong"].ToString()));
                }
                var barSeries = new ColumnSeries
                {
                    Title = "Doanh Thu",
                    Values = values
                };

                barChart.Series.Clear();
                barChart.Series.Add(barSeries);
                barChart.AxisX.Clear();

                barChart.AxisX.Add(new Axis
                {
                    Title = "\nTên Shop",
                    Labels = labels
                });

                barChart.AxisY.Add(new Axis
                {
                    Title = "Tổng Doanh Thu (đơn vị: VNĐ)\n",
                    
                    LabelFormatter = value => value.ToString("N0") // Format nhãn để dễ đọc, ví dụ: 1,000, 2,000
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string sqlsosp = "select count(*) as tongsp From SanPham";
            DataTable dt2= database.getAllData(sqlsosp);
            foreach(DataRow row in dt2.Rows)
            {
                tongsanpham.Text = row["tongsp"].ToString();
            }
            string sqlsoshop = "SELECT COUNT(DISTINCT TenShop) AS SoLuongCuaHang FROM SanPham;";
            DataTable dt3 = database.getAllData(sqlsoshop);
            foreach (DataRow row in dt3.Rows)
            {
              
               tongsoshop.Text = row["SoLuongCuaHang"].ToString();
            }
            string sql4 = "SELECT count( DISTINCT TenShop) as tong FROM SanPham WHERE TenShop NOT IN (SELECT DISTINCT NguoiDung.HoTen  FROM SanPham INNER JOIN SP_DaMua ON SanPham.MaSP = SP_DaMua.MaSP  INNER JOIN SP_Ban ON SP_Ban.MaSP = SP_DaMua.MaSP  INNER JOIN NguoiDung ON SP_Ban.TaiKhoan = NguoiDung.TaiKhoan  GROUP BY SP_Ban.TaiKhoan, NguoiDung.HoTen)";
            DataTable dt4 = database.getAllData(sql4);
            foreach (DataRow row in dt4.Rows)
            {
                kodoanhthu.Text = row["tong"].ToString();
            }
        }
    }
}
