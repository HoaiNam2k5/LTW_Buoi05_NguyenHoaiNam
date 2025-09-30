using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTVN_03.Models;

namespace BTVN_03.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HienThiLoai()
        {
            DuLieu db = new DuLieu();
            List<Loai> ds = db.dsLoai;
            return View(ds);
        }

        public ActionResult HienThiSanPham()
        {
            DuLieu db = new DuLieu();
            List<SanPham> ds = db.dsSanPham;
            return View(ds);
        }
        public ActionResult SanPhamTheoLoai(int? id)
        {
            if (id == null)
            {
         
                return RedirectToAction("HienThiSanPham");
            }
            DuLieu db = new DuLieu();
            var ds = db.GetSanPhamByLoai(id.Value);
            return View(ds);
        }
        public ActionResult TimKiem(string keyword)
        {
            DuLieu db = new DuLieu();
            var ds = db.SearchSanPham(keyword ?? "");
            ViewBag.Keyword = keyword;
            ViewBag.Count = ds.Count;
            return View(ds);
        }
        public PartialViewResult MenuSanPham()
        {
            DuLieu db = new DuLieu();
            var dsLoai = db.GetLoaiSP();
            return PartialView("_MenuSanPham", dsLoai);
        }

    }
}