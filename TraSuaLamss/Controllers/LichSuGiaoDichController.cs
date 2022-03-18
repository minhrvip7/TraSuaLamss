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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang dONHANG = db.DonHang.Find(id);
            if (dONHANG == null)
            {
                /*var ctdh = new ChiTietDonHang();*/
                var sanpham=(from x in db.SanPham where x.MaSP == item.MaSP select x).FirstOrDefault();
                SanPhamTrongDonHang moi = new SanPhamTrongDonHang(){ chiTietDonHang=item,sanPham=sanpham};
                listCTSP.Add(moi);
            }
            
            return View(listCTSP);
        }
    }
}