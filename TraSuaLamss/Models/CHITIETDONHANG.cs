namespace TraSuaLamss.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETDONHANG")]
    public partial class CHITIETDONHANG
    {
        [Required]
        [StringLength(5)]
        public string MaKH { get; set; }

        [Key]
        [StringLength(5)]
        public string MaHD { get; set; }

        [StringLength(5)]
        public string MaSP { get; set; }

        public int SoLuong { get; set; }

        public decimal DonGia { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual SanPham SANPHAM { get; set; }
    }
}
