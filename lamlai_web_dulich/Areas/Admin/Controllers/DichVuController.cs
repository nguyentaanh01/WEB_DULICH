using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lamlai_web_dulich.Models;

namespace lamlai_web_dulich.Areas.Admin.Controllers
{
    public class DichVuController : Controller
    {
        // GET: Admin/DichVu
        public ActionResult DanhSach()
        {
            mapDichVu map = new mapDichVu();
            return View(map.DanhSach());
        }

        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(DichVu model)
        {
            mapDichVu map = new mapDichVu();
            if(map.ThemMoi(model))
            {
                return RedirectToAction("DanhSach");
            }
            else
            {
                ViewBag.thongtin = map.message;
                return View();
            }
        }

        public ActionResult CapNhat(int idDichVu)
        {
            mapDichVu map = new mapDichVu();
            return View(map.ChiTiet(idDichVu));
        }
        [HttpPost]
        public ActionResult CapNhat(DichVu model)
        {
            mapDichVu map = new mapDichVu();
            if(map.CapNhat(model))
            {
                return RedirectToAction("DanhSach");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Xoa(int idDichVu)
        {
            mapDichVu map = new mapDichVu();
            map.Xoa(idDichVu);
            return RedirectToAction("DanhSach");
        }
    }
}