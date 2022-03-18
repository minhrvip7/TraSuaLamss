using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TraSuaLamss.Models
{
    public class DoiMatKhauModel
    {
        [Key]
        [Required(ErrorMessage = "Nhập mật khẩu hiện tại!")]
        [Display(Name = "Mật khẩu hiện tại")]
        public string Password { set; get; }

        [Required(ErrorMessage = "Nhập mật khẩu mới!")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự.")]
        [Display(Name = "Mật khẩu mới")]
        public string NewPassword { set; get; }

        [Required(ErrorMessage = "Nhập xác nhận mật khẩu!")]
        [Compare("NewPassword", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        [Display(Name = "Xác nhận mật khẩu")]
        public string ConfirmPassword { set; get; }
    }
}