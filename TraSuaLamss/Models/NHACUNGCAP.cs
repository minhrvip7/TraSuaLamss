namespace TraSuaLamss.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHACUNGCAP")]
    public partial class NhaCungCap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaCungCap()
        {
            NguyenLieu = new HashSet<NguyenLieu>();
        }

        [Key]
        [StringLength(5)]
        public string MaNCC { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNCC { get; set; }

        [Required]
        [StringLength(100)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(20)]
        public string SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguyenLieu> NguyenLieu { get; set; }
    }
}
