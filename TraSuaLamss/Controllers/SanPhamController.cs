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

        // GET: SanPham
        public ActionResult Index()
        {
            var SanPham = db.SanPham.Include(s => s.NGUYENLIEU).Include(s => s.PHANLOAI);
            return View(SanPham.ToList());
        }

        [HttpPost]
        public ActionResult Search(string searchkey)
        {
            var lstResult = db.SanPham.SqlQuery("Select * from SanPham where TenSP like '%" + searchkey + "%'").ToList();
            return View(lstResult);
        }

        // GET: SanPham/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham SanPham = db.SanPham.Find(id);
            if (SanPham == null)
            {
                return HttpNotFound();
            }
            return View(SanPham);
        }
        public List<SanPham> SearhByKey(string key)
        {
            return db.SanPham.SqlQuery("Select * from SanPham where TenSP like '%"+key+"%'").ToList();
        }

        // GET: SanPham/Create
        public ActionResult Create()
        {
            ViewBag.MaNL = new SelectList(db.NguyenLieu, "MaNL", "TenNL");
            ViewBag.MaLoai = new SelectList(db.PhanLoai, "MaLoai", "TenLoai");
            return View();
        }

        // POST: SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,GiaBan,MoTa,Anh,MaNL,MaLoai")] SanPham SanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPham.Add(SanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNL = new SelectList(db.NguyenLieu, "MaNL", "TenNL", SanPham.MaNL);
            ViewBag.MaLoai = new SelectList(db.PhanLoai, "MaLoai", "TenLoai", SanPham.MaLoai);
            return View(SanPham);
        }

        // GET: SanPham/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham SanPham = db.SanPham.Find(id);
            if (SanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNL = new SelectList(db.NguyenLieu, "MaNL", "TenNL", SanPham.MaNL);
            ViewBag.MaLoai = new SelectList(db.PhanLoai, "MaLoai", "TenLoai", SanPham.MaLoai);
            return View(SanPham);
        }

        // POST: SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,GiaBan,MoTa,Anh,MaNL,MaLoai")] SanPham SanPham)
        {
            if (ModelState.IsValid)
            {
                SanPham.Anh = "";
                var f = Request.Files["ImageFile"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/wwwroot/Images/" + FileName);
                    f.SaveAs(UploadPath);
                    SanPham.Anh = FileName;
                }

                db.Entry(SanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNL = new SelectList(db.NguyenLieu, "MaNL", "TenNL", SanPham.MaNL);
            ViewBag.MaLoai = new SelectList(db.PhanLoai, "MaLoai", "TenLoai", SanPham.MaLoai);
            return View(SanPham);
        }

        // GET: SanPham/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham SanPham = db.SanPham.Find(id);
            if (SanPham == null)
            {
                return HttpNotFound();
            }
            return View(SanPham);
        }

        // POST: SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham SanPham = db.SanPham.Find(id);
            db.SanPham.Remove(SanPham);
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
