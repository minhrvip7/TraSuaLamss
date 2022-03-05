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
        private const string MaKHSession = "MaKHSession";
        private const string ListHangSession = "ListHangSession";
        public ActionResult Giohang()
        {
            string KHID = "KH001";
            List<XemGioHang> list = (from e in db.GioHang
                                      join d in db.SanPham
                                      on e.MaSP equals d.MaSP
                                      where e.MaKH == KHID
                                      select new XemGioHang { GH = e, SP = d }).ToList();
            ViewBag.MaKH = KHID;
            Session[ListHangSession] = list;
            return View(list);
        }
        public ActionResult Dathang()
        {
            var list = Session[ListHangSession] as List<XemGioHang>;
            string KHID = "KH001";
            string MaDH = "DH";
            int SLDH = db.DonHang.Count() + 1;
            if (SLDH < 1000 && SLDH > 99)
            {
                MaDH = MaDH + SLDH.ToString();
            }
            else if (SLDH < 100 && SLDH > 9)
            {
                MaDH = MaDH + "0" + SLDH.ToString();
            }
            else
            {
                MaDH = MaDH + "00" + SLDH.ToString();
            }
            var lischitiet = new List<PhieuDatHang>();
            foreach (var item in list)
            {
                ChiTietDonHang ChitietDH = new ChiTietDonHang
                {
                    MaKH = KHID,
                    MaHD = MaDH,
                    MaSP = item.SP.MaSP,
                    SoLuong = item.GH.Soluong,
                    DonGia = Convert.ToInt32(item.SP.GiaBan)
                };
                SanPham sanPham=(from e in db.SanPham
                                 where e.MaSP==item.SP.MaSP
                                 select e).FirstOrDefault();
                var Phieu = new PhieuDatHang { CTDH = ChitietDH, SP = sanPham };
                lischitiet.Add(Phieu);
            }
            ViewBag.TongTien = lischitiet.Sum(x => x.CTDH.SoLuong * x.CTDH.DonGia);
            ViewBag.MaDH = MaDH;
            ViewBag.TenKH = (from e in db.KhachHang
                                where e.MaKH == KHID
                                select e.TenKH).FirstOrDefault();
            ViewBag.DiaChi = (from e in db.KhachHang
                             where e.MaKH == KHID
                             select e.DiaChi).FirstOrDefault();
            ViewBag.NgayDat = DateTime.Today.ToString("dd/MM/yyyy");
            return View(lischitiet);
        }

        public ActionResult Add(string MaKhach, string MaHang, int soluong)
        {
            GioHang gioHang = (from e in db.GioHang
                               where e.MaKH == MaKhach && e.MaSP == MaHang
                               select e).FirstOrDefault();
            if (gioHang == null)
            {
                gioHang = new GioHang();
                gioHang.MaKH = MaKhach;
                gioHang.MaSP = MaHang;
                gioHang.Soluong = soluong;
                db.GioHang.Add(gioHang);
            }
            else
            {
                gioHang.Soluong += soluong;
            }
            db.SaveChanges();
            return RedirectToAction("Giohang");
        }
        public ActionResult Delete(string MaKhach, string MaHang)
        {
            GioHang gioHang = (from e in db.GioHang
                               where (e.MaKH == MaKhach && e.MaSP == MaHang)
                               select e).FirstOrDefault();
            if (gioHang != null)
            {
                db.GioHang.Remove(gioHang);
            }
            db.SaveChanges();
            return RedirectToAction("Giohang");
        }
        public ActionResult DeleteAll(string MaKhach)
        {
            foreach (var item in db.GioHang)
            {
                if (item.MaKH == MaKhach)
                {
                    db.GioHang.Remove(item);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Giohang");
        }
    }
}
