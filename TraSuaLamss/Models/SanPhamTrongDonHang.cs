using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TraSuaLamss.Models
{
    [Serializable]
    public class SanPhamTrongDonHang
    {
        public ChiTietDonHang chiTietDonHang { get; set; }
        public SanPham sanPham { get; set; }
    }
}