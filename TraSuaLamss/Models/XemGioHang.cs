using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TraSuaLamss.Models
{
    [Serializable]
    public class XemGioHang
    {
        public SanPham SP { get; set; }
        public int Soluong { get; set; }
        public decimal ThanhTien { get { return Convert.ToDecimal(SP.GiaBan) * Soluong; } }
    }
}