﻿using System;
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
        private const string MaKH = "MaKH";
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
                    sanpham = sanpham.Where(p => p.GiaBan >= decimal.Parse(first) && p.GiaBan <= decimal.Parse(end)).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && decimal.Parse(end) < decimal.Parse(first))
                {
                    ViewBag.Error = "Giá nhập không hợp lệ";
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && !String.IsNullOrEmpty(Name))
                {
                    sanpham = sanpham.Where(p => p.GiaBan >= decimal.Parse(first) && p.GiaBan <= decimal.Parse(end) && p.TenSP.ToLower().Contains(Name.ToLower())).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Giá nhập không hợp lệ";

            }

            return View(sanpham.ToPagedList(pageNumber, pagesize));
        }
        public ActionResult Details(string id, string loai)
        {
            ViewBag.MaKH = 1;
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
                          GiaBan = tr.GiaBan,
                          MaLoai = l.MaLoai
                      };
            foreach (var item in tra)
            {
                ViewBag.MaSP = item.MaSP;
                ViewBag.TenSP = item.TenSP;
                ViewBag.Anh = item.Anh;
                ViewBag.MoTa = item.MoTa;
                ViewBag.TenLoai = item.TenLoai;
                ViewBag.TenNl = item.TenNL;
                ViewBag.GiaBan = item.GiaBan;
            }
            var danhsach = from ds in db.SanPham
                           join l in db.PhanLoai on ds.MaLoai equals l.MaLoai
                           where ds.MaSP != id && l.MaLoai == loai
                           select ds;
            return View(danhsach.ToList());
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
                    sanpham = sanpham.Where(p => p.GiaBan >= decimal.Parse(first) && p.GiaBan <= decimal.Parse(end)).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && decimal.Parse(end) < decimal.Parse(first))
                {
                    ViewBag.Error = "Giá nhập không hợp lệ";
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && !String.IsNullOrEmpty(Name))
                {
                    sanpham = sanpham.Where(p => p.GiaBan >= decimal.Parse(first) && p.GiaBan <= decimal.Parse(end) && p.TenSP.ToLower().Contains(Name.ToLower())).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Giá nhập không hợp lệ";

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
                    sanpham = sanpham.Where(p => p.GiaBan >= decimal.Parse(first) && p.GiaBan <= decimal.Parse(end)).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && decimal.Parse(end) < decimal.Parse(first))
                {
                    ViewBag.Error = "Giá nhập không hợp lệ";
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && !String.IsNullOrEmpty(Name))
                {
                    sanpham = sanpham.Where(p => p.GiaBan >= decimal.Parse(first) && p.GiaBan <= decimal.Parse(end) && p.TenSP.ToLower().Contains(Name.ToLower())).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Giá nhập không hợp lệ";

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
                    sanpham = sanpham.Where(p => p.GiaBan >= decimal.Parse(first) && p.GiaBan <= decimal.Parse(end)).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && decimal.Parse(end) < decimal.Parse(first))
                {
                    ViewBag.Error = "Giá nhập không hợp lệ";
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && !String.IsNullOrEmpty(Name))
                {
                    sanpham = sanpham.Where(p => p.GiaBan >= decimal.Parse(first) && p.GiaBan <= decimal.Parse(end) && p.TenSP.ToLower().Contains(Name.ToLower())).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Giá nhập không hợp lệ";

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
                    sanpham = sanpham.Where(p => p.GiaBan >= decimal.Parse(first) && p.GiaBan <= decimal.Parse(end)).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && decimal.Parse(end) < decimal.Parse(first))
                {
                    ViewBag.Error = "Giá nhập không hợp lệ";
                }
                else if (!String.IsNullOrEmpty(first) && !String.IsNullOrEmpty(end) && !String.IsNullOrEmpty(Name))
                {
                    sanpham = sanpham.Where(p => p.GiaBan >= decimal.Parse(first) && p.GiaBan <= decimal.Parse(end) && p.TenSP.ToLower().Contains(Name.ToLower())).ToList();
                    return View(sanpham.ToPagedList(pageNumber, pagesize));
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Giá nhập không hợp lệ";

            }
            return View(sanpham.ToPagedList(pageNumber, pagesize));
        }
    }
}