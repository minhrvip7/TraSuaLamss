using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TraSuaLamss.Models
{
    [Serializable]
    public class PhieuDatHang
    {
        public SanPham SP { get; set; }
        public ChiTietDonHang CTDH { get; set; }
    }
}