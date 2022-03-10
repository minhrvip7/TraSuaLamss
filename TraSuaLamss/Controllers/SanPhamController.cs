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
    public class SanPhamController : Controller
    {
        private TraSuaContext db = new TraSuaContext();

        // GET: SANPHAMs
        public ActionResult Index()
        {
            var sANPHAMs = db.SanPham.Include(s => s.NGUYENLIEU).Include(s => s.PHANLOAI);
            return View(sANPHAMs.ToList());
        }

        [HttpPost]
        public ActionResult Search(string searchkey)
        {
            var lstResult = db.SANPHAMs.SqlQuery("Select * from SANPHAM where TenSP like '%" + searchkey + "%'").ToList();
            return View(lstResult);
        }

        // GET: SANPHAMs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sANPHAM = db.SanPham.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }
        public List<SANPHAM> SearhByKey(string key)
        {
            return db.SANPHAMs.SqlQuery("Select * from SANPHAM where TenSP like '%"+key+"%'").ToList();
        }

        // GET: SANPHAMs/Create
        public ActionResult Create()
        {
            ViewBag.MaNL = new SelectList(db.NGUYENLIEUx, "MaNL", "TenNL");
            ViewBag.MaLoai = new SelectList(db.PHANLOAIs, "MaLoai", "TenLoai");
            return View();
        }

        // POST: SANPHAMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,GiaBan,MoTa,Anh,MaNL,MaLoai")] SanPham sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.SanPham.Add(sANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNL = new SelectList(db.NGUYENLIEUx, "MaNL", "TenNL", sANPHAM.MaNL);
            ViewBag.MaLoai = new SelectList(db.PHANLOAIs, "MaLoai", "TenLoai", sANPHAM.MaLoai);
            return View(sANPHAM);
        }

        // GET: SANPHAMs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sANPHAM = db.SanPham.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNL = new SelectList(db.NGUYENLIEUx, "MaNL", "TenNL", sANPHAM.MaNL);
            ViewBag.MaLoai = new SelectList(db.PHANLOAIs, "MaLoai", "TenLoai", sANPHAM.MaLoai);
            return View(sANPHAM);
        }

        // POST: SANPHAMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,GiaBan,MoTa,Anh,MaNL,MaLoai")] SanPham sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNL = new SelectList(db.NGUYENLIEUx, "MaNL", "TenNL", sANPHAM.MaNL);
            ViewBag.MaLoai = new SelectList(db.PHANLOAIs, "MaLoai", "TenLoai", sANPHAM.MaLoai);
            return View(sANPHAM);
        }

        // GET: SANPHAMs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sANPHAM = db.SanPham.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // POST: SANPHAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham sANPHAM = db.SanPham.Find(id);
            db.SanPham.Remove(sANPHAM);
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
