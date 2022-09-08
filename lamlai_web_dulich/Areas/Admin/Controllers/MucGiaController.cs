using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lamlai_web_dulich.Models;

namespace lamlai_web_dulich.Areas.Admin.Controllers
{
    public class MucGiaController : Controller
    {
        // GET: Admin/MucGia
        public ActionResult DanhSach()
        {
            mapMucGia map = new mapMucGia();
            return View(map.DanhSach());
        }

        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(MucGia model)
        {
            mapMucGia map = new mapMucGia();
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

        public ActionResult CapNhat(int idMucGia)
        {
            mapMucGia map = new mapMucGia();
            return View(map.ChiTiet(idMucGia));
        }
        [HttpPost]
        public ActionResult CapNhat(MucGia model)
        {
            mapMucGia map = new mapMucGia();
            if(map.CapNhat(model))
            {
                return RedirectToAction("DanhSach");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Xoa(int idMucGia)
        {
            mapMucGia map = new mapMucGia();
            map.Xoa(idMucGia);
            return RedirectToAction("DanhSach");
        }
    }
}