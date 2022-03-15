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
    public class DonHangController : Controller
    {
        private TraSuaContext db = new TraSuaContext();
        private const string MaKHSession = "MaKH";
        // GET: DONHANGs
        public ActionResult Index()
        {
            ViewBag.Message = "Đã khởi tạo đơn hàng thành công";
            return View();
        }
        public ActionResult CreateDonHang(List<PhieuDatHang> list, DonHang DH)
        {
            foreach (var item in list)
            {
                db.ChiTietDonHang.Add(item.CTDH);
            }
            db.DonHang.Add(DH);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CreateDonHangLe(PhieuDatHang Phieu, DonHang DH)
        {
            db.ChiTietDonHang.Add(Phieu.CTDH);
            db.DonHang.Add(DH);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
