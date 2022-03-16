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
    public class KhachHangController : Controller
    {
        private TraSuaContext db = new TraSuaContext();

        // GET: KhachHang
        public ActionResult Index()
        {
            var kHACHHANGs = db.KhachHang.Include(k => k.TAIKHOAN);
            return View(kHACHHANGs.ToList());
        }

        // GET: KhachHang/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang kHACHHANG = db.KhachHang.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // GET: KhachHang/Create
        public ActionResult Create()
        {
            ViewBag.Username = new SelectList(db.TaiKhoan, "Username", "Password");
            return View();
        }

        // POST: KhachHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,TenKH,GioiTinh,NgaySinh,Username,Email,DiaChi,DienThoai")] KhachHang kHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.KhachHang.Add(kHACHHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Username = new SelectList(db.TaiKhoan, "Username", "Password", kHACHHANG.Username);
            return View(kHACHHANG);
        }

        // GET: KhachHang/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang kHACHHANG = db.KhachHang.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.Username = new SelectList(db.TaiKhoan, "Username", "Password", kHACHHANG.Username);
            return View(kHACHHANG);
        }

        // POST: KhachHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,TenKH,GioiTinh,NgaySinh,Username,Email,DiaChi,DienThoai")] KhachHang kHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHACHHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Username = new SelectList(db.TaiKhoan, "Username", "Password", kHACHHANG.Username);
            return View(kHACHHANG);
        }

        // GET: KhachHang/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang kHACHHANG = db.KhachHang.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // POST: KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KhachHang kHACHHANG = db.KhachHang.Find(id);
            db.KhachHang.Remove(kHACHHANG);
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
