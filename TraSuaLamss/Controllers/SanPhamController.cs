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
        // GET: SANPHAMs
        public ActionResult Index()
        {
            var SanPham = db.SanPham.Include(s => s.NGUYENLIEU).Include(s => s.PHANLOAI);
            return View(SanPham.ToList());
        }

            
                var sANPHAMs = db.SanPham.Include(s => s.NGUYENLIEU).Include(s => s.PHANLOAI);
                return View(sANPHAMs.ToList());

        }
        // GET: SanPhams/Details/5
=========
        [HttpPost]
            var lstResult = db.SanPham.SqlQuery("Select * from SanPham where TenSP like '%" + searchkey + "%'").ToList();
            var lstResult = db.SanPham.SqlQuery("Select * from SANPHAM where TenSP like '%" + searchkey + "%'").ToList();
        {
            var lstResult = db.SANPHAMs.SqlQuery("Select * from SANPHAM where TenSP like '%" + searchkey + "%'").ToList();
            return View(lstResult);
        // GET: SanPham/Details/5
        // GET: SANPHAMs/Details/5

        // GET: SANPHAMs/Details/5
>>>>>>>>> Temporary merge branch 2
        public ActionResult Details(string id)
        {
            if (id == null)
            SanPham sANPHAM = db.SanPham.Find(id);
            if (sANPHAM == null)
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            return View(SanPham);
            return View(sANPHAM);
                return HttpNotFound();
        {
        // GET: SANPHAMs/Create
        }

        // GET: SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaNL = new SelectList(db.NguyenLieu, "MaNL", "TenNL");
            ViewBag.MaLoai = new SelectList(db.PhanLoai, "MaLoai", "TenLoai");
        // POST: SANPHAMs/Create
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        public ActionResult Create([Bind(Include = "MaSP,TenSP,GiaBan,MoTa,Anh,MaNL,MaLoai")] SanPham sANPHAM)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,GiaBan,MoTa,Anh,MaNL,MaLoai")] SanPham sanPham)
                db.SanPham.Add(sANPHAM);
            if (ModelState.IsValid)
            {
                db.SanPham.Add(sanPham);
                db.SaveChanges();
            ViewBag.MaNL = new SelectList(db.NguyenLieu, "MaNL", "TenNL", sANPHAM.MaNL);
            ViewBag.MaLoai = new SelectList(db.PhanLoai, "MaLoai", "TenLoai", sANPHAM.MaLoai);
            return View(sANPHAM);
            ViewBag.MaNL = new SelectList(db.NguyenLieu, "MaNL", "TenNL", sanPham.MaNL);
            ViewBag.MaLoai = new SelectList(db.PhanLoai, "MaLoai", "TenLoai", sanPham.MaLoai);
        // GET: SANPHAMs/Edit/5
        }

        // GET: SanPhams/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            SanPham sANPHAM = db.SanPham.Find(id);
            if (sANPHAM == null)
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            ViewBag.MaNL = new SelectList(db.NguyenLieu, "MaNL", "TenNL", sANPHAM.MaNL);
            ViewBag.MaLoai = new SelectList(db.PhanLoai, "MaLoai", "TenLoai", sANPHAM.MaLoai);
            return View(sANPHAM);
            ViewBag.MaNL = new SelectList(db.NguyenLieu, "MaNL", "TenNL", sanPham.MaNL);
            ViewBag.MaLoai = new SelectList(db.PhanLoai, "MaLoai", "TenLoai", sanPham.MaLoai);
        // POST: SANPHAMs/Edit/5
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,GiaBan,MoTa,Anh,MaNL,MaLoai")] SanPham sANPHAM)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,GiaBan,MoTa,Anh,MaNL,MaLoai")] SanPham sanPham)
                db.Entry(sANPHAM).State = EntityState.Modified;
                }

                db.Entry(sanPham).State = EntityState.Modified;
            ViewBag.MaNL = new SelectList(db.NguyenLieu, "MaNL", "TenNL", sANPHAM.MaNL);
            ViewBag.MaLoai = new SelectList(db.PhanLoai, "MaLoai", "TenLoai", sANPHAM.MaLoai);
            return View(sANPHAM);
            ViewBag.MaNL = new SelectList(db.NguyenLieu, "MaNL", "TenNL", sanPham.MaNL);
            ViewBag.MaLoai = new SelectList(db.PhanLoai, "MaLoai", "TenLoai", sanPham.MaLoai);
        // GET: SANPHAMs/Delete/5
        }

        // GET: SanPhams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            SanPham sANPHAM = db.SanPham.Find(id);
            if (sANPHAM == null)
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            return View(sANPHAM);
                return HttpNotFound();
            }
        // POST: SANPHAMs/Delete/5
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
            SanPham sANPHAM = db.SanPham.Find(id);
            db.SanPham.Remove(sANPHAM);
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
