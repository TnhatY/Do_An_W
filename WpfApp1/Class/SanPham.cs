using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Do_an.Class
{
    class SanPham
    {
        public string DanhMucSP { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string TenShop { get; set; }
        public float GiaGoc { get; set; }
        public float GiaHTai { get; set; }
        public string NgayMua { get; set; }
        public string TinhTrang { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }
        public string TheLoai { get; set; }
        public string HinhAnh2 { get; set; }
        public string HinhAnh3 { get; set; }
        public string HinhAnh4 { get; set; }

        public SanPham() { }
        public SanPham(string maSP, string tenSP, string tenShop, float giaGoc, float giaHTai, string ngayMua, string tinhTrang, string moTa, string hinhAnh, string danhMucSP, string theLoai)
        {
            DanhMucSP = danhMucSP;
            MaSP = maSP;
            TenSP = tenSP;
            TenShop = tenShop;
            GiaGoc = giaGoc;
            GiaHTai = giaHTai;
            NgayMua = ngayMua;
            TinhTrang = tinhTrang;
            MoTa = moTa;
            HinhAnh = hinhAnh;
            TheLoai = theLoai;
        }
        public SanPham(string maSP, string tenSP, string tenShop, float giaGoc, float giaHTai, string ngayMua, string tinhTrang, string moTa, string hinhAnh, string danhMucSP, string theLoai,string hinhanh2,string hinhanh3,string hinhanh4)
        {
            DanhMucSP = danhMucSP;
            MaSP = maSP;
            TenSP = tenSP;
            TenShop = tenShop;
            GiaGoc = giaGoc;
            GiaHTai = giaHTai;
            NgayMua = ngayMua;
            TinhTrang = tinhTrang;
            MoTa = moTa;
            HinhAnh = hinhAnh;
            TheLoai = theLoai;
            HinhAnh2= hinhanh2;
            HinhAnh3= hinhanh3;
            HinhAnh4= hinhanh4;
        }
    }
}
