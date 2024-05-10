using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_an.Class
{
    class DanhGiaSP
    {
        public string ten { get; set; }
        public string ngay { get; set; }
        public string danhgiasp { get; set; }
        public int sosao { get; set; }
        public string tenshop { get; set; }
        public string avatar { get; set; }
        public DanhGiaSP(string _ten, string _ngay, string _danhgia, int sao, string avatar)
        {
            ten = _ten;
            ngay = _ngay;
            danhgiasp = _danhgia;
            sosao = sao;
            this.avatar = avatar;
        }
        public DanhGiaSP(string tenshop, string _ten, string _ngay, string _danhgia, int sao,string avatar)
        {
            this.tenshop = tenshop;
            ten = _ten;
            ngay = _ngay;
            danhgiasp = _danhgia;
            sosao = sao;
            this.avatar = avatar;
        }
        public DanhGiaSP() { }  
    }
}
