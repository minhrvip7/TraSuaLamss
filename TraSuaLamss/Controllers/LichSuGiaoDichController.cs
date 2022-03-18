using System;
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
            var giaoDich = (from s in db.DonHang where s.MaKH == 1 select s);
            return View(giaoDich.ToList());
        }


        public ActionResult Details(string id)
        {
            ViewBag.donHang = (from a in db.DonHang where a.MaDH == id select a).FirstOrDefault();

            ViewBag.Ten = (from x in db.KhachHang join m in db.DonHang on x.MaKH equals m.MaKH where m.MaDH == id select x.TenKH).FirstOrDefault();

            List<ChiTietDonHang> listSP = (from x in db.ChiTietDonHang where x.MaHD == id select x).ToList();
            var listCTSP = new List<SanPhamTrongDonHang>();
            foreach (var item in listSP)
            {
                /*var ctdh = new ChiTietDonHang();*/
                var sanpham = (from x in db.SanPham where x.MaSP == item.MaSP select x).FirstOrDefault();
                SanPhamTrongDonHang moi = new SanPhamTrongDonHang() { chiTietDonHang = item, sanPham = sanpham };
                listCTSP.Add(moi);
            }

            return View(listCTSP);
        }
    }
}