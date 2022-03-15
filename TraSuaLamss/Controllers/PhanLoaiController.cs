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
    public class PhanLoaiController : Controller
    {
        private TraSuaContext db = new TraSuaContext();

        // GET: PHANLOAIs
        public ActionResult Index()
        {
            return View(db.PHANLOAI.ToList());
        }

        // GET: PHANLOAIs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanLoai pHANLOAI = db.PHANLOAIs.Find(id);
            if (pHANLOAI == null)
            {
                return HttpNotFound();
            }
            return View(pHANLOAI);
        }

        // GET: PHANLOAIs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PHANLOAIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoai,TenLoai")] PhanLoai pHANLOAI)
        {
            if (ModelState.IsValid)
            {
                db.PHANLOAI.Add(pHANLOAI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pHANLOAI);
        }

        // GET: PHANLOAIs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanLoai pHANLOAI = db.PHANLOAIs.Find(id);
            if (pHANLOAI == null)
            {
                return HttpNotFound();
            }
            return View(pHANLOAI);
        }

        // POST: PHANLOAIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoai,TenLoai")] PhanLoai pHANLOAI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHANLOAI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pHANLOAI);
        }

        // GET: PHANLOAIs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanLoai pHANLOAI = db.PHANLOAIs.Find(id);
            if (pHANLOAI == null)
            {
                return HttpNotFound();
            }
            return View(pHANLOAI);
        }

        // POST: PHANLOAIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhanLoai pHANLOAI = db.PHANLOAIs.Find(id);
            db.PHANLOAIs.Remove(pHANLOAI);
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
