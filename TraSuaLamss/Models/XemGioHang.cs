using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TraSuaLamss.Models
{
    [Serializable]
    public class XemGioHang
    {
        public GioHang GH { get; set; }
        public SanPham SP { get; set; }
    }
}