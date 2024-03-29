﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TraSuaLamss.Models;
using PagedList;
using System.Data.OleDb;
using System.Data.Entity.Validation;

namespace TraSuaLamss.Controllers
{
    public class NhanVienController : Controller
    {
        private TraSuaContext db = new TraSuaContext();

        // GET: NhanVien
        public ActionResult Index()
        {
            var NhanVien = db.NhanVien.Include(n => n.TAIKHOAN);
            return View(NhanVien.ToList());
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
