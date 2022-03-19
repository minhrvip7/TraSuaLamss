using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
        public ActionResult Search()
        {
            return View();
        }
        public bool CheckUsername(string username)
        {
            if (db.TaiKhoan.Count(x => x.Username == username) > 0)
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
            if (db.KhachHang.Count(x => x.Email == email) > 0)
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
                    db.TaiKhoan.Add(tk);
                    db.SaveChanges();
                    kh.TenKH = model.TenKH;
                    kh.Username = model.Username;
                    kh.GioiTinh = model.GioiTinh;
                    kh.NgaySinh = model.NgaySinh;
                    kh.Email = model.Email;
                    kh.DiaChi = model.DiaChi;
                    kh.DienThoai = model.DienThoai;
                    db.KhachHang.Add(kh);
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
                TaiKhoan tk = db.TaiKhoan.SingleOrDefault(n => n.Username == username && n.Password == password);
                if (tk != null)
                {
                    Session["TAIKHOAN"] = tk;
                    Session["PhanQuyen"] = tk.PhanQuyen;
                    Session["Hoten"] = tk.HoTen;
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
        public bool CheckUsername(string username)
        {
            if (db.TaiKhoan.Count(x => x.Username == username) > 0)
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
            if (db.KhachHang.Count(x => x.Email == email) > 0)
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
                
                TaiKhoan tk = db.TaiKhoan.SingleOrDefault(n => n.Username == username && n.Password == password);
                if (tk != null)
                {
                    ViewBag.Success = "Chúc mừng đăng nhập thành công!";
                    Session["TAIKHOAN"] = tk;
                    Session["Hoten"] = tk.HoTen;
                    Session["PhanQuyen"] = tk.PhanQuyen;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không tồn tại!");
                }
                return View(model);
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}