namespace TraSuaLamss.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
            DonHang = new HashSet<DonHang>();
            GioHang = new HashSet<GioHang>();
        }

        [Key]
        public int MaKH { get; set; }

        [Required]
        [StringLength(30)]
        public string TenKH { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHang { get; set; }

        public virtual TaiKhoan TAIKHOAN { get; set; }
    }
}
