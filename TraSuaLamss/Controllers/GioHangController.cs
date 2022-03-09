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
        private const string MaKHSession = "MaKHSession";
        public ActionResult Giohang()
        {
            string KHID = "KH001";
            IList<XemGioHang> list = (from e in db.GIOHANG
                        join d in db.SANPHAM
                        on e.MaSP equals d.MaSP
                        where e.MaKH == KHID
                        select new XemGioHang { GH = e, SP = d }).ToList();
            ViewBag.MaKH = KHID;
            ViewData["ListGiohang"] = list;
            return View(list);
        }
        public ActionResult Dathang(List<XemGioHang> lists)
        { 
            return View();
        }

        public ActionResult Add(string MaKhach, string MaHang, int soluong)
        {
            GioHang gioHang = (from e in db.GIOHANG
                               where (e.MaKH == MaKhach && e.MaSP == MaHang)
                               select e).FirstOrDefault();
            if (gioHang == null)
            {
                gioHang = new GioHang();
                gioHang.MaKH = MaKhach;
                gioHang.MaSP = MaHang;
                gioHang.Soluong = soluong;
                db.GIOHANG.Add(gioHang);
            }
            else
            {
                gioHang.Soluong += soluong;
            }
            db.SaveChanges();
            return RedirectToAction("Giohang");
        }
        public ActionResult Delete(string MaKhach, string MaHang)
        {
            GioHang gioHang = (from e in db.GIOHANG
                               where (e.MaKH == MaKhach && e.MaSP == MaHang)
                               select e).FirstOrDefault();
            if (gioHang != null)
            {
                db.GIOHANG.Remove(gioHang);
            }
            db.SaveChanges();
            return RedirectToAction("Giohang");
        }
        public ActionResult DeleteAll(string MaKhach)
        {
            foreach(var item in db.GIOHANG)
            {
                if (item.MaKH == MaKhach)
                {
                    db.GIOHANG.Remove(item);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Giohang");
        }
    }
}
