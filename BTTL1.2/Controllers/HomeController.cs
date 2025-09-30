using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buoi05.Models;
using Buoi05.ViewModels;


namespace Buoi05.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HienThiNhanVien()
        {
            DuLieu csdl = new DuLieu();
            List<Employee> ds = csdl.dsnv;
            return View(ds);
        }
        public ActionResult HienthiPhongBan()
        {
            DuLieu csdl = new DuLieu();
            List<Deparment> ds=csdl.dspb;
            return View(ds);
        }
        [HttpGet]
        public ActionResult Detail_PhongBan(int id)
        {
            DuLieu csdl = new DuLieu();
            DepartmentViewModel department = new DepartmentViewModel();
            Deparment ds = csdl.ChiTietPhongBan(id);
            List<Employee> dsnv = csdl.DanhSachNhanVienTheoMaPhong(id);
            department.Department = ds;

            return View(department);
        }
        [HttpGet]
        public ActionResult AddNew_PhongBan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNew_PhongBan(string Id, string Name)
        {
            DuLieu csdl = new DuLieu();
            Deparment department = new Deparment();
            department.Maph = int.Parse(Id);
            department.TenPh= Name;
            bool result = csdl.ThemPhongBan(department);
            ViewBag.Message = result == true ? "SUCCESS" : "FAILURE";
            return View();
        }

        [HttpGet]
        public ActionResult Edit_PhongBan(int id)
        {
            DuLieu csdl = new DuLieu();
            Deparment ds = csdl.ChiTietPhongBan(id);
            return View(ds);
        }

        [HttpPost]
        public ActionResult Edit_PhongBan(string Id, string Name)
        {
            DuLieu csdl = new DuLieu();
            Deparment department = new Deparment();
            department.Maph = int.Parse(Id);
            department.TenPh= Name;
            bool result = csdl.CapNhatPhongBan(department);

            ViewBag.Message = result == true ? "SUCCESS" : "FAILURE";
            return View(department);
        }

        [HttpGet]
        public ActionResult Delete_PhongBan(int id)
        {
            DuLieu csdl = new DuLieu();
            bool result = csdl.XoaPhongBan(id);

            //    ViewBag.Message = result == true ? "SUCCESS" : "FAILURE";
            return RedirectToAction("HienThiPhongBan", "Home");
        }
    }
}