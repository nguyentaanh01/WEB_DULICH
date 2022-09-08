using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lamlai_web_dulich.Models;

namespace lamlai_web_dulich.Areas.Admin.Controllers
{
    public class CamNangDuLichController : Controller
    {
        // GET: Admin/CamNangDuLich
        public ActionResult DanhSach()
        {
            return View(new mapCamNang().DanhSach());
        }

        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(CamNangDuLich model)
        {
            mapCamNang map = new mapCamNang();
            if (map.ThemMoi(model))
            {
                return RedirectToAction("DanhSach");
            }
            else
            {
                ViewBag.thongtin = map.message;
                return View();
            }
        }

        public ActionResult CapNhat(int idCamNang)
        {
            mapCamNang map = new mapCamNang();
            return View(map.ChiTiet(idCamNang));
        }
        [HttpPost]
        public ActionResult CapNhat(CamNangDuLich model)
        {
            mapCamNang map = new mapCamNang();
            if (map.CapNhat(model))
            {
                return RedirectToAction("DanhSach");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Xoa(int idCamNang)
        {
            mapCamNang map = new mapCamNang();
            map.Xoa(idCamNang);
            return RedirectToAction("DanhSach");
        }
    }
}