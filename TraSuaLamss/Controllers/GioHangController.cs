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
            var gIOHANGs = db.GIOHANGs.Include(g => g.KHACHHANG).Include(g => g.SANPHAM);
            return View(gIOHANGs.ToList());
        }

        public ActionResult Giohang()
        {
            List<XemGioHang> GiohangView = (from e in db.GIOHANGs
                                            join d in db.SANPHAMs
                                            on e.MaSP equals d.MaSP
                                            where e.MaKH == "KH001"
                                            select new XemGioHang { TenSP = d.TenSP, HinhAnh = d.Anh, GiaBan = d.GiaBan, Soluong = e.Soluong }).ToList();

            return View(GiohangView);
        }

        // GET: GIOHANGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gIOHANG = db.GIOHANGs.Find(id);
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
        public ActionResult Create([Bind(Include = "MaKH,MaSP,Soluong")] GioHang gIOHANG)
        {
            if (ModelState.IsValid)
            {
                db.GIOHANGs.Add(gIOHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "TenKH", gIOHANG.MaKH);
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP", gIOHANG.MaSP);
            return View(gIOHANG);
        }

        // GET: GIOHANGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gIOHANG = db.GIOHANGs.Find(id);
            if (gIOHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "TenKH", gIOHANG.MaKH);
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP", gIOHANG.MaSP);
            return View(gIOHANG);
        }

        // POST: GIOHANGs/Edit/5
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
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "TenKH", gIOHANG.MaKH);
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP", gIOHANG.MaSP);
            return View(gIOHANG);
        }

        // GET: GIOHANGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gIOHANG = db.GIOHANGs.Find(id);
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
            GioHang gIOHANG = db.GIOHANGs.Find(id);
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