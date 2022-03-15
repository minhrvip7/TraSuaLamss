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
    public class GioHangController : Controller
    {
        private TraSuaContext db = new TraSuaContext();
        private const string MaKHSession = "MaKHSession";
        private const string ListHangSession = "ListHangSession";
        public ActionResult Giohang()
        {
            int KHID = 1;
            List<XemGioHang> list = (from e in db.GioHang
                                     join d in db.SanPham
                                     on e.MaSP equals d.MaSP
                                     where e.MaKH == KHID
                                     select new XemGioHang { GH = e, SP = d }).ToList();
            ViewBag.MaKH = KHID;
            Session[ListHangSession] = list;
            return View(list);
        }
        public ActionResult DatHang()
        {
            var list = Session[ListHangSession] as List<XemGioHang>;
            int KHID = 1;
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
                    DonGia = item.SP.GiaBan
                };
                SanPham sanPham = (from e in db.SanPham
                                   where e.MaSP == item.SP.MaSP
                                   select e).FirstOrDefault();
                var Phieu = new PhieuDatHang { CTDH = ChitietDH, SP = sanPham };
                lischitiet.Add(Phieu);
            }
            var NgayDat = DateTime.Today;
            ViewBag.DonHang = new DonHang()
            {
                MaDH = MaDH,
                ThanhTien = lischitiet.Sum(x => x.CTDH.SoLuong * x.CTDH.DonGia),
                PhuongThucThanhToan = "",
                DiaChiGiaoHang = "",
                TinhTrangGiaoHang = "",
                NgayDat = NgayDat,
                MaKH = KHID,
                GhiChu = ""
            };
            ViewBag.NgayDat = NgayDat.ToString("dd/MM/yyyy");
            ViewBag.TenKH = (from e in db.KhachHang
                             where e.MaKH == KHID
                             select e.TenKH).FirstOrDefault();
            ViewBag.List = lischitiet as List<PhieuDatHang>;
            return View(lischitiet);
        }

        public ActionResult Add(int MaKhach, string MaHang, int soluong)
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
        public ActionResult Delete(int MaKhach, string MaHang)
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
        public ActionResult DeleteAll(int MaKhach)
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
        public ActionResult DatHangLe(int MaKH, string MaHang, int soluong)
        {
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
            var chitietdonhang = new ChiTietDonHang()
            {
                MaHD = MaDH,
                MaKH = MaKH,
                MaSP = MaHang,
                SoLuong = soluong,
                DonGia = (from e in db.SanPham where e.MaSP == MaHang select e.GiaBan).FirstOrDefault(),
            };
            var sanpham = (from d in db.SanPham
                           where d.MaSP == MaHang
                           select d).FirstOrDefault();
            var chitiet = new PhieuDatHang()
            {
                CTDH = chitietdonhang,
                SP = sanpham,
            };
            var NgayDat = DateTime.Today;
            ViewBag.DonHang = new DonHang()
            {
                MaDH = MaDH,
                ThanhTien = chitiet.SP.GiaBan * chitiet.CTDH.SoLuong,
                PhuongThucThanhToan = "",
                DiaChiGiaoHang = "",
                TinhTrangGiaoHang = "",
                NgayDat = NgayDat,
                MaKH = MaKH,
                GhiChu = ""
            };
            ViewBag.NgayDat = NgayDat.ToString("dd/MM/yyyy");
            ViewBag.TenKH = (from e in db.KhachHang
                             where e.MaKH == MaKH
                             select e.TenKH).FirstOrDefault();
            ViewBag.Phieu = chitiet as PhieuDatHang;
            return View(chitiet);
        }
    }
}