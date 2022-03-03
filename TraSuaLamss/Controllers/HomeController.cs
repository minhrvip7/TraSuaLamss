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
        TraSuaContext db=new TraSuaContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult DangNhap(DangNhapModel model)
        {
            if (ModelState.IsValid)
            {
                var username = model.Username;
                var password = model.Password;
                TAIKHOAN tk = db.TAIKHOAN.SingleOrDefault(n => n.Username == username && n.Password == password);
                if (tk != null)
                {
                    ViewBag.Success = "Chúc mừng đăng nhập thành công!";
                    Session["TAIKHOAN"] = tk;
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
    }
}