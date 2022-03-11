namespace TraSuaLamss.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIOHANG")]
    public partial class GioHang
    {
        [Key]
        [Column(Order = 0)]
        public int MaKH { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string MaSP { get; set; }

        public int Soluong { get; set; }

        public virtual KhachHang KHACHHANG { get; set; }

        public virtual SanPham SANPHAM { get; set; }
    }
}
