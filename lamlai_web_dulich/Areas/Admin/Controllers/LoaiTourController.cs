using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lamlai_web_dulich.Models;

namespace lamlai_web_dulich.Areas.Admin.Controllers
{
    public class LoaiTourController : Controller
    {
        // GET: Admin/LoaiTour
        public ActionResult DanhSach()
        {
            mapLoaiTour map = new mapLoaiTour();
            return View(map.DanhSach());
        }

        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(LoaiTour model)
        {
            //1. Khai báo mapLoaiTour
            mapLoaiTour map = new mapLoaiTour();
            if(map.ThemMoi(model))
            {
                return RedirectToAction("DanhSach");
            }
            else
            {
                ViewBag.thongbao = map.message;
                return View();
            }
        }

        public ActionResult CapNhat(int idLoaiTour)
        {
            mapLoaiTour map = new mapLoaiTour();
            //1. Tìm nó đã
            LoaiTour updateLT = map.Chitiet(idLoaiTour);
            return View(updateLT);
        }
        [HttpPost]
        public ActionResult CapNhat(LoaiTour model)
        {
            mapLoaiTour map = new mapLoaiTour();
            if(map.CapNhat(model))
            {
                return RedirectToAction("DanhSach");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Xoa(int idLoaiTour)
        {
            mapLoaiTour map = new mapLoaiTour();
            map.Xoa(idLoaiTour);
            return RedirectToAction("DanhSach");
        }
    }
}