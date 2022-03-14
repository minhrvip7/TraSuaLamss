using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraSuaLamss.Models;

namespace TraSuaLamss.Controllers
{
    public class HomeController : Controller
    {
        TraSuaContext db = new TraSuaContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public bool CheckUsername(string username)
        {
            if (db.TAIKHOAN.Count(x => x.Username == username) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckEmail(string email)
        {
            if (db.KHACHHANG.Count(x => x.Email == email) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(DangKyModel model)
        {
            if (ModelState.IsValid)
            {
                if (CheckUsername(model.Username))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại!");
                }
                else if (CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại!");
                }
                else
                {
                    var tk = new TaiKhoan();
                    var kh = new KhachHang();
                    tk.Username = model.Username;
                    tk.Password = model.Password;
                    tk.HoTen = model.TenKH;
                    tk.PhanQuyen = "Khách hàng";
                    db.TAIKHOAN.Add(tk);
                    db.SaveChanges();
                    kh.TenKH = model.TenKH;
                    kh.Username = model.Username;
                    kh.GioiTinh = model.GioiTinh;
                    kh.NgaySinh = model.NgaySinh;
                    kh.Email = model.Email;
                    kh.DiaChi = model.DiaChi;
                    kh.DienThoai = model.DienThoai;
                    db.KHACHHANG.Add(kh);
                    db.SaveChanges();
                    return RedirectToAction("DangNhap", "Home");
                }
                return View(model);
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(DangNhapModel model)
        {
            if (ModelState.IsValid)
            {
                var username = model.Username;
                var password = model.Password;
                TaiKhoan tk = db.TAIKHOAN.SingleOrDefault(n => n.Username == username && n.Password == password);
                if (tk != null)
                {
                    Session["TAIKHOAN"] = tk;
                    Session["Username"] = username;
                    Session["Password"] = password;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không tồn tại!");
                    return View(model);
                }
            }
            return View(model);
        }
        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
        public ActionResult DoiMatKhau()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoiMatKhau(DoiMatKhauModel model)
        {
            if (ModelState.IsValid)
            { 
                string username = Session["Username"].ToString();
                string password = Session["Password"].ToString();
                var tk = db.TAIKHOAN.SingleOrDefault(n => n.Username == username);
                if (model.Password == password)
                {
                    var pw = model.NewPassword;
                    tk.Password = model.NewPassword;
                    db.SaveChanges();
                    Session["Password"]=pw;
                    ViewBag.Success="Mật khẩu đã được đổi thành công!";
                    return View(model);
                }
                else
                {
                    ViewBag.Error = "Mật khẩu hiện tại không đúng!";
                }
            }
            return View(model);
        }
        public ActionResult DoiThongTin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoiThongTin(string username, DoiThongTinModel model)
        {
            username = Session["Username"].ToString();
            var kh = db.KHACHHANG.SingleOrDefault(n => n.Username == username);
            if (ModelState.IsValid)
            {
                var tk = db.TAIKHOAN.SingleOrDefault(n => n.Username == username);
                tk.HoTen = model.TenKH;
                db.SaveChanges();
                kh.TenKH = model.TenKH;
                kh.NgaySinh = model.NgaySinh;
                kh.DiaChi = model.DiaChi;
                kh.DienThoai = model.DienThoai;
                db.SaveChanges();
                ViewBag.Success = "Cập nhật thành công!";
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật không thành công!");
                return View(model);
            }
            return View(model);
        }
    }
}