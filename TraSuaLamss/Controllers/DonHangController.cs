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

        // GET: DONHANGs
        public ActionResult Index()
        {
            var dONHANGs = db.DonHang.Include(d => d.KHACHHANG);
            return View(dONHANGs.ToList());
        }
        public ActionResult CreateDonHang(List<PhieuDatHang> list,string MaDH,string maKH,decimal tongtien)
        {
            return View();
        }
    }
}
