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

        // GET: GIOHANGs
        public ActionResult Index()
        {
            int KHID = 1;
            List<XemGioHang> list = (from e in db.GioHang
                                      join d in db.SanPham
                                      on e.MaSP equals d.MaSP
                                      where e.MaKH == KHID
                                      select new XemGioHang { GH = e, SP = d }).ToList();
            ViewBag.MaKH = KHID;
            Session[ListHangSession] = list;
            return View(list);
        }

        // GET: GIOHANGs/Details/5
        public ActionResult Details(string id)
        {
            var list = Session[ListHangSession] as List<XemGioHang>;
            int KHID = 1;
            string MaDH = "DH";
            int SLDH = db.DonHang.Count() + 1;
            if (SLDH < 1000 && SLDH > 99)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIOHANG gIOHANG = db.GIOHANGs.Find(id);
            if (gIOHANG == null)
            {
                return HttpNotFound();
            }
            return View(gIOHANG);
        }

        // GET: GIOHANGs/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "TenKH");
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP");
            return View();
        }

        // POST: GIOHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,MaSP,Soluong")] GIOHANG gIOHANG)
        {
            if (ModelState.IsValid)
            {
                db.GIOHANGs.Add(gIOHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TongTien = lischitiet.Sum(x => x.CTDH.SoLuong * x.CTDH.DonGia);
            ViewBag.MaDH = MaDH;
            ViewBag.TenKH = (from e in db.KhachHang
                                where e.MaKH == KHID
                                select e.TenKH).FirstOrDefault();
            ViewBag.DiaChi = (from e in db.KhachHang
                             where e.MaKH == KHID
                             select e.DiaChi).FirstOrDefault();
            ViewBag.NgayDat = DateTime.Today.ToString("dd/MM/yyyy");
            return View(lischitiet);
        }

        public ActionResult Add(int MaKhach, string MaHang, int soluong)
        {
            GioHang gioHang = (from e in db.GioHang
                               where e.MaKH == MaKhach && e.MaSP == MaHang
                               select e).FirstOrDefault();
            if (gioHang == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIOHANG gIOHANG = db.GIOHANGs.Find(id);
            if (gIOHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "TenKH", gIOHANG.MaKH);
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP", gIOHANG.MaSP);
            return View(gIOHANG);
        }
        public ActionResult Delete(int MaKhach, string MaHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gIOHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "TenKH", gIOHANG.MaKH);
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP", gIOHANG.MaSP);
            return View(gIOHANG);
        }
        public ActionResult DeleteAll(int MaKhach)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIOHANG gIOHANG = db.GIOHANGs.Find(id);
            if (gIOHANG == null)
            {
                return HttpNotFound();
            }
            return View(gIOHANG);
        }

        // POST: GIOHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GIOHANG gIOHANG = db.GIOHANGs.Find(id);
            db.GIOHANGs.Remove(gIOHANG);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
