using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraSuaLamss.Models;
using PagedList;

namespace TraSuaLamss.Controllers
{
    public class DSSanPhamController : Controller
    {
        private TraSuaContext db = new TraSuaContext();
        private List<SanPham> LaySanPham()
        {
            return db.SanPham.OrderByDescending(s => s.TenSP).ToList();
        }
        // GET: DSSANPHAM
        public ActionResult Index(int? page, string Name, string first, string end, string currentFilter, string currentFilter1, string currentFilter2)
        {
            if (Name != null)
            {
                page = 1;
            }
            else
            {
                Name = currentFilter;
            }
            if (first != null)
            {
                page = 1;
            }
            else
            {
                first = currentFilter1;
            }
            if (end != null)
            {
                page = 1;
            }
            else
            {
                end = currentFilter2;
            }
            ViewBag.currentFilter1 = first;
            ViewBag.currentFilter2 = end;
            ViewBag.currentFilter = Name;
            var sanpham = LaySanPham();
            int pagesize = 8;
            int pageNumber = (page ?? 1);
            ViewBag.Loai = "TẤT CẢ SẢN PHẨM";

            try
            {
                if (!String.IsNullOrEmpty(Name) && String.IsNullOrEmpty(first) && String.IsNullOrEmpty(end))
                {
                    sanpham = sanpham.Where(p => p.TenSP.ToLower().Contains(Name.ToLower())).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && String.IsNullOrEmpty(Name))
                {
                    sanpham = sanpham.Where(p => p.GiaBan >= long.Parse(first) && p.GiaBan <= long.Parse(end)).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && long.Parse(end) < long.Parse(first))
                {
                    ViewBag.Error = "Giá không hợp lệ";
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && !String.IsNullOrEmpty(Name))
                {
                    sanpham = sanpham.Where(p => p.GiaBan >= long.Parse(first) && p.GiaBan <= long.Parse(end) && p.TenSP.ToLower().Contains(Name.ToLower())).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Giá không hợp lệ";

            }

            return View(sanpham.ToPagedList(pageNumber, pagesize));
        }
        public ActionResult Details(string id, string loai)
        {

            var tra = from tr in db.SanPham
                      join l in db.PhanLoai on tr.MaLoai equals l.MaLoai
                      join nl in db.NguyenLieu on tr.MaNL equals nl.MaNL
                      where tr.MaSP == id
                      select new ChiTietSanPham()
                      {
                          MaSP = tr.MaSP,
                          TenSP = tr.TenSP,
                          Anh = tr.Anh,
                          MoTa = tr.MoTa,
                          TenLoai = l.TenLoai,
                          TenNL = nl.TenNL,
                          GiaBan = tr.GiaBan
                      };
            string masp = "";
            string tensp = "";
            string anh = "";
            string mota = "";
            string tenloai = "";
            string tennl = "";
            decimal giaban = 0;
            foreach (var item in tra)
            {
                masp = item.MaSP;
            }
            foreach (var item in tra)
            {
                tensp = item.TenSP;
            }
            foreach (var item in tra)
            {
                anh = item.Anh;
            }
            foreach (var item in tra)
            {
                mota = item.MoTa;
            }
            foreach (var item in tra)
            {
                tenloai = item.TenLoai;
            }
            foreach (var item in tra)
            {
                tennl = item.TenNL;
            }
            foreach (var item in tra)
            {
                giaban = item.GiaBan;
            }
            ViewBag.MaSP = masp;
            ViewBag.MaLoai = loai;
            ViewBag.TenSP = tensp;
            ViewBag.TenLoai = tenloai;
            ViewBag.TenNl = tennl;
            ViewBag.GiaBan = giaban;
            ViewBag.MoTa = mota;
            ViewBag.Anh = anh;
            ViewBag.SL = 1;
            var danhsach = (from ds in db.SanPham
                            where ds.MaSP != id && ds.MaLoai == loai
                            select ds).ToList();
            return View(danhsach);
        }
        public ActionResult TraSua(int? page, string Name, string first, string end, string currentFilter, string currentFilter1, string currentFilter2)
        {
            if (Name != null)
            {
                page = 1;
            }
            else
            {
                Name = currentFilter;
            }
            if (first != null)
            {
                page = 1;
            }
            else
            {
                first = currentFilter1;
            }
            if (end != null)
            {
                page = 1;
            }
            else
            {
                end = currentFilter2;
            }
            ViewBag.currentFilter1 = first;
            ViewBag.currentFilter2 = end;
            ViewBag.currentFilter = Name;
            var sanpham = (from sp in db.SanPham
                           join l in db.PhanLoai on sp.MaLoai equals l.MaLoai
                           where l.TenLoai == "Trà sữa"
                           select sp).ToList();
            int pagesize = 8;
            int pageNumber = (page ?? 1);
            ViewBag.Loai = "TRÀ SỮA";

            try
            {
                if (!String.IsNullOrEmpty(Name) && String.IsNullOrEmpty(first) && String.IsNullOrEmpty(end))
                {
                    sanpham = sanpham.Where(p => p.TenSP.ToLower().Contains(Name.ToLower())).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && String.IsNullOrEmpty(Name))
                {
                    sanpham = sanpham.Where(p => p.GiaBan >= long.Parse(first) && p.GiaBan <= long.Parse(end)).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && long.Parse(end) < long.Parse(first))
                {
                    ViewBag.Error = "Giá không hợp lệ";
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && !String.IsNullOrEmpty(Name))
                {
                    sanpham = sanpham.Where(p => p.GiaBan >= long.Parse(first) && p.GiaBan <= long.Parse(end) && p.TenSP.ToLower().Contains(Name.ToLower())).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Không hợp lệ";

            }
            return View(sanpham.ToPagedList(pageNumber, pagesize));
        }
        public ActionResult Tra(int? page, string Name, string first, string end, string currentFilter, string currentFilter1, string currentFilter2)
        {
            if (Name != null)
            {
                page = 1;
            }
            else
            {
                Name = currentFilter;
            }
            if (first != null)
            {
                page = 1;
            }
            else
            {
                first = currentFilter1;
            }
            if (end != null)
            {
                page = 1;
            }
            else
            {
                end = currentFilter2;
            }
            ViewBag.currentFilter1 = first;
            ViewBag.currentFilter2 = end;
            ViewBag.currentFilter = Name;
            var sanpham = (from sp in db.SanPham
                           join l in db.PhanLoai on sp.MaLoai equals l.MaLoai
                           where l.TenLoai == "Trà"
                           select sp).ToList();
            int pagesize = 8;
            int pageNumber = (page ?? 1);
            ViewBag.Loai = "TRÀ";

            try
            {
                if (!String.IsNullOrEmpty(Name) && String.IsNullOrEmpty(first) && String.IsNullOrEmpty(end))
                {
                    sanpham = sanpham.Where(p => p.TenSP.ToLower().Contains(Name.ToLower())).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && String.IsNullOrEmpty(Name))
                {
                    sanpham = sanpham.Where(p => p.GiaBan >= long.Parse(first) && p.GiaBan <= long.Parse(end)).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && long.Parse(end) < long.Parse(first))
                {
                    ViewBag.Error = "Giá không hợp lệ";
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && !String.IsNullOrEmpty(Name))
                {
                    sanpham = sanpham.Where(p => p.GiaBan >= long.Parse(first) && p.GiaBan <= long.Parse(end) && p.TenSP.ToLower().Contains(Name.ToLower())).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Không hợp lệ";

            }
            return View(sanpham.ToPagedList(pageNumber, pagesize));
        }
        public ActionResult CaPhe(int? page, string Name, string first, string end, string currentFilter, string currentFilter1, string currentFilter2)
        {
            if (Name != null)
            {
                page = 1;
            }
            else
            {
                Name = currentFilter;
            }
            if (first != null)
            {
                page = 1;
            }
            else
            {
                first = currentFilter1;
            }
            if (end != null)
            {
                page = 1;
            }
            else
            {
                end = currentFilter2;
            }
            ViewBag.currentFilter1 = first;
            ViewBag.currentFilter2 = end;
            ViewBag.currentFilter = Name;
            var sanpham = (from sp in db.SanPham
                           join l in db.PhanLoai on sp.MaLoai equals l.MaLoai
                           where l.TenLoai == "Cà phê"
                           select sp).ToList();
            int pagesize = 8;
            int pageNumber = (page ?? 1);
            ViewBag.Loai = "CÀ PHÊ";

            try
            {
                if (!String.IsNullOrEmpty(Name) && String.IsNullOrEmpty(first) && String.IsNullOrEmpty(end))
                {
                    sanpham = sanpham.Where(p => p.TenSP.ToLower().Contains(Name.ToLower())).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && String.IsNullOrEmpty(Name))
                {
                    sanpham = sanpham.Where(p => p.GiaBan >= long.Parse(first) && p.GiaBan <= long.Parse(end)).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && long.Parse(end) < long.Parse(first))
                {
                    ViewBag.Error = "Giá không hợp lệ";
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && !String.IsNullOrEmpty(Name))
                {
                    sanpham = sanpham.Where(p => p.GiaBan >= long.Parse(first) && p.GiaBan <= long.Parse(end) && p.TenSP.ToLower().Contains(Name.ToLower())).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Không hợp lệ";

            }
            return View(sanpham.ToPagedList(pageNumber, pagesize));
        }
        public ActionResult DoAnVat(int? page, string Name, string first, string end, string currentFilter, string currentFilter1, string currentFilter2)
        {
            if (Name != null)
            {
                page = 1;
            }
            else
            {
                Name = currentFilter;
            }
            if (first != null)
            {
                page = 1;
            }
            else
            {
                first = currentFilter1;
            }
            if (end != null)
            {
                page = 1;
            }
            else
            {
                end = currentFilter2;
            }
            ViewBag.currentFilter1 = first;
            ViewBag.currentFilter2 = end;
            ViewBag.currentFilter = Name;
            var sanpham = (from sp in db.SanPham
                           join l in db.PhanLoai on sp.MaLoai equals l.MaLoai
                           where l.TenLoai == "Đồ ăn vặt"
                           select sp).ToList();
            int pagesize = 8;
            int pageNumber = (page ?? 1);
            ViewBag.Loai = "ĐỒ ĂN VẶT";

            try
            {
                if (!String.IsNullOrEmpty(Name) && String.IsNullOrEmpty(first) && String.IsNullOrEmpty(end))
                {
                    sanpham = sanpham.Where(p => p.TenSP.ToLower().Contains(Name.ToLower())).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && String.IsNullOrEmpty(Name))
                {
                    sanpham = sanpham.Where(p => p.GiaBan >= long.Parse(first) && p.GiaBan <= long.Parse(end)).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && long.Parse(end) < long.Parse(first))
                {
                    ViewBag.Error = "Giá không hợp lệ";
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && !String.IsNullOrEmpty(Name))
                {
                    sanpham = sanpham.Where(p => p.GiaBan >= long.Parse(first) && p.GiaBan <= long.Parse(end) && p.TenSP.ToLower().Contains(Name.ToLower())).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Không hợp lệ";

            }
            return View(sanpham.ToPagedList(pageNumber, pagesize));
        }
        public ActionResult TangSL(string id, string loai, int SLtam)
        {
            SLtam += 1;
            ViewBag.SL = SLtam;
            var tra = from tr in db.SanPham
                      join l in db.PhanLoai on tr.MaLoai equals l.MaLoai
                      join nl in db.NguyenLieu on tr.MaNL equals nl.MaNL
                      where tr.MaSP == id
                      select new ChiTietSanPham()
                      {
                          MaSP = tr.MaSP,
                          TenSP = tr.TenSP,
                          Anh = tr.Anh,
                          MoTa = tr.MoTa,
                          TenLoai = l.TenLoai,
                          TenNL = nl.TenNL,
                          GiaBan = tr.GiaBan
                      };
            string masp = "";
            string tensp = "";
            string anh = "";
            string mota = "";
            string tenloai = "";
            string tennl = "";
            decimal giaban=0;
            foreach (var item in tra)
            {
                masp = item.MaSP;
            }
            foreach (var item in tra)
            {
                tensp = item.TenSP;
            }
            foreach (var item in tra)
            {
                anh = item.Anh;
            }
            foreach (var item in tra)
            {
                mota = item.MoTa;
            }
            foreach (var item in tra)
            {
                tenloai = item.TenLoai;
            }
            foreach (var item in tra)
            {
                tennl = item.TenNL;
            }
            foreach (var item in tra)
            {
                giaban = item.GiaBan;
            }
            ViewBag.MaSP = masp;
            ViewBag.MaLoai = loai;
            ViewBag.TenSP = tensp;
            ViewBag.TenLoai = tenloai;
            ViewBag.TenNl = tennl;
            ViewBag.GiaBan = giaban;
            ViewBag.MoTa = mota;
            ViewBag.Anh = anh;
            var danhsach = (from ds in db.SanPham
                            where ds.MaSP != id && ds.MaLoai == loai
                            select ds).ToList();
            return RedirectToAction("Details");
        }
        public ActionResult GiamSL(string id, string loai, int SLtam)
        {
            if (SLtam > 1) { SLtam -= 1; } else { SLtam = 1; }
            ViewBag.SL = SLtam;
            var tra = from tr in db.SanPham
                      join l in db.PhanLoai on tr.MaLoai equals l.MaLoai
                      join nl in db.NguyenLieu on tr.MaNL equals nl.MaNL
                      where tr.MaSP == id
                      select new ChiTietSanPham()
                      {
                          MaSP = tr.MaSP,
                          TenSP = tr.TenSP,
                          Anh = tr.Anh,
                          MoTa = tr.MoTa,
                          TenLoai = l.TenLoai,
                          TenNL = nl.TenNL,
                          GiaBan = tr.GiaBan
                      };
            string masp = "";
            string tensp = "";
            string anh = "";
            string mota = "";
            string tenloai = "";
            string tennl = "";
            decimal giaban = 0;
            foreach (var item in tra)
            {
                masp = item.MaSP;
            }
            foreach (var item in tra)
            {
                tensp = item.TenSP;
            }
            foreach (var item in tra)
            {
                anh = item.Anh;
            }
            foreach (var item in tra)
            {
                mota = item.MoTa;
            }
            foreach (var item in tra)
            {
                tenloai = item.TenLoai;
            }
            foreach (var item in tra)
            {
                tennl = item.TenNL;
            }
            foreach (var item in tra)
            {
                giaban = item.GiaBan;
            }
            ViewBag.MaSP = masp;
            ViewBag.MaLoai = loai;
            ViewBag.TenSP = tensp;
            ViewBag.TenLoai = tenloai;
            ViewBag.TenNl = tennl;
            ViewBag.GiaBan = giaban;
            ViewBag.MoTa = mota;
            ViewBag.Anh = anh;
            var danhsach = (from ds in db.SanPham
                            where ds.MaSP != id && ds.MaLoai == loai
                            select ds).ToList();
            return RedirectToAction("Details");
        }
    }
}