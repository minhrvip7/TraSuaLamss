namespace TraSuaLamss.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NhanVien
    {
        [Key]
        [StringLength(5)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(30)]
        public string TenNV { get; set; }

        [Required]
        [StringLength(10)]
        public string GioiTinh { get; set; }

        public DateTime NgaySinh { get; set; }

        [Required]
        [StringLength(30)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(20)]
        public string DienThoai { get; set; }

        [Required]
        [StringLength(50)]
        public string STK { get; set; }

        public decimal Luong { get; set; }

        public virtual TaiKhoan TAIKHOAN { get; set; }
    }
}
