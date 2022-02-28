﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TraSuaLamss.Models
{
    [Serializable]
    public class XemGioHang
    {
        public string TenSP { get; set; }
        public string HinhAnh { get; set; }
        public string GiaBan { get; set; }
        public int Soluong { get; set; }
        public decimal ThanhTien { get { return Convert.ToDecimal(GiaBan) * Soluong; } }
    }
}