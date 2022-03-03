using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//class chứa thông tin chi tiết sản phẩm

namespace TraSuaLamss.Models
{
    public class ChiTietSanPham
    {
        public string MaSP { get; set; }
        public string GiaBan { get; set; }
        public string TenSP { get; set; }
        public string MoTa { get; set; }
        public string Anh { get; set; }
        public string TenLoai { get; set; }
        public string TenNL { get; set; }
    }
}