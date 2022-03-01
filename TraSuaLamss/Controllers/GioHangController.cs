using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TraSuaLamss.Models;

namespace TraSuaLamss.Controllers
{
    public class GioHangController : Controller
    {
        private TraSuaContext db = new TraSuaContext();
        public ActionResult Giohang(string KHID)
        {
            KHID = "KH001";
            var list = (from e in db.GioHang
                        join d in db.SanPham
                        on e.MaSP equals d.MaSP
                        where e.MaKH == KHID
                        select new XemGioHang { GH = e, SP = d }).ToList();
            return View(list);
        }
        public ActionResult Dathang()
        {
            return View();
        }
        public ActionResult Add(string MaKhach, string MaHang, int soluong)
        {
            var list = (from e in db.GioHang select e).ToList();
            if (list.Exists(e => e.MaSP == MaHang && e.MaKH == MaKhach))
            {
                foreach (var item in db.GioHang)
                {
                    if (item.MaKH == MaKhach && item.MaSP == MaHang)
                    {
                        item.Soluong += soluong;
                    }
                    db.SaveChanges();
                }
            }
            else
            {
                GioHang giohangnew = new GioHang { MaKH = MaKhach, MaSP = MaHang, Soluong = soluong };
                db.GioHang.Add(giohangnew);
                db.SaveChanges();
            }
            return RedirectToAction("Giohang");
        }
    }
}
