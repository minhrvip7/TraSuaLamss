namespace TraSuaLamss.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
            GioHang = new HashSet<GioHang>();
        }

        [Key]
        [StringLength(5)]
        public string MaSP { get; set; }

        [Required]
        [StringLength(30)]
        public string TenSP { get; set; }

        [Required]
        
        public decimal GiaBan { get; set; }

        [Required]
        [StringLength(100)]
        public string MoTa { get; set; }

        [Required]
        [StringLength(100)]
        public string Anh { get; set; }

        [Required]
        [StringLength(5)]
        public string MaNL { get; set; }

        [Required]
        [StringLength(5)]
        public string MaLoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHang { get; set; }

        public virtual NguyenLieu NGUYENLIEU { get; set; }

        public virtual PhanLoai PHANLOAI { get; set; }
    }
}
