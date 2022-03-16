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

        // GET: GioHang
        public ActionResult Index()
        {
            var gIOHANGs = db.GioHang.Include(g => g.KHACHHANG).Include(g => g.SANPHAM);
            return View(gIOHANGs.ToList());
        }

        // GET: GioHang/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gIOHANG = db.GioHang.Find(id);
            if (gIOHANG == null)
            {
                return HttpNotFound();
            }
            return View(gIOHANG);
        }

        // GET: GioHang/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH");
            ViewBag.MaSP = new SelectList(db.SanPham, "MaSP", "TenSP");
            return View();
        }

        // POST: GioHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,MaSP,Soluong")] GioHang gIOHANG)
        {
            if (ModelState.IsValid)
            {
                db.GioHang.Add(gIOHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH", gIOHANG.MaKH);
            ViewBag.MaSP = new SelectList(db.SanPham, "MaSP", "TenSP", gIOHANG.MaSP);
            return View(gIOHANG);
        }

        // GET: GioHang/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gIOHANG = db.GioHang.Find(id);
            if (gIOHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH", gIOHANG.MaKH);
            ViewBag.MaSP = new SelectList(db.SanPham, "MaSP", "TenSP", gIOHANG.MaSP);
            return View(gIOHANG);
        }

        // POST: GioHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,MaSP,Soluong")] GioHang gIOHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gIOHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH", gIOHANG.MaKH);
            ViewBag.MaSP = new SelectList(db.SanPham, "MaSP", "TenSP", gIOHANG.MaSP);
            return View(gIOHANG);
        }

        // GET: GioHang/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gIOHANG = db.GioHang.Find(id);
            if (gIOHANG == null)
            {
                return HttpNotFound();
            }
            return View(gIOHANG);
        }

        // POST: GioHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GioHang gIOHANG = db.GioHang.Find(id);
            db.GioHang.Remove(gIOHANG);
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
