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
        // GET: GIOHANGs
        public ActionResult Index()
        {
            var gIOHANGs = db.GIOHANGs.Include(g => g.KHACHHANG).Include(g => g.SANPHAM);
            return View(gIOHANGs.ToList());
        }

        public ActionResult Giohang()
        {
            List<XemGioHang> GiohangView = (from e in db.GIOHANGs
                                            join d in db.SANPHAMs
                                            on e.MaSP equals d.MaSP
                                            where e.MaKH == "KH001"
                                            select new XemGioHang { TenSP = d.TenSP, HinhAnh = d.Anh, GiaBan = d.GiaBan, Soluong = e.Soluong }).ToList();

            return View(GiohangView);
        }
        public ActionResult DatHang()
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gIOHANG = db.GIOHANGs.Find(id);
            if (gIOHANG == null)
            {
                return HttpNotFound();
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

        // GET: GIOHANGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gIOHANG = db.GIOHANGs.Find(id);
            if (gIOHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "TenKH", gIOHANG.MaKH);
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP", gIOHANG.MaSP);
            return View(gIOHANG);
        }

        // POST: GIOHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,MaSP,Soluong")] GioHang gIOHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gIOHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KHACHHANGs, "MaKH", "TenKH", gIOHANG.MaKH);
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP", gIOHANG.MaSP);
            return View(gIOHANG);
        }

        // GET: GIOHANGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gIOHANG = db.GIOHANGs.Find(id);
            if (gIOHANG == null)
            {
                return HttpNotFound();
            }
            return View(gIOHANG);
        }

        // POST: GIOHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GioHang gIOHANG = db.GIOHANGs.Find(id);
            db.GIOHANGs.Remove(gIOHANG);
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