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

        // GET: DonHang
        public ActionResult Index()
        {
            var dONHANGs = db.DonHang.Include(d => d.KHACHHANG);
            return View(dONHANGs.ToList());
        }


        // GET: DonHang/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang dONHANG = db.DonHang.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONHANG);
        }

        // GET: DonHang/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH");
            return View();
        }

        // POST: DonHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDH,ThanhTien,PhuongThucThanhToan,ThanhToan,DiaChiGiaoHang,TinhTrangGiaoHang,NgayDat,NgayGiao,MaKH,GhiChu")] DonHang dONHANG)
        {
            if (ModelState.IsValid)
            {
                db.DonHang.Add(dONHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH", dONHANG.MaKH);
            return View(dONHANG);
        }

        // GET: DonHang/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang dONHANG = db.DonHang.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH", dONHANG.MaKH);
            return View(dONHANG);
        }

        // POST: DonHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDH,ThanhTien,PhuongThucThanhToan,ThanhToan,DiaChiGiaoHang,TinhTrangGiaoHang,NgayDat,NgayGiao,MaKH,GhiChu")] DonHang dONHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dONHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH", dONHANG.MaKH);
            return View(dONHANG);
        }

        // GET: DonHang/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang dONHANG = db.DonHang.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONHANG);
        }

        // POST: DonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DonHang dONHANG = db.DonHang.Find(id);
            db.DonHang.Remove(dONHANG);
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
