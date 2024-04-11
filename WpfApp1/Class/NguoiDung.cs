using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_an.Class
{
    internal class NguoiDung
    {
        public string hoten { get; set; }   
        public string ngaysinh { get; set; }
        public string gioitinh { get; set; }
        public string sodt { get; set; }
        public string email { get; set; }
        public string taikhoan { get; set; }
        public string matkhau { get; set; }
        public string diachi { get; set; }

        public NguoiDung(string hoten, string ngaysinh, string gioitinh, string sodt, string email, string taikhoan, string matkhau, string diachi)
        {
            this.hoten = hoten;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.sodt = sodt;
            this.email = email;
            this.taikhoan = taikhoan;
            this.matkhau = matkhau;
            this.diachi = diachi;
        }
        public NguoiDung() { }
    }
}
