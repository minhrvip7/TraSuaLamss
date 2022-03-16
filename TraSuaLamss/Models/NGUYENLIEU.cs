namespace TraSuaLamss.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGUYENLIEU")]
    public partial class NguyenLieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguyenLieu()
        {
            SanPham = new HashSet<SanPham>();
        }

        [Key]
        [StringLength(5)]
        public string MaNL { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNL { get; set; }

        [Required]
        [StringLength(5)]
        public string MaNCC { get; set; }

        public virtual NhaCungCap NHACUNGCAP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
