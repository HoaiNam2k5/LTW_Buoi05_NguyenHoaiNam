using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTVN_03.Models;

namespace BTVN_03.Controllers
{
    public class SanPhamController : Controller
    {
        DuLieu dl = new DuLieu();

        public ActionResult MenuLoai()
        {
            var loais = dl.GetLoaiSP();
            return View(loais);
        }
        [HttpPost]
        public ActionResult SanPhamTheoLoai(int maloai)
        {
            var sps = dl.GetSanPhamByLoai(maloai);
            ViewBag.Loai = maloai;
            return View(sps);
        }
        [HttpPost]
        public ActionResult TimKiem(string keyword)
        {
            var sps = dl.SearchSanPham(keyword ?? "");
            ViewBag.Keyword = keyword;
            ViewBag.Count = sps.Count;
            return View(sps);
        }
    }
}