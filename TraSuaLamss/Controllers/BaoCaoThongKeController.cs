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
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TraSuaLamss.Content
{
    public class BaoCaoThongKeController : Controller
    {
        private TraSuaContext db = new TraSuaContext();

        // GET: BaoCaoThongKe
        public ActionResult Index(string sortOrder)
        {
            ViewBag.TongTienSort = sortOrder == "TongTien" ? "TongTien_desc" : "TongTien";
            ViewBag.DoanhSoSort = sortOrder == "DoanhSo" ? "DoanhSo_desc" : "DoanhSo";
            ViewBag.ThangSort = sortOrder == "" ? "Thang_desc" : "";
            var Donhang = (from s in db.DonHang
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
                           });
            switch (sortOrder)
            {
                case "TongTien_desc":
                    Donhang = Donhang.OrderByDescending(s => s.TongTien);
                    break;
                case "TongTien":
                    Donhang = Donhang.OrderBy(s => s.TongTien);
                    break;
                case "DoanhSo_desc":
                    Donhang = Donhang.OrderByDescending(s => s.SoLuongDonHang);
                    break;
                case "DoanhSo":
                    Donhang = Donhang.OrderBy(s => s.SoLuongDonHang);
                    break;
                case "Thang_desc":
                    Donhang = Donhang.OrderByDescending(s => s.Thang);
                    break;
                default:
                    Donhang = Donhang.OrderBy(s => s.Thang);
                    break;
            }
            return View(Donhang.ToList());
        }

        public ActionResult Details(int month)
        {
            var Donhang = (from DONHANG in db.DonHang
                           where
                             (int)DONHANG.NgayDat.Month == month
                           select DONHANG).ToList();
            return View(Donhang);
        }
    }
}