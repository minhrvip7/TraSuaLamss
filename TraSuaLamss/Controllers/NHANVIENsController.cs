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
    public class NHANVIENsController : Controller
    {
        private TraSuaContext db = new TraSuaContext();

        // GET: NHANVIENs
        public ActionResult Index()
        {
            var nHANVIENs = db.NHANVIEN.Include(n => n.TAIKHOAN);
            return View(nHANVIENs.ToList());
        }

        // GET: NHANVIENs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nHANVIEN = db.NHANVIEN.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Create
        public ActionResult Create()
        {
            ViewBag.Username = new SelectList(db.TAIKHOAN, "Username", "Password");
            return View();
        }

        // POST: NHANVIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,TenNV,GioiTinh,NgaySinh,Username,Email,DiaChi,DienThoai,STK,Luong")] NhanVien nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.NHANVIEN.Add(nHANVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Username = new SelectList(db.TAIKHOAN, "Username", "Password", nHANVIEN.Username);
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nHANVIEN = db.NHANVIEN.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.Username = new SelectList(db.TAIKHOAN, "Username", "Password", nHANVIEN.Username);
            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Edit/5
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
            ViewBag.Username = new SelectList(db.TAIKHOAN, "Username", "Password", nHANVIEN.Username);
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nHANVIEN = db.NHANVIEN.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanVien nHANVIEN = db.NHANVIEN.Find(id);
            db.NHANVIEN.Remove(nHANVIEN);
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
