﻿using System;
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
    public class NguyenLieuController : Controller
    {
        private TraSuaContext db = new TraSuaContext();

        // GET: NguyenLieu
        public ActionResult Index()
        {
            var NguyenLieu = db.NguyenLieu.Include(n => n.NHACUNGCAP);
            return View(NguyenLieu.ToList());
        }

        // GET: NguyenLieu/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguyenLieu nGUYENLIEU = db.NguyenLieu.Find(id);
            if (nGUYENLIEU == null)
            {
                return HttpNotFound();
            }
            return View(nGUYENLIEU);
        }

        // GET: NguyenLieu/Create
        public ActionResult Create()
        {
            ViewBag.MaNCC = new SelectList(db.NhaCungCap, "MaNCC", "TenNCC");
            return View();
        }

        // POST: NguyenLieu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNL,TenNL,MaNCC")] NguyenLieu nGUYENLIEU)
        {
            if (ModelState.IsValid)
            {
                db.NguyenLieu.Add(nGUYENLIEU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNCC = new SelectList(db.NhaCungCap, "MaNCC", "TenNCC", nGUYENLIEU.MaNCC);
            return View(nGUYENLIEU);
        }

        // GET: NguyenLieu/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguyenLieu nGUYENLIEU = db.NguyenLieu.Find(id);
            if (nGUYENLIEU == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCap, "MaNCC", "TenNCC", nGUYENLIEU.MaNCC);
            return View(nGUYENLIEU);
        }

        // POST: NguyenLieu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNL,TenNL,MaNCC")] NguyenLieu nGUYENLIEU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nGUYENLIEU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCap, "MaNCC", "TenNCC", nGUYENLIEU.MaNCC);
            return View(nGUYENLIEU);
        }

        // GET: NguyenLieu/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguyenLieu nGUYENLIEU = db.NguyenLieu.Find(id);
            if (nGUYENLIEU == null)
            {
                return HttpNotFound();
            }
            return View(nGUYENLIEU);
        }

        // POST: NguyenLieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NguyenLieu nGUYENLIEU = db.NguyenLieu.Find(id);
            db.NguyenLieu.Remove(nGUYENLIEU);
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
