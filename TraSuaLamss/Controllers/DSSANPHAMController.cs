using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraSuaLamss.Models;
using PagedList;

namespace TraSuaLamss.Controllers
{
    public class DSSANPHAMController : Controller
    {
        private TraSuaContext db = new TraSuaContext();
        private List<SANPHAM> LaySanPham()
        {
            return db.SANPHAMs.OrderByDescending(s => s.TenSP).ToList();
        }
        private bool isNumber(string a)
        {
            if (!string.IsNullOrEmpty(a))
            {
                return true;
            }
            return false;
        }
        // GET: DSSANPHAM
        public ActionResult Index(int? page, string Name, string first, string end,string currentFilter, string currentFilter1, string currentFilter2)
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

            if (!String.IsNullOrEmpty(Name))
            {
                sanpham = sanpham.Where(p => p.TenSP.ToLower().Contains(Name.ToLower())).ToList();
                return View(sanpham.ToPagedList(pageNumber, pagesize));
            }
            try
            {
                if (isNumber(first) && isNumber(end))
                {
                    sanpham = sanpham.Where(p => long.Parse(p.GiaBan) >= long.Parse(first) && long.Parse(p.GiaBan) <= long.Parse(end)).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Giá không hợp lệ";

            }
            return View(sanpham.ToPagedList(pageNumber, pagesize));
        }

        public ActionResult Details(string id)
        {
            var tra = from tr in db.SANPHAMs
                      where tr.MaSP == id
                      select tr;
            return View(tra.Single());
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
            var sanpham = (from sp in db.SANPHAMs
                           join l in db.PHANLOAIs on sp.MaLoai equals l.MaLoai
                           where l.TenLoai == "Trà sữa"
                           select sp).ToList();
            int pagesize = 8;
            int pageNumber = (page ?? 1);
            ViewBag.Loai = "TRÀ SỮA";
            if (!String.IsNullOrEmpty(Name))
            {

                sanpham = sanpham.Where(p => p.TenSP.ToLower().Contains(Name.ToLower())).ToList();
                return View(sanpham.ToPagedList(pageNumber, pagesize));
            }
            try
            {
                if (isNumber(first) && isNumber(end))
                {
                    sanpham = sanpham.Where(p => long.Parse(p.GiaBan) >= long.Parse(first) && long.Parse(p.GiaBan) <= long.Parse(end)).ToList();
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
            var sanpham = (from sp in db.SANPHAMs
                           join l in db.PHANLOAIs on sp.MaLoai equals l.MaLoai
                           where l.TenLoai == "Trà"
                           select sp).ToList();
            int pagesize = 8;
            int pageNumber = (page ?? 1);
            ViewBag.Loai = "TRÀ";
            if (!String.IsNullOrEmpty(Name))
            {

                sanpham = sanpham.Where(p => p.TenSP.ToLower().Contains(Name.ToLower())).ToList();
                return View(sanpham.ToPagedList(pageNumber, pagesize));
            }
            try
            {
                if (isNumber(first) && isNumber(end))
                {
                    sanpham = sanpham.Where(p => long.Parse(p.GiaBan) >= long.Parse(first) && long.Parse(p.GiaBan) <= long.Parse(end)).ToList();
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
            var sanpham = (from sp in db.SANPHAMs
                           join l in db.PHANLOAIs on sp.MaLoai equals l.MaLoai
                           where l.TenLoai == "Cà phê"
                           select sp).ToList();
            int pagesize = 8;
            int pageNumber = (page ?? 1);
            ViewBag.Loai = "CÀ PHÊ";
            if (!String.IsNullOrEmpty(Name))
            {

                sanpham = sanpham.Where(p => p.TenSP.ToLower().Contains(Name.ToLower())).ToList();
                return View(sanpham.ToPagedList(pageNumber, pagesize));
            }
            try
            {
                if (isNumber(first) && isNumber(end))
                {
                    sanpham = sanpham.Where(p => long.Parse(p.GiaBan) >= long.Parse(first) && long.Parse(p.GiaBan) <= long.Parse(end)).ToList();
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
            var sanpham = (from sp in db.SANPHAMs
                           join l in db.PHANLOAIs on sp.MaLoai equals l.MaLoai
                           where l.TenLoai == "Đồ ăn vặt"
                           select sp).ToList();
            int pagesize = 8;
            int pageNumber = (page ?? 1);
            ViewBag.Loai = "ĐỒ ĂN VẶT";
            if (!String.IsNullOrEmpty(Name))
            {
                sanpham = sanpham.Where(p => p.TenSP.ToLower().Contains(Name.ToLower())).ToList();
                return View(sanpham.ToPagedList(pageNumber, pagesize));
            }
            try
            {
                if (isNumber(first) && isNumber(end))
                {
                    sanpham = sanpham.Where(p => long.Parse(p.GiaBan) >= long.Parse(first) && long.Parse(p.GiaBan) <= long.Parse(end)).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Không hợp lệ";

            }
            return View(sanpham.ToPagedList(pageNumber, pagesize));
        }
    }
}