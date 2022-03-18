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
        [Required(ErrorMessage = "Nhập mã")]
        [StringLength(5)]
        public string MaNV { get; set; }

        [Required(ErrorMessage = "Nhập tên")]
        [StringLength(30)]
        public string TenNV { get; set; }

        [Required(ErrorMessage = "Chọn giới tính")]
        [StringLength(30)]
        public string GioiTinh { get; set; }

        [Required(ErrorMessage = "Nhập ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }

        [Required(ErrorMessage = "Chọn tên đăng nhập")]
        [StringLength(30, ErrorMessage = "Không nhập quá 30 ký tự")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Nhhập email")]
        [StringLength(50, ErrorMessage = "Không nhập quá 50 ký tự")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Nhhập địa chỉ")]
        [StringLength(200, ErrorMessage = "Không nhập quá 200 ký tự ")]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Nhập số điện thoại")]
        [StringLength(10, MinimumLength = 10, ErrorMessage ="Điện thoại gồm 10 số")]
        public string DienThoai { get; set; }

        [Required(ErrorMessage ="Nhập số tài khoản")]
        [StringLength(14, MinimumLength =14, ErrorMessage ="Tài khoản ngân hàng gồm 14 số")]
        public string STK { get; set; }

        [Required(ErrorMessage ="Nhập tiền lương")]
        [Display(Name = "Lương")]
        public decimal Luong { get; set; }

        public virtual TaiKhoan TAIKHOAN { get; set; }
    }
}
