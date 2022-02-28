﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TraSuaLamss.Models;

namespace TraSuaLamss.Controllers
{
    public class LichSuGiaoDichController : Controller
    {
        private TraSuaContext db = new TraSuaContext();
        // GET: LichSuGiaoDich
        public ActionResult Index()
        {
            //var kHACHHANGs = db.KHACHHANGs.Include(k => k.TAIKHOAN);
            var giaoDich = (from s in db.DONHANGs where s.MaKH == "KH001" select s);
            return View(giaoDich.ToList());
        }

        public ActionResult LichSuGiaoDich()
        {
            //var kHACHHANGs = db.KHACHHANGs.Include(k => k.TAIKHOAN);
            var giaoDich = (from s in db.DONHANGs where s.MaKH == "KH001" select s);
            return View(giaoDich.ToList());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var giaoDich = (from s in db.DONHANGs where s.MaKH == "KH001" select s).Where(x => x.MaDH == id);
            if (giaoDich == null)
            {
                return HttpNotFound();
            }
            return View(giaoDich.ToList());
        }
    }
}