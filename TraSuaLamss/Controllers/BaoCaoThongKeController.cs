using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TraSuaLamss.Models;
using PagedList;
using System.Data.OleDb;
using System.Data.Entity.Validation;
using System.Globalization;

namespace TraSuaLamss.Content
{
    public class BaoCaoThongKeController : Controller
    {
        private TraSuaContext db = new TraSuaContext();

        // GET: BaoCaoThongKe
        public ActionResult Index()
        {
            var Donhang = (from s in db.DONHANGs
                           group s by new
                           {
                               Column1 = (int?)s.NgayDat.Month
                           } into g
                           orderby
                             g.Key.Column1
                           select new BaoCaoThang
                           {
                               Thang = g.Key.Column1,
                               SoLuongDonHang = g.Count(),
                               TongTien = (decimal?)g.Sum(p => p.ThanhTien)
                           }).ToList();
            return View(Donhang);
        }

        public ActionResult Details(int month)
        {
            var Donhang = (from DONHANG in db.DONHANGs
                           where
                             (int)DONHANG.NgayDat.Month == month
                           select DONHANG).ToList();
            return View(Donhang);
        }
    }
}