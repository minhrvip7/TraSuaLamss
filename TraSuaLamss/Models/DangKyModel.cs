using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TraSuaLamss.Models
{
    public class DangKyModel
    {
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Yêu cầu nhập họ tên")]
        public string TenKH { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Yêu cầu chọn giới tính")]
        public string GioiTinh { set; get; }

        [Key]
        [Display(Name = "Tên đăng nhập")]
        [StringLength(20,MinimumLength = 6, ErrorMessage = "Độ dài tên đăng nhập ít nhất 6 ký tự và không quá 20 ký tự.")]
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]
        public string Username { set; get; }

        [Display(Name = "Mật khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự và không quá 20 ký tự.")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string Password { set; get; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        public string ConfirmPassword { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập email")]
        [EmailAddress(ErrorMessage = "Email sai định dạng")]
        [Display(Name = "Email")]
        public string Email { set; get; }

        [Phone(ErrorMessage = "{0} sai định dạng")]
        [Required(ErrorMessage = "Yêu cầu nhập điện thoại")]
        [StringLength(10, MinimumLength=10 , ErrorMessage = "Sai định dạng")]
        [Display(Name = "Điện thoại")]
        public string DienThoai { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập địa chỉ")]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập ngày sinh")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString ="{0:dd/MM/yyyy}")]
        [Display(Name = "Ngày sinh")]
        public DateTime NgaySinh { get; set; }
    }
}