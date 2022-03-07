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
    public class TaiKhoanController : Controller
    {
        private TraSuaContext db = new TraSuaContext();

        // GET: TAIKHOANs
        public ActionResult Index()
        {
            return View(db.TAIKHOANs.ToList());
        }

        // GET: TAIKHOANs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
            if (tAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(tAIKHOAN);
        }

        // GET: TAIKHOANs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TAIKHOANs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,Password,HoTen,PhanQuyen")] TAIKHOAN tAIKHOAN)
        {
            if (ModelState.IsValid)
            {
                db.TAIKHOANs.Add(tAIKHOAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tAIKHOAN);
        }

        // GET: TAIKHOANs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
            if (tAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(tAIKHOAN);
        }

        // POST: TAIKHOANs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username,Password,HoTen,PhanQuyen")] TAIKHOAN tAIKHOAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAIKHOAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tAIKHOAN);
        }

        // GET: TAIKHOANs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
            if (tAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(tAIKHOAN);
        }

        // POST: TAIKHOANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
            db.TAIKHOANs.Remove(tAIKHOAN);
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
