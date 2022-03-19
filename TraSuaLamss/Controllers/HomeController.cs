using System;
using System.Collections.Generic;
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