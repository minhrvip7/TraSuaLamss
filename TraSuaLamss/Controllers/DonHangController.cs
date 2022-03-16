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
        public ActionResult Index()
        {
            ViewBag.Message = "Đã khởi tạo đơn hàng thành công";
            return View();
        }
        /*public ActionResult CreateDonHang(IList<PhieuDatHang> list, DonHang don)
        {
            foreach (var item in list)
            {
                db.ChiTietDonHang.Add(item.CTDH);
            }
            db.DonHang.Add(don);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CreateDonHangLe(PhieuDatHang phieu, DonHang don)
        {
            db.ChiTietDonHang.Add(phieu.CTDH);
            db.DonHang.Add(don);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/
    }
}
