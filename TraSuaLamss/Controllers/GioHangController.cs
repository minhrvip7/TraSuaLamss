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
    public class GioHangController : Controller
    {
        private TraSuaContext db = new TraSuaContext();
        public ActionResult Giohang(string KHID)
        {
            var list = (from e in db.GioHang
                        join d in db.SanPham
                        on e.MaSP equals d.MaSP
                        where e.MaKH == KHID
                        select new XemGioHang { GH = e, SP = d }).ToList();
            return View(list);
        }
        public ActionResult Dathang()
        {
            return View();
        }

        public ActionResult Add(string KHID, string HangID, int soluong)
        {
            
            var list = (from e in db.GioHang
                        join d in db.SanPham
                        on e.MaSP equals d.MaSP
                        where e.MaKH == KHID
                        select new XemGioHang { GH = e, SP = d }).ToList();
            if (list.Exists(e => e.SP.MaSP == HangID))
            {
                foreach (var item in list)
                {
                    if (item.SP.MaSP == HangID)
                    {
                        item.GH.Soluong += soluong;
                    }
                }
            }
            else
            {
                var hang = (from e in db.GioHang
                            join d in db.SanPham
                            on e.MaSP equals d.MaSP
                            select new XemGioHang { GH = e, SP = d }).FirstOrDefault();
                list.Add(hang);
                db.GioHang.Add(hang.GH);
            }
            return View();
        }
    }
}
