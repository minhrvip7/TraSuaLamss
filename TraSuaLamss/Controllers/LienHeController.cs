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
    public class LienHeController : Controller
    {
        private TraSuaContext db = new TraSuaContext();

        // GET: LienHe
        public ActionResult Index()
        {
            return View(db.LienHe.ToList());
        }

        // GET: LienHe/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LienHe lIENHE = db.LienHe.Find(id);
            if (lIENHE == null)
            {
                return HttpNotFound();
            }
            return View(lIENHE);
        }

        // GET: LienHe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LienHe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLH,TenLH,DiaChiLH,SDT")] LienHe lIENHE)
        {
            if (ModelState.IsValid)
            {
                db.LienHe.Add(lIENHE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lIENHE);
        }

        // GET: LienHe/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LienHe lIENHE = db.LienHe.Find(id);
            if (lIENHE == null)
            {
                return HttpNotFound();
            }
            return View(lIENHE);
        }

        // POST: LienHe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLH,TenLH,DiaChiLH,SDT")] LienHe lIENHE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lIENHE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lIENHE);
        }

        // GET: LienHe/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LienHe lIENHE = db.LienHe.Find(id);
            if (lIENHE == null)
            {
                return HttpNotFound();
            }
            return View(lIENHE);
        }

        // POST: LienHe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LienHe lIENHE = db.LienHe.Find(id);
            db.LienHe.Remove(lIENHE);
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
