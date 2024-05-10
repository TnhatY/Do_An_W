using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_an.Class
{
    class NguoiMua:NguoiDung
    {
        public NguoiMua() { }   
        public override void Dat_Hang(string masp)
        {
            base.Dat_Hang(masp);
        }
        public override bool ThemGioHang(string masp, string taikhoan, string query)
        {
            return base.ThemGioHang(masp, taikhoan, query);
        }
    }
}
