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
    public class ChiTietDonHangController : Controller
    {
        private TraSuaContext db = new TraSuaContext();

        // GET: CHITIETDONHANGs
        public ActionResult Index()
        {
            var cHITIETDONHANGs = db.ChiTietDonHang.Include(c => c.KHACHHANG).Include(c => c.SANPHAM);
            return View(cHITIETDONHANGs.ToList());
        }

        // GET: CHITIETDONHANGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang cHITIETDONHANG = db.ChiTietDonHang.Find(id);
            if (cHITIETDONHANG == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETDONHANG);
        }

        // GET: CHITIETDONHANGs/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH");
            ViewBag.MaSP = new SelectList(db.SanPham, "MaSP", "TenSP");
            return View();
        }

        // POST: CHITIETDONHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,MaKH,MaSP,SoLuong,DonGia")] ChiTietDonHang cHITIETDONHANG)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietDonHang.Add(cHITIETDONHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH", cHITIETDONHANG.MaKH);
            ViewBag.MaSP = new SelectList(db.SanPham, "MaSP", "TenSP", cHITIETDONHANG.MaSP);
            return View(cHITIETDONHANG);
        }

        // GET: CHITIETDONHANGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang cHITIETDONHANG = db.ChiTietDonHang.Find(id);
            if (cHITIETDONHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH", cHITIETDONHANG.MaKH);
            ViewBag.MaSP = new SelectList(db.SanPham, "MaSP", "TenSP", cHITIETDONHANG.MaSP);
            return View(cHITIETDONHANG);
        }

        // POST: CHITIETDONHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,MaKH,MaSP,SoLuong,DonGia")] ChiTietDonHang cHITIETDONHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHITIETDONHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH", cHITIETDONHANG.MaKH);
            ViewBag.MaSP = new SelectList(db.SanPham, "MaSP", "TenSP", cHITIETDONHANG.MaSP);
            return View(cHITIETDONHANG);
        }

        // GET: CHITIETDONHANGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang cHITIETDONHANG = db.ChiTietDonHang.Find(id);
            if (cHITIETDONHANG == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETDONHANG);
        }

        // POST: CHITIETDONHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietDonHang cHITIETDONHANG = db.ChiTietDonHang.Find(id);
            db.ChiTietDonHang.Remove(cHITIETDONHANG);
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
