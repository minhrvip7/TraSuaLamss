using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TraSuaLamss.Models
{
    public class DoiThongTinModel
    {
        [Key]
        public string Username { set; get; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Yêu cầu nhập họ tên")]
        public string TenKH { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Yêu cầu chọn giới tính")]
        public string GioiTinh { set; get; }

        [Phone(ErrorMessage = "{0} sai định dạng")]
        [Required(ErrorMessage = "Yêu cầu nhập điện thoại")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Sai định dạng")]
        [Display(Name = "Điện thoại")]
        public string DienThoai { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập địa chỉ")]
        [Display(Name = "Địa chỉ")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Độ dài địa chỉ ít nhất 6 ký tự và không quá không quá 50 ký tự.")]
        public string DiaChi { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập ngày sinh")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Ngày sinh")]
        public DateTime NgaySinh { get; set; }
    }
}