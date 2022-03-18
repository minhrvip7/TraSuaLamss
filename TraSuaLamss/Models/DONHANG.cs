namespace TraSuaLamss.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    [Table("DONHANG")]
    [Serializable]
    public partial class DonHang
    {
        [Key]
        [StringLength(5)]
        public string MaDH { get; set; }

        [Column(TypeName = "money")]
        public decimal ThanhTien { get; set; }

        [Required]
        [StringLength(50)]
        public string PhuongThucThanhToan { get; set; }

        [Required]
        [StringLength(30)]
        public string ThanhToan { get; set; }

        [Required]
        [StringLength(50)]
        public string DiaChiGiaoHang { get; set; }

        [Required]
        [StringLength(50)]
        public string TinhTrangGiaoHang { get; set; }

        [DataType(DataType.Date)]
        public DateTime NgayDat { get; set; }

        [DataType(DataType.Date)]
        public DateTime NgayGiao { get; set; }

        [Required]
        public int MaKH { get; set; }

        [Required]
        [StringLength(100)]
        public string GhiChu { get; set; }

        public virtual KhachHang KHACHHANG { get; set; }
    }
}
