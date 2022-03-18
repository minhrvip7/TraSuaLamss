using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TraSuaLamss.Models;
using System.IO;
using PagedList;

namespace TraSuaLamss.Controllers
{
    public class SanPhamController : Controller
    {
        private TraSuaContext db = new TraSuaContext();

        // GET: SanPhams
        public ActionResult Index(int? page,string sortOrder)
        {
            ViewBag.TheoLoai = string.IsNullOrEmpty(sortOrder) ? "ten_desc" : "";
            ViewBag.TheoGia = sortOrder == "gia" ? "gia_desc" : "gia";
            var sanPham = db.SanPham.Include(s => s.NGUYENLIEU).Include(s => s.PHANLOAI).OrderByDescending(s => s.MaSP);
            switch (sortOrder)
            {
                case "ten_desc":
                    sanPham =sanPham.OrderByDescending(s => s.MaLoai);
                    break;
                case "gia":
                    sanPham = sanPham.OrderBy(s => s.GiaBan);
                    break;
                case "gia_desc":
                    sanPham = sanPham.OrderByDescending(s => s.GiaBan);
                    break;
                default:
                    sanPham = sanPham.OrderBy(s => s.MaSP);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(sanPham.ToPagedList(pageNumber,pageSize));
        }

        // GET: SanPhams/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaNL = new SelectList(db.NguyenLieu, "MaNL", "TenNL");
            ViewBag.MaLoai = new SelectList(db.PhanLoai, "MaLoai", "TenLoai");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,GiaBan,MoTa,Anh,MaNL,MaLoai")] SanPham sanPham)
        {
            ViewBag.MaNL = new SelectList(db.NguyenLieu, "MaNL", "TenNL", sanPham.MaNL);
            ViewBag.MaLoai = new SelectList(db.PhanLoai, "MaLoai", "TenLoai", sanPham.MaLoai);
            try
            {
                if (ModelState.IsValid)
                {
                    sanPham.Anh = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/wwwroot/Images/" + FileName);
                        f.SaveAs(UploadPath);
                        sanPham.Anh = FileName;
                    }
                    db.SanPham.Add(sanPham);
                    db.SaveChanges();
                    
                }return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu";
                return View(sanPham);
            }
             
        }

        // GET: SanPhams/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNL = new SelectList(db.NguyenLieu, "MaNL", "TenNL", sanPham.MaNL);
            ViewBag.MaLoai = new SelectList(db.PhanLoai, "MaLoai", "TenLoai", sanPham.MaLoai);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,GiaBan,MoTa,Anh,MaNL,MaLoai")] SanPham sanPham)
        {
            ViewBag.MaNL = new SelectList(db.NguyenLieu, "MaNL", "TenNL", sanPham.MaNL);
            ViewBag.MaLoai = new SelectList(db.PhanLoai, "MaLoai", "TenLoai", sanPham.MaLoai);
            try
            {
                if (ModelState.IsValid)
                {
                    sanPham.Anh = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/wwwroot/Images/" + FileName);
                        f.SaveAs(UploadPath);
                        sanPham.Anh = FileName;
                    }

                    db.Entry(sanPham).State = EntityState.Modified;
                    db.SaveChanges();
                    
                }return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu";
                return View(sanPham);
            }
                    }

        // GET: SanPhams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham sanPham = db.SanPham.Find(id);
            db.SanPham.Remove(sanPham);
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
