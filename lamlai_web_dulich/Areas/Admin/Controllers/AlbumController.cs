using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lamlai_web_dulich.Models;

namespace lamlai_web_dulich.Areas.Admin.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Admin/Album
        public ActionResult DanhSach()
        {
            mapAlbum map = new mapAlbum();
            return View(map.DanhSach());
        }

        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(AlbumAnh model)
        {
            mapAlbum map = new mapAlbum();
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

        public ActionResult CapNhat(int idAlbum)
        {
            mapAlbum map = new mapAlbum();
            return View(map.ChiTiet(idAlbum));
        }
        [HttpPost]
        public ActionResult CapNhat(AlbumAnh model)
        {
            mapAlbum map = new mapAlbum();
            if (map.CapNhat(model))
            {
                return RedirectToAction("DanhSach");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Xoa(int idAlbum)
        {
            mapAlbum map = new mapAlbum();
            map.Xoa(idAlbum);
            return RedirectToAction("DanhSach");
        }
    }
}