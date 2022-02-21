using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TraSuaLamss.Models
{
    public class DangKyModel
    {
        [Display(Name ="Họ tên")]
        [Required(ErrorMessage ="Yêu cầu nhập họ tên")]
        public string TenKH { get; set; } 

        [Key]
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]
        public string Username { set; get; }

        [Display(Name = "Mật khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự.")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string Password { set; get; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        public string ConfirmPassword { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập email")]
        [Display(Name = "Email")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập điện thoại")]
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