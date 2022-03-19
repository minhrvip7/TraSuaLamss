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
    public class NhanVienController : Controller
    {
        private TraSuaContext db = new TraSuaContext();

        // GET: NhanVien
        public ActionResult Index(string searchStr, int? page)
        {
            var nHANVIENs = db.NhanVien.Include(n => n.TAIKHOAN);

            if(searchStr == null)
            {
                nHANVIENs = nHANVIENs;
            }
            else if(searchStr.Any(char.IsDigit))
            {
                nHANVIENs = nHANVIENs.Where(e => e.MaNV.Contains(searchStr));
            }
            else if (!String.IsNullOrEmpty(searchStr))
            {
                nHANVIENs = nHANVIENs.Where(e => e.TenNV.Contains(searchStr));
            }
            //Sắp xếp trước khi phân trang
            NhanVien = NhanVien.OrderBy(e => e.MaNV);
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(NhanVien.ToPagedList(pageNumber, pageSize));
        }

        // GET: NhanVien/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nHANVIEN = db.NhanVien.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // GET: NhanVien/Create
        public ActionResult Create()
        {
            ViewBag.Username = new SelectList(db.TaiKhoan, "Username", "Password");
            return View();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,TenNV,GioiTinh,NgaySinh,Username,Email,DiaChi,DienThoai,STK,Luong")] NhanVien nHANVIEN)
        {
            
            if (ModelState.IsValid)
            {
                var taiKhoan = new TaiKhoan() {
                    Username = nHANVIEN.Username,
                    Password = "1",
                    HoTen = nHANVIEN.TenNV,
                    PhanQuyen = "Nhân viên"
                };
                db.TaiKhoan.Add(taiKhoan);
                db.SaveChanges();
                db.NhanVien.Add(nHANVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Username = new SelectList(db.TaiKhoan, "Username", "Password", nHANVIEN.Username);
            return View(nHANVIEN);
        }

        // GET: NhanVien/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nHANVIEN = db.NhanVien.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.Username = new SelectList(db.TaiKhoan, "Username", "Password", nHANVIEN.Username);
            return View(nHANVIEN);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,TenNV,GioiTinh,NgaySinh,Username,Email,DiaChi,DienThoai,STK,Luong")] NhanVien nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHANVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Username = new SelectList(db.TaiKhoan, "Username", "Password", nHANVIEN.Username);
            return View(nHANVIEN);
        }

        // GET: NhanVien/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nHANVIEN = db.NhanVien.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanVien nHANVIEN = db.NhanVien.Find(id);
            db.NhanVien.Remove(nHANVIEN);
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
