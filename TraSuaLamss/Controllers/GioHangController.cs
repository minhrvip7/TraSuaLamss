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
        private const string HangSession = "HangSession";
        private const string KHSession = "KHSession";
        public ActionResult Giohang()
        {
            var hang = Session[HangSession];
            var list = new List<XemGioHang>();
            if (hang != null)
            {
                list=(List<XemGioHang>)hang;
            }
            return View(list);
        }
        public ActionResult Dathang()
        {
            return View();
        }

        public ActionResult Add(string HangID, int soluong)
        {
            var hang = Session[HangSession];
            if (hang == null)
            {
                var list = (List<XemGioHang>)hang;
                if (list.Exists(x => x.SP.MaSP == HangID))
                {
                    foreach (var item in list)
                    {
                        if (item.SP.MaSP==HangID)
                        {
                            item.Soluong += soluong;
                        }
                    }
                }
                else
                {
                    var item = new XemGioHang();
                    item.SP.MaSP = HangID;
                    item.Soluong = soluong;
                    list.Add(item);
                }
            }
            else
            {
                var item = new XemGioHang();
                item.SP.MaSP = HangID;
                item.Soluong = soluong;
                var list = new List<XemGioHang>();
                list.Add(item);
                Session[HangSession] = list;
            }
            return RedirectToAction("Giohang");
        }
    }
}
